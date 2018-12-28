using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecDll
{
    public class RecPictureClass
    {
        public static bool Add(RecPictureList recPictureList,ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return false;
            string sql = "insert into RecPictureList ("
                + "CameraID,"
                + "RecPictureName,"
               + "RecPictureDate,"
               + "RecPictureTime,"
               + "RecPictureFile,"
               + "PictureType,"
               + "UserName,"
               + "PictureEventName,"
               + "Description,"
               + "Mark)"
               + "values ('"
               + recPictureList.CameraID + "','"
               + recPictureList.RecPictureName + "','"
               + recPictureList.RecPictureDate + "','"
               + recPictureList.RecPictureTime + "','"
               + recPictureList.RecPictureFile + "','"
               + recPictureList.PictureType + "','"
               + recPictureList.UserName + "','"
               + recPictureList.PictureEventName + "','"
               + recPictureList.Description + "','"
               + recPictureList.Mark + "'"
               + ")";
            //往表添加一条记录
            OleDbCommand oleDbCommand = new OleDbCommand(sql, Access.oleDb);
            int i = oleDbCommand.ExecuteNonQuery(); //返回被修改的数目
            return i > 0;
        }

        /// <summary>
        /// 查询录像分页信息
        /// </summary>
        public static DataSet SelectPictureInfo(string page, string pageSize, PicQueryStatement qs, ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return null;
            int i_page = int.Parse(page);
            int i_pageSize = int.Parse(pageSize);
            int exclude = (i_pageSize * (i_page - 1)) + 1;
            bool b_Conditional = false;
            string sql = "select top " + pageSize + " * from RecPictureList " +
                          "where id>= (select max(id) from(select top " + exclude + " id from RecPictureList order by id)a where";
            if (qs.CameraID != null)
            {
                if(qs.CameraID.Count!=0)
                {
                    for (int j = 0; j < qs.CameraID.Count; j++)
                    {
                        sql += " CameraID='" + qs.CameraID[j] + "'or";
                    }
                    b_Conditional = true;
                    sql=sql.Substring(0, sql.Length - 2)+"and";
                }
            }
            if (qs.UserName != null)
            {
                sql += " UserName='" + qs.UserName + "'and";
                b_Conditional = true;
            }
            if (qs.RecStartDate != null)
            {
                sql += " RecPictureDate>='" + qs.RecStartDate + "'and";
                b_Conditional = true;
            }
            if (qs.RecStartTime != null)
            {
                sql += " RecPictureTime>='" + qs.RecStartTime + "'and";
                b_Conditional = true;
            }
            if (qs.RecEndDate != null)
            {
                sql += " RecPictureDate<='" + qs.RecEndDate + "'and";
                b_Conditional = true;
            }
            if (qs.RecEndTime != null)
            {
                sql += " RecPictureTime<='" + qs.RecEndTime + "'and";
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
            oleDbDataAdapter.Fill(ds, "RecPictureList");
            ds.Tables["RecPictureList"].Columns["ID"].ColumnName = "序号";
            ds.Tables["RecPictureList"].Columns["CameraID"].ColumnName = "设备编号";
            ds.Tables["RecPictureList"].Columns["RecPictureName"].ColumnName = "截图名称";
            ds.Tables["RecPictureList"].Columns["RecPictureDate"].ColumnName = "截图日期";
            ds.Tables["RecPictureList"].Columns["RecPictureTime"].ColumnName = "截图时间";
            ds.Tables["RecPictureList"].Columns["RecPictureFile"].ColumnName = "截图地址";
            ds.Tables["RecPictureList"].Columns["PictureType"].ColumnName = "图片类型";
            ds.Tables["RecPictureList"].Columns["UserName"].ColumnName = "操作用户";
            ds.Tables["RecPictureList"].Columns["PictureEventName"].ColumnName = "事件名称";
            ds.Tables["RecPictureList"].Columns["Description"].ColumnName = "事件描述";
            ds.Tables["RecPictureList"].Columns["Mark"].ColumnName = "备注";
            return ds;
        }

        /// <summary>
        /// 获取条件查询的总记录数
        /// </summary>
        /// <param name="qs"></param>
        /// <returns></returns>
        public static int GetPicPageCount(PicQueryStatement qs,ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return -1;
            bool b_Conditional = false;
            string sql = "select count(*) from RecPictureList where";
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
            if (qs.UserName != null)
            {
                sql += " UserName='" + qs.UserName + "'and";
                b_Conditional = true;
            }
            if (qs.RecStartDate != null)
            {
                sql += " RecPictureDate>='" + qs.RecStartDate + "'and";
                b_Conditional = true;
            }
            if (qs.RecStartTime != null)
            {
                sql += " RecPictureTime>='" + qs.RecStartTime + "'and";
                b_Conditional = true;
            }
            if (qs.RecEndDate != null)
            {
                sql += " RecPictureDate<='" + qs.RecEndDate + "'and";
                b_Conditional = true;
            }
            if (qs.RecEndTime != null)
            {
                sql += " RecPictureTime<='" + qs.RecEndTime + "'and";
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
            return i;
        }
        /// <summary>
        /// 获取用户名列（不重复项）
        /// </summary>
        /// <returns></returns>
        public static List<string> GetUserNames( ref string errorInfo)
        {
            if (!Access.Connection(ref errorInfo)) return null;
            List<string> userNames=new List<string>();
            string sql = "select distinct UserName from RecPictureList";
            OleDbCommand oleDbCommand = new OleDbCommand(sql, Access.oleDb);
            DbDataReader dr=oleDbCommand.ExecuteReader();
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    userNames.Add(dr[0].ToString());
                }
            }
            return userNames;
        }
    }

    public class RecPictureList
    {
        public int ID;
        public string CameraID;
        public string RecPictureName;
        public string RecPictureDate;
        public string RecPictureTime;
        public string RecPictureFile;
        public string PictureType;
        public string UserName;
        public string PictureEventName;
        public string Description;
        public string Mark;
        public RecPictureList() { }
        public RecPictureList(string cameraID,string recPictureName,
            string recPictureDate,string recPictureTime,string recPictureFile,
            string pictureType,string userName,string pictureEventName,
            string description,string mark)
        {
            CameraID = cameraID;
            RecPictureName = recPictureName;
            RecPictureDate = recPictureDate;
            RecPictureTime = recPictureTime;
            RecPictureFile = recPictureFile;
            PictureType = pictureType;
            UserName = userName;
            PictureEventName = pictureEventName;
            Description = description;
            Mark = mark;
        }
    }

    /// <summary>
    /// 条件查询语句结构
    /// </summary>
    public class PicQueryStatement
    {
        public List<string> CameraID;//摄像机ID(通道名称)
        public string UserName;//用户
        public string RecStartDate;//开始日期
        public string RecStartTime;//开始时间
        public string RecEndDate;//结束日期
        public string RecEndTime;//结束时间
    }

}
