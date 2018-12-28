using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseDataClass;
using DataInterfaceModule;
using MyTool;
using System.IO;
using Newtonsoft.Json;

namespace SVM
{
    public partial class Form_Onduty : Form
    {
        List<string> _infoList = new List<string>();//用来存储当前选中单元格的信息
        static SVMServerCommunicate SVMServerCommunicate;
        static CommandForm cf;
        public Form_Onduty()
        {
            InitializeComponent();
            dtp_Intime.Text = "";
        }

        private void myPageControl1_OnPageChanged(object sender, EventArgs e)
        {
                btn_Ok_Click(sender, e);  
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<object, EventArgs>(btn_Ok_Click), sender, e);
            }
            else
            {
                try
                {
                    deviceInfo device = new deviceInfo();
                    log_tabel condition = new log_tabel();
                    if (tbx_Name.Text.Trim() != "")
                    {
                        condition.addrow("PersonName", tbx_Name.Text.Trim(), log_tabel.operatetype.equal, log_tabel.mark.normal);
                    }
                    if (dtp_Intime.Text != "")
                    {
                        condition.addrow("DutyEventTime", dtp_Intime.Value.ToString("yyyy-MM-dd"), log_tabel.operatetype.lessAndEqual, log_tabel.mark.Date);
                        //condition.addrow("DutyEventTime", "2019-04-06", log_tabel.operatetype.lessAndEqual, log_tabel.mark.Date);
                    }

                    int Recordcount = device.GetRecordCount(logs.DutyRecordInfoList, condition);
                    if (Recordcount > 0)
                    {
                        myPageControl1.PageRecordCount = Recordcount;
                        myPageControl1.PageRecordNumber = 100;
                        DataTable dt = device.getpage(logs.DutyRecordInfoList, condition, myPageControl1.DataStart, myPageControl1.PageRecordNumber);
                        DataView.DataSource = dt;
                        bindingColName(dt);
                    }
                    else
                    {

                        MessageBox.Show("无匹配数据，请重新更改查询条件！");
                    }
                    tbx_Name.Text = "";
                    dtp_Intime.Text = "";
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        private void bindingColName(DataTable dt) 
        {
            dt.Columns[1].ColumnName = "执勤人";
            dt.Columns[2].ColumnName = "执勤人编号";
            dt.Columns[3].ColumnName = "执勤日期";
            dt.Columns[4].ColumnName = "执勤事件记录";
            dt.Columns[5].ColumnName = "事件发生时间";
            dt.Columns[6].ColumnName = "执勤路线";
            dt.Columns[7].ColumnName = "描述";
            dt.Columns[8].ColumnName = "事件预案处理";
            DataView.Columns[1].Width = 100;
            DataView.Columns[2].Width = 100;
            DataView.Columns[3].Width = 100;
            DataView.Columns[4].Width = 400;
            DataView.Columns[5].Width = 100;
            DataView.Columns[6].Width = 200;
            DataView.Columns[7].Width = 400;
            DataView.Columns[8].Width = 100;
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            ExcelHelper.DataGridViewToExcel(this.DataView);
        }



        /// <summary>
        /// 获取选中的单元格的数据信息
        /// </summary>
        private void GetDataGridViewValueSelect()
        {
            _infoList.Clear();
            if (DataView.SelectedRows.Count > 0)
            {
                int RowsLine = DataView.CurrentRow.Index;
                for (int i = 0; i < DataView.Columns.Count; i++)
                {
                    _infoList.Add(DataView.Rows[RowsLine].Cells[i].Value.ToString());
                }
            }
        }

        private void btn_Dutyadd_Click(object sender, EventArgs e)
        {
            Form_OndutyAdd form = new Form_OndutyAdd("添加");
            form.Show();
        }

        private void btn_DutyEdit_Click(object sender, EventArgs e)
        {
            Form_OndutyAdd onduty = new Form_OndutyAdd("编辑");
            if (_infoList.Count>0)
            {
                onduty.infoList = _infoList;
                onduty.Show();
            }
            else
            {
                MessageBox.Show("请选中需要编辑的对象！");
            }

        }

        private void btn_DutyDelete_Click(object sender, EventArgs e)
        {
            Form_OndutyAdd onduty = new Form_OndutyAdd("删除");
            if (_infoList.Count > 0)
            {
                onduty.infoList = _infoList;
                onduty.Show();
            }
            else
            {
                MessageBox.Show("请选中需要删除的对象！");
            }
        }

        private void btn_PlanAdd_Click(object sender, EventArgs e)
        {
            Form_PlanAdd plan = new Form_PlanAdd();
            plan.Show();
        }

        private void DataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //事件
                GetDataGridViewValueSelect();
            }
           
        }

