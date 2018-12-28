using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace RecDll.ole
{
    public class RunLogClass
    {
        /// <summary>
        /// 插入操作日志记录
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public static bool InsertData(RunLog log, ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return false;
            string sql = "insert into RunLog("
                + "LogType,"
                + "IsAbnormal,"
                + "Date,"
                + "Time,"
                + "Operation,"
                + "Description,"
                + "Mark)"
                + "values('"
                + log.LogType + "','"
                + log.IsAbnormal + "','"
                + log.Date + "','"
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
        public static DataSet SelectRunLogInfo(string page, string pageSize, RunLogQueryStatement qs, ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return null;
            int i_page = int.Parse(page);
            int i_pageSize = int.Parse(pageSize);
            int exclude = (i_pageSize * (i_page - 1)) + 1;
            bool b_Conditional = false;
            string sql = "select top " + pageSize + " * from RunLog " +
                          "where id>= (select max(id) from(select top " + exclude + " id from RunLog order by id)a where";
            if (qs.Operation != null)
            {
                sql += " Operation='" + qs.Operation + "'and";
                b_Conditional = true;
            }
            if (qs.IsAbnormal != null)
            {
                sql += " IsAbnormal='" + qs.IsAbnormal + "'and";
                b_Conditional = true;
            }
            if (qs.StartDate != null)
            {
                sql += " Date>='" + qs.StartDate + "'and";
                b_Conditional = true;
            }
            if (qs.StartTime != null)
            {
                sql += " Time>='" + qs.StartTime + "'and";
                b_Conditional = true;
            }
            if (qs.EndDate != null)
            {
                sql += " Date<='" + qs.EndDate + "'and";
                b_Conditional = true;
            }
            if (qs.EndTime != null)
            {
                sql += " Time<='" + qs.EndTime + "'and";
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
            oleDbDataAdapter.Fill(ds, "RunLog");
            ds.Tables["RunLog"].Columns["ID"].ColumnName = "序号";
            ds.Tables["RunLog"].Columns["LogType"].ColumnName = "运行类型";
            ds.Tables["RunLog"].Columns["IsAbnormal"].ColumnName = "是否异常";
            ds.Tables["RunLog"].Columns["Date"].ColumnName = "日期";
            ds.Tables["RunLog"].Columns["Time"].ColumnName = "时间";
            ds.Tables["RunLog"].Columns["Operation"].ColumnName = "信息";
            ds.Tables["RunLog"].Columns["Description"].ColumnName = "描述";
            ds.Tables["RunLog"].Columns["Mark"].ColumnName = "备注";
            Access.CloseConn();
            return ds;
        }
        /// <summary>
        /// 获取条件查询的总记录数
        /// </summary>
        /// <param name="qs"></param>
        /// <returns></returns>
        public static int GetRunLogPageCount(RunLogQueryStatement qs, ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return -1;
            bool b_Conditional = false;
            string sql = "select count(*) from RunLog where";
            if (qs.Operation != null)
            {
                sql += " Operation='" + qs.Operation + "'and";
                b_Conditional = true;
            }
            if (qs.IsAbnormal != null)
            {
                sql += " IsAbnormal='" + qs.IsAbnormal + "'and";
                b_Conditional = true;
            }
            if (qs.StartDate != null)
            {
                sql += " Date>='" + qs.StartDate + "'and";
                b_Conditional = true;
            }
            if (qs.StartTime != null)
            {
                sql += " Time>='" + qs.StartTime + "'and";
                b_Conditional = true;
            }
            if (qs.EndDate != null)
            {
                sql += " Date<='" + qs.EndDate + "'and";
                b_Conditional = true;
            }
            if (qs.EndTime != null)
            {
                sql += " Time<='" + qs.EndTime + "'and";
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
        /// 获取操作类型列（不重复项）
        /// </summary>
        /// <returns></returns>
        public static List<string> GetOperations( ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return null;
            List<string> userNames = new List<string>();
            string sql = "select distinct Operation from RunLog";
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

    public class RunLog
    {
        public int ID;
        public string LogType;//运行类型
        public string IsAbnormal;//是否异常
        public string Date;//日期
        public string Time;//时间
        public string Operation;//日志信息
        public string Description;//描述
        public string Mark;//备注
    }
    /// <summary>
    /// 条件查询语句结构
    /// </summary>
    public class RunLogQueryStatement
    {
        public string Operation;//日志类型
        public string IsAbnormal;//是否异常
        public string StartDate;//开始日期
        public string StartTime;//开始时间
        public string EndDate;//结束日期
        public string EndTime;//结束时间
    }
}
