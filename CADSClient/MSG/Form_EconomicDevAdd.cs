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
    public partial class Form_EconomicDevAdd : Form
    {
        string operType = string.Empty;
        public CADS.Model.EconomicDevInfoList EconomicDevInfo = new CADS.Model.EconomicDevInfoList();
        public CADS.BLL.EconomicDevInfoList EconomicDev = new CADS.BLL.EconomicDevInfoList();

        public Form_EconomicDevAdd(string operType, CADS.Model.EconomicDevInfoList EconomicDevInfo)
        {
            InitializeComponent();
            this.operType = operType;
            if (operType == "add")
            {
                Title_Label.Text = "战区经济发展状况添加";
            }
            else
            {
                Title_Label.Text = "战区经济发展状况修改";
                this.EconomicDevInfo = EconomicDevInfo;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            EconomicDevInfo.Agriculture = txt_Agriculture.Text;
            EconomicDevInfo.Industry = txt_Industry.Text;
            EconomicDevInfo.Service = txt_Service.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearText(Content);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void Form_EconomicDevAdd_Load(object sender, EventArgs e)
        {

            if (EconomicDevInfo != null)
            {
                txt_Agriculture.Text = EconomicDevInfo.Agriculture;
                txt_Industry.Text = EconomicDevInfo.Industry;
                txt_Service.Text = EconomicDevInfo.Service;
            }
        }
    }
}
