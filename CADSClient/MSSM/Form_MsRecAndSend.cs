using Server;
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
    public partial class Form_MsRecAndSend : Form
    {
        Form1 form_Server = null;
        public Form_MsRecAndSend()
        {
            InitializeComponent();
        }

        private void Form_MsRecAndSend_Load(object sender, EventArgs e)
        {
            form_Server = new Form1();
            form_Server.TopLevel = false;
            form_Server.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form_Server);
            form_Server.Show();
        }
    }
}
