using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class Station_DataManagement
    {
        static StationListRepository _tmpStation = new StationListRepository();
        /// <summary>
        /// 添加工作站
        /// </summary>
        /// <param name="_CameraList"></param>
        /// <returns></returns>
        static public int[] AddData(List<StationList> _StationList)
        {
            int[] i;
            if (_StationList != null && _StationList.Count > 0)
            {
                i = new int[_StationList.Count];
                for (int j = 0; j < _StationList.Count; j++)
                {
                    try
                    {
                        _tmpStation.Insert(_StationList[j]);
                        i[j] = 1;
                    }
                    catch
                    {
                        i[j] = 2;
                    }
                    
                }
            }
            else { i = null; }
            return i;
        }

        /// <summary>
        /// 删除工作站
        /// </summary>
        /// <param name="_GuidData"></param>
        /// <returns></returns>
        static public int[] DelData(Guid[] _GuidData)
        {
            int[] i;
            if (_GuidData != null && _GuidData.Length > 0)
            {
                i = new int[_GuidData.Length];
                for (int j = 0; j < _GuidData.Length; j++)
                {
                    try
                    {
                        _tmpStation.Delete(_GuidData[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }
            return i;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        static public int[] UpData(List<StationList> _StationList)
        {

            int[] i;
            if (_StationList != null && _StationList.Count > 0)
            {
                i = new int[_StationList.Count];
                for (int j = 0; j < _StationList.Count; j++)
                {
                    try
                    {
                        _tmpStation.Update(_StationList[j]);
                        i[j] = 1;
                    }
                    catch
                    { i[j] = 2; }
                }
            }
            else { i = null; }
            return i;
        }

        /// <summary>
        /// 查询所有工作站
        /// </summary>
        /// <returns></returns>
        static public List<StationList> GetAllData()
        {
            List<StationList> _ListStation = new List<StationList>();
            try { _ListStation = _tmpStation.GetList(); }catch { _ListStation = null; }
            
            return _ListStation;
        }
    }
}
