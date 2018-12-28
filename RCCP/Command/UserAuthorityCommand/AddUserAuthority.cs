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

namespace RCCP.Command.UserAuthority
{
    public class AddUserAuthority:CommandBase<AppSession,StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            UserPermissionList newUserPermission = JsonConvert.DeserializeObject<UserPermissionList>(requestInfo.Body);
            UserPermissionListRepository repository = new UserPermissionListRepository();
            try
            {
                repository.Insert(newUserPermission);
                session.Send(true.ToString());
            }
            catch(Exception ex)
            {
                session.Send(false.ToString());
            }

        }
    }
}
