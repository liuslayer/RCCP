using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSSM
{
    public partial class MSSM_MainForm : Form
    {
        Form_MsSearch form1;
        Form_MsRecAndSend form2;
        Form Lform = null;
        int width;

        public MSSM_MainForm()
        {
            InitializeComponent();
            width = MessView.Width;
        }

        private void MSSM_MainForm_Load(object sender, EventArgs e)
        {
            form1 = new Form_MsSearch();
            form1.TopLevel = false;
            form1.Dock = DockStyle.Fill;
            form1.Parent = this.TagContent;
            form1.Show();
            form1.Visible = false;

            form2 = new Form_MsRecAndSend();
            form2.TopLevel = false;
            form2.Dock = DockStyle.Fill;
            form2.Parent = this.TagContent;
            form2.Show();
            form2.Visible = false;
        }


        private void Dockbtn_Click(object sender, EventArgs e)
        {
            if (MessView.Width == width)
            {
                MessView.Width = 50;

            }
            else
            {
                MessView.Width = width;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //if (Lform != null)
            //{
            //    Lform.Close();
            //}

            //form1 = new Form_MsSearch();
            //form1.TopLevel = false;
            //form1.Dock = DockStyle.Fill;
            //form1.Parent = this.TagContent;
            //form1.Show();
            //Lform = form1;
            form1.Visible = true;
            form2.Visible = false;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            //if (Lform != null)
            //{
            //    Lform.Close();
            //}

            //form2 = new Form_MsRecAndSend();
            //form2.TopLevel = false;
            //form2.Dock = DockStyle.Fill;
            //form2.Parent = this.TagContent;
            //form2.Show();
            //Lform = form2;
            form1.Visible = false;
            form2.Visible = true;
        }
    }
}
