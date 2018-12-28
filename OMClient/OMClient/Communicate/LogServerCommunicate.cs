using Newtonsoft.Json;
using OMClient.Model;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMClient
{
    public class LogServerCommunicate : CommunicateBase
    {
        public delegate void QueryLogEventHandler();
        public event QueryLogEventHandler QueryLog;//报警日志查询事件

        public delegate void GetAlarmLogEventHandler(AlarmLogAssemble alarmLogAssemble);
        public event GetAlarmLogEventHandler GetAlarmLog;//报警日志显示事件

        public delegate void GetRunLogEventHandler(RunLogAssemble runLogAssemble);
        public event GetRunLogEventHandler GetRunLog;//报警日志显示事件

        public delegate void GetErrLogEventHandler(ErrLogAssemble errLogAssemble);
        public event GetErrLogEventHandler GetErrLog;//报警日志显示事件

        public LogServerCommunicate(string ip, int port, string localIP)
            : base(ip, port, localIP)
        {

        }

        protected override void ProcessProtocol(object arg)
        {
            string content = string.Empty;
            string protocol = arg as string;
            if (protocol.StartsWith(LogServerCommand.GetAlarmLogResult.ToString()))
            {
                content = protocol.Substring(LogServerCommand.GetAlarmLogResult.ToString().Length).Trim();
                try
                {
                    AlarmLogAssemble alarmLogAssemble = JsonConvert.DeserializeObject<AlarmLogAssemble>(content);
                    if (GetAlarmLog != null)
                        GetAlarmLog(alarmLogAssemble);
                }
                catch
                { }
            }
            else if (protocol.StartsWith(LogServerCommand.GetRunLogResult.ToString()))
            {
                content = protocol.Substring(LogServerCommand.GetRunLogResult.ToString().Length).Trim();
                try
                {
                    RunLogAssemble runLogAssemble = JsonConvert.DeserializeObject<RunLogAssemble>(content);
                    if (GetRunLog != null)
                        GetRunLog(runLogAssemble);
                }
                catch
                { }
            }
            else if (protocol.StartsWith(LogServerCommand.GetErrLogResult.ToString()))
            {
                content = protocol.Substring(LogServerCommand.GetErrLogResult.ToString().Length).Trim();
                try
                {
                    ErrLogAssemble errLogAssemble = JsonConvert.DeserializeObject<ErrLogAssemble>(content);
                    if (GetErrLog != null)
                        GetErrLog(errLogAssemble);
                }
                catch
                { }
            }
        }

        protected override void OnConnected()
        {
            base.OnConnected();
            if (QueryLog != null)
                QueryLog();
        }

        /// <summary>
        /// 断线后向界面发送通知
        /// </summary>
        protected override void OnDisconnect()
        {
            if (GetAlarmLog != null)
                GetAlarmLog(null);
            if (GetRunLog != null)
                GetRunLog(null);
            if (GetErrLog != null)
                GetErrLog(null);
        }

        public enum LogServerCommand
        {
            GetAlarmLog = 1,
            GetRunLog,
            GetErrLog,
            GetAlarmLogResult,
            GetRunLogResult,
            GetErrLogResult
        }
    }
}
