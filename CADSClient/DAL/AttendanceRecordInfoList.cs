using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace CADS.DAL
{
	/// <summary>
	/// 数据访问类:AttendanceRecordInfoList
	/// </summary>
	public partial class AttendanceRecordInfoList
	{
		public AttendanceRecordInfoList()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "AttendanceRecordInfoList"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AttendanceRecordInfoList");
			strSql.Append(" where ID="+ID+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.AttendanceRecordInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.PersonName != null)
			{
				strSql1.Append("PersonName,");
				strSql2.Append("'"+model.PersonName+"',");
			}
			if (model.PersonID != null)
			{
				strSql1.Append("PersonID,");
				strSql2.Append("'"+model.PersonID+"',");
			}
			if (model.PersonLeader != null)
			{
				strSql1.Append("PersonLeader,");
				strSql2.Append("'"+model.PersonLeader+"',");
			}
			if (model.TimeGo != null)
			{
				strSql1.Append("TimeGo,");
				strSql2.Append("'"+model.TimeGo+"',");
			}
			if (model.TimeEnd != null)
			{
				strSql1.Append("TimeEnd,");
				strSql2.Append("'"+model.TimeEnd+"',");
			}
			if (model.IsAbsent != null)
			{
				strSql1.Append("IsAbsent,");
				strSql2.Append("'"+model.IsAbsent+"',");
			}
			if (model.Reasons != null)
			{
				strSql1.Append("Reasons,");
				strSql2.Append("'"+model.Reasons+"',");
			}
			if (model.Description != null)
			{
				strSql1.Append("Description,");
				strSql2.Append("'"+model.Description+"',");
			}
			if (model.Mark != null)
			{
				strSql1.Append("Mark,");
				strSql2.Append("'"+model.Mark+"',");
			}
			strSql.Append("insert into AttendanceRecordInfoList(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CADS.Model.AttendanceRecordInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AttendanceRecordInfoList set ");
			if (model.PersonName != null)
			{
				strSql.Append("PersonName='"+model.PersonName+"',");
			}
			else
			{
				strSql.Append("PersonName= null ,");
			}
			if (model.PersonID != null)
			{
				strSql.Append("PersonID='"+model.PersonID+"',");
			}
			else
			{
				strSql.Append("PersonID= null ,");
			}
			if (model.PersonLeader != null)
			{
				strSql.Append("PersonLeader='"+model.PersonLeader+"',");
			}
			else
			{
				strSql.Append("PersonLeader= null ,");
			}
			if (model.TimeGo != null)
			{
				strSql.Append("TimeGo='"+model.TimeGo+"',");
			}
			else
			{
				strSql.Append("TimeGo= null ,");
			}
			if (model.TimeEnd != null)
			{
				strSql.Append("TimeEnd='"+model.TimeEnd+"',");
			}
			else
			{
				strSql.Append("TimeEnd= null ,");
			}
			if (model.IsAbsent != null)
			{
				strSql.Append("IsAbsent='"+model.IsAbsent+"',");
			}
			else
			{
				strSql.Append("IsAbsent= null ,");
			}
			if (model.Reasons != null)
			{
				strSql.Append("Reasons='"+model.Reasons+"',");
			}
			else
			{
				strSql.Append("Reasons= null ,");
			}
			if (model.Description != null)
			{
				strSql.Append("Description='"+model.Description+"',");
			}
			else
			{
				strSql.Append("Description= null ,");
			}
			if (model.Mark != null)
			{
				strSql.Append("Mark='"+model.Mark+"',");
			}
			else
			{
				strSql.Append("Mark= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ID="+ model.ID+"");
			int rowsAffected=DbHelperOleDb.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AttendanceRecordInfoList ");
			strSql.Append(" where ID="+ID+"" );
			int rowsAffected=DbHelperOleDb.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AttendanceRecordInfoList ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CADS.Model.AttendanceRecordInfoList GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,PersonName,PersonID,PersonLeader,TimeGo,TimeEnd,IsAbsent,Reasons,Description,Mark ");
			strSql.Append(" from AttendanceRecordInfoList ");
			strSql.Append(" where ID="+ID+"" );
			CADS.Model.AttendanceRecordInfoList model=new CADS.Model.AttendanceRecordInfoList();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CADS.Model.AttendanceRecordInfoList DataRowToModel(DataRow row)
		{
			CADS.Model.AttendanceRecordInfoList model=new CADS.Model.AttendanceRecordInfoList();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["PersonName"]!=null)
				{
					model.PersonName=row["PersonName"].ToString();
				}
				if(row["PersonID"]!=null)
				{
					model.PersonID=row["PersonID"].ToString();
				}
				if(row["PersonLeader"]!=null)
				{
					model.PersonLeader=row["PersonLeader"].ToString();
				}
				if(row["TimeGo"]!=null)
				{
					model.TimeGo=row["TimeGo"].ToString();
				}
				if(row["TimeEnd"]!=null)
				{
					model.TimeEnd=row["TimeEnd"].ToString();
				}
				if(row["IsAbsent"]!=null)
				{
					model.IsAbsent=row["IsAbsent"].ToString();
				}
				if(row["Reasons"]!=null)
				{
					model.Reasons=row["Reasons"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Mark"]!=null)
				{
					model.Mark=row["Mark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,PersonName,PersonID,PersonLeader,TimeGo,TimeEnd,IsAbsent,Reasons,Description,Mark ");
			strSql.Append(" FROM AttendanceRecordInfoList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM AttendanceRecordInfoList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from AttendanceRecordInfoList T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

