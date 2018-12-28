using Newtonsoft.Json;
using RCCP.Repository.Concrete;
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

namespace IntegratedManagement
{
    public partial class AlarmInfoAddAndEditForm : Form
    {
        IMCommunicate IMCommunicate;
        public AlarmInfoAddAndEditForm(IMCommunicate IMCommunicate)
        {
            InitializeComponent();
            this.IMCommunicate = IMCommunicate;
        }

        private void buttonX_Save_Click(object sender, EventArgs e)
        {
            try
            {
                AlarmInfoRepository repo = new AlarmInfoRepository();
                AlarmInfo newAlarmInfo = new AlarmInfo();
                newAlarmInfo.AlarmID = DateTime.Now.Ticks.ToString();
                newAlarmInfo.AlarmTime = dateTimeInput_Time.Value;
                newAlarmInfo.AlarmLocation = textBoxX_AlarmLocation.Text;
                newAlarmInfo.AlarmType = (int)comboBoxEx_AlarmType.SelectedIndex;
                newAlarmInfo.TargetAttribute = (int)comboBoxEx_TargetAttribute.SelectedIndex;
                newAlarmInfo.Description = textBoxX_Description.Text;
                repo.Insert(newAlarmInfo);

                string sendMsg = "PostAlarmInfo " + JsonConvert.SerializeObject(newAlarmInfo) + "\r\n";
                IMCommunicate.SendMsgToServer(sendMsg);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonX_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
