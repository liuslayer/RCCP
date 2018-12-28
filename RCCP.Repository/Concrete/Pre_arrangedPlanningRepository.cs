using Dapper;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RCCP.Repository.Concrete
{
    public class Pre_arrangedPlanningRepository
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

        public Pre_arrangedPlanning GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<Pre_arrangedPlanning>(id);
            }
        }

        public List<Pre_arrangedPlanning> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<Pre_arrangedPlanning>().ToList();
            }
        }

        public List<Pre_arrangedPlanning> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<Pre_arrangedPlanning>(whereCondition).ToList();
            }
        }

        public List<Pre_arrangedPlanning> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<Pre_arrangedPlanning>(condition).ToList();
            }
        }

        public List<Pre_arrangedPlanning> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<Pre_arrangedPlanning>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(Pre_arrangedPlanning entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(Pre_arrangedPlanning entityToInsert)
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
                return Conn.Delete<Pre_arrangedPlanning>(deviceId);
            }
        }

        public int Delete(Pre_arrangedPlanning entityToInsert)
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
                return Conn.DeleteList<Pre_arrangedPlanning>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<Pre_arrangedPlanning>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<Pre_arrangedPlanning>(conditions);
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
