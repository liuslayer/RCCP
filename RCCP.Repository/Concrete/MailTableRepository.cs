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
    public class MailTableRepository
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

        public MailTable GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<MailTable>(id);
            }
        }

        public List<MailTable> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<MailTable>().ToList();
            }
        }

        public List<MailTable> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<MailTable>(whereCondition).ToList();
            }
        }

        public List<MailTable> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<MailTable>(condition).ToList();
            }
        }

        public List<MailTable> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<MailTable>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(MailTable entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(MailTable entityToInsert)
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
                return Conn.Delete<MailTable>(deviceId);
            }
        }

        public int Delete(MailTable entityToInsert)
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
                return Conn.DeleteList<MailTable>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<MailTable>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<MailTable>(conditions);
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
