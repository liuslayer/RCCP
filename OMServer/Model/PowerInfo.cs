using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMServer.Model
{
    [Serializable]
    public class PowerInfos
    {
        public List<PowerInfo> powerList;
    }

    [Serializable]
    public class PowerInfo
    {
        public string ID;
        public string STATIONID;
        public string NAME;
        public string TYPE;
        public string BRAND;
        public string BATTERYNUM;
        public string BATTERYCURRENT;
        public string BATTERYVOLTAGE;
        public string BATTERYBTIME;
        public string BATTERYLASTTIME;
        public string BATTERYFACTORY;
        public string PANELNUM;
        public string PANELPOWER;
        public string PANELVOLTAGE;
        public string PANELBTIME;
        public string PANELLASTTIME;
        public string PANELFACTORY;
        public string CTRLVOLTAGE;
        public string CTRLBTIME;
        public string CTRLLASTTIME;
        public string CTRLFACTORY;
        public string LON;
        public string LAT;
    }
}
