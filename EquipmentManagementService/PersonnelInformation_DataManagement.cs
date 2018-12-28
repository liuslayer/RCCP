using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class PersonnelInformation_DataManagement
    {
        static PersonnelInformationListRepository _tmpPersonnelInformationList = new PersonnelInformationListRepository();
        static public int[] AddData(List<PersonnelInformationList> _PersonnelInformationList)
        {
            int[] i;
            if (_PersonnelInformationList != null && _PersonnelInformationList.Count > 0)
            {
                i = new int[_PersonnelInformationList.Count];
                for (int j = 0; j < _PersonnelInformationList.Count; j++)
                {
                    try
                    {
                        _tmpPersonnelInformationList.Insert(_PersonnelInformationList[j]);
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
                        _tmpPersonnelInformationList.Delete(_GuidData[j]);
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
            List<PersonnelInformationList> _ListPersonnelInformation = new List<PersonnelInformationList>();
            try
            {
                _ListPersonnelInformation = _tmpPersonnelInformationList.GetList();
                for (int j = 0; j < _ListPersonnelInformation.Count; j++)
                {
                    _tmpPersonnelInformationList.Delete(_ListPersonnelInformation[j].ID);
                }
                i = 1;
            }
            catch { i = 2; }
            return i;
        }
        static public int[] UpData(List<PersonnelInformationList> _PersonnelInformationList)
        {
            int[] i;
            if (_PersonnelInformationList != null && _PersonnelInformationList.Count > 0)
            {
                i = new int[_PersonnelInformationList.Count];
                for (int j = 0; j < _PersonnelInformationList.Count; j++)
                {
                    try
                    {
                        _tmpPersonnelInformationList.Update(_PersonnelInformationList[j]);
                        i[j] = 1;
                    }
                    catch { i[j] = 2; }
                }
            }
            else { i = null; }

            return i;
        }
        static public List<PersonnelInformationList> GetAllData()
        {
            List<PersonnelInformationList> _ListPersonnelInformation = new List<PersonnelInformationList>();
            try { _ListPersonnelInformation = _tmpPersonnelInformationList.GetList(); } catch { _ListPersonnelInformation = null; }
            return _ListPersonnelInformation;
        }
    }
}
