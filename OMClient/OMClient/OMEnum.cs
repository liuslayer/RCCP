using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OMClient
{
    public enum OMCommand
    {
        Connected = 1,
        GetDeviceInfo,
        GetDeviceStatus,
        DeviceInfo,
        CameraStatusInfo,
        UPSStatusInfo,
        SolarEnergyStatusInfo,
        StationStatusInfo
    }

    public enum DeviceParamType
    {
        /// <summary>
        /// 流媒体
        /// </summary>
        StreamMediaDevice = 1,
        /// <summary>
        /// NVR
        /// </summary>
        NVRDevice,
        /// <summary>
        /// DVR
        /// </summary>
        DVRDevice,
        /// <summary>
        /// 摄像机
        /// </summary>
        CameraDevice,
        /// <summary>
        /// 串口
        /// </summary>
        SerialCOMDevice,
        /// <summary>
        /// 太阳能电站
        /// </summary>
        SolarEnergyDevice,
        /// <summary>
        /// 转台or云台        
        /// </summary>
        TurnTableDevice,
        /// <summary>
        /// UPS电源
        /// </summary>
        UPSDevice,
        /// <summary>
        /// 监控站
        /// </summary>
        Station,
        /// <summary>
        /// 流媒体开关量
        /// </summary>
        DVRorNVRSwitchDevice
    }

    public enum VideoCommandType
    {
        /// <summary>
        /// 白光
        /// </summary>
        VideoCCD = 101,
        /// <summary>
        /// 红外
        /// </summary>
        VideoIR,
        /// <summary>
        /// 球机
        /// </summary>
        VideoPTZ
    }

    //0表示无，1表示有遮挡报警，2表示有移动目标报警，3表示画面异常报警，4表示其他
    public enum CameraAlarmType
    {
        无 = 0,
        遮挡报警,
        移动目标报警,
        画面异常报警,
        其他
    }
    //0表示未知，1表示未录像，2表示录像中
    public enum RecordStatusType
    {
        未知 = 0,
        未录像,
        录像中
    }
    //0表示未知，1表示正常，2表示信号丢失
    public enum SignalStatusType
    {
        未知 = 0,
        正常,
        信号丢失
    }
    //0表示未知，1表示正常，2表示异常
    public enum HardwareStatusType
    {
        未知 = 0,
        正常,
        异常
    }

    public enum SolarEnergyAlarmType
    {
        无 = 0,
        过压,
        欠压
    }

    public enum StationStatus
    {
        未知 = 0,
        开机,
        关机,
        工作,
        故障
    }
    /// <summary>
    /// 报警类别：0未知，1视频，2雷达，3震动光缆，4微波墙
    /// </summary>
    public enum AlarmType
    {
        未知 = 0,
        视频,
        雷达,
        震动光缆,
        微波墙
    }
    /// <summary>
    /// 报警状态:1报警触发、2报警处置、3报警未处置、4报警结束
    /// </summary>
    public enum AlarmStatus
    {
        未知 = 0,
        报警触发,
        报警处置,
        报警未处置,
        报警结束
    }
    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperationType
    {
        后台系统 = 1,
        客户端 = 2
    }
    /// <summary>
    /// 异常类型
    /// </summary>
    public enum ErrLogType
    {
        内部异常 = 1,
        网络异常 = 2,
        报警异常 = 3,
        数据库异常
    }
}
