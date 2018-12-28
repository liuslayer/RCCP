using EquipmentControlServer.ProtocolData;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EquipmentControlServer
{
    public class UPSData_AutomaticAcquisition
    {
        static List<UPSList> upsList;
        static UPSListRepository tmpUpsList = new UPSListRepository();
        static Thread t;
        /// <summary>
        /// 初始化UPS静态数据
        /// </summary>
        public static void DataInit()
        {
            upsList = tmpUpsList.GetList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>1表示UPS表有数据开启线程，-1表示UPS表没有数据不开启线程</returns>
        public static int seviceInfo()
        {
            int i = 0;
            if (upsList.Count > 0)
            {
                t = new Thread(TestSetThred);
                i = 1;
            }
            else
            {
                i = -1;
            }
            return i;
        }

        private static void TestSetThred()
        {

            while(true)
            {
                for(int i=0;i< upsList.Count;i++)
                {
                    if (upsList[i].ProtocolType == (int)ControlProtocolType.UPS_3onedata)
                    {
                        if (upsList[i].CommunicationID != null)
                        {
                            ProtocolUPS_3onedata_Business.GetUPSData(upsList[i].CommunicationID, upsList[i].CommunicationType.ToString());
                        }
                        
                    }
                }
                //60000 600000
                Thread.Sleep(10000);
            }
        }

        public static void ThreadOpen()
        {
            t.Start();
        }

        public static void ThreadStop()
        {
            t.Abort();
        }
    }
}
