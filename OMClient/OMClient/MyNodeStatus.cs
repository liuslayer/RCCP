using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMClient
{
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

    public class ManagementResult
    {
        public bool result { get; set; }
        public string Message { get; set; }
        public MyNodeStatus MyNodeStatus { get; set; }
    }
}
