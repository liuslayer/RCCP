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
    public partial class MainForm : Form
    {
        ManagementServerCommunicate managementServerCommunicate;//服务器管理器通信
        OMServerCommunicate omServerCommunicate;//运维服务通信
        LogServerCommunicate logServerCommunicate;//日志服务通信

        MapForm mapForm = null;
        StatisticsForm statisticsForm = null;
        ManagementServerForm managementServerForm = null;
        LogServerForm logServerForm = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonX_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void HiddenForm()
        {
            mapForm.Hide();
            statisticsForm.Hide();
            managementServerForm.Hide();
            logServerForm.Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadConfiguration();
            this.WindowState = FormWindowState.Maximized;
            managementServerCommunicate = new ManagementServerCommunicate(serverManagerIP, serverManagerPort, localIP);
            omServerCommunicate = new OMServerCommunicate(OMServerIP, OMServerPort, localIP);
            logServerCommunicate = new LogServerCommunicate(logServerIP, logServerPort, localIP);

            mapForm = new MapForm();
            mapForm.Owner = this;
            mapForm.ShowInTaskbar = false;
            mapForm.TopLevel = false;
            this.panelEx_Base.Controls.Add(mapForm);
            omServerCommunicate.UpdateDeviceInfo += mapForm.UpdateDeviceInfo;
            omServerCommunicate.UpdateCameraStatus += mapForm.UpdateCameraStatus;
            omServerCommunicate.UpdateUPSStatus += mapForm.UpdateUPSStatus;
            omServerCommunicate.UpdateSolarEnergyStatus += mapForm.UpdateSolarEnergyStatus;
            omServerCommunicate.UpdatestationStatus += mapForm.UpdateStationStatus;
            mapForm.Show();

            statisticsForm = new StatisticsForm();
            statisticsForm.Owner = this;
            statisticsForm.ShowInTaskbar = false;
            statisticsForm.TopLevel = false;
            this.panelEx_Base.Controls.Add(statisticsForm);
            omServerCommunicate.UpdateDeviceInfo += statisticsForm.UpdateDeviceInfo;
            omServerCommunicate.UpdateCameraStatus += statisticsForm.UpdateCameraStatus;
            omServerCommunicate.UpdateUPSStatus += statisticsForm.UpdateUPSStatus;
            omServerCommunicate.UpdateSolarEnergyStatus += statisticsForm.UpdateSolarEnergyStatus;
            omServerCommunicate.SocketCreateConnect();

            managementServerForm = new ManagementServerForm(managementServerCommunicate);
            managementServerForm.Owner = this;
            managementServerForm.ShowInTaskbar = false;
            managementServerForm.TopLevel = false;
            this.panelEx_Base.Controls.Add(managementServerForm);
            managementServerCommunicate.UpdateMyNodeStatus += managementServerForm.UpdateMyNodeStatus;
            managementServerCommunicate.SocketCreateConnect();
            
            logServerForm = new LogServerForm(logServerCommunicate);
            logServerForm.Owner = this;
            logServerForm.ShowInTaskbar = false;
            logServerForm.TopLevel = false;
            this.panelEx_Base.Controls.Add(logServerForm);
            logServerCommunicate.GetAlarmLog += logServerForm.GetAlarmLog;
            logServerCommunicate.GetRunLog += logServerForm.GetRunLog;
            logServerCommunicate.GetErrLog += logServerForm.GetErrLog;
            logServerCommunicate.QueryLog += logServerForm.QueryLog;
            logServerCommunicate.SocketCreateConnect();
        }

        string localIP = string.Empty;
        string serverManagerIP = string.Empty;
        int serverManagerPort = 0;
        string OMServerIP = string.Empty;
        int OMServerPort = 0;
        string logServerIP = string.Empty;
        int logServerPort = 0;
        private void LoadConfiguration()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Config.ini");
                if (!File.Exists(filePath))
                {
                    //File.Create(filePath);
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        sw.WriteLine("[Settings]");
                        sw.WriteLine("LocalIP=");
                        sw.WriteLine("服务管理器IP=");
                        sw.WriteLine("服务管理器端口号=");
                        sw.WriteLine("采集服务IP=");
                        sw.WriteLine("采集服务端口号=");
                        sw.WriteLine("日志服务IP=");
                        sw.WriteLine("日志服务端口号=");
                        sw.WriteLine("PStationLevel=");
                        sw.WriteLine("StationLevel=");
                        sw.WriteLine("MapSkipLevel=");
                    }
                }
                AccessIni accessIni = new AccessIni();
                localIP = accessIni.ReadIni("Settings", "LocalIP", "", filePath);
                serverManagerIP = accessIni.ReadIni("Settings", "服务管理器IP", "", filePath);
                int.TryParse(accessIni.ReadIni("Settings", "服务管理器端口号", "0", filePath), out serverManagerPort);
                OMServerIP = accessIni.ReadIni("Settings", "采集服务IP", "", filePath);
                int.TryParse(accessIni.ReadIni("Settings", "采集服务端口号", "0", filePath), out OMServerPort);
                logServerIP = accessIni.ReadIni("Settings", "日志服务IP", "", filePath);
                int.TryParse(accessIni.ReadIni("Settings", "日志服务端口号", "0", filePath), out logServerPort);
                if (!ValidData(localIP, serverManagerIP, serverManagerPort.ToString(), OMServerIP, OMServerPort.ToString(), logServerIP, logServerPort.ToString()))
                {
                    MessageBox.Show("运维管理尚未正确配置数据，请前往“设置”菜单进行设置！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Config.ini");
                AccessIni accessIni = new AccessIni();
                localIP = accessIni.ReadIni("Settings", "LocalIP", "", filePath);
                serverManagerIP = accessIni.ReadIni("Settings", "服务管理器IP", "", filePath);
                int.TryParse(accessIni.ReadIni("Settings", "服务管理器端口号", "0", filePath), out serverManagerPort);
                OMServerIP = accessIni.ReadIni("Settings", "采集服务IP", "", filePath);
                int.TryParse(accessIni.ReadIni("Settings", "采集服务端口号", "0", filePath), out OMServerPort);
                logServerIP = accessIni.ReadIni("Settings", "日志服务IP", "", filePath);
                int.TryParse(accessIni.ReadIni("Settings", "日志服务端口号", "0", filePath), out logServerPort);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidData(string localIP, string ManagementServerIP, string ManagementServerPort, string OMServerIP, string OMServerPort, string LogServerIP, string LogServerPort)
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
            this.Close();
        }
        private void buttonX_Map_Click(object sender, EventArgs e)
        {
            HiddenForm();
            mapForm.Show();
        }

        private void buttonX_Statistics_Click(object sender, EventArgs e)
        {
            HiddenForm();
            statisticsForm.Show();
        }

        private void buttonX_ManagementServer_Click(object sender, EventArgs e)
        {
            HiddenForm();
            managementServerForm.Show();
        }

        private void buttonX_Log_Click(object sender, EventArgs e)
        {
            HiddenForm();
            logServerForm.Show();
        }

        private void buttonX_Setting_Click(object sender, EventArgs e)
        {
            SettingForm sf = new SettingForm();
            sf.ShowDialog();
        }
    }
}
