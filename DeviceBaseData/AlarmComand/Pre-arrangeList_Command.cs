using Client.Entities.AlarmEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceBaseData
{
    public class Pre_arrangeList_Command
    {
        public class Pre_Command
        {
            public List<Pre_arrangeList> tmpPre_arrangeList;
            public Pre_arrangeList tmp_Pre_arrangeList;
            public class pre_arrangeList
            {
                public List<Pre_arrangeList> Pre_arrangeList;
                public Guid[] tmp_Guid;
            }
            public void Pre_arrangeList_AddData(List<Pre_arrangeList> _Pre_arrangeList)
            {
                if (_Pre_arrangeList != null && _Pre_arrangeList.Count > 0)
                {
                    pre_arrangeList data = new pre_arrangeList();
                    data.Pre_arrangeList = _Pre_arrangeList;
                    string str = JsonConvert.SerializeObject(data);
                    string message = "GetPre_arrangeList/Add," + str + "\r\n";
                    byte[] b = Encoding.UTF8.GetBytes(message);
                    CommunicationClass.stream2.Write(b, 0, b.Length);
                }
            }
            //
            public List<Pre_arrangeList> Pre_arrangeList_QueryData()
            {
                List<Pre_arrangeList> tmpQueryData = new List<Pre_arrangeList>();
                pre_arrangeList data = new pre_arrangeList();
                string message = "GetPre_arrangeList/Query" + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);

                string responseData = String.Empty;
                b = new Byte[1024 * 100];

                Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
                responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
                pre_arrangeList AlarmData = new pre_arrangeList();
                AlarmData = JsonConvert.DeserializeObject<pre_arrangeList>(responseData);

                tmpQueryData = AlarmData.Pre_arrangeList;
                return tmpQueryData;
            }
            public void Pre_arrangeList_ReviseData(List<Pre_arrangeList> _Pre_arrangeList)
            {
                if (_Pre_arrangeList != null && _Pre_arrangeList.Count > 0)
                {
                    pre_arrangeList data = new pre_arrangeList();
                    data.Pre_arrangeList = _Pre_arrangeList;
                    string str = JsonConvert.SerializeObject(data);
                    string message = "GetPre_arrangeList/Revise," + str + "\r\n";
                    byte[] b = Encoding.UTF8.GetBytes(message);
                    CommunicationClass.stream2.Write(b, 0, b.Length);

                }
            }
            public void Pre_arrangeList_DelData(Guid[] _GuisList)
            {
                if (_GuisList != null && _GuisList.Length > 0)
                {
                    pre_arrangeList data = new pre_arrangeList();
                    data.tmp_Guid = _GuisList;
                    string str = JsonConvert.SerializeObject(data);
                    string message = "GetPre_arrangeList/Del," + str + "\r\n";
                    byte[] b = Encoding.UTF8.GetBytes(message);
                    CommunicationClass.stream2.Write(b, 0, b.Length);
                }
            }

            public void Pre_arrangeList_AllDelData()
            {
                string message = "GetPre_arrangeList/AllDel," + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
            public List<Pre_arrangeList> Pre_arrangeList_GetListWithCondition(string sql)
            {
                List<Pre_arrangeList> tmpQueryData = new List<Pre_arrangeList>();

                string message = "GetPre_arrangeList/TimeQuery,"  + sql+ "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);

                string responseData = String.Empty;
                b = new Byte[1024 * 100];

                Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
                responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
                pre_arrangeList AlarmData = new pre_arrangeList();
                AlarmData = JsonConvert.DeserializeObject<pre_arrangeList>(responseData);

                tmpQueryData = AlarmData.Pre_arrangeList;
                return tmpQueryData;
            }
        }
    }
}
