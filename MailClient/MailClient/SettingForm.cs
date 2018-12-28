using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient
{
    public partial class SettingForm : Form
    {
        private string localIP;
        private string userName;
        private string serverIP;
        private int serverPort = 0;
        string filePath;
        AccessIni accessIni;

        public SettingForm()
        {
            InitializeComponent();
            textBoxX_LocalIP.Enabled = false;
            textBoxX_UserName.Enabled = false;
            textBoxX_ServerIP.Enabled = false;
            textBoxX_Port.Enabled = false;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            try
            {
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Config.ini");
                accessIni = new AccessIni();
                localIP = accessIni.ReadIni("Settings", "LocalIP", "", filePath);
                userName = accessIni.ReadIni("Settings", "UserName", "", filePath);
                serverIP = accessIni.ReadIni("Settings", "ServerIP", "", filePath);
                serverPort = int.Parse(accessIni.ReadIni("Settings", "ServerPort", "0", filePath));
                textBoxX_LocalIP.Text = localIP;
                textBoxX_UserName.Text = userName;
                textBoxX_ServerIP.Text = serverIP;
                textBoxX_Port.Text = serverPort.ToString();
            }
            catch
            {
            }
        }

        private void buttonX_EditAndSave_Click(object sender, EventArgs e)
        {
            if (buttonX_EditAndSave.Text == "编辑")
            {
                buttonX_EditAndSave.Text = "保存";
                textBoxX_LocalIP.Enabled = true;
                textBoxX_UserName.Enabled = true;
                textBoxX_ServerIP.Enabled = true;
                textBoxX_Port.Enabled = true;
            }
            else
            {
                if (!ValidData(textBoxX_LocalIP.Text, textBoxX_UserName.Text, textBoxX_ServerIP.Text, textBoxX_Port.Text))
                    return;

                buttonX_EditAndSave.Text = "编辑";
                textBoxX_LocalIP.Enabled = false;
                textBoxX_UserName.Enabled = false;
                textBoxX_ServerIP.Enabled = false;
                textBoxX_Port.Enabled = false;
                if (localIP != textBoxX_LocalIP.Text)
                {
                    accessIni.WriteIni("Settings", "LocalIP", textBoxX_LocalIP.Text, filePath);
                }
                if (userName != textBoxX_UserName.Text)
                {
                    accessIni.WriteIni("Settings", "UserName", textBoxX_UserName.Text, filePath);
                }
                if (serverIP != textBoxX_ServerIP.Text)
                {
                    accessIni.WriteIni("Settings", "ServerIP", textBoxX_ServerIP.Text, filePath);
                }
                if (serverPort != int.Parse(textBoxX_Port.Text))
                {
                    accessIni.WriteIni("Settings", "ServerPort", textBoxX_Port.Text, filePath);
                }
                if (localIP != textBoxX_LocalIP.Text || userName != textBoxX_UserName.Text || serverIP != textBoxX_ServerIP.Text || serverPort != int.Parse(textBoxX_Port.Text))
                {
                    MessageBox.Show("配置已变更，将自动重启软件！");
                    System.Windows.Forms.Application.Restart(); //重启当前程序
                }
            }
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

        private bool ValidData(string localIP, string userName, string serverIP, string serverPort)
        {
            IPAddress address;
            int port = 0;
            if (!IPAddress.TryParse(localIP, out address))
            {
                MessageBox.Show("本地IP地址格式不正确");
                return false;
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("用户名不能为空或只包含空格");
                return false;
            }
            if (!IPAddress.TryParse(serverIP, out address))
            {
                MessageBox.Show("文电服务器IP地址格式不正确");
                return false;
            }
            if (!int.TryParse(serverPort, out port))
            {
                MessageBox.Show("文电服务器端口号必须为数字");
                return false;
            }
            return true;
        }
    }
}