        private void Form_Onduty_Load(object sender, EventArgs e)
        {
            string localIP;
            string stationName;
            string serverIP;
            int serverPort = 0;
            btn_Ok_Click(sender, e);

            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Config.ini");
                AccessIni accessIni = new AccessIni();
                localIP = accessIni.ReadIni("Settings", "LocalIP", "", filePath);
                stationName = accessIni.ReadIni("Settings", "StationName", "", filePath);
                serverIP = accessIni.ReadIni("Settings", "ServerIP", "", filePath);
                serverPort = 0;
                int.TryParse(accessIni.ReadIni("Settings", "ServerPort", "0", filePath), out serverPort);

                if (SVMServerCommunicate == null && cf == null)
                {
                    SVMServerCommunicate = new SVMServerCommunicate(serverIP, serverPort, localIP);
                    SVMServerCommunicate.OnNewCommand += NewCommand;
                    SVMServerCommunicate.OnNewDuty += NewDuty;

                    cf = new CommandForm(SVMServerCommunicate);
                    cf.lb_StationName.Text = stationName;
                    cf.StartPosition = FormStartPosition.CenterParent;
                    cf.Hide();

                    SVMServerCommunicate.SocketCreateConnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonX_Command_Click(object sender, EventArgs e)
        {
            cf.Show();
        }

        private void NewCommand(CommandClass commandClass)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("命令来源：  " + commandClass.StationSrc);
            sb.AppendLine("巡逻路线：  " + commandClass.PatrolRoute);
            sb.AppendLine("巡逻时间：  " + commandClass.PatrolTime);
            sb.AppendLine("描述：  " + commandClass.Description);
            MessageBox.Show(sb.ToString(), "收到上级下达的巡逻命令", MessageBoxButtons.OK);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (DataView.SelectedRows.Count < 1)
                return;
            DataGridViewRow row = DataView.SelectedRows[0];
            BaseDataClass.DutyRecordInfoList DutyList = new DutyRecordInfoList();
            DutyList.DutyPerson = row.Cells[1].Value.ToString();
            DutyList.PersonID = row.Cells[2].Value.ToString();
            DutyList.DutyDate = row.Cells[3].Value.ToString();
            DutyList.DutyEvent = row.Cells[4].Value.ToString();
            DutyList.DutyEventTime = row.Cells[5].Value.ToString();
            DutyList.DutyRoute = row.Cells[6].Value.ToString();
            DutyList.Description = row.Cells[7].Value.ToString();
            DutyList.Mark = row.Cells[8].Value.ToString();
            string sendMsg = "SVMMsg" + " " + JsonConvert.SerializeObject(DutyList) + "\r\n";
            SVMServerCommunicate.SendMsgToServer(sendMsg);
        }

        private void NewDuty(DutyRecordInfoList dutyRecordInfo)
        {
            string Error = string.Empty;
            MessageBox.Show("收到新的执勤信息");
            deviceInfo deviceInfo = new deviceInfo();
            try
            {
                bool Result = deviceInfo.AddBaseList(dutyRecordInfo, ref Error);
            }
            catch
            { 
            
            }
            btn_Ok_Click(this, new EventArgs());
        }
    }
}
