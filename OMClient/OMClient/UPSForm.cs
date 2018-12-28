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
    public partial class UPSForm : Form
    {
        public Guid ID;
        public MapForm mapForm;
        public UPSForm(MapForm mapForm, UPSStatusList UPSStatus)
        {
            InitializeComponent();
            this.mapForm = mapForm;
            UPSStatus = UPSStatus ?? new UPSStatusList();
            expandablePanel1.TitleText = string.Empty;
            labelX_InVoltage.Text = UPSStatus.InVoltage + "V";
            labelX_LVoltage.Text = UPSStatus.LVoltage + "V";
            labelX_OutVoltage.Text = UPSStatus.OutVoltage + "V";
            labelX_OutputLoad.Text = UPSStatus.OutputLoad + "%";
            labelX_Freq.Text = UPSStatus.Freq + "Hz";
            labelX_CellVoltage.Text = UPSStatus.CellVoltage + "V";
            labelX_Temperature.Text = UPSStatus.Temperature + "℃";
            labelX_Alarm.Text = OMCommon.UPSAlarmConvert(UPSStatus.Alarm);
            labelX_Time.Text = UPSStatus.Time.ToString();
            labelX_Alarm.Visible = true;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            mapForm.markerIDList.Remove(ID);
            this.Close();
        }
    }
}
