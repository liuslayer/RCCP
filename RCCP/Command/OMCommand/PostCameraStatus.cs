using Newtonsoft.Json;
using OMServer;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
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
    public class PostCameraStatus : CommandBase<OMSession, StringRequestInfo>
    {
        public override void ExecuteCommand(OMSession session, StringRequestInfo requestInfo)
        {
            //List<CameraStatusList> cameraStatusList = JsonConvert.DeserializeObject<List<CameraStatusList>>(requestInfo.Body);
            //CameraStatusListRepository repo = new CameraStatusListRepository();
            //Task.Run(() =>
            //{
            //    try
            //    {
            //        foreach (var cameraStatus in cameraStatusList)
            //        {
            //            repo.Insert(cameraStatus);
            //        }
            //    }
            //    catch
            //    {

            //    }

            //});
            foreach (var item in session.AppServer.GetSessions(_ => _.isOMClient && _.Connected))
            {
                string message = OMCommand.CameraStatusInfo.ToString() + " " + requestInfo.Body + "\r\n";//命令行协议
                item.TrySend(message);
            }
        }
    }
}
