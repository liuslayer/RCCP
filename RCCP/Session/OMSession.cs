using OMServer;
using RCCP.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RCCP.Session
{
    public class OMSession : AppSession<OMSession>
    {
        public OMServerManager manager;
        public bool isOMClient = false;//判断此连接是否是运维客户端
        /// <summary>  
        /// 新连接  
        /// </summary>  
        protected override void OnSessionStarted()
        {
            base.OnSessionStarted();

            string command = OMCommand.Connected.ToString() + " " + "\r\n";//命令行协议
            this.Send(command);

            //while (!manager.isLoaddeviceInfo) ;

            //SendDeviceInfo();
            //Thread.Sleep(2000);
            //manager.Query_CameraStatus_Info();
            //manager.Query_UPSStatus_Info();
        }

        /// <summary>  
        /// 未知的Command  
        /// </summary>  
        /// <param name="requestInfo"></param>  
        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            base.HandleUnknownRequest(requestInfo);
        }

        /// <summary>  
        /// 捕捉异常并输出  
        /// </summary>  
        /// <param name="e"></param>  
        protected override void HandleException(Exception e)
        {
            base.HandleException(e);
        }

        /// <summary>  
        /// 连接关闭  
        /// </summary>  
        /// <param name="reason"></param>  
        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
        }

        //private void SendDeviceInfo()
        //{
        //    string jsonContent = manager.SerializeDeviceInfo();
        //    string command = "DeviceInfo " + jsonContent + "\r\n";//命令行协议
        //    this.Send(command);
        //}
    }
}
