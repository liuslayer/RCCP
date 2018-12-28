using AlarmService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlarmService;

namespace RCCP.UnitTest
{
    [TestClass]
    public class AlarmTest
    {
        [TestMethod]
        public void TempAlarm()
        {
            MediaData.AlarmCallback temp_a = new MediaData.AlarmCallback();
            long AlarmFingerprintID=0;
            //temp_a.alarmCallBack("192.168.10.111,1",18,0,ref AlarmFingerprintID);
        }
    }
}
