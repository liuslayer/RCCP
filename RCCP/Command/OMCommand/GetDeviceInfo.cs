using OMServer;
using RCCP.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RCCP.Command
{
    public class GetDeviceInfo : CommandBase<OMSession, StringRequestInfo>
    {
        public override void ExecuteCommand(OMSession session, StringRequestInfo requestInfo)
        {
            session.isOMClient = true;
            string jsonContent = session.manager.GetDeviceInfoJson();
            if (string.IsNullOrEmpty(jsonContent))
                return;
            string message = OMCommand.DeviceInfo.ToString() + " " + jsonContent + "\r\n";//命令行协议
            session.TrySend(message);
        }
    }
}
