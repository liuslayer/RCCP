using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ClassLibrary1
{
    public class VM_Player_Vlc
    {
        [DllImport("VM.Player.Vlc.dll",CallingConvention=CallingConvention.Cdecl)]
        public static extern int VMK_Player_Open(int lPort, string sFileName);//打开文件
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_Close(int lPort);//关闭文件
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_GetLastError(int lPort);//获取错误代码
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_SetHwnd(int lPort, IntPtr hwnd);//设置播放的窗口
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_Play(int lPort);//播放
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_Stop(int lPort);//停止
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int  VMK_Player_Pause(int lPort, bool bPause);//True-暂停，False-恢复
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_Fast(int lPort);//快放，每次播放速度快一倍，最多四次
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_Slow(int lPort);//慢放，每次播放速度慢一倍，最多四次
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_ReSpeed(int lPort);//恢复播放速度
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_OpenSound(int lPort);//打开声音
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_CloseSound(int lPort);//关闭声音
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_SetVolume(int lPort, byte byVolume);//设置声音
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_GetVolume(int lPort);//获取声音
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_GetState(int lPort);//获取状态
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_GetTime(int lPort);//获取文件总时间，单位毫秒
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_GetPlayedTime(int lPort);//获取当前播放时间，单位毫秒
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_SetPlayedTime(int lPort, int lTime);//设置当前播放时间，单位毫秒
        //[DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        // public static extern int VMK_Player_GetPictureSize(int lPort, int* pWidth, int* pHeight);//获取图像大小
        [DllImport("VM.Player.Vlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VMK_Player_SavePicture(int lPort, string sPicName, int lType);//抓图,1-BMP,2-JPG
    }
}
