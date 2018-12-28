using RCCP.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;

namespace RCCP.Command
{
    public class TimeSet : CommandBase<BCSession, StringRequestInfo>
    {

        public override void ExecuteCommand(BCSession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine("业务协同服务接收到时间设置消息");
            string str = requestInfo.Body;
            try
            {
                string[] str_split = str.Split('_');
                AlarmService.TimeSet.TimingSet.TimeSetBySuperior(str_split[0], str_split[1], str_split[2], str_split[3], str_split[4], str_split[5], str_split[6]);
            }
            catch
            {
            }
        }
    }
}
