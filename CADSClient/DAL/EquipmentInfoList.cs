using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace CADS.DAL
{
	/// <summary>
	/// 数据访问类:EquipmentInfoList
	/// </summary>
	public partial class EquipmentInfoList
	{
		public EquipmentInfoList()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string EquipmentID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EquipmentInfoList");
			strSql.Append(" where EquipmentID='"+EquipmentID+"' ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.EquipmentInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.EquipmentID != null)
			{
				strSql1.Append("EquipmentID,");
				strSql2.Append("'"+model.EquipmentID+"',");
			}
			if (model.EquipmentType != null)
			{
				strSql1.Append("EquipmentType,");
				strSql2.Append("'"+model.EquipmentType+"',");
			}
			if (model.EquipmentModel != null)
			{
				strSql1.Append("EquipmentModel,");
				strSql2.Append("'"+model.EquipmentModel+"',");
			}
			if (model.EquipmentName != null)
			{
				strSql1.Append("EquipmentName,");
				strSql2.Append("'"+model.EquipmentName+"',");
			}
			if (model.PersonIncharge != null)
			{
				strSql1.Append("PersonIncharge,");
				strSql2.Append("'"+model.PersonIncharge+"',");
			}
			if (model.AllottedDate != null)
			{
				strSql1.Append("AllottedDate,");
				strSql2.Append("'"+model.AllottedDate+"',");
			}
			if (model.Unit != null)
			{
				strSql1.Append("Unit,");
				strSql2.Append("'"+model.Unit+"',");
			}
			if (model.ReturnDate != null)
			{
				strSql1.Append("ReturnDate,");
				strSql2.Append("'"+model.ReturnDate+"',");
			}
			if (model.EquipmentState != null)
			{
				strSql1.Append("EquipmentState,");
				strSql2.Append("'"+model.EquipmentState+"',");
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
			strSql.Append("insert into EquipmentInfoList(");
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
		public bool Update(CADS.Model.EquipmentInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EquipmentInfoList set ");
			if (model.EquipmentType != null)
			{
				strSql.Append("EquipmentType='"+model.EquipmentType+"',");
			}
			else
			{
				strSql.Append("EquipmentType= null ,");
			}
			if (model.EquipmentModel != null)
			{
				strSql.Append("EquipmentModel='"+model.EquipmentModel+"',");
			}
			else
			{
				strSql.Append("EquipmentModel= null ,");
			}
			if (model.EquipmentName != null)
			{
				strSql.Append("EquipmentName='"+model.EquipmentName+"',");
			}
			else
			{
				strSql.Append("EquipmentName= null ,");
			}
			if (model.PersonIncharge != null)
			{
				strSql.Append("PersonIncharge='"+model.PersonIncharge+"',");
			}
			else
			{
				strSql.Append("PersonIncharge= null ,");
			}
			if (model.AllottedDate != null)
			{
				strSql.Append("AllottedDate='"+model.AllottedDate+"',");
			}
			else
			{
				strSql.Append("AllottedDate= null ,");
			}
			if (model.Unit != null)
			{
				strSql.Append("Unit='"+model.Unit+"',");
			}
			else
			{
				strSql.Append("Unit= null ,");
			}
			if (model.ReturnDate != null)
			{
				strSql.Append("ReturnDate='"+model.ReturnDate+"',");
			}
			else
			{
				strSql.Append("ReturnDate= null ,");
			}
			if (model.EquipmentState != null)
			{
				strSql.Append("EquipmentState='"+model.EquipmentState+"',");
			}
			else
			{
				strSql.Append("EquipmentState= null ,");
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
			strSql.Append(" where EquipmentID='"+ model.EquipmentID+"' ");
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
		public bool Delete(string EquipmentID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EquipmentInfoList ");
			strSql.Append(" where EquipmentID='"+EquipmentID+"' " );
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
		public bool DeleteList(string EquipmentIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EquipmentInfoList ");
			strSql.Append(" where EquipmentID in ("+EquipmentIDlist + ")  ");
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
		public CADS.Model.EquipmentInfoList GetModel(string EquipmentID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,EquipmentID,EquipmentType,EquipmentModel,EquipmentName,PersonIncharge,AllottedDate,Unit,ReturnDate,EquipmentState,Description,Mark ");
			strSql.Append(" from EquipmentInfoList ");
			strSql.Append(" where EquipmentID='"+EquipmentID+"' " );
			CADS.Model.EquipmentInfoList model=new CADS.Model.EquipmentInfoList();
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
		public CADS.Model.EquipmentInfoList DataRowToModel(DataRow row)
		{
			CADS.Model.EquipmentInfoList model=new CADS.Model.EquipmentInfoList();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["EquipmentID"]!=null)
				{
					model.EquipmentID=row["EquipmentID"].ToString();
				}
				if(row["EquipmentType"]!=null)
				{
					model.EquipmentType=row["EquipmentType"].ToString();
				}
				if(row["EquipmentModel"]!=null)
				{
					model.EquipmentModel=row["EquipmentModel"].ToString();
				}
				if(row["EquipmentName"]!=null)
				{
					model.EquipmentName=row["EquipmentName"].ToString();
				}
				if(row["PersonIncharge"]!=null)
				{
					model.PersonIncharge=row["PersonIncharge"].ToString();
				}
				if(row["AllottedDate"]!=null)
				{
					model.AllottedDate=row["AllottedDate"].ToString();
				}
				if(row["Unit"]!=null)
				{
					model.Unit=row["Unit"].ToString();
				}
				if(row["ReturnDate"]!=null)
				{
					model.ReturnDate=row["ReturnDate"].ToString();
				}
				if(row["EquipmentState"]!=null)
				{
					model.EquipmentState=row["EquipmentState"].ToString();
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
			strSql.Append("select ID,EquipmentID,EquipmentType,EquipmentModel,EquipmentName,PersonIncharge,AllottedDate,Unit,ReturnDate,EquipmentState,Description,Mark ");
			strSql.Append(" FROM EquipmentInfoList ");
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
			strSql.Append("select count(1) FROM EquipmentInfoList ");
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
				strSql.Append("order by T.EquipmentID desc");
			}
			strSql.Append(")AS Row, T.*  from EquipmentInfoList T ");
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

