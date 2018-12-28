using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class Radar_DataManagement
    {
        static RadarListRepository _tmpRadarList = new RadarListRepository();

        /// <summary>
        /// 添加雷达
        /// </summary>
        /// <param name="_RadarList"></param>
        /// <returns></returns>
        static public int[] AddData(List<RadarList> _RadarList)
        {
            int[] i;
            if (_RadarList != null && _RadarList.Count > 0)
            {
                i = new int[_RadarList.Count];
                for (int j = 0; j < _RadarList.Count; j++)
                {
                    try
                    {
                        _tmpRadarList.Insert(_RadarList[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }

            return i;
        }

        /// <summary>
        /// 删除雷达
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
                        _tmpRadarList.Delete(_GuidData[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }

            return i;
        }
        static public int DelAllData()
        {
            int i = 0;
            List<RadarList> _ListRadar = new List<RadarList>();
            try
            {
                _ListRadar = _tmpRadarList.GetList();
                for (int j = 0; j < _ListRadar.Count; j++)
                {
                    _tmpRadarList.Delete(_ListRadar[j].DeviceID);
                }
                i = 1;
            }
            catch { i = 2; }
            return i;
        }
        /// <summary>
        /// 修改摄像机
        /// </summary>
        /// <param name="_CameraList"></param>
        /// <returns></returns>
        static public int[] UpData(List<RadarList> _RadarList)
        {
            int[] i;
            if (_RadarList != null && _RadarList.Count > 0)
            {
                i = new int[_RadarList.Count];
                for (int j = 0; j < _RadarList.Count; j++)
                {
                    try
                    {
                        _tmpRadarList.Update(_RadarList[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }

            return i;
        }

        /// <summary>
        /// 查询所有摄像机数据
        /// </summary>
        /// <returns></returns>
        static public List<RadarList> GetAllData()
        {
            List<RadarList> _ListRadar = new List<RadarList>();
            try { _ListRadar = _tmpRadarList.GetList(); } catch { _ListRadar = null; }
            return _ListRadar;
        }
    }
}
