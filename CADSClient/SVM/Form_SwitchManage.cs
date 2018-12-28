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
    public partial class Form_SwitchManage : Form
    {
        private string editMark = "";//用于标记是否选中修改编辑对象
        private DataTable switchResult = null;
        string Mark = "";
        CADS.BLL.SwitchManageInfoList switchManage = new CADS.BLL.SwitchManageInfoList();
        public Form_SwitchManage()
        {
            InitializeComponent();
            this.bunifuCards1.Visible = false;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                OpreationDB(Mark);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            this.bunifuCards1.Visible = true;
            Mark = "添加";
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            this.bunifuCards1.Visible = true;
            if (editMark == "")
            {
                MessageBox.Show("抱歉，您还未选中任何需要修改的交接班信息！");
            }
            else
            {
                foreach (DataRow item in switchResult.Rows)
                {
                    if (editMark == item["NextName"].ToString())
                    {
                        tbx_PreLeader.Text = item["PreLeader"].ToString();
                        tbx_PreName.Text = item["PreName"].ToString();
                        tbx_NextLeader.Text = item["NextLeader"].ToString();
                        tbx_NextName.Text = item["NextName"].ToString();
                        dtp_SwtichTime.Text = item["SwtichTime"].ToString();
                        tbx_SwitchContent.Text = item["SwitchContent"].ToString();
                        Mark = "编辑";
                    }
                }

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            this.bunifuCards1.Visible = true;
            if (editMark == "")
            {
                MessageBox.Show("抱歉，您还未选中任何需要删除的交接班信息！");
            }
            else
            {
                foreach (DataRow item in switchResult.Rows)
                {
                    tbx_PreLeader.Text = item["PreLeader"].ToString();
                    tbx_PreName.Text = item["PreName"].ToString();
                    tbx_NextLeader.Text = item["NextLeader"].ToString();
                    tbx_NextName.Text = item["NextName"].ToString();
                    dtp_SwtichTime.Text = item["SwtichTime"].ToString();
                    tbx_SwitchContent.Text = item["SwitchContent"].ToString();
                    Mark = "删除";
                }
            }
        }

        /// <summary>
        /// 用户数据录入查询
        /// </summary>
        private bool CheckInput()
        {

            if (tbx_PreName.Text.Trim() == "")
            {
                MessageBox.Show("请填写交班人员！");
                return false;
            }
            if (tbx_NextName.Text.Trim() == "")
            {
                MessageBox.Show("请填写接班人员！");
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
            CADS.Model.SwitchManageInfoList switchManageInfoList = new CADS.Model.SwitchManageInfoList();
            try
            {
                switchManageInfoList.PreLeader = this.tbx_PreLeader.Text.Trim();
                switchManageInfoList.PreName = this.tbx_NextName.Text.Trim();
                switchManageInfoList.NextLeader = this.tbx_NextLeader.Text.Trim();
                switchManageInfoList.NextName = this.tbx_NextName.Text.Trim();
                switchManageInfoList.SwtichTime = this.dtp_SwtichTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                switchManageInfoList.SwitchContent = this.tbx_SwitchContent.Text.Trim();
                if (!string.IsNullOrEmpty(editMark))
                {
                    switchManageInfoList.ID = int.Parse(editMark);
                }
                bool Result = false;
                if (Mess == "添加")
                {
                    Result = switchManage.Add(switchManageInfoList);
                }
                if (Mess == "编辑")
                {
                    Result = switchManage.Update(switchManageInfoList);
                }
                if (Mess == "删除")
                {

                    Result = switchManage.Delete(switchManageInfoList.ID);
                }
                if (Result == true)
                {
                    MessageBox.Show("交接班信息" + Mess + "成功");
                    ClearText(this.Content);
                }
                else
                {
                    MessageBox.Show("交接班信息" + Mess + "失败，请稍后再试！");
                    ClearText(this.Content);
                }  
            }
            catch (Exception e)
            {
                
                throw e;
            }


        }

        /// <summary>
        /// 清除文本
        /// </summary>
        /// <param name="ctrlTop"></param>
        private void ClearText(Control ctrlTop)
        {
            this.switch_List.DataSource = null;
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

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (tbx_Search.Text.ToString() != "")
            {
                string KeyWord = tbx_Search.Text.ToString();
                GetEquipInfoByName(KeyWord);
                if (switchResult != null && switchResult.Rows.Count > 0)
                {
                    switch_List.DataSource = switchResult;
                    switch_List.DisplayMember = switchResult.Columns["NextName"].ToString();
                    switch_List.ValueMember = switchResult.Columns["NextName"].ToString();
                }
            }
        }

        /// <summary>
        /// 通过姓名联想
        /// </summary>
        /// <param name="Condition"></param>
        private void GetEquipInfoByName(string Condition)
        {
            string sql = string.Empty;
            if (string.IsNullOrEmpty(Condition))
                return;
            sql += " NextName like '%" + Condition + "%'";
            DataTable dt = switchManage.GetList(sql).Tables[0];
            if (dt.Rows.Count > 0 && dt != null)
            {
                switchResult = dt;
            }
            else
            {
                MessageBox.Show("找不到符合条件的相关信息，请重新输入！");
            }

        }

        private void switch_List_Click(object sender, EventArgs e)
        {
            editMark = switch_List.SelectedValue.ToString();
            btn_Edit_Click(sender, e);
        }

        private void tbx_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SearchBtn_Click(sender, e);
            }
        }
    }
}
