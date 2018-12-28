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
    /// <summary>
    /// 指挥调度即时消息
    /// </summary>
    public class PostStationInfo : CommandBase<CommandDispatchSession, StringRequestInfo>
    {
        public override void ExecuteCommand(CommandDispatchSession session, StringRequestInfo requestInfo)
        {
            string message = CommandUtils.TerminalCommandAssemble(DispatchCommandEnum.PostStationInfo.ToString(), requestInfo.Body);
            CommandDispatchServer commandDispatchServer = session.AppServer as CommandDispatchServer;
            commandDispatchServer.DispatchToEDCServer("CenterClient", message);
        }
    }
}
