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
    public class StreamMediaListRepository
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

        public StreamMediaList GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<StreamMediaList>(id);
            }
        }

        public List<StreamMediaList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<StreamMediaList>().ToList();
            }
        }

        public List<StreamMediaList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<StreamMediaList>(whereCondition).ToList();
            }
        }

        public List<StreamMediaList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<StreamMediaList>(condition).ToList();
            }
        }

        public List<StreamMediaList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<StreamMediaList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(StreamMediaList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(StreamMediaList entityToInsert)
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
                return Conn.Delete<StreamMediaList>(deviceId);
            }
        }

        public int Delete(StreamMediaList entityToInsert)
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
                return Conn.DeleteList<StreamMediaList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<StreamMediaList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<StreamMediaList>(conditions);
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
