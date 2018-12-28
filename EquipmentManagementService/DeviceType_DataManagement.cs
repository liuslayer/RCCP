using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class DeviceType_DataManagement
    {
        static DeviceTypeListRepository _tmpDeviceTypeList = new DeviceTypeListRepository();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_DeviceTypeList"></param>
        /// <returns></returns>
        static public int[] AddData(List<DeviceTypeList> _DeviceTypeList)
        {
            int[] i;
            if(_DeviceTypeList != null && _DeviceTypeList.Count > 0 )
            {
                i = new int[_DeviceTypeList.Count];
                for (int j = 0; j < _DeviceTypeList.Count; j++)
                {
                    try
                    {
                        _tmpDeviceTypeList.Insert(_DeviceTypeList[j]);
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
                        _tmpDeviceTypeList.Delete(_GuidData[j]);
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
            List<DeviceTypeList> tmp_All = new List<DeviceTypeList>();
            try
            {
                tmp_All = _tmpDeviceTypeList.GetList();
                for (int j = 0; j < tmp_All.Count; j++)
                {
                    _tmpDeviceTypeList.Delete(tmp_All[j].ID);
                }
                i = 1;
            }
            catch { i = 2; }
            return i;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_DeviceTypeList"></param>
        /// <returns></returns>
        static public int[] UpData(List<DeviceTypeList> _DeviceTypeList)
        {
            int[] i;
            if(_DeviceTypeList.Count >0)
            {
                i = new int[_DeviceTypeList.Count];
                for (int j = 0; j < _DeviceTypeList.Count; j++)
                {
                    try
                    {
                        _tmpDeviceTypeList.Update(_DeviceTypeList[j]);
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
        /// 查询所有设备类型数据
        /// </summary>
        /// <returns></returns>
        static public List<DeviceTypeList> GetAllData()
        {
            List<DeviceTypeList> ListDeviceTypeList = new List<DeviceTypeList>();
            try { ListDeviceTypeList = _tmpDeviceTypeList.GetList(); } catch { ListDeviceTypeList = null; }
            return ListDeviceTypeList;
        }
    }
}
