using AlarmService;
using RCCP.Server;
using System.Threading;

namespace RCCP
{
    /// <summary>
    /// 报警器
    /// </summary>
    public class AlarmBusiness
    {
      
        /// <summary>
        /// 初始化所有事件
        /// </summary>
        public static void InitEvent()
        {
            // 绑定临时报警事件
            MediaData.AlarmCallback.tempAlarmEvent += AlarmCallback_tempAlarmEvent;
            //BF_Video_SDK.XW_DVR_Init();
            //MediaData.DataInit();
            //AlarmService.MediaData.AlarmCallback.stateCallBack();
            //Thread th = new Thread(AlarmTest);
            //th.IsBackground = true;
            //th.Start();
            MediaData.AlarmCallback.AlarmMessageCallback();
            //自动布撤防
            MediaData.AlarmCallback.AlarmSetAll();
            //自动录像启动
            MediaData.AlarmCallback.RecSetAll();
        }
        private static void AlarmTest()
        {
            int a = 0;
            Thread.Sleep(10000);
            while (a<10)
            {
                a++;
                Thread.Sleep(1000);
                AlarmService.MediaData.AlarmCallback.alarmCallBack("192.168.20.10,1", 18, 0);
            }
            Thread.Sleep(30000);
            int b = 0;
            while (b < 10)
            {
                b++;
                Thread.Sleep(1000);
                AlarmService.MediaData.AlarmCallback.alarmCallBack("192.168.20.10,1", 18, 0);
            }
        }
        private static void AlarmCallback_tempAlarmEvent(string jsonStr)
        {
            //遍历所有用户session连接，发送报警信息
            foreach (var session in BCServer.sessions)
            {
                session.Send(jsonStr + "\r\n");
            }
        }

        /// <summary>
        /// 设置临时报警
        /// </summary>
        /// <param name="str"></param>
        public void SetTempAlarm(string[] str)
        {
            //调用AlarmService
            SetAlarm.SetTempAlarm(str);
        }
    }
}
