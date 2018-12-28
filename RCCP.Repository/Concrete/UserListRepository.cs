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
    public class UserListRepository
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

        public UserList GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<UserList>(id);
            }
        }

        public List<UserList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<UserList>().ToList();
            }
        }

        public List<UserList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<UserList>(whereCondition).ToList();
            }
        }

        public List<UserList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<UserList>(condition).ToList();
            }
        }

        public List<UserList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<UserList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(UserList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(UserList entityToInsert)
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
                return Conn.Delete<UserList>(deviceId);
            }
        }

        public int Delete(UserList entityToInsert)
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
                return Conn.DeleteList<UserList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<UserList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<UserList>(conditions);
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
