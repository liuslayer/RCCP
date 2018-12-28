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

namespace RCCP.Command.User
{
    public class ModifyUser:CommandBase<AppSession,StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            UserListRepository repository = new UserListRepository();
            UserList userlist = JsonConvert.DeserializeObject<UserList>(requestInfo.Body);
            int i = repository.Update(userlist);
            bool b_response = false;
            if (i != -1)
            {
                b_response = true;
            }
            session.Send(b_response.ToString());
        }
    }
}
