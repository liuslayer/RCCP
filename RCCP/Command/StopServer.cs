using Newtonsoft.Json;
using RCCP.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command
{
    public class StopServer : CommandBase<ManagementSession, StringRequestInfo>
    {
        public override void ExecuteCommand(ManagementSession session, StringRequestInfo requestInfo)
        {
            var instanceName = requestInfo.Body;
            var server = session.AppServer.GetServerByName(instanceName);
            if (server == null)
            {
                session.TrySend("ManagementResult " + JsonConvert.SerializeObject(new { Result = false, Message = string.Format("服务器\"{0}\"不存在", server) }) + "\r\n");
                return;
            }
            if (server.State != SuperSocket.SocketBase.ServerState.Running)
            {
                session.TrySend("ManagementResult " + JsonConvert.SerializeObject(new { Result = false, Message = string.Format("服务器\"{0}\"已停止", server) }) + "\r\n");
                return;
            }
            server.Stop();

            var nodeStatus = session.AppServer.MyNodeStatus;
            var instance = nodeStatus.MyInstancesStatus.FirstOrDefault(i => i.Name.Equals(instanceName));
            instance.IsRunning = "False";
            instance.StartedTime = string.Empty;
            session.TrySend("ManagementResult " + JsonConvert.SerializeObject(new { Result = true, MyNodeStatus = nodeStatus }) + "\r\n");

        }
    }
}
