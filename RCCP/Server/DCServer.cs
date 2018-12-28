using LogServer;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.Server
{
    /// <summary>
    /// 数据中心服务
    /// </summary>
    public class DCServer:AppServer<AppSession>
    {
        public DCServer()
        : base(new CommandLineReceiveFilterFactory(Encoding.UTF8, new BasicRequestInfoParser("/", ",")))
        {
        }
        protected override void OnStarted()
        {
            base.OnStarted();
            LogServerManager.AddRunLog(OperationType.System, "服务器DCServer启动");
            Console.WriteLine("服务器DCServer启动");
        }
        /// <summary>  
        /// 输出新连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        protected override void OnNewSessionConnected(AppSession session)
        {
            base.OnNewSessionConnected(session);
            //输出客户端IP地址  
            Console.WriteLine("DCServer:" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + ":连接");
        }

        /// <summary>  
        /// 输出断开连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(AppSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            Console.Write("DCServer:" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + ":断开连接");
        }

        protected override void OnStopped()
        {
            base.OnStopped();
            LogServerManager.AddRunLog(OperationType.System, "服务器DCServer已停止");
            Console.WriteLine("服务器DCServer已停止");
        }
    }
}
