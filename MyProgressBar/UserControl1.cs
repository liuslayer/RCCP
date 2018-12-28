using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyProgressBar
{
    public partial class UserControl1: UserControl
    {
        float secondWidth;
        //录像时间块
        List<Panel> panels = new List<Panel>();
        int i = 0;//录像索引号
        int lRet = -1;//返回值
        public delegate void SendMessageDelegate(int index);
        public event SendMessageDelegate SendMessage;
        public UserControl1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int ScaleCount = 12;
            int singleWidth = Width / ScaleCount;
            Width = singleWidth * ScaleCount;
            secondWidth =(float) Width / (24 * 60 * 60);
            Pen pen = new Pen(Color.Gray, 1);
            for (int i = 1; i < 12;i++)
            {
                Point point1 = new Point(singleWidth * i, Height/2);
                Point point2 = new Point(singleWidth * i, Height);
                Graphics g = CreateGraphics();
                string text = (i*2) + ":00";
                if (i*2<10)
                {
                    text = "0" + (i*2) + ":00";
                }
                int x = point1.X - 18;
                int y = point1.Y - 9;
                g.DrawString(text, new Font("宋体", 9, FontStyle.Regular), Brushes.White, x,y);
                g.DrawLine(pen, point1, point2);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                panel1.ClientRectangle,
                                Color.Green,
                                1,
                                ButtonBorderStyle.Solid,
                                Color.Green,
                                1,
                                ButtonBorderStyle.Solid,
                                Color.Green,
                                1,
                                ButtonBorderStyle.Solid,
                                Color.Green,
                                1,
                                ButtonBorderStyle.Solid);
        }
       
        //添加时间块
        public void AddTimeBlock(long seconds,int pastSecond)
        {
            int height = panel1.Height - 2;
            //一秒占多少长度
            int width = (int)(secondWidth * seconds);
            Panel p = new Panel();
            p.Name = i.ToString();
            i++;
            p.BackColor = Color.Yellow;
            p.Size = new Size(width, height);
            p.Location = new Point((int)(secondWidth * pastSecond), 1);
            p.Tag = seconds;
            p.MouseDown += P_MouseDown;
            panels.Add(p);
            panel1.Controls.Add(p);
        }

        private void P_MouseDown(object sender, MouseEventArgs e)
        {
            Panel p = sender as Panel;
            pictureBox1.Location = new Point(e.X + p.Location.X, 0);
            //播放当前选中时间块的录像
            int index =int.Parse(p.Name);
            SendMessage(index);
            timer1.Interval =int.Parse(Math.Round(1/secondWidth).ToString())*1000;
            timer1.Start();
            pictureBox1.Location = new Point(p.Location.X, 0);
        }

        private void UserControl1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Location = new Point(e.X, 0);
        }
        //时间轴指针
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X+1, pictureBox1.Location.Y);
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            //timer1.Start();
        }
    }
}
