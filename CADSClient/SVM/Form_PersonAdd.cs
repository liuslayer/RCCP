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
    public partial class Form_PersonAdd : Form
    {
        private string PersonEditMark = "";//用于标记是否选中修改编辑对象
        private DataTable PersonResult = null;
        string Mark = "";
        public Form_PersonAdd()
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
            
            if (PersonEditMark=="")
            {
                MessageBox.Show("抱歉，您还未选中任何需要修改的个人信息！");
            }
            else
            {
                foreach (DataRow item in PersonResult.Rows)
                {
                    if (PersonEditMark==item["PersonID"].ToString())
                    {
                       tbx_Name.Text=item["PersonName"].ToString();
                       tbx_ID.Text= item["PersonID"].ToString(); 
                       tbx_Nation.Text=item["PersonNation"].ToString(); 
                       tbx_post.Text=item["Post"].ToString();
                       tbx_Unit.Text=item["Unit"].ToString(); 
                       tbx_contactinfo.Text=item["ContactInfo"].ToString(); 
                       TimePicker_DateOfBirth.Value= Convert.ToDateTime(item["DateOfBirth"]);
                       tbx_DegreeOfEducation.Text=item["DegreeOfEducation"].ToString();
                       TimePicker_Intime.Value=Convert.ToDateTime(item["EnlistmentTime"]);
                       TimePicker_Outtime.Value=Convert.ToDateTime(item["RetiredTime"]);
                       tbx_place.Text=item["NativePlace"].ToString();
                       tbx_descrip.Text = item["Description"].ToString();
                       Mark = "编辑";
                    }
                }
                this.bunifuCards1.Visible = true;
            }
        }
        //删除按钮事件
        private void btn_delete_Click(object sender, EventArgs e)
        { 
            if (PersonEditMark == "")
            {
                MessageBox.Show("抱歉，您还未选中任何需要删除的个人信息！");
            }
            else
            {
                foreach (DataRow item in PersonResult.Rows)
                {
                    if (PersonEditMark == item["PersonID"].ToString())
                    {
                        tbx_Name.Text = item["PersonName"].ToString();
                        tbx_ID.Text = item["PersonID"].ToString();
                        tbx_Nation.Text = item["PersonNation"].ToString();
                        tbx_post.Text = item["Post"].ToString();
                        tbx_Unit.Text = item["Unit"].ToString();
                        tbx_contactinfo.Text = item["ContactInfo"].ToString();
                        TimePicker_DateOfBirth.Value = Convert.ToDateTime(item["DateOfBirth"]);
                        tbx_DegreeOfEducation.Text = item["DegreeOfEducation"].ToString();
                        TimePicker_Intime.Value = Convert.ToDateTime(item["EnlistmentTime"]);
                        TimePicker_Outtime.Value = Convert.ToDateTime(item["RetiredTime"]);
                        tbx_place.Text = item["NativePlace"].ToString();
                        tbx_descrip.Text = item["Description"].ToString();
                        Mark = "删除";
                    }
                }
                this.bunifuCards1.Visible = true;
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
                GetPersonInfoByName(KeyWord);
                if (PersonResult!=null&&PersonResult.Rows.Count>0)
                {
                    Person_List.DataSource = PersonResult;
                    Person_List.DisplayMember=PersonResult.Columns["PersonName"].ToString();
                    Person_List.ValueMember=PersonResult.Columns["PersonID"].ToString();
                }
            }
        }
        /// <summary>
        /// 通过姓名联想
        /// </summary>
        /// <param name="Condition"></param>
        private void GetPersonInfoByName(string Condition) 
        {
            deviceInfo device = new deviceInfo();
            string sql = "select * from PersonnelInfoList where PersonName like '%"+Condition+"%'";
            DataSet ds= device.gettablebycondition(sql);
            DataTable dt  = ds.Tables[0];
            if (dt.Rows.Count > 0 && dt != null)
            {
                PersonResult = dt;
            }
            else 
            {
                MessageBox.Show("找不到符合条件的人员相关信息，请重新输入！");
            }
            
        }
        /// <summary>
        /// 通过ID联想
        /// </summary>
        /// <param name="Condition"></param>
        private void GetPersonInfoByID(string Condition) 
        {
            deviceInfo device = new deviceInfo();
            string sql = "select * from PersonnelInfoList where PersonID like '%" + Condition + "%'";
            DataSet ds = device.gettablebycondition(sql);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0 && dt != null)
            {
                PersonResult = dt;
            }
            else
            {
                MessageBox.Show("找不到符合条件的人员相关信息，请重新输入！");
            }
        }
        /// <summary>
        /// ListBox选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Person_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            PersonEditMark = Person_List.SelectedValue.ToString();
        }

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
            if (ctrlTop.GetType() == typeof(TextBox))
            {
                ctrlTop.Text = "";
            }
            if (ctrlTop.GetType()==typeof(WindowsFormsControlLibrary1.BunifuCustomTextbox))
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
            if (tbx_contactinfo.Text.Trim()=="")
            {
                MessageBox.Show("请填写联系方式！");
                return false;
            }
            if (tbx_DegreeOfEducation.Text.Trim()=="")
            {
                MessageBox.Show("请填写教育程度！");
                return false;
            }
            if (tbx_ID.Text.Trim()=="")   
            {
                MessageBox.Show("请填写用户编号信息！");
                return false;
            }

            if (tbx_Name.Text.Trim()=="")
            {
                MessageBox.Show("请填写用户姓名！");
                return false;
            }
            if (tbx_Nation.Text.Trim()=="")
            {
                MessageBox.Show("请填写民族！");
                return false;
            }
            if (tbx_place.Text.Trim()=="")
            {
                MessageBox.Show("请填写籍贯！");
                return false;
            }
            if (tbx_post.Text.Trim()=="")
            {
                MessageBox.Show("请填写职位名称！");
            }
            if (tbx_Unit.Text.Trim()=="")
            {
                MessageBox.Show("请填写单位名称！");
            }
            return true;
        }
        /// <summary>
        /// 数据操作
        /// </summary>
        /// <param name="Mess">区别编辑还是新增还是删除</param>
        private void OpreationDB(string Mess) 
        {

            BaseDataClass.PersonnelInfoList PersonList = new PersonnelInfoList();
            PersonList.PersonName = this.tbx_Name.Text.ToString();
            PersonList.PersonID = this.tbx_ID.Text.ToString();
            PersonList.PersonNation = this.tbx_Nation.Text.ToString();
            PersonList.Post = this.tbx_post.Text.ToString();
            PersonList.Unit = this.tbx_Unit.Text.ToString();
            PersonList.ContactInfo = this.tbx_contactinfo.Text.ToString();
            PersonList.DateOfBirth = this.TimePicker_DateOfBirth.Value.ToString("yyyy-MM-dd");
            PersonList.DegreeOfEducation = this.tbx_DegreeOfEducation.Text.ToString();
            PersonList.EnlistmentTime = this.TimePicker_Intime.Value.ToString("yyyy-MM-dd");
            PersonList.RetiredTime = this.TimePicker_Outtime.Value.ToString("yyyy-MM-dd");
            PersonList.NativePlace = this.tbx_place.Text.ToString();
            PersonList.Description = this.tbx_descrip.Text.ToString();

            deviceInfo PersonInfo = new deviceInfo();
            string Error = "";
            bool Result = false;
            if (Mess=="添加")
            {
                if (tbx_ID.Text.Trim() != "")
                {
                    deviceInfo device = new deviceInfo();
                    //string sql = "select * from PersonnelListInfo where PersonID =‘" + tbx_ID.Text.Trim()+"’";
                    //DataSet result= device.gettablebycondition(sql);
                    log_tabel log = new log_tabel();
                    log.addrow("PersonID", tbx_ID.Text.Trim(), log_tabel.operatetype.equal, log_tabel.mark.normal);
                    int i = device.GetRecordCount(logs.PersonnelInfoList, log);
                    if (i > 0)
                    {
                        MessageBox.Show("用户编号重复 请重新录入！");
                    }
                    else
                    {
                        Result = PersonInfo.AddBaseList(PersonList, ref Error);
                    }
                }

            }
            if (Mess=="编辑")
            {
                Result = PersonInfo.UpdateBaselist(PersonList, ref Error);
            }
            if (Mess=="删除")
            {
                Result = PersonInfo.DeleteOneRecord(BaseDataClassNames.PersonnelInfoList, PersonList.PersonID, ref Error);
            }
            if (Result == true)
            {
                MessageBox.Show("人员信息"+Mess+"成功");
                ClearText(this.Content);
            }
            else
            {
                MessageBox.Show("人员信息"+Mess+"失败，请稍后再试！");
                ClearText(this.Content);
            }  
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearText(Content);
        }



    }
}
