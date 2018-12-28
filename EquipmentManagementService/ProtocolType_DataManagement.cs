using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class ProtocolType_DataManagement
    {
        static ProtocolTypeListRepository _tmpProtocolTypeList = new ProtocolTypeListRepository();
        static List<ProtocolTypeList> List_ProtocolTypeList = new List<ProtocolTypeList>();
        static int ad;
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        static public int[] AddData(List<ProtocolTypeList> _ProtocolTypeList)
        {
            int[] i;
            if (_ProtocolTypeList != null && _ProtocolTypeList.Count > 0)
            {
                i = new int[_ProtocolTypeList.Count];
                for (int j = 0; j < _ProtocolTypeList.Count; j++)
                {
                    try
                    {
                        _tmpProtocolTypeList.Insert(_ProtocolTypeList[j]);
                        i[j] = 1;
                    }
                    catch (Exception e) { i[j] = 2; }
                }
            }
            else { i = null; }
            return i;
        }

        /// <summary>
        /// 删除
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
                        _tmpProtocolTypeList.Delete(_GuidData[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }
            return i;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public int DelAllData()
        {
            int i = 0;
            List<ProtocolTypeList> tmp_All = new List<ProtocolTypeList>();
            tmp_All = _tmpProtocolTypeList.GetList();
            if (tmp_All.Count > 0)
            {
                for (int j = 0; j < tmp_All.Count; j++)
                {
                    try
                    {
                        _tmpProtocolTypeList.Delete(tmp_All[j].ID);
                        i = 1;
                    }
                    catch { i = 2; }
                }
            }
            else { i = 2; }

            return i;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="_SerialCOMList"></param>
        /// <returns></returns>
        static public int[] UpData(List<ProtocolTypeList> _ProtocolTypeList)
        {
            int[] i = new int[_ProtocolTypeList.Count];

            for (int j = 0; j < _ProtocolTypeList.Count; j++)
            {
                try
                {
                    _tmpProtocolTypeList.Update(_ProtocolTypeList[j]);
                    i[j] = 1;
                }
                catch { i[j] = 2; }
            }
            return i;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        static public List<ProtocolTypeList> GetAllData()
        {
            List<ProtocolTypeList> ListProtocolTypeList = new List<ProtocolTypeList>();
            try { ListProtocolTypeList = _tmpProtocolTypeList.GetList(); } catch { ListProtocolTypeList = null; }
            return ListProtocolTypeList;
        }
    }
}
