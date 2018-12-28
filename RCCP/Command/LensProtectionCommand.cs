using Newtonsoft.Json;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP
{
    public class LensProtectionCommand : CommandBase<AppSession, StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            LensProtectionRepository repository = new LensProtectionRepository();
            List<LensProtection> lensProtectionList;
            LensProtection lensProtection;
            string[] str = requestInfo.Body.Split('/');
            switch (str[0])
            {
                case "Get":
                    lensProtectionList = repository.GetList();
                    string message = JsonConvert.SerializeObject(lensProtectionList);
                    session.Send(message);
                    break;
                case "Set":
                    lensProtection = JsonConvert.DeserializeObject<LensProtection>(str[1]);
                    try
                    {
                        repository.Update(lensProtection);
                        session.Send(true.ToString());
                    }
                    catch { session.Send(false.ToString()); }
                    break;
            }
        }
    }
}
