using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMClient
{
    public partial class SettingForm : Form
    {
        private string localIP;
        private string ManagementServerIP;
        private int ManagementServerPort = 0;
        private string OMServerIP;
        private int OMServerPort = 0;
        private string LogServerIP;
        private int LogServerPort = 0;
        string filePath;
        AccessIni accessIni;
        public SettingForm()
        {
            InitializeComponent();
            textBoxX_LocalIP.Enabled = false;
            textBoxX_ManagementServerIP.Enabled = false;
            textBoxX_ManagementServerPort.Enabled = false;
            textBoxX_OMServerIP.Enabled = false;
            textBoxX_OMServerPort.Enabled = false;
            textBoxX_LogServerIP.Enabled = false;
            textBoxX_LogServerPort.Enabled = false;
        }

        private void buttonX_EditAndSave_Click(object sender, EventArgs e)
        {
            if (buttonX_EditAndSave.Text == "编辑")
            {
                buttonX_EditAndSave.Text = "保存";
                textBoxX_LocalIP.Enabled = true;
                textBoxX_ManagementServerIP.Enabled = true;
                textBoxX_ManagementServerPort.Enabled = true;
                textBoxX_OMServerIP.Enabled = true;
                textBoxX_OMServerPort.Enabled = true;
                textBoxX_LogServerIP.Enabled = true;
                textBoxX_LogServerPort.Enabled = true;
            }
            else
            {
                if (!ValidData(textBoxX_LocalIP.Text, textBoxX_ManagementServerIP.Text, textBoxX_ManagementServerPort.Text, textBoxX_OMServerIP.Text,
                    textBoxX_OMServerPort.Text, textBoxX_LogServerIP.Text, textBoxX_LogServerPort.Text))
                    return;

                buttonX_EditAndSave.Text = "编辑";
                textBoxX_LocalIP.Enabled = false;
                textBoxX_ManagementServerIP.Enabled = false;
                textBoxX_ManagementServerPort.Enabled = false;
                textBoxX_OMServerIP.Enabled = false;
                textBoxX_OMServerPort.Enabled = false;
                textBoxX_LogServerIP.Enabled = false;
                textBoxX_LogServerPort.Enabled = false;

                bool isChange = false;
                if (localIP != textBoxX_LocalIP.Text)
                {
                    isChange = true;
                    accessIni.WriteIni("Settings", "LocalIP", textBoxX_LocalIP.Text, filePath);
                }

                if (ManagementServerIP != textBoxX_ManagementServerIP.Text)
                {
                    isChange = true;
                    accessIni.WriteIni("Settings", "服务管理器IP", textBoxX_ManagementServerIP.Text, filePath);
                }
                if (ManagementServerPort != int.Parse(textBoxX_ManagementServerPort.Text))
                {
                    isChange = true;
                    accessIni.WriteIni("Settings", "服务管理器端口号", textBoxX_ManagementServerPort.Text, filePath);
                }

                if (OMServerIP != textBoxX_OMServerIP.Text)
                {
                    isChange = true;
                    accessIni.WriteIni("Settings", "采集服务IP", textBoxX_OMServerIP.Text, filePath);
                }
                if (OMServerPort != int.Parse(textBoxX_OMServerPort.Text))
                {
                    isChange = true;
                    accessIni.WriteIni("Settings", "采集服务端口号", textBoxX_OMServerPort.Text, filePath);
                }

                if (LogServerIP != textBoxX_LogServerIP.Text)
                {
                    isChange = true;
                    accessIni.WriteIni("Settings", "日志服务IP", textBoxX_LogServerIP.Text, filePath);
                }
                if (LogServerPort != int.Parse(textBoxX_LogServerPort.Text))
                {
                    isChange = true;
                    accessIni.WriteIni("Settings", "日志服务端口号", textBoxX_LogServerPort.Text, filePath);
                }

                if (isChange)
                {
                    MessageBox.Show("配置已变更，将自动重启软件！");
                    System.Windows.Forms.Application.Restart(); //重启当前程序
                }
            }
        }

        private bool ValidData(string localIP, string ManagementServerIP, string ManagementServerPort, string OMServerIP,string OMServerPort, string LogServerIP, string LogServerPort)
        {
            IPAddress address;
            int port = 0;

            if (!IPAddress.TryParse(localIP, out address))
            {
                MessageBox.Show("本地IP地址格式不正确");
                return false;
            }
            if (!IPAddress.TryParse(ManagementServerIP, out address))
            {
                MessageBox.Show("服务管理器IP地址格式不正确");
                return false;
            }
            if (!int.TryParse(ManagementServerPort, out port))
            {
                MessageBox.Show("服务管理器端口号必须为数字");
                return false;
            }
            if (!IPAddress.TryParse(OMServerIP, out address))
            {
                MessageBox.Show("采集服务IP地址格式不正确");
                return false;
            }
            if (!int.TryParse(OMServerPort, out port))
            {
                MessageBox.Show("采集服务端口号必须为数字");
                return false;
            }
            if (!IPAddress.TryParse(LogServerIP, out address))
            {
                MessageBox.Show("日志服务IP地址格式不正确");
                return false;
            }
            if (!int.TryParse(LogServerPort, out port))
            {
                MessageBox.Show("日志服务端口号必须为数字");
                return false;
            }
            return true;
        }

        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            if (buttonX_EditAndSave.Text == "保存")
            {
                DialogResult result = MessageBox.Show("是否放弃编辑并退出？", null, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }
            this.Close();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            try
            {
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Config.ini");
                accessIni = new AccessIni();
                localIP = accessIni.ReadIni("Settings", "LocalIP", "", filePath);
                ManagementServerIP = accessIni.ReadIni("Settings", "服务管理器IP", "", filePath);
                ManagementServerPort = int.Parse(accessIni.ReadIni("Settings", "服务管理器端口号", "0", filePath));
                OMServerIP = accessIni.ReadIni("Settings", "采集服务IP", "", filePath);
                OMServerPort = int.Parse(accessIni.ReadIni("Settings", "采集服务端口号", "0", filePath));
                LogServerIP = accessIni.ReadIni("Settings", "日志服务IP", "", filePath);
                LogServerPort = int.Parse(accessIni.ReadIni("Settings", "日志服务端口号", "0", filePath));

                textBoxX_LocalIP.Text = localIP;
                textBoxX_ManagementServerIP.Text = ManagementServerIP;
                textBoxX_ManagementServerPort.Text = ManagementServerPort.ToString();
                textBoxX_OMServerIP.Text = OMServerIP;
                textBoxX_OMServerPort.Text = OMServerPort.ToString();
                textBoxX_LogServerIP.Text = LogServerIP;
                textBoxX_LogServerPort.Text = LogServerPort.ToString();
                ;
            }
            catch
            {
            }
        }
    }
}
