using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMServer.Model
{
    [Serializable]
    public class VoiceInfo
    {
        public string TYPE;//0发起请求，1反馈(同意，拒绝)，2断开
        public string RESULT;//仅反馈时用:0同意，1拒绝
        public string INFO;//仅拒绝时用
        public string IP;
        public string PORT;
        public string CHANNEL;
        public string USER;
        public string PASSWORD;
    }
}
