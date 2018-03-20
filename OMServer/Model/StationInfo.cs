using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMServer.Model
{
    [Serializable]
    public class StationInfos
    {
        public List<StationInfo> stationList;
    }

    [Serializable]
    public class StationInfo
    {
        public string ID;
        public string DEPTID;
        public string NAME;
        public string TYPE;
        public string BUILDTIME;
        public string FACTOTY;
        public string REMARK;
        public string LOGOUT;
        public string LON;
        public string LAT;       
    }
}
