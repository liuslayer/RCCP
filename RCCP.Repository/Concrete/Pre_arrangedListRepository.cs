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
    public class Pre_arrangeListRepository
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

        public Pre_arrangeList GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<Pre_arrangeList>(id);
            }
        }

        public List<Pre_arrangeList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<Pre_arrangeList>().ToList();
            }
        }

        public List<Pre_arrangeList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<Pre_arrangeList>(whereCondition).ToList();
            }
        }

        public List<Pre_arrangeList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<Pre_arrangeList>(condition).ToList();
            }
        }

        public List<Pre_arrangeList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<Pre_arrangeList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(Pre_arrangeList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(Pre_arrangeList entityToInsert)
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
                return Conn.Delete<Pre_arrangeList>(deviceId);
            }
        }

        public int Delete(Pre_arrangeList entityToInsert)
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
                return Conn.DeleteList<Pre_arrangeList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<Pre_arrangeList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<Pre_arrangeList>(conditions);
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
