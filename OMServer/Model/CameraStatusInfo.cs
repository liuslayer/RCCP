using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMServer.Model
{
    [Serializable]
    public class CameraStatusInfos
    {
        public List<CameraStatusInfo> cameraStatuslist;
    }

    [Serializable]
    public class CameraStatusInfo
    {
        public string ID;
        public string ONLINE;
        public string IMGSTATUS;
        public string IMGQUALITY;
        public string BITSTREAM;
        public string NETSTATUS;
        public string ALARM;
        public string TIME;
    }
}
