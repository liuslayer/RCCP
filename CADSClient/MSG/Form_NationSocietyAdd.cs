using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSG
{
    public partial class Form_NationSocietyAdd : Form
    {
        string operType = string.Empty;
        public CADS.Model.NationalSocialInfoList nationalSocialInfo = new CADS.Model.NationalSocialInfoList();
        public CADS.BLL.NationalSocialInfoList nationalSocial = new CADS.BLL.NationalSocialInfoList();

        public Form_NationSocietyAdd(string operType, CADS.Model.NationalSocialInfoList nationalSocialInfo)
        {
            InitializeComponent();
            this.operType = operType;
            if (operType == "add")
            {
                Title_Label.Text = "战区民社情添加";
            }
            else
            {
                Title_Label.Text = "战区民社情修改";
                this.nationalSocialInfo = nationalSocialInfo;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;
            nationalSocialInfo.NationID = txt_NationID.Text;
            nationalSocialInfo.NationName = txt_NationName.Text;
            nationalSocialInfo.Religion = txt_Religion.Text;
            nationalSocialInfo.Habit = txt_Habit.Text;
            nationalSocialInfo.SocialGroup = txt_SocialGroup.Text;
            nationalSocialInfo.Description = txt_Description.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearText(Content);
        }

        private void Form_NationSocietyAdd_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 用户数据录入查询
        /// </summary>
        private bool CheckInput()
        {

            if (txt_NationID.Text.Trim() == "")
            {
                MessageBox.Show("请填写民族编号！");
                return false;
            }
            if (operType == "add" && !CheckIDIsrepeat())
            {
                return false;
            }
            if (txt_NationName.Text == "")
            {
                MessageBox.Show("请填写民族名称！");
                return false;
            }
            return true;
        }

        private bool CheckIDIsrepeat()
        {
            string sql = string.Empty;
            sql += "NationID ='" + txt_NationID.Text.Trim() + "'";
            try
            {
                DataTable dt = nationalSocial.GetList(sql).Tables[0];
                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("战区编号重复,请重新录入！");
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
            else
            {
                foreach (Control ctrl in ctrlTop.Controls)
                {
                    ClearText(ctrl); //循环调用  
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
