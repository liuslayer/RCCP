﻿using System;
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
    public class CameraStatusListRepository
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

        public CameraStatusList GetEntityById(int id)
        {
            using (Conn)
            {
                return Conn.Get<CameraStatusList>(id);
            }
        }

        public List<CameraStatusList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<CameraStatusList>().ToList();
            }
        }

        public List<CameraStatusList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<CameraStatusList>(whereCondition).ToList();
            }
        }

        public List<CameraStatusList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<CameraStatusList>(condition).ToList();
            }
        }

        public List<CameraStatusList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<CameraStatusList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public int Insert(CameraStatusList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<int>(entityToInsert);
            }
        }

        public int Update(CameraStatusList entityToInsert)
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
                return Conn.Delete<CameraStatusList>(deviceId);
            }
        }

        public int Delete(CameraStatusList entityToInsert)
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
                return Conn.DeleteList<CameraStatusList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<CameraStatusList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<CameraStatusList>(conditions);
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
