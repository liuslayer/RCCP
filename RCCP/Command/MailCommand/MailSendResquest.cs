using LogServer;
using MailServer;
using Newtonsoft.Json;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using RCCP.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command
{
    public class MailSendResquest : CommandBase<MailSession, StringRequestInfo>
    {
        private MailServerManager mailServerManager = new MailServerManager();
        public override void ExecuteCommand(MailSession session, StringRequestInfo requestInfo)
        {
            MailTable mailTable = JsonConvert.DeserializeObject<MailTable>(requestInfo.Body);
            MailServerManager mailServerManager = new MailServerManager();
            
            mailTable.MailFileStorageName = mailServerManager.GetMailFileStorageName(mailTable.MailFileName);

            //var DesSessions = session.AppServer.GetSessions(_ => _.RemoteEndPoint.Address.ToString() == mailTable.ReceiverIP);
            //if (DesSessions == null || DesSessions.Count() <= 0)//不包含，返回错误
            //{
            //    session.TrySend(MailServerCommand.MailSendResponse.ToString() + " " + JsonConvert.SerializeObject(new { Result = false, Message = string.Format("找不到收件人{0}", mailTable.Receiver) }) + "\r\n");
            //    return;
            //}

            try
            {
                mailServerManager.SaveMail(mailTable);
                session.TrySend(MailServerCommand.MailSendResponse.ToString() + " " + JsonConvert.SerializeObject(new { Result = true, Message = "邮件已发送" }) + "\r\n");
            }
            catch
            {
                session.TrySend(MailServerCommand.MailSendResponse.ToString() + " " + JsonConvert.SerializeObject(new { Result = false, Message = "邮件服务器出错，请联系技术人员" }) + "\r\n");
                return;
            }

            //转发邮件给目标用户
            foreach (var item in session.AppServer.GetSessions(_ => _.RemoteEndPoint.Address.ToString() == mailTable.ReceiverIP))
            {
                string msg = MailServerCommand.NewMail.ToString() + "\r\n";
                item.TrySend(msg);
            }
        }
    }
}
