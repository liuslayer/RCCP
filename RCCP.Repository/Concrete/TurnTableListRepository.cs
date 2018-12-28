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
    public class TurnTableListRepository
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

        public TurnTableList GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<TurnTableList>(id);
            }
        }

        public List<TurnTableList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<TurnTableList>().ToList();
            }
        }

        public List<TurnTableList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<TurnTableList>(whereCondition).ToList();
            }
        }

        public List<TurnTableList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<TurnTableList>(condition).ToList();
            }
        }

        public List<TurnTableList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<TurnTableList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(TurnTableList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(TurnTableList entityToInsert)
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
                return Conn.Delete<TurnTableList>(deviceId);
            }
        }

        public int Delete(TurnTableList entityToInsert)
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
                return Conn.DeleteList<TurnTableList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<TurnTableList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<TurnTableList>(conditions);
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
