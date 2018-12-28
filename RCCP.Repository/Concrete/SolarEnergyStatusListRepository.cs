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
    public class SolarEnergyStatusListRepository
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

        public SolarEnergyStatusList GetEntityById(int id)
        {
            using (Conn)
            {
                return Conn.Get<SolarEnergyStatusList>(id);
            }
        }

        public List<SolarEnergyStatusList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<SolarEnergyStatusList>().ToList();
            }
        }

        public List<SolarEnergyStatusList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<SolarEnergyStatusList>(whereCondition).ToList();
            }
        }

        public List<SolarEnergyStatusList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<SolarEnergyStatusList>(condition).ToList();
            }
        }

        public List<SolarEnergyStatusList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<SolarEnergyStatusList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public int Insert(SolarEnergyStatusList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<int>(entityToInsert);
            }
        }

        public int Update(SolarEnergyStatusList entityToInsert)
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
                return Conn.Delete<SolarEnergyStatusList>(deviceId);
            }
        }

        public int Delete(SolarEnergyStatusList entityToInsert)
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
                return Conn.DeleteList<SolarEnergyStatusList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<SolarEnergyStatusList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<SolarEnergyStatusList>(conditions);
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
