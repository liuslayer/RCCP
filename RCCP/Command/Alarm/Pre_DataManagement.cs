using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command.Alarm
{
    public class Pre_DataManagement
    {
        static Pre_arrangeListRepository _tmparmPre_arrangeList = new Pre_arrangeListRepository();

        /// <summary>
        /// 添加Pre_arrangeList
        /// </summary>
        /// <param name="_Pre_arrangeList"></param>
        /// <returns></returns>
        static public int[] AddData(List<Pre_arrangeList> _Pre_arrangeList)
        {
            int[] i = null;
            if (_Pre_arrangeList != null && _Pre_arrangeList.Count > 0)
            {
                i = new int[_Pre_arrangeList.Count];
                for (int j = 0; j < _Pre_arrangeList.Count; j++)
                {
                    Pre_arrangeList tmparmPre_arrangeList = new Pre_arrangeList();
                    tmparmPre_arrangeList.AlarmDeviceID = _Pre_arrangeList[j].AlarmDeviceID;
                    tmparmPre_arrangeList.AlarmName = _Pre_arrangeList[j].AlarmName;
                    tmparmPre_arrangeList.CreatTime = _Pre_arrangeList[j].CreatTime;
                    tmparmPre_arrangeList.Description = _Pre_arrangeList[j].Description;
                    tmparmPre_arrangeList.Mark = _Pre_arrangeList[j].Mark;
                    tmparmPre_arrangeList.PlanPath = _Pre_arrangeList[j].PlanPath;
                    tmparmPre_arrangeList.Pre_arrangedID = _Pre_arrangeList[j].Pre_arrangedID;
                    tmparmPre_arrangeList.Pre_arrangeName = _Pre_arrangeList[j].Pre_arrangeName;
                    tmparmPre_arrangeList.ReviseTime = _Pre_arrangeList[j].ReviseTime;
                    tmparmPre_arrangeList.Pre_arrangeType = _Pre_arrangeList[j].Pre_arrangeType;

                    try
                    {
                        _tmparmPre_arrangeList.Insert(tmparmPre_arrangeList);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            return i;
        }

        /// <summary>
        /// 删除Pre_arrangeList
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
                        _tmparmPre_arrangeList.Delete(_GuidData[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }
            return i;
        }

        /// <summary>
        /// 修改Pre_arrangeList
        /// </summary>
        /// <param name="_Pre_arrangeList"></param>
        /// <returns></returns>
        static public int[] UpData(List<Pre_arrangeList> _Pre_arrangeList)
        {
            int[] i;
            if (_Pre_arrangeList.Count > 0 && _Pre_arrangeList != null)
            {
                i = new int[_Pre_arrangeList.Count];
                for (int j = 0; j < _Pre_arrangeList.Count; j++)
                {
                    try
                    {
                        _tmparmPre_arrangeList.Update(_Pre_arrangeList[j]);
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
        /// 查询所有Pre_arrangeList数据
        /// </summary>
        /// <returns></returns>
        static public List<Pre_arrangeList> GetAllData()
        {
            List<Pre_arrangeList> _ListPre_arrangeList = new List<Pre_arrangeList>();
            try { _ListPre_arrangeList = _tmparmPre_arrangeList.GetList(); } catch { _ListPre_arrangeList = null; }
            return _ListPre_arrangeList;
        }
        /// <summary>
        /// 根据时间查询条件查询
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        static public List<Pre_arrangeList> GetListWithCondition(string SQL)
        {
            List<Pre_arrangeList> _ListPre_arrangeList = new List<Pre_arrangeList>();
            try { _ListPre_arrangeList = _tmparmPre_arrangeList.GetListWithCondition(SQL); } catch { _ListPre_arrangeList = null; }
            return _ListPre_arrangeList;
        }
    }
}
