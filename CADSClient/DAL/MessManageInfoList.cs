using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace CADS.DAL
{
	/// <summary>
	/// 数据访问类:MessManageInfoList
	/// </summary>
	public partial class MessManageInfoList
	{
		public MessManageInfoList()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string MessID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MessManageInfoList");
			strSql.Append(" where MessID='"+MessID+"' ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.MessManageInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.MessID != null)
			{
				strSql1.Append("MessID,");
				strSql2.Append("'"+model.MessID+"',");
			}
			if (model.Receiver != null)
			{
				strSql1.Append("Receiver,");
				strSql2.Append("'"+model.Receiver+"',");
			}
			if (model.ReceiveOrg != null)
			{
				strSql1.Append("ReceiveOrg,");
				strSql2.Append("'"+model.ReceiveOrg+"',");
			}
			if (model.MessType != null)
			{
				strSql1.Append("MessType,");
				strSql2.Append("'"+model.MessType+"',");
			}
			if (model.IsHandle != null)
			{
				strSql1.Append("IsHandle,");
				strSql2.Append("'"+model.IsHandle+"',");
			}
			if (model.MessTitle != null)
			{
				strSql1.Append("MessTitle,");
				strSql2.Append("'"+model.MessTitle+"',");
			}
			if (model.MessContent != null)
			{
				strSql1.Append("MessContent,");
				strSql2.Append("'"+model.MessContent+"',");
			}
			if (model.Attachment != null)
			{
				strSql1.Append("Attachment,");
				strSql2.Append("'"+model.Attachment+"',");
			}
			if (model.mark != null)
			{
				strSql1.Append("mark,");
				strSql2.Append("'"+model.mark+"',");
			}
			strSql.Append("insert into MessManageInfoList(");
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
		public bool Update(CADS.Model.MessManageInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MessManageInfoList set ");
			if (model.Receiver != null)
			{
				strSql.Append("Receiver='"+model.Receiver+"',");
			}
			else
			{
				strSql.Append("Receiver= null ,");
			}
			if (model.ReceiveOrg != null)
			{
				strSql.Append("ReceiveOrg='"+model.ReceiveOrg+"',");
			}
			else
			{
				strSql.Append("ReceiveOrg= null ,");
			}
			if (model.MessType != null)
			{
				strSql.Append("MessType='"+model.MessType+"',");
			}
			else
			{
				strSql.Append("MessType= null ,");
			}
			if (model.IsHandle != null)
			{
				strSql.Append("IsHandle='"+model.IsHandle+"',");
			}
			else
			{
				strSql.Append("IsHandle= null ,");
			}
			if (model.MessTitle != null)
			{
				strSql.Append("MessTitle='"+model.MessTitle+"',");
			}
			else
			{
				strSql.Append("MessTitle= null ,");
			}
			if (model.MessContent != null)
			{
				strSql.Append("MessContent='"+model.MessContent+"',");
			}
			else
			{
				strSql.Append("MessContent= null ,");
			}
			if (model.Attachment != null)
			{
				strSql.Append("Attachment='"+model.Attachment+"',");
			}
			else
			{
				strSql.Append("Attachment= null ,");
			}
			if (model.mark != null)
			{
				strSql.Append("mark='"+model.mark+"',");
			}
			else
			{
				strSql.Append("mark= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where MessID='"+ model.MessID+"' ");
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
		public bool Delete(string MessID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MessManageInfoList ");
			strSql.Append(" where MessID='"+MessID+"' " );
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
		public bool DeleteList(string MessIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MessManageInfoList ");
			strSql.Append(" where MessID in ("+MessIDlist + ")  ");
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
		public CADS.Model.MessManageInfoList GetModel(string MessID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,MessID,Receiver,ReceiveOrg,MessType,IsHandle,MessTitle,MessContent,Attachment,mark ");
			strSql.Append(" from MessManageInfoList ");
			strSql.Append(" where MessID='"+MessID+"' " );
			CADS.Model.MessManageInfoList model=new CADS.Model.MessManageInfoList();
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
		public CADS.Model.MessManageInfoList DataRowToModel(DataRow row)
		{
			CADS.Model.MessManageInfoList model=new CADS.Model.MessManageInfoList();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["MessID"]!=null)
				{
					model.MessID=row["MessID"].ToString();
				}
				if(row["Receiver"]!=null)
				{
					model.Receiver=row["Receiver"].ToString();
				}
				if(row["ReceiveOrg"]!=null)
				{
					model.ReceiveOrg=row["ReceiveOrg"].ToString();
				}
				if(row["MessType"]!=null)
				{
					model.MessType=row["MessType"].ToString();
				}
				if(row["IsHandle"]!=null)
				{
					model.IsHandle=row["IsHandle"].ToString();
				}
				if(row["MessTitle"]!=null)
				{
					model.MessTitle=row["MessTitle"].ToString();
				}
				if(row["MessContent"]!=null)
				{
					model.MessContent=row["MessContent"].ToString();
				}
				if(row["Attachment"]!=null)
				{
					model.Attachment=row["Attachment"].ToString();
				}
				if(row["mark"]!=null)
				{
					model.mark=row["mark"].ToString();
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
			strSql.Append("select ID,MessID,Receiver,ReceiveOrg,MessType,IsHandle,MessTitle,MessContent,Attachment,mark ");
			strSql.Append(" FROM MessManageInfoList ");
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
			strSql.Append("select count(1) FROM MessManageInfoList ");
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
				strSql.Append("order by T.MessID desc");
			}
			strSql.Append(")AS Row, T.*  from MessManageInfoList T ");
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

