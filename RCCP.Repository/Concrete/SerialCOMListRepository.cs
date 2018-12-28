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
    public class SerialCOMListRepository
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

        public SerialCOMList GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<SerialCOMList>(id);
            }
        }

        public List<SerialCOMList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<SerialCOMList>().ToList();
            }
        }

        public List<SerialCOMList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<SerialCOMList>(whereCondition).ToList();
            }
        }

        public List<SerialCOMList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<SerialCOMList>(condition).ToList();
            }
        }

        public List<SerialCOMList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<SerialCOMList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(SerialCOMList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(SerialCOMList entityToInsert)
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
                return Conn.Delete<SerialCOMList>(deviceId);
            }
        }

        public int Delete(SerialCOMList entityToInsert)
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
                return Conn.DeleteList<SerialCOMList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<SerialCOMList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<SerialCOMList>(conditions);
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
