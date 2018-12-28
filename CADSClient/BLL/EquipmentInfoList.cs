using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using CADS.Model;
namespace CADS.BLL
{
	/// <summary>
	/// EquipmentInfoList
	/// </summary>
	public partial class EquipmentInfoList
	{
		private readonly CADS.DAL.EquipmentInfoList dal=new CADS.DAL.EquipmentInfoList();
		public EquipmentInfoList()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string EquipmentID)
		{
			return dal.Exists(EquipmentID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CADS.Model.EquipmentInfoList model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CADS.Model.EquipmentInfoList model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string EquipmentID)
		{
			
			return dal.Delete(EquipmentID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string EquipmentIDlist )
		{
			return dal.DeleteList(EquipmentIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CADS.Model.EquipmentInfoList GetModel(string EquipmentID)
		{
			
			return dal.GetModel(EquipmentID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public CADS.Model.EquipmentInfoList GetModelByCache(string EquipmentID)
		{
			
			string CacheKey = "EquipmentInfoListModel-" + EquipmentID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(EquipmentID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (CADS.Model.EquipmentInfoList)objModel;
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
		public List<CADS.Model.EquipmentInfoList> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CADS.Model.EquipmentInfoList> DataTableToList(DataTable dt)
		{
			List<CADS.Model.EquipmentInfoList> modelList = new List<CADS.Model.EquipmentInfoList>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CADS.Model.EquipmentInfoList model;
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

