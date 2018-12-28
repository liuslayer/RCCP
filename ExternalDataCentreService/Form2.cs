using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExternalDataCentreService
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void ShowMessage(string message)
        {
            Action action = delegate () { listBox1.Items.Add(DateTime.Now.ToString("HH:mm:ss") + ":"+message); };
            Invoke(action);
        }
    }
}
