using ExternalDataCentreService;
using System;
using System.Collections.Generic;

namespace TurntableControlInterface
{
    public class InterfaceControl
    {
        static Control_Command tmpControl = new Control_Command();
        static ControlData tmpCommand = new ControlData();
        static SectorScanData tmpSectorScanData = new SectorScanData();
        public static void HDControl(Guid? tmpGuid, int tmpAction, int tmpSpeed, int tmpParameter, Guid? UserGuid)
        {
            if (tmpGuid != null)
            {
                tmpCommand.VideoGuid = tmpGuid;
                tmpCommand.iAction = tmpAction;
                tmpCommand.iSpeed = tmpSpeed;
                tmpCommand.Parameter = tmpParameter;
                tmpCommand.UserGuid = UserGuid;
                Control_Command.HDControl(tmpCommand);
            }
            
        }
        public static void SectorScanOpen(Guid? tmpGuid, int i_HorizontalSt, int i_HorizontalEnd, int i_Hspeed,int i_VerticalSt,int i_VerticalEnd, int i_Vspeed)
        {
            if(tmpGuid !=null)
            {
                tmpSectorScanData.VideoGuid = tmpGuid;
                tmpSectorScanData.i_HorizontalSt = i_HorizontalSt;
                tmpSectorScanData.i_HorizontalEnd = i_HorizontalEnd;
                tmpSectorScanData.i_Hspeed = i_Hspeed;
                tmpSectorScanData.i_VerticalSt = i_VerticalSt;
                tmpSectorScanData.i_VerticalEnd = i_VerticalEnd;
                tmpSectorScanData.i_Vspeed = i_Vspeed;
                Control_Command.SectorScanOpenControl(tmpSectorScanData);
            }
        }
        public static void SectorScanOff(Guid? tmpGuid)
        {
            if(tmpGuid != null)
            {
                Control_Command.SectorScanOffControl(tmpGuid);
            }
        }
        public static void CCDControl(Guid? tmpGuid, int tmpAction, int tmpSpeed, int tmpParameter, Guid? UserGuid)
        {
            if (tmpGuid != null)
            {
                tmpCommand.VideoGuid = tmpGuid;
                tmpCommand.iAction = tmpAction;
                tmpCommand.iSpeed = tmpSpeed;
                tmpCommand.Parameter = tmpParameter;
                tmpCommand.UserGuid = UserGuid;
                Control_Command.CCDControl(tmpCommand);
            }
            
        }
        public static void IRControl(Guid? tmpGuid, int tmpAction, int tmpSpeed, int tmpParameter, Guid? UserGuid)
        {
            if(tmpGuid != null)
            {
                tmpCommand.VideoGuid = tmpGuid;
                tmpCommand.iAction = tmpAction;
                tmpCommand.iSpeed = tmpSpeed;
                tmpCommand.Parameter = tmpParameter;
                tmpCommand.UserGuid = UserGuid;
                Control_Command.IRControl(tmpCommand);
            }
        }

        //public static List<PresetList> GetPreset(Guid? VideoDeviceGuid)
        //{
        //    List<PresetList> tmpPresetList = new List<PresetList>();
        //    if (VideoDeviceGuid !=null)
        //    {
        //        //List<PresetList> PresetGetControl
        //        tmpPresetList = Control_Command.PresetGetControl(VideoDeviceGuid);
        //    }
        //    return tmpPresetList;
        //}
        //public static void DelPreset(TurntablePresetData tmpPresetData)
        //{
        //    if(tmpPresetData.PresetGuid != null)
        //    {
        //        Control_Command.PresetDelControl(tmpPresetData);
        //    }
        //}
        public static void SetPreset(TurntablePresetData tmpPresetData)
        {
            if (tmpPresetData.PresetGuid != null)
            {
                Control_Command.PresetSetControl(tmpPresetData);
            }
        }
    }
}
