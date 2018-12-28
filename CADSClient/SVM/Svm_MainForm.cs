using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ns1;
namespace SVM
{
    public partial class Svm_MainForm : Form
    {
        Form Lform = null;
        int width;
        public Svm_MainForm()
        {
            InitializeComponent();
            width = DutyView.Width;

        }

        //主页标题图标按钮收缩功能
        private void Dockbtn_Click(object sender, EventArgs e)
        {
            if (DutyView.Width==width)
            {
                DutyView.Width = 65;

            }
            else
            {
                DutyView.Width = width;
            }
        }

        //退出按钮事件
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        private void btn_Onduty_Click(object sender, EventArgs e)
        {
            if (Lform!=null)
            {
                Lform.Close();
            }
                
                Form_Onduty form = new Form_Onduty();
                form.TopLevel = false;
                form.Parent = this.TagContent;
                this.TagContent.Controls.Add(form);
                this.TagContent.Controls.SetChildIndex(form, 0);
                form.Dock = DockStyle.Fill;
                form.Show();
                Lform = form;
        }

        private void btn_Equip_Click(object sender, EventArgs e)
        {

        }

        private void btn_CheckWork_Click(object sender, EventArgs e)
        {
            if (Lform != null)
            {
                Lform.Close();
            }
            Form_AttendanceRecord form = new Form_AttendanceRecord();
            form.TopLevel = false;
            form.Parent = this.TagContent;
            this.TagContent.Controls.Add(form);
            this.TagContent.Controls.SetChildIndex(form, 0);
            form.Dock = DockStyle.Fill;
            form.Show();
            Lform = form;
        }

        private void btn_Person_Click(object sender, EventArgs e)
        {

        }

        private void btn_FileLaw_Click(object sender, EventArgs e)
        {
            if (Lform != null)
            {
                Lform.Close();
            }
            Form_LawFile form = new Form_LawFile();
            form.TopLevel = false;
            form.Parent = this.TagContent;
            this.TagContent.Controls.Add(form);
            this.TagContent.Controls.SetChildIndex(form, 0);
            form.Dock = DockStyle.Fill;
            form.Show();
            Lform = form;
        }

        private void Svm_MainForm_Load(object sender, EventArgs e)
        {
            Form_Onduty form = new Form_Onduty();
            form.TopLevel = false;
            form.Parent = this.TagContent;
            this.TagContent.Controls.Add(form);
            this.TagContent.Controls.SetChildIndex(form, 0);
            form.Dock = DockStyle.Fill;
            form.Show();
            Lform = form;
        }

        private void btn_Foundation_Click(object sender, EventArgs e)
        {
            if (Lform != null)
            {
                Lform.Close();
            }
            Form_Foundation form = new Form_Foundation();
            form.TopLevel = false;
            form.Parent = this.TagContent;
            form.Dock = DockStyle.Fill;
            form.Show();
            Lform = form;
        }


    }
}
