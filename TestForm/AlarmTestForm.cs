using AlarmService;
using System;
using System.Windows.Forms;
using static AlarmService.MediaData;

namespace TestForm
{
    public partial class AlarmTestForm : Form
    {
        public AlarmCallback temp_a = new AlarmCallback();
        long AlarmFingerprintID = 0;
        public AlarmTestForm()
        {
            InitializeComponent();
            //bool a=XW_SDK.Init();
            MediaData.DataInit();
            //保存SDK日志 To save the SDK log
            //CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
            //temp_a.stateCallBack();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //temp_a.alarmCallBack("192.168.10.111,1", 18, 0,ref AlarmFingerprintID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //temp_a.DoAlarmWithParamType(AlarmFingerprintID,ParamType.Disposal,0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //temp_a.AlarmMessageCallback();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //AlarmCallback.SetAlarm();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
