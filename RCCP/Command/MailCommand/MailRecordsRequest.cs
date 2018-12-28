using MailServer;
using MailServer.Model;
using Newtonsoft.Json;
using RCCP.Repository.Entities;
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
    public class MailRecordsRequest : CommandBase<MailSession, StringRequestInfo>
    {
        private MailServerManager mailServerManager = new MailServerManager();
        public override void ExecuteCommand(MailSession session, StringRequestInfo requestInfo)
        {
            string[] contents = requestInfo.Body.Split(',');
            string userIP = contents[0];
            string mailType = contents[1];//send发送 receive接收
            int pageNumber = 0;
            int.TryParse(contents[2], out pageNumber);
            int rowsPerPage = 0;
            int.TryParse(contents[3], out rowsPerPage);
            MailTableAssemble mailTableAssemble = new MailTableAssemble();
            try
            {
                //List<MailTable> mailTableListOnePage = mailTableList.OrderByDescending(_ => _.SendTime).Skip((pageNumber - 1) * rowsPerPage).Take(rowsPerPage).ToList();               
                mailTableAssemble.PageNumber = pageNumber;
                mailTableAssemble.rowsPerPage = rowsPerPage;
                mailTableAssemble.MailCount = mailServerManager.GetMailCount(userIP, mailType);
                mailTableAssemble.PageCount = (int)Math.Ceiling((double)mailTableAssemble.MailCount / rowsPerPage);
                mailTableAssemble.MailTableList = mailServerManager.GetMailRecordsByPage(pageNumber, rowsPerPage, userIP, mailType);
                mailTableAssemble.MailType = mailType;
            }
            catch
            {
                foreach (var item in session.AppServer.GetSessions(_ => _.RemoteEndPoint.Address.ToString() == userIP))
                {
                    item.TrySend(MailServerCommand.MailRecordsResponse.ToString() + " " + JsonConvert.SerializeObject(new { Result = false, Message = "无法获取邮件记录" }) + "\r\n");
                }
            }
            //文电记录查询回复
            session.TrySend(MailServerCommand.MailRecordsResponse.ToString() + " " + JsonConvert.SerializeObject(new { Result = true, Message = string.Empty, MailTableAssemble = mailTableAssemble }) + "\r\n");
        }
    }
}
