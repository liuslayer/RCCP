﻿        using Dapper;
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
    public class ArmAndDisArmListRepository
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

        public ArmAndDisarmList GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<ArmAndDisarmList>(id);
            }
        }

        public List<ArmAndDisarmList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<ArmAndDisarmList>().ToList();
            }
        }

        public List<ArmAndDisarmList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<ArmAndDisarmList>(whereCondition).ToList();
            }
        }

        public List<ArmAndDisarmList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<ArmAndDisarmList>(condition).ToList();
            }
        }

        public List<ArmAndDisarmList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<ArmAndDisarmList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(ArmAndDisarmList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(ArmAndDisarmList entityToInsert)
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
                return Conn.Delete<ArmAndDisarmList>(deviceId);
            }
        }

        public int Delete(ArmAndDisarmList entityToInsert)
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
                return Conn.DeleteList<ArmAndDisarmList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<ArmAndDisarmList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<ArmAndDisarmList>(conditions);
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
