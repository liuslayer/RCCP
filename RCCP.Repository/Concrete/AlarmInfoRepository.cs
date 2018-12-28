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
    public class AlarmInfoRepository
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

        public AlarmInfo GetEntityById(int id)
        {
            using (Conn)
            {
                return Conn.Get<AlarmInfo>(id);
            }
        }

        public List<AlarmInfo> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<AlarmInfo>().ToList();
            }
        }

        public List<AlarmInfo> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<AlarmInfo>(whereCondition).ToList();
            }
        }

        public List<AlarmInfo> GetListWithCondition(string condition, object parameters)
        {
            using (Conn)
            {
                return Conn.GetList<AlarmInfo>(condition, parameters).ToList();
            }
        }

        public List<AlarmInfo> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<AlarmInfo>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public long Insert(AlarmInfo entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<long>(entityToInsert);
            }
        }

        public int Update(AlarmInfo entityToInsert)
        {
            using (Conn)
            {
                return Conn.Update(entityToInsert);
            }
        }

        public int Delete(long deviceId)
        {
            using (Conn)
            {
                return Conn.Delete<AlarmInfo>(deviceId);
            }
        }

        public int Delete(AlarmInfo entityToInsert)
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
                return Conn.DeleteList<AlarmInfo>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<AlarmInfo>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<AlarmInfo>(conditions);
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
