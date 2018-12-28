using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using RCCP.Repository.Entities;

namespace RCCP.Repository.Concrete
{
    public class UPSStatusListRepository
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

        public UPSStatusList GetEntityById(int id)
        {
            using (Conn)
            {
                return Conn.Get<UPSStatusList>(id);
            }
        }

        public List<UPSStatusList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<UPSStatusList>().ToList();
            }
        }

        public List<UPSStatusList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<UPSStatusList>(whereCondition).ToList();
            }
        }

        public List<UPSStatusList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<UPSStatusList>(condition).ToList();
            }
        }

        public List<UPSStatusList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<UPSStatusList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public int Insert(UPSStatusList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<int>(entityToInsert);
            }
        }

        public int Update(UPSStatusList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Update(entityToInsert);
            }
        }

        public int Delete(long deviceId)
        {
            using (Conn)
            {
                return Conn.Delete<UPSStatusList>(deviceId);
            }
        }

        public int Delete(UPSStatusList entityToInsert)
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
                return Conn.DeleteList<UPSStatusList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<UPSStatusList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<UPSStatusList>(conditions);
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
