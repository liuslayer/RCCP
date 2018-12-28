using DevComponents.DotNetBar.Controls;
using DevComponents.Editors.DateTimeAdv;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegratedManagement
{
    public partial class MainForm : Form
    {
        IMCommunicate IMCommunicate;
        private string localIP;
        private string serverIP;
        private int serverPort = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Config.ini");
            if (!File.Exists(filePath))
            {
                //File.Create(filePath);
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("[Settings]");
                    sw.WriteLine("LocalIP=");
                    sw.WriteLine("ServerIP=");
                    sw.WriteLine("ServerPort=");
                }
            }
            AccessIni accessIni = new AccessIni();
            localIP = accessIni.ReadIni("Settings", "LocalIP", "", filePath);
            serverIP = accessIni.ReadIni("Settings", "ServerIP", "", filePath);
            int.TryParse(accessIni.ReadIni("Settings", "ServerPort", "0", filePath), out serverPort);
            if (!ValidData(localIP, serverIP, serverPort.ToString()))
            {
                MessageBox.Show("尚未正确配置数据");
                return;
            }
            IMCommunicate = new IMCommunicate(serverIP, serverPort, localIP);

            VideoRecForm videoRecForm = new VideoRecForm();
            videoRecForm.TopLevel = false;
            videoRecForm.Parent = superTabControlPanel1;
            videoRecForm.Dock = DockStyle.Fill;
            videoRecForm.ShowInTaskbar = false;
            videoRecForm.Show();

            ImgRecForm imgRecForm = new ImgRecForm();
            imgRecForm.TopLevel = false;
            imgRecForm.Parent = superTabControlPanel2;
            imgRecForm.Dock = DockStyle.Fill;
            imgRecForm.ShowInTaskbar = false;
            imgRecForm.Show();

            LawFileInfoForm lawFileInfoForm = new LawFileInfoForm();
            lawFileInfoForm.TopLevel = false;
            lawFileInfoForm.Parent = superTabControlPanel4;
            lawFileInfoForm.Dock = DockStyle.Fill;
            lawFileInfoForm.ShowInTaskbar = false;
            lawFileInfoForm.Show();

            AlarmInfoForm alarmInfoForm = new AlarmInfoForm(IMCommunicate);
            alarmInfoForm.TopLevel = false;
            alarmInfoForm.Parent = superTabControlPanel5;
            alarmInfoForm.Dock = DockStyle.Fill;
            alarmInfoForm.ShowInTaskbar = false;
            alarmInfoForm.Show();

            StationForm stationForm = new StationForm(IMCommunicate);
            stationForm.TopLevel = false;
            stationForm.Parent = superTabControlPanel3;
            stationForm.Dock = DockStyle.Fill;
            stationForm.ShowInTaskbar = false;
            stationForm.Show();

            IMCommunicate.SocketCreateConnect();
        }

        private void buttonX_Publish_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择要发布的报告";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    byte[] buffer = new byte[1024 * 1024 * 100];
                    int bytesRead = fs.Read(buffer, 0, buffer.Length);
                    string strRead = Convert.ToBase64String(buffer, 0, bytesRead);
                    IMCommunicate.SendMsgToServer("IntergratedInfoPublish " + strRead + "\r\n");
                }
            }
        }

        private bool ValidData(string localIP,  string serverIP, string serverPort)
        {
            IPAddress address;
            int port = 0;
            if (!IPAddress.TryParse(localIP, out address))
            {
                //MessageBox.Show("本地IP地址格式不正确");
                return false;
            }
            if (!IPAddress.TryParse(serverIP, out address))
            {
                //MessageBox.Show("文电服务器IP地址格式不正确");
                return false;
            }
            if (!int.TryParse(serverPort, out port))
            {
                //MessageBox.Show("文电服务器端口号必须为数字");
                return false;
            }
            return true;
        }
    }
}
