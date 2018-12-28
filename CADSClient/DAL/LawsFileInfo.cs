using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace CADS.DAL
{
	/// <summary>
	/// 数据访问类:LawsFileInfo
	/// </summary>
	public partial class LawsFileInfo
	{
		public LawsFileInfo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "LawsFileInfo"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from LawsFileInfo");
			strSql.Append(" where ID="+ID+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.LawsFileInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.FileName != null)
			{
				strSql1.Append("FileName,");
				strSql2.Append("'"+model.FileName+"',");
			}
			if (model.FileType != null)
			{
				strSql1.Append("FileType,");
				strSql2.Append("'"+model.FileType+"',");
			}
			if (model.IssueTime != null)
			{
				strSql1.Append("IssueTime,");
				strSql2.Append("'"+model.IssueTime+"',");
			}
			if (model.IssueOrganization != null)
			{
				strSql1.Append("IssueOrganization,");
				strSql2.Append("'"+model.IssueOrganization+"',");
			}
			if (model.IssueVersion != null)
			{
				strSql1.Append("IssueVersion,");
				strSql2.Append("'"+model.IssueVersion+"',");
			}
			if (model.FilePath != null)
			{
				strSql1.Append("FilePath,");
				strSql2.Append("'"+model.FilePath+"',");
			}
			if (model.Descrpition != null)
			{
				strSql1.Append("Descrpition,");
				strSql2.Append("'"+model.Descrpition+"',");
			}
			if (model.Mark != null)
			{
				strSql1.Append("Mark,");
				strSql2.Append("'"+model.Mark+"',");
			}
			strSql.Append("insert into LawsFileInfo(");
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
		public bool Update(CADS.Model.LawsFileInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LawsFileInfo set ");
			if (model.FileName != null)
			{
				strSql.Append("FileName='"+model.FileName+"',");
			}
			else
			{
				strSql.Append("FileName= null ,");
			}
			if (model.FileType != null)
			{
				strSql.Append("FileType='"+model.FileType+"',");
			}
			else
			{
				strSql.Append("FileType= null ,");
			}
			if (model.IssueTime != null)
			{
				strSql.Append("IssueTime='"+model.IssueTime+"',");
			}
			else
			{
				strSql.Append("IssueTime= null ,");
			}
			if (model.IssueOrganization != null)
			{
				strSql.Append("IssueOrganization='"+model.IssueOrganization+"',");
			}
			else
			{
				strSql.Append("IssueOrganization= null ,");
			}
			if (model.IssueVersion != null)
			{
				strSql.Append("IssueVersion='"+model.IssueVersion+"',");
			}
			else
			{
				strSql.Append("IssueVersion= null ,");
			}
			if (model.FilePath != null)
			{
				strSql.Append("FilePath='"+model.FilePath+"',");
			}
			else
			{
				strSql.Append("FilePath= null ,");
			}
			if (model.Descrpition != null)
			{
				strSql.Append("Descrpition='"+model.Descrpition+"',");
			}
			else
			{
				strSql.Append("Descrpition= null ,");
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
			strSql.Append("delete from LawsFileInfo ");
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
			strSql.Append("delete from LawsFileInfo ");
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
		public CADS.Model.LawsFileInfo GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,FileName,FileType,IssueTime,IssueOrganization,IssueVersion,FilePath,Descrpition,Mark ");
			strSql.Append(" from LawsFileInfo ");
			strSql.Append(" where ID="+ID+"" );
			CADS.Model.LawsFileInfo model=new CADS.Model.LawsFileInfo();
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
		public CADS.Model.LawsFileInfo DataRowToModel(DataRow row)
		{
			CADS.Model.LawsFileInfo model=new CADS.Model.LawsFileInfo();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["FileName"]!=null)
				{
					model.FileName=row["FileName"].ToString();
				}
				if(row["FileType"]!=null)
				{
					model.FileType=row["FileType"].ToString();
				}
				if(row["IssueTime"]!=null)
				{
					model.IssueTime=row["IssueTime"].ToString();
				}
				if(row["IssueOrganization"]!=null)
				{
					model.IssueOrganization=row["IssueOrganization"].ToString();
				}
				if(row["IssueVersion"]!=null)
				{
					model.IssueVersion=row["IssueVersion"].ToString();
				}
				if(row["FilePath"]!=null)
				{
					model.FilePath=row["FilePath"].ToString();
				}
				if(row["Descrpition"]!=null)
				{
					model.Descrpition=row["Descrpition"].ToString();
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
			strSql.Append("select ID,FileName,FileType,IssueTime,IssueOrganization,IssueVersion,FilePath,Descrpition,Mark ");
			strSql.Append(" FROM LawsFileInfo ");
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
			strSql.Append("select count(1) FROM LawsFileInfo ");
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
			strSql.Append(")AS Row, T.*  from LawsFileInfo T ");
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

