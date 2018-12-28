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
    public class PostUPSStatus : CommandBase<OMSession, StringRequestInfo>
    {
        public override void ExecuteCommand(OMSession session, StringRequestInfo requestInfo)
        {
            //List<UPSStatusList> UPSStatusList = JsonConvert.DeserializeObject<List<UPSStatusList>>(requestInfo.Body);
            //UPSStatusListRepository repo = new UPSStatusListRepository();
            //Task.Run(() =>
            //{
            //    try
            //    {
            //        foreach (var UPSStatus in UPSStatusList)
            //        {
            //            repo.Insert(UPSStatus);
            //        }
            //    }
            //    catch
            //    {

            //    }

            //});
            foreach (var item in session.AppServer.GetSessions(_ => _.isOMClient && _.Connected))
            {
                string message = OMCommand.UPSStatusInfo.ToString() + " " + requestInfo.Body + "\r\n";//命令行协议
                item.TrySend(message);
            }
        }
    }
}
