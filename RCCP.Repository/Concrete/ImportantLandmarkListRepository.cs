using Dapper;
using RCCP.Repository.Entities;
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
    public class ImportantLandmarkListRepository
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
        public ImportantLandmarkList GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<ImportantLandmarkList>(id);
            }
        }

        public List<ImportantLandmarkList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<ImportantLandmarkList>().ToList();
            }
        }

        public List<ImportantLandmarkList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<ImportantLandmarkList>(whereCondition).ToList();
            }
        }

        public List<ImportantLandmarkList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<ImportantLandmarkList>(condition).ToList();
            }
        }

        public List<ImportantLandmarkList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<ImportantLandmarkList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(ImportantLandmarkList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(ImportantLandmarkList entityToInsert)
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
                return Conn.Delete<ImportantLandmarkList>(deviceId);
            }
        }

        public int Delete(ImportantLandmarkList entityToInsert)
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
                return Conn.DeleteList<ImportantLandmarkList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<ImportantLandmarkList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<ImportantLandmarkList>(conditions);
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
