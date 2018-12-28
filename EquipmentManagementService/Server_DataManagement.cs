using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class Server_DataManagement
    {
        static ServerListRepository _tmpServerList = new ServerListRepository();
        static public int[] AddData(List<ServerList> _ServerList)
        {
            int[] i;
            if (_ServerList != null && _ServerList.Count > 0)
            {
                i = new int[_ServerList.Count];
                for (int j = 0; j < _ServerList.Count; j++)
                {
                    try
                    {
                        _tmpServerList.Insert(_ServerList[j]);
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
                        _tmpServerList.Delete(_GuidData[j]);
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
            List<ServerList> _ListServer = new List<ServerList>();
            try
            {
                _ListServer = _tmpServerList.GetList();
                for (int j = 0; j < _ListServer.Count; j++)
                {
                    _tmpServerList.Delete(_ListServer[j].DeviceID);
                }
                i = 1;
            }
            catch { i = 2; }
            return i;
        }
        static public int[] UpData(List<ServerList> _ServerList)
        {
            int[] i;
            if (_ServerList != null && _ServerList.Count > 0)
            {
                i = new int[_ServerList.Count];
                for (int j = 0; j < _ServerList.Count; j++)
                {
                    try
                    {
                        _tmpServerList.Update(_ServerList[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }

            return i;
        }
        static public List<ServerList> GetAllData()
        {
            List<ServerList> _ListServer = new List<ServerList>();
            try { _ListServer = _tmpServerList.GetList(); } catch { _ListServer = null; }
            return _ListServer;
        }
    }
}
