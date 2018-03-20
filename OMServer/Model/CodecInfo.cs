using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMServer.Model
{
    [Serializable]
    public class CodecInfos
    {
        public List<CodecInfo> codecList;
    }

    [Serializable]
    public class CodecInfo
    {
        public List<CameraInfo> camList;
        public string ID;
        public string DEPTID;
        public string NAME;
        public string TYPE;
        public string BRAND;
        public string IP;
        public string CHNUM;
        public string USER;
        public string PASS;
        public string PORT;
       
    }


}
