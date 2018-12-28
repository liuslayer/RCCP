using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMClient
{
    public partial class TurntableForm : Form
    {
        public Guid ID;
        public MapForm mapForm;
        public TurntableForm(MapForm mapForm,List<CameraList> cameraList, List<CameraStatusList> cameraStatusList, List<StreamMediaList> streamMediaList)
        {
            InitializeComponent();
            this.mapForm = mapForm;

            try
            {
                if (cameraList.Count == 2)
                {
                    this.expandablePanel2.Visible = true;
                    CameraList cameraCCD = cameraList.Find(_ => _.VideoType == ((int)VideoCommandType.VideoCCD).ToString());
                    StreamMediaList streamMediaCCD = streamMediaList.Find(_ => _.DeviceID == cameraCCD.StreamMedia_DeviceID);
                    this.expandablePanel1.TitleText = cameraCCD.VideoName;
                    this.labelX1_IP.Text = streamMediaCCD == null ? "未知" : streamMediaCCD.VideoIP;
                    CameraList cameraIR = cameraList.Find(_ => _.VideoType == ((int)VideoCommandType.VideoIR).ToString());
                    StreamMediaList streamMediaIR = streamMediaList.Find(_ => _.DeviceID == cameraIR.StreamMedia_DeviceID);
                    this.expandablePanel2.TitleText = cameraIR.VideoName;
                    this.labelX2_IP.Text = streamMediaIR == null ? "未知" : streamMediaIR.VideoIP;

                    CameraStatusList cameraStatusCCD = cameraStatusList.Find(_ => _.DeviceID == cameraCCD.DeviceID);
                    if (cameraStatusCCD == null)
                        return;
                    this.labelX1_IsOnline.Text = cameraStatusCCD.IsOnline ? "在线" : "不在线";
                    if (cameraStatusCCD.IsOnline)
                    {
                        this.labelX1_SignalStatus.Text = Enum.Parse(typeof(SignalStatusType), cameraStatusCCD.SignalStatus.ToString()).ToString();
                        this.labelX1_RecordStatus.Text = Enum.Parse(typeof(RecordStatusType), cameraStatusCCD.RecordStatus.ToString()).ToString();
                        this.labelX1_Time.Text = cameraStatusCCD.Time.ToString();
                        this.labelX1_HardwareStatus.Text = Enum.Parse(typeof(HardwareStatusType), cameraStatusCCD.HardwareStatus.ToString()).ToString();
                        this.labelX1_BitRate.Text = (double)cameraStatusCCD.BitRate / 1000 + "KBit/S";
                    }

                    CameraStatusList cameraStatusIR = cameraStatusList.Find(_ => _.DeviceID == cameraIR.DeviceID);
                    if (cameraStatusIR == null)
                        return;
                    this.labelX2_IsOnline.Text = cameraStatusIR.IsOnline ? "在线" : "不在线";
                    if (cameraStatusIR.IsOnline)
                    {
                        this.labelX2_SignalStatus.Text = Enum.Parse(typeof(SignalStatusType), cameraStatusIR.SignalStatus.ToString()).ToString();
                        this.labelX2_RecordStatus.Text = Enum.Parse(typeof(RecordStatusType), cameraStatusIR.RecordStatus.ToString()).ToString();
                        this.labelX2_Time.Text = cameraStatusIR.Time.ToString();
                        this.labelX2_HardwareStatus.Text = Enum.Parse(typeof(HardwareStatusType), cameraStatusIR.HardwareStatus.ToString()).ToString();
                        this.labelX2_BitRate.Text = (double)cameraStatusIR.BitRate / 1000 + "KBit/S";
                    }
                }
                else
                {
                    this.expandablePanel2.Visible = false;
                    CameraStatusList cameraStatus = cameraStatusList.Find(_ => _.DeviceID == cameraList[0].DeviceID);
                    if (cameraStatus == null)
                        return;
                    this.labelX1_IsOnline.Text = cameraStatus.IsOnline ? "在线" : "不在线";
                    if (cameraStatus.IsOnline)
                    {
                        this.labelX1_SignalStatus.Text = Enum.Parse(typeof(SignalStatusType), cameraStatus.SignalStatus.ToString()).ToString();
                        this.labelX1_RecordStatus.Text = Enum.Parse(typeof(RecordStatusType), cameraStatus.RecordStatus.ToString()).ToString();
                        this.labelX1_Time.Text = cameraStatus.Time.ToString();
                        this.labelX1_HardwareStatus.Text = Enum.Parse(typeof(HardwareStatusType), cameraStatus.HardwareStatus.ToString()).ToString();
                        this.labelX1_BitRate.Text = (double)cameraStatus.BitRate / 1000 + "KBit/S";
                    }
                }
            }
            catch
            {
                MessageBox.Show("数据加载出错");
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            mapForm.markerIDList.Remove(ID);
            this.Close();
        }

        private void DisplayInfoForm_Load(object sender, EventArgs e)
        {
        }
    }
}
