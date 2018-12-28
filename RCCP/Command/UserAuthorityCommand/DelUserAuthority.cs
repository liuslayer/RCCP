using RCCP.Repository.Concrete;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command.UserAuthority
{
    public class DelUserAuthority:CommandBase<AppSession,StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            Guid id;
            bool b_response = false;
            if (Guid.TryParse(requestInfo.Parameters[0], out id))
            {
                UserPermissionListRepository repository = new UserPermissionListRepository();
                int i = repository.Delete(id);
                if (i != -1)
                    b_response = true;
            }
            session.Send(b_response.ToString());
        }
    }
}
