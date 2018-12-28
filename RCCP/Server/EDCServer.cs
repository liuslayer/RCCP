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
    public class EDCServer : AppServer<EDCSession>, IDispatch
    {
        protected override void OnStarted()
        {
            base.OnStarted();
            LogServerManager.AddRunLog(OperationType.System, "服务器EDCServer启动");
            Console.WriteLine("服务器EDCServer启动");
        }

        /// <summary>  
        /// 输出新连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        protected override void OnNewSessionConnected(EDCSession session)
        {
            base.OnNewSessionConnected(session);
            Console.WriteLine("EDCServer:" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + "连接");
        }

        /// <summary>  
        /// 输出断开连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(EDCSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            Console.WriteLine("EDCServer:" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + "断开连接");
        }

        protected override void OnStopped()
        {
            base.OnStopped();
            Console.WriteLine("服务器EDCServer已停止");
        }

        public void DispatchMessage(string sessionKey, string message)
        {
            foreach (var item in this.GetSessions(_ => _.ClientIdentity == sessionKey))
            {
                item.TrySend(message);
            }
        }
    }
}
