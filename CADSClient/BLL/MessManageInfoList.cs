using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CADS.Model;
namespace CADS.BLL
{
	/// <summary>
	/// MessManageInfoList
	/// </summary>
	public partial class MessManageInfoList
	{
		private readonly CADS.DAL.MessManageInfoList dal=new CADS.DAL.MessManageInfoList();
		public MessManageInfoList()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string MessID)
		{
			return dal.Exists(MessID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.MessManageInfoList model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CADS.Model.MessManageInfoList model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string MessID)
		{
			
			return dal.Delete(MessID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MessIDlist )
		{
			return dal.DeleteList(MessIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CADS.Model.MessManageInfoList GetModel(string MessID)
		{
			
			return dal.GetModel(MessID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public CADS.Model.MessManageInfoList GetModelByCache(string MessID)
		{
			
			string CacheKey = "MessManageInfoListModel-" + MessID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MessID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (CADS.Model.MessManageInfoList)objModel;
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
		public List<CADS.Model.MessManageInfoList> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CADS.Model.MessManageInfoList> DataTableToList(DataTable dt)
		{
			List<CADS.Model.MessManageInfoList> modelList = new List<CADS.Model.MessManageInfoList>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CADS.Model.MessManageInfoList model;
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

