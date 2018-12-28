using Newtonsoft.Json;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using RCCP.Session;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;

namespace RCCP.Command
{
    public class GetLinkagedata:CommandBase<AppSession, StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            LinkageDataRepository linkage = new LinkageDataRepository();
            LinkageData data=linkage.GetEntityById(Guid.Parse(requestInfo[1]));
            string str = JsonConvert.SerializeObject(data);
            session.Send(str.Length.ToString());
            session.Send(str);
        }
    }
}
