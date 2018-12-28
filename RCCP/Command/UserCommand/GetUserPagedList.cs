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

namespace RCCP.Command
{
    public class GetUserPagedList: CommandBase<AppSession, StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            int pageNumber;
            int.TryParse(requestInfo.Parameters[0], out pageNumber);
            int rowsPerPage;
            int.TryParse(requestInfo.Parameters[1], out rowsPerPage);
            UserListRepository repository = new UserListRepository();
            List<UserList> userList=repository.GetListPaged(pageNumber, rowsPerPage, null, null);
            string message = JsonConvert.SerializeObject(userList);
            session.Send(message);
        }
    }
}
