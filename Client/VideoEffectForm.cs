using PreviewDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class VideoEffectForm : Form
    {
        int lUserID=-1;
        int lChannel=-1;
        uint pBrightValue = 1;
        uint pContrastValue = 1;
        uint pSaturationValue = 1;
        uint pHueValue = 1;
        public VideoEffectForm()
        {
            InitializeComponent();
        }
        //public static CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30 m_comPressionCFG = new CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30();
        public VideoEffectForm(int lUserID,int lChannel)
        {
            InitializeComponent();
            this.lUserID = lUserID;
            this.lChannel = lChannel;
            CHCNetSDK.NET_DVR_GetVideoEffect(lUserID, lChannel, ref pBrightValue, ref pContrastValue, ref pSaturationValue, ref pHueValue);
            trackBar1.Value = (int)pBrightValue;
            trackBar2.Value = (int)pContrastValue;
            trackBar3.Value = (int)pSaturationValue;
            trackBar4.Value = (int)pHueValue;
            label5.Text = pBrightValue.ToString();
            label6.Text = pContrastValue.ToString();
            label7.Text = pSaturationValue.ToString();
            label8.Text = pHueValue.ToString();

            //UInt32 dwReturn_CFG = 0;
            //Int32 nSize_CFG = Marshal.SizeOf(m_comPressionCFG);
            //IntPtr comPressionCFG = Marshal.AllocHGlobal(nSize_CFG);
            //Marshal.StructureToPtr(m_comPressionCFG, comPressionCFG, false);
            //bool CFG = CHCNetSDK.NET_DVR_GetDVRConfig(lUserID, CHCNetSDK.NET_DVR_GET_COMPRESSCFG_V30, lChannel, comPressionCFG, (UInt32)nSize_CFG, ref dwReturn_CFG);

        }
        //亮度
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            string NewValue1= trackBar1.Value.ToString();
            label5.Text = NewValue1;
            CHCNetSDK.NET_DVR_SetVideoEffect(lUserID,lChannel, uint.Parse(NewValue1), pContrastValue, pSaturationValue, pHueValue);
        }
        //对比度
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            string NewValue2 = trackBar2.Value.ToString();
            label6.Text = NewValue2;
            CHCNetSDK.NET_DVR_SetVideoEffect(lUserID, lChannel, pBrightValue, uint.Parse(NewValue2), pSaturationValue, pHueValue);
        }
        //饱和度
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            string NewValue3 = trackBar3.Value.ToString();
            label7.Text = NewValue3;
            CHCNetSDK.NET_DVR_SetVideoEffect(lUserID, lChannel, pBrightValue, pContrastValue, uint.Parse(NewValue3), pHueValue);
        }
        //色度
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            string NewValue4 = trackBar4.Value.ToString();
            label8.Text = NewValue4;
            CHCNetSDK.NET_DVR_SetVideoEffect(lUserID, lChannel, pBrightValue, pContrastValue, pSaturationValue, uint.Parse(NewValue4));

        }
    }
}
