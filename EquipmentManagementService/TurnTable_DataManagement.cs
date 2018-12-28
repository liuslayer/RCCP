using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class TurnTable_DataManagement
    {

        static TurnTableListRepository tmpTurnTableList = new TurnTableListRepository();

        /// <summary>
        /// 添加 转台
        /// </summary>
        /// <param name="_TurnTableList"></param>
        /// <returns></returns>
        static public int[] AddData(List<TurnTableList> _TurnTableList)
        {
            int[] i = null;
            if (_TurnTableList != null && _TurnTableList.Count > 0)
            {
                i = new int[_TurnTableList.Count];
                for (int j = 0; j < _TurnTableList.Count; j++)
                {
                    try
                    {
                        tmpTurnTableList.Insert(_TurnTableList[j]);
                        i[j] = 1;
                    }
                    catch
                    {
                        i[j] = 2;
                    }
                }
            }

            return i;
        }

        /// <summary>
        /// 删除 转台
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
                    i[j] = tmpTurnTableList.Delete(_GuidData[j]);
                }
            }

            return i;
        }

        /// <summary>
        /// 修改 转台
        /// </summary>
        /// <param name="_UPSList"></param>
        /// <returns></returns>
        static public int[] UpData(List<TurnTableList> _TurnTableList)
        {
            int[] i = null;
            if (_TurnTableList.Count > 0 && _TurnTableList != null)
            {
                i = new int[_TurnTableList.Count];
                for (int j = 0; j < _TurnTableList.Count; j++)
                {
                    i[j] = tmpTurnTableList.Update(_TurnTableList[j]);
                }
            }
            return i;
        }

        /// <summary>
        /// 查询所有 转台数据
        /// </summary>
        /// <returns></returns>
        static public List<TurnTableList> GetAllData()
        {
            List<TurnTableList> _TurnTableList = new List<TurnTableList>();
            _TurnTableList = tmpTurnTableList.GetList();
            return _TurnTableList;
        }
    }
}
