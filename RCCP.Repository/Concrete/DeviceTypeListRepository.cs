using Dapper;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RCCP.Repository.Concrete
{
    public class DeviceTypeListRepository
    {
        #region init dbconnection
        private static readonly string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        private IDbConnection _conn;
        public IDbConnection Conn
        {
            get
            {
                _conn = new SqlConnection(connString);
                _conn.Open();
                return _conn;
            }
        }
        #endregion

        public DeviceTypeList GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<DeviceTypeList>(id);
            }
        }

        public List<DeviceTypeList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<DeviceTypeList>().ToList();
            }
        }

        public List<DeviceTypeList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<DeviceTypeList>(whereCondition).ToList();
            }
        }

        public List<DeviceTypeList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<DeviceTypeList>(condition).ToList();
            }
        }

        public List<DeviceTypeList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<DeviceTypeList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(DeviceTypeList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(DeviceTypeList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Update(entityToInsert);
            }
        }

        public int Delete(Guid deviceId)
        {
            using (Conn)
            {
                return Conn.Delete<DeviceTypeList>(deviceId);
            }
        }

        public int Delete(DeviceTypeList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Delete(entityToInsert);
            }
        }

        public int DeleteList(object whereConditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<DeviceTypeList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<DeviceTypeList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<DeviceTypeList>(conditions);
            }
        }

        public Guid GetGuid()
        {
            using (Conn)
            {
                return SimpleCRUD.SequentialGuid();
            }
        }
    }
}
