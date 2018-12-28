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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command
{
    public class SendMail : CommandBase<MailSession, StringRequestInfo>
    {
        public override void ExecuteCommand(MailSession session, StringRequestInfo requestInfo)
        {
            MailTable mailTable = JsonConvert.DeserializeObject<MailTable>(requestInfo.Body);
            MailServerManager mailServerManager = new MailServerManager();
            mailTable.MailFileName = mailServerManager.GetNewFileName(mailTable.MailFileName);

            if (!MailServerManager.OnlineUserDic.ContainsKey(mailTable.ReceiverIP))//不包含，返回错误
            {
                session.TrySend(MailServerCommand.SendMailResult.ToString() + " " + JsonConvert.SerializeObject(new { Result = false, Message = string.Format("找不到收件人{0}", mailTable.Receiver) }) + "\r\n");
                return;
            }

            //将邮件信息存储到服务器上
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string mailDirectory = Path.Combine(basePath, "MailCache");
            string ReceiverDirectory = Path.Combine(mailDirectory, mailTable.ReceiverIP);
            string filePath = Path.Combine(ReceiverDirectory, mailTable.MailFileName);
            DirectoryInfo di = Directory.CreateDirectory(ReceiverDirectory);
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fs.Write(mailTable.MailFile, 0, mailTable.MailFile.Length);
            }
            try
            {
                MailTableRepository mailTableRepository = new MailTableRepository();
                mailTableRepository.Insert(mailTable);
            }
            catch (Exception ex)
            {
                LogServerManager.AddErrLog(LogServerManager.ErrLogType.DBErr, ex);
            }
            //清空发送的附件缓存
            Array.Clear(mailTable.MailFile, 0, mailTable.MailFile.Length);
            //转发邮件给目标用户
            foreach (var item in session.AppServer.GetSessions(_ => _.RemoteEndPoint.Address.ToString() == mailTable.ReceiverIP))
            {
                string msg = MailServerCommand.ReceiveMail + " " + JsonConvert.SerializeObject(mailTable) + "\r\n";
                item.TrySend(msg);
            }
        }
    }
}
