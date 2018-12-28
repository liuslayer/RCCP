using RCCP.Common;
using RCCP.Server;
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
    public class IntergratedInfoPublish : CommandBase<CommandDispatchSession, StringRequestInfo>
    {
        public override void ExecuteCommand(CommandDispatchSession session, StringRequestInfo requestInfo)
        {
            string message = CommandUtils.TerminalCommandAssemble(DispatchCommandEnum.IntergratedInfoPublish.ToString(), requestInfo.Body);
            CommandDispatchServer commandDispatchServer = session.AppServer as CommandDispatchServer;
            commandDispatchServer.DispatchToEDCServer("PublishClient", message);
        }
    }
}
