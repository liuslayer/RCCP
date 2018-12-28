using Client.Entities;
using Client.Entities.ControlEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurntableControlInterface
{
    public class InterfaceControl
    {
        public static void HDControl(Guid? tmpGuid, int tmpAction, int tmpSpeed, int tmpParameter, Guid? UserGuid)
        {
            ControlData tmpCommand = new ControlData();
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
            SectorScanData tmpSectorScanData = new SectorScanData();
            if (tmpGuid !=null)
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
            ControlData tmpCommand = new ControlData();
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
        public static void ResetIRProtect()
        {
            Control_Command.ResetIRProtect();
        }

        public static void IRControl(Guid? tmpGuid, int tmpAction, int tmpSpeed, int tmpParameter, Guid? UserGuid)
        {
            ControlData tmpCommand = new ControlData();
            if (tmpGuid != null)
            {
                tmpCommand.VideoGuid = tmpGuid;
                tmpCommand.iAction = tmpAction;
                tmpCommand.iSpeed = tmpSpeed;
                tmpCommand.Parameter = tmpParameter;
                tmpCommand.UserGuid = UserGuid;
                Control_Command.IRControl(tmpCommand);
            }
        }

        public static List<DynamicDataOfUps3onedata> GetUpsData()
        {
            List<DynamicDataOfUps3onedata> tmpUpsData = new List<DynamicDataOfUps3onedata>();
            tmpUpsData = Control_Command.UpsDataGetControl();
            return tmpUpsData;
        }

        public static List<TurntablePresetData> GetPreset(Guid? VideoDeviceGuid)
        {
            List<TurntablePresetData> tmpPresetList = new List<TurntablePresetData>();
            if (VideoDeviceGuid !=null)
            {
                //List<PresetList> PresetGetControl
                tmpPresetList = Control_Command.PresetGetControl(VideoDeviceGuid);
            }
            return tmpPresetList;
        }
        public static void DelPreset(TurntablePresetData tmpPresetData)
        {
            if(tmpPresetData!= null)
            {
                Control_Command.PresetDelControl(tmpPresetData);
            }
        }
        public static void SetPreset(TurntablePresetData tmpPresetData)
        {
            if (tmpPresetData != null)
            {
                Control_Command.PresetSetControl(tmpPresetData);
            }
        }

        public static void UpdatePrese(TurntablePresetData tmpPresetData)
        {
            if(tmpPresetData != null)
            {
                Control_Command.PresetUpdateControl(tmpPresetData);
            }
        }
    }
}
