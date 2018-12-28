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
    public class PersonnelInformationListRepository
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
        public PersonnelInformationList GetEntityById(Guid id)
        {
            using (Conn)
            {
                return Conn.Get<PersonnelInformationList>(id);
            }
        }

        public List<PersonnelInformationList> GetList()
        {
            using (Conn)
            {
                return Conn.GetList<PersonnelInformationList>().ToList();
            }
        }

        public List<PersonnelInformationList> GetListWithCondition(object whereCondition)
        {
            using (Conn)
            {
                return Conn.GetList<PersonnelInformationList>(whereCondition).ToList();
            }
        }

        public List<PersonnelInformationList> GetListWithCondition(string condition)
        {
            using (Conn)
            {
                return Conn.GetList<PersonnelInformationList>(condition).ToList();
            }
        }

        public List<PersonnelInformationList> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby)
        {
            using (Conn)
            {
                return Conn.GetListPaged<PersonnelInformationList>(pageNumber, rowsPerPage, conditions, orderby).ToList();
            }
        }

        public Guid Insert(PersonnelInformationList entityToInsert)
        {
            using (Conn)
            {
                return Conn.Insert<Guid>(entityToInsert);
            }
        }

        public int Update(PersonnelInformationList entityToInsert)
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
                return Conn.Delete<PersonnelInformationList>(deviceId);
            }
        }

        public int Delete(PersonnelInformationList entityToInsert)
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
                return Conn.DeleteList<PersonnelInformationList>(whereConditions);
            }
        }

        public int DeleteList(string conditions)
        {
            using (Conn)
            {
                return Conn.DeleteList<PersonnelInformationList>(conditions);
            }
        }

        public int RecordCount(string conditions = "")
        {
            using (Conn)
            {
                return Conn.RecordCount<PersonnelInformationList>(conditions);
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
