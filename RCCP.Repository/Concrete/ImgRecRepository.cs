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
    public class ImgRecRepository
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

        public ImgRec GetEntityById(int id)
        {
            using (Conn)
            {
                return Conn.Get<ImgRec>(id);
            }
        }

        public List<ImgRec> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<ImgRec>().ToList();
            }
        }

        public List<ImgRec> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<ImgRec>(whereCondition).ToList();
            }
        }

        public List<ImgRec> GetListWithCondition(string condition, object parameters)
        {
            using (Conn)
            {
                return Conn.GetList<ImgRec>(condition, parameters).ToList();
            }
        }

        public List<ImgRec> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<ImgRec>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public int Insert(ImgRec entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<int>(entityToInsert);
            }
        }

        public int Update(ImgRec entityToInsert)
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
                return Conn.Delete<ImgRec>(deviceId);
            }
        }

        public int Delete(ImgRec entityToInsert)
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
                return Conn.DeleteList<ImgRec>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<ImgRec>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<ImgRec>(conditions);
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
