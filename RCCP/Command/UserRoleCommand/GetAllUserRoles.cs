using Newtonsoft.Json;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities.DynamicEntity;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command.UserRoleCommand
{
    public class GetAllUserRoles:CommandBase<AppSession,StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            UserRoleRepository repository = new UserRoleRepository();
            try
            {
                List<UserRole> list = repository.GetList();
                string message = JsonConvert.SerializeObject(list);
                session.Send(message);
            }
            catch
            {
                session.Send("NULL");
            }
        }
    }
}
