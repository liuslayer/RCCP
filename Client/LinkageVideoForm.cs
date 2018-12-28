using Client.Entities.AlarmEntity;
using DeviceBaseData;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Client
{
    public partial class LinkageVideoForm : Form
    {
        #region 窗体特效
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        public const Int32 AW_CENTER = 0x00000010;//
        public const Int32 AW_HIDE = 0x00010000;//
        #endregion
        #region 窗体随意拖动
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0X0112;
        public const int SC_MOVE = 0XF010;
        public const int HTCAPTION = 0X0002;
        #endregion
        Videobox[] videoboxs;//视频框
        int[] hwnd;//存储打开的流媒体句柄
        string[] SID;//存储已经打开的视频sSID
        public LinkageVideoForm(string DeviceID)
        {
            InitializeComponent();
            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果
            PresetDataManage pdata = Form1.PDM[Form1.selectedIndex];
            if (pdata == null) return;

            //获得视频数，生成对应视频框，依次打开视频，
            string[] DeviceIDs = pdata.temp_LinkageData._videodeviceid.Split(new char[] { ',' });
            int VideoBoxCount = DeviceIDs.Length;
            SID = new string[VideoBoxCount];
            hwnd = new int[VideoBoxCount];
            videoboxs = new Videobox[VideoBoxCount];
            for (int i = 0; i < VideoBoxCount; i++)
            {
                Videobox videobox = new Videobox();
                videobox.MouseDown += Videobox_MouseDown;
                videobox.Tag = i;
                videoboxs[i] = videobox;
            }
            SetVideoBox(VideoBoxCount);
            //依次打开视频
            for(int j=0;j<VideoBoxCount;j++)
            {
                RealPlay(DeviceIDs[j], j);
            }
        }
        /// <summary>
        /// 设置视频框(支持n^2数量设置)
        /// </summary>
        /// <param name="Num">要设置的视频框数</param>
        private void SetVideoBox(int Num)
        {
            try
            {
                double num = Math.Sqrt(Num);
                panel3.Controls.Clear();
                int width = (int)((panel3.Width - num - 1) / num);
                int height = (int)((panel3.Height - num - 1) / num);
                int x = 1;
                int y = 1;
                int tag = 0;
                for (int i = 0; i < num; i++)
                {
                    for (int j = 0; j < num; j++)
                    {
                        panel3.Controls.Add(videoboxs[tag]);

                        videoboxs[tag].Size = new Size(width, height);
                        videoboxs[tag].Location = new Point(x * (j + 1) + j * width, y * (i + 1) + i * height);
                        tag++;
                    }
                }
            }
            catch { }
        }

        public delegate int ControlDelegate(object strDeviceID, int index);
        /// <summary>
        /// 视频预览
        /// </summary>
        /// <param name="strDeviceID"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int RealPlay(object strDeviceID, int index)
        {
            if (videoboxs[index].InvokeRequired)
            {
                ControlDelegate d = RealPlay;
                videoboxs[index].Invoke(d, strDeviceID);
            }
            else
            {
                Guid DeviceID = (Guid)strDeviceID;
                Entities.CameraList device = Class1.cameraList.Find(
                    delegate (Entities.CameraList camera)
                    {
                        return camera.DeviceID.Equals(DeviceID);
                    }
                    );
                if (device == null) return -1;
                Entities.StreamMediaList streamMedia = Class1.streamMediaList.Find(
                    delegate (Entities.StreamMediaList sm)
                    {
                        return sm.DeviceID.Equals(device.StreamMedia_DeviceID);

                    });
                if (streamMedia == null) return -1;
                Entities.StreamServerList server = Class1.streamServerList.Find(
                    delegate (Entities.StreamServerList ss)
                    {
                        return ss.DeviceID.Equals(streamMedia.StreamServerID);
                    }
                    );
                if (server == null) return -1;

                //视频预览
                VMSdk.VM_CLIENT_CONFIG_VMSTREAMINGSER config = new VMSdk.VM_CLIENT_CONFIG_VMSTREAMINGSER();
                config.sSID = device.Stream_MainID.ToString();
                config.sDeviceAddress = server.StreamServerIP;
              
                    hwnd[index] = VMSdk.VM_CLIENT_RealPlay(videoboxs[index].pictureBox1.Handle.ToInt32(), ref config, (int)VMSdk.VM_CLIENT_DEV_TYPE.VM_CLIENT_DEV_RTSP_VMSTREAMINGSER);
                    if (hwnd[index] == -1)
                        MessageBox.Show("视频预览失败！");
                    else
                        SID[index] = config.sSID;
                
            }
            return hwnd[index];
        }
        private void Videobox_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void LinkageVideoForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        
    }
}
