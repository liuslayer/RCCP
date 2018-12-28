using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary1;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PlayBack
{
    public partial class Form1 : Form
    {
        private const int CS_DropSHADOW = 0x20000;
        private const int GCL_STYLE = (-26);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        int lHandle=-1;
        public Form1()
        {
            InitializeComponent();
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW);
            int i = CMSSdk.VM_CMS_Init();
            if (i < 0)
            {
                MessageBox.Show("流媒体初始化失败！");
            }
            else
            {
                CMSSdk.LPCMS_USER_LOGIN_INFO LoginInfo = new CMSSdk.LPCMS_USER_LOGIN_INFO();
                LoginInfo.szIP = "192.0.0.66";
                LoginInfo.uPort = 8000;
                LoginInfo.szUser = "system";
                LoginInfo.szPassword = "system";
                lHandle = CMSSdk.VM_CMS_Login(ref LoginInfo, 0);
                if (lHandle < 0)
                {
                    MessageBox.Show("媒体管理服务器登录失败!");
                }
                else
                {
                    MessageBox.Show("媒体管理服务器登录成功！");
                }
            }

        }

        //添加流媒体服务器
        private void button1_Click(object sender, EventArgs e)
        {
            CMSSdk.LPCMS_VMSR VMSInfo = new CMSSdk.LPCMS_VMSR();
            VMSInfo.szIP=textBox1.Text;
            VMSInfo.szPort=textBox2.Text;
            VMSInfo.szMaxChannel=textBox3.Text;
            if (CMSSdk.VM_CMS_AddVMS(lHandle, ref VMSInfo, 0) < 0)
            {
                MessageBox.Show("添加流媒体服务器失败!");
            }
            else
            { MessageBox.Show("添加流媒体服务器成功！"); }
        }

        // 删除流媒体服务器
        private void button2_Click(object sender, EventArgs e)
        {

        }
        
         CMSSdk.MyAddress myAddress = new CMSSdk.MyAddress();
         CMSSdk.LPCMS_CONFIG_HIKVISION HIKConfig;
        //添加设备到流媒体服务器
        private void button4_Click(object sender, EventArgs e)
        {
            //获取摄像机RTSP地址
            HIKConfig = new CMSSdk.LPCMS_CONFIG_HIKVISION();
            HIKConfig.sDeviceAddress = "192.0.0.11";
            HIKConfig.ulPort = 554;
            HIKConfig.sUserName ="admin";
            HIKConfig.sPassword = "12345";
            HIKConfig.lChannel = 1;
            HIKConfig.ulStreamType = 0;
            HIKConfig.ulLinkMode = 0;
            HIKConfig.ulVideoEncType = 0;
            IntPtr sp=Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(CMSSdk.LPCMS_CONFIG_HIKVISION)));
            Marshal.StructureToPtr(HIKConfig,sp,true);
            int i;
            i = CMSSdk.VM_CMS_CAMToRTSP(ref HIKConfig, CMSSdk.emCMS_CAM_TYPE.CMS_CAM_HIKVISION,ref myAddress);
            if (i < 0)
            {
                MessageBox.Show("获取摄像机RTSP地址失败！");
            }
            ClassLibrary1.CMSSdk.LPCMS_CAM CAMInfo = new CMSSdk.LPCMS_CAM();
            
            CAMInfo.szSid = "ch2";
            CAMInfo.szIP = "192.0.0.11";
            CAMInfo.szPort = "554";
            CAMInfo.szRTSP = myAddress.szRtspOutput;
            CAMInfo.szMark = "hikvision";
            //CAMInfo.szState = "";

           //byte[] test= serializeInfoObjToByteArray(CAMInfo);
            i = CMSSdk.VM_CMS_AddCAM(lHandle,ref CAMInfo, 0);
            if (i < 0)
            {
                MessageBox.Show("添加摄像机失败！");
            }
            else
            {
                MessageBox.Show("添加摄像机成功！");
            }
        }private IFormatter formatter = new BinaryFormatter();
        private byte[] serializeInfoObjToByteArray(ValueType infoStruct)
        {
            if (infoStruct == null)
            {
                return null;
            }

            try
            {
                MemoryStream stream = new MemoryStream();
                formatter.Serialize(stream, infoStruct);

                byte[] bytes = new byte[(int)stream.Length];
                stream.Position = 0;
                int count = stream.Read(bytes, 0, (int)stream.Length);
                stream.Close();
                return bytes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //删除流媒体服务器中的设备
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //打开预览
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (lHandle != -1)
            {
                int i = CMSSdk.VM_CMS_RealPlay(lHandle, pictureBox1.Handle, "ch1");
                if (i < 0)
                    MessageBox.Show("视频预览失败！");
            }
        }
        //关闭预览
        private void button2_Click_1(object sender, EventArgs e)
        {
            CMSSdk.VM_CMS_StopPlay(lHandle);
        }
    }
}
