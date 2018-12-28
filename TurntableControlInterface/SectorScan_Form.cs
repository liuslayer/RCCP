using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurntableControlInterface
{
    public partial class SectorScan_Form : Form
    {
        Guid? tmpVideoDeviceGuid;
        int HSpeed, VSpeed;
        public SectorScan_Form(Guid? VideoDeviceGuid, int i_Hspeed, int i_Vspeed)
        {
            InitializeComponent();
            tmpVideoDeviceGuid = VideoDeviceGuid;
            HSpeed = i_Hspeed;
            VSpeed = i_Vspeed;
        }

        private void button_SectorScanOpen_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("请输入角度！");
            }
            else
            {
                double d1 = Convert.ToDouble(textBox1.Text);
                double d2 = Convert.ToDouble(textBox3.Text);
                double d3 = Convert.ToDouble(textBox2.Text);
                double d4 = Convert.ToDouble(textBox4.Text);
                int i_HorizontalSt = Convert.ToInt32(d1);//水平开始
                int i_HorizontalEnd = Convert.ToInt32(d2);//水平结束
                int i_VerticalSt = Convert.ToInt32(d3);//俯仰开始
                int i_VerticalEnd = Convert.ToInt32(d4);//俯仰结束
                InterfaceControl.SectorScanOpen(tmpVideoDeviceGuid, i_HorizontalSt, i_HorizontalEnd, HSpeed, i_VerticalSt, i_VerticalEnd, VSpeed);
                this.Close();
            }
        }

        private void button_SectorScan_Off_Click(object sender, EventArgs e)
        {
            if (tmpVideoDeviceGuid != null)
            {
                InterfaceControl.SectorScanOff(tmpVideoDeviceGuid);
                this.Close();
            }
        }
    }
}
