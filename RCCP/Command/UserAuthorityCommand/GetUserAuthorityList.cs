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
    public  class GetUserAuthorityList:CommandBase<AppSession,StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            UserPermissionListRepository repository = new UserPermissionListRepository();
            List<UserPermissionList> userPermission = repository.GetList();
            string message = JsonConvert.SerializeObject(userPermission);
            session.Send(message);
        }
    }
}
