using LogServer;
using OMServer;
using RCCP.Common;
using RCCP.Session;
using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace RCCP.Server
{
    public class OMServer : AppServer<OMSession>
    {
        OMServerManager manager;
        System.Timers.Timer timer;
        protected override void OnStarted()
        {
            base.OnStarted();
            try
            {
                manager = new OMServerManager();
                manager.LoadDeviceInfo();

                if (timer == null)
                {
                    timer = new System.Timers.Timer();
                    timer.Interval = 1000 * 30;//0.5分钟采集一次
                    timer.Elapsed += new
                         ElapsedEventHandler((sender, e) =>
                         {
                             manager.Query_CameraStatus_Info(SendCameraStatusInfo);
                             manager.Query_UPSStatus_Info(SendUPSStatusInfo);
                             manager.Query_SolarEnergyStatus_Info(SendSolarEnergyStatusInfo);
                             manager.Query_StationStatus_Info(SendStationStatusInfo);
                         });
                }
                timer.Start();
                LogServerManager.AddRunLog(OperationType.System, "服务器OMServer启动");
                Console.WriteLine("服务器OMServer启动");
            }
            catch (Exception ex)
            {
                Console.WriteLine("服务器OMServer启动失败：" + ex.Message);
            }
        }

        /// <summary>  
        /// 输出新连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        protected override void OnNewSessionConnected(OMSession session)
        {
            base.OnNewSessionConnected(session);
            //输出客户端IP地址  
            Console.WriteLine("OMServer:" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + "连接");
            session.manager = manager;
        }

        /// <summary>  
        /// 输出断开连接信息  
        /// </summary>  
        /// <param name="session"></param>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(OMSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
            Console.WriteLine("OMServer:" + session.RemoteEndPoint.Address.ToString() + ":" + session.RemoteEndPoint.Port.ToString() + "断开连接");
        }

        protected override void OnStopped()
        {
            base.OnStopped();
            LogServerManager.AddRunLog(OperationType.System, "服务器OMServer已停止");
            Console.WriteLine("服务器OMServer已停止");
            if (timer != null)
            {
                timer.Stop();
            }
        }

        private void SendDeviceInfo(string jsonContent)
        {
            string message = OMCommand.DeviceInfo.ToString() + " " + jsonContent + "\r\n";//命令行协议
            foreach (var s in this.GetAllSessions().Where(s => s.Connected && s.isOMClient))
            {
                s.TrySend(message);
            }
        }

        private void SendCameraStatusInfo(string jsonContent)
        {
            string message = OMCommand.CameraStatusInfo.ToString() + " " + jsonContent + "\r\n";//命令行协议
            foreach (var s in this.GetSessions(s => s.Connected && s.isOMClient))
            {
                s.TrySend(message);
            }
        }

        private void SendUPSStatusInfo(string jsonContent)
        {
            string message = OMCommand.UPSStatusInfo.ToString() + " " + jsonContent + "\r\n";//命令行协议
            foreach (var s in this.GetSessions(s => s.Connected && s.isOMClient))
            {
                s.TrySend(message);
            }
        }

        private void SendSolarEnergyStatusInfo(string jsonContent)
        {
            string message = OMCommand.SolarEnergyStatusInfo.ToString() + " " + jsonContent + "\r\n";//命令行协议
            foreach (var s in this.GetSessions(s => s.Connected && s.isOMClient))
            {
                s.TrySend(message);
            }
        }

        private void SendStationStatusInfo(string jsonContent)
        {
            string message = OMCommand.StationStatusInfo.ToString() + " " + jsonContent + "\r\n";//命令行协议
            foreach (var s in this.GetSessions(s => s.Connected && s.isOMClient))
            {
                s.TrySend(message);
            }
        }
    }
}
