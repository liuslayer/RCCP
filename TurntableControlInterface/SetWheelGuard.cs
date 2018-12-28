using AccessOperation;
using Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TurntableControlInterface
{
    public class SetWheelGuard
    {
        Thread t;
        List<TurntablePresetData> tmpData;
        public void seviceInfo(List<TurntablePresetData> tmp_wheelGuardList)
        {
            tmpData = tmp_wheelGuardList;
            t = new Thread(TestSetThred);
        }
        private void TestSetThred()
        {
            while (true)
            {
                TurntablePresetData tmpPresetData = new TurntablePresetData();
                for (int i = 0; i < tmpData.Count; i++)
                {
                    tmpPresetData.PresetName = tmpData[i].PresetName;
                    tmpPresetData.VideoGuid = tmpData[i].VideoGuid;
                    InterfaceControl.SetPreset(tmpPresetData);
                    Thread.Sleep(9 * 1000);
                    if (tmpData[i].AlarmType == 1)
                    {
                        //布防
                        AlarmSetSDK.AlarmSet_Yang(tmpData[i].VideoGuid.Value, tmpData[i].PresetName, 1);
                    }
                    Thread.Sleep((tmpData[i].Time - 9) * 1000);
                    if(tmpData[i].AlarmType == 1)
                    {
                        AlarmSetSDK.AlarmSet_Yang(tmpData[i].VideoGuid.Value, tmpData[i].PresetName, 0);
                    }
                    Thread.Sleep(2 * 1000);
                }
            }
        }

        /// <summary>
        /// 开启线程
        /// </summary>
        public void ThreadOpen()
        {
            t.Start();
        }

        /// <summary>
        /// 关闭线程
        /// </summary>
        public void ThreadStop()
        {
            t.Abort();
        }
    }
}
