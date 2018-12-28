using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace CADS.DAL
{
	/// <summary>
	/// 数据访问类:PersonnelInfoList
	/// </summary>
	public partial class PersonnelInfoList
	{
		public PersonnelInfoList()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PersonID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PersonnelInfoList");
			strSql.Append(" where PersonID='"+PersonID+"' ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.PersonnelInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.PersonID != null)
			{
				strSql1.Append("PersonID,");
				strSql2.Append("'"+model.PersonID+"',");
			}
			if (model.PersonName != null)
			{
				strSql1.Append("PersonName,");
				strSql2.Append("'"+model.PersonName+"',");
			}
			if (model.PersonNation != null)
			{
				strSql1.Append("PersonNation,");
				strSql2.Append("'"+model.PersonNation+"',");
			}
			if (model.NativePlace != null)
			{
				strSql1.Append("NativePlace,");
				strSql2.Append("'"+model.NativePlace+"',");
			}
			if (model.DateOfBirth != null)
			{
				strSql1.Append("DateOfBirth,");
				strSql2.Append("'"+model.DateOfBirth+"',");
			}
			if (model.DegreeOfEducation != null)
			{
				strSql1.Append("DegreeOfEducation,");
				strSql2.Append("'"+model.DegreeOfEducation+"',");
			}
			if (model.EnlistmentTime != null)
			{
				strSql1.Append("EnlistmentTime,");
				strSql2.Append("'"+model.EnlistmentTime+"',");
			}
			if (model.RetiredTime != null)
			{
				strSql1.Append("RetiredTime,");
				strSql2.Append("'"+model.RetiredTime+"',");
			}
			if (model.ContactInfo != null)
			{
				strSql1.Append("ContactInfo,");
				strSql2.Append("'"+model.ContactInfo+"',");
			}
			if (model.Post != null)
			{
				strSql1.Append("Post,");
				strSql2.Append("'"+model.Post+"',");
			}
			if (model.Description != null)
			{
				strSql1.Append("Description,");
				strSql2.Append("'"+model.Description+"',");
			}
			if (model.Unit != null)
			{
				strSql1.Append("Unit,");
				strSql2.Append("'"+model.Unit+"',");
			}
			if (model.Mark != null)
			{
				strSql1.Append("Mark,");
				strSql2.Append("'"+model.Mark+"',");
			}
			strSql.Append("insert into PersonnelInfoList(");
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
		public bool Update(CADS.Model.PersonnelInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PersonnelInfoList set ");
			if (model.PersonName != null)
			{
				strSql.Append("PersonName='"+model.PersonName+"',");
			}
			else
			{
				strSql.Append("PersonName= null ,");
			}
			if (model.PersonNation != null)
			{
				strSql.Append("PersonNation='"+model.PersonNation+"',");
			}
			else
			{
				strSql.Append("PersonNation= null ,");
			}
			if (model.NativePlace != null)
			{
				strSql.Append("NativePlace='"+model.NativePlace+"',");
			}
			else
			{
				strSql.Append("NativePlace= null ,");
			}
			if (model.DateOfBirth != null)
			{
				strSql.Append("DateOfBirth='"+model.DateOfBirth+"',");
			}
			else
			{
				strSql.Append("DateOfBirth= null ,");
			}
			if (model.DegreeOfEducation != null)
			{
				strSql.Append("DegreeOfEducation='"+model.DegreeOfEducation+"',");
			}
			else
			{
				strSql.Append("DegreeOfEducation= null ,");
			}
			if (model.EnlistmentTime != null)
			{
				strSql.Append("EnlistmentTime='"+model.EnlistmentTime+"',");
			}
			else
			{
				strSql.Append("EnlistmentTime= null ,");
			}
			if (model.RetiredTime != null)
			{
				strSql.Append("RetiredTime='"+model.RetiredTime+"',");
			}
			else
			{
				strSql.Append("RetiredTime= null ,");
			}
			if (model.ContactInfo != null)
			{
				strSql.Append("ContactInfo='"+model.ContactInfo+"',");
			}
			else
			{
				strSql.Append("ContactInfo= null ,");
			}
			if (model.Post != null)
			{
				strSql.Append("Post='"+model.Post+"',");
			}
			else
			{
				strSql.Append("Post= null ,");
			}
			if (model.Description != null)
			{
				strSql.Append("Description='"+model.Description+"',");
			}
			else
			{
				strSql.Append("Description= null ,");
			}
			if (model.Unit != null)
			{
				strSql.Append("Unit='"+model.Unit+"',");
			}
			else
			{
				strSql.Append("Unit= null ,");
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
			strSql.Append(" where PersonID='"+ model.PersonID+"' ");
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
		public bool Delete(string PersonID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PersonnelInfoList ");
			strSql.Append(" where PersonID='"+PersonID+"' " );
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
		public bool DeleteList(string PersonIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PersonnelInfoList ");
			strSql.Append(" where PersonID in ("+PersonIDlist + ")  ");
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
		public CADS.Model.PersonnelInfoList GetModel(string PersonID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,PersonID,PersonName,PersonNation,NativePlace,DateOfBirth,DegreeOfEducation,EnlistmentTime,RetiredTime,ContactInfo,Post,Description,Unit,Mark ");
			strSql.Append(" from PersonnelInfoList ");
			strSql.Append(" where PersonID='"+PersonID+"' " );
			CADS.Model.PersonnelInfoList model=new CADS.Model.PersonnelInfoList();
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
		public CADS.Model.PersonnelInfoList DataRowToModel(DataRow row)
		{
			CADS.Model.PersonnelInfoList model=new CADS.Model.PersonnelInfoList();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["PersonID"]!=null)
				{
					model.PersonID=row["PersonID"].ToString();
				}
				if(row["PersonName"]!=null)
				{
					model.PersonName=row["PersonName"].ToString();
				}
				if(row["PersonNation"]!=null)
				{
					model.PersonNation=row["PersonNation"].ToString();
				}
				if(row["NativePlace"]!=null)
				{
					model.NativePlace=row["NativePlace"].ToString();
				}
				if(row["DateOfBirth"]!=null)
				{
					model.DateOfBirth=row["DateOfBirth"].ToString();
				}
				if(row["DegreeOfEducation"]!=null)
				{
					model.DegreeOfEducation=row["DegreeOfEducation"].ToString();
				}
				if(row["EnlistmentTime"]!=null)
				{
					model.EnlistmentTime=row["EnlistmentTime"].ToString();
				}
				if(row["RetiredTime"]!=null)
				{
					model.RetiredTime=row["RetiredTime"].ToString();
				}
				if(row["ContactInfo"]!=null)
				{
					model.ContactInfo=row["ContactInfo"].ToString();
				}
				if(row["Post"]!=null)
				{
					model.Post=row["Post"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Unit"]!=null)
				{
					model.Unit=row["Unit"].ToString();
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
			strSql.Append("select ID,PersonID,PersonName,PersonNation,NativePlace,DateOfBirth,DegreeOfEducation,EnlistmentTime,RetiredTime,ContactInfo,Post,Description,Unit,Mark ");
			strSql.Append(" FROM PersonnelInfoList ");
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
			strSql.Append("select count(1) FROM PersonnelInfoList ");
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
				strSql.Append("order by T.PersonID desc");
			}
			strSql.Append(")AS Row, T.*  from PersonnelInfoList T ");
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

