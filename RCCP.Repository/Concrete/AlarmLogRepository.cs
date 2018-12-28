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
    public class AlarmLogRepository
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

        public AlarmLog GetEntityById(int id)
        {
            using (Conn)
            {
                return Conn.Get<AlarmLog>(id);
            }
        }

        public List<AlarmLog> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<AlarmLog>().ToList();
            }
        }

        public List<AlarmLog> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<AlarmLog>(whereCondition).ToList();
            }
        }

        public List<AlarmLog> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<AlarmLog>(condition).ToList();
            }
        }

        public List<AlarmLog> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<AlarmLog>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public int Insert(AlarmLog entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<int>(entityToInsert);
            }
        }

        public int Update(AlarmLog entityToInsert)
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
                return Conn.Delete<AlarmLog>(deviceId);
            }
        }

        public int Delete(AlarmLog entityToInsert)
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
                return Conn.DeleteList<AlarmLog>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<AlarmLog>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<AlarmLog>(conditions);
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
