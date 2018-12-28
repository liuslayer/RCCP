using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace CADS.DAL
{
	/// <summary>
	/// 数据访问类:DutyRecordInfoList
	/// </summary>
	public partial class DutyRecordInfoList
	{
		public DutyRecordInfoList()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "DutyRecordInfoList"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DutyRecordInfoList");
			strSql.Append(" where ID="+ID+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.DutyRecordInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.DutyPerson != null)
			{
				strSql1.Append("DutyPerson,");
				strSql2.Append("'"+model.DutyPerson+"',");
			}
			if (model.PersonID != null)
			{
				strSql1.Append("PersonID,");
				strSql2.Append("'"+model.PersonID+"',");
			}
			if (model.DutyDate != null)
			{
				strSql1.Append("DutyDate,");
				strSql2.Append("'"+model.DutyDate+"',");
			}
			if (model.DutyEvent != null)
			{
				strSql1.Append("DutyEvent,");
				strSql2.Append("'"+model.DutyEvent+"',");
			}
			if (model.DutyEventTime != null)
			{
				strSql1.Append("DutyEventTime,");
				strSql2.Append("'"+model.DutyEventTime+"',");
			}
			if (model.DutyRoute != null)
			{
				strSql1.Append("DutyRoute,");
				strSql2.Append("'"+model.DutyRoute+"',");
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
			strSql.Append("insert into DutyRecordInfoList(");
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
		public bool Update(CADS.Model.DutyRecordInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DutyRecordInfoList set ");
			if (model.DutyPerson != null)
			{
				strSql.Append("DutyPerson='"+model.DutyPerson+"',");
			}
			else
			{
				strSql.Append("DutyPerson= null ,");
			}
			if (model.PersonID != null)
			{
				strSql.Append("PersonID='"+model.PersonID+"',");
			}
			else
			{
				strSql.Append("PersonID= null ,");
			}
			if (model.DutyDate != null)
			{
				strSql.Append("DutyDate='"+model.DutyDate+"',");
			}
			else
			{
				strSql.Append("DutyDate= null ,");
			}
			if (model.DutyEvent != null)
			{
				strSql.Append("DutyEvent='"+model.DutyEvent+"',");
			}
			else
			{
				strSql.Append("DutyEvent= null ,");
			}
			if (model.DutyEventTime != null)
			{
				strSql.Append("DutyEventTime='"+model.DutyEventTime+"',");
			}
			else
			{
				strSql.Append("DutyEventTime= null ,");
			}
			if (model.DutyRoute != null)
			{
				strSql.Append("DutyRoute='"+model.DutyRoute+"',");
			}
			else
			{
				strSql.Append("DutyRoute= null ,");
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
			strSql.Append("delete from DutyRecordInfoList ");
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
			strSql.Append("delete from DutyRecordInfoList ");
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
		public CADS.Model.DutyRecordInfoList GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,DutyPerson,PersonID,DutyDate,DutyEvent,DutyEventTime,DutyRoute,Description,Mark ");
			strSql.Append(" from DutyRecordInfoList ");
			strSql.Append(" where ID="+ID+"" );
			CADS.Model.DutyRecordInfoList model=new CADS.Model.DutyRecordInfoList();
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
		public CADS.Model.DutyRecordInfoList DataRowToModel(DataRow row)
		{
			CADS.Model.DutyRecordInfoList model=new CADS.Model.DutyRecordInfoList();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["DutyPerson"]!=null)
				{
					model.DutyPerson=row["DutyPerson"].ToString();
				}
				if(row["PersonID"]!=null)
				{
					model.PersonID=row["PersonID"].ToString();
				}
				if(row["DutyDate"]!=null)
				{
					model.DutyDate=row["DutyDate"].ToString();
				}
				if(row["DutyEvent"]!=null)
				{
					model.DutyEvent=row["DutyEvent"].ToString();
				}
				if(row["DutyEventTime"]!=null)
				{
					model.DutyEventTime=row["DutyEventTime"].ToString();
				}
				if(row["DutyRoute"]!=null)
				{
					model.DutyRoute=row["DutyRoute"].ToString();
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
			strSql.Append("select ID,DutyPerson,PersonID,DutyDate,DutyEvent,DutyEventTime,DutyRoute,Description,Mark ");
			strSql.Append(" FROM DutyRecordInfoList ");
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
			strSql.Append("select count(1) FROM DutyRecordInfoList ");
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
			strSql.Append(")AS Row, T.*  from DutyRecordInfoList T ");
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

