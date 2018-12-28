using Newtonsoft.Json;
using RCCP.Repository.Concrete;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command.UserRoleCommand
{
    public class DelUserRole:CommandBase<AppSession,StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            int role_id = JsonConvert.DeserializeObject<int>(requestInfo.Body);
            UserRoleRepository repository = new UserRoleRepository();
            int result=repository.Delete(role_id);
            if (result == -1)
                session.Send("False");
            else
                session.Send("True");
        }
    }
}
