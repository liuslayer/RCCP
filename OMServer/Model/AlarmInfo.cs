using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMServer.Model
{
    [Serializable]
    public class AlarmInfo
    {
        public string ID;
        public string TIME;
        public string LOCATION;
        public string TYPE;
        public string CHARACTER;
        public string COMMENT;
        public string IP;
        public string CHANNEL;
    }
}
