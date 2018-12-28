using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer
{
     public class PresetData
    {
        static StaticDataOfTurntable tmp_StaticDataT;
        /// <summary>
        /// 获取预置位
        /// </summary>
        /// <param name="tmp_TurntablePresetData"></param>
        /// <returns></returns>
        public static List<TurntablePresetData> GetPreset(Guid? VideoGuid)//,string[] strPresetName)
        {
            List<TurntablePresetData> tmpGetPreset = new List<TurntablePresetData>();
            PresetListRepository tmpPresetListRepository = new PresetListRepository();
            List<PresetList> tmp_PresetList = tmpPresetListRepository.GetList();
            if (tmp_PresetList.Count > 0 && VideoGuid != null)
            {
                for (int i = 0; i < tmp_PresetList.Count; i++)
                {
                    if(tmp_PresetList[i].CameraDeviceID == VideoGuid)
                    {
                        TurntablePresetData tmp = new TurntablePresetData();
                        tmp.VideoGuid = tmp_PresetList[i].CameraDeviceID;
                        tmp.PresetGuid = tmp_PresetList[i].PresetID;
                        tmp.PresetName = tmp_PresetList[i].PresetName;
                        tmpGetPreset.Add(tmp);
                    }
                }
            }
            else if(VideoGuid!=null)
            {
                TurntablePresetData tmp = new TurntablePresetData();
                tmp.VideoGuid = VideoGuid;
                tmp.PresetGuid = null;
                tmp.PresetName = "";
                tmp.AlarmType = -1;
                tmpGetPreset.Add(tmp);
            }
            return tmpGetPreset;
        }
        
        /// <summary>
        /// 修改预置位
        /// </summary>
        /// <param name="tmpTurntablePresetData"></param>
        /// <returns></returns>
        static public int UpdatePreset(TurntablePresetData tmpTurntablePresetData)
        {
            int tmpUpdata = 0;
            PresetList entityToInsert = null;
            PresetListRepository tmpPresetListRepository = new PresetListRepository();
            Guid tmpTurntableGuid;
            Guid PresetGuid =  GetPresetGuid(tmpTurntablePresetData.VideoGuid, tmpTurntablePresetData.PresetName);
            if (ControlBusinessData.CameraList_Dictionary[tmpTurntablePresetData.VideoGuid.ToString()].Turntable_PTZ_DeviceID != null)
            {
                tmpTurntableGuid = ControlBusinessData.CameraList_Dictionary[tmpTurntablePresetData.VideoGuid.ToString()].Turntable_PTZ_DeviceID.Value;
                int VideoType = ControlBusinessData.GetCameraVideoType(tmpTurntablePresetData.VideoGuid);
                switch (VideoType)
                {
                    case (int)VideoCommandType.VideoCCD:
                        {
                            entityToInsert = new PresetList();
                            entityToInsert.PresetID = PresetGuid;
                            entityToInsert.PresetName = tmpTurntablePresetData.PresetName;
                            entityToInsert.CameraDeviceID = tmpTurntablePresetData.VideoGuid.Value;
                            entityToInsert.PresetType = 0;
                            entityToInsert.Horizontal_Data = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].Horizontal_Data.ToString();/**水平-原始数据*/
                            entityToInsert.Vertical_Data = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].Vertical_Data.ToString();/**俯仰-原始数据*/
                            entityToInsert.CCDorIR_Depth = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].CCD_Depth_Data.ToString();/**白光变倍-原始数据*/
                            entityToInsert.CCDorIR_Focus = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].CCD_Focus_Data.ToString();/**白光聚焦-原始数据*/
                            tmpUpdata = tmpPresetListRepository.Update(entityToInsert);
                        }
                        break;
                    case (int)VideoCommandType.VideoIR:
                        {
                            entityToInsert = new PresetList();
                            entityToInsert.PresetID = PresetGuid;
                            entityToInsert.PresetName = tmpTurntablePresetData.PresetName;
                            entityToInsert.CameraDeviceID = tmpTurntablePresetData.VideoGuid.Value;
                            entityToInsert.PresetType = 0;
                            entityToInsert.Horizontal_Data = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].Horizontal_Data.ToString();/**水平-原始数据*/
                            entityToInsert.Vertical_Data = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].Vertical_Data.ToString();/**俯仰-原始数据*/
                            entityToInsert.CCDorIR_Depth = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].IR_Depth_Data.ToString();/**红外变倍-原始数据*/
                            entityToInsert.CCDorIR_Focus = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].IR_Focus_Data.ToString();/**红外聚焦-原始数据*/
                            tmpUpdata = tmpPresetListRepository.Update(entityToInsert);
                        }
                        break;
                    case (int)VideoCommandType.VideoPTZ:
                        {
                            entityToInsert = new PresetList();
                            entityToInsert.CameraDeviceID = tmpTurntablePresetData.VideoGuid.Value;
                            entityToInsert.PresetName = tmpTurntablePresetData.PresetName;
                            entityToInsert.PresetType = 0;
                            entityToInsert.PresetNo = 1;
                            //ProtocolBusinessLogic
                            tmpUpdata = tmpPresetListRepository.Update(entityToInsert);
                        }
                        break;
                }

            }
            return tmpUpdata;
        }
        /// <summary>
        /// 添加预置位
        /// </summary>
        /// <param name="tmpTurntablePresetData"></param>
        /// <returns></returns>
        static public Guid? AddrPreset(TurntablePresetData tmpTurntablePresetData)
        {
            Guid? strAddrPresetType=null;
            PresetListRepository tmpPresetListRepository = new PresetListRepository();
            PresetList entityToInsert = null;
            Guid tmpTurntableGuid;
            if (ControlBusinessData.CameraList_Dictionary[tmpTurntablePresetData.VideoGuid.ToString()].Turntable_PTZ_DeviceID!=null)
            {
                tmpTurntableGuid = ControlBusinessData.CameraList_Dictionary[tmpTurntablePresetData.VideoGuid.ToString()].Turntable_PTZ_DeviceID.Value;
                int VideoType = ControlBusinessData.GetCameraVideoType(tmpTurntablePresetData.VideoGuid);
                switch (VideoType)
                {
                    case (int)VideoCommandType.VideoCCD:
                        {
                            entityToInsert = new PresetList();
                            entityToInsert.PresetName = tmpTurntablePresetData.PresetName;
                            entityToInsert.CameraDeviceID = tmpTurntablePresetData.VideoGuid.Value;
                            entityToInsert.PresetType = 0;
                            entityToInsert.Horizontal_Data = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].Horizontal_Data.ToString();/**水平-原始数据*/
                            entityToInsert.Vertical_Data = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].Vertical_Data.ToString();/**俯仰-原始数据*/
                            entityToInsert.CCDorIR_Depth = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].CCD_Depth_Data.ToString();/**白光变倍-原始数据*/
                            entityToInsert.CCDorIR_Focus = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].CCD_Focus_Data.ToString();/**白光聚焦-原始数据*/
                            strAddrPresetType = tmpPresetListRepository.Insert(entityToInsert);
                        }
                        break;
                    case (int)VideoCommandType.VideoIR:
                        {
                            entityToInsert = new PresetList();
                            entityToInsert.PresetName = tmpTurntablePresetData.PresetName;
                            entityToInsert.CameraDeviceID = tmpTurntablePresetData.VideoGuid.Value;
                            entityToInsert.PresetType = 0;
                            entityToInsert.Horizontal_Data = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].Horizontal_Data.ToString();/**水平-原始数据*/
                            entityToInsert.Vertical_Data = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].Vertical_Data.ToString();/**俯仰-原始数据*/
                            entityToInsert.CCDorIR_Depth = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].IR_Depth_Data.ToString();/**红外变倍-原始数据*/
                            entityToInsert.CCDorIR_Focus = ControlBusinessData.DynamicDataOfTurntable_Dictionary[tmpTurntableGuid].IR_Focus_Data.ToString();/**红外聚焦-原始数据*/
                            strAddrPresetType = tmpPresetListRepository.Insert(entityToInsert);
                        }
                        break;
                    case (int)VideoCommandType.VideoPTZ:
                        {
                            entityToInsert = new PresetList();
                            entityToInsert.CameraDeviceID = tmpTurntablePresetData.VideoGuid.Value;
                            entityToInsert.PresetName = tmpTurntablePresetData.PresetName;
                            entityToInsert.PresetType = 0;
                            entityToInsert.PresetNo = 1;
                            //ProtocolBusinessLogic
                            strAddrPresetType = tmpPresetListRepository.Insert(entityToInsert);
                        }
                        break;
                }
            }
            else
            { }
            
            return strAddrPresetType;
        }
        /// <summary>
        /// 删除预置位
        /// </summary>
        /// <param name="tmpTurntablePresetData"></param>
        /// <returns></returns>
        static public string DelPreset(TurntablePresetData tmpTurntablePresetData)
        {
            string strDelPreset = "";
            PresetListRepository tmpPresetListRepository = new PresetListRepository();
            //List<PresetList> tmp = tmpPresetListRepository.GetList();
            int VideoType = ControlBusinessData.GetCameraVideoType(tmpTurntablePresetData.VideoGuid);
            Guid PresetGuid = GetPresetGuid(tmpTurntablePresetData.VideoGuid, tmpTurntablePresetData.PresetName);
            if (VideoType == (int)VideoCommandType.VideoCCD || VideoType == (int)VideoCommandType.VideoIR)
            {
                tmpPresetListRepository.Delete(PresetGuid);
            }
            else
            {
                tmpPresetListRepository.Delete(PresetGuid);
            }
            return strDelPreset;
        }
        /// <summary>
        /// 调用预置位
        /// </summary>
        /// <param name="tmpTurntablePresetData"></param>
        static public void SetPreset(TurntablePresetData tmpTurntablePresetData)
        {
            tmp_StaticDataT = new StaticDataOfTurntable();
            tmp_StaticDataT = ControlBusinessData.GetStaticDataOfTurntable(tmpTurntablePresetData.VideoGuid);

            PresetListRepository tmpPresetListRepository = new PresetListRepository();
            List<PresetList> tmp = tmpPresetListRepository.GetList();
            if (tmp.Count > 0)
            {
                for (int i = 0; i < tmp.Count; i++)
                {
                    if(tmp[i].PresetName == tmpTurntablePresetData.PresetName && tmp[i].CameraDeviceID == tmpTurntablePresetData.VideoGuid)
                    {
                        ProtocolBusinessLogic.SetPreset_Business(tmp_StaticDataT, tmp[i]);
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// 获取预置位ID
        /// </summary>
        /// <param name="VideoGuid"></param>
        /// <param name="PresetName"></param>
        /// <returns></returns>
        static Guid GetPresetGuid(Guid? VideoGuid, string PresetName)
        {
            Guid PresetGuid = new Guid();
            if (VideoGuid != null && PresetName != "" && PresetName != null)
            {
                PresetListRepository tmpPresetListRepository = new PresetListRepository();
                List<PresetList> tmp = tmpPresetListRepository.GetList();
                if (tmp != null)
                {
                    for (int i = 0; i < tmp.Count; i++)
                    {
                        if (tmp[i].CameraDeviceID == VideoGuid && tmp[i].PresetName == PresetName)
                        {
                            PresetGuid = tmp[i].PresetID;
                            break;
                        }
                    }
                }
            }
            return PresetGuid;
        }
    }
}
