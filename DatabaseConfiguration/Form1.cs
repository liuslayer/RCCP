using DatabaseConfiguration.add_edit_dialogs;
using DatabaseConfiguration.CommandFunction;
using DatabaseConfiguration.Tables_From;
using DeviceBaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseConfiguration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bool result1 = CommunicationClass.Init();
            if(result1)
            {
                Class1 class1 = new Class1();
                //class1.Init();
                initFormData();
            }

        }
        private void initFormData()
        {
            ConfigDeviceTypeInfo tmp_ConfigDeviceTypeInfo = new ConfigDeviceTypeInfo();

            tmp_ConfigDeviceTypeInfo.FormBorderStyle = FormBorderStyle.None;
            tmp_ConfigDeviceTypeInfo.Dock = DockStyle.Fill;
            tmp_ConfigDeviceTypeInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmp_ConfigDeviceTypeInfo);

            tmp_ConfigDeviceTypeInfo.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigDeviceTypeInfo tmp_ConfigDeviceTypeInfo = new ConfigDeviceTypeInfo();

            tmp_ConfigDeviceTypeInfo.FormBorderStyle = FormBorderStyle.None;
            tmp_ConfigDeviceTypeInfo.Dock = DockStyle.Fill;
            tmp_ConfigDeviceTypeInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmp_ConfigDeviceTypeInfo);

            tmp_ConfigDeviceTypeInfo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfigStreamMediaInfo tmp_ConfigStreamMediaInfo = new ConfigStreamMediaInfo();

            tmp_ConfigStreamMediaInfo.FormBorderStyle = FormBorderStyle.None;
            tmp_ConfigStreamMediaInfo.Dock = DockStyle.Fill;
            tmp_ConfigStreamMediaInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmp_ConfigStreamMediaInfo);

            tmp_ConfigStreamMediaInfo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConfigCameraInfo tmp_ConfigCameraInfo = new ConfigCameraInfo();

            tmp_ConfigCameraInfo.FormBorderStyle = FormBorderStyle.None;
            tmp_ConfigCameraInfo.Dock = DockStyle.Fill;
            tmp_ConfigCameraInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmp_ConfigCameraInfo);

            tmp_ConfigCameraInfo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConfigProtocolTypeInfo tmp_ConfigProtocolTypeInfo = new ConfigProtocolTypeInfo();

            tmp_ConfigProtocolTypeInfo.FormBorderStyle = FormBorderStyle.None;
            tmp_ConfigProtocolTypeInfo.Dock = DockStyle.Fill;
            tmp_ConfigProtocolTypeInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmp_ConfigProtocolTypeInfo);

            tmp_ConfigProtocolTypeInfo.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConfigSerialCOMInfo tmp_ConfigSerialCOMInfo = new ConfigSerialCOMInfo();

            tmp_ConfigSerialCOMInfo.FormBorderStyle = FormBorderStyle.None;
            tmp_ConfigSerialCOMInfo.Dock = DockStyle.Fill;
            tmp_ConfigSerialCOMInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmp_ConfigSerialCOMInfo);

            tmp_ConfigSerialCOMInfo.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ConfigStationInfo tmpConfigStationInfo = new Tables_From.ConfigStationInfo();

            tmpConfigStationInfo.FormBorderStyle = FormBorderStyle.None;
            tmpConfigStationInfo.Dock = DockStyle.Fill;
            tmpConfigStationInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmpConfigStationInfo);

            tmpConfigStationInfo.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ConfigUPSInfo tmpConfigUPSInfo = new ConfigUPSInfo();

            tmpConfigUPSInfo.FormBorderStyle = FormBorderStyle.None;
            tmpConfigUPSInfo.Dock = DockStyle.Fill;
            tmpConfigUPSInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmpConfigUPSInfo);

            tmpConfigUPSInfo.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ConfigTurnTableInfo tmpConfigTurnTableInfo = new ConfigTurnTableInfo();

            tmpConfigTurnTableInfo.FormBorderStyle = FormBorderStyle.None;
            tmpConfigTurnTableInfo.Dock = DockStyle.Fill;
            tmpConfigTurnTableInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmpConfigTurnTableInfo);

            tmpConfigTurnTableInfo.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ConfigSolarEnergyInfo tmpConfigSolarEnergyInfo = new ConfigSolarEnergyInfo();
            tmpConfigSolarEnergyInfo.FormBorderStyle = FormBorderStyle.None;
            tmpConfigSolarEnergyInfo.Dock = DockStyle.Fill;
            tmpConfigSolarEnergyInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmpConfigSolarEnergyInfo);
            tmpConfigSolarEnergyInfo.Show();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            ConfigRadarInfo tmpConfigRadarInfo = new ConfigRadarInfo();
            tmpConfigRadarInfo.FormBorderStyle = FormBorderStyle.None;
            tmpConfigRadarInfo.Dock = DockStyle.Fill;
            tmpConfigRadarInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmpConfigRadarInfo);
            tmpConfigRadarInfo.Show();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            ConfigComputerInfo tmpConfigComputerInfo = new ConfigComputerInfo();
            tmpConfigComputerInfo.FormBorderStyle = FormBorderStyle.None;
            tmpConfigComputerInfo.Dock = DockStyle.Fill;
            tmpConfigComputerInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmpConfigComputerInfo);
            tmpConfigComputerInfo.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ConfigServerInfo tmpConfigServerInfo = new ConfigServerInfo();
            tmpConfigServerInfo.FormBorderStyle = FormBorderStyle.None;
            tmpConfigServerInfo.Dock = DockStyle.Fill;
            tmpConfigServerInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmpConfigServerInfo);
            tmpConfigServerInfo.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ConfigVibrationCableInfo tmpConfigVibrationCableInfo = new ConfigVibrationCableInfo();
            tmpConfigVibrationCableInfo.FormBorderStyle = FormBorderStyle.None;
            tmpConfigVibrationCableInfo.Dock = DockStyle.Fill;
            tmpConfigVibrationCableInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmpConfigVibrationCableInfo);
            tmpConfigVibrationCableInfo.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ConfigPersonnelInformationInfo tmpConfigPersonnelInformationInfo = new ConfigPersonnelInformationInfo();
            tmpConfigPersonnelInformationInfo.FormBorderStyle = FormBorderStyle.None;
            tmpConfigPersonnelInformationInfo.Dock = DockStyle.Fill;
            tmpConfigPersonnelInformationInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmpConfigPersonnelInformationInfo);
            tmpConfigPersonnelInformationInfo.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ConfigImportantLandmarkInfo tmpConfigImportantLandmarkInfo = new ConfigImportantLandmarkInfo();
            tmpConfigImportantLandmarkInfo.FormBorderStyle = FormBorderStyle.None;
            tmpConfigImportantLandmarkInfo.Dock = DockStyle.Fill;
            tmpConfigImportantLandmarkInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmpConfigImportantLandmarkInfo);
            tmpConfigImportantLandmarkInfo.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ConfigFacilityInformationInfo tmpConfigFacilityInformationInfo = new ConfigFacilityInformationInfo();
            tmpConfigFacilityInformationInfo.FormBorderStyle = FormBorderStyle.None;
            tmpConfigFacilityInformationInfo.Dock = DockStyle.Fill;
            tmpConfigFacilityInformationInfo.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(tmpConfigFacilityInformationInfo);
            tmpConfigFacilityInformationInfo.Show();
        }
    }
}
