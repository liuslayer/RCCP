using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SVM
{
    public partial class CommandForm : Form
    {
        SVMServerCommunicate SVMServerCommunicate;
        public CommandForm(SVMServerCommunicate SVMServerCommunicate)
        {
            InitializeComponent();
            this.SVMServerCommunicate = SVMServerCommunicate;
            SVMServerCommunicate.OnNewDispatchMsg += NewDispatchMsg;

        }

        private void CommandForm_Load(object sender, EventArgs e)
        {
            tbx_PatrolTime.Text = DateTime.Now.ToString();
            cbx_Station.SelectedIndex = 0;
        }

        private void btn_SendCommand_Click(object sender, EventArgs e)
        {
            CommandClass cc = new CommandClass();
            cc.StationSrc = lb_StationName.Text;
            cc.StationDes = cbx_Station.Text;
            cc.PatrolRoute = tbx_PatrolRoute.Text;
            cc.PatrolTime = tbx_PatrolTime.Text;
            cc.Description = tbx_Description.Text;
            string sendMsg = "SVMCommand" + " " + JsonConvert.SerializeObject(cc) + "\r\n";
            SVMServerCommunicate.SendMsgToServer(sendMsg);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_SendMsg_Click(object sender, EventArgs e)
        {
            tbx_Msg.Text += lb_StationName.Text + ":" + tbx_SendMsg.Text + "\r\n";
            string sendMsg = "DispatchMsg " + " " + lb_StationName.Text + "," + tbx_SendMsg.Text + "\r\n";
            SVMServerCommunicate.SendMsgToServer(sendMsg);
        }

        public delegate void NewDispatchMsgDel(string stationSrc, string msg);
        public void NewDispatchMsg(string stationSrc, string msg)
        {
            if (tbx_Msg.InvokeRequired)
            {
                NewDispatchMsgDel del = new
                 NewDispatchMsgDel(NewDispatchMsg);
                this.Invoke(del, stationSrc, msg);
            }
            else
            {
                tbx_Msg.Text += stationSrc + ":" + msg + "\r\n";
            }
        }
    }
}
