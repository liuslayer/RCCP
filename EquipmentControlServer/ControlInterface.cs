using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using RCCP.Repository.Entities.DynamicEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EquipmentControlServer
{
    public class ControlInterface
    {
        /// <summary>
        /// 转台静态数据
        /// </summary>
        static public Dictionary<Guid, StaticDataOfTurntable> Dictionary_StaticDataT = new Dictionary<Guid, StaticDataOfTurntable>();

        static public Dictionary<string, CameraListRepository> Dictionary_CamerList = new Dictionary<string, CameraListRepository>();

        static StaticDataOfTurntable tmp;
        public static List<TurnTableList> cameraList;
        static LensProtectionBusiness tmpLensProtectionBusiness = null;

        public static void Init()
        {
            ControlBusinessData.Init();//初始化转台/云台基本数据
            SerialCOMInit.SerialCOMEquipmentInit();//初始化串口设备
            //CHCNetSDKInterface.HK_EquipmentInit(); //初始化HK网络设备
            ////////////自动获取UPS数据///////////////////
            UPSDataInterface();
            IRProtect();
        }

        /// <summary>
        /// UPS数据接口
        /// </summary>
        public static void UPSDataInterface()
        {
            UPSData_AutomaticAcquisition.DataInit();
            UPSData_AutomaticAcquisition.seviceInfo();
            UPSData_AutomaticAcquisition.ThreadOpen();
        }
        /// <summary>
        /// 红外保护
        /// </summary>
        public static void IRProtect()
        {
            if (tmpLensProtectionBusiness == null)
            {
                tmpLensProtectionBusiness = new LensProtectionBusiness();
                tmpLensProtectionBusiness.seviceInfo();
                tmpLensProtectionBusiness.ThreadOpen();
            }
            else
            {
                tmpLensProtectionBusiness.ThreadStop();
                Thread.Sleep(50);
                tmpLensProtectionBusiness = null;
                Thread.Sleep(100);
                tmpLensProtectionBusiness = new LensProtectionBusiness();
                Thread.Sleep(100);
                tmpLensProtectionBusiness.seviceInfo();
                tmpLensProtectionBusiness.ThreadOpen();
            }

        }
        /// <summary>
        /// 转台控制
        /// </summary>
        /// <param name="tmp_ControlData"></param>
        public static void HDControlInterface(ControlData tmp_ControlData)
        {
            ProtocolBusinessLogic.SetHDControl_Business(tmp_ControlData);
        }
        /// <summary>
        /// 白光控制
        /// </summary>
        /// <param name="tmp_ControlData"></param>
        public static void CCDControlInterface(ControlData tmp_ControlData)
        {
            ProtocolBusinessLogic.SetCCDControl_Business(tmp_ControlData);
        }
        /// <summary>
        /// 红外控制
        /// </summary>
        /// <param name="tmp_ControlData"></param>
        public static void IRControlInterface(ControlData tmp_ControlData)
        {
            ProtocolBusinessLogic.SetIRControl_Business(tmp_ControlData);
        }
        /// <summary>
        /// 预置位添加
        /// </summary>
        /// <param name="tmp_TurntablePresetData"></param>
        public static void PresetAddInterface(TurntablePresetData tmp_TurntablePresetData)
        {
            PresetData.AddrPreset(tmp_TurntablePresetData);
        }
        /// <summary>
        /// 预置位修改
        /// </summary>
        /// <param name="tmp_TurntablePresetData"></param>
        public static void PresetUpdateInterface(TurntablePresetData tmp_TurntablePresetData)
        {
            PresetData.UpdatePreset(tmp_TurntablePresetData);
        }
        /// <summary>
        /// 预置位获取数据库
        /// </summary>
        /// <param name="VideoGuid"></param>
        /// <returns></returns>
        public static List<TurntablePresetData> PresetGetInterface(Guid? VideoGuid)
        {
            List<TurntablePresetData> tmpPresetList = PresetData.GetPreset(VideoGuid);
            return tmpPresetList;
        }
        /// <summary>
        /// 预置位删除
        /// </summary>
        /// <param name="tmp_TurntablePresetData"></param>
        public static void PresetDelInterface(TurntablePresetData tmp_TurntablePresetData)
        {
            PresetData.DelPreset(tmp_TurntablePresetData);
        }
        /// <summary>
        /// 预置位调用
        /// </summary>
        /// <param name="tmp_TurntablePresetData"></param>
        public static void PresetSetInterface(TurntablePresetData tmp_TurntablePresetData)
        {
            PresetData.SetPreset(tmp_TurntablePresetData);
        }
        /// <summary>
        /// 报警联动预置位
        /// </summary>
        /// <param name="VideoGuid"></param>
        /// <param name="PresetName"></param>
        /// <param name="UserGuid"></param>
        public static void PresetAlarmSetInterface(Guid VideoGuid, string PresetName, Guid? UserGuid)
        {
            TurntablePresetData tmp_TurntablePresetData = new TurntablePresetData();
            tmp_TurntablePresetData.VideoGuid = VideoGuid;
            tmp_TurntablePresetData.PresetName = PresetName;
            PresetData.SetPreset(tmp_TurntablePresetData);
        }
        /// <summary>
        /// 扇扫 开
        /// </summary>
        /// <param name="tmpSectorScanData"></param>
        public static void SectorScanOpen(SectorScanData tmpSectorScanData)
        {
            ProtocolBusinessLogic.SectorScanControlOpen_Business(tmpSectorScanData);
        }
        /// <summary>
        /// 扇扫 关
        /// </summary>
        /// <param name="tmpSectorScanData"></param>
        public static void SectorScanOff(SectorScanData tmpSectorScanData)
        {
            ProtocolBusinessLogic.SectorScanControlOff_Business(tmpSectorScanData);
        }

        public static TurntableStateData GetTurntableStateData(Guid? VideoGuid)
        {
            TurntableStateData tmpTurntableStateData = new TurntableStateData();
            tmpTurntableStateData = ControlBusinessData.GetTurntableState(VideoGuid);
            return tmpTurntableStateData;
        }

        public static string SuperiorGetTurntableStateData(Guid? VideoGuid)
        {
            string tmpData;
            TurntableStateData tmpTurntableStateData = new TurntableStateData();
            tmpTurntableStateData = ControlBusinessData.GetTurntableState(VideoGuid);
            tmpData = tmpTurntableStateData.VideoGuid.ToString() + "," + tmpTurntableStateData.iHorizontalData.ToString()+","+
                tmpTurntableStateData.iVerticalData.ToString()+","+ tmpTurntableStateData.iDepth+","+ tmpTurntableStateData.iFocus.ToString();
            return tmpData;
        }

        /// <summary>
        /// UPS信息
        /// </summary>
        /// <returns></returns>
        public static List<DynamicDataOfUps3onedata> UpsGet()
        {
            List<DynamicDataOfUps3onedata> tmpUpsData = ControlBusinessData.GetUpsData();
            return tmpUpsData;
        }
    }
}
