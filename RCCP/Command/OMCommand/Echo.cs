using OMServer;
using RCCP.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command
{
    public class Echo : CommandBase<OMSession, StringRequestInfo>
    {
        public override void ExecuteCommand(OMSession session, StringRequestInfo requestInfo)
        {
            string message = "Echo\r\n";//命令行协议
            session.TrySend(message);
        }
    }
}
