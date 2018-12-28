using RCCP.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.Command
{
    public class Alertor:CommandBase<BCSession, StringRequestInfo>
    {
       
        public override void ExecuteCommand(BCSession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine("业务协同服务接收到报警设置消息");
            AlarmBusiness alarmBusiness = new AlarmBusiness();
            string str = requestInfo.Body;
            try
            {
                string[] str_split = str.Split('_');
                alarmBusiness.SetTempAlarm(str_split);
            }
            catch 
            {
            }
        }
    }
}
