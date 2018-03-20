using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMServer.Model
{
    public enum Command
    {
        putdeviceups = 1,
        putdevicepower,
        putcamera,
        putstation,
        putfactory,
        puttbservice,
        putalarm,
        putvoice,
        putrecontrol
    }

    public enum ResStatus
    {
        成功 = 0,
        错误 = -1,
        系统错误 = -2
    }
}