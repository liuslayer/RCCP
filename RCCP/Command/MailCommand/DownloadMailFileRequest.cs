using MailServer;
using Newtonsoft.Json;
using RCCP.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RCCP.Command
{
    public class DownloadMailFileRequest : CommandBase<MailSession, StringRequestInfo>
    {
         private MailServerManager mailServerManager = new MailServerManager();
         public override void ExecuteCommand(MailSession session, StringRequestInfo requestInfo)
         {
             string[] contents = requestInfo.Body.Split(',');
             string senderIP = contents[0];
             string mailFileStorageName = contents[1];
             string fileConncectIP = contents[2];
             int fileConncectPort = int.Parse(contents[3]);
             if (!mailServerManager.IsFileExist(senderIP, mailFileStorageName))
             {
                 session.TrySend(MailServerCommand.DownloadMailFileResponse.ToString() + " " + JsonConvert.SerializeObject(new { Result = false, Message = "附件找不到或已过期" }) + "\r\n");
                 return;
             }

             try
             {
                 mailServerManager.SendMailFile(senderIP, mailFileStorageName, fileConncectIP, fileConncectPort);
             }
             catch(Exception ex)
             {
                 session.TrySend(MailServerCommand.DownloadMailFileResponse.ToString() + " " + JsonConvert.SerializeObject(new { Result = false, Message = "邮件服务器出错，请联系技术人员" }) + "\r\n");
             }
         }
    }
}
