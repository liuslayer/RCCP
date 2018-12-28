using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPM
{
    public partial class EPM_MainForm : Form
    {
        Form Lform = null;

        public EPM_MainForm()
        {
            InitializeComponent();
        }

        private void btn_Onduty_Click(object sender, EventArgs e)
        {
            if (Lform != null)
            {
                Lform.Close();
            }

            Form_PlanInfo form = new Form_PlanInfo();
            form.TopLevel = false;
            form.Parent = this.TagContent;
            form.Dock = DockStyle.Fill;
            form.Show();
            Lform = form;
        }
    }
}
