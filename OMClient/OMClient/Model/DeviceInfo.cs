using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OMClient
{
    //运维查询对象,单例
    public class DeviceInfo
    {
        //饿汉式单例
        //private static readonly QueryOMInfo queryOMInfo = new QueryOMInfo();

        //public static QueryOMInfo GetInstance()
        //{
        //    return queryOMInfo;
        //}

        private static DeviceInfo deviceInfo;
        private static object _lock = new object();

        //双重锁
        public static DeviceInfo GetInstance()
        {
            if (deviceInfo == null)
            {
                lock (_lock)
                {
                    if (deviceInfo == null)
                    {
                        deviceInfo = new DeviceInfo();
                    }
                }
            }
            return deviceInfo;
        }
        //私有构造方法，客户端不能通过new新建对象
        private DeviceInfo()
        {
            //TODO:初始化设备数据，从数据库中读取设备数据
            //StationInfos = new StationRepository().GetList();
        }

        /// <summary>
        /// 监控站信息
        /// </summary>
        public List<StationList> StationList { get; set; }

        /// <summary>
        /// 转台设备信息
        /// </summary>
        public List<TurnTableList> TurnTableList { get; set; }
        /// <summary>
        /// 流媒体设备信息
        /// </summary>
        public List<StreamMediaList> StreamMediaList { get; set; }
        /// <summary>
        /// 摄像头设备信息
        /// </summary>
        public List<CameraList> CameraList { get; set; }
        /// <summary>
        /// 太阳能设备信息
        /// </summary>
        public List<SolarEnergyList> SolarEnergyList { get; set; }
        /// <summary>
        /// UPS设备信息
        /// </summary>
        public List<UPSList> UPSList { get; set; }
        /// <summary>
        /// 串口设备信息
        /// </summary>
        public List<SerialCOMList> SerialCOMList { get; set; }
        /// <summary>
        /// 设备类型列表
        /// </summary>
        public List<DeviceTypeList> DeviceTypeList { get; set; }
    }
}
