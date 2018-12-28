using Newtonsoft.Json;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities.StaticEntity;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command
{
    public class GetSwitchList:CommandBase<AppSession,StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            DVRorNVR_SwitchListRepository swit = new DVRorNVR_SwitchListRepository();
            List<DVRorNVR_SwitchList> switchList = swit.GetList();
            //转json
            string str = JsonConvert.SerializeObject(switchList);
            session.Send(str);
        }
    }
}
