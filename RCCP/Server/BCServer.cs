using EquipmentControlServer;
using LogServer;
using RCCP.Session;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.Server
{
    public class BCServer:AppServer<BCSession>
    {
        public static List<BCSession> sessions = new List<BCSession>();
       
        public BCServer()
        : base(new CommandLineReceiveFilterFactory(Encoding.UTF8, new BasicRequestInfoParser("/", ",")))
        {
        }
        protected override void OnStarted()
        {
            base.OnStarted();

            //报警服务初始化、设备控制服务初始化
            try
            {
                AlarmBusiness.InitEvent();
                LogServerManager.AddRunLog(OperationType.System, "服务器BCServer启动");
                ControlInterface.Init();
                Console.WriteLine("服务器BCServer启动");
            }
            catch(Exception ex)
            {
                Console.WriteLine("服务器BCServer启动失败！");
            }
        }
        /// <summary>  
          /// 输出新连接信息  
          /// </summary>  
          /// <param name="session"></param>  
        protected override void OnNewSessionConnected(BCSession session)
        {
            base.OnNewSessionConnected(session);
            sessions.Add(session);
            //输出客户端IP地址  
            Console.WriteLine("BCServer:" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + ":连接");
        }

        /// <summary>  
        /// 输出断开连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(BCSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            for(int i=0;i<sessions.Count;i++)
            {
                if (sessions[i] == session)
                    sessions.RemoveAt(i);
            }
            Console.Write("BCServer:" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + ":断开连接");
        }

        protected override void OnStopped()
        {
            base.OnStopped();
            LogServerManager.AddRunLog(OperationType.System, "服务器BCServer已停止");
            Console.WriteLine("服务器BCServer已停止");
        }

    }
}
