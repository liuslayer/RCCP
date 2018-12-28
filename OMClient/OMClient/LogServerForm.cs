using OMClient.Model;
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
    public partial class LogServerForm : Form
    {
        private LogServerCommunicate logServerCommunicate;
        public LogServerForm(LogServerCommunicate logServerCommunicate)
        {
            InitializeComponent();
            this.logServerCommunicate = logServerCommunicate;
        }

        public delegate void GetAlarmLogDel(AlarmLogAssemble alarmLogAssemble);
        public void GetAlarmLog(AlarmLogAssemble alarmLogAssemble)
        {
            if (this.InvokeRequired)
            {
                GetAlarmLogDel del = new
                 GetAlarmLogDel(GetAlarmLog);
                this.Invoke(del, alarmLogAssemble);
            }
            else
            {
                if (alarmLogAssemble == null)
                {
                    myPageControl_AlarmLog.PageIndex = 1;
                    myPageControl_AlarmLog.PageRecordCount = 1;
                    myPageControl_AlarmLog.PageRecordNumber = 20;
                    dataGridView_AlarmLog.DataSource = new List<AlarmLog>();
                    return;
                }
                myPageControl_AlarmLog.PageIndex = alarmLogAssemble.PageNumber;
                myPageControl_AlarmLog.PageRecordCount = alarmLogAssemble.LogCount;
                myPageControl_AlarmLog.PageRecordNumber = alarmLogAssemble.rowsPerPage;
                dataGridView_AlarmLog.DataSource = alarmLogAssemble.AlarmLogList.Select(_ =>
                {
                    return new
                    {
                        _.AlarmID,
                        AlarmType = Enum.Parse(typeof(AlarmType), _.AlarmType.ToString()).ToString(),
                        _.AlarmName,
                        _.AlarmLevel,
                        _.AlarmTime,
                        AlarmStatus = Enum.Parse(typeof(AlarmStatus), _.AlarmStatus.ToString()).ToString(),
                        _.DisposeTime,
                        _.Operator,
                        _.Lon,
                        _.Lat,
                        _.Alt
                    };
                }).ToList();
                //for (int i = 0; i < dataGridView_AlarmLog.Rows.Count; i++)
                //{
                //    string status = dataGridView_AlarmLog.Rows[i].Cells[5].Value.ToString();
                //    dataGridView_AlarmLog.Rows[i].Cells[5].Value = status == "1" ? "未处理" : "已处理";
                //}
            }
        }

        public delegate void GetRunLogDel(RunLogAssemble runLogAssemble);
        public void GetRunLog(RunLogAssemble runLogAssemble)
        {
            if (this.InvokeRequired)
            {
                GetRunLogDel del = new
                 GetRunLogDel(GetRunLog);
                this.Invoke(del, runLogAssemble);
            }
            else
            {
                if (runLogAssemble == null)
                {
                    myPageControl_RunLog.PageIndex = 1;
                    myPageControl_RunLog.PageRecordCount = 1;
                    myPageControl_RunLog.PageRecordNumber = 20;
                    dataGridView_RunLog.DataSource = new List<RunLog>();
                    return;
                }
                myPageControl_RunLog.PageIndex = runLogAssemble.PageNumber;
                myPageControl_RunLog.PageRecordCount = runLogAssemble.LogCount;
                myPageControl_RunLog.PageRecordNumber = runLogAssemble.rowsPerPage;
                dataGridView_RunLog.DataSource = runLogAssemble.RunLogList.Select(_ =>
                {
                    return new
                    {
                        _.ID,
                        OperationType = Enum.Parse(typeof(OperationType), _.OperationType.ToString()).ToString(),
                        _.OperationTime,
                        _.Operator,
                        _.OperationContent
                    };
                }).ToList();
            }
        }

        public delegate void GetErrLogDel(ErrLogAssemble errLogAssemble);
        public void GetErrLog(ErrLogAssemble errLogAssemble)
        {
            if (this.InvokeRequired)
            {
                GetErrLogDel del = new
                 GetErrLogDel(GetErrLog);
                this.Invoke(del, errLogAssemble);
            }
            else
            {
                if (errLogAssemble == null)
                {
                    myPageControl_ErrLog.PageIndex = 1;
                    myPageControl_ErrLog.PageRecordCount = 1;
                    myPageControl_ErrLog.PageRecordNumber = 20;
                    dataGridView_ErrLog.DataSource = new List<ErrLog>();
                    return;
                }
                myPageControl_ErrLog.PageIndex = errLogAssemble.PageNumber;
                myPageControl_ErrLog.PageRecordCount = errLogAssemble.LogCount;
                myPageControl_ErrLog.PageRecordNumber = errLogAssemble.rowsPerPage;
                dataGridView_ErrLog.DataSource = errLogAssemble.ErrLogList.Select(_ =>
                {
                    return new
                    {
                        _.ID,
                        ErrType = Enum.Parse(typeof(ErrLogType), _.ErrType.ToString()).ToString(),
                        _.ErrTime,
                        _.ErrClass,
                        _.ErrMethod,
                        _.ErrContent
                    };
                }).ToList();
            }
        }

        public void QueryLog()
        {
            string msg = LogServerCommunicate.LogServerCommand.GetAlarmLog.ToString() + " " + myPageControl_AlarmLog.PageIndex + "," + myPageControl_AlarmLog.PageRecordNumber + "\r\n";
            logServerCommunicate.SendMsgToServer(msg);
            msg = LogServerCommunicate.LogServerCommand.GetRunLog.ToString() + " " + myPageControl_RunLog.PageIndex + "," + myPageControl_RunLog.PageRecordNumber + "\r\n";
            logServerCommunicate.SendMsgToServer(msg);
            msg = LogServerCommunicate.LogServerCommand.GetErrLog.ToString() + " " + myPageControl_ErrLog.PageIndex + "," + myPageControl_ErrLog.PageRecordNumber + "\r\n";
            logServerCommunicate.SendMsgToServer(msg);
        }

        private void myPageControl_RunLog_OnPageChanged(object sender, EventArgs e)
        {
            myPageControl_RunLog.PageIndex = myPageControl_RunLog.PageIndex <= 0 ? 1 : myPageControl_RunLog.PageIndex;
            string msg = LogServerCommunicate.LogServerCommand.GetRunLog.ToString() + " " + myPageControl_RunLog.PageIndex + "," + myPageControl_RunLog.PageRecordNumber + "\r\n";
            logServerCommunicate.SendMsgToServer(msg);
        }

        private void myPageControl_AlarmLog_OnPageChanged(object sender, EventArgs e)
        {
            myPageControl_AlarmLog.PageIndex = myPageControl_AlarmLog.PageIndex <= 0 ? 1 : myPageControl_AlarmLog.PageIndex;
            string msg = LogServerCommunicate.LogServerCommand.GetAlarmLog.ToString() + " " + myPageControl_AlarmLog.PageIndex + "," + myPageControl_AlarmLog.PageRecordNumber + "\r\n";
            logServerCommunicate.SendMsgToServer(msg);
        }

        private void myPageControl_ErrLog_OnPageChanged(object sender, EventArgs e)
        {
            myPageControl_ErrLog.PageIndex = myPageControl_ErrLog.PageIndex <= 0 ? 1 : myPageControl_ErrLog.PageIndex;
            string msg = LogServerCommunicate.LogServerCommand.GetErrLog.ToString() + " " + myPageControl_ErrLog.PageIndex + "," + myPageControl_ErrLog.PageRecordNumber + "\r\n";
            logServerCommunicate.SendMsgToServer(msg);
        }

        private void buttonX_AlarmGenerateExcel_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportExcels("报警日志报表", dataGridView_AlarmLog);
        }

        private void buttonX_RunGenerateExcel_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportExcels("运行日志报表", dataGridView_RunLog);
        }

        private void buttonX_ErrGenerateExcel_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportExcels("异常日志报表", dataGridView_ErrLog);
        }

        private void dataGridView_ErrLog_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("异常类型： " + dataGridView_ErrLog.Rows[e.RowIndex].Cells[1].Value.ToString());
            stringBuilder.AppendLine("异常时间： " + dataGridView_ErrLog.Rows[e.RowIndex].Cells[2].Value.ToString());
            stringBuilder.AppendLine("异常类： " + dataGridView_ErrLog.Rows[e.RowIndex].Cells[3].Value.ToString());
            stringBuilder.AppendLine("异常方法： " + dataGridView_ErrLog.Rows[e.RowIndex].Cells[4].Value.ToString());
            stringBuilder.AppendLine("异常分析处理： " + dataGridView_ErrLog.Rows[e.RowIndex].Cells[5].Value.ToString());
            MessageBox.Show(stringBuilder.ToString(), "异常详情", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //string errType = dataGridView_ErrLog.Rows[e.RowIndex].Cells[1].Value.ToString();
            //string errTime = dataGridView_ErrLog.Rows[e.RowIndex].Cells[2].Value.ToString();
            //string errClass = dataGridView_ErrLog.Rows[e.RowIndex].Cells[3].Value.ToString();
            //string errMethod = dataGridView_ErrLog.Rows[e.RowIndex].Cells[4].Value.ToString();
            //string errContent = dataGridView_ErrLog.Rows[e.RowIndex].Cells[5].Value.ToString();
            
        }
    }
}
