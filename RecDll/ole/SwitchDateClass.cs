using RecDll;
using System.Data;
using System.Data.OleDb;

namespace AccessOperation.ole
{
    public class SwitchDateClass
    {
        public static bool Add(SwitchDateList switchDateList,ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return false;
            string sql = "insert into SwitchDateList ("
                + "DateID,"
                + "DeviceID,"
                + "StartDate,"
                + "StartWeek,"
                + "StartTime,"
                + "EndDate,"
                + "EndWeek,"
                + "EndTime,"
                + "Mark,"
                + "Description,"
                + "SwitchStatus)"
                + "values ('"
                + switchDateList.DateID + "','"
                + switchDateList.DeviceID + "','"
                + switchDateList.StartDate + "','"
                + switchDateList.StartWeek + "','"
                + switchDateList.StartTime + "','"
                + switchDateList.EndDate + "','"
                + switchDateList.EndWeek + "','"
                + switchDateList.EndTime + "','"
                + switchDateList.Mark + "','"
                + switchDateList.Description + "','"
                + switchDateList.SwitchStatus + "')";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, Access.oleDb);
            int i = oleDbCommand.ExecuteNonQuery();//
            return i > 0;
        }
        public static DataSet SelectAll(ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return null;
            string sql = "select * from SwitchDateList";
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(sql, Access.oleDb);
            DataSet ds = new DataSet();
            oleDbDataAdapter.Fill(ds, "SwitchDateList");
            Access.CloseConn();
            return ds;
        }
        /// <summary>
        /// 删除开关量设置信息
        /// </summary>
        /// <param name="ID"></param>
        public static bool Delete(int ID,ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return false;
            string sql = "delete from SwitchDateList where ID=" + ID;
            OleDbCommand oleDbCommand = new OleDbCommand(sql, Access.oleDb);
            int i = oleDbCommand.ExecuteNonQuery();
            Access.CloseConn();
            return i > 0;
        }
    }

    public class SwitchDateList
    {
        public string ID;
        public string DateID;
        public string DeviceID;
        public string TimeType;
        public string StartDate;
        public string StartWeek;
        public string StartTime;
        public string EndDate;
        public string EndWeek;
        public string EndTime;
        public string Mark;
        public string Description;
        public string SwitchStatus;
    }
}
