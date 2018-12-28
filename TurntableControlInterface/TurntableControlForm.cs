using Client.Entities;
using Client.Entities.ControlEntity;
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
using static Client.Entities.ControlCommandData;

namespace TurntableControlInterface
{
    public partial class TurntableControlForm : Form
    {
        private string imgPath = @".\images\TurntableControlForm\";

        //方向速度滑动条
        string str_trackBar1 = "";

        //俯仰速度滑动条
        string str_trackBar2 = "";

        bool TurntableDeviceType = false;
        //平均速度（使用时用的是两个数值的平均值）
        int average_speed = 0;
        private List<TurntablePresetData> presetList;
        public static Guid? VideoDeviceGuid;
        public static Guid? UserGuid;
        public static int VideoType = 101;
        //InterfaceControl tmpInterfaceControl = new InterfaceControl(); TurntablePresetData tmpPresetData
        public static Dictionary<Guid, SetWheelGuard> setWheelGuard = new Dictionary<Guid, SetWheelGuard>();
        public static Dictionary<Guid, List<TurntablePresetData>> wheelGuardData = new Dictionary<Guid, List<TurntablePresetData>>();
        string PresetName;
        public TurntableControlForm()
        {
            InitializeComponent();
            TurntableDeviceType = false;
            //CommunicationClassInit();
            //GetPresetList(VideoDeviceGuid);
            dataGridView1.Columns[1].Visible = false;
        }

        public void TurntableDeviceDataInit()
        {
            TurntableDeviceType = false;
            if (Class1.cameraList.Count > 0)
            {
                for (int i = 0; i < Class1.cameraList.Count; i++)
                {
                    if (Class1.cameraList[i].DeviceID == VideoDeviceGuid)
                    {
                        if (Class1.cameraList[i].Turntable_PTZ_DeviceID != null)
                        {
                            TurntableDeviceType = true;
                            return;
                        }
                        
                    }
                }
            }
        }

        /// <summary>
        /// 单独启动时需要初始化
        /// </summary>
        public void CommunicationClassInit()
        {
            bool result1 = CommunicationClass.Init();
            if (result1)
            {
                Class1 class1 = new Class1();
                class1.Init();
            }
        }
        

        /// <summary>
        /// 九个方向键的鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDirectionKeys_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "btnDirectionKeys\\" + btn.Name + "1-1.png");
            }
            catch { }

