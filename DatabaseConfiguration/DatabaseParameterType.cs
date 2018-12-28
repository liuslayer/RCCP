using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DatabaseConfiguration
{
    public class DataBaseParameterType : EventArgs
    {
        //public readonly DeviceParamType deviceParamType;
        //public DataBaseParameterType(DeviceParamType deviceParamType)
        //{
        //    this.deviceParamType = deviceParamType;
        //}
        
    }
    public enum HeightMeasurementType
    {
        /// <summary>
        /// 用户测量
        /// </summary>
        UserMeasurement=1,
        /// <summary>
        /// 北斗测量
        /// </summary>
        BeiDouMeasurement
    }

    public enum CommunicationMode
    {
        /// <summary>
        /// 无
        /// </summary>
        NoneType,
        /// <summary>
        /// 串口通信
        /// </summary>
        ComType=1,
        /// <summary>
        /// 网络通信
        /// </summary>
        NetworkType,
        /// <summary>
        /// 透明通道
        /// </summary>
        TransparentChannelType,
        /// <summary>
        /// 海康SDK
        /// </summary>
        HKSDKType


    }
    public enum DeviceParamType
    {
        /// <summary>
        /// 流媒体
        /// </summary>
        StreamMediaDevice=1,
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
        DVRorNVRSwitchDevice,
        /// <summary>
        /// 计算机
        /// </summary>
        ComputerDevice,
        /// <summary>
        /// 雷达
        /// </summary>
        RadarDevice,
        /// <summary>
        /// 服务器
        /// </summary>
        ServerDevice,
        /// <summary>
        /// 报警系统
        /// </summary>
        VibrationCableDevice

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
    //校验位:0 None parity(无)、1 Odd parity(奇)、2 Even parity(偶)、3 Mark parity(标志)、4 Space parity(空格)
    public enum ComCheckBit
    {
        /// <summary>
        /// (无)
        /// </summary>
        NoneParity,
        /// <summary>
        /// (奇)
        /// </summary>
        OddParity,
        /// <summary>
        /// (偶)
        /// </summary>
        EvenParity,
        /// <summary>
        /// (标志)
        /// </summary>
        MarkParity,
        /// <summary>
        /// (空格)
        /// </summary>
        SpaceParity
    }
    //停止位：0 None、1 One、2 Two、3 OnePointFive
    public enum ComStopBit
    {
        /// <summary>
        /// 
        /// </summary>
        None,
        /// <summary>
        /// 
        /// </summary>
        One,
        /// <summary>
        /// 
        /// </summary>
        Two,
        /// <summary>
        /// 
        /// </summary>
        OnePointFive
    }
}
