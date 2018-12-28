using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project2
{
    public partial class ContentForm2 : Form
    {
        public Client.ContentForm1 myHigher;

        public ContentForm2()
        {
            InitializeComponent();
        }

        //后退
        private void back_Click(object sender, EventArgs e)
        {
            if (myHigher != null)
            {
                myHigher.Show();
                myHigher.Width -= 20;
                this.Close();
            }
        }
    }
}
