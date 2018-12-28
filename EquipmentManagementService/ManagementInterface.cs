using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementService
{
    public class ManagementInterface
    {
        public void AddCameraList()
        {
            CameraList entityToInsert = new CameraList();
            //entityToInsert.  
            new CameraListRepository().Update(entityToInsert);
        }
        public void AddSerialCOMList(SerialCOMList m_SerialCOMList)
        {
            SerialCOMList tmp_SerialCOMList = new SerialCOMList();

            tmp_SerialCOMList.Name = "";
            tmp_SerialCOMList.COMNo = "";
            tmp_SerialCOMList.Baud= 1;
            int i = 0;
            switch (i)
            {
                case 0:
                    break;
            }
            tmp_SerialCOMList.CheckBit =1;
            tmp_SerialCOMList.DataBit = 1;
            tmp_SerialCOMList.StopBit =1;
            tmp_SerialCOMList.Description = "";
            tmp_SerialCOMList.Mark = "";
            new SerialCOMListRepository().Update(tmp_SerialCOMList);
        }

        public void GetDVRorNVR_SwitchList()
        {
            new DVRorNVR_SwitchListRepository().GetListWithCondition(new { PresetName = "aaa", Turntable_PTZ_DeviceID = new Guid() });
        }
        public void GetSerialCOMList()
        {
            new SerialCOMListRepository().GetListWithCondition(new { PresetName = "aaa", Turntable_PTZ_DeviceID = new Guid() });
        }
    }
}
