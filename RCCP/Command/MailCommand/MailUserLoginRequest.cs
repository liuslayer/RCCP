using MailServer;
using Newtonsoft.Json;
using RCCP.Repository.Entities;
using RCCP.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RCCP.Command
{
    public class MailUserLoginRequest : CommandBase<MailSession, StringRequestInfo>
    {
        private MailServerManager mailServerManager = new MailServerManager();
        public override void ExecuteCommand(MailSession session, StringRequestInfo requestInfo)
        {
            string userIP = requestInfo.Body.Split(',')[0];
            string userName = requestInfo.Body.Split(',')[1];

            CheckMailUser(userIP, userName);

            mailServerManager.AddOnlineUser(userIP);
            List<MailUser> mailUserList = mailServerManager.GetMailUsers();
            if (mailUserList == null || mailUserList.Count <= 0)
                return;
            string contentResult = JsonConvert.SerializeObject(mailUserList);
            //while (session.AppServer.GetAllSessions() == null || session.AppServer.GetAllSessions().Count() <= 0)
            //{
            //    Thread.Sleep(100);
            //}
            //向新登录的用户发送所有用户列表
            session.TrySend(MailServerCommand.MailUsersResponse.ToString() + " " + contentResult + "\r\n");
            //向其他用户发送更新通知
            MailUser mailUser = mailServerManager.GetMailUsersByIP(userIP);
            contentResult = JsonConvert.SerializeObject(mailUser);
            foreach (var item in session.AppServer.GetSessions(_ => _.SessionID != session.SessionID))
            {
                item.TrySend(MailServerCommand.UpdateMailUsers.ToString() + " " + contentResult + "\r\n");
            }
        }

        //检查邮件用户，不存在就添加，存在如果名字有变化就更改
        private void CheckMailUser(string userIP, string userName)
        {
            MailUser mailUser = mailServerManager.GetMailUsersByIP(userIP);
            if (mailUser == null)
            {
                mailUser = new MailUser();
                mailUser.UserIP = userIP;
                mailUser.UserName = userName;
                mailServerManager.AddMailUser(mailUser);
                return;
            }
            if (mailUser.UserName != userName)
            {
                mailUser.UserName = userName;
                mailServerManager.UpdateMailUser(mailUser);
                return;
            }
        }
    }
}
