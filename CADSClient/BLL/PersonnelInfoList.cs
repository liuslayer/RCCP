using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CADS.Model;
namespace CADS.BLL
{
	/// <summary>
	/// PersonnelInfoList
	/// </summary>
	public partial class PersonnelInfoList
	{
		private readonly CADS.DAL.PersonnelInfoList dal=new CADS.DAL.PersonnelInfoList();
		public PersonnelInfoList()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PersonID)
		{
			return dal.Exists(PersonID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.PersonnelInfoList model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CADS.Model.PersonnelInfoList model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string PersonID)
		{
			
			return dal.Delete(PersonID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PersonIDlist )
		{
			return dal.DeleteList(PersonIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CADS.Model.PersonnelInfoList GetModel(string PersonID)
		{
			
			return dal.GetModel(PersonID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public CADS.Model.PersonnelInfoList GetModelByCache(string PersonID)
		{
			
			string CacheKey = "PersonnelInfoListModel-" + PersonID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PersonID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (CADS.Model.PersonnelInfoList)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CADS.Model.PersonnelInfoList> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CADS.Model.PersonnelInfoList> DataTableToList(DataTable dt)
		{
			List<CADS.Model.PersonnelInfoList> modelList = new List<CADS.Model.PersonnelInfoList>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CADS.Model.PersonnelInfoList model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

