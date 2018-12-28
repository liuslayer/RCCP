using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer
{
    /// <summary>
    /// 转台静态信息
    /// </summary>
    public struct StaticDataOfTurntable
    {
        public Guid? GuidDeviceID;
        public string Name;/**转台名称*/
        public int CommunicationType;/**通信类型*/
        public Guid? CommunicationID;/**通信ID*/
        public Guid? StationId;
        public int TypeId;
        public double? Lon;/**经度*/
        public double? Lat;/**纬度*/
        public double Alt;/**海拔*/
        public double ErectingHeightType;/**架设高度类型*/
        public double ErectingHeight;/**架设高度*/
        public double AzimuthAngle;/**偏北角*/
        public int ProtocolType;/**协议类型*/
        public int TurntableAddr;/**转台协议地址*/
        public int CCDAddr;/**白光协议地址*/
        public int IRAddr;/**红外协议地址*/
    }
    /// <summary>
    /// 转台动态信息
    /// </summary>
    public class DynamicDataOfTurntable
    {
        public Guid GuidDeviceID;
        public int ProtocolType;/**协议类型*/
        public Guid? CommunicationID;/**通信ID*/
        public double Horizontal;/**水平*/
        public double Vertical;/**俯仰*/
        public int CCD_Depth;/**白光变倍*/
        public int CCD_Focus;/**白光聚焦*/
        public int CCD_Temp;/**白光温度*/
        public int IR_Depth;/**红外变倍*/
        public int IR_Focus;/**红外聚焦*/
        public int IR_Temp;/**红外温度*/
        public int Horizontal_Data;/**水平-原始数据*/
        public int Vertical_Data;/**俯仰-原始数据*/
        public int CCD_Depth_Data;/**白光变倍-原始数据*/
        public int CCD_Focus_Data;/**白光聚焦-原始数据*/
        public int IR_Depth_Data;/**红外变倍-原始数据*/
        public int IR_Focus_Data;/**红外聚焦-原始数据*/

    }

    public class DynamicDataOfUps3onedata
    {
        public Guid UpsGuid;
        public string UpsName;
        public int CommunicationType;/**协议类型*/
        public Guid? CommunicationID;/**通信ID*/
        public double INVOLTAGE;
        public double LVOLTAGE;
        public double OUTVOLTAGE;
        public double LOAD;
        public double FREQ;
        public double CELLVOLTAGE;
        public double TEMP;
        public string m_ALARM1;
        public string m_ALARM2;
        public string m_ALARM3;
        public string m_ALARM4;
        public string m_ALARM5;
        public string m_ALARM6;
        public string m_ALARM7;
        public string m_ALARM8;
    }
    /// <summary>
    /// 转台预置位信息
    /// </summary>
    public struct TurntablePreset
    {
        /// <summary>
        /// 摄像机ID
        /// </summary>
        public Guid CameraDeviceID;
        /// <summary>
        /// 预置位名字
        /// </summary>
        public string PresetName;
        /// <summary>
        /// 预置位类型
        /// </summary>
        public string PresetType;
        /// <summary>
        /// 预置位编号
        /// </summary>
        public string PresetNo;
        /// <summary>
        /// 水平-原始数据
        /// </summary>
        public int Horizontal_Data;
        /// <summary>
        /// 俯仰-原始数据
        /// </summary>
        public int Vertical_Data;
        /// <summary>
        /// 白光或红外变倍-原始数据
        /// </summary>
        public int CCDorIR_Depth;
        /// <summary>
        /// 白光或红外聚焦-原始数据
        /// </summary>
        public int CCDorIR_Focus;
        /// <summary>
        /// 转台协议地址
        /// </summary>
        public int TurntableAddr;
        /// <summary>
        /// 白光协议地址
        /// </summary>
        public int CCDAddr;
        /// <summary>
        /// 红外协议地址
        /// </summary>
        public int IRAddr;
    }
    public class TurntableData
    {
    }
}
