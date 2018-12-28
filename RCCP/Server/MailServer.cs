using LogServer;
using RCCP.Session;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Server
{
    public class MailServer : AppServer<MailSession>
    {
        protected override void OnStarted()
        {
            base.OnStarted();
            LogServerManager.AddRunLog(OperationType.System, "服务器MailServer启动");
            Console.WriteLine("服务器MailServer启动");
        }

        /// <summary>  
        /// 输出新连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        protected override void OnNewSessionConnected(MailSession session)
        {
            base.OnNewSessionConnected(session);
            Console.WriteLine("MailServer:" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + "连接");
        }

        /// <summary>  
        /// 输出断开连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(MailSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            Console.WriteLine("MailServer:" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + "断开连接");

        }

        protected override void OnStopped()
        {
            base.OnStopped();
            LogServerManager.AddRunLog(OperationType.System, "服务器MailServer已停止");
            Console.WriteLine("服务器MailServer已停止");
        }
    }
}
