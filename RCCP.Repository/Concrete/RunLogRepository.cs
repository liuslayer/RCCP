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
    public class RunLogRepository
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

        public RunLog GetEntityById(int id)
        {
            using (Conn)
            {
                return Conn.Get<RunLog>(id);
            }
        }

        public List<RunLog> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<RunLog>().ToList();
            }
        }

        public List<RunLog> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<RunLog>(whereCondition).ToList();
            }
        }

        public List<RunLog> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<RunLog>(condition).ToList();
            }
        }

        public List<RunLog> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<RunLog>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public int Insert(RunLog entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<int>(entityToInsert);
            }
        }

        public int Update(RunLog entityToInsert)
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
                return Conn.Delete<RunLog>(deviceId);
            }
        }

        public int Delete(RunLog entityToInsert)
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
                return Conn.DeleteList<RunLog>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<RunLog>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<RunLog>(conditions);
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
