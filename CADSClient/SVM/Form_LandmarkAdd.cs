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
    public partial class Form_LandmarkAdd : Form
    {

        private string editMark = "";//用于标记是否选中修改编辑对象
        private DataTable landmarkResult = null;
        string Mark = "";
        CADS.BLL.LandmarkManageInfoList landmarkManage = new CADS.BLL.LandmarkManageInfoList();
        public Form_LandmarkAdd()
        {
            InitializeComponent();
            this.bunifuCards1.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;
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
        /// <summary>
        /// 用户数据录入查询
        /// </summary>
        private bool CheckInput()
        {

            if (tbx_LandmarkID.Text.Trim() == "")
            {
                MessageBox.Show("请填写地标编号！");
                return false;
            }
            if (Mark == "添加" && !CheckIDIsrepeat())
            {
                return false;
            }
            if (tbx_LandmarkName.Text.Trim() == "")
            {
                MessageBox.Show("请填写地标名称！");
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
            string sql = string.Empty;
            sql += "LandmarkID ='" + tbx_LandmarkID.Text.Trim() + "'";
            try
            {
                DataTable dt = landmarkManage.GetList(sql).Tables[0];
                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("地标编号重复 请重新录入！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            CADS.Model.LandmarkManageInfoList landmarkManageInfoList = new CADS.Model.LandmarkManageInfoList();
            try
            {
                landmarkManageInfoList.LandmarkID = tbx_LandmarkID.Text.Trim();
                landmarkManageInfoList.LandmarkName = tbx_LandmarkName.Text.Trim();
                landmarkManageInfoList.OrganizationName = tbx_OrganizationName.Text.Trim();
                landmarkManageInfoList.AdminDivision = tbx_AdminDivision.Text.Trim();
                landmarkManageInfoList.LandmarkType = tbx_LandmarkType.Text.Trim();
                landmarkManageInfoList.Unit = tbx_Unit.Text.Trim();
                landmarkManageInfoList.QTY = tbx_QTY.Text.Trim();
                landmarkManageInfoList.LandmarkDescription = tbx_LandmarkDescription.Text.Trim();
                bool Result = false;
                if (Mess == "添加")
                {
                    Result = landmarkManage.Add(landmarkManageInfoList);
                }
                if (Mess == "编辑")
                {
                    Result = landmarkManage.Update(landmarkManageInfoList);
                }
                if (Mess == "删除")
                {

                    Result = landmarkManage.Delete(landmarkManageInfoList.LandmarkID);
                }
                if (Result == true)
                {
                    MessageBox.Show("地标信息" + Mess + "成功");
                    ClearText(this.Content);
                }
                else
                {
                    MessageBox.Show("地标信息" + Mess + "失败，请稍后再试！");
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
            if (ctrlTop.GetType() == typeof(TextBox))
            {
                ctrlTop.Text = "";
            }
            if (ctrlTop.GetType() == typeof(WindowsFormsControlLibrary1.BunifuCustomTextbox))
            {
                ctrlTop.Text = "";
            }
            if (ctrlTop.GetType() == typeof(ns1.BunifuDatepicker))
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
                MessageBox.Show("抱歉，您还未选中任何需要修改的地标信息！");
            }
            else
            {
                foreach (DataRow item in landmarkResult.Rows)
                {
                    if (editMark == item["LandmarkID"].ToString())
                    {
                        tbx_LandmarkID.Text = item["LandmarkID"].ToString();
                        tbx_LandmarkName.Text = item["LandmarkName"].ToString();
                        tbx_OrganizationName.Text = item["OrganizationName"].ToString();
                        tbx_AdminDivision.Text = item["AdminDivision"].ToString();
                        tbx_LandmarkType.Text = item["LandmarkType"].ToString();
                        tbx_Unit.Text = item["Unit"].ToString();
                        tbx_QTY.Text = item["QTY"].ToString();
                        tbx_LandmarkDescription.Text = item["LandmarkDescription"].ToString();
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
                MessageBox.Show("抱歉，您还未选中任何需要删除的地标信息！");
            }
            else
            {
                foreach (DataRow item in landmarkResult.Rows)
                {
                    tbx_LandmarkID.Text = item["LandmarkID"].ToString();
                    tbx_LandmarkName.Text = item["LandmarkName"].ToString();
                    tbx_OrganizationName.Text = item["OrganizationName"].ToString();
                    tbx_AdminDivision.Text = item["AdminDivision"].ToString();
                    tbx_LandmarkType.Text = item["LandmarkType"].ToString();
                    tbx_Unit.Text = item["Unit"].ToString();
                    tbx_QTY.Text = item["QTY"].ToString();
                    tbx_LandmarkDescription.Text = item["LandmarkDescription"].ToString();
                    Mark = "删除";
                }
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (tbx_Search.Text.ToString() != "")
            {
                string KeyWord = tbx_Search.Text.ToString();
                GetLandmarkInfoByID(KeyWord);
                if (landmarkResult != null && landmarkResult.Rows.Count > 0)
                {
                    landmark_List.DataSource = landmarkResult;
                    landmark_List.DisplayMember = landmarkResult.Columns["LandmarkName"].ToString();
                    landmark_List.ValueMember = landmarkResult.Columns["LandmarkID"].ToString();
                }
            }
        }

        /// <summary>
        /// 通过姓名联想
        /// </summary>
        /// <param name="Condition"></param>
        private void GetLandmarkInfoByID(string Condition)
        {
            string sql = string.Empty;
            if (string.IsNullOrEmpty(Condition))
                return;
            sql += " LandmarkName like '%" + Condition + "%'";
            DataTable dt = landmarkManage.GetList(sql).Tables[0];
            if (dt.Rows.Count > 0 && dt != null)
            {
                landmarkResult = dt;
            }
            else
            {
                MessageBox.Show("找不到符合条件的相关信息，请重新输入！");
            }

        }

        private void tbx_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SearchBtn_Click(sender, e);
            }
        }

        private void landmark_List_Click(object sender, EventArgs e)
        {
            editMark = landmark_List.SelectedValue.ToString();
            btn_Edit_Click(sender, e);
        }
    }
}
