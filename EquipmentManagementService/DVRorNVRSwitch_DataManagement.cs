using RCCP.Repository.Concrete;
using RCCP.Repository.Entities.StaticEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class DVRorNVRSwitch_DataManagement
    {
        static DVRorNVR_SwitchListRepository _tmpDVRorNVR_Switch = new DVRorNVR_SwitchListRepository();
        /// <summary>
        /// 添加 DVRorNVR_SwitchList
        /// </summary>
        /// <param name="_DVRorNVR_SwitchList"></param>
        /// <returns></returns>
        static public int[] AddData(List<DVRorNVR_SwitchList> _DVRorNVR_SwitchList)
        {
            int[] i = null;
            if (_DVRorNVR_SwitchList != null && _DVRorNVR_SwitchList.Count > 0)
            {
                i = new int[_DVRorNVR_SwitchList.Count];
                for (int j = 0; j < _DVRorNVR_SwitchList.Count; j++)
                {
                    try
                    {
                        _tmpDVRorNVR_Switch.Insert(_DVRorNVR_SwitchList[j]);
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
                        _tmpDVRorNVR_Switch.Delete(_GuidData[j]);
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
            List<DVRorNVR_SwitchList> tmp_All = new List<DVRorNVR_SwitchList>();
            try
            {
                tmp_All = _tmpDVRorNVR_Switch.GetList();
                for (int j = 0; j < tmp_All.Count; j++)
                {
                    _tmpDVRorNVR_Switch.Delete(tmp_All[j].DeviceID);
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
        static public int[] UpData(List<DVRorNVR_SwitchList> _DVRorNVR_SwitchList)
        {
            int[] i = null;
            if (_DVRorNVR_SwitchList.Count > 0 && _DVRorNVR_SwitchList != null)
            {
                i = new int[_DVRorNVR_SwitchList.Count];
                for (int j = 0; j < _DVRorNVR_SwitchList.Count; j++)
                {
                    try
                    {
                        _tmpDVRorNVR_Switch.Update(_DVRorNVR_SwitchList[j]);
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
        static public List<DVRorNVR_SwitchList> GetAllData()
        {
            List<DVRorNVR_SwitchList> _DVRorNVR_SwitchList = new List<DVRorNVR_SwitchList>();
            try { _DVRorNVR_SwitchList = _tmpDVRorNVR_Switch.GetList(); } catch { _DVRorNVR_SwitchList = null; }
             return _DVRorNVR_SwitchList;
        }
    }
}
