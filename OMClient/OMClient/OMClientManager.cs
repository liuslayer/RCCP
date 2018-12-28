using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMClient
{
    public class OMClientManager
    {
        public static MyNodeStatus myNodeStatus;
        public static DeviceInfo deviceInfo;
        public static List<CameraStatusList> cameraStatusList = new List<CameraStatusList>();
        public static List<UPSStatusList> UPSStatusList = new List<UPSStatusList>();
        public static List<SolarEnergyStatusList> solarEnergyStatusList = new List<SolarEnergyStatusList>();
        public static Dictionary<Guid, int> stationStatusDic = new Dictionary<Guid, int>();
        public static List<AlarmLog> alarmLogList = new List<AlarmLog>();
        public static List<RunLog> runLogList = new List<RunLog>();
        public static List<ErrLog> errLogList = new List<ErrLog>();

        private readonly object cameraStatusLockObj = new object();
        private readonly object UPSStatusLockObj = new object();
        private readonly object solarEnergyStatusLockObj = new object();
        private readonly object stationStatusLockObj = new object();

        /// <summary>
        /// 更新内存中摄像机状态信息
        /// </summary>
        /// <param name="newCameraStatusList"></param>
        public void UpdateCameraStatus(List<CameraStatusList> newCameraStatusList)
        {
            lock (cameraStatusLockObj)
            {
                cameraStatusList = newCameraStatusList.Union(cameraStatusList, new CameraStatusListEquality()).ToList();
            }
        }

        /// <summary>
        /// 更新内存中UPS状态信息
        /// </summary>
        /// <param name="newUPSStatusList"></param>
        public void UpdateUPSStatus(List<UPSStatusList> newUPSStatusList)
        {
            lock (UPSStatusLockObj)
            {
                UPSStatusList = newUPSStatusList.Union(UPSStatusList, new UPSStatusListEquality()).ToList();
            }
        }

        /// <summary>
        /// 更新内存中太阳能状态信息
        /// </summary>
        /// <param name="newSolarEnergyStatusList"></param>
        public void UpdateSolarEnergyStatus(List<SolarEnergyStatusList> newSolarEnergyStatusList)
        {
            lock (solarEnergyStatusLockObj)
            {
                solarEnergyStatusList = newSolarEnergyStatusList.Union(solarEnergyStatusList, new SolarEnergyStatusListEquality()).ToList();
            }
        }

        /// <summary>
        /// 更新内存中监控站状态信息
        /// </summary>
        /// <param name="stationStatusDic"></param>
        public void UpdateStationStatus(Dictionary<Guid, int> newStationStatusDic)
        {
            lock (stationStatusLockObj)
            {
                foreach (var item in newStationStatusDic)
                {
                    stationStatusDic[item.Key] = item.Value;
                }
            }
        }
    }

    public class CameraStatusListEquality : IEqualityComparer<CameraStatusList>
    {
        public bool Equals(CameraStatusList x, CameraStatusList y)
        {
            return x.DeviceID == y.DeviceID;
        }

        public int GetHashCode(CameraStatusList obj)
        {
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.ToString().GetHashCode();
            }
        }
    }

    public class UPSStatusListEquality : IEqualityComparer<UPSStatusList>
    {
        public bool Equals(UPSStatusList x, UPSStatusList y)
        {
            return x.DeviceID == y.DeviceID;
        }

        public int GetHashCode(UPSStatusList obj)
        {
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.ToString().GetHashCode();
            }
        }
    }

    public class SolarEnergyStatusListEquality : IEqualityComparer<SolarEnergyStatusList>
    {
        public bool Equals(SolarEnergyStatusList x, SolarEnergyStatusList y)
        {
            return x.DeviceID == y.DeviceID;
        }

        public int GetHashCode(SolarEnergyStatusList obj)
        {
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.ToString().GetHashCode();
            }
        }
    }
}
