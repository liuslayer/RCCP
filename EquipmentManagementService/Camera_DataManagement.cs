using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class Camera_DataManagement
    {
        static CameraListRepository _tmpCameraList = new CameraListRepository();

        /// <summary>
        /// 添加摄像机 
        /// </summary>
        /// <param name="_CameraList"></param>
        /// <returns></returns>
        static public int[] AddData(List<CameraList> _CameraList)
        {
            int[] i;
            if (_CameraList!=null && _CameraList.Count > 0)
            {
                i = new int[_CameraList.Count];
                for (int j = 0; j < _CameraList.Count; j++)
                {
                    try
                    {
                        _tmpCameraList.Insert(_CameraList[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }
            
            return i;
        }

        /// <summary>
        /// 删除摄像机
        /// </summary>
        /// <param name="_GuidData"></param>
        /// <returns></returns>
        static public int[] DelData(Guid[] _GuidData)
        {
            int[] i;
            if (_GuidData!=null && _GuidData.Length>0)
            {
                 i= new int[_GuidData.Length];
                for (int j = 0; j < _GuidData.Length; j++)
                {
                    try
                    {
                        _tmpCameraList.Delete(_GuidData[j]);
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
            List<CameraList> _ListCamera = new List<CameraList>();
            try
            {
                _ListCamera = _tmpCameraList.GetList();
                for (int j = 0; j < _ListCamera.Count; j++)
                {
                    _tmpCameraList.Delete(_ListCamera[j].DeviceID);
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
        static public int[] UpData(List<CameraList> _CameraList)
        {
            int[] i;
            if(_CameraList!=null && _CameraList.Count > 0)
            {
                i = new int[_CameraList.Count];
                for (int j = 0; j < _CameraList.Count; j++)
                {
                    try
                    {
                        _tmpCameraList.Update(_CameraList[j]);
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
        static public List<CameraList> GetAllData()
        {
            List<CameraList> _ListCamera = new List<CameraList>();
            try { _ListCamera = _tmpCameraList.GetList(); } catch { _ListCamera = null; }
            return _ListCamera;
        }
    }
}
