using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace CADS.DAL
{
	/// <summary>
	/// 数据访问类:SwitchManageInfoList
	/// </summary>
	public partial class SwitchManageInfoList
	{
		public SwitchManageInfoList()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "SwitchManageInfoList"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SwitchManageInfoList");
			strSql.Append(" where ID="+ID+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.SwitchManageInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.PreLeader != null)
			{
				strSql1.Append("PreLeader,");
				strSql2.Append("'"+model.PreLeader+"',");
			}
			if (model.PreName != null)
			{
				strSql1.Append("PreName,");
				strSql2.Append("'"+model.PreName+"',");
			}
			if (model.NextLeader != null)
			{
				strSql1.Append("NextLeader,");
				strSql2.Append("'"+model.NextLeader+"',");
			}
			if (model.NextName != null)
			{
				strSql1.Append("NextName,");
				strSql2.Append("'"+model.NextName+"',");
			}
			if (model.SwtichTime != null)
			{
				strSql1.Append("SwtichTime,");
				strSql2.Append("'"+model.SwtichTime+"',");
			}
			if (model.SwitchContent != null)
			{
				strSql1.Append("SwitchContent,");
				strSql2.Append("'"+model.SwitchContent+"',");
			}
			if (model.Mark != null)
			{
				strSql1.Append("Mark,");
				strSql2.Append("'"+model.Mark+"',");
			}
			strSql.Append("insert into SwitchManageInfoList(");
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
		public bool Update(CADS.Model.SwitchManageInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SwitchManageInfoList set ");
			if (model.PreLeader != null)
			{
				strSql.Append("PreLeader='"+model.PreLeader+"',");
			}
			else
			{
				strSql.Append("PreLeader= null ,");
			}
			if (model.PreName != null)
			{
				strSql.Append("PreName='"+model.PreName+"',");
			}
			else
			{
				strSql.Append("PreName= null ,");
			}
			if (model.NextLeader != null)
			{
				strSql.Append("NextLeader='"+model.NextLeader+"',");
			}
			else
			{
				strSql.Append("NextLeader= null ,");
			}
			if (model.NextName != null)
			{
				strSql.Append("NextName='"+model.NextName+"',");
			}
			else
			{
				strSql.Append("NextName= null ,");
			}
			if (model.SwtichTime != null)
			{
				strSql.Append("SwtichTime='"+model.SwtichTime+"',");
			}
			else
			{
				strSql.Append("SwtichTime= null ,");
			}
			if (model.SwitchContent != null)
			{
				strSql.Append("SwitchContent='"+model.SwitchContent+"',");
			}
			else
			{
				strSql.Append("SwitchContent= null ,");
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
			strSql.Append("delete from SwitchManageInfoList ");
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
			strSql.Append("delete from SwitchManageInfoList ");
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
		public CADS.Model.SwitchManageInfoList GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,PreLeader,PreName,NextLeader,NextName,SwtichTime,SwitchContent,Mark ");
			strSql.Append(" from SwitchManageInfoList ");
			strSql.Append(" where ID="+ID+"" );
			CADS.Model.SwitchManageInfoList model=new CADS.Model.SwitchManageInfoList();
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
		public CADS.Model.SwitchManageInfoList DataRowToModel(DataRow row)
		{
			CADS.Model.SwitchManageInfoList model=new CADS.Model.SwitchManageInfoList();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["PreLeader"]!=null)
				{
					model.PreLeader=row["PreLeader"].ToString();
				}
				if(row["PreName"]!=null)
				{
					model.PreName=row["PreName"].ToString();
				}
				if(row["NextLeader"]!=null)
				{
					model.NextLeader=row["NextLeader"].ToString();
				}
				if(row["NextName"]!=null)
				{
					model.NextName=row["NextName"].ToString();
				}
				if(row["SwtichTime"]!=null)
				{
					model.SwtichTime=row["SwtichTime"].ToString();
				}
				if(row["SwitchContent"]!=null)
				{
					model.SwitchContent=row["SwitchContent"].ToString();
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
			strSql.Append("select ID,PreLeader,PreName,NextLeader,NextName,SwtichTime,SwitchContent,Mark ");
			strSql.Append(" FROM SwitchManageInfoList ");
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
			strSql.Append("select count(1) FROM SwitchManageInfoList ");
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
			strSql.Append(")AS Row, T.*  from SwitchManageInfoList T ");
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

