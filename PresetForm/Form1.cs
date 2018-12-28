using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PresetForm
{
    public partial class Form1 : Form
    {
        private Cms_AlarmSetting cm1;
        public int flag = 0;
        public int UD = 0;
        public Point MyPoint1, MyPoint2;
        public Form1(Cms_AlarmSetting cm_1, int Width, int Height, Point p)
        {
            InitializeComponent();
            cm1 = cm_1;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Fuchsia;
            this.TransparencyKey = Color.Fuchsia;
            this.Size = new Size(Width, Height);
            this.Location = p;
        }
        public void draw(Point a)
        {
            Graphics g = this.CreateGraphics();
            Pen Mypen = new Pen(Color.Red, 2);

            if (flag == 1)
            {
                if (UD == 0)
                {
                    UD = 1;
                }
                else
                {
                    g.DrawLine(Mypen, MyPoint1, a);
                }
                MyPoint1 = a;
            }
            return;
        }
        //private FormChild_Center_rangingForm r1;
        //public Form1(FormChild_Center_rangingForm r_1, int Width, int Height, Point p)
        //{
        //    InitializeComponent();
        //    r1 = r_1;
        //    this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        //    this.BackColor = Color.Fuchsia;
        //    this.TransparencyKey = Color.Fuchsia;
        //    this.Size = new Size(Width, Height);
        //    this.Location = p;
        //}
        //public void draw(Point a, Point b)
        //{
        //    Graphics g = this.CreateGraphics();
        //    Pen Mypen = new Pen(Color.Red, 2);
        //    MyPoint1.X = a.X;
        //    MyPoint1.Y = b.Y;
        //    MyPoint2.X = b.X;
        //    MyPoint2.Y = a.Y;
        //    g.DrawLine(Mypen, a, MyPoint2);
        //    g.DrawLine(Mypen, MyPoint2, b);
        //    g.DrawLine(Mypen, a, MyPoint1);
        //    g.DrawLine(Mypen, MyPoint1, b);
        //}
    }
}
