using System.Collections.Generic;

namespace Client
{
    public class DeviceDataClass
    {
        //public static List<CameraList> cameraList;
        //public static List<StreamMediaList> streamMediaList;
        //public static List<StreamServerList> streamServerList;
        public static bool Init()
        {
            try
            {
                ////获取数据库的所有设备信息，登录设备
                //CameraListRepository camera = new CameraListRepository();
                //cameraList = camera.GetList();
                //StreamMediaListRepository streamMedia = new StreamMediaListRepository();
                //streamMediaList = streamMedia.GetList();
                //StreamServerListRepository streamServer = new StreamServerListRepository();
                //streamServerList = streamServer.GetList();
                return true;
            }
            catch { return false; }
        }
    }
}
