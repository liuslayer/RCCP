using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Entities
{
    public enum ServerType
    {
        DeviceRealTimeData=0,//设备实时数据
        Alarm,//报警：临时报警、联动报警
        Intercom//对讲
    }

}
