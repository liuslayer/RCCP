using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVM
{
    public class SVMServerCommunicate : CommunicateBase
    {
        public delegate void NewCommandEventHandler(CommandClass commandClass);
        public event NewCommandEventHandler OnNewCommand;//设备信息更新事件

        public event Action<string, string> OnNewDispatchMsg;

        public event Action<BaseDataClass.DutyRecordInfoList> OnNewDuty;
        public SVMServerCommunicate(string remoteIP, int remotePort, string localIP)
            : base(remoteIP, remotePort, localIP)
        {

        }

        protected override void ProcessProtocol(object arg)
        {
            string content = string.Empty;
            string protocol = arg as string;
            if (protocol.StartsWith("SVMCommand"))
            {
                content = protocol.Substring("SVMCommand".Length).Trim();
                try
                {
                    CommandClass cc = JsonConvert.DeserializeObject<CommandClass>(content);
                    OnNewCommand(cc);
                }
                catch
                { }
            }
            else if (protocol.StartsWith("DispatchMsg"))
            {
                content = protocol.Substring("DispatchMsg".Length).Trim();
                try
                {
                    string[] dispatchMsg = content.Split(',');
                    OnNewDispatchMsg(dispatchMsg[0], dispatchMsg[1]);
                }
                catch
                { }
            }
            else if (protocol.StartsWith("SVMMsg"))
            {
                content = protocol.Substring("SVMMsg".Length).Trim();
                try
                {
                    try
                    {
                        BaseDataClass.DutyRecordInfoList dutyRecordInfo = JsonConvert.DeserializeObject<BaseDataClass.DutyRecordInfoList>(content);
                        OnNewDuty(dutyRecordInfo);
                    }
                    catch
                    { }
                }
                catch
                { }
            }
        }
    }
}
