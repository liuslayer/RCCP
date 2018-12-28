using AccessOperation;
using AlarmService;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command.Alarm
{
    public class Alarm_DataManagement
    {
        static ArmAndDisArmListRepository _tmparmAndDisarmDataList = new ArmAndDisArmListRepository();

        /// <summary>
        /// 添加ArmAndDisArmList
        /// </summary>
        /// <param name="_armAndDisarmDataList"></param>
        /// <returns></returns>
        static public int[] AddData(List<ArmAndDisarmList> _armAndDisarmDataList)
        {
            int[] i = null;
            if (_armAndDisarmDataList != null && _armAndDisarmDataList.Count > 0)
            {
                i = new int[_armAndDisarmDataList.Count];
                for (int j = 0; j < _armAndDisarmDataList.Count; j++)
                {
                    ArmAndDisarmList tmparmAndDisarmDataList = new ArmAndDisarmList();
                    tmparmAndDisarmDataList.AlarmDeviceID = _armAndDisarmDataList[j].AlarmDeviceID;
                    tmparmAndDisarmDataList.AlarmLevel = _armAndDisarmDataList[j].AlarmLevel;
                    tmparmAndDisarmDataList.AlarmLine = _armAndDisarmDataList[j].AlarmLine;
                    tmparmAndDisarmDataList.AlarmName = _armAndDisarmDataList[j].AlarmName;
                    tmparmAndDisarmDataList.AlarmRecPictureID = _armAndDisarmDataList[j].AlarmRecPictureID;
                    tmparmAndDisarmDataList.AlarmSensitive = _armAndDisarmDataList[j].AlarmSensitive;
                    tmparmAndDisarmDataList.AlarmType = _armAndDisarmDataList[j].AlarmType;
                    tmparmAndDisarmDataList.CurrentArmStatus = _armAndDisarmDataList[j].CurrentArmStatus;
                    tmparmAndDisarmDataList.Description = _armAndDisarmDataList[j].Description;
                    tmparmAndDisarmDataList.DeviceID = _armAndDisarmDataList[j].DeviceID;
                    tmparmAndDisarmDataList.IsAlarmSound = _armAndDisarmDataList[j].IsAlarmSound;
                    tmparmAndDisarmDataList.IsArm = _armAndDisarmDataList[j].IsArm;
                    tmparmAndDisarmDataList.IsVideoFlashing = _armAndDisarmDataList[j].IsVideoFlashing;
                    tmparmAndDisarmDataList.Mark = _armAndDisarmDataList[j].Mark;
                    tmparmAndDisarmDataList.PictureboxSize = _armAndDisarmDataList[j].PictureboxSize;
                    tmparmAndDisarmDataList.ScreenFrame = _armAndDisarmDataList[j].ScreenFrame;
                    tmparmAndDisarmDataList.ScreenResolution = _armAndDisarmDataList[j].ScreenResolution;
                    tmparmAndDisarmDataList.TimeType = _armAndDisarmDataList[j].TimeType;
                    try
                    {
                        _tmparmAndDisarmDataList.Insert(tmparmAndDisarmDataList);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            } 
            return i;
        }

        /// <summary>
        /// 删除ArmAndDisArmList
        /// </summary>
        /// <param name="_GuidData"></param>
        /// <returns></returns>
        static public int[] DelData(Guid[] _GuidData)
        {
            int[] i;
            if(_GuidData.Length > 0 && _GuidData != null)
            {
                i = new int[_GuidData.Length];
                for (int j = 0; j < _GuidData.Length; j++)
                {
                    try
                    {
                        _tmparmAndDisarmDataList.Delete(_GuidData[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2;}
                }
            }
            else{ i=null;}
            return i;
        }

        /// <summary>
        /// 修改ArmAndDisArmList
        /// </summary>
        /// <param name="_armAndDisarmDataList"></param>
        /// <returns></returns>
        static public int[] UpData(List<ArmAndDisarmList> _armAndDisarmDataList)
        {
            int[] i;
            if (_armAndDisarmDataList.Count > 0 && _armAndDisarmDataList != null)
            {
                i = new int[_armAndDisarmDataList.Count];
                for (int j = 0; j < _armAndDisarmDataList.Count; j++)
                {
                    try
                    {
                        _tmparmAndDisarmDataList.Update(_armAndDisarmDataList[j]);
                        i[j] = 1;
                    }
                    catch
                    {
                        i[j] = 2;
                    } 
                }
            }
            else
            { i = null; }
            return i;
        }

        /// <summary>
        /// 查询所有ArmAndDisArmList数据
        /// </summary>
        /// <returns></returns>
        static public List<ArmAndDisarmList> GetAllData()
        {
            List<ArmAndDisarmList> _ListArmAndDisarmList = new List<ArmAndDisarmList>();
            try { _ListArmAndDisarmList = _tmparmAndDisarmDataList.GetList(); } catch { _ListArmAndDisarmList = null; }
            return _ListArmAndDisarmList;
        }
    }
}
