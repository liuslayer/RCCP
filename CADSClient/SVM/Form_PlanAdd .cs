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
    public partial class Form_PlanAdd  : Form
    {
        private string EquipEditMark = "";//用于标记是否选中修改编辑对象
        private DataTable PlanResult = null;
        string Mark = "";
        public Form_PlanAdd()
        {
            InitializeComponent();
            this.bunifuCards1.Visible = false;
        }
        //窗体关闭按钮事件
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //添加按钮事件
        private void btn_Add_Click(object sender, EventArgs e)
        {
            this.bunifuCards1.Visible = true;
            Mark = "添加";
        }
        //编辑按钮事件
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            this.bunifuCards1.Visible = true;
            if (EquipEditMark=="")
            {
                MessageBox.Show("抱歉，您还未选中任何需要修改的预案信息！");
            }
            else
            {
                foreach (DataRow item in PlanResult.Rows)
                {
                    if (EquipEditMark == item["PlanID"].ToString())
                    {
                        tbx_PlanID.Text = item["PlanID"].ToString();
                        
                        tbx_PlanContent.Text = item["PlanContent"].ToString();
                       Mark = "编辑";
                    }
                }
                 
            }
        }
        //删除按钮事件
        private void btn_delete_Click(object sender, EventArgs e)
        {
            this.bunifuCards1.Visible = true;
            if (EquipEditMark == "")
            {
                MessageBox.Show("抱歉，您还未选中任何需要删除的预案信息！");
            }
            else
            {
                foreach (DataRow item in PlanResult.Rows)
                {
                    if (EquipEditMark == item["PlanID"].ToString())
                    {
                        tbx_PlanID.Text = item["PlanID"].ToString();
                        
                        tbx_PlanContent.Text = item["PlanContent"].ToString();
                        Mark = "删除";
                    }
                }
            }
        }
        //添加按钮事件
        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                OpreationDB(Mark);
            }

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (tbx_Search.Text.ToString()!="")
            {
                string KeyWord = tbx_Search.Text.ToString();
                GetEquipInfoByName(KeyWord);
                if (PlanResult!=null&&PlanResult.Rows.Count>0)
                {
                    Plan_List.DataSource = PlanResult;
                    Plan_List.DisplayMember = PlanResult.Columns["PlanID"].ToString();
                    Plan_List.ValueMember = PlanResult.Columns["PlanID"].ToString();
                }
            }
        }
        /// <summary>
        /// 通过姓名联想
        /// </summary>
        /// <param name="Condition"></param>
        private void GetEquipInfoByName(string Condition) 
        {
            deviceInfo device = new deviceInfo();
            string sql = "select * from PlanManagementInfoList where PlanID like '%" + Condition + "%'";
            DataSet ds = device.gettablebycondition(sql);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0 && dt != null)
            {
                PlanResult = dt;
            }
            else
            {
                MessageBox.Show("找不到符合条件的相关信息，请重新输入！");
            }
            
        }
        /// <summary>
        /// 通过ID联想
        /// </summary>
        /// <param name="Condition"></param>
        private void GetEquipInfoByID(string Condition) 
        {
            deviceInfo device = new deviceInfo();
            string sql = "select * from PlanManagementInfoList where PlanID like '%" + Condition + "%'";
            DataSet ds = device.gettablebycondition(sql);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0 && dt != null)
            {
                PlanResult = dt;
            }
            else
            {
                MessageBox.Show("找不到符合条件的相关信息，请重新输入！");
            }
        }
        /// <summary>
        /// ListBox选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Person_List_SelectedIndexChanged(object sender, EventArgs e)
        //{
            
        //   // EquipEditMark = Plan_List.SelectedValue.ToString();
        //}

        private void tbx_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                SearchBtn_Click(sender, e);
            }
        }

        /// <summary>
        /// 用户数据录入查询
        /// </summary>
        private bool CheckInput()
        {

            if (tbx_PlanID.Text.Trim() == "")   
            {
                MessageBox.Show("请填写预案编号！");
                return false;
            }
            if (tbx_PlanContent.Text=="")
            {
                MessageBox.Show("请填写预案内容！");
                return false;
            }
            return true;
        }
        /// <summary>
        /// ID查重
        /// </summary>
        /// <returns></returns>
        private bool CheckIDIsrepeat()
        {
            if (tbx_PlanID.Text.Trim() != "")
            {
                deviceInfo device = new deviceInfo();
                string Condition = tbx_PlanID.Text;
                string sql = "select * from PlanManagementInfoList where PlanID ='" + Condition + "'";
                try
                {
                    DataSet result = device.gettablebycondition(sql);
                    //log_tabel log = new log_tabel();
                    //log.addrow("PlanID", tbx_PlanID.Text.Trim(), log_tabel.operatetype.equal, log_tabel.mark.normal);
                    //int i = device.GetRecordCount(logs.PlanManagementInfoList, log);
                    if (result.Tables[0] != null && result.Tables[0].Rows.Count > 0)
                    {

                        MessageBox.Show("预案编号重复 请重新录入！");
                        return false;

                    }
                }
                catch (Exception e)
                {

                    throw e;
                }

            }
            return true;
        }
        /// <summary>
        /// 数据操作
        /// </summary>
        /// <param name="Mess">区别编辑还是新增还是删除</param>
        private void OpreationDB(string Mess) 
        {

            BaseDataClass.PlanManagementInfoList Planlist = new PlanManagementInfoList();
            try
            {
                Planlist.PlanContent = this.tbx_PlanContent.Text;
                Planlist.PlanID = this.tbx_PlanID.Text.Trim();
                deviceInfo PersonInfo = new deviceInfo();
                string Error = "";
                bool Result = false;
                if (Mess == "添加")
                {
                    if (CheckIDIsrepeat())
	                {
                        Result = PersonInfo.AddBaseList(Planlist, ref Error);
	                }

                }
                if (Mess == "编辑")
                {
                    Result = PersonInfo.UpdateBaselist(Planlist, ref Error);
                }
                if (Mess == "删除")
                {

                    Result = PersonInfo.DeleteOneRecord(BaseDataClassNames.PlanManagementInfoList, Planlist.PlanID, ref Error);
                }
                if (Result == true)
                {
                    MessageBox.Show("预案信息" + Mess + "成功");
                    ClearText(this.Content);
                }
                else
                {
                    MessageBox.Show("预案信息" + Mess + "失败，请稍后再试！");
                    ClearText(this.Content);
                }  
            }
            catch (Exception e)
            {
                
                throw e;
            }


        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearText(Content);
        }

        private void Plan_List_Click(object sender, EventArgs e)
        {
            
            EquipEditMark = Plan_List.SelectedValue.ToString();
            btn_Edit_Click(sender,e);
        }

        /// <summary>
        /// 清除文本
        /// </summary>
        /// <param name="ctrlTop"></param>
        private void ClearText(Control ctrlTop)
        {
            this.Plan_List.DataSource = null;
            if (ctrlTop.GetType() == typeof(TextBox))
            {
                ctrlTop.Text = "";
            }
            if (ctrlTop.GetType() == typeof(WindowsFormsControlLibrary1.BunifuCustomTextbox))
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



    }
}
