using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    //
    public class SerialCOM_DataManagement
    {
        static SerialCOMListRepository _tmpSerialCOMList = new SerialCOMListRepository();
        static List<SerialCOMList> List_SerialCOMList = new List<SerialCOMList>();
        static int ad ;
        /// <summary>
        /// 添加新的串口
        /// </summary>
        /// <param name="_SerialCOMList"></param>
        /// <returns></returns>
        static public int[] AddData(List <SerialCOMList> _SerialCOMList)
        {
            int[] i;
            if (_SerialCOMList!=null && _SerialCOMList.Count > 0)
            {
                i = new int[_SerialCOMList.Count];
                for (int j = 0; j < _SerialCOMList.Count; j++)
                {
                    try
                    {
                        _tmpSerialCOMList.Insert(_SerialCOMList[j]);
                        i[j] = 1;
                    }
                    catch (Exception e) { i[j] = 2; } 
                }
            }
            else { i = null; }
            return i;
        }

        /// <summary>
        /// 删除串口数据
        /// </summary>
        /// <param name="_GuidData"></param>
        /// <returns></returns>
        static public int[] DelData(Guid[] _GuidData)
        {
            int[] i;
            if ( _GuidData!=null && _GuidData.Length > 0)
            {
                i = new int[_GuidData.Length];
                for (int j = 0; j < _GuidData.Length; j++)
                {
                    try
                    {
                        _tmpSerialCOMList.Delete(_GuidData[j]);
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
            int i = 0 ;
            List<SerialCOMList> tmp_All = new List<SerialCOMList>();
            tmp_All = _tmpSerialCOMList.GetList();
            if (tmp_All.Count > 0)
            {
                for (int j = 0; j < tmp_All.Count; j++)
                {
                    try
                    {
                        _tmpSerialCOMList.Delete(tmp_All[j].DeviceID);
                        i = 1;
                    }
                    catch { i = 2; } 
                }
            }
            else { i = 2; }
            
            return i;
        }

        /// <summary>
        /// 修改串口数据
        /// </summary>
        /// <param name="_SerialCOMList"></param>
        /// <returns></returns>
        static public int[] UpData(List<SerialCOMList> _SerialCOMList)
        {
            int[] i = new int[_SerialCOMList.Count];
            
            for(int j =0;j<_SerialCOMList.Count;j++)
            {
                try
                {
                    _tmpSerialCOMList.Update(_SerialCOMList[j]);
                    i[j] = 1;
                }
                catch { i[j] = 2; } 
            }
            return i;
        }

        /// <summary>
        /// 查询所有串口数据
        /// </summary>
        /// <returns></returns>
        static public List<SerialCOMList> GetAllData()
        {
            List<SerialCOMList> ListSerialCOMList = new List<SerialCOMList>();
            try { ListSerialCOMList = _tmpSerialCOMList.GetList(); } catch { ListSerialCOMList = null; }
            return ListSerialCOMList;
        }
    }
}
