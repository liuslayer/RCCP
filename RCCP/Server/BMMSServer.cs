using LogServer;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace RCCP.Server
{
    public class BMMSServer:AppServer<AppSession>
    {
        public static List<AppSession> sessions = new List<AppSession>();
        public BMMSServer()
        : base(new CommandLineReceiveFilterFactory(Encoding.UTF8, new BasicRequestInfoParser("/", ",")))
        {
        }
        protected override void OnStarted()
        {
            base.OnStarted();
            LogServerManager.AddRunLog(OperationType.System, "服务器BMMSServer启动");
        }
        /// <summary>  
        /// 输出新连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        protected override void OnNewSessionConnected(AppSession session)
        {
            base.OnNewSessionConnected(session);
            sessions.Add(session);
        }

        /// <summary>  
        /// 输出断开连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(AppSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i] == session)
                    sessions.RemoveAt(i);
            }
        }

        protected override void OnStopped()
        {
            base.OnStopped();
            LogServerManager.AddRunLog(OperationType.System, "服务器BMMSServer已停止");
        }
    }
    public class ReceiveServiceStatus
    {
        public static void Receive(NodeStatus m_CurrentNodeStatus)
        {
            //Thread thread = new Thread(new ParameterizedThreadStart(WriteXML));
            //thread.IsBackground = true;
            //thread.Start(m_CurrentNodeStatus);
            WriteXML(m_CurrentNodeStatus);
        }

        private static void WriteXML(object CurrentNodeStatus)
        {
            NodeStatus m_CurrentNodeStatus = (NodeStatus)CurrentNodeStatus;
            var instancesStatus = m_CurrentNodeStatus.InstancesStatus;
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
                string message = InstancesStatus.Name + ":" + InstancesStatus.IsRunning;
                
                //通知基础模块管理
                IPAddress ipAddress = IPAddress.Parse(System.Configuration.ConfigurationManager.AppSettings["BMMSServer_IP"]);
                IPEndPoint ipe = new IPEndPoint(ipAddress, int.Parse(System.Configuration.ConfigurationManager.AppSettings["BMMSServer_Port"]));
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    clientSocket.Connect(ipe);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("连接基础模块失败！错误信息：" + ex.ToString());
                }
                string sendStr = InstancesStatus.Name + "," + InstancesStatus.IsRunning;
                byte[] sendBytes = Encoding.UTF8.GetBytes(sendStr);
                try
                {
                    clientSocket.Send(sendBytes);
                }
                catch { }

                #region 写入ServiceStatus.xml
                //string path = @".\ServiceStatus.xml";
                //XmlDocument xml = new XmlDocument();
                //if (!File.Exists(path))
                //{
                //    XmlDeclaration xmldecl = xml.CreateXmlDeclaration("1.0", "utf-8", null);
                //    xml.AppendChild(xmldecl);
                //    XmlElement xmlelem = xml.CreateElement("services");
                //    xml.AppendChild(xmlelem);
                //    xml.Save(path);
                //}
                //xml.Load(path);//加载xml文件
                //XmlNode root = xml.SelectSingleNode("services");//查找<root>
                //XmlNodeList list = root.ChildNodes;
                //string ip = InstancesStatus.Listeners.Split(new char[] { ':' })[0];
                //string port = InstancesStatus.Listeners.Split(new char[] { ':' })[1];
                //bool exist = false;

                //foreach (XmlNode node in list)
                //{
                //    if (node.Attributes["name"].InnerText.ToString() == InstancesStatus.Name)
                //    {
                //        exist = true;
                //        if(node.ChildNodes[0].InnerText != InstancesStatus.IsRunning)
                //        {
                //            node.ChildNodes[0].InnerText = InstancesStatus.IsRunning;
                //            xml.Save(path);
                //            //通知客户端
                //            for (int i = 0; i < BMMSServer.sessions.Count; i++)
                //            {
                //                BMMSServer.sessions[i].Send(InstancesStatus.Name + "_" + InstancesStatus.IsRunning);
                //            }
                //        }
                //    }
                //}
                #endregion

                ////通知客户端
                //XmlDocument xml = new XmlDocument();
                for (int i = 0; i < BMMSServer.sessions.Count; i++)
                {
                    try
                    {
                        BMMSServer.sessions[i].Send(InstancesStatus.Name + "_" + InstancesStatus.IsRunning + "\r\n");

                    }
                    catch { }
                }
                //if (!exist)
                //{
                //    XmlElement ele = xml.CreateElement("service");//创建一个user节点
                //    ele.SetAttribute("name", InstancesStatus.Name);
                //    ele.SetAttribute("ip", ip);
                //    ele.SetAttribute("port", port);
                //    XmlElement status = xml.CreateElement("status");
                //    status.InnerText = InstancesStatus.IsRunning;
                //    ele.AppendChild(status);
                //    root.AppendChild(ele);
                //    xml.Save(path);
                //}
            }
        }
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
