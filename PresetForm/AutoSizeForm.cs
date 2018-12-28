using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PresetForm
{
    public class AutoSizeForm
    {
        //(1).声明结构,只记录窗体和其控件的初始位置和大小。  
        public struct controlRect
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;
            public float FontSize;
        }

        //(2).声明 1个对象  
        //注意这里不能使用控件列表记录 List<Control> nCtrl;，因为控件的关联性，记录的始终是的大小。  
        public List<controlRect> oldCtrl;

        //int ctrl_first = 0;  
        //(3). 创建两个函数  
        //(3.1)记录窗体和其控件的初始位置和大小,  
        public void controllInitializeSize(Form mForm)
        {
            // if (ctrl_first == 0)  
            {
                //  ctrl_first = 1;  
                oldCtrl = new List<controlRect>();
                controlRect cR;
                //记录窗体位置和大小及字体大小  
                cR.Left = mForm.Left;
                cR.Top = mForm.Top;
                cR.Width = mForm.Width;
                cR.Height = mForm.Height;
                //cR.Width = int.Parse(mForm.Tag.ToString().Split(',')[0]);
                //cR.Height = int.Parse(mForm.Tag.ToString().Split(',')[1]);
                cR.FontSize = mForm.Font.Size;

                oldCtrl.Add(cR);
                //记录控件的位置大小及字体大小  
                GetControlSize(mForm);
            }
        }

        //记录控件容器中各个控件的位置与大小  
        private void GetControlSize(Control con)
        {
            int s = con.Controls.Count;
            string name = con.Name;
            //记录控件的位置大小及字体大小  
            foreach (Control c in con.Controls)
            {
                controlRect objCtrl;
                objCtrl.Left = c.Left;
                objCtrl.Top = c.Top;
                objCtrl.Width = c.Width;
                objCtrl.Height = c.Height;
                objCtrl.FontSize = c.Font.Size;
                oldCtrl.Add(objCtrl);
                //记录容器控件中的控件位置，大小，及字体大小  
                if (c.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    GetControlSize(c);
                }
            }
        }


        //(3.2)控件自适应大小,  
        public void controlAutoSize(Form mForm)
        {
            float wScale;
            float hScale;
            try
            {
                wScale = (float)mForm.Width / (float)oldCtrl[0].Width;//新旧窗体之间的比例，与最早的旧窗体  
                hScale = (float)mForm.Height / (float)oldCtrl[0].Height;//.Height;  
            }
            catch (Exception)
            {
                return;
            }

            //int ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0;
            //float ctrFontSize0;
            int ctrlNo = 1;//第1个是窗体自身的 Left,Top,Width,Height，所以窗体控件从ctrlNo=1开始  

            SetSize(mForm, ctrlNo, wScale, hScale);

        }

        private void SetSize(Control con, int ctrlNo, float wScale, float hScale)
        {
            int ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0;
            float ctrFontSize0;
            int s = con.Controls.Count;
            string name = con.Name;
            foreach (Control c in con.Controls)
            {
                ctrLeft0 = oldCtrl[ctrlNo].Left;
                ctrTop0 = oldCtrl[ctrlNo].Top;
                ctrWidth0 = oldCtrl[ctrlNo].Width;
                ctrHeight0 = oldCtrl[ctrlNo].Height;
                ctrFontSize0 = oldCtrl[ctrlNo].FontSize;

                c.Left = (int)((ctrLeft0) * wScale);//新旧控件之间的线性比例。控件位置只相对于窗体，所以不能加 + wLeft1  
                c.Top = (int)((ctrTop0) * hScale);//  
                c.Width = (int)(ctrWidth0 * wScale)+1;//只与最初的大小相关，所以不能与现在的宽度相乘 (int)(c.Width * w);  
                c.Height = (int)(ctrHeight0 * hScale)+1;//  
                c.Font = new Font(c.Font.Name, (float)(ctrFontSize0 * hScale),c.Font.Style, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                ctrlNo += 1;
                if (ctrlNo >= oldCtrl.Count) return;
                if (c.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    SetSize(c, ctrlNo, wScale, hScale);//设置控件容器中的控件大小。  
                    ctrlNo += c.Controls.Count;
                }
            }
        }
    }

}
