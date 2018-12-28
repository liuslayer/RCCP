using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace CADS.DAL
{
	/// <summary>
	/// 数据访问类:GeographyEnvInfoList
	/// </summary>
	public partial class GeographyEnvInfoList
	{
		public GeographyEnvInfoList()
		{}
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ZoneID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from GeographyEnvInfoList");
			strSql.Append(" where ZoneID='"+ZoneID+"' ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.GeographyEnvInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.ZoneID != null)
			{
				strSql1.Append("ZoneID,");
				strSql2.Append("'"+model.ZoneID+"',");
			}
			if (model.ZoneScale != null)
			{
				strSql1.Append("ZoneScale,");
				strSql2.Append("'"+model.ZoneScale+"',");
			}
			if (model.GeographyEnv != null)
			{
				strSql1.Append("GeographyEnv,");
				strSql2.Append("'"+model.GeographyEnv+"',");
			}
			if (model.RoadTransport != null)
			{
				strSql1.Append("RoadTransport,");
				strSql2.Append("'"+model.RoadTransport+"',");
			}
			if (model.WaterSystem != null)
			{
				strSql1.Append("WaterSystem,");
				strSql2.Append("'"+model.WaterSystem+"',");
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
			strSql.Append("insert into GeographyEnvInfoList(");
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
		public bool Update(CADS.Model.GeographyEnvInfoList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update GeographyEnvInfoList set ");
			if (model.ZoneScale != null)
			{
				strSql.Append("ZoneScale='"+model.ZoneScale+"',");
			}
			else
			{
				strSql.Append("ZoneScale= null ,");
			}
			if (model.GeographyEnv != null)
			{
				strSql.Append("GeographyEnv='"+model.GeographyEnv+"',");
			}
			else
			{
				strSql.Append("GeographyEnv= null ,");
			}
			if (model.RoadTransport != null)
			{
				strSql.Append("RoadTransport='"+model.RoadTransport+"',");
			}
			else
			{
				strSql.Append("RoadTransport= null ,");
			}
			if (model.WaterSystem != null)
			{
				strSql.Append("WaterSystem='"+model.WaterSystem+"',");
			}
			else
			{
				strSql.Append("WaterSystem= null ,");
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
			strSql.Append(" where ZoneID='"+ model.ZoneID+"' ");
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
		public bool Delete(string ZoneID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GeographyEnvInfoList ");
			strSql.Append(" where ZoneID='"+ZoneID+"' " );
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
		public bool DeleteList(string ZoneIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GeographyEnvInfoList ");
			strSql.Append(" where ZoneID in ("+ZoneIDlist + ")  ");
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
		public CADS.Model.GeographyEnvInfoList GetModel(string ZoneID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ID,ZoneID,ZoneScale,GeographyEnv,RoadTransport,WaterSystem,Description,Mark ");
			strSql.Append(" from GeographyEnvInfoList ");
			strSql.Append(" where ZoneID='"+ZoneID+"' " );
			CADS.Model.GeographyEnvInfoList model=new CADS.Model.GeographyEnvInfoList();
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
		public CADS.Model.GeographyEnvInfoList DataRowToModel(DataRow row)
		{
			CADS.Model.GeographyEnvInfoList model=new CADS.Model.GeographyEnvInfoList();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ZoneID"]!=null)
				{
					model.ZoneID=row["ZoneID"].ToString();
				}
				if(row["ZoneScale"]!=null)
				{
					model.ZoneScale=row["ZoneScale"].ToString();
				}
				if(row["GeographyEnv"]!=null)
				{
					model.GeographyEnv=row["GeographyEnv"].ToString();
				}
				if(row["RoadTransport"]!=null)
				{
					model.RoadTransport=row["RoadTransport"].ToString();
				}
				if(row["WaterSystem"]!=null)
				{
					model.WaterSystem=row["WaterSystem"].ToString();
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
			strSql.Append("select ID,ZoneID,ZoneScale,GeographyEnv,RoadTransport,WaterSystem,Description,Mark ");
			strSql.Append(" FROM GeographyEnvInfoList ");
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
			strSql.Append("select count(1) FROM GeographyEnvInfoList ");
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
				strSql.Append("order by T.ZoneID desc");
			}
			strSql.Append(")AS Row, T.*  from GeographyEnvInfoList T ");
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

