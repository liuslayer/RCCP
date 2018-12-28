using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class VibrationCable_DataManagement
    {
        static VibrationCableListRepository _tmpVibrationCableList = new VibrationCableListRepository();
        static public int[] AddData(List<VibrationCableList> _VibrationCableList)
        {
            int[] i;
            if (_VibrationCableList != null && _VibrationCableList.Count > 0)
            {
                i = new int[_VibrationCableList.Count];
                for (int j = 0; j < _VibrationCableList.Count; j++)
                {
                    try
                    {
                        _tmpVibrationCableList.Insert(_VibrationCableList[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }

            return i;
        }
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
                        _tmpVibrationCableList.Delete(_GuidData[j]);
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
            List<VibrationCableList> _ListVibrationCable = new List<VibrationCableList>();
            try
            {
                _ListVibrationCable = _tmpVibrationCableList.GetList();
                for (int j = 0; j < _ListVibrationCable.Count; j++)
                {
                    _tmpVibrationCableList.Delete(_ListVibrationCable[j].DeviceID);
                }
                i = 1;
            }
            catch { i = 2; }
            return i;
        }
        static public int[] UpData(List<VibrationCableList> _VibrationCableList)
        {
            int[] i;
            if (_VibrationCableList != null && _VibrationCableList.Count > 0)
            {
                i = new int[_VibrationCableList.Count];
                for (int j = 0; j < _VibrationCableList.Count; j++)
                {
                    try
                    {
                        _tmpVibrationCableList.Update(_VibrationCableList[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }

            return i;
        }
        static public List<VibrationCableList> GetAllData()
        {
            List<VibrationCableList> _ListVibrationCable = new List<VibrationCableList>();
            try { _ListVibrationCable = _tmpVibrationCableList.GetList(); } catch { _ListVibrationCable = null; }
            return _ListVibrationCable;
        }
    }
}
