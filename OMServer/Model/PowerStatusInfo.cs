using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMServer.Model
{
    [Serializable]
    public class PowerStatusInfos
    {
        public List<PowerStatusInfo> powerStatusList;
    }

    [Serializable]
    public class PowerStatusInfo
    {
        public List<BatteryStatusInfo> batterys;
        public string ID;
        public string VOLTAGE;
        public string CURRENT;
        public string RESISTANCE;
        public string TEMP;
        public string HUMI;
        public string ALARM;
        public string TIME;
    }
}
