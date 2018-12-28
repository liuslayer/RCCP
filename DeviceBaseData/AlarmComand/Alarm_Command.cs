using Client.Entities.AlarmEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceBaseData
{
    public class Alarm_Command
    {
        public class ArmAndDisarmList_Command
        {
            public List<ArmAndDisarmList> tmpArmAndDisarmList;
            public ArmAndDisarmList tmp_ArmAndDisarmList;
            public class armAndDisarmData
            {
                public List<ArmAndDisarmList> armAndDisarmList;
                public Guid[] tmp_Guid;
            }
            public void ArmAndDisarmList_AddData(List<ArmAndDisarmList> _ArmAndDisarmList)
            {
                if (_ArmAndDisarmList != null && _ArmAndDisarmList.Count > 0)
                {
                    armAndDisarmData data = new armAndDisarmData();
                    data.armAndDisarmList = _ArmAndDisarmList;
                    string str = JsonConvert.SerializeObject(data);
                    string message = "GetArmAndDisarmList/Add," + str + "\r\n";
                    byte[] b = Encoding.UTF8.GetBytes(message);
                    CommunicationClass.stream2.Write(b, 0, b.Length);
                }
            }
            //
            public List<ArmAndDisarmList> ArmAndDisarmList_QueryData()
            {
                List<ArmAndDisarmList> tmpQueryData = new List<ArmAndDisarmList>();
                armAndDisarmData data = new armAndDisarmData();
                string message = "GetArmAndDisarmList/Query" + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);

                string responseData = String.Empty;
                b = new Byte[1024 * 100];

                Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
                responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
                armAndDisarmData AlarmData = new armAndDisarmData();
                AlarmData = JsonConvert.DeserializeObject<armAndDisarmData>(responseData);

                tmpQueryData = AlarmData.armAndDisarmList;
                return tmpQueryData;
            }
            public void ArmAndDisarmList_ReviseData(List<ArmAndDisarmList> _ArmAndDisarmList)
            {
                if (_ArmAndDisarmList != null && _ArmAndDisarmList.Count > 0)
                {
                    armAndDisarmData data = new armAndDisarmData();
                    data.armAndDisarmList = _ArmAndDisarmList;
                    string str = JsonConvert.SerializeObject(data);
                    string message = "GetArmAndDisarmList/Revise," + str + "\r\n";
                    byte[] b = Encoding.UTF8.GetBytes(message);
                    CommunicationClass.stream2.Write(b, 0, b.Length);

                }
            }
            public void ArmAndDisarmList_DelData(Guid[] _GuisList)
            {
                if (_GuisList != null && _GuisList.Length > 0)
                {
                    armAndDisarmData data = new armAndDisarmData();
                    data.tmp_Guid = _GuisList;
                    string str = JsonConvert.SerializeObject(data);
                    string message = "GetArmAndDisarmList/Del," + str + "\r\n";
                    byte[] b = Encoding.UTF8.GetBytes(message);
                    CommunicationClass.stream2.Write(b, 0, b.Length);
                }
            }

            public void ArmAndDisarmList_AllDelData()
            {
                string message = "GetArmAndDisarmList/AllDel," + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
    }
}
