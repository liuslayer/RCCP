using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMServer.Model
{
    [Serializable]
    public class UpsStatusInfos
    {
        public List<UpsStatusInfo> upsStatusList;
    }

    [Serializable]
    public class UpsStatusInfo
    {
        public string ID;
        public string INVOLTAGE;
        public string LVOLTAGE;
        public string OUTVOLTAGE;
        public string LOAD;
        public string FREQ;
        public string CELLVOLTAGE;
        public string TEMP;
        public string ALARM;
        public string TIME;
    }
}
