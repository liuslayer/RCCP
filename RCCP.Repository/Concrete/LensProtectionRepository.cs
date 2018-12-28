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
    public class LensProtectionRepository
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

        public LensProtection GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<LensProtection>(id);
            }
        }

        public List<LensProtection> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<LensProtection>().ToList();
            }
        }

        public List<LensProtection> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<LensProtection>(whereCondition).ToList();
            }
        }

        public List<LensProtection> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<LensProtection>(condition).ToList();
            }
        }

        public List<LensProtection> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<LensProtection>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(LensProtection entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(LensProtection entityToInsert)
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
                return Conn.Delete<LensProtection>(deviceId);
            }
        }

        public int Delete(LensProtection entityToInsert)
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
                return Conn.DeleteList<LensProtection>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<LensProtection>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<LensProtection>(conditions);
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
