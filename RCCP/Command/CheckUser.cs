using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command
{
    public class CheckUser:CommandBase<AppSession, StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
           bool result= new BusinessCollaborationService.CheckUser().check(requestInfo.Parameters[0], requestInfo.Parameters[1]);
            session.Send(result.ToString());
        }
    }
}
