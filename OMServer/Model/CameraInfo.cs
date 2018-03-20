using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMServer.Model
{
    [Serializable]
    public class CameraInfo
    {
        public string ID;
        public string STATIONID;
        public string CHINDEX;
        public string NAME;
        public string TYPE;       
        public string LON;
        public string LAT;
    }
}
