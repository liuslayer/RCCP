using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace RecDll.ole
{
    public class AutoRecInfoClass
    {
        /// <summary>
        /// 添加自动录像信息
        /// </summary>
        /// <param name="autoRecInfoList"></param>
        public static bool Add(AutoRecInfoList autoRecInfoList,ref string errorInfo)
        {
            if(!Access.Connection(ref errorInfo))return false;
            string sql = "insert into AutoRecInfoList ("
                + "DeviceID,"
                + "StartDate,"
                + "StartWeek,"
                + "StartTime,"
                + "EndDate,"
                + "EndWeek,"
                + "EndTime,"
                + "AutoRecFlag,"
                + "AutoRecMode,"
                + "Description,"
                + "Mark)"
                + "values ('"
                + autoRecInfoList.DeviceID + "','"
                + autoRecInfoList.StartDate + "','"
                + autoRecInfoList.StartWeek + "','"
                + autoRecInfoList.StartTime + "','"
                + autoRecInfoList.EndDate + "','"
                + autoRecInfoList.EndWeek + "','"
                + autoRecInfoList.EndTime + "','"
                + autoRecInfoList.AutoRecFlag + "','"
                + autoRecInfoList.AutoRecMode + "','"
                + autoRecInfoList.Description + "','"
                +autoRecInfoList.Mark+"')";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, Access.oleDb);
            int i = oleDbCommand.ExecuteNonQuery();//
            return i > 0;
        }

        /// <summary>
        /// 搜索所有录像设置信息
        /// </summary>
        public static DataSet SelectAll(ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return null;
            string sql = "select * from AutoRecInfoList";
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(sql, Access.oleDb);
            DataSet ds = new DataSet();
            oleDbDataAdapter.Fill(ds, "AutoRecInfoList");
            ds.Tables["AutoRecInfoList"].Columns["ID"].ColumnName = "序号";
            ds.Tables["AutoRecInfoList"].Columns["DeviceID"].ColumnName = "设备编号";
            ds.Tables["AutoRecInfoList"].Columns["StartDate"].ColumnName = "启动日期";
            ds.Tables["AutoRecInfoList"].Columns["StartWeek"].ColumnName = "启动星期";
            ds.Tables["AutoRecInfoList"].Columns["StartTime"].ColumnName = "启动时间";
            ds.Tables["AutoRecInfoList"].Columns["EndDate"].ColumnName = "结束日期";
            ds.Tables["AutoRecInfoList"].Columns["EndWeek"].ColumnName = "结束星期";
            ds.Tables["AutoRecInfoList"].Columns["EndTime"].ColumnName = "结束时间";
            ds.Tables["AutoRecInfoList"].Columns["AutoRecFlag"].ColumnName = "是否录像";
            ds.Tables["AutoRecInfoList"].Columns["AutoRecMode"].ColumnName = "录像模式";
            ds.Tables["AutoRecInfoList"].Columns["Description"].ColumnName = "描述";
            ds.Tables["AutoRecInfoList"].Columns["Mark"].ColumnName = "标记";
            Access.CloseConn();
            return ds;
        }

        /// <summary>
        /// 删除录像设置信息
        /// </summary>
        /// <param name="ID"></param>
        public static bool Delete(int ID,ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return false;
            string sql = "delete from AutoRecInfoList where ID="+ID;
            OleDbCommand oleDbCommand = new OleDbCommand(sql, Access.oleDb);
            int i=oleDbCommand.ExecuteNonQuery();
            Access.CloseConn();
            return i > 0;
        }

    }

    public class AutoRecInfoList
    {
        public int ID;
        public string DeviceID;
        public string StartDate;
        public string StartWeek;
        public string StartTime;
        public string EndDate;
        public string EndWeek;
        public string EndTime;
        public string AutoRecFlag;
        public string AutoRecMode;
        public string Description;
        public string Mark;
    }
}
