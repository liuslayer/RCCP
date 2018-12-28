using Client.Entities;
using System;
using System.Collections.Generic;

namespace RecDll
{
    public class RecDataClass
    {
        //正在录像的录像信息
        public static Dictionary<string,RecInfo> recInfo;
        public static bool Init()
        {
            try
            {
                recInfo = new Dictionary<string, RecInfo>();
                //登录设备--手动录像
                ManualRec.LogIn();
                //登录设备--自动录像
                //AutoRec.LogIn();
                ////登录设备--报警录像
                //AlarmRec.LogIn();
                //登录设备--截图
                //CapturePic.LogIn();
                return true;
            }
            catch{ return false; }
        }
    }

    public class RecInfo
    {
        public string Name;//名称
        public DateTime DT;//开始时间
        public string RecType;//录像模式

        public RecInfo() { }
        public RecInfo(string name,DateTime dt,string recType)
        {
            Name = name;
            DT = dt;
            RecType = recType;
        }
    }
}