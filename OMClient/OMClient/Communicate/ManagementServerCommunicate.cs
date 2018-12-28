using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMClient
{
    public class ManagementServerCommunicate : CommunicateBase
    {
        public delegate void UpdateMyNodeStatusEventHandler(MyNodeStatus myNodeStatus);
        public event UpdateMyNodeStatusEventHandler UpdateMyNodeStatus;//设备信息更新事件
        public ManagementServerCommunicate(string ip, int port, string localIP)
            : base(ip, port, localIP)
        {

        }

        protected override void ProcessProtocol(object arg)
        {
            string content = string.Empty;
            string protocol = arg as string;
            if (protocol.StartsWith(ManagementServerCommand.ManagementServer.ToString()))
            {
                content = protocol.Substring(ManagementServerCommand.ManagementServer.ToString().Length).Trim();
                try
                {
                    MyNodeStatus myNodeStatus = JsonConvert.DeserializeObject<MyNodeStatus>(content);
                    OMClientManager.myNodeStatus = myNodeStatus;
                    if (UpdateMyNodeStatus != null)
                        UpdateMyNodeStatus(myNodeStatus);
                }
                catch
                { }
            }
            else if (protocol.StartsWith(ManagementServerCommand.ManagementResult.ToString()))
            {
                content = protocol.Substring(ManagementServerCommand.ManagementResult.ToString().Length).Trim();
                try
                {
                    ManagementResult managementResult = JsonConvert.DeserializeObject<ManagementResult>(content);
                    if (managementResult.result == true)
                    {
                        OMClientManager.myNodeStatus = managementResult.MyNodeStatus;
                        if (UpdateMyNodeStatus != null)
                            UpdateMyNodeStatus(OMClientManager.myNodeStatus);
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 断线后向界面发送通知
        /// </summary>
        protected override void OnDisconnect()
        {
            if (UpdateMyNodeStatus != null)
                UpdateMyNodeStatus(null);
        }

        public enum ManagementServerCommand
        {
            ManagementServer = 1,
            RestartServer,
            StartServer,
            StopServer,
            ManagementResult
        }
    }
}
