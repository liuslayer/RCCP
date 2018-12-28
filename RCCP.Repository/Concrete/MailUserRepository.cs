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
    public class MailUserRepository
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

        public MailUser GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<MailUser>(id);
            }
        }

        public List<MailUser> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<MailUser>().ToList();
            }
        }

        public List<MailUser> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<MailUser>(whereCondition).ToList();
            }
        }

        public List<MailUser> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<MailUser>(condition).ToList();
            }
        }

        public List<MailUser> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<MailUser>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(MailUser entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(MailUser entityToInsert)
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
                return Conn.Delete<MailUser>(deviceId);
            }
        }

        public int Delete(MailUser entityToInsert)
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
                return Conn.DeleteList<MailUser>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<MailUser>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<MailUser>(conditions);
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
