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
    public class PostSolarEnergyStatus : CommandBase<OMSession, StringRequestInfo>
    {
        public override void ExecuteCommand(OMSession session, StringRequestInfo requestInfo)
        {
            //List<SolarEnergyStatusList> solarEnergyStatusList = JsonConvert.DeserializeObject<List<SolarEnergyStatusList>>(requestInfo.Body);
            //SolarEnergyStatusListRepository repo = new SolarEnergyStatusListRepository();
            //Task.Run(() =>
            //{
            //    try
            //    {
            //        foreach (var solarEnergyStatus in solarEnergyStatusList)
            //        {
            //            repo.Insert(solarEnergyStatus);
            //        }
            //    }
            //    catch
            //    {

            //    }

            //});
            foreach (var item in session.AppServer.GetSessions(_ => _.isOMClient && _.Connected))
            {
                string message = OMCommand.SolarEnergyStatusInfo.ToString() + " " + requestInfo.Body + "\r\n";//命令行协议
                item.TrySend(message);
            }
        }
    }
}
