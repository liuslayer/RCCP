using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace CADS.DAL
{
	/// <summary>
	/// 数据访问类:PlanManageInfoList
	/// </summary>
	public partial class PlanManageInfoList
	{
		public PlanManageInfoList()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PlanID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PlanManageInfoList");
			strSql.Append(" where PlanID='"+PlanID+"' ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.PlanManageInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.PlanID != null)
			{
				strSql1.Append("PlanID,");
				strSql2.Append("'"+model.PlanID+"',");
			}
			if (model.PlanTitle != null)
			{
				strSql1.Append("PlanTitle,");
				strSql2.Append("'"+model.PlanTitle+"',");
			}
			if (model.Description != null)
			{
				strSql1.Append("Description,");
				strSql2.Append("'"+model.Description+"',");
			}
			if (model.Path != null)
			{
				strSql1.Append("Path,");
				strSql2.Append("'"+model.Path+"',");
			}
			if (model.Mark != null)
			{
				strSql1.Append("Mark,");
				strSql2.Append("'"+model.Mark+"',");
			}
			strSql.Append("insert into PlanManageInfoList(");
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
		public bool Update(CADS.Model.PlanManageInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PlanManageInfoList set ");
			if (model.PlanTitle != null)
			{
				strSql.Append("PlanTitle='"+model.PlanTitle+"',");
			}
			else
			{
				strSql.Append("PlanTitle= null ,");
			}
			if (model.Description != null)
			{
				strSql.Append("Description='"+model.Description+"',");
			}
			else
			{
				strSql.Append("Description= null ,");
			}
			if (model.Path != null)
			{
				strSql.Append("Path='"+model.Path+"',");
			}
			else
			{
				strSql.Append("Path= null ,");
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
			strSql.Append(" where PlanID='"+ model.PlanID+"' ");
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
		public bool Delete(string PlanID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PlanManageInfoList ");
			strSql.Append(" where PlanID='"+PlanID+"' " );
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
		public bool DeleteList(string PlanIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PlanManageInfoList ");
			strSql.Append(" where PlanID in ("+PlanIDlist + ")  ");
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
		public CADS.Model.PlanManageInfoList GetModel(string PlanID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,PlanID,PlanTitle,Description,Path,Mark ");
			strSql.Append(" from PlanManageInfoList ");
			strSql.Append(" where PlanID='"+PlanID+"' " );
			CADS.Model.PlanManageInfoList model=new CADS.Model.PlanManageInfoList();
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
		public CADS.Model.PlanManageInfoList DataRowToModel(DataRow row)
		{
			CADS.Model.PlanManageInfoList model=new CADS.Model.PlanManageInfoList();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["PlanID"]!=null)
				{
					model.PlanID=row["PlanID"].ToString();
				}
				if(row["PlanTitle"]!=null)
				{
					model.PlanTitle=row["PlanTitle"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Path"]!=null)
				{
					model.Path=row["Path"].ToString();
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
			strSql.Append("select ID,PlanID,PlanTitle,Description,Path,Mark ");
			strSql.Append(" FROM PlanManageInfoList ");
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
			strSql.Append("select count(1) FROM PlanManageInfoList ");
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
				strSql.Append("order by T.PlanID desc");
			}
			strSql.Append(")AS Row, T.*  from PlanManageInfoList T ");
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

