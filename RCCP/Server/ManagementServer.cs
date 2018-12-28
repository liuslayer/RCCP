
using LogServer;
using Newtonsoft.Json;
using RCCP.Session;
using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperSocket.ServerManager
{
    public class ManagementServer : AppServer<ManagementSession>
    {
        private NodeStatus m_CurrentNodeStatus;

        /// <summary>
        /// Gets the current node status.
        /// </summary>
        /// <value>
        /// The current node status.
        /// </value>
        internal NodeStatus CurrentNodeStatus
        {
            get { return m_CurrentNodeStatus; }
        }

        private MyNodeStatus _myNodeStatus;
        internal MyNodeStatus MyNodeStatus
        {
            get { return _myNodeStatus; }
        }

        protected override void OnStarted()
        {
            base.OnStarted();
            LogServerManager.AddRunLog(OperationType.System, "服务器ManagementServer启动");
            Console.WriteLine("服务器ManagementServer启动");
        }

        /// <summary>  
        /// 输出新连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        protected override void OnNewSessionConnected(ManagementSession session)
        {
            base.OnNewSessionConnected(session);
            //输出客户端IP地址  
            Console.WriteLine("ManagementServer:" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + "连接");
        }

        /// <summary>  
        /// 输出断开连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(ManagementSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            Console.WriteLine("ManagementServer" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + ":断开连接");
        }

        protected override void OnStopped()
        {
            base.OnStopped();
            LogServerManager.AddRunLog(OperationType.System, "服务器ManagementServer已停止");
            Console.WriteLine("服务ManagementServer已停止");
        }

        private static object lockObj = new object();
        protected override void OnSystemMessageReceived(string messageType, object messageData)
        {
            if (messageType == "ServerStatusCollected")
            {
                var nodeStatus = (NodeStatus)messageData;
                nodeStatus.InstancesStatus = nodeStatus.InstancesStatus.Where(s => s.Name != "ManagementServer").ToArray();
                m_CurrentNodeStatus = nodeStatus;

                //Task.Run(() =>
                //{
                //    RCCP.Server.ReceiveServiceStatus.Receive(m_CurrentNodeStatus);
                //});
                
                //if (Monitor.TryEnter(m_CurrentNodeStatus))
                //{
                //    try
                //    {
                //        BroadcastServerUpdate();
                //    }
                //    catch (Exception e)
                //    {
                //        Logger.Error("BroadcastServerUpdate error", e);
                //    }
                //    finally
                //    {
                //        Monitor.Exit(m_CurrentNodeStatus);
                //    }
                //}
                lock (lockObj)
                {
                    try
                    {
                        BroadcastServerUpdate();
                    }
                    catch (Exception e)
                    {
                        Logger.Error("BroadcastServerUpdate error", e);
                    }
                }
            }
        }

        private void BroadcastServerUpdate()
        {
            _myNodeStatus = ConvetToMyEntity(m_CurrentNodeStatus);
            var message = string.Format("{0} {1}\r\n", "ManagementServer ", JsonConvert.SerializeObject(_myNodeStatus));
            int i = this.SessionCount;
            //Only push update to loged in sessions
            foreach (var s in this.GetSessions(s => s.Connected))
            {
                s.TrySend(message);
            }
        }

        private MyNodeStatus ConvetToMyEntity(NodeStatus m_CurrentNodeStatus)
        {
            MyNodeStatus myNodeStatus = new MyNodeStatus();
            var bootstrapStatus = m_CurrentNodeStatus.BootstrapStatus;
            MyBootstrapStatus myBootstrapStatus = new MyBootstrapStatus();
            myBootstrapStatus.AvailableWorkingThreads = bootstrapStatus.Values["AvailableWorkingThreads"].ToString();
            myBootstrapStatus.AvailableCompletionPortThreads = bootstrapStatus.Values["AvailableCompletionPortThreads"].ToString();
            myBootstrapStatus.MaxCompletionPortThreads = bootstrapStatus.Values["MaxCompletionPortThreads"].ToString();
            myBootstrapStatus.MaxWorkingThreads = bootstrapStatus.Values["MaxWorkingThreads"].ToString();
            myBootstrapStatus.TotalThreadCount = bootstrapStatus.Values["TotalThreadCount"].ToString();
            myBootstrapStatus.CpuUsage = bootstrapStatus.Values["CpuUsage"].ToString();
            myBootstrapStatus.MemoryUsage = bootstrapStatus.Values["MemoryUsage"].ToString();
            myNodeStatus.MyBootstrapStatus = myBootstrapStatus;

            var instancesStatus = m_CurrentNodeStatus.InstancesStatus;
            myNodeStatus.MyInstancesStatus = new List<MyInstancesStatus>();
            foreach (var item in instancesStatus)
            {
                MyInstancesStatus InstancesStatus = new MyInstancesStatus();
                InstancesStatus.CollectedTime = item.CollectedTime.ToString();
                InstancesStatus.Name = item.Name;
                InstancesStatus.Tag = item.Tag;
                InstancesStatus.MaxConnectionNumber = item.Values["MaxConnectionNumber"].ToString();
                ListenerInfo[] ListenerInfos = item.Values["Listeners"] as ListenerInfo[];
                if (ListenerInfos == null || ListenerInfos.Length < 1)
                {
                    InstancesStatus.Listeners = "0.0.0.0";
                }
                else
                {
                    InstancesStatus.Listeners = ListenerInfos[0].EndPoint.ToString();
                }
                InstancesStatus.IsRunning = item.Values["IsRunning"].ToString();
                InstancesStatus.StartedTime = !item.Values.ContainsKey("StartedTime") || item.Values["StartedTime"] == null ? string.Empty : item.Values["StartedTime"].ToString();
                InstancesStatus.TotalConnections = item.Values["TotalConnections"].ToString();
                InstancesStatus.RequestHandlingSpeed = item.Values["RequestHandlingSpeed"].ToString();
                InstancesStatus.TotalHandledRequests = item.Values["TotalHandledRequests"].ToString();
                InstancesStatus.AvialableSendingQueueItems = item.Values["AvialableSendingQueueItems"].ToString();
                InstancesStatus.TotalSendingQueueItems = item.Values["TotalSendingQueueItems"].ToString();
                myNodeStatus.MyInstancesStatus.Add(InstancesStatus);
            }
            return myNodeStatus;
        }

        /// <summary>
        /// Gets the name of the server by.
        /// </summary>
        /// <param name="serverName">Name of the server.</param>
        /// <returns></returns>
        public IWorkItem GetServerByName(string serverName)
        {
            return Bootstrap.AppServers.FirstOrDefault(s => s.Name.Equals(serverName, StringComparison.OrdinalIgnoreCase));
        }
    }

    [Serializable]
    public class MyNodeStatus
    {
        public MyBootstrapStatus MyBootstrapStatus { get; set; }

        public List<MyInstancesStatus> MyInstancesStatus { get; set; }
    }

    [Serializable]
    public class MyBootstrapStatus
    {
        public string AvailableWorkingThreads { get; set; }
        public string AvailableCompletionPortThreads { get; set; }
        public string MaxCompletionPortThreads { get; set; }
        public string MaxWorkingThreads { get; set; }
        public string TotalThreadCount { get; set; }
        public string CpuUsage { get; set; }
        public string MemoryUsage { get; set; }
    }

    [Serializable]
    public class MyInstancesStatus
    {
        public string CollectedTime { get; set; }
        public string Name { get; set; }
        public string StartedTime { get; set; }
        public string IsRunning { get; set; }
        public string MaxConnectionNumber { get; set; }
        public string Listeners { get; set; }
        public string TotalConnections { get; set; }
        public string RequestHandlingSpeed { get; set; }
        public string TotalHandledRequests { get; set; }
        public string AvialableSendingQueueItems { get; set; }
        public string TotalSendingQueueItems { get; set; }
        public string Tag { get; set; }
    }
}
