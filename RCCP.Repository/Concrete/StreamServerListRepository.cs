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
    public class StreamServerListRepository
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

        public StreamServerList GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<StreamServerList>(id);
            }
        }

        public List<StreamServerList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<StreamServerList>().ToList();
            }
        }

        public List<StreamServerList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<StreamServerList>(whereCondition).ToList();
            }
        }

        public List<StreamServerList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<StreamServerList>(condition).ToList();
            }
        }

        public List<StreamServerList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<StreamServerList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(StreamServerList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(StreamServerList entityToInsert)
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
                return Conn.Delete<StreamServerList>(deviceId);
            }
        }

        public int Delete(StreamServerList entityToInsert)
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
                return Conn.DeleteList<StreamServerList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<StreamServerList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<StreamServerList>(conditions);
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
