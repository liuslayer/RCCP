using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ExternalDataCentreService
{
    public class Control_Command
    {
        public class DeviceData
        {
            public ControlData tmpControlData;
            public TurntablePresetData tmpTurntablePresetData;
            public SectorScanData tmpSectorScanData;
            public Guid? tmp_Guid;
            public TurntableStateData tmpTurntableStateData;
        }
        //转台控制
        public static void HDControl(ControlData tmpControlData)
        {
            if (tmpControlData.VideoGuid != null)
            {
              DeviceData data = new DeviceData();
              data.tmpControlData = tmpControlData;
              string str = JsonConvert.SerializeObject(data);
              string message = "EquipmentControl/HD," + str + "\r\n";
              byte[] b = Encoding.UTF8.GetBytes(message);
                if(!CommunicationClass.tcp2.Connected)
                {
                    CommunicationClass.tcp2 = new TcpClient();
                    string DCServer_IP = ConfigurationManager.AppSettings["DCServer_IP"];
                    int DCServer_Port = int.Parse(ConfigurationManager.AppSettings["DCServer_Port"]);
                    try
                    {
                        CommunicationClass.tcp2.Connect(DCServer_IP, DCServer_Port);
                        CommunicationClass.stream2 = CommunicationClass.tcp2.GetStream();
                    }catch
                    {
                        MessageBox.Show("连接服务器失败！");
                    }
                }
               CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
        /// <summary>
        /// 获取转台镜头状态
        /// </summary>
        /// <param name="VideoGuid"></param>
        public static void GetStateData(Guid? VideoGuid)
        {
            if (VideoGuid != null)
            {
                DeviceData data = new DeviceData();
                data.tmp_Guid = VideoGuid;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/SuperiorGetStateData," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                if (!CommunicationClass.tcp2.Connected)
                {
                    CommunicationClass.tcp2 = new TcpClient();
                    string DCServer_IP = ConfigurationManager.AppSettings["DCServer_IP"];
                    int DCServer_Port = int.Parse(ConfigurationManager.AppSettings["DCServer_Port"]);
                    try
                    {
                        CommunicationClass.tcp2.Connect(DCServer_IP, DCServer_Port);
                        CommunicationClass.stream2 = CommunicationClass.tcp2.GetStream();
                    }
                    catch
                    {
                        MessageBox.Show("连接服务器失败！");
                    }
                }
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        //白光控制
        public static void CCDControl(ControlData tmpControlData)
        {
            if (tmpControlData.VideoGuid != null)
            {
                DeviceData data = new DeviceData();
                data.tmpControlData = tmpControlData;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/CCD," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                if (!CommunicationClass.tcp2.Connected)
                {
                    CommunicationClass.tcp2 = new TcpClient();
                    string DCServer_IP = ConfigurationManager.AppSettings["DCServer_IP"];
                    int DCServer_Port = int.Parse(ConfigurationManager.AppSettings["DCServer_Port"]);
                    try
                    {
                        CommunicationClass.tcp2.Connect(DCServer_IP, DCServer_Port);
                        CommunicationClass.stream2 = CommunicationClass.tcp2.GetStream();
                    }
                    catch
                    {
                        MessageBox.Show("连接服务器失败！");
                    }
                }
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
        //红外控制
        public static void IRControl(ControlData tmpControlData)
        {
            if (tmpControlData.VideoGuid!= null)
            {
                DeviceData data = new DeviceData();
                data.tmpControlData = tmpControlData;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/IR," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                if (!CommunicationClass.tcp2.Connected)
                {
                    CommunicationClass.tcp2 = new TcpClient();
                    string DCServer_IP = ConfigurationManager.AppSettings["DCServer_IP"];
                    int DCServer_Port = int.Parse(ConfigurationManager.AppSettings["DCServer_Port"]);
                    try
                    {
                        CommunicationClass.tcp2.Connect(DCServer_IP, DCServer_Port);
                        CommunicationClass.stream2 = CommunicationClass.tcp2.GetStream();
                    }
                    catch
                    {
                        MessageBox.Show("连接服务器失败！");
                    }
                }
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        ////添加预置位
        //public static TurntablePresetData PresetAddControl(TurntablePresetData tmpAddPreset)
        //{
        //    TurntablePresetData tmp_AddPreset = new TurntablePresetData();
        //    if(tmpAddPreset.PresetName !=null && tmpAddPreset.VideoGuid !=null)
        //    {
        //        DeviceData data = new DeviceData();
        //        data.tmpTurntablePresetData = tmpAddPreset;
        //        string str = JsonConvert.SerializeObject(data);
        //        string message = "EquipmentControl/PresetAdd," + str + "\r\n";
        //        byte[] b = Encoding.UTF8.GetBytes(message);
        //        CommunicationClass.stream2.Write(b, 0, b.Length);
        //    }
        //    return tmp_AddPreset;
        //}
        //获取所有预置位
        //public static List<PresetList> PresetGetControl(Guid? VideoDeviceGuid)
        //{
        //    List<PresetList> tmp_PresetList = new List<PresetList>();
        //    if (VideoDeviceGuid != null)
        //    {
        //        DeviceData data = new DeviceData();
        //        data.tmp_Guid = VideoDeviceGuid.Value;
        //        string str = JsonConvert.SerializeObject(data);
        //        string message = "EquipmentControl/PresetGet," + str + "\r\n";
        //        byte[] b = Encoding.UTF8.GetBytes(message);
        //        CommunicationClass.stream2.Write(b, 0, b.Length);

        //        string responseData = String.Empty;
        //        b = new Byte[1024 * 100];

        //        Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
        //        responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
        //        DeviceData deviceData = new DeviceData();
        //        deviceData = JsonConvert.DeserializeObject<DeviceData>(responseData);
        //        tmp_PresetList = deviceData.tmpPresetList;
        //    }
        //    return tmp_PresetList;
        //}
        ////删除某个预置位
        //public static void PresetDelControl(TurntablePresetData tmpPresetData)
        //{
        //    if (tmpPresetData.PresetGuid != null)
        //    {
        //        DeviceData data = new DeviceData();
        //        data.tmpTurntablePresetData = tmpPresetData;
        //        string str = JsonConvert.SerializeObject(data);
        //        string message = "EquipmentControl/PresetDel," + str + "\r\n";
        //        byte[] b = Encoding.UTF8.GetBytes(message);
        //        CommunicationClass.stream2.Write(b, 0, b.Length);
        //    }
        //}
        //调用预置位
        public static void PresetSetControl(TurntablePresetData tmpPresetData)
        {
            if (tmpPresetData.PresetGuid != null)
            {
                DeviceData data = new DeviceData();
                data.tmpTurntablePresetData = tmpPresetData;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/PresetSet," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                if (!CommunicationClass.tcp2.Connected)
                {
                    CommunicationClass.tcp2 = new TcpClient();
                    string DCServer_IP = ConfigurationManager.AppSettings["DCServer_IP"];
                    int DCServer_Port = int.Parse(ConfigurationManager.AppSettings["DCServer_Port"]);
                    try
                    {
                        CommunicationClass.tcp2.Connect(DCServer_IP, DCServer_Port);
                        CommunicationClass.stream2 = CommunicationClass.tcp2.GetStream();
                    }
                    catch
                    {
                        MessageBox.Show("连接服务器失败！");
                    }
                }
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
        //开启扇扫
        public static void SectorScanOpenControl(SectorScanData tmpSectorScanData)
        {
            if (tmpSectorScanData.VideoGuid != null)
            {
                DeviceData data = new DeviceData();
                data.tmpSectorScanData = tmpSectorScanData;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/SectorScanOpen," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                if (!CommunicationClass.tcp2.Connected)
                {
                    CommunicationClass.tcp2 = new TcpClient();
                    string DCServer_IP = ConfigurationManager.AppSettings["DCServer_IP"];
                    int DCServer_Port = int.Parse(ConfigurationManager.AppSettings["DCServer_Port"]);
                    try
                    {
                        CommunicationClass.tcp2.Connect(DCServer_IP, DCServer_Port);
                        CommunicationClass.stream2 = CommunicationClass.tcp2.GetStream();
                    }
                    catch
                    {
                        MessageBox.Show("连接服务器失败！");
                    }
                }
                CommunicationClass.stream2.Write(b, 0, b.Length);

            }
        }
        //关闭扇扫
        public static void SectorScanOffControl(Guid? tmpGuid)
        {
            if(tmpGuid != null)
            {
                DeviceData data = new DeviceData();
                data.tmp_Guid = tmpGuid;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/SectorScanOff," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                if (!CommunicationClass.tcp2.Connected)
                {
                    CommunicationClass.tcp2 = new TcpClient();
                    string DCServer_IP = ConfigurationManager.AppSettings["DCServer_IP"];
                    int DCServer_Port = int.Parse(ConfigurationManager.AppSettings["DCServer_Port"]);
                    try
                    {
                        CommunicationClass.tcp2.Connect(DCServer_IP, DCServer_Port);
                        CommunicationClass.stream2 = CommunicationClass.tcp2.GetStream();
                    }
                    catch
                    {
                        MessageBox.Show("连接服务器失败！");
                    }
                }
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
    }
}
