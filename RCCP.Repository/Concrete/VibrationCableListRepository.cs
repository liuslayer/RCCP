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
    public class VibrationCableListRepository
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
        public VibrationCableList GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<VibrationCableList>(id);
            }
        }

        public List<VibrationCableList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<VibrationCableList>().ToList();
            }
        }

        public List<VibrationCableList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<VibrationCableList>(whereCondition).ToList();
            }
        }

        public List<VibrationCableList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<VibrationCableList>(condition).ToList();
            }
        }

        public List<VibrationCableList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<VibrationCableList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(VibrationCableList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(VibrationCableList entityToInsert)
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
                return Conn.Delete<VibrationCableList>(deviceId);
            }
        }

        public int Delete(VibrationCableList entityToInsert)
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
                return Conn.DeleteList<VibrationCableList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<VibrationCableList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<VibrationCableList>(conditions);
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
