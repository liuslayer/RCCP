using DeviceBaseData;
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class XtraForm1 : Form
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string jsonStr = "";
            string message = "Alertor/"+jsonStr+"\r\n";
            //向服务器发送控制命令
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            CommunicationClass.stream1 = CommunicationClass.tcp1.GetStream();
            CommunicationClass.stream1.Write(data, 0, data.Length);
          
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
        }
    }
}