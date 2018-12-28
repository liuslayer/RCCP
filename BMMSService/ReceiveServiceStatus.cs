using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMMSService
{
    public class ReceiveServiceStatus
    {
        public static void Receive(NodeStatus m_CurrentNodeStatus)
        {
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
                InstancesStatus.StartedTime = item.Values["StartedTime"] == null ? string.Empty : item.Values["StartedTime"].ToString();
                InstancesStatus.TotalConnections = item.Values["TotalConnections"].ToString();
                InstancesStatus.RequestHandlingSpeed = item.Values["RequestHandlingSpeed"].ToString();
                InstancesStatus.TotalHandledRequests = item.Values["TotalHandledRequests"].ToString();
                InstancesStatus.AvialableSendingQueueItems = item.Values["AvialableSendingQueueItems"].ToString();
                InstancesStatus.TotalSendingQueueItems = item.Values["TotalSendingQueueItems"].ToString();

                Console.WriteLine(InstancesStatus.Name + ":" + InstancesStatus.IsRunning);
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
