using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseDataClass;
using DataAssemblyClass;
using DataInterfaceModule;

namespace SVM
{
    public partial class Form_OndutyAdd : Form
    {

        string Mark = "";
        public List<string> infoList = new List<string>();//用来存储当前选中单元格的信息 
        public Form_OndutyAdd(string mark)
        {
            InitializeComponent();
            ClearText(Content);
            Mark = mark;
            Title_Lable.Text = "执勤" + mark;
            bingdingPlan();
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
            if (ctrlTop.GetType() == typeof(WindowsFormsControlLibrary1.BunifuCustomTextbox))
            {
                ctrlTop.Text = "";
            }
            if (ctrlTop.GetType()==typeof(ns1.BunifuDatepicker))
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
                MessageBox.Show("请填写执勤人编号信息！");
                return false;
            }
            if (tbx_Name.Text.Trim()=="")
            {
                MessageBox.Show("请填写执勤人姓名！");
                return false;
            }
            if (tbx_DutyRoute.Text==""||tbx_DutyRoute.Text=="执勤路线地名之间请用符号-—隔开")
            {
                MessageBox.Show("请填写执勤路线！");
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

            BaseDataClass.DutyRecordInfoList DutyLIst = new DutyRecordInfoList();

            DutyLIst.DutyPerson = tbx_Name.Text.Trim();
            DutyLIst.PersonID = tbx_ID.Text.Trim();
            DutyLIst.DutyDate = TimePicker_DutyDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            DutyLIst.DutyEvent = tbx_DutyEvent.Text;
            if (tbx_DutyEvent.Text=="")
            {
                DutyLIst.DutyEventTime = "";
                
            }
            DutyLIst.DutyEventTime = TimePicker_DutyEventTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            DutyLIst.DutyRoute = tbx_DutyRoute.Text;
            DutyLIst.Description = tbx_descrip.Text;
            DutyLIst.Mark = cbx_Plan.SelectedText;//预留字段MARK这里用来保存预案处置结果
            

            deviceInfo PersonInfo = new deviceInfo();
            string Error = "";
            bool Result = false;
            if (Mess=="添加")
            {
                Result = PersonInfo.AddBaseList(DutyLIst, ref Error);
            }
            if (Mess=="编辑")
            {
                DutyLIst.ID = Convert.ToInt32(infoList[0].ToString());
                Result = PersonInfo.UpdateBaselist(DutyLIst, ref Error);
            }
            if (Mess=="删除")
            {
                DutyLIst.ID = Convert.ToInt32(infoList[0].ToString());
                Result = PersonInfo.DeleteOneRecord(BaseDataClassNames.DutyRecordInfoList, DutyLIst.ID, ref Error);
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
            ClearText(this.Content);
        }

        private void Form_OndutyAdd_Load(object sender, EventArgs e)
        {
            if (Mark=="编辑"||Mark=="删除")
            {
                tbx_Name.Text = infoList[1].ToString();
                tbx_ID.Text = infoList[2].ToString();
                TimePicker_DutyDate.Text = infoList[3].ToString();
                tbx_DutyEvent.Text = infoList[4].ToString();
                TimePicker_DutyEventTime.Text = infoList[5].ToString();
                tbx_DutyRoute.Text = infoList[6].ToString();
                tbx_descrip.Text = infoList[7].ToString();
                cbx_Plan.Text = infoList[8].ToString();
            }
        }

        private void bingdingPlan() 
        {
            deviceInfo Plan = new deviceInfo();
            string sql = "select * from PlanManagementInfoList";
            DataSet ds=Plan.gettablebycondition(sql);
            if (ds!=null)
            {
                DataTable dt = ds.Tables[0];
                if (dt!=null&&dt.Rows.Count>0)
                {
                    //foreach (DataRow item in dt.Rows)
                    //{
                        cbx_Plan.DataSource = dt;
                        cbx_Plan.ValueMember=dt.Columns["PlanID"].ToString();
                        cbx_Plan.DisplayMember = dt.Columns["PlanContent"].ToString();
                    //}
                }
            }
            
        
        }

    }
}
