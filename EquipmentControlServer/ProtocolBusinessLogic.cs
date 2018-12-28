using EquipmentControlServer.ProtocolData;
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
    public class ProtocolBusinessLogic
    {
        static StaticDataOfTurntable tmp_StaticDataT;
        static LensProtectionBusiness tmpLensProtectionBusiness =null;

        /// <summary>
        /// 转台控制
        /// </summary>
        /// <param name="GuidDeviceID"></param>
        /// <param name="iAction"></param>
        /// <param name="iSpeed"></param>
        /// <param name="iValue"></param>
        /// <returns></returns>
        public static string SetHDControl_Business(ControlData tmp_ControlData)
        {
            string strHDControlState = "";
            tmp_StaticDataT = new StaticDataOfTurntable();
            tmp_StaticDataT = ControlBusinessData.GetStaticDataOfTurntable(tmp_ControlData.VideoGuid);
            if(tmp_StaticDataT.GuidDeviceID !=null)
            { SetTurntable(tmp_StaticDataT, tmp_ControlData.iAction, tmp_ControlData.iSpeed, tmp_ControlData.Parameter); } 
            return strHDControlState;
        }

        /// <summary>
        /// 白光控制
        /// </summary>
        /// <param name="tmp_ControlData"></param>
        /// <returns></returns>
        public static string SetCCDControl_Business(ControlData tmp_ControlData)
        {
            string strCCDControlState = "";
            tmp_StaticDataT = new StaticDataOfTurntable();
            tmp_StaticDataT = ControlBusinessData.GetStaticDataOfTurntable(tmp_ControlData.VideoGuid);
            if (tmp_StaticDataT.GuidDeviceID != null)
            { SetCCD(tmp_StaticDataT, tmp_ControlData.iAction, tmp_ControlData.iSpeed, tmp_ControlData.Parameter); } 
            return strCCDControlState;
        }
        /// <summary>
        /// 红外控制
        /// </summary>
        /// <param name="tmp_ControlData"></param>
        /// <returns></returns>
        public static string SetIRControl_Business(ControlData tmp_ControlData)
        {
            string strIRControlState = "";
            tmp_StaticDataT = new StaticDataOfTurntable();
            tmp_StaticDataT = ControlBusinessData.GetStaticDataOfTurntable(tmp_ControlData.VideoGuid);
            if (tmp_StaticDataT.GuidDeviceID != null)
            { SetIR(tmp_StaticDataT, tmp_ControlData.iAction, tmp_ControlData.iSpeed, tmp_ControlData.Parameter); } 
            return strIRControlState;
        }

        /// <summary>
        /// 调用预置位
        /// </summary>
        /// <param name="tmp_StaticData"></param>
        /// <param name="tmpPresetData"></param>
        public static void SetPreset_Business(StaticDataOfTurntable tmp_StaticData, PresetList tmpPresetData)
        {
            if (tmp_StaticData.GuidDeviceID != null)
            {
                SetPreset(tmp_StaticData, tmpPresetData);
            }
        }

        /// <summary>
        /// 扇扫开启
        /// </summary>
        /// <param name="tmpSectorScanData"></param>
        /// <returns></returns>
        public static string SectorScanControlOpen_Business(SectorScanData tmpSectorScanData)
        {
            string strSectorScanControl = "";
            tmp_StaticDataT = new StaticDataOfTurntable();
            tmp_StaticDataT = ControlBusinessData.GetStaticDataOfTurntable(tmpSectorScanData.VideoGuid);
            if (tmp_StaticDataT.GuidDeviceID != null)
            {
                SectorScanControlOpen(tmp_StaticDataT, tmpSectorScanData.i_HorizontalSt, tmpSectorScanData.i_HorizontalEnd, tmpSectorScanData.i_Hspeed,
                    tmpSectorScanData.i_VerticalSt, tmpSectorScanData.i_VerticalEnd, tmpSectorScanData.i_Vspeed);
            }
            return strSectorScanControl;
        }

        /// <summary>
        /// 扇扫结束
        /// </summary>
        /// <param name="tmpSectorScanData"></param>
        /// <returns></returns>
        public static string SectorScanControlOff_Business(SectorScanData tmpSectorScanData)
        {
            string strSectorScanControl = "";
            tmp_StaticDataT = new StaticDataOfTurntable();
            tmp_StaticDataT = ControlBusinessData.GetStaticDataOfTurntable(tmpSectorScanData.VideoGuid);
            if (tmp_StaticDataT.GuidDeviceID != null)
            {
                SectorScanControlOff(tmp_StaticDataT);
            }
            return strSectorScanControl;
        }

        /// <summary>
        /// 红外保护
        /// </summary>
        public static void All_LensProtection_Business()
        {
            All_LensProtection();
        }

        static void SectorScanControlOpen(StaticDataOfTurntable tmpStaticData, int i_HorizontalSt, int i_HorizontalEnd, int i_Hspeed,
            int i_VerticalSt,int i_VerticalEnd,int i_Vspeed)
        {
            string strTurntableState = "";
            if (tmpStaticData.ProtocolType.ToString() == "-1") { strTurntableState = "该设备控制信息有误,需检查控制信息"; }
            switch (tmpStaticData.ProtocolType)
            {
                case (int)ControlProtocolType.GS209_RY:/** 209sRY*/
                    { Protocol209sRY_Business.SetSanScan_Open(tmpStaticData.TurntableAddr, i_HorizontalSt, i_HorizontalSt, i_Hspeed, i_VerticalSt, i_VerticalEnd, i_Vspeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS209_SR:/** 209sSR*/
                    { Protocol209sSR_Business.SetSanScan_Open(tmpStaticData.TurntableAddr, i_HorizontalSt, i_HorizontalSt, i_Hspeed, i_VerticalSt, i_VerticalEnd, i_Vspeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                        break;
                case (int)ControlProtocolType.GS209_PT100:/** 209sPT100*/
                    { Protocol209sPT100_Business.SetSanScan_Open(tmpStaticData.TurntableAddr,i_HorizontalSt,i_HorizontalSt,i_Hspeed,i_VerticalSt,i_VerticalEnd,i_Vspeed,tmpStaticData.CommunicationID,tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS368_BJ:/** 368s*/
                    { Protocol368s_Business.SetSanScan_Open(tmpStaticData.TurntableAddr, i_HorizontalSt, i_HorizontalSt, i_Hspeed, i_VerticalSt, i_VerticalEnd, i_Vspeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS508_Ali:/** 508s*/
                    //{ Protocol508s_Business.SetSanScan_Open(tmpStaticData.TurntableAddr, i_HorizontalSt, i_HorizontalSt, i_Hspeed, i_VerticalSt, i_VerticalEnd, i_Vspeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS11s:/** 11s*/
                    //{ Protocol11s_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_GPL:/** 高普乐*/
                    //{ Protocol209sSR_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());}
                    break;
                case (int)ControlProtocolType.GS5308_OP3:/** OP3*/
                    //{ ProtocolOP3_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS211_OT11:/** OT11*/
                    //{ Protocol211_OT11_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_PelcoD:/** PelcoD*/
                    //{ ProtocolPelcoD_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_PelcoP:/** PelcoP*/
                    //{ Protocol209sSR_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
            }
        }

        static void SectorScanControlOff(StaticDataOfTurntable tmpStaticData)
        {
            string strTurntableState = "";
            if (tmpStaticData.ProtocolType.ToString() == "-1") { strTurntableState = "该设备控制信息有误,需检查控制信息"; }
            switch (tmpStaticData.ProtocolType)
            {
                case (int)ControlProtocolType.GS209_RY:/** 209sRY*/
                    { Protocol209sRY_Business.SetSanScan_Off(tmpStaticData.TurntableAddr, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS209_SR:/** 209sSR*/
                    { Protocol209sSR_Business.SetSanScan_Off(tmpStaticData.TurntableAddr, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS209_PT100:/** 209sPT100*/
                    { Protocol209sPT100_Business.SetSanScan_Off(tmpStaticData.TurntableAddr, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS368_BJ:/** 368s*/
                    { Protocol368s_Business.SetSanScan_Off(tmpStaticData.TurntableAddr, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS508_Ali:/** 508s*/
                    //{ Protocol508s_Business.SetSanScan_Open(tmpStaticData.TurntableAddr, i_HorizontalSt, i_HorizontalSt, i_Hspeed, i_VerticalSt, i_VerticalEnd, i_Vspeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS11s:/** 11s*/
                    //{ Protocol11s_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_GPL:/** 高普乐*/
                    //{ Protocol209sSR_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());}
                    break;
                case (int)ControlProtocolType.GS5308_OP3:/** OP3*/
                    //{ ProtocolOP3_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS211_OT11:/** OT11*/
                    //{ Protocol211_OT11_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_PelcoD:/** PelcoD*/
                    //{ ProtocolPelcoD_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_PelcoP:/** PelcoP*/
                    //{ Protocol209sSR_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
            }
        }

        /// <summary>
        /// 转台控制
        /// </summary>
        /// <param name="iDeviceID">转台ID</param>
        /// <param name="iAction">控制类型</param>
        /// <param name="iSpeed">速度</param>
        /// <param name="iValue">值</param>
        /// <returns></returns>
        static string SetTurntable(StaticDataOfTurntable tmpStaticData, int iAction, int iSpeed,int iValue)
        {
            string strTurntableState = "";
            if (tmpStaticData.ProtocolType.ToString() == "-1") { strTurntableState = "该设备控制信息有误,需检查控制信息"; }

            switch (tmpStaticData.ProtocolType)
            {
                case (int)ControlProtocolType.GS209_RY:/** 209sRY*/
                    { Protocol209sRY_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());}
                    break;
                case (int)ControlProtocolType.GS209_SR:/** 209sSR*/
                    { Protocol209sSR_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS209_PT100:/** 209sPT100*/
                    { Protocol209sPT100_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString(),iValue); }
                    break;
                case (int)ControlProtocolType.GS368_BJ:/** 368s*/
                    { Protocol368s_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS508_Ali:/** 508s*/
                    //{ Protocol508s_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());}
                    break;
                case (int)ControlProtocolType.GS11s:/** 11s*/
                    { Protocol11s_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_GPL:/** 高普乐*/
                    //{ Protocol209sSR_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());}
                    break;
                case (int)ControlProtocolType.GS5308_OP3:/** OP3*/
                    { ProtocolOP3_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());}
                    break;
                case (int)ControlProtocolType.GS211_OT11:/** OT11*/
                    { Protocol211_OT11_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_PelcoD:/** PelcoD*/
                    { ProtocolPelcoD_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_PelcoP:/** PelcoP*/
                    { Protocol209sSR_Business.SetTurntable(iAction, tmpStaticData.TurntableAddr.ToString(), iSpeed, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
            }
            return strTurntableState;
        }
        /// <summary>
        /// 白光控制
        /// </summary>
        /// <param name="tmpStaticData"></param>
        /// <param name="iAction"></param>
        /// <param name="iSpeed"></param>
        /// <param name="iValue"></param>
        /// <returns></returns>
        static string SetCCD(StaticDataOfTurntable tmpStaticData, int iAction, int iSpeed, int iValue)
        {
            string strCDDState = "";
            if (tmpStaticData.ProtocolType.ToString() == "-1") { strCDDState = "该设备控制信息有误,需检查控制信息"; }
            switch (tmpStaticData.ProtocolType)
            {
                case (int)ControlProtocolType.GS209_RY:/** 209sRY*/
                    { Protocol209sRY_Business.SetCCD(iAction, tmpStaticData.CCDAddr.ToString(), iSpeed, iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS209_SR:/** 209sSR*/
                    { Protocol209sSR_Business.SetCCD(iAction, tmpStaticData.CCDAddr.ToString(), iSpeed, iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS209_PT100:/** 209sPT100*/
                    { Protocol209sPT100_Business.SetCCD(iAction, tmpStaticData.CCDAddr.ToString(), iSpeed, iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS368_BJ:/** 368s*/
                    { Protocol368s_Business.SetCCD(iAction, tmpStaticData.CCDAddr.ToString(), iSpeed, iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS508_Ali:/** 508s*/
                    //{ Protocol508s_Business.SetCCD(iAction, strCCDAddr, iSpeed, strCommunicationID, strCommunicationType); }
                    break;
                case (int)ControlProtocolType.GS11s:/** 11s*/
                    { Protocol11s_Business.SetCCD(iAction, tmpStaticData.CCDAddr.ToString(), iSpeed, iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_GPL:/** 高普乐*/
                    //{ Protocol209sSR_Business.SetCCD(iAction, tmpStaticData.CCDAddr.ToString(), iSpeed, iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS5308_OP3:/** OP3*/
                    { ProtocolOP3_Business.SetCCD(iAction, tmpStaticData.CCDAddr.ToString(), iSpeed, iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS211_OT11:/** OT11*/
                    { Protocol211_OT11_Business.SetCCD(iAction, tmpStaticData.CCDAddr.ToString(), iSpeed, iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_PelcoD:/** PelcoD*/
                    { ProtocolPelcoD_Business.SetCCD(iAction, tmpStaticData.CCDAddr.ToString(), iSpeed, iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_PelcoP:/** PelcoP*/
                    { Protocol209sSR_Business.SetCCD(iAction, tmpStaticData.CCDAddr.ToString(), iSpeed, iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
            }
            return strCDDState;
        }
        /// <summary>
        /// 红外控制
        /// </summary>
        /// <param name="tmpStaticData"></param>
        /// <param name="iAction"></param>
        /// <param name="iSpeed"></param>
        /// <param name="iValue"></param>
        /// <returns></returns>
        static string SetIR(StaticDataOfTurntable tmpStaticData, int iAction, int iSpeed, int iValue)
        {
            string strIRState = "";
            if (tmpStaticData.ProtocolType.ToString() == "-1") { strIRState = "该设备控制信息有误,需检查控制信息"; }
            switch (tmpStaticData.ProtocolType)
            {
                case (int)ControlProtocolType.GS209_RY:/** 209sRY*/
                    { Protocol209sRY_Business.SetIR(iAction, tmpStaticData.IRAddr.ToString(), iSpeed,iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS209_SR:/** 209sSR*/
                    { Protocol209sSR_Business.SetIR(iAction, tmpStaticData.IRAddr.ToString(), iSpeed,iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS209_PT100:/** 209sPT100*/
                    { Protocol209sPT100_Business.SetIR(iAction, tmpStaticData.IRAddr.ToString(), iSpeed,iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS368_BJ:/** 368s*/
                    { Protocol368s_Business.SetIR(iAction, tmpStaticData.IRAddr.ToString(), iSpeed,iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS508_Ali:/** 508s*/
                    //{ Protocol508s_Business.SetIR(iAction, tmpStaticData.IRAddr.ToString(), iSpeed,iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS11s:/** 11s*/
                    { Protocol11s_Business.SetIR(iAction, tmpStaticData.IRAddr.ToString(), iSpeed,iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_GPL:/** 高普乐*/
                    //{ Protocol209sSR_Business.SetIR(iAction, tmpStaticData.IRAddr.ToString(), iSpeed,iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS5308_OP3:/** OP3*/
                    { ProtocolOP3_Business.SetIR(iAction, tmpStaticData.IRAddr.ToString(), iSpeed,iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.GS211_OT11:/** OT11*/
                    { Protocol211_OT11_Business.SetIR(iAction, tmpStaticData.IRAddr.ToString(), iSpeed,iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_PelcoD:/** PelcoD*/
                    { ProtocolPelcoD_Business.SetIR(iAction, tmpStaticData.IRAddr.ToString(), iSpeed,iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
                case (int)ControlProtocolType.CIVIL_PelcoP:/** PelcoP*/
                    { Protocol209sSR_Business.SetIR(iAction, tmpStaticData.IRAddr.ToString(), iSpeed,iValue, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString()); }
                    break;
            }
            return strIRState;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strPresetName"></param>
        /// <returns></returns>
        //static string AddPreset(string strPresetName)
        //{
        //    string strPresetState = "";

        //    return strPresetState;
        //}
        /// <summary>
        /// 调用预置位
        /// </summary>
        /// <param name="tmpStaticData"></param>
        /// <param name="tmpPresetData"></param>
        /// <returns></returns>
        static string SetPreset(StaticDataOfTurntable tmpStaticData, PresetList tmpPresetData)
        {
            string strPresetState = "";
            switch (tmpStaticData.ProtocolType)
            {
                /// 209所
                case (int)ControlProtocolType.GS209_RY:
                    {
                        Protocol209sRY_Business.SetPresetTurntable(tmpStaticData.TurntableAddr.ToString(),
                            Convert.ToInt32(tmpPresetData.Horizontal_Data), Convert.ToInt32(tmpPresetData.Vertical_Data),
                            tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());
                        Thread.Sleep(50);
                        Protocol209sRY_Business.SetPresetCCD(tmpStaticData.CCDAddr.ToString(),
                            Convert.ToInt32(tmpPresetData.CCDorIR_Depth),Convert.ToInt32(tmpPresetData.CCDorIR_Focus),
                            tmpStaticData.CommunicationID,tmpStaticData.CommunicationType.ToString());
                    }
                    break;
                /// 209所-神戎
                case (int)ControlProtocolType.GS209_SR:
                    {
                        Protocol209sSR_Business.SetPresetTurntable(tmpStaticData.TurntableAddr.ToString(),
                            Convert.ToInt32(tmpPresetData.Horizontal_Data), Convert.ToInt32(tmpPresetData.Vertical_Data),
                            tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());
                        Thread.Sleep(50);
                        Protocol209sSR_Business.SetPresetCCD(tmpStaticData.CCDAddr.ToString(),
                            Convert.ToInt32(tmpPresetData.CCDorIR_Depth), Convert.ToInt32(tmpPresetData.CCDorIR_Focus),
                            tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());
                    }
                    break;
                /// 209所—PT100
                case (int)ControlProtocolType.GS209_PT100:
                    {
                        Protocol209sPT100_Business.SetPresetTurntable(tmpStaticData.TurntableAddr.ToString(),
                            Convert.ToInt32(tmpPresetData.Horizontal_Data), Convert.ToInt32(tmpPresetData.Vertical_Data),
                            tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());
                        Thread.Sleep(50);
                        Protocol209sPT100_Business.SetPresetCCD(tmpStaticData.CCDAddr.ToString(),
                            Convert.ToInt32(tmpPresetData.CCDorIR_Depth), Convert.ToInt32(tmpPresetData.CCDorIR_Focus),
                            tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());
                    }
                    break;
                /// 368所-白家
                case (int)ControlProtocolType.GS368_BJ:
                    {
                        Protocol368s_Business.SetPresetTurntable(tmpStaticData.TurntableAddr.ToString(),
                            Convert.ToInt32(tmpPresetData.Horizontal_Data), Convert.ToInt32(tmpPresetData.Vertical_Data),
                            tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());
                        Thread.Sleep(50);
                        Protocol368s_Business.SetPresetCCD(tmpStaticData.CCDAddr.ToString(),
                            Convert.ToInt32(tmpPresetData.CCDorIR_Depth), Convert.ToInt32(tmpPresetData.CCDorIR_Focus),
                            tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());
                    }
                    break;
                /// 368所-吉达 神戎
                case (int)ControlProtocolType.GS368_JDSR:
                    break;
                /// 368所-吉达 大力
                case (int)ControlProtocolType.GS368_JDDL:
                    break;
                /// 508-阿里
                case (int)ControlProtocolType.GS508_Ali:
                    break;
                /// 11所
                case (int)ControlProtocolType.GS11s:
                    break;
                /// 5308所-OP3
                case (int)ControlProtocolType.GS5308_OP3:
                    break;
                /// 211所-OT11
                case (int)ControlProtocolType.GS211_OT11:
                    break;
                /// 民用-高普乐
                case (int)ControlProtocolType.CIVIL_GPL:
                    break;
                /// 民用-PelcoD通用
                case (int)ControlProtocolType.CIVIL_PelcoD:
                    {
                        ProtocolPelcoD_Business.SetPreset(tmpStaticData.TurntableAddr.ToString(),
                            tmpPresetData.PresetNo, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());
                    }
                    break;
                /// 民用-PelcoP通用
                case (int)ControlProtocolType.CIVIL_PelcoP:
                    break;
            }
            return strPresetState;
        }

        /// <summary>
        /// 设置预置位
        /// </summary>
        /// <param name="tmpStaticData"></param>
        /// <param name="tmpPresetData"></param>
        /// <returns></returns>
        static string GetPreset(StaticDataOfTurntable tmpStaticData, PresetList tmpPresetData)
        {
            string strPresetState ="";
            switch (tmpStaticData.ProtocolType)
            {
                case (int)ControlProtocolType.CIVIL_PelcoD:
                    {
                        ProtocolPelcoD_Business.GetPreset(tmpStaticData.TurntableAddr.ToString(),
                            tmpPresetData.PresetNo, tmpStaticData.CommunicationID, tmpStaticData.CommunicationType.ToString());
                    }
                    break;
                case (int)ControlProtocolType.CIVIL_PelcoP:
                    {

                    }
                    break;
            }
            return strPresetState;
        }
        static string AddPreset_Business(Guid GuidDeviceID, string iDeviceID1)
        {
            string strAddPresetState = "";
            return strAddPresetState;
        }
        static string SetPreset_Business(Guid GuidDeviceID)//, string strPresetName)
        {
            string strSetPresetState = "";
            tmp_StaticDataT = new StaticDataOfTurntable();
            TurntablePreset tmp_Preset = new TurntablePreset();
            if (ControlInterface.Dictionary_StaticDataT.ContainsKey(GuidDeviceID))
            {
                tmp_StaticDataT.ProtocolType = ControlInterface.Dictionary_StaticDataT[GuidDeviceID].ProtocolType;
                tmp_StaticDataT.TurntableAddr = ControlInterface.Dictionary_StaticDataT[GuidDeviceID].TurntableAddr;
                tmp_StaticDataT.CCDAddr = ControlInterface.Dictionary_StaticDataT[GuidDeviceID].CCDAddr;
                tmp_StaticDataT.IRAddr = ControlInterface.Dictionary_StaticDataT[GuidDeviceID].IRAddr;
                tmp_StaticDataT.CommunicationID = ControlInterface.Dictionary_StaticDataT[GuidDeviceID].CommunicationID;
                tmp_StaticDataT.CommunicationType = ControlInterface.Dictionary_StaticDataT[GuidDeviceID].CommunicationType;
            }

            return strSetPresetState;
        }
        static string DelPreset_Business(string iDeviceID, string strPresetName)
        {
            string strDelPresetState = "";
            return strDelPresetState;
        }
        static void All_LensProtection()
        {
            string StartUpType;
            if (tmpLensProtectionBusiness != null)
            {
                tmpLensProtectionBusiness.ThreadStop();
                tmpLensProtectionBusiness = null;
                Thread.Sleep(2000);
                tmpLensProtectionBusiness = new LensProtectionBusiness();
                StartUpType = tmpLensProtectionBusiness.seviceInfo();
                if(StartUpType == "1")
                {
                    tmpLensProtectionBusiness.ThreadOpen();
                }
                else
                {
                    tmpLensProtectionBusiness = null;
                }
                
            }
            else
            {
                tmpLensProtectionBusiness = new LensProtectionBusiness();
                StartUpType = tmpLensProtectionBusiness.seviceInfo();
                if (StartUpType == "1")
                {
                    tmpLensProtectionBusiness.ThreadOpen();
                }
                else
                {
                    tmpLensProtectionBusiness = null;
                }
            }
        }
    }
}
