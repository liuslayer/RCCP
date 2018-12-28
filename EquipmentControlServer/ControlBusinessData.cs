using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer
{
    public class ControlBusinessData
    {
        static TurnTableListRepository tmpTurnTableList = new TurnTableListRepository();
        static List<TurnTableList> _TurnTableList = new List<TurnTableList>();
        static Dictionary<string, TurnTableList> StaticDataOfTurntable_Dictionary = new Dictionary<string, TurnTableList>();

        static List<CameraList> _CameraList = new List<CameraList>();
        static CameraListRepository tmpCameraList = new CameraListRepository();
        public static Dictionary<string, CameraList> CameraList_Dictionary = new Dictionary<string, CameraList>();

        static List<StreamMediaList> _StreamMediaList = new List<StreamMediaList>();
        static StreamMediaListRepository tmpStreamMediaList = new StreamMediaListRepository();
        static Dictionary<string, StreamMediaList> StreamMediaList_Dictionary = new Dictionary<string, StreamMediaList>();

        static List<UPSList> _UPSList = new List<UPSList>();
        static UPSListRepository tmpUPSList = new UPSListRepository();
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<Guid, DynamicDataOfTurntable> DynamicDataOfTurntable_Dictionary = new Dictionary<Guid, DynamicDataOfTurntable>();
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<Guid, DynamicDataOfUps3onedata> DynamicDataOfUps3onedata_Dictionary = new Dictionary<Guid, DynamicDataOfUps3onedata>();

        public static void Init()
        {
            StaticDataOfTurntableInit();
            StreamMediaListInit();
            CameraListInit();
            TurntableDynamicDataInit();
            Ups3onedataInit();
        }

        /// <summary>
        /// 初始化UPS信息数据
        /// </summary>
        public static void Ups3onedataInit()
        {
            _UPSList = tmpUPSList.GetList();
            for (int i = 0; i < _UPSList.Count; i++)
            {
                DynamicDataOfUps3onedata tmp = new DynamicDataOfUps3onedata();
                tmp.UpsGuid = _UPSList[i].DeviceID;
                tmp.UpsName = _UPSList[i].Name;
                tmp.CommunicationType = _UPSList[i].CommunicationType;/**协议类型*/
                tmp.CommunicationID = _UPSList[i].CommunicationID;/**通信ID*/
                DynamicDataOfUps3onedata_Dictionary.Add(_UPSList[i].DeviceID, tmp);
            }
        }
        /// <summary>
        /// 初始化转台动态基本数据
        /// </summary>
        public static void TurntableDynamicDataInit()
        {
            _TurnTableList = tmpTurnTableList.GetList();
            _CameraList = tmpCameraList.GetList();
            DynamicDataOfTurntable tmp = new DynamicDataOfTurntable();
            for (int i = 0; i < _TurnTableList.Count; i++)
            {
                tmp.GuidDeviceID = _TurnTableList[i].DeviceID;
                tmp.ProtocolType = _TurnTableList[i].ProtocolType;
                tmp.CommunicationID = _TurnTableList[i].CommunicationID;/**通信ID*/
                //for (int j = 0; j < _CameraList.Count; j++)
                //{
                //    if(_CameraList[j].Turntable_PTZ_DeviceID == _TurnTableList[i].DeviceID)
                //    {
                //        tmp.CameraDeviceID = _CameraList[j].DeviceID;
                //    }
                //}
                DynamicDataOfTurntable_Dictionary.Add(_TurnTableList[i].DeviceID, tmp);
            }
        }
        /// <summary>
        /// 初始化转台动态数据字典
        /// </summary>
        public static void StaticDataOfTurntableInit()
        {
            _TurnTableList = tmpTurnTableList.GetList();
            if (_TurnTableList.Count > 0)
            {
                for (int i = 0; i < _TurnTableList.Count; i++)
                {
                    StaticDataOfTurntable_Dictionary.Add(_TurnTableList[i].DeviceID.ToString(), _TurnTableList[i]);
                }
            }
        }
        /// <summary>
        /// 初始化流媒体静态字典
        /// </summary>
        public static void StreamMediaListInit()
        {
            _StreamMediaList = tmpStreamMediaList.GetList();
            if (_StreamMediaList.Count > 0)
            {
                for(int i = 0; i < _StreamMediaList.Count; i++)
                {
                    StreamMediaList_Dictionary.Add(_StreamMediaList[i].DeviceID.ToString(), _StreamMediaList[i]);
                }
            }
        }
        /// <summary>
        /// 初始化摄像机静态字典
        /// </summary>
        public static void CameraListInit()
        {
            _CameraList = tmpCameraList.GetList();
            if (_CameraList.Count > 0)
            {
                for (int i = 0; i < _CameraList.Count; i++)
                {
                    CameraList_Dictionary.Add(_CameraList[i].DeviceID.ToString(), _CameraList[i]);
                }
            }
        }
        /// <summary>
        /// 获取摄像机类型
        /// </summary>
        /// <param name="tmpCaneraGuid"></param>
        /// <returns></returns>
        public static int GetCameraVideoType(Guid? tmpCaneraGuid)
        {
            int VideoType = 0;
            if(CameraList_Dictionary.ContainsKey(tmpCaneraGuid.ToString()))
            {
                string strVideoType = CameraList_Dictionary[tmpCaneraGuid.ToString()].VideoType;
                VideoType = Convert.ToInt32(strVideoType);
            }
            return VideoType;
        }

        /// <summary>
        /// 获取转台的静态信息
        /// </summary>
        /// <param name="VGuid"></param>
        /// <returns></returns>
        public static StaticDataOfTurntable GetStaticDataOfTurntable(Guid? VGuid)
        {
            StaticDataOfTurntable tmpStaticDataOfTurntable = new StaticDataOfTurntable();
            tmpStaticDataOfTurntable.GuidDeviceID = null;
            foreach (CameraList mc in CameraList_Dictionary.Values)
            {
                if (mc.DeviceID == VGuid)
                {
                    tmpStaticDataOfTurntable.GuidDeviceID = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].DeviceID;
                    tmpStaticDataOfTurntable.Name = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].Name;/**转台名称*/
                    tmpStaticDataOfTurntable.CommunicationType = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].CommunicationType;/**通信类型*/
                    tmpStaticDataOfTurntable.CommunicationID = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].CommunicationID;/**通信ID*/
                    tmpStaticDataOfTurntable.StationId = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].StationID;
                    tmpStaticDataOfTurntable.TypeId = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].TypeID;
                    tmpStaticDataOfTurntable.Lon = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].Lon;/**经度*/
                    tmpStaticDataOfTurntable.Lat = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].Lat;/**纬度*/
                    tmpStaticDataOfTurntable.Alt = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].Alt;/**海拔*/
                    tmpStaticDataOfTurntable.ErectingHeightType = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].ErectingHeightType;/**架设高度类型*/
                    tmpStaticDataOfTurntable.ErectingHeight = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].ErectingHeight;/**架设高度*/
                    tmpStaticDataOfTurntable.AzimuthAngle = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].AzimuthAngle;/**偏北角*/
                    tmpStaticDataOfTurntable.ProtocolType = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].ProtocolType;/**协议类型*/
                    tmpStaticDataOfTurntable.TurntableAddr = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].TurntableAddr;/**转台协议地址*/
                    tmpStaticDataOfTurntable.CCDAddr = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].CCDAddr;/**白光协议地址*/
                    tmpStaticDataOfTurntable.IRAddr = StaticDataOfTurntable_Dictionary[mc.Turntable_PTZ_DeviceID.ToString()].IRAddr;/**红外协议地址*/
                    break;
                }
            }
            return tmpStaticDataOfTurntable;
        }
        /// <summary>
        /// 保存UPS数据-3旺的UPS数据
        /// </summary>
        /// <param name="CommunicationID"></param>
        /// <param name="INVOLTAGE"></param>
        /// <param name="LVOLTAGE"></param>
        /// <param name="OUTVOLTAGE"></param>
        /// <param name="LOAD"></param>
        /// <param name="FREQ"></param>
        /// <param name="CELLVOLTAGE"></param>
        /// <param name="TEMP"></param>
        /// <param name="m_ALARM1"></param>
        /// <param name="m_ALARM2"></param>
        /// <param name="m_ALARM3"></param>
        /// <param name="m_ALARM4"></param>
        /// <param name="m_ALARM5"></param>
        /// <param name="m_ALARM6"></param>
        /// <param name="m_ALARM7"></param>
        /// <param name="m_ALARM8"></param>
        public void Preservation_UPS3onedata(Guid CommunicationID, double INVOLTAGE, double LVOLTAGE, double OUTVOLTAGE, double LOAD, double FREQ, double CELLVOLTAGE, double TEMP,
            string m_ALARM1,string m_ALARM2,string m_ALARM3,string m_ALARM4,string m_ALARM5,string m_ALARM6,string m_ALARM7,string m_ALARM8)
        {
            foreach (DynamicDataOfUps3onedata mc in DynamicDataOfUps3onedata_Dictionary.Values)
            {
                if (mc.CommunicationID == CommunicationID)
                {
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].INVOLTAGE=INVOLTAGE;
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].LVOLTAGE=LVOLTAGE;
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].OUTVOLTAGE=OUTVOLTAGE;
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].LOAD=LOAD;
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].FREQ=FREQ;
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].CELLVOLTAGE=CELLVOLTAGE;
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].TEMP = TEMP;
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].m_ALARM1 = m_ALARM1;
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].m_ALARM2 = m_ALARM2;
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].m_ALARM3 = m_ALARM3;
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].m_ALARM4 = m_ALARM4;
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].m_ALARM5 = m_ALARM5;
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].m_ALARM6 = m_ALARM6;
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].m_ALARM7 = m_ALARM7;
                    DynamicDataOfUps3onedata_Dictionary[mc.UpsGuid].m_ALARM8 = m_ALARM8;
                    break;
                }
            }
        }
        /// <summary>
        /// 保存转台动态信息
        /// </summary>
        /// <param name="CommunicationID"></param>
        /// <param name="Horizontal"></param>
        /// <param name="HorizontalData"></param>
        /// <param name="Vertical"></param>
        /// <param name="VerticalData"></param>
        /// <param name="CCD_Depth"></param>
        /// <param name="CCD_DepthData"></param>
        /// <param name="CCD_Focus"></param>
        /// <param name="CCD_FocusData"></param>
        /// <param name="IR_Depth"></param>
        /// <param name="IR_DepthData"></param>
        /// <param name="IR_Focus"></param>
        /// <param name="IR_FocusData"></param>
        public void Preservation_All(Guid CommunicationID, double Horizontal, int HorizontalData, double Vertical, int VerticalData,
            int CCD_Depth, int CCD_DepthData, int CCD_Focus, int CCD_FocusData, int IR_Depth, int IR_DepthData, int IR_Focus, int IR_FocusData)
        {
            foreach (DynamicDataOfTurntable mc in DynamicDataOfTurntable_Dictionary.Values)
            {
                if (mc.CommunicationID == CommunicationID)
                {
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].Horizontal = Horizontal;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].Horizontal_Data = HorizontalData;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].Vertical = Vertical;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].Vertical_Data = VerticalData;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].CCD_Depth = CCD_Depth;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].CCD_Depth_Data = CCD_DepthData;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].CCD_Focus = CCD_Focus;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].CCD_Focus_Data = CCD_FocusData;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].IR_Depth = IR_Depth;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].IR_Depth_Data = IR_DepthData;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].IR_Focus = IR_Focus;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].IR_Focus_Data = IR_FocusData;
                    break;
                }
            }
        }
        /// <summary>
        /// 保存转台水平动态信息
        /// </summary>
        /// <param name="CommunicationID"></param>
        /// <param name="Horizontal"></param>
        /// <param name="HorizontalData"></param>
        public void Preservation_Horizontal(Guid CommunicationID, double Horizontal,int HorizontalData)
        {
            foreach (DynamicDataOfTurntable mc in DynamicDataOfTurntable_Dictionary.Values)
            {
                if (mc.CommunicationID == CommunicationID)
                {
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].Horizontal = Horizontal;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].Horizontal_Data = HorizontalData;
                    break;
                }
            }
        }
        /// <summary>
        /// 保存转台俯仰信息
        /// </summary>
        /// <param name="CommunicationID"></param>
        /// <param name="Vertical"></param>
        /// <param name="VerticalData"></param>
        public void Preservation_Vertical(Guid CommunicationID, double Vertical, int VerticalData)
        {
            foreach (DynamicDataOfTurntable mc in DynamicDataOfTurntable_Dictionary.Values)
            {
                if (mc.CommunicationID == CommunicationID)
                {
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].Vertical = Vertical;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].Vertical_Data = VerticalData;
                    break;
                }
            }
        }
        /// <summary>
        /// 保存转台白光视场信息
        /// </summary>
        /// <param name="CommunicationID"></param>
        /// <param name="CCD_Depth"></param>
        /// <param name="CCD_DepthData"></param>
        public void Preservation_CCDDepth(Guid CommunicationID, int CCD_Depth, int CCD_DepthData)
        {
            foreach (DynamicDataOfTurntable mc in DynamicDataOfTurntable_Dictionary.Values)
            {
                if (mc.CommunicationID == CommunicationID)
                {
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].CCD_Depth = CCD_Depth;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].CCD_Depth_Data = CCD_DepthData;
                    break;
                }
            }
        }
        /// <summary>
        /// 保存转台白光聚焦信息
        /// </summary>
        /// <param name="CommunicationID"></param>
        /// <param name="CCD_Focus"></param>
        /// <param name="CCD_FocusData"></param>
        public void Preservation_CCDFocus(Guid CommunicationID, int CCD_Focus, int CCD_FocusData)
        {
            foreach (DynamicDataOfTurntable mc in DynamicDataOfTurntable_Dictionary.Values)
            {
                if (mc.CommunicationID == CommunicationID)
                {
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].CCD_Focus = CCD_Focus;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].CCD_Focus_Data = CCD_FocusData;
                    break;
                }
            }
        }
        /// <summary>
        /// 保存转台红外视场信息
        /// </summary>
        /// <param name="CommunicationID"></param>
        /// <param name="IR_Depth"></param>
        /// <param name="IR_DepthData"></param>
        public void Preservation_IRDepth(Guid CommunicationID, int IR_Depth, int IR_DepthData)
        {
            foreach (DynamicDataOfTurntable mc in DynamicDataOfTurntable_Dictionary.Values)
            {
                if (mc.CommunicationID == CommunicationID)
                {
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].IR_Depth = IR_Depth;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].IR_Depth_Data = IR_DepthData;
                    break;
                }
            }
        }
        /// <summary>
        /// 保存转台红外聚焦信息
        /// </summary>
        /// <param name="CommunicationID"></param>
        /// <param name="IR_Focus"></param>
        /// <param name="IR_FocusData"></param>
        public void Preservation_IRFocus(Guid CommunicationID, int IR_Focus, int IR_FocusData)
        {
            foreach (DynamicDataOfTurntable mc in DynamicDataOfTurntable_Dictionary.Values)
            {
                if (mc.CommunicationID == CommunicationID)
                {
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].IR_Focus = IR_Focus;
                    DynamicDataOfTurntable_Dictionary[mc.GuidDeviceID].IR_Focus_Data = IR_FocusData;
                    break;
                }
            }
        }

        /// <summary>
        /// 获取UPS数据
        /// </summary>
        /// <returns></returns>
        public static List<DynamicDataOfUps3onedata> GetUpsData()
        {
            List<DynamicDataOfUps3onedata> tmpGetUpsData = new List<DynamicDataOfUps3onedata>();
            foreach (DynamicDataOfUps3onedata mc in DynamicDataOfUps3onedata_Dictionary.Values)
            {
                DynamicDataOfUps3onedata tmp = new DynamicDataOfUps3onedata();
                tmp = mc;
                tmpGetUpsData.Add(tmp);
            }
            return tmpGetUpsData;
        }
        /// <summary>
        /// 获取转台方位俯仰及关联的摄像机镜头状态。
        /// </summary>
        /// <param name="VideoGuid"></param>
        /// <returns></returns>
        public static TurntableStateData GetTurntableState(Guid? VideoGuid)
        {
            TurntableStateData tmpTurntableStateData = new TurntableStateData();
            if(CameraList_Dictionary.ContainsKey(VideoGuid.ToString()))
            {
                int VideoType = GetCameraVideoType(VideoGuid);
                Guid? tmpTurntableGuid = CameraList_Dictionary[VideoGuid.ToString()].Turntable_PTZ_DeviceID;
                if (tmpTurntableGuid != null)
                {
                    if (VideoType == (int)VideoCommandType.VideoCCD || VideoType == (int)VideoCommandType.VideoPTZ)
                    {
                        tmpTurntableStateData.VideoGuid = VideoGuid;
                        //tmpTurntableStateData.UserGuid;
                        tmpTurntableStateData.iHorizontalData = DynamicDataOfTurntable_Dictionary[tmpTurntableGuid.Value].Horizontal;
                        tmpTurntableStateData.iVerticalData = DynamicDataOfTurntable_Dictionary[tmpTurntableGuid.Value].Vertical;
                        tmpTurntableStateData.iDepth = DynamicDataOfTurntable_Dictionary[tmpTurntableGuid.Value].CCD_Depth;
                        tmpTurntableStateData.iFocus = DynamicDataOfTurntable_Dictionary[tmpTurntableGuid.Value].CCD_Focus;
                    }
                    else
                    {
                        tmpTurntableStateData.VideoGuid = VideoGuid;
                        //tmpTurntableStateData.UserGuid;
                        tmpTurntableStateData.iHorizontalData = DynamicDataOfTurntable_Dictionary[tmpTurntableGuid.Value].Horizontal;
                        tmpTurntableStateData.iVerticalData = DynamicDataOfTurntable_Dictionary[tmpTurntableGuid.Value].Vertical;
                        tmpTurntableStateData.iDepth = DynamicDataOfTurntable_Dictionary[tmpTurntableGuid.Value].IR_Depth;
                        tmpTurntableStateData.iFocus = DynamicDataOfTurntable_Dictionary[tmpTurntableGuid.Value].IR_Focus;
                    }
                }
            }
            return tmpTurntableStateData;
        }

        public string[] GetDeviceIPandChannel(Guid VGuid)
        {
            string[] tmpIPandChannel = new string[2];
            //foreach()
            //{
            //}
            return tmpIPandChannel;
        }
    }
}
