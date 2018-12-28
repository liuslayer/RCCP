using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class Computer_DataManagement
    { 
        static ComputerListRepository _tmpComputerList = new ComputerListRepository();
        static public int[] AddData(List<ComputerList> _ComputerList)
        {
            int[] i;
            if (_ComputerList != null && _ComputerList.Count > 0)
            {
                i = new int[_ComputerList.Count];
                for (int j = 0; j < _ComputerList.Count; j++)
                {
                    try
                    {
                        _tmpComputerList.Insert(_ComputerList[j]);
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
                        _tmpComputerList.Delete(_GuidData[j]);
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
            List<ComputerList> _ListComputer = new List<ComputerList>();
            try
            {
                _ListComputer = _tmpComputerList.GetList();
                for (int j = 0; j < _ListComputer.Count; j++)
                {
                    _tmpComputerList.Delete(_ListComputer[j].DeviceID);
                }
                i = 1;
            }
            catch { i = 2; }
            return i;
        }
        static public int[] UpData(List<ComputerList> _ComputerList)
        {
            int[] i;
            if (_ComputerList != null && _ComputerList.Count > 0)
            {
                i = new int[_ComputerList.Count];
                for (int j = 0; j < _ComputerList.Count; j++)
                {
                    try
                    {
                        _tmpComputerList.Update(_ComputerList[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }

            return i;
        }
        static public List<ComputerList> GetAllData()
        {
            List<ComputerList> _ListComputer = new List<ComputerList>();
            try { _ListComputer = _tmpComputerList.GetList(); } catch { _ListComputer = null; }
            return _ListComputer;
        }
    }
}
