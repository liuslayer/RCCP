using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command.Alarm
{
    public class Video_DataManagement
    {
        static VideoAlarmListRepository _tmparmVideoAlarmList = new VideoAlarmListRepository();

        /// <summary>
        /// 添加VideoAlarmList
        /// </summary>
        /// <param name="_VideoAlarmDataList"></param>
        /// <returns></returns>
        static public int[] AddData(List<VideoAlarmList> _VideoAlarmDataList)
        {
            int[] i = null;
            if (_VideoAlarmDataList != null && _VideoAlarmDataList.Count > 0)
            {
                i = new int[_VideoAlarmDataList.Count];
                for (int j = 0; j < _VideoAlarmDataList.Count; j++)
                {
                    VideoAlarmList tmparmVideoAlarmDataList = new VideoAlarmList();
                    tmparmVideoAlarmDataList.AlarmName = _VideoAlarmDataList[j].AlarmName;
                    tmparmVideoAlarmDataList.AlarmPointSelect = _VideoAlarmDataList[j].AlarmPointSelect;
                    tmparmVideoAlarmDataList.AlarmSnapshotsCheck = _VideoAlarmDataList[j].AlarmSnapshotsCheck;
                    tmparmVideoAlarmDataList.AlarmType = _VideoAlarmDataList[j].AlarmType;
                    tmparmVideoAlarmDataList.COM = _VideoAlarmDataList[j].COM;
                    tmparmVideoAlarmDataList.Description = _VideoAlarmDataList[j].Description;
                    tmparmVideoAlarmDataList.DeviceID = _VideoAlarmDataList[j].DeviceID;
                    tmparmVideoAlarmDataList.IP = _VideoAlarmDataList[j].IP;
                    tmparmVideoAlarmDataList.Mark = _VideoAlarmDataList[j].Mark;
                    tmparmVideoAlarmDataList.TypeID = _VideoAlarmDataList[j].TypeID;

                    try
                    {
                        _tmparmVideoAlarmList.Insert(tmparmVideoAlarmDataList);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            return i;
        }

        /// <summary>
        /// 删除VideoAlarmList
        /// </summary>
        /// <param name="_GuidData"></param>
        /// <returns></returns>
        static public int[] DelData(Guid[] _GuidData)
        {
            int[] i;
            if (_GuidData.Length > 0 && _GuidData != null)
            {
                i = new int[_GuidData.Length];
                for (int j = 0; j < _GuidData.Length; j++)
                {
                    try
                    {
                        _tmparmVideoAlarmList.Delete(_GuidData[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }
            return i;
        }

        /// <summary>
        /// 修改VideoAlarmList
        /// </summary>
        /// <param name="_VideoAlarmDataList"></param>
        /// <returns></returns>
        static public int[] UpData(List<VideoAlarmList> _VideoAlarmDataList)
        {
            int[] i;
            if (_VideoAlarmDataList.Count > 0 && _VideoAlarmDataList != null)
            {
                i = new int[_VideoAlarmDataList.Count];
                for (int j = 0; j < _VideoAlarmDataList.Count; j++)
                {
                    try
                    {
                        _tmparmVideoAlarmList.Update(_VideoAlarmDataList[j]);
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
        /// 查询所有VideoAlarmList数据
        /// </summary>
        /// <returns></returns>
        static public List<VideoAlarmList> GetAllData()
        {
            List<VideoAlarmList> _ListVideoAlarmList = new List<VideoAlarmList>();
            try { _ListVideoAlarmList = _tmparmVideoAlarmList.GetList(); } catch { _ListVideoAlarmList = null; }
            return _ListVideoAlarmList;
        }
    }
}
