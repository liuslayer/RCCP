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
    /// <summary>
    /// 指挥调度即时消息
    /// </summary>
    public class DispatchMsg : CommandBase<CommandDispatchSession, StringRequestInfo>
    {
        public override void ExecuteCommand(CommandDispatchSession session, StringRequestInfo requestInfo)
        {
            //var desSession = session.AppServer.GetSessions(_ => _.RemoteEndPoint != session.RemoteEndPoint);
            foreach (var item in session.AppServer.GetSessions(_ => _.RemoteEndPoint != session.RemoteEndPoint))
            {
                string sendMsg = "DispatchMsg" + " " + requestInfo.Body + "\r\n";
                item.TrySend(sendMsg);
            }
        }
    }
}
