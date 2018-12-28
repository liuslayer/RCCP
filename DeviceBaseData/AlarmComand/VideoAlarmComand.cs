using Client.Entities.AlarmEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceBaseData.AlarmComand
{
    public class VideoAlarmComand
    {
        public class VideoAlarmList_Command
        {
            public List<VideoAlarmList> tmpVideoAlarmList;
            public VideoAlarmList tmp_VideoAlarmList;
            public class videoAlarmLsitData
            {
                public List<VideoAlarmList> VideoAlarmList;
                public Guid[] tmp_Guid;
            }
            public void VideoAlarmList_AddData(List<VideoAlarmList> _VideoAlarmList)
            {
                if (_VideoAlarmList != null && _VideoAlarmList.Count > 0)
                {
                    videoAlarmLsitData data = new videoAlarmLsitData();
                    data.VideoAlarmList = _VideoAlarmList;
                    string str = JsonConvert.SerializeObject(data);
                    string message = "GetVideoAlarmList/Add," + str + "\r\n";
                    byte[] b = Encoding.UTF8.GetBytes(message);
                    CommunicationClass.stream2.Write(b, 0, b.Length);
                }
            }
            //
            public List<VideoAlarmList> VideoAlarmList_QueryData()
            {
                List<VideoAlarmList> tmpQueryData = new List<VideoAlarmList>();
                videoAlarmLsitData data = new videoAlarmLsitData();
                string message = "GetVideoAlarmList/Query" + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);

                string responseData = String.Empty;
                b = new Byte[1024 * 100];

                Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
                responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
                videoAlarmLsitData AlarmData = new videoAlarmLsitData();
                AlarmData = JsonConvert.DeserializeObject<videoAlarmLsitData>(responseData);

                tmpQueryData = AlarmData.VideoAlarmList;
                return tmpQueryData;
            }
            public void VideoAlarmList_ReviseData(List<VideoAlarmList> _VideoAlarmList)
            {
                if (_VideoAlarmList != null && _VideoAlarmList.Count > 0)
                {
                    videoAlarmLsitData data = new videoAlarmLsitData();
                    data.VideoAlarmList = _VideoAlarmList;
                    string str = JsonConvert.SerializeObject(data);
                    string message = "GetVideoAlarmList/Revise," + str + "\r\n";
                    byte[] b = Encoding.UTF8.GetBytes(message);
                    CommunicationClass.stream2.Write(b, 0, b.Length);

                }
            }
            public void VideoAlarmList_DelData(Guid[] _GuisList)
            {
                if (_GuisList != null && _GuisList.Length > 0)
                {
                    videoAlarmLsitData data = new videoAlarmLsitData();
                    data.tmp_Guid = _GuisList;
                    string str = JsonConvert.SerializeObject(data);
                    string message = "GetVideoAlarmList/Del," + str + "\r\n";
                    byte[] b = Encoding.UTF8.GetBytes(message);
                    CommunicationClass.stream2.Write(b, 0, b.Length);
                }
            }

            public void VideoAlarmList_AllDelData()
            {
                string message = "GetVideoAlarmList/AllDel," + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
    }
}
