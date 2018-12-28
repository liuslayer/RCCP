using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace CADS.DAL
{
	/// <summary>
	/// 数据访问类:NationalSocialInfoList
	/// </summary>
	public partial class NationalSocialInfoList
	{
		public NationalSocialInfoList()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string NationID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from NationalSocialInfoList");
			strSql.Append(" where NationID='"+NationID+"' ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.NationalSocialInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.NationID != null)
			{
				strSql1.Append("NationID,");
				strSql2.Append("'"+model.NationID+"',");
			}
			if (model.NationName != null)
			{
				strSql1.Append("NationName,");
				strSql2.Append("'"+model.NationName+"',");
			}
			if (model.Religion != null)
			{
				strSql1.Append("Religion,");
				strSql2.Append("'"+model.Religion+"',");
			}
			if (model.Habit != null)
			{
				strSql1.Append("Habit,");
				strSql2.Append("'"+model.Habit+"',");
			}
			if (model.SocialGroup != null)
			{
				strSql1.Append("SocialGroup,");
				strSql2.Append("'"+model.SocialGroup+"',");
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
			strSql.Append("insert into NationalSocialInfoList(");
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
		public bool Update(CADS.Model.NationalSocialInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update NationalSocialInfoList set ");
			if (model.NationName != null)
			{
				strSql.Append("NationName='"+model.NationName+"',");
			}
			else
			{
				strSql.Append("NationName= null ,");
			}
			if (model.Religion != null)
			{
				strSql.Append("Religion='"+model.Religion+"',");
			}
			else
			{
				strSql.Append("Religion= null ,");
			}
			if (model.Habit != null)
			{
				strSql.Append("Habit='"+model.Habit+"',");
			}
			else
			{
				strSql.Append("Habit= null ,");
			}
			if (model.SocialGroup != null)
			{
				strSql.Append("SocialGroup='"+model.SocialGroup+"',");
			}
			else
			{
				strSql.Append("SocialGroup= null ,");
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
			strSql.Append(" where NationID='"+ model.NationID+"' ");
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
		public bool Delete(string NationID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NationalSocialInfoList ");
			strSql.Append(" where NationID='"+NationID+"' " );
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
		public bool DeleteList(string NationIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NationalSocialInfoList ");
			strSql.Append(" where NationID in ("+NationIDlist + ")  ");
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
		public CADS.Model.NationalSocialInfoList GetModel(string NationID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,NationID,NationName,Religion,Habit,SocialGroup,Description,Mark ");
			strSql.Append(" from NationalSocialInfoList ");
			strSql.Append(" where NationID='"+NationID+"' " );
			CADS.Model.NationalSocialInfoList model=new CADS.Model.NationalSocialInfoList();
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
		public CADS.Model.NationalSocialInfoList DataRowToModel(DataRow row)
		{
			CADS.Model.NationalSocialInfoList model=new CADS.Model.NationalSocialInfoList();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["NationID"]!=null)
				{
					model.NationID=row["NationID"].ToString();
				}
				if(row["NationName"]!=null)
				{
					model.NationName=row["NationName"].ToString();
				}
				if(row["Religion"]!=null)
				{
					model.Religion=row["Religion"].ToString();
				}
				if(row["Habit"]!=null)
				{
					model.Habit=row["Habit"].ToString();
				}
				if(row["SocialGroup"]!=null)
				{
					model.SocialGroup=row["SocialGroup"].ToString();
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
			strSql.Append("select ID,NationID,NationName,Religion,Habit,SocialGroup,Description,Mark ");
			strSql.Append(" FROM NationalSocialInfoList ");
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
			strSql.Append("select count(1) FROM NationalSocialInfoList ");
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
				strSql.Append("order by T.NationID desc");
			}
			strSql.Append(")AS Row, T.*  from NationalSocialInfoList T ");
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

