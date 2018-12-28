using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class ImportantLandmark_DataManagement
    {
        static ImportantLandmarkListRepository _tmpImportantLandmarkList = new ImportantLandmarkListRepository();
        static public int[] AddData(List<ImportantLandmarkList> _ImportantLandmarkList)
        {
            int[] i;
            if (_ImportantLandmarkList != null && _ImportantLandmarkList.Count > 0)
            {
                i = new int[_ImportantLandmarkList.Count];
                for (int j = 0; j < _ImportantLandmarkList.Count; j++)
                {
                    try
                    {
                        _tmpImportantLandmarkList.Insert(_ImportantLandmarkList[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }

            return i;
        }
        static public int[] DelData(Guid[] _GuidData)
        {
            int[] i;
            if (_GuidData != null && _GuidData.Length > 0)
            {
                i = new int[_GuidData.Length];
                for (int j = 0; j < _GuidData.Length; j++)
                {
                    try
                    {
                        _tmpImportantLandmarkList.Delete(_GuidData[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }

            return i;
        }
        static public int DelAllData()
        {
            int i = 0;
            List<ImportantLandmarkList> _ListImportantLandmark = new List<ImportantLandmarkList>();
            try
            {
                _ListImportantLandmark = _tmpImportantLandmarkList.GetList();
                for (int j = 0; j < _ListImportantLandmark.Count; j++)
                {
                    _tmpImportantLandmarkList.Delete(_ListImportantLandmark[j].ID);
                }
                i = 1;
            }
            catch { i = 2; }
            return i;
        }
        static public int[] UpData(List<ImportantLandmarkList> _ImportantLandmarkList)
        {
            int[] i;
            if (_ImportantLandmarkList != null && _ImportantLandmarkList.Count > 0)
            {
                i = new int[_ImportantLandmarkList.Count];
                for (int j = 0; j < _ImportantLandmarkList.Count; j++)
                {
                    try
                    {
                        _tmpImportantLandmarkList.Update(_ImportantLandmarkList[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }

            return i;
        }
        static public List<ImportantLandmarkList> GetAllData()
        {
            List<ImportantLandmarkList> _ListImportantLandmark = new List<ImportantLandmarkList>();
            try { _ListImportantLandmark = _tmpImportantLandmarkList.GetList(); } catch { _ListImportantLandmark = null; }
            return _ListImportantLandmark;
        }
    }
}
