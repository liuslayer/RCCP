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
    public class LawFileInfoRepository
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

        public LawFileInfo GetEntityById(int id)
        {
            using (Conn)
            {
                return Conn.Get<LawFileInfo>(id);
            }
        }

        public List<LawFileInfo> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<LawFileInfo>().ToList();
            }
        }

        public List<LawFileInfo> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<LawFileInfo>(whereCondition).ToList();
            }
        }

        public List<LawFileInfo> GetListWithCondition(string condition, object parameters)
        {
            using (Conn)
            {
                return Conn.GetList<LawFileInfo>(condition, parameters).ToList();
            }
        }

        public List<LawFileInfo> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<LawFileInfo>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public int Insert(LawFileInfo entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<int>(entityToInsert);
            }
        }

        public int Update(LawFileInfo entityToInsert)
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
                return Conn.Delete<LawFileInfo>(deviceId);
            }
        }

        public int Delete(LawFileInfo entityToInsert)
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
                return Conn.DeleteList<LawFileInfo>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<LawFileInfo>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<LawFileInfo>(conditions);
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
