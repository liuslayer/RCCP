using RecDll;
using System.Data;
using System.Data.OleDb;

namespace AccessOperation.ole
{
    public class RecPathClass
    {
        public static void Add()
        {

        }

        public static bool Update(RecPathList recPathList,ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return false;
            DataSet ds = SelectAll(ref errorInfo);
            if (ds == null) return false;
            string ID = "";
            for(int i=0;i<ds.Tables["RecPath"].Rows.Count;i++)
            {
                if (ds.Tables["RecPath"].Rows[i]["Usefor"].ToString() == recPathList.Userfor)
                    ID = ds.Tables["RecPath"].Rows[i]["ID"].ToString();
            }
            string sql= "update RecPath set Disk='"+recPathList.Disk+ "',CapacityClear='"+recPathList.CapacityClear+"'where ID="+ID;
            OleDbCommand oleDbCommand = new OleDbCommand(sql, Access.oleDb);
            if (!Access.Connection(ref errorInfo)) return false;
            int j=oleDbCommand.ExecuteNonQuery();
            Access.CloseConn();
            return j > 0;
        }

        public static DataSet SelectAll(ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return null;
            string sql = "select * from RecPath";
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(sql, Access.oleDb);
            DataSet ds = new DataSet();
            oleDbDataAdapter.Fill(ds, "RecPath");
            Access.CloseConn();
            return ds;
        }
        
    }

    public class RecPathList
    {
        public string ID;
        public string RecName;
        public string Disk;
        public string FileName;
        public string CapacityAlarm;
        public string CapacityClear;
        public string Userfor;
        public string Description;
        public string Mark;
    }
}
