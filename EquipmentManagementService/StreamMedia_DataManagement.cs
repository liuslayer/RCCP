using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class StreamMedia_DataManagement
    {
        static StreamMediaListRepository _tmpStreamMedia = new StreamMediaListRepository();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="_DVRorNVR_SwitchList"></param>
        /// <returns></returns>
        static public int[] AddData(List<StreamMediaList> _StreamMediaList)
        {
            int[] i = null;
            if (_StreamMediaList != null && _StreamMediaList.Count > 0)
            {
                i = new int[_StreamMediaList.Count];
                for (int j = 0; j < _StreamMediaList.Count; j++)
                {
                    try
                    {
                        _tmpStreamMedia.Insert(_StreamMediaList[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            return i;
        }

        /// <summary>
        /// 删除UPS
        /// </summary>
        /// <param name="_GuidData"></param>
        /// <returns></returns>
        static public int[] DelData(Guid[] _GuidData)
        {
            int[] i = null;
            if (_GuidData.Length > 0 && _GuidData != null)
            {
                i = new int[_GuidData.Length];
                for (int j = 0; j < _GuidData.Length; j++)
                {
                    try
                    {
                        _tmpStreamMedia.Delete(_GuidData[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            return i;
        }

        static public int DelAllData()
        {
            int i = 0;
            List<StreamMediaList> tmp_All = new List<StreamMediaList>();
            try
            {
                tmp_All = _tmpStreamMedia.GetList();
                for (int j = 0; j < tmp_All.Count; j++)
                {
                    _tmpStreamMedia.Delete(tmp_All[j].DeviceID);
                    i = 1;
                }
            }
            catch { i = 2; }
            return i;
        }

        /// <summary>
        /// 修改
        /// </summary> 
        /// <param name="_UPSList"></param>
        /// <returns></returns>
        static public int[] UpData(List<StreamMediaList> _DVRorNVR_SwitchList)
        {
            int[] i = null;
            if (_DVRorNVR_SwitchList.Count > 0 && _DVRorNVR_SwitchList != null)
            {
                i = new int[_DVRorNVR_SwitchList.Count];
                for (int j = 0; j < _DVRorNVR_SwitchList.Count; j++)
                {
                    try
                    {
                        _tmpStreamMedia.Update(_DVRorNVR_SwitchList[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            return i;
        }

        /// <summary>
        /// 查询所有UPS数据
        /// </summary>
        /// <returns></returns>
        static public List<StreamMediaList> GetAllData()
        {
            List<StreamMediaList> _StreamMediaList = new List<StreamMediaList>();
            try { _StreamMediaList = _tmpStreamMedia.GetList(); } catch { _StreamMediaList = null; }
            return _StreamMediaList;
        }
    }
}
