using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace RecDll.ole
{
    public class UserLogClass
    {
        /// <summary>
        /// 插入用户日志记录
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public static bool InsertData(UserLog log, ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return false;
            string sql = "insert into UserLog("
                + "UserLogID,"
                + "UserName,"
                + "OperationDate,"
                + "OperationTime,"
                + "Operation,"
                + "Description,"
                + "Mark)"
                + "values('"
                + log.UserLogID + "','"
                + log.UserName + "','"
                + log.OperationDate + "','"
                + log.OperationTime + "','"
                + log.Operation + "','"
                + log.Description + "','"
                + log.Mark + "')";
            //往表添加一条记录
            OleDbCommand oleDbCommand = new OleDbCommand(sql, Access.oleDb);
            int i = oleDbCommand.ExecuteNonQuery(); //返回被修改的数目
            Access.CloseConn();
            return i > 0;
        }

        /// <summary>
        /// 查询录像分页信息
        /// </summary>
        public static DataSet SelectUserLogInfo(string page, string pageSize, UserLogQueryStatement qs, ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return null;
            int i_page = int.Parse(page);
            int i_pageSize = int.Parse(pageSize);
            int exclude = (i_pageSize * (i_page - 1)) + 1;
            bool b_Conditional = false;
            string sql = "select top " + pageSize + " * from UserLog " +
                          "where id>= (select max(id) from(select top " + exclude + " id from UserLog order by id)a where";
            if (qs.Operation != null)
            {
                sql += " Operation='" + qs.Operation + "'and";
                b_Conditional = true;
            }
            if (qs.Name != null)
            {
                sql += " UserName='" + qs.Name + "'and";
                b_Conditional = true;
            }
            if (qs.StartDate != null)
            {
                sql += " OperationDate>='" + qs.StartDate + "'and";
                b_Conditional = true;
            }
            if (qs.StartTime != null)
            {
                sql += " OperationTime>='" + qs.StartTime + "'and";
                b_Conditional = true;
            }
            if (qs.EndDate != null)
            {
                sql += " OperationDate<='" + qs.EndDate + "'and";
                b_Conditional = true;
            }
            if (qs.EndTime != null)
            {
                sql += " OperationTime<='" + qs.EndTime + "'and";
                b_Conditional = true;
            }
            if (!b_Conditional)
            {
                sql = sql.Substring(0, sql.Length - 5);
            }
            else
            {
                sql = sql.Substring(0, sql.Length - 3);
            }
            sql += ")order by id";
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(sql, Access.oleDb);
            DataSet ds = new DataSet();
            oleDbDataAdapter.Fill(ds, "UserLog");
            ds.Tables["UserLog"].Columns["ID"].ColumnName = "序号";
            ds.Tables["UserLog"].Columns["UserLogID"].ColumnName = "日志编号";
            ds.Tables["UserLog"].Columns["UserName"].ColumnName = "用户名";
            ds.Tables["UserLog"].Columns["OperationDate"].ColumnName = "日期";
            ds.Tables["UserLog"].Columns["OperationTime"].ColumnName = "时间";
            ds.Tables["UserLog"].Columns["Operation"].ColumnName = "信息";
            ds.Tables["UserLog"].Columns["Description"].ColumnName = "描述";
            ds.Tables["UserLog"].Columns["Mark"].ColumnName = "备注";
            Access.CloseConn();
            return ds;
        }
        /// <summary>
        /// 获取条件查询的总记录数
        /// </summary>
        /// <param name="qs"></param>
        /// <returns></returns>
        public static int GetUserLogPageCount(UserLogQueryStatement qs, ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return -1;
            bool b_Conditional = false;
            string sql = "select count(*) from UserLog where";
            if (qs.Operation != null)
            {
                sql += " Operation='" + qs.Operation + "'and";
                b_Conditional = true;
            }
            if (qs.Name != null)
            {
                sql += " OperationName='" + qs.Name + "'and";
                b_Conditional = true;
            }
            if (qs.StartDate != null)
            {
                sql += " OperationDate>='" + qs.StartDate + "'and";
                b_Conditional = true;
            }
            if (qs.StartTime != null)
            {
                sql += " OperationTime>='" + qs.StartTime + "'and";
                b_Conditional = true;
            }
            if (qs.EndDate != null)
            {
                sql += " OperationDate<='" + qs.EndDate + "'and";
                b_Conditional = true;
            }
            if (qs.EndTime != null)
            {
                sql += " OperationTime<='" + qs.EndTime + "'and";
                b_Conditional = true;
            }
            if (!b_Conditional)
            {
                sql = sql.Substring(0, sql.Length - 5);
            }
            else
            {
                sql = sql.Substring(0, sql.Length - 3);
            }
            OleDbCommand oleDbCommand = new OleDbCommand(sql, Access.oleDb);
            int i = (int)oleDbCommand.ExecuteScalar();
            Access.CloseConn();
            return i;
        }

        /// <summary>
        /// 获取用户名列（不重复项）
        /// </summary>
        /// <returns></returns>
        public static List<string> GetUserNames(ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return null;
            List<string> userNames = new List<string>();
            string sql = "select distinct UserName from UserLog";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, Access.oleDb);
            DbDataReader dr = oleDbCommand.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    userNames.Add(dr[0].ToString());
                }
            }
            Access.CloseConn();
            return userNames;
        }

        /// <summary>
        /// 获取操作类型列（不重复项）
        /// </summary>
        /// <returns></returns>
        public static List<string> GetOperations(ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return null;
            List<string> userNames = new List<string>();
            string sql = "select distinct Operation from UserLog";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, Access.oleDb);
            DbDataReader dr = oleDbCommand.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    userNames.Add(dr[0].ToString());
                }
            }
            Access.CloseConn();
            return userNames;
        }
    }

    public class UserLog
    {
        public int ID;
        public string UserLogID;//用户日志ID
        public string UserName;//用户名
        public string OperationDate;//日期
        public string OperationTime;//时间
        public string Operation;//信息
        public string Description;//描述
        public string Mark;//备注
    }
    /// <summary>
    /// 条件查询语句结构
    /// </summary>
    public class UserLogQueryStatement
    {
        public string Operation;//操作类型
        public string Name;//用户
        public string StartDate;//开始日期
        public string StartTime;//开始时间
        public string EndDate;//结束日期
        public string EndTime;//结束时间
    }
}
