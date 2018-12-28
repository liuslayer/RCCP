using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecDll
{
    public class Access
    {
        public static OleDbConnection oleDb = new OleDbConnection(ConfigurationManager.ConnectionStrings["connStr_local"].ConnectionString);
        public static bool Connection(ref string errorInfo) //构造函数
        {
            bool result = false;
            try
            {
                if(oleDb.State!= ConnectionState.Open)
                {
                    oleDb.Open();
                }
                result = true;
            }
            catch(Exception ex)
            {
                errorInfo="数据库连接失败！";
            }
            return result;
        }

        public static void CloseConn()
        {
            oleDb.Close();
        }
    }
}
