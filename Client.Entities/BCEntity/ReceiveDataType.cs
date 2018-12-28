using Client.Entities.AlarmEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Entities.BCEntity
{
    public class ReceiveDataType
    {
        public ServerType SType;//接收到的数据来自哪个服务
        public AlarmMessageToClient DataPackage;//接收到的数据包
    }
}
