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

namespace RCCP.Command.MailCommand
{
    public class UpdateMailStatusRequest : CommandBase<MailSession, StringRequestInfo>
    {
        private MailServerManager mailServerManager = new MailServerManager();
        public override void ExecuteCommand(MailSession session, StringRequestInfo requestInfo)
        {
            string[] contents = requestInfo.Body.Split(',');
            string userIP = contents[0];
            Guid MailID = Guid.Parse(contents[1]);
            try
            {
                mailServerManager.UpdateMailStatus(MailID);
                foreach (var item in session.AppServer.GetSessions(_ => _.RemoteEndPoint.Address.ToString() == userIP))
                {
                    item.TrySend(MailServerCommand.UpdateMailStatusResponse.ToString() + " " + JsonConvert.SerializeObject(new { Result = true, Message = string.Empty }) + "\r\n");
                }
            }
            catch
            {

            }
        }
    }
}
