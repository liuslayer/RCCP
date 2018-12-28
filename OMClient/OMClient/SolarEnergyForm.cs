using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMClient
{
    public partial class SolarEnergyForm : Form
    {
        public Guid ID;
        public MapForm mapForm;
        public SolarEnergyForm(MapForm mapForm, SolarEnergyStatusList solarEnergyStatusList)
        {
            InitializeComponent();
            this.mapForm = mapForm;
            solarEnergyStatusList = solarEnergyStatusList ?? new SolarEnergyStatusList();
            expandablePanel1.TitleText = string.Empty;
            labelX_Voltage.Text = solarEnergyStatusList.Voltage + "V";
            labelX_SolarCurrent.Text = solarEnergyStatusList.SolarCurrent + "A";
            labelX_Resistance.Text = solarEnergyStatusList.Resistance + "Ω";
            labelX_Temp.Text = solarEnergyStatusList.Temp + "℃";
            labelX_Humi.Text = solarEnergyStatusList.Humi + "D";
            labelX_Alarm.Text = Enum.Parse(typeof(SolarEnergyAlarmType), solarEnergyStatusList.Alarm.ToString()).ToString();
            labelX_Time.Text = solarEnergyStatusList.Time.ToString();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            mapForm.markerIDList.Remove(ID);
            this.Close();
        }
    }
}
