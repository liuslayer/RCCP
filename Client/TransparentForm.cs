using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Client
{
    public partial class TransparentForm : Form
    {
        PictureBox[] ps = new PictureBox[Form1.BoxCount];
        int[] tag_rec = new int[Form1.BoxCount];//记录录像点是否显示
        int[] tag_arm = new int[Form1.BoxCount];//记录布放点是否显示
        public TransparentForm()
        {
            InitializeComponent();
           
            for(int i=0;i< Form1.BoxCount; i++)
            {
                PictureBox p = new PictureBox();
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.BackgroundImageLayout = ImageLayout.Stretch;
                p.BackColor = Color.Transparent;
                ps[i]=p;
            }            
        }
        //画录像点
        public void DrawRecPoint(int index)
        {
            if (index == -1) return;
            Bitmap bm = new Bitmap(ps[index].Width, ps[index].Height);
            Graphics g = Graphics.FromImage(bm);
            Brush bush = new SolidBrush(Color.Red);
            g.FillEllipse(bush, 10, 10, 10, 10);
            float fontSize = 12.0f;//字体大小
            string text = "REC";
            RectangleF textArea = new RectangleF(25, 7, text.Length * (fontSize + 8), fontSize+8);
            Font font = new Font("宋体", fontSize);
            Brush redBrush = new SolidBrush(Color.Red);
            g.DrawString(text, font, redBrush, textArea);
            g.Save();
            ps[index].Image = bm;
            tag_rec[index] = 1;
        }

        //擦除录像点
        public void WipeRecPoint(int index)
        {
            if (index == -1 || ps[index].Image == null ) return;
            Bitmap bm = (Bitmap)ps[index].Image;
            Graphics g = Graphics.FromImage(bm);
            Brush bush = new SolidBrush(Color.Transparent);
            g.Clear(Color.Transparent);
            g.Save();
            ps[index].Image = bm;
            tag_rec[index] = 0;
        }

        //画布防点
        public void DrawArmPoint(int index)
        {
            if (index == -1) return;
            float fontSize = 12.0f;//字体大小
            string text = "Arm";
            float x = ps[index].Width - text.Length * (fontSize + 8) - 25;
            Bitmap bm= new Bitmap(ps[index].Width, ps[index].Height);
            Graphics g = Graphics.FromImage(bm);
            SolidBrush bush = new SolidBrush(Color.Green);
            g.FillEllipse(bush, x, 10, 10, 10);
            RectangleF textArea = new RectangleF(x+10, 7, text.Length * (fontSize + 8), fontSize + 8);
            Font font = new Font("宋体", fontSize);
            g.DrawString(text, font, bush, textArea);
            g.Save();
            ps[index].BackgroundImage = bm;
            tag_arm[index] = 1;
        }

        //擦除布放点
        public void WipeArmPoint(int index)
        {
            if (index == -1 || ps[index].BackgroundImage == null) return;
            Bitmap bm = (Bitmap)ps[index].BackgroundImage;
            Graphics g = Graphics.FromImage(bm);
            Brush bush = new SolidBrush(Color.Transparent);
            g.Clear(Color.Transparent);
            g.Save();
            ps[index].BackgroundImage = bm;
            ps[index].Refresh();
            tag_arm[index] = 0;
        }

        /// <summary>
        /// 切换分屏时，重绘录像点和布放点
        /// </summary>
        public void ChangeFrames()
        {
            for(int i=0;i< Form1.BoxCount; i++)
            {
                if(tag_rec[i]==1)
                    DrawRecPoint(i);//重绘录像点

                if(tag_arm[i]==1)
                    DrawArmPoint(i);//重绘布放点
            }
        }

        /// 设置视频框
        /// </summary>
        /// <param name="Num">要设置的视频框数</param>
        public void SetPictureBox(int Num,Size size,Point point)
        {
            Size =size;
            Location = point;
            double num = Math.Sqrt(Num);
            Controls.Clear();
            int width = (int)((size.Width - num - 1) / num);
            int height = (int)((size.Height - num - 1) / num);
            int x = 1;
            int y = 1;
            int tag = 0;
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    Controls.Add(ps[tag]);
                    ps[tag].Size = new Size(width, height);
                    ps[tag].Location = new Point(x * (j + 1) + j * width, y * (i + 1) + i * height);
                    tag++;
                }
            }
            ChangeFrames();
        }
        /// <summary>
        /// 选中的视频框全屏
        /// </summary>
        /// <param name="selectedIndex">选择视频框的下标</param>
        public void FullScreen(int selectedIndex,Size size,Point point)
        {
            Size = size;
            Location = point;
            Controls.Clear();
            Controls.Add(ps[selectedIndex]);
            ps[selectedIndex].Size = size;
            ps[selectedIndex].Location = new Point(0, 0);
            ChangeFrames();
        }

      
    }
}
