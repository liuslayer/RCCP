using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace RecDll
{
    public class RecFileClass
    {
        /// <summary>
        /// 添加录像信息开始时间
        /// </summary>
        /// <param name="recFileList"></param>
        /// <returns></returns>
        public static bool AddStartTime(RecFileList recFileList,ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo))
                return false;
            string sql = "insert into RecFileList ("
                + "CameraID,"
                + "LocationFlag,"
               + "RecName,"
               + "RecType,"
               + "RecStartDate,"
               + "RecStartTime,"
               + "RecEndDate,"
               + "RecEndTime,"
               + "RecRecFile,"
               + "UserName,"
               + "RecEventName,"
               + "RecDescription,"
               + "Mark)"
               + "values ('"
               + recFileList.CameraID + "','"
               + recFileList.LocationFlag + "','"
               + recFileList.RecName + "','"
               + recFileList.RecType + "','"
               + recFileList.RecStartDate + "','"
               + recFileList.RecStartTime + "','"
               + recFileList.RecEndDate + "','"
               + recFileList.RecEndTime + "','"
               + recFileList.RecRecFile + "','"
               + recFileList.UserName + "','"
               + recFileList.RecEventName + "','"
               + recFileList.RecDescription + "','"
               + recFileList.Mark + "'"
               + ")";
            //往表添加一条记录
            OleDbCommand oleDbCommand = new OleDbCommand(sql, Access.oleDb);
            int i = oleDbCommand.ExecuteNonQuery(); //返回被修改的数目
            Access.CloseConn();
            return i > 0;
        }
        /// <summary>
        /// 添加录像信息结束时间
        /// </summary>
        /// <param name="recName"></param>
        /// <param name="RecEndDate"></param>
        /// <param name="RecEndTime"></param>
        public static bool AddEndTime(string recName, string recEndDate, string recEndTime,ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return false;
            string sql = "update RecFileList set RecEndDate='" + recEndDate + "',RecEndTime='"+ recEndTime + "' where RecName='" + recName + "'";
            //修改录像信息
            OleDbCommand oleDbCommand = new OleDbCommand(sql, Access.oleDb);
            int i = oleDbCommand.ExecuteNonQuery();
            Access.CloseConn();
            return i > 0;
        }

        /// <summary>
        /// 查询录像分页信息
        /// </summary>
        public static DataSet SelectRecInfo(string page,string pageSize, RecQueryStatement qs,ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo )) return null;
            int i_page = int.Parse(page);
            int i_pageSize = int.Parse(pageSize);
            int exclude = (i_pageSize * (i_page - 1))+1;
            bool b_Conditional=false;
            string sql = "select top " + pageSize + " * from RecFileList " +
                          "where id>= (select max(id) from(select top " + exclude + " id from RecFileList order by id)a where";
            if (qs.CameraID!=null)
            {
                if (qs.CameraID.Count != 0)
                {
                    for (int j = 0; j < qs.CameraID.Count; j++)
                    {

                        sql += " CameraID='" + qs.CameraID[j] + "'or";
                    }
                    b_Conditional = true;
                    sql = sql.Substring(0, sql.Length - 2) + "and";
                }
            }
            if (qs.RecType!=null)
            {
                sql += " RecType='" + qs.RecType + "'and";
                b_Conditional = true;
            }
            if (qs.UserName != null)
            {
                sql += " UserName='" + qs.UserName + "'and";
                b_Conditional = true;
            }
            if (qs.RecStartDate != null)
            {
                sql += " RecStartDate>='" + qs.RecStartDate + "'and";
                b_Conditional = true;
            }
            if (qs.RecStartTime != null)
            {
                sql += " RecStartTime>='" + qs.RecStartTime + "'and";
                b_Conditional = true;
            }
            if (qs.RecEndDate != null)
            {
                sql += " RecEndDate<='" + qs.RecEndDate + "'and";
                b_Conditional = true;
            }
            if (qs.RecEndTime != null)
            {
                sql += " RecEndTime<='" + qs.RecEndTime + "'and";
                b_Conditional = true;
            }
            if (!b_Conditional)
            {
                sql=sql.Substring(0, sql.Length - 5);
            }
            else
            {
                sql=sql.Substring(0, sql.Length - 3);
            }
            sql +=")order by id";
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(sql, Access.oleDb);
            DataSet ds = new DataSet();
            oleDbDataAdapter.Fill(ds,"RecFileList");
            ds.Tables["RecFileList"].Columns["ID"].ColumnName = "序号";
            ds.Tables["RecFileList"].Columns["CameraID"].ColumnName = "设备编号";
            ds.Tables["RecFileList"].Columns["LocationFlag"].ColumnName = "标识";
            ds.Tables["RecFileList"].Columns["RecName"].ColumnName = "录像名称";
            ds.Tables["RecFileList"].Columns["RecType"].ColumnName = "录像类型";
            ds.Tables["RecFileList"].Columns["RecStartDate"].ColumnName = "开始日期";
            ds.Tables["RecFileList"].Columns["RecStartTime"].ColumnName = "开始时间";
            ds.Tables["RecFileList"].Columns["RecEndDate"].ColumnName = "结束日期";
            ds.Tables["RecFileList"].Columns["RecEndTime"].ColumnName = "结束时间";
            ds.Tables["RecFileList"].Columns["RecRecFile"].ColumnName = "录像地址";
            ds.Tables["RecFileList"].Columns["UserName"].ColumnName = "操作用户";
            ds.Tables["RecFileList"].Columns["RecEventName"].ColumnName = "事件名称";
            ds.Tables["RecFileList"].Columns["RecDescription"].ColumnName = "事件描述";
            ds.Tables["RecFileList"].Columns["Mark"].ColumnName = "备注";
            Access.CloseConn();
            return ds;
        }
        /// <summary>
        /// 获取条件查询的总记录数
        /// </summary>
        /// <param name="qs"></param>
        /// <returns></returns>
        public static int GetRecPageCount(RecQueryStatement qs,ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return -1;
            bool b_Conditional = false;
            string sql = "select count(*) from RecFileList where";
            if (qs.CameraID != null)
            {
                if(qs.CameraID.Count!=0)
                {
                    for (int j = 0; j < qs.CameraID.Count; j++)
                    {

                        sql += " CameraID='" + qs.CameraID[j] + "'or";
                    }
                    b_Conditional = true;
                    sql = sql.Substring(0, sql.Length - 2) + "and";
                }
            }
            if (qs.RecType != null)
            {
                sql += " RecType='" + qs.RecType + "'and";
                b_Conditional = true;
            }
            if (qs.UserName != null)
            {
                sql += " UserName='" + qs.UserName + "'and";
                b_Conditional = true;
            }
            if (qs.RecStartDate != null)
            {
                sql += " RecStartDate>='" + qs.RecStartDate + "'and";
                b_Conditional = true;
            }
            if (qs.RecStartTime != null)
            {
                sql += " RecStartTime>='" + qs.RecStartTime + "'and";
                b_Conditional = true;
            }
            if (qs.RecEndDate != null)
            {
                sql += " RecStartDate<='" + qs.RecEndDate + "'and";
                b_Conditional = true;
            }
            if (qs.RecEndTime != null)
            {
                sql += " RecStartTime<='" + qs.RecEndTime + "'and";
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
            if (!Access.Connection(ref errorInfo))
                return null;
            List<string> userNames = new List<string>();
            string sql = "select distinct UserName from RecFileList";
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


    public class RecFileList
    {
        public int ID;
        public string CameraID;
        public string LocationFlag;
        public string RecName;
        public string RecType;
        public string RecStartDate;
        public string RecStartTime;
        public string RecEndDate;
        public string RecEndTime;
        public string RecRecFile;
        public string UserName;
        public string RecEventName;
        public string RecDescription;
        public string Mark;
        public RecFileList() { }
        public RecFileList(string cameraID,string locationFlag,
            string recName,string rectype,string recStartDate,
            string recStartTime,string recEndDate,string recEndTime,
            string recRecFile,string userName,string recEventName,
            string recDescription,string mark)
        {
            CameraID = cameraID;
            LocationFlag = locationFlag;
            RecName = recName;
            RecType = rectype;
            RecStartDate = recStartDate;
            RecStartTime = recStartTime;
            RecEndDate = recEndDate;
            RecEndTime = recEndTime;
            RecRecFile = recRecFile;
            UserName = userName;
            RecEventName = recEventName;
            RecDescription = recDescription;
            Mark = mark;
        }
    }
    /// <summary>
    /// 条件查询语句结构
    /// </summary>
    public class RecQueryStatement
    {
        public List<string> CameraID;//摄像机ID(通道名称)
        public string RecType;//录像类型
        public string UserName;//用户
        public string RecStartDate;//开始日期
        public string RecStartTime;//开始时间
        public string RecEndDate;//结束日期
        public string RecEndTime;//结束时间
    }

}