            //计算速度
            int speed1 = int.Parse(directionText.Text);
            int speed2 = int.Parse(pitchText.Text);
            int speed = (speed1 + speed2) / 2;
            //调用接口类InterfaceControl里的设备控制函数
            btnDirectionKeys_MouseDown(VideoDeviceGuid, btn.Name, speed, 0, UserGuid);
        }

        public static void VideoData(Guid tmpVideoDeviceGuid, Guid tmpUserGuid, int tmpVideoType)
        {
            VideoDeviceGuid = tmpVideoDeviceGuid;
            UserGuid = tmpUserGuid;
            VideoType = tmpVideoType;
        }

        public void btnDirectionKeys_MouseDown(Guid? tmpGuid, string strAction, int tmpSpeed, int tmpParameter, Guid? tmpUserGuid)
        {
            int i_Action = -1;
            switch (strAction)
            {
                case "Up":
                    i_Action = (int)HDCommand.Up;
                    break;
                case "Down":
                    i_Action = (int)HDCommand.Down;
                    break;
                case "Left":
                    i_Action = (int)HDCommand.Left;
                    break;
                case "Right":
                    i_Action = (int)HDCommand.Right;
                    break;
                case "LeftUp":
                    i_Action = (int)HDCommand.LeftUp;
                    break;
                case "LeftDown":
                    i_Action = (int)HDCommand.LeftDown;
                    break;
                case "RightUp":
                    i_Action = (int)HDCommand.RightUp;
                    break;
                case "RightDown":
                    i_Action = (int)HDCommand.RightDown;
                    break;
                case "InitialPoint":
                    i_Action = (int)HDCommand.InitialPoint;
                    break;
            }

            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备");  }
            else
            {
                if (tmpGuid != null && i_Action != -1)
                { InterfaceControl.HDControl(tmpGuid, i_Action, tmpSpeed, tmpParameter, tmpUserGuid); }
            }
        }

        /// <summary>
        /// 九个方向键的鼠标弹起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDirectionKeys_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "btnDirectionKeys\\" + btn.Name + "1.png");
            }
            catch { }

            int i_Action = (int)HDCommand.DirectionStop;
            if (TurntableDeviceType == false) {}
            else
            {
                if (VideoDeviceGuid != null)
                {
                    InterfaceControl.HDControl(VideoDeviceGuid, i_Action, 0, 0, UserGuid);
                }
            }  
        }


        /// <summary>
        /// 视场 聚焦 "-"号按钮鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSub_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "subBtn1.png");
            }
            catch { }
            int speed2 = int.Parse(pitchText.Text);
            if (btn.Name == "fieldBtnSub")//视场-
            {
                if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
                else
                {
                    if (VideoDeviceGuid != null)
                    {
                        if (VideoType == (int)VideoCommandType.VideoCCD)
                        {
                            InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_TurnShort, speed2, 0, UserGuid);
                        }
                        else if (VideoType == (int)VideoCommandType.VideoIR)
                        {
                            InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_TurnShort, speed2, 0, UserGuid);
                        }
                    }
                }
                
            }
            else if(btn.Name == "focusBtnSub")//聚焦-
            {
                if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
                else
                {
                    if (VideoDeviceGuid != null)
                    {
                        if (VideoType == (int)VideoCommandType.VideoCCD)
                        {
                            InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_FocusShort, speed2, 0, UserGuid);
                        }
                        else if (VideoType == (int)VideoCommandType.VideoIR)
                        {
                            InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_FocusShort, speed2, 0, UserGuid);
                        }
                    }
                }
                
            }
        }

        /// <summary>
        /// 视场 聚焦 "-"号按钮鼠标弹起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSub_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "subBtn2.png");
            }
            catch { }

            if (btn.Name == "fieldBtnSub")//视场-
            {
                if (TurntableDeviceType == false) {}
                else
                {
                    if (VideoDeviceGuid != null)
                    {
                        if (VideoType == (int)VideoCommandType.VideoCCD)
                        {
                            InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_TurnShortStop, 0, 0, UserGuid);
                        }
                        else if (VideoType == (int)VideoCommandType.VideoIR)
                        {
                            InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_TurnShortStop, 0, 0, UserGuid);
                        }
                    }
                }
                
            }
            else if (btn.Name == "focusBtnSub")//聚焦-
            {
                if (TurntableDeviceType == false) {}
                else
                {
                    if (VideoDeviceGuid != null)
                    {
                        if (VideoType == (int)VideoCommandType.VideoCCD)
                        {
                            InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_FocusShortStop, 0, 0, UserGuid);
                        }
                        else if (VideoType == (int)VideoCommandType.VideoIR)
                        {
                            InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_FocusStop, 0, 0, UserGuid);
                        }
                    }
                }
                
            }
        }

        /// <summary>
        /// 视场 聚焦 "+"号按钮鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "addBtn1.png");
            }
            catch { }
            int speed2 = int.Parse(pitchText.Text);
            if (btn.Name == "fieldBtnAdd")//视场 +
            {
                if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
                else
                {
                    if (VideoDeviceGuid != null)
                    {
                        if (VideoType == (int)VideoCommandType.VideoCCD)
                        {
                            InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_TurnLong, speed2, 0, UserGuid);
                        }
                        else if (VideoType == (int)VideoCommandType.VideoIR)
                        {
                            InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_TurnLong, speed2, 0, UserGuid);
                        }
                    }
                }
                
            }
            else if(btn.Name == "focusBtnAdd")//聚焦+
            {
                if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
                else
                {
                    if (VideoDeviceGuid != null)
                    {
                        if (VideoType == (int)VideoCommandType.VideoCCD)
                        {
                            InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_FocusLong, speed2, 0, UserGuid);
                        }
                        else if (VideoType == (int)VideoCommandType.VideoIR)
                        {
                            InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_FocusLong, speed2, 0, UserGuid);
                        }
                    }
                } 
            }


        }
        /// <summary>
        /// 视场 聚焦 "+"号按钮鼠标弹起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "addBtn2.png");
            }
            catch { }
            if(btn.Name == "fieldBtnAdd")
            {
                if (TurntableDeviceType == false) {}
                else
                {
                    if (VideoDeviceGuid != null)
                    {
                        if (VideoType == (int)VideoCommandType.VideoCCD)
                        {
                            InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_TurnLongStop, 0, 0, UserGuid);
                        }
                        else if (VideoType == (int)VideoCommandType.VideoIR)
                        {
                            InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_TurnLongStop, 0, 0, UserGuid);
                        }
                    }
                }
                
            }
            else if(btn.Name == "focusBtnAdd")
            {
                if (TurntableDeviceType == false) { }
                else
                {
                    if (VideoDeviceGuid != null)
                    {
                        if (VideoType == (int)VideoCommandType.VideoCCD)
                        {
                            InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_FocusLongStop, 0, 0, UserGuid);
                        }
                        else if (VideoType == (int)VideoCommandType.VideoIR)
                        {
                            InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_FocusStop, 0, 0, UserGuid);
                        }
                    }
                }
                
            }
        }
        /// <summary>
        /// 界面切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InterfaceSwitching(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "AzimuthControl"://方位控制
                    {
                        tabControl1.SelectedIndex = 0;
                    }
                    
                    break;
                case "PresetPositionControl"://预置位与扇扫
                    {
                        tabControl1.SelectedIndex = 1;
                        GetPresetList(VideoDeviceGuid);
                    }
                    break;
                case "BasicControl"://基础控制
                    {
                        CCDorIRorPZTswitch(VideoType);
                    }
                    break;
            }
        }
        /// <summary>
        /// 基本控制界面切换
        /// </summary>
        /// <param name="VideoType"></param>
        private void CCDorIRorPZTswitch(int VideoType)
        {
            switch(VideoType)
            {
                case (int)VideoCommandType.VideoCCD://白光控制
                    { tabControl1.SelectedIndex = 2; }
                    break;
                case (int)VideoCommandType.VideoIR://红外控制
                    { tabControl1.SelectedIndex = 3; }
                    break;
                case (int)VideoCommandType.VideoPTZ://球机控制
                    { tabControl1.SelectedIndex = 4; }
                    break;
            }
        }
        /// <summary>
        /// 红外控制 按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasicControl_IRMouseDown(object sender, MouseEventArgs e)
        {
            int tmpAction = -1;
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "btnDirectionKeys\\" + btn.Name + "1.png");
            }
            catch { }
            switch(btn.Name)
            {
                case "IRCrossForksOpen":
                    { tmpAction = (int)IRCommand.IR_CrossForksOpen; }
                    break;
                case "IRCrossForksOff":
                    { tmpAction = (int)IRCommand.IR_CrossForksOff; }
                    break;
                case "IRImageEnhancementOpen":
                    { tmpAction = (int)IRCommand.IR_ImageEnhancementOpen; }
                    break;
                case "IRImageEnhancementOff":
                    { tmpAction = (int)IRCommand.IR_ImageEnhancementOff; }
                    break;
                case "IRWhiteHeatModel":
                    { tmpAction = (int)IRCommand.IR_WhiteHeatModel; }
                    break;
                case "IRBlackHeatModel":
                    { tmpAction = (int)IRCommand.IR_BlackHeatModel; }
                    break;
                case "IR1XLens":
                    { tmpAction = (int)IRCommand.IR_1XLens; }
                    break;
                case "IR2XLens":
                    { tmpAction = (int)IRCommand.IR_2XLens; }
                    break;
                case "IRAutofocusOpen":
                    { tmpAction = (int)IRCommand.IR_AutofocusOpen; }
                    break;
                case "IRAutofocusOff":
                    { tmpAction = (int)IRCommand.IR_AutofocusOff; }
                    break;
                case "IRManualCorrection":
                    { tmpAction = (int)IRCommand.IR_ManualCorrection; }
                    break;
                case "IRBackgroundCorrection":
                    { tmpAction = (int)IRCommand.IR_BackgroundCorrection; }
                    break;
                case "IRGammaCorrection":
                    { tmpAction = (int)IRCommand.IR_GammaCorrection; }
                    break;
                case "IRShutterCorrection":
                    { tmpAction = (int)IRCommand.IR_ShutterCorrection; }
                    break;
            }
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, tmpAction, 0, 0, UserGuid);
            }
        }
        /// <summary>
        /// 白光控制 按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasicControl_CCDMouseDown(object sender, MouseEventArgs e)
        {
            int tmpAction = -1;
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "btnDirectionKeys\\" + btn.Name + "1.png");
            }
            catch { }

            switch (btn.Name)
            {
                case "CCDApertureSub":
                    { tmpAction = (int)CCDCommand.CCD_ApertureSub; }
                    break;
                case "CCDApertureAdd":
                    { tmpAction = (int)CCDCommand.CCD_ApertureSub; }
                    break;
                case "CCD2XEnlarge":
                    { tmpAction = (int)CCDCommand.CCD_FocusLongStop; }
                    break;
                case "CCD2XNarrow":
                    { tmpAction = (int)CCDCommand.CCD_FocusLongStop; }
                    break;
                case "CCDShutterCorrection":
                    { tmpAction = (int)CCDCommand.CCD_ShutterCorrection; }
                    break;
                case "CCDAutofocus":
                    { tmpAction = (int)CCDCommand.CCD_Autofocus; }
                    break;
                case "CCDRearFocus":
                    { tmpAction = (int)CCDCommand.CCD_RearFocus; }
                    break;
                case "CCDPenetratingFogOpen":
                    { tmpAction = (int)CCDCommand.CCD_PenetratingFogOpen; }
                    break;
                case "CCDPenetratingFogOff":
                    { tmpAction = (int)CCDCommand.CCD_PenetratingFogOff; }
                    break;
            }
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.CCDControl(VideoDeviceGuid, tmpAction, 0, 0, UserGuid);
            }
        }
        /// <summary>
        /// 获取预置位信息
        /// </summary>
        /// <param name="tmpVideoDeviceGuid"></param>
        private void GetPresetList(Guid? tmpVideoDeviceGuid)
        {
            presetList = InterfaceControl.GetPreset(tmpVideoDeviceGuid);
            if (presetList != null)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < presetList.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = presetList[i].PresetName;
                    dataGridView1.Rows[index].Cells[1].Value = presetList[i].VideoGuid;
                }
            }
        }
        /// <summary>
        /// 预置位添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                if (VideoDeviceGuid != null)
                {
                    //Preset_Add_Form tmpPresetAddForm = new Preset_Add_Form(VideoDeviceGuid.Value, VideoType,
                    //    "H","V","D","F", UserGuid);
                    Preset_Add_Form tmpPresetAddForm = new Preset_Add_Form(VideoDeviceGuid.Value);
                    tmpPresetAddForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("该设备不能添加预置位！");
                }
            }
        }
        /// <summary>
        /// 预置删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            {
                if (VideoDeviceGuid != null && PresetName != null && !setWheelGuard.ContainsKey(VideoDeviceGuid.Value))
                {
                    TurntablePresetData tmpPresetData = new TurntablePresetData();
                    tmpPresetData.VideoGuid = VideoDeviceGuid;
                    tmpPresetData.PresetName = PresetName;
                    InterfaceControl.DelPreset(tmpPresetData);
                    MessageBox.Show("删除预置位成功！");
                }
                else
                {
                    MessageBox.Show("该设备不能删除预置位！");
                }
            }  
        }
        /// <summary>
        /// 预置位调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetPreset_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            {
                if (VideoDeviceGuid != null && PresetName != null)
                {
                    TurntablePresetData tmpPresetData = new TurntablePresetData();
                    tmpPresetData.VideoGuid = VideoDeviceGuid;
                    tmpPresetData.PresetName = PresetName;
                    InterfaceControl.SetPreset(tmpPresetData);
                }
                else
                {
                    MessageBox.Show("该设备不能调用预置位！");
                }
            } 
        }
        /// <summary>
        /// 预置位修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            {
                if (VideoDeviceGuid != null && PresetName != null)
                {
                    TurntablePresetData tmpPresetData = new TurntablePresetData();
                    tmpPresetData.VideoGuid = VideoDeviceGuid;
                    tmpPresetData.PresetName = PresetName;
                    InterfaceControl.UpdatePrese(tmpPresetData);
                    MessageBox.Show("修改预置位成功！");
                }
                else
                {
                    MessageBox.Show("该设备不能调用预置位！");
                }
            }
        }
        /// <summary>
        /// 预置位轮巡 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wheelGuard_Click(object sender, EventArgs e)
        {
            //TurntableControlForm.VideoDeviceGuid = new Guid(DeviceIDs[selectedIndex]);
            //TurntableControlForm.UserGuid = new Guid();
            //TCF.TurntableDeviceDataInit();

            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                if (VideoDeviceGuid != null)
                {
                    Preset_WheelGuard_Form tmp = new Preset_WheelGuard_Form(VideoDeviceGuid);
                    //tmp.VideoDeviceGuid = VideoDeviceGuid;
                    tmp.Show();
                }
                else
                {
                    MessageBox.Show("该设备不能设置轮巡！");
                }
            } 
        }
        /// <summary>
        /// 扇扫控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sectorScan_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                if (VideoDeviceGuid != null)
                {
                    int speed1 = int.Parse(directionText.Text);
                    int speed2 = int.Parse(pitchText.Text);
                    SectorScan_Form tmpSectorScanForm = new SectorScan_Form(VideoDeviceGuid, speed1, speed2);
                    tmpSectorScanForm.ShowDialog();
                }
            }
            
        }

        /// <summary>
        /// 红外控制 按钮弹起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasicControl_IRMouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "btnDirectionKeys\\" + btn.Name + "2.png");
            }
            catch { }
        }

        /// <summary>
        /// 白光控制 按钮弹起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasicControl_CCDMouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "btnDirectionKeys\\" + btn.Name + "2.png");
            }
            catch { }
        }

        /// <summary>
        /// 方向速度"-"鼠标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionSub_Click(object sender, EventArgs e)
        {
            if (trackBar1.Value == 1)
            {
                trackBar1.Value = 1;
            }
            else
            {
                trackBar1.Value -= 1;
            }

            directionText.Text = trackBar1.Value.ToString();//方向速度滑动条后的显示文本
            str_trackBar1 = trackBar1.Value.ToString();
            str_trackBar2 = trackBar2.Value.ToString();
        }

        

        /// <summary>
        /// 方向速度"+"鼠标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionAdd_Click(object sender, EventArgs e)
        {
            if (trackBar1.Value == 255)
            {
                trackBar1.Value = 255;
            }
            else
            {
                trackBar1.Value += 1;
            }

            directionText.Text = trackBar1.Value.ToString();//方向速度滑动条后的显示文本
            str_trackBar1 = trackBar1.Value.ToString();
            str_trackBar2 = trackBar2.Value.ToString();
        }


        /// <summary>
        /// 俯仰速度"-"鼠标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PitchBtnSub_Click(object sender, EventArgs e)
        {
            if (trackBar2.Value == 1)
            {
                trackBar2.Value = 1;
            }
            else
            {
                trackBar2.Value -= 1;
            }

            pitchText.Text = trackBar2.Value.ToString();//方向速度滑动条后的显示文本
            str_trackBar1 = trackBar1.Value.ToString();
            str_trackBar2 = trackBar2.Value.ToString();
            average_speed = (Convert.ToInt32(str_trackBar1) + Convert.ToInt32(str_trackBar2)) / 2;
        }

        /// <summary>
        /// 俯仰速度"+"滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PitchBtnAdd_Click(object sender, EventArgs e)
        {
            if (trackBar2.Value == 255)
            {
                trackBar2.Value = 255;
            }
            else
            {
                trackBar2.Value += 1;
            }

            pitchText.Text = trackBar2.Value.ToString();//方向速度滑动条后的显示文本
            str_trackBar1 = trackBar1.Value.ToString();
            str_trackBar2 = trackBar2.Value.ToString();
            average_speed = (Convert.ToInt32(str_trackBar1) + Convert.ToInt32(str_trackBar2)) / 2;
        }

        /// <summary>
        /// 方向速度"滑动条"滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            directionText.Text = trackBar1.Value.ToString();//方向速度滑动条后的显示文本
            str_trackBar1 = trackBar1.Value.ToString();
            str_trackBar2 = trackBar2.Value.ToString();
            average_speed = (Convert.ToInt32(str_trackBar1) + Convert.ToInt32(str_trackBar2)) / 2;

        }
        /// <summary>
        /// 俯仰速度"滑动条"滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            pitchText.Text = trackBar2.Value.ToString();//俯仰速度滑动条后的显示文本
            str_trackBar1 = trackBar1.Value.ToString();
            str_trackBar2 = trackBar2.Value.ToString();
            average_speed = (Convert.ToInt32(str_trackBar1) + Convert.ToInt32(str_trackBar2)) / 2;
        }

        

        /// <summary>
        /// 九个方向键的鼠标进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDirectionKeys_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "btnDirectionKeys\\" + btn.Name + "1.png");
            }
            catch { }
        }

        /// <summary>
        /// 九个方向键的鼠标离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDirectionKeys_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "btnDirectionKeys\\" + btn.Name + "1-1.png");
            }
            catch { }
        }

        /// <summary>
        /// "-"号按钮鼠标进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSub_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "subBtn2.png");
            }
            catch { }
        }
        /// <summary>
        /// "-"号按钮鼠标离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSub_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "subBtn1.png");
            }
            catch { }
        }

        /// <summary>
        /// "+"号按钮鼠标进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "addBtn2.png");
            }
            catch { }
        }

        /// <summary>
        /// "+"号按钮鼠标离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                btn.BackgroundImage = Image.FromFile(imgPath + "addBtn1.png");
            }
            catch { }
        }

        private void CCDApertureSub_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_ApertureSub, 0, 0, null); 
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_ApertureManual, 0, 0, null);
            }
        }

        private void CCDApertureAdd_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_AperturePlus, 0, 0, null);
            }
        }

        private void CCD2XEnlarge_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_AperturePlus, 0, 0, null);
            }
        }

        private void CCD2XNarrow_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_AperturePlus, 0, 0, null);
            }
        }

        private void CCDShutterCorrection_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_ShutterCorrection, 0, 0, null);
            }
        }

        private void CCDAutofocus_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_Autofocus, 0, 0, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_RearFocus, 0, 0, null);
            }
        }

        private void CCDPenetratingFogOpen_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_PenetratingFogOpen, 0, 0, null);
            }
        }

        private void CCDPenetratingFogOff_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.CCDControl(VideoDeviceGuid, (int)CCDCommand.CCD_PenetratingFogOff, 0, 0, null);
            }
        }

        private void IRCrossForksOpen_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_CrossForksOpen, 0, 0, null);
            }
        }

        private void IRCrossForksOff_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_CrossForksOff, 0, 0, null);
            }
        }

        private void IRManualCorrection_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_ManualCorrection, 0, 0, null);
            }
        }

        private void IRWhiteHeatModel_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_WhiteHeatModel, 0, 0, null);
            }
        }

        private void IRBlackHeatModel_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_BlackHeatModel, 0, 0, null);
            }
        }

        private void IRBackgroundCorrection_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_BackgroundCorrection, 0, 0, null);
            }
        }

        private void IR1XLens_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_1XLens, 0, 0, null);
            }
        }

        private void IR2XLens_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_2XLens, 0, 0, null);
            }
        }

        private void IRGammaCorrection_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_GammaCorrection, 0, 0, null);
            }
        }

        private void IRAutofocusOpen_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_AutofocusOpen, 0, 0, null);
            }
        }

        private void IRAutofocusOff_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_AutofocusOff, 0, 0, null);
            }
        }

        private void IRShutterCorrection_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_ShutterCorrection, 0, 0, null);
            }
        }

        private void IRImageEnhancementOpen_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_ImageEnhancementOpen, 0, 0, null);
            }
        }

        private void IRImageEnhancementOff_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)IRCommand.IR_ImageEnhancementOff, 0, 0, null);
            }
        }

        private void PTZApertureSub_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)CCDCommand.CCD_ApertureSub, 0, 0, null);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)CCDCommand.CCD_ApertureManual, 0, 0, null);
            }
        }

        private void ApertureAdd_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)CCDCommand.CCD_AperturePlus, 0, 0, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)CCDCommand.CCD_ApertureAuto, 0, 0, null);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TurntableDeviceType == false) { MessageBox.Show("该视频未绑定控制设备"); }
            else
            {
                InterfaceControl.IRControl(VideoDeviceGuid, (int)CCDCommand.CCD_ApertureAuto, 0, 0, null);
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            PresetName = null;
            if (e.Button == MouseButtons.Left && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                PresetName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                //dataGridView1.Rows[index].Cells[0].Value = presetList[i].PresetName;
            }
        }

        private void button_UPSData_Click(object sender, EventArgs e)
        {
            UpsDataFrom s = new UpsDataFrom();
            s.ShowDialog();
        }
    }
}
