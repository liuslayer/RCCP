using RCCP.Repository.Concrete;
using RCCP.Repository.Entities.DynamicEntity;
using RCCP.Session;
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
    public class SearchUsername:CommandBase<AppSession, StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            bool result=false;
            string username = requestInfo.Parameters[0];
            UserListRepository repository = new UserListRepository();
            List<UserList> user= repository.GetListWithCondition(new { Username=username}); 
            if(user.Count>0)
            {
                result = true;
            }
            session.Send(result.ToString());
        }
    }
}
