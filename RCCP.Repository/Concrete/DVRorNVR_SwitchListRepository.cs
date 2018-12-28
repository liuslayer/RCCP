using Dapper;
using RCCP.Repository.Entities.StaticEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RCCP.Repository.Concrete
{
    public class DVRorNVR_SwitchListRepository
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

        public DVRorNVR_SwitchList GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<DVRorNVR_SwitchList>(id);
            }
        }

        public List<DVRorNVR_SwitchList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<DVRorNVR_SwitchList>().ToList();
            }
        }

        public List<DVRorNVR_SwitchList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<DVRorNVR_SwitchList>(whereCondition).ToList();
            }
        }

        public List<DVRorNVR_SwitchList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<DVRorNVR_SwitchList>(condition).ToList();
            }
        }

        public List<DVRorNVR_SwitchList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<DVRorNVR_SwitchList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(DVRorNVR_SwitchList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(DVRorNVR_SwitchList entityToInsert)
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
                return Conn.Delete<DVRorNVR_SwitchList>(deviceId);
            }
        }

        public int Delete(DVRorNVR_SwitchList entityToInsert)
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
                return Conn.DeleteList<DVRorNVR_SwitchList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<DVRorNVR_SwitchList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<DVRorNVR_SwitchList>(conditions);
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
