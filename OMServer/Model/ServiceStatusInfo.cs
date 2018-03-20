using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMServer.Model
{
    [Serializable]
    public class ServiceStatusInfos
    {
        public List<ServiceStatusInfo> serviceStatusList;
    }

    [Serializable]
    public class ServiceStatusInfo
    {
        public string ID;
        public string ONLINE;
        public string WORKSTATUS;
        public string TIME;
    }
}
