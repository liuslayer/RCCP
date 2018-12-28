using Newtonsoft.Json;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities.DynamicEntity;
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
    public class AddUserRole:CommandBase<AppSession,StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            UserRole userRole = JsonConvert.DeserializeObject<UserRole>(requestInfo.Body);
            UserRoleRepository repository = new UserRoleRepository();
            try
            {
                repository.Insert(userRole);
                session.Send("True");
            }
            catch(Exception ex)
            {
                session.Send("False");
            }
        }
    }
}
