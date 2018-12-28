using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EPM
{
    public partial class Form_PlanAdd  : Form
    {
        private string editMark = "";//用于标记是否选中修改编辑对象
        private DataTable PlanResult = null;
        string Mark = "";
        public CADS.Model.PlanManageInfoList planInfo = null;
        string operType = string.Empty;
        CADS.BLL.PlanManageInfoList plan = null;
        public Form_PlanAdd(string operType, CADS.Model.PlanManageInfoList planInfo)
        {
            InitializeComponent();
            if (operType == "add")
            {
                Title_Label.Text = "预案添加";
            }
            else
            {
                Title_Label.Text = "预案编辑";
            }
            this.planInfo = planInfo;
            this.operType = operType;
            plan = new CADS.BLL.PlanManageInfoList();
        }

        public Form_PlanAdd(string operType)
            : this(operType, new CADS.Model.PlanManageInfoList())
        {
        }

        private void Form_PlanAdd_Load(object sender, EventArgs e)
        {
            if (planInfo != null)
            {
                this.tbx_PlanID.Text = planInfo.PlanID;
                this.tbx_PlanTitle.Text = planInfo.PlanTitle;
                this.tbx_descrip.Text = planInfo.Description;
                if (!string.IsNullOrEmpty(planInfo.Path))
                {
                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                    string planDirectory = Path.Combine(basePath, "预案模板");
                    this.tbx_planOriginPath.Text = Path.Combine(planDirectory, planInfo.Path);
                }
            }
        }

        //窗体关闭按钮事件
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //确认按钮事件
        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                try
                {
                    planInfo.PlanID = tbx_PlanID.Text;
                    planInfo.PlanTitle = tbx_PlanTitle.Text;
                    planInfo.Description = tbx_descrip.Text;
                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                    string planDirectory = Path.Combine(basePath, "预案模板");
                    if (!Directory.Exists(planDirectory))
                    {
                        Directory.CreateDirectory(planDirectory);
                    }
                    //if (!string.IsNullOrEmpty(tbx_planOriginPath.Text))
                    //{                      
                    //    string fileExt = Path.GetExtension(tbx_planOriginPath.Text);
                    //    string oldFileName = "";
                    //    string oldFileNameBak = "";
                    //    if (!string.IsNullOrEmpty(planInfo.Path))
                    //    {
                    //        oldFileName = Path.Combine(planDirectory, planInfo.Path);
                    //        oldFileNameBak = oldFileName.Split('.')[0] + ".bak";
                    //    }
                    //    planInfo.Path = planInfo.PlanID + fileExt;
                    //    string destFileName = Path.Combine(planDirectory, planInfo.Path);

                    //    if (!Directory.Exists(planDirectory))
                    //    {
                    //        Directory.CreateDirectory(planDirectory);
                    //    }
                    //    if (tbx_planOriginPath.Text != destFileName)
                    //    {
                    //        if (File.Exists(oldFileName))
                    //        {
                    //            if (File.Exists(oldFileNameBak))
                    //            {
                    //                File.Delete(oldFileNameBak);
                    //            }
                    //            File.Move(oldFileName, oldFileNameBak);
                    //        }
                    //        File.Copy(tbx_planOriginPath.Text, destFileName, true);
                    //    }
                    //}

                    string oldFileName = "";//旧文件
                    string newFileName = "";//新文件
                    if (!string.IsNullOrEmpty(tbx_planOriginPath.Text.Trim()))//如果新文件路径不为空，且与原文件路径不同，则删除原文件，复制新文件
                    {
                        if (!string.IsNullOrEmpty(planInfo.Path))
                        {
                            oldFileName = Path.Combine(planDirectory, planInfo.Path);
                        }
                        string fileExt = Path.GetExtension(tbx_planOriginPath.Text);
                        planInfo.Path = planInfo.PlanID + fileExt;
                        newFileName = Path.Combine(planDirectory, planInfo.Path);
                        if (tbx_planOriginPath.Text.Trim() != newFileName)
                        {
                            if (File.Exists(oldFileName))
                                File.Delete(oldFileName);
                            File.Copy(tbx_planOriginPath.Text, newFileName, true);
                        }
                    }
                    else if (!string.IsNullOrEmpty(planInfo.Path))//如果新文件路径为空且原文件路径不为空，则删除原文件
                    {
                        oldFileName = Path.Combine(planDirectory, planInfo.Path);
                        if (File.Exists(oldFileName))
                            File.Delete(oldFileName);
                        planInfo.Path = "";
                    }                                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                //OpreationDB(Mark);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (tbx_Search.Text.ToString() != "")
            {
                string KeyWord = tbx_Search.Text.ToString();
                GetEquipInfoByName(KeyWord);
                if (PlanResult != null && PlanResult.Rows.Count > 0)
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
            //deviceInfo device = new deviceInfo();
            //string sql = "select * from PlanManagementInfoList where PlanID like '%" + Condition + "%'";
            //DataSet ds = device.gettablebycondition(sql);
            string sql = string.Empty;
            sql += " PlanID like '" + Condition + "'";
            DataTable dt = plan.GetList(sql).Tables[0];
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
        /// 清除文本
        /// </summary>
        /// <param name="ctrlTop"></param>
        private void ClearText(Control ctrlTop)
        {
            this.Plan_List.DataSource=null;
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

            if (tbx_PlanID.Text.Trim() == "")   
            {
                MessageBox.Show("请填写预案编号！");
                return false;
            }
            if (operType == "add" && !CheckIDIsrepeat())
            {
                return false;
            }
            if (tbx_PlanTitle.Text=="")
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
            //if (tbx_PlanID.Text.Trim() != "")
            //{
            //    deviceInfo device = new deviceInfo();
            //    string Condition = tbx_PlanID.Text;
            //    string sql = "select * from PlanManagementInfoList where PlanID ='" + Condition + "'";
            //    try
            //    {
            //        DataSet result = device.gettablebycondition(sql);
            //        //log_tabel log = new log_tabel();
            //        //log.addrow("PlanID", tbx_PlanID.Text.Trim(), log_tabel.operatetype.equal, log_tabel.mark.normal);
            //        //int i = device.GetRecordCount(logs.PlanManagementInfoList, log);
            //        if (result.Tables[0] != null && result.Tables[0].Rows.Count > 0)
            //        {

            //            MessageBox.Show("预案编号重复 请重新录入！");
            //            return false;

            //        }
            //    }
            //    catch (Exception e)
            //    {

            //        throw e;
            //    }

            //}
            //return true;
            string sql = string.Empty;
            sql += "PlanID ='" + tbx_PlanID.Text.Trim() + "'";
            try
            {
                DataTable dt = plan.GetList(sql).Tables[0];
                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("预案编号重复,请重新录入！");
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearText(Content);
        }

        private void Plan_List_Click(object sender, EventArgs e)
        {
            
            editMark = Plan_List.SelectedValue.ToString();
        }

        private void btnPlanInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择导入的模板";
            ofd.Filter = "所有文件|*.*";
            ofd.Multiselect = false;
            ofd.ShowDialog();
            tbx_planOriginPath.Text = ofd.FileName;
        }





    }
}
