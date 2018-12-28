using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class UPS_DataManagement
    {
        static UPSListRepository _tmpUPSList = new UPSListRepository();

        /// <summary>
        /// 添加 UPS
        /// </summary>
        /// <param name="_UPSList"></param>
        /// <returns></returns>
        static public int[] AddData(List<UPSList> _UPSList)
        {
            int[] i = null;
            if (_UPSList != null && _UPSList.Count > 0)
            {
                i = new int[_UPSList.Count];
                for (int j = 0; j < _UPSList.Count; j++)
                {
                    try
                    {
                        _tmpUPSList.Insert(_UPSList[j]);
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
            int[] i;
            if(_GuidData.Length > 0 && _GuidData != null)
            {
                i = new int[_GuidData.Length];
                for (int j = 0; j < _GuidData.Length; j++)
                {
                    try
                    {
                        _tmpUPSList.Delete(_GuidData[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2;}
                }
            }
            else{ i=null;}
            return i;
        }

        /// <summary>
        /// 修改UPS
        /// </summary>
        /// <param name="_UPSList"></param>
        /// <returns></returns>
        static public int[] UpData(List<UPSList> _UPSList)
        {
            int[] i;
            if (_UPSList.Count > 0 && _UPSList != null)
            {
                i = new int[_UPSList.Count];
                for (int j = 0; j < _UPSList.Count; j++)
                {
                    try
                    {
                        _tmpUPSList.Update(_UPSList[j]);
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
        /// 查询所有UPS数据
        /// </summary>
        /// <returns></returns>
        static public List<UPSList> GetAllData()
        {
            List<UPSList> _ListUps = new List<UPSList>();
            try { _ListUps = _tmpUPSList.GetList(); } catch { _ListUps = null; }
            return _ListUps;
        }
    }
}
