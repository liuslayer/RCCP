using DeviceBaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresetForm
{
    public partial class PlanSetForm : Form
    {
        ClassPlan classplan;
        public PlanSetForm(ClassPlan temp_ClassPlan)
        {
            InitializeComponent();
            classplan = temp_ClassPlan;
            if (classplan == null)
            {
                MessageBox.Show("预案数据为空");
                return;
            }
            PlanSet ps_1 = new PlanSet(classplan,this);
            ps_1.TopLevel = false;
            panel1.Controls.Add(ps_1);
            ps_1.Show();
        }
    }
}
