using OMServer;
using RCCP.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.Command
{
    public class STATION : CommandBase<OMSession, StringRequestInfo>
    {
        public override void ExecuteCommand(OMSession session, StringRequestInfo requestInfo)
        {
            OMServerManager manager = new OMServerManager();
            manager.Process_STATION_Info(requestInfo.Body);
        }
    }
}
