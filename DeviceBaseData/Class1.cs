using Client.Entities;
using Client.Entities.DeviceEntity;
using Client.Entities.UserEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceBaseData
{
    public class Class1
    {
        public static List<CameraList> cameraList;
        public static List<StreamMediaList> streamMediaList;
        public static List<StreamServerList> streamServerList;
        public static List<StationList> stationList;
        public static bool IsDone;
        public static LoginUserInfomation loginUserInfomation;//存储登录成功的用户信息
        public void Init()
        {
            //从服务器获取设备基础数据
            string message = "GetDeviceStaticData\r\n";
            Byte[] data = Encoding.ASCII.GetBytes(message);
            if (CommunicationClass.stream2 == null) return;
            CommunicationClass.stream2.Write(data, 0, data.Length); 

            string responseData = String.Empty;
            
            data = new Byte[1024*100];
            while (true)
            {
                Int64 bytes = CommunicationClass.stream2.Read(data, 0, data.Length);

                responseData += Encoding.UTF8.GetString(data, 0, (int)bytes);
                DeviceData deviceData = JsonConvert.DeserializeObject<DeviceData>(responseData);
                cameraList = deviceData.cameraList;
                streamMediaList = deviceData.streamMediaList;
                streamServerList = deviceData.streamServerList;
                stationList = deviceData.stationList;
                IsDone = true;
                break;
            }
        }
    }
    public class DeviceData
    {
        public List<CameraList> cameraList;
        public List<StreamMediaList> streamMediaList;
        public List<StreamServerList> streamServerList;
        public List<StationList> stationList;
    }
}
