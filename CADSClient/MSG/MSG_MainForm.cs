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
    public partial class MSG_MainForm : Form
    {
        Form Lform = null;
        int width;

        public MSG_MainForm()
        {
            InitializeComponent();
            width = MSGView.Width;
            lb_Descript.Visible = false;
        }

        private void Dockbtn_Click(object sender, EventArgs e)
        {
            if (MSGView.Width == width)
            {
                MSGView.Width = 50;

            }
            else
            {
                MSGView.Width = width;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            lb_Descript.Visible = false;
            if (Lform != null)
            {
                Lform.Close();
            }

            Form_GeographyEnv form = new Form_GeographyEnv();
            form.TopLevel = false;
            form.Parent = this.TagContent;
            form.Dock = DockStyle.Fill;
            form.Show();
            Lform = form;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            lb_Descript.Visible = false;
            if (Lform != null)
            {
                Lform.Close();
            }

            Form_NationSociety form = new Form_NationSociety();
            form.TopLevel = false;
            form.Parent = this.TagContent;
            form.Dock = DockStyle.Fill;
            form.Show();
            Lform = form;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            lb_Descript.Visible = false;
            if (Lform != null)
            {
                Lform.Close();
            }

            Form_EconomicDev form = new Form_EconomicDev();
            form.TopLevel = false;
            form.Parent = this.TagContent;
            form.Dock = DockStyle.Fill;
            form.Show();
            Lform = form;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if (Lform != null)
            {
                Lform.Close();
            }
            lb_Descript.Visible = true;
            lb_Descript.Text = "战区内可以征招人员、物资、装备、能源、公路、铁路";
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            if (Lform != null)
            {
                Lform.Close();
            }
            lb_Descript.Visible = true;
            lb_Descript.Text = "战区内历史上发生过的战争、历史经验教训";
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            if (Lform != null)
            {
                Lform.Close();
            }
            lb_Descript.Visible = true;
            lb_Descript.Text = "当面所辖管段范围、兵种兵力构成、武器装备配备，指挥官文化素养、个性特征、指挥策略";
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            if (Lform != null)
            {
                Lform.Close();
            }
            lb_Descript.Visible = true;
            lb_Descript.Text = "自身所辖管段范围、兵种兵力构成、武器装备配备，指挥官文化素养、个性特征、指挥策略";
        }
    }
}
