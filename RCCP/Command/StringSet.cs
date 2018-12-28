using RCCP.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;

namespace RCCP.Command
{
    public class StringSet : CommandBase<BCSession, StringRequestInfo>
    {

        public override void ExecuteCommand(BCSession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine("业务协同服务接收到字符叠加设置消息");
            string str = requestInfo.Body;
            try
            {
                string[] str_split = str.Split('_');
                AccessOperation.AlarmSetSDK.StringSet(str_split[0], int.Parse(str_split[1]), str_split[2],"256","192");
            }
            catch
            {
            }
        }
    }
}
