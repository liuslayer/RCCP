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
    public class AddUser : CommandBase<AppSession, StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            UserList user = JsonConvert.DeserializeObject<UserList>(requestInfo.Body);
            UserListRepository reposity = new UserListRepository();
            try
            {
                Guid guid = reposity.Insert(user);
                session.Send("True");
            }
            catch { session.Send("False"); }
        }
    }
}
