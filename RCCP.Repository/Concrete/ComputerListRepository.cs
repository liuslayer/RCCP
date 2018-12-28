using System;
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
    public class ComputerListRepository
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
        public ComputerList GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<ComputerList>(id);
            }
        }

        public List<ComputerList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<ComputerList>().ToList();
            }
        }

        public List<ComputerList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<ComputerList>(whereCondition).ToList();
            }
        }

        public List<ComputerList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<ComputerList>(condition).ToList();
            }
        }

        public List<ComputerList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<ComputerList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(ComputerList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(ComputerList entityToInsert)
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
                return Conn.Delete<ComputerList>(deviceId);
            }
        }

        public int Delete(ComputerList entityToInsert)
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
                return Conn.DeleteList<ComputerList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<ComputerList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<ComputerList>(conditions);
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
