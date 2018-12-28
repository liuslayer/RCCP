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
    public class LinkageDataRepository
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

        public LinkageData GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<LinkageData>(id);
            }
        }

        public List<LinkageData> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<LinkageData>().ToList();
            }
        }

        public List<LinkageData> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<LinkageData>(whereCondition).ToList();
            }
        }

        public List<LinkageData> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<LinkageData>(condition).ToList();
            }
        }

        public List<LinkageData> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<LinkageData>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(LinkageData entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(LinkageData entityToInsert)
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
                return Conn.Delete<LinkageData>(deviceId);
            }
        }

        public int Delete(LinkageData entityToInsert)
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
                return Conn.DeleteList<LinkageData>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<LinkageData>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<LinkageData>(conditions);
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
