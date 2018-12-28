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
    public partial class Form_AttendanceRecordAdd : Form
    {
        CADS.BLL.AttendanceRecordInfoList attendanceRecord = new CADS.BLL.AttendanceRecordInfoList();
        string Mark = "";
        public List<string> infoList = new List<string>();//用来存储当前选中单元格的信息 
        public Form_AttendanceRecordAdd(string mark)
        {
            InitializeComponent();
            Mark = mark;
            Title_Lable.Text = "考勤" + mark;

        }
        //窗体关闭按钮事件
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //添加按钮事件
        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (Mark=="添加")
            {
                if (CheckInput())
                {
                    OpreationDB(Mark);
                }
            }
            if (Mark=="编辑")
            {
                if (CheckInput())
                {
                    OpreationDB(Mark);
                }
            }
            if (Mark == "删除")
            {
                if (CheckInput())
                {
                    OpreationDB(Mark);
                }
            }

        }

        /// <summary>
        /// 清除文本
        /// </summary>
        /// <param name="ctrlTop"></param>
        private void ClearText(Control ctrlTop)
        {
            if (ctrlTop.GetType() == typeof(TextBox))
            {
                ctrlTop.Text = "";
            }
            if (ctrlTop.GetType()==typeof(WindowsFormsControlLibrary1.BunifuCustomTextbox))
            {
                ctrlTop.Text = "";
            }
            else
            {
                foreach (Control ctrl in ctrlTop.Controls)
                {
                    ClearText(ctrl); //循环调用  
                }
            }
        }
        /// <summary>
        /// 用户数据录入查询
        /// </summary>
        private bool CheckInput()
        {
           
            if (tbx_ID.Text.Trim()=="")   
            {
                MessageBox.Show("请填写被考勤人编号信息！");
                return false;
            }
            if (tbx_Name.Text.Trim()=="")
            {
                MessageBox.Show("请填写被考勤人姓名！");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 数据操作
        /// </summary>
        /// <param name="Mess">区别编辑还是新增还是删除</param>
        private void OpreationDB(string Mess) 
        {

            CADS.Model.AttendanceRecordInfoList AttendanceRecord = new CADS.Model.AttendanceRecordInfoList();

            AttendanceRecord.PersonName = tbx_Name.Text.Trim();
            AttendanceRecord.PersonID = tbx_ID.Text.Trim();
            AttendanceRecord.PersonLeader = tbx_Leader.Text.Trim();
            AttendanceRecord.TimeGo =  dtp_start.Value.ToString("yyyy-MM-dd HH:mm:ss");
            AttendanceRecord.IsAbsent = cbx_IsAbsent.SelectedText.ToString();
            AttendanceRecord.Reasons = tbx_Reasons.Text;
            AttendanceRecord.TimeEnd = dtp_end.Value.ToString("yyyy-MM-dd HH:mm:ss");
            AttendanceRecord.Description = tbx_descrip.Text;
            AttendanceRecord.Mark = cbx_IsAbsent.SelectedText;//预留字段MARK这里用来保存预案处置结果
            

            string Error = "";
            bool Result = false;
            if (Mess=="添加")
            {
                Result = attendanceRecord.Add(AttendanceRecord);
            }
            if (Mess=="编辑")
            {
                AttendanceRecord.ID = Convert.ToInt32(infoList[0].ToString());
                Result = attendanceRecord.Update(AttendanceRecord);
            }
            if (Mess=="删除")
            {
                AttendanceRecord.ID = Convert.ToInt32(infoList[0].ToString());
                Result = attendanceRecord.Delete(AttendanceRecord.ID);
            }
            if (Result == true)
            {
                MessageBox.Show("设备信息"+Mess+"成功");
                ClearText(this.Content);
                this.Close();
            }
            else
            {
                MessageBox.Show("设备信息"+Mess+"失败，请稍后再试！");
                ClearText(this.Content);
            }  
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_OndutyAdd_Load(object sender, EventArgs e)
        {
            if (Mark=="编辑"||Mark=="删除")
            {
                tbx_Name.Text = infoList[1].ToString();
                tbx_ID.Text = infoList[2].ToString();
                tbx_Leader.Text = infoList[3].ToString();
                dtp_start.Text = infoList[4].ToString();
                dtp_end.Text = infoList[5].ToString();
                cbx_IsAbsent.Text = infoList[6].ToString();
                tbx_Reasons.Text = infoList[7].ToString();   
                tbx_descrip.Text = infoList[8].ToString();
            }
        }


    }
}
