using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SVM
{
    public partial class Form_Foundation : Form
    {
        public Form_Foundation()
        {
            InitializeComponent();
        }

        private void Form_Foundation_Load(object sender, EventArgs e)
        {
            Form_PersonManage form1 = new Form_PersonManage();
            form1.TopLevel = false;
            form1.Parent = this.tabPage1;
            form1.Dock = DockStyle.Fill;
            form1.Show();

            Form_EquipManage form2 = new Form_EquipManage();
            form2.TopLevel = false;
            form2.Parent = this.tabPage2;
            form2.Dock = DockStyle.Fill;
            form2.Show();

            Form_Landmark form3 = new Form_Landmark();
            form3.TopLevel = false;
            form3.Parent = this.tabPage3;
            form3.Dock = DockStyle.Fill;
            form3.Show();
        }
    }
}
