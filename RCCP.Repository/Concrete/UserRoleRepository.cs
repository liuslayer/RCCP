using Dapper;
using RCCP.Repository.Entities.DynamicEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Repository.Concrete
{
    public class UserRoleRepository
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

        public UserRole GetEntityById(int id)
        {
            using (Conn)
            {
                return Conn.Get<UserRole>(id);
            }
        }

        public List<UserRole> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<UserRole>().ToList();
            }
        }

        public List<UserRole> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<UserRole>(whereCondition).ToList();
            }
        }

        public List<UserRole> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<UserRole>(condition).ToList();
            }
        }

        public List<UserRole> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<UserRole>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public int Insert(UserRole entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<int>(entityToInsert);
            }
        }

        public int Update(UserRole entityToInsert)
        {
            using (Conn)
            {
                return Conn.Update(entityToInsert);
            }
        }

        public int Delete(int deviceId)
        {
            using (Conn)
            {
                return Conn.Delete<UserRole>(deviceId);
            }
        }

        public int Delete(UserRole entityToInsert)
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
                return Conn.DeleteList<UserRole>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<UserRole>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<UserRole>(conditions);
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
