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
    public class VideoRecRepository
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

        public VideoRec GetEntityById(int id)
        {
            using (Conn)
            {
                return Conn.Get<VideoRec>(id);
            }
        }

        public List<VideoRec> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<VideoRec>().ToList();
            }
        }

        public List<VideoRec> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<VideoRec>(whereCondition).ToList();
            }
        }

        public List<VideoRec> GetListWithCondition(string condition, object parameters)
        {
            using (Conn)
            {
                return Conn.GetList<VideoRec>(condition, parameters).ToList();
            }
        }

        public List<VideoRec> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<VideoRec>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public int Insert(VideoRec entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<int>(entityToInsert);
            }
        }

        public int Update(VideoRec entityToInsert)
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
                return Conn.Delete<VideoRec>(deviceId);
            }
        }

        public int Delete(VideoRec entityToInsert)
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
                return Conn.DeleteList<VideoRec>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<VideoRec>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<VideoRec>(conditions);
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
