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
    public partial class Form_GeographyEnvAdd : Form
    {
        string operType = string.Empty;
        public CADS.Model.GeographyEnvInfoList geographyEnvInfo = new CADS.Model.GeographyEnvInfoList();
        public CADS.BLL.GeographyEnvInfoList geographyEnv = new CADS.BLL.GeographyEnvInfoList();

        public Form_GeographyEnvAdd(string operType, CADS.Model.GeographyEnvInfoList geographyEnvInfo)
        {
            InitializeComponent();
            this.operType = operType;
            if (operType == "add")
            {
                Title_Label.Text = "战区地理环境添加";
            }
            else
            {
                Title_Label.Text = "战区地理环境修改";
                this.geographyEnvInfo = geographyEnvInfo;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;
            geographyEnvInfo.ZoneID = txt_ZoneID.Text;
            geographyEnvInfo.ZoneScale = txt_ZoneScale.Text;
            geographyEnvInfo.GeographyEnv = txt_GeographyEnv.Text;
            geographyEnvInfo.RoadTransport = txt_RoadTransport.Text;
            geographyEnvInfo.WaterSystem = txt_WaterSystem.Text;
            geographyEnvInfo.Description = txt_Description.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearText(Content);
        }

        private void Form_GeographyEnvAdd_Load(object sender, EventArgs e)
        {
            if (geographyEnvInfo != null)
            {
                txt_ZoneID.Text = geographyEnvInfo.ZoneID;
                txt_ZoneScale.Text = geographyEnvInfo.ZoneScale;
                txt_GeographyEnv.Text = geographyEnvInfo.GeographyEnv;
                txt_RoadTransport.Text = geographyEnvInfo.RoadTransport;
                txt_WaterSystem.Text = geographyEnvInfo.WaterSystem;
                txt_Description.Text = geographyEnvInfo.Description;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 用户数据录入查询
        /// </summary>
        private bool CheckInput()
        {

            if (txt_ZoneID.Text.Trim() == "")
            {
                MessageBox.Show("请填写战区编号！");
                return false;
            }
            if (operType == "add" && !CheckIDIsrepeat())
            {
                return false;
            }
            if (txt_ZoneScale.Text == "")
            {
                MessageBox.Show("请填写作战范围！");
                return false;
            }
            return true;
        }

        private bool CheckIDIsrepeat()
        {
            string sql = string.Empty;
            sql += "ZoneID ='" + txt_ZoneID.Text.Trim() + "'";
            try
            {
                DataTable dt = geographyEnv.GetList(sql).Tables[0];
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
    }
}
