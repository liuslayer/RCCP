using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMServer.Model
{
    [Serializable]
    public class ServiceInfos
    {
        public List<ServiceInfo> serverList;
    }

    [Serializable]
    public class ServiceInfo
    {
        public string ID;
        public string DEPTID;
        public string NAME;
        public string TYPE;
        public string IP;
        public string LON;
        public string LAT;  
    }
}
