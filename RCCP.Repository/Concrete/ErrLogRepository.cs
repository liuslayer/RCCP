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
    public class ErrLogRepository
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

        public ErrLog GetEntityById(int id)
        {
            using (Conn)
            {
                return Conn.Get<ErrLog>(id);
            }
        }

        public List<ErrLog> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<ErrLog>().ToList();
            }
        }

        public List<ErrLog> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<ErrLog>(whereCondition).ToList();
            }
        }

        public List<ErrLog> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<ErrLog>(condition).ToList();
            }
        }

        public List<ErrLog> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<ErrLog>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public int Insert(ErrLog entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<int>(entityToInsert);
            }
        }

        public int Update(ErrLog entityToInsert)
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
                return Conn.Delete<ErrLog>(deviceId);
            }
        }

        public int Delete(ErrLog entityToInsert)
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
                return Conn.DeleteList<ErrLog>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<ErrLog>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<ErrLog>(conditions);
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
