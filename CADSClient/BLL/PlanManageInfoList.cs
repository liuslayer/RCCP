using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CADS.Model;
namespace CADS.BLL
{
	/// <summary>
	/// PlanManageInfoList
	/// </summary>
	public partial class PlanManageInfoList
	{
		private readonly CADS.DAL.PlanManageInfoList dal=new CADS.DAL.PlanManageInfoList();
		public PlanManageInfoList()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PlanID)
		{
			return dal.Exists(PlanID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.PlanManageInfoList model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CADS.Model.PlanManageInfoList model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string PlanID)
		{
			
			return dal.Delete(PlanID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PlanIDlist )
		{
			return dal.DeleteList(PlanIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CADS.Model.PlanManageInfoList GetModel(string PlanID)
		{
			
			return dal.GetModel(PlanID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public CADS.Model.PlanManageInfoList GetModelByCache(string PlanID)
		{
			
			string CacheKey = "PlanManageInfoListModel-" + PlanID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PlanID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (CADS.Model.PlanManageInfoList)objModel;
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
		public List<CADS.Model.PlanManageInfoList> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CADS.Model.PlanManageInfoList> DataTableToList(DataTable dt)
		{
			List<CADS.Model.PlanManageInfoList> modelList = new List<CADS.Model.PlanManageInfoList>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CADS.Model.PlanManageInfoList model;
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

