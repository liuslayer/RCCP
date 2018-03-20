using RCCP.Session;
using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.Server
{
    public class OMServer : AppServer<OMSession>
    {
        protected override void OnStarted()
        {
            base.OnStarted();
            Console.WriteLine("服务器OMServer启动");
        }

        /// <summary>  
        /// 输出新连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        protected override void OnNewSessionConnected(OMSession session)
        {
            base.OnNewSessionConnected(session);
            //输出客户端IP地址  
            Console.WriteLine(session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + ":连接");
        }

        /// <summary>  
        /// 输出断开连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(OMSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            Console.Write(session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + ":断开连接");
        }

        protected override void OnStopped()
        {
            base.OnStopped();
            Console.WriteLine("服务器OMServer已停止");
        }
    }
}
