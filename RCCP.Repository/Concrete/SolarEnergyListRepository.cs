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
    public class SolarEnergyListRepository
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

        public SolarEnergyList GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<SolarEnergyList>(id);
            }
        }

        public List<SolarEnergyList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<SolarEnergyList>().ToList();
            }
        }

        public List<SolarEnergyList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<SolarEnergyList>(whereCondition).ToList();
            }
        }

        public List<SolarEnergyList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<SolarEnergyList>(condition).ToList();
            }
        }

        public List<SolarEnergyList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<SolarEnergyList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(SolarEnergyList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(SolarEnergyList entityToInsert)
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
                return Conn.Delete<SolarEnergyList>(deviceId);
            }
        }

        public int Delete(SolarEnergyList entityToInsert)
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
                return Conn.DeleteList<SolarEnergyList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<SolarEnergyList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<SolarEnergyList>(conditions);
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
