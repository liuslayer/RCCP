
using LogServer;
using RCCP.Session;
using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Server
{
    class CommandDispatchServer : AppServer<CommandDispatchSession>
    {
        private IDispatch EDCDispatch;
        protected override void OnStarted()
        {
            base.OnStarted();
            EDCDispatch = this.Bootstrap.GetServerByName("EDCServer") as IDispatch;
            LogServerManager.AddRunLog(OperationType.System, "服务器CommandDispatchServer启动");
            Console.WriteLine("服务器CommandDispatchServer启动");
        }

        /// <summary>  
        /// 输出新连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        protected override void OnNewSessionConnected(CommandDispatchSession session)
        {
            base.OnNewSessionConnected(session);
            Console.WriteLine("CommandDispatchServer:" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + "连接");
        }

        /// <summary>  
        /// 输出断开连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(CommandDispatchSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            Console.WriteLine("CommandDispatchServer:" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + "断开连接");

        }

        protected override void OnStopped()
        {
            base.OnStopped();
            LogServerManager.AddRunLog(OperationType.System, "服务器CommandDispatchServer已停止");
            Console.WriteLine("服务器CommandDispatchServer已停止");
        }

        public void DispatchToEDCServer(string sessionKey, string message)
        {
            EDCDispatch.DispatchMessage(sessionKey, message);
        }
    }
}
