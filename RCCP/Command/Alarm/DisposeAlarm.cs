using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command.Alarm
{
    public class DisposeAlarm : CommandBase<AppSession, StringRequestInfo>
    {
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            AlarmService.MediaData.AlarmCallback.DoAlarmWithParamType(requestInfo.Parameters[0], AlarmService.ParamType.Disposal,UInt32.Parse(requestInfo.Parameters[1]));
        }
    }
}
