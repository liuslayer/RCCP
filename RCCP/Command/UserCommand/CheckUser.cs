using Newtonsoft.Json;
using RCCP.Repository.Entities;
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
    public class CheckUser:CommandBase<AppSession, StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            LoginUserInfomation loginUserInfomation;
            bool result= new BusinessCollaborationService.CheckUser().check(requestInfo.Parameters[0], requestInfo.Parameters[1],out loginUserInfomation);
            string message = JsonConvert.SerializeObject(loginUserInfomation);
            session.Send(result.ToString()+"_"+ message);
        }
    }
}
