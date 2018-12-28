using DeviceBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace DeviceRTStatus
{
    public class NetPing
    {
        public static List<string> IP = new List<string>();
        public static List<int> status = new List<int>();
        //public static Dictionary<string, int> Dictionary_Status = new Dictionary<string, int>();
        public static void StateCallback()
        {
            if (Class1.streamMediaList != null)
            {
                for (int i = 0; i < Class1.streamMediaList.Count; i++)
                {
                    IP.Add(Class1.streamMediaList[i].VideoIP);
                    status.Add(0);
                }
                int r = (int)Math.Ceiling(Class1.streamMediaList.Count / (double)3);
                for (int i = 0; i < r; i++)
                {
                    Thread state_p = new Thread(DataPing);
                    state_p.IsBackground = true;
                    state_p.Start(i + 1);
                }
            }
        }
        private static void DataPing(object o)
        {
            int a = (int)o;
            int ping_time = 10000;
            
            while (true)
            {
                for (int i = 0; i < 3; i++)
                {
                    //this.lst_PingResult.Items.Clear();
                    //远程服务器IP  
                    if (((a - 1) * 3 + i) < Class1.streamMediaList.Count)
                    {
                        string ipStr = Class1.streamMediaList[(a - 1) * 3 + i].VideoIP;
                        //构造Ping实例  
                        Ping pingSender = new Ping();
                        //Ping 选项设置  
                        PingOptions options = new PingOptions();
                        options.DontFragment = true;
                        //测试数据  
                        string data = "test data abcabc";
                        byte[] buffer = Encoding.ASCII.GetBytes(data);
                        //设置超时时间  
                        int timeout = 200;
                        //调用同步 send 方法发送数据,将返回结果保存至PingReply实例  
                        try
                        {
                            PingReply reply = pingSender.Send(ipStr, timeout, buffer, options);
                            if (reply.Status == IPStatus.Success)
                            {
                                for (int j = 0; j < IP.Count; j++)
                                {
                                    if (IP[j] == ipStr)
                                        status[j] = 1;
                                }
                                
                                ping_time = 10000;
                            }
                            else//如果ping第一次没有成功
                            {
                                //ping第二次进行测试，成功依然为正常
                                PingReply reply_1 = pingSender.Send(ipStr, timeout, buffer, options);
                                {
                                    if (reply_1.Status == IPStatus.Success)
                                    {
                                        for (int j = 0; j < IP.Count; j++)
                                        {
                                            if (IP[j] == ipStr)
                                                status[j] = 1;
                                        }

                                    }
                                    else
                                    {
                                        for (int j = 0; j < IP.Count; j++)
                                        {
                                            if (IP[j] == ipStr)
                                                status[j] = 0;
                                        }
                                        ping_time = 1000;
                                    }
                                }
                            }
                        }
                        catch
                        {
                            for (int j = 0; j < IP.Count; j++)
                            {
                                if (IP[j] == ipStr)
                                    status[j] = 0;
                            }
                            ping_time = 1000;
                        }
                        Thread.Sleep(ping_time);
                    }
                }
            }
        }
    
    }
}
