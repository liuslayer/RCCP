using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class SolarEnergyList_DataManagement
    {
        static SolarEnergyListRepository _tmpSolarEnergy = new SolarEnergyListRepository();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="_CameraList"></param>
        /// <returns></returns>
        static public int[] AddData(List<SolarEnergyList> _SolarEnergyList)
        {
            int[] i;
            if (_SolarEnergyList != null && _SolarEnergyList.Count > 0)
            {
                i = new int[_SolarEnergyList.Count];
                for (int j = 0; j < _SolarEnergyList.Count; j++)
                {
                    try
                    {
                        _tmpSolarEnergy.Insert(_SolarEnergyList[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
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
                        _tmpSolarEnergy.Delete(_GuidData[j]);
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
        /// <param name="_CameraList"></param>
        /// <returns></returns>
        static public int[] UpData(List<SolarEnergyList> _SolarEnergyList)
        {
            int[] i;
            if (_SolarEnergyList != null && _SolarEnergyList.Count > 0)
            {
                i = new int[_SolarEnergyList.Count];
                for (int j = 0; j < _SolarEnergyList.Count; j++)
                {
                    try
                    {
                        _tmpSolarEnergy.Update(_SolarEnergyList[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }
            
            return i;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        static public List<SolarEnergyList> GetAllData()
        {
            List<SolarEnergyList> _ListSolarEnergy = new List<SolarEnergyList>();
            try
            { _ListSolarEnergy = _tmpSolarEnergy.GetList(); }
            catch { _ListSolarEnergy = null; }
            return _ListSolarEnergy;
        }
    }
}
