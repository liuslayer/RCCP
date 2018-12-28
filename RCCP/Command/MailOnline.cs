using MailServer;
using Newtonsoft.Json;
using RCCP.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command
{
    public class MailOnline : CommandBase<MailSession, StringRequestInfo>
    {
        public override void ExecuteCommand(MailSession session, StringRequestInfo requestInfo)
        {
            string alias = requestInfo.Body;
            string ip = session.RemoteEndPoint.Address.ToString();
            MailServerManager mailServerManager = new MailServerManager();
            mailServerManager.AddOnlineUser(ip, alias);
            session.TrySend(MailServerCommand.OnlineUsers.ToString() + " " + JsonConvert.SerializeObject(MailServerManager.OnlineUserDic) + "\r\n");
        }
    }
}
