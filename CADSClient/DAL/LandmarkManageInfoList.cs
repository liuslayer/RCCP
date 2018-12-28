using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace CADS.DAL
{
	/// <summary>
	/// 数据访问类:LandmarkManageInfoList
	/// </summary>
	public partial class LandmarkManageInfoList
	{
		public LandmarkManageInfoList()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string LandmarkID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from LandmarkManageInfoList");
			strSql.Append(" where LandmarkID='"+LandmarkID+"' ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.LandmarkManageInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.LandmarkID != null)
			{
				strSql1.Append("LandmarkID,");
				strSql2.Append("'"+model.LandmarkID+"',");
			}
			if (model.OrganizationName != null)
			{
				strSql1.Append("OrganizationName,");
				strSql2.Append("'"+model.OrganizationName+"',");
			}
			if (model.AdminDivision != null)
			{
				strSql1.Append("AdminDivision,");
				strSql2.Append("'"+model.AdminDivision+"',");
			}
			if (model.LandmarkName != null)
			{
				strSql1.Append("LandmarkName,");
				strSql2.Append("'"+model.LandmarkName+"',");
			}
			if (model.LandmarkType != null)
			{
				strSql1.Append("LandmarkType,");
				strSql2.Append("'"+model.LandmarkType+"',");
			}
			if (model.Unit != null)
			{
				strSql1.Append("Unit,");
				strSql2.Append("'"+model.Unit+"',");
			}
			if (model.QTY != null)
			{
				strSql1.Append("QTY,");
				strSql2.Append("'"+model.QTY+"',");
			}
			if (model.LandmarkDescription != null)
			{
				strSql1.Append("LandmarkDescription,");
				strSql2.Append("'"+model.LandmarkDescription+"',");
			}
			if (model.Mark != null)
			{
				strSql1.Append("Mark,");
				strSql2.Append("'"+model.Mark+"',");
			}
			strSql.Append("insert into LandmarkManageInfoList(");
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
		public bool Update(CADS.Model.LandmarkManageInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LandmarkManageInfoList set ");
			if (model.OrganizationName != null)
			{
				strSql.Append("OrganizationName='"+model.OrganizationName+"',");
			}
			else
			{
				strSql.Append("OrganizationName= null ,");
			}
			if (model.AdminDivision != null)
			{
				strSql.Append("AdminDivision='"+model.AdminDivision+"',");
			}
			else
			{
				strSql.Append("AdminDivision= null ,");
			}
			if (model.LandmarkName != null)
			{
				strSql.Append("LandmarkName='"+model.LandmarkName+"',");
			}
			else
			{
				strSql.Append("LandmarkName= null ,");
			}
			if (model.LandmarkType != null)
			{
				strSql.Append("LandmarkType='"+model.LandmarkType+"',");
			}
			else
			{
				strSql.Append("LandmarkType= null ,");
			}
			if (model.Unit != null)
			{
				strSql.Append("Unit='"+model.Unit+"',");
			}
			else
			{
				strSql.Append("Unit= null ,");
			}
			if (model.QTY != null)
			{
				strSql.Append("QTY='"+model.QTY+"',");
			}
			else
			{
				strSql.Append("QTY= null ,");
			}
			if (model.LandmarkDescription != null)
			{
				strSql.Append("LandmarkDescription='"+model.LandmarkDescription+"',");
			}
			else
			{
				strSql.Append("LandmarkDescription= null ,");
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
			strSql.Append(" where LandmarkID='"+ model.LandmarkID+"' ");
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
		public bool Delete(string LandmarkID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LandmarkManageInfoList ");
			strSql.Append(" where LandmarkID='"+LandmarkID+"' " );
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
		public bool DeleteList(string LandmarkIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LandmarkManageInfoList ");
			strSql.Append(" where LandmarkID in ("+LandmarkIDlist + ")  ");
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
		public CADS.Model.LandmarkManageInfoList GetModel(string LandmarkID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,LandmarkID,OrganizationName,AdminDivision,LandmarkName,LandmarkType,Unit,QTY,LandmarkDescription,Mark ");
			strSql.Append(" from LandmarkManageInfoList ");
			strSql.Append(" where LandmarkID='"+LandmarkID+"' " );
			CADS.Model.LandmarkManageInfoList model=new CADS.Model.LandmarkManageInfoList();
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
		public CADS.Model.LandmarkManageInfoList DataRowToModel(DataRow row)
		{
			CADS.Model.LandmarkManageInfoList model=new CADS.Model.LandmarkManageInfoList();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["LandmarkID"]!=null)
				{
					model.LandmarkID=row["LandmarkID"].ToString();
				}
				if(row["OrganizationName"]!=null)
				{
					model.OrganizationName=row["OrganizationName"].ToString();
				}
				if(row["AdminDivision"]!=null)
				{
					model.AdminDivision=row["AdminDivision"].ToString();
				}
				if(row["LandmarkName"]!=null)
				{
					model.LandmarkName=row["LandmarkName"].ToString();
				}
				if(row["LandmarkType"]!=null)
				{
					model.LandmarkType=row["LandmarkType"].ToString();
				}
				if(row["Unit"]!=null)
				{
					model.Unit=row["Unit"].ToString();
				}
				if(row["QTY"]!=null)
				{
					model.QTY=row["QTY"].ToString();
				}
				if(row["LandmarkDescription"]!=null)
				{
					model.LandmarkDescription=row["LandmarkDescription"].ToString();
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
			strSql.Append("select ID,LandmarkID,OrganizationName,AdminDivision,LandmarkName,LandmarkType,Unit,QTY,LandmarkDescription,Mark ");
			strSql.Append(" FROM LandmarkManageInfoList ");
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
			strSql.Append("select count(1) FROM LandmarkManageInfoList ");
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
				strSql.Append("order by T.LandmarkID desc");
			}
			strSql.Append(")AS Row, T.*  from LandmarkManageInfoList T ");
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

