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
    public class SVMMsg : CommandBase<CommandDispatchSession, StringRequestInfo>
    {
        public override void ExecuteCommand(CommandDispatchSession session, StringRequestInfo requestInfo)
        {
            //var desSession = session.AppServer.GetSessions(_ => _.RemoteEndPoint != session.RemoteEndPoint);
            foreach (var item in session.AppServer.GetSessions(_ => _.RemoteEndPoint != session.RemoteEndPoint))
            {
                string sendMsg = "SVMMsg" + " " + requestInfo.Body + "\r\n";
                item.TrySend(sendMsg);
            }
        }
    }
}
