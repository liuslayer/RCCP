using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer
{

    public class ControlCommandData
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public enum VideoCommandType
    {
        VideoCCD = 101,
        VideoIR,
        VideoPTZ
    }
    /// <summary>
    /// 
    /// </summary>
    public enum VideoProtectType
    {
        Protect_Open,
        Protect_Off
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ControlProtocolType
    {
        //GS-GraduateSchool 研究所
        //CIVIL 民用
        /// <summary>
        /// 209所
        /// </summary>
        GS209_RY=1,
        /// <summary>
        /// 209所-神戎
        /// </summary>
        GS209_SR,
        /// <summary>
        /// 209所—PT100
        /// </summary>
        GS209_PT100,
        /// <summary>
        /// 368所-白家
        /// </summary>
        GS368_BJ,
        /// <summary>
        /// 368所-吉达 神戎
        /// </summary>
        GS368_JDSR,
        /// <summary>
        /// 368所-吉达 大力
        /// </summary>
        GS368_JDDL,
        /// <summary>
        /// 508-阿里
        /// </summary>
        GS508_Ali,
        /// <summary>
        /// 11所
        /// </summary>
        GS11s,
        /// <summary>
        /// 5308所-OP3
        /// </summary>
        GS5308_OP3,
        /// <summary>
        /// 211所-OT11
        /// </summary>
        GS211_OT11,
        /// <summary>
        /// 民用-高普乐
        /// </summary>
        CIVIL_GPL,
        /// <summary>
        /// 民用-PelcoD通用
        /// </summary>
        CIVIL_PelcoD,
        /// <summary>
        /// 民用-PelcoP通用
        /// </summary>
        CIVIL_PelcoP,
        /// <summary>
        /// UPS-三旺 
        /// </summary>
        UPS_3onedata
    }
    /// <summary>
    /// 
    /// </summary>
    public enum HDCommand
    {
        /// <summary>
        /// 复位
        /// </summary>
        InitialPoint,
        /// <summary>
        /// 电机 开
        /// </summary>
        MotorOpen,
        /// <summary>
        /// 电机 关
        /// </summary>
        MotorOff,
        /// <summary>
        /// 自检
        /// </summary>
        SelfDetection,
        /// <summary>
        /// 上
        /// </summary>
        Up,
        /// <summary>
        /// 下
        /// </summary>
        Down,
        /// <summary>
        /// 左
        /// </summary>
        Left,
        /// <summary>
        /// 右
        /// </summary>
        Right,
        /// <summary>
        /// 左上
        /// </summary>
        LeftUp,
        /// <summary>
        /// 左下
        /// </summary>
        LeftDown,
        /// <summary>
        /// 右上
        /// </summary>
        RightUp,
        /// <summary>
        /// 右下
        /// </summary>
        RightDown,
        /// <summary>
        /// 停
        /// </summary>
        DirectionStop,
        /// <summary>
        /// 风扇1 开
        /// </summary>
        FanOpen1,
        /// <summary>
        /// 风扇1 关
        /// </summary>
        FanOff1,
        /// <summary>
        /// 风扇2 开
        /// </summary>
        FanOpen2,
        /// <summary>
        /// 风扇2 关
        /// </summary>
        FanOff2,
        /// <summary>
        /// 加热片1 开
        /// </summary>
        HeatingSheetOpen1,
        /// <summary>
        /// 加热片1 关
        /// </summary>
        HeatingSheetOff1,
        /// <summary>
        /// 加热片2 开
        /// </summary>
        HeatingSheetOpen2,
        /// <summary>
        /// 加热片2 关
        /// </summary>
        HeatingSheetOff2,
        /// <summary>
        /// 水平查询
        /// </summary>
        HorizontalQuery,
        /// <summary>
        /// 俯仰查询
        /// </summary>
        VerticalQuery
    }
    /// <summary>
    /// 
    /// </summary>
    public enum CCDCommand
    {
        /// <summary>
        /// 视场+
        /// </summary>
        CCD_TurnLong,
        /// <summary>
        /// 视场+ 停
        /// </summary>
        CCD_TurnLongStop,
        /// <summary>
        /// 视场-
        /// </summary>
        CCD_TurnShort,
        /// <summary>
        /// 视场- 停
        /// </summary>
        CCD_TurnShortStop,
        /// <summary>
        /// 聚焦+
        /// </summary>
        CCD_FocusLong,
        /// <summary>
        /// 聚焦+ 停
        /// </summary>
        CCD_FocusLongStop,
        /// <summary>
        /// 聚焦-
        /// </summary>
        CCD_FocusShort,
        /// <summary>
        /// 聚焦- 停
        /// </summary>
        CCD_FocusShortStop,
        /// <summary>
        /// 光圈 -
        /// </summary>
        CCD_ApertureSub,
        /// <summary>
        /// 光圈+
        /// </summary>
        CCD_AperturePlus,
        /// <summary>
        /// 光圈手动
        /// </summary>
        CCD_ApertureManual,
        /// <summary>
        /// 光圈自动
        /// </summary>
        CCD_ApertureAuto,
        /// <summary>
        /// 快门校正
        /// </summary>
        CCD_ShutterCorrection,
        /// <summary>
        /// 自动聚焦
        /// </summary>
        CCD_Autofocus,
        /// <summary>
        /// 自动聚焦 开
        /// </summary>
        CCD_AutofocusOpen,
        /// <summary>
        /// 自动聚焦 关
        /// </summary>
        CCD_AutofocusOff,
        /// <summary>
        /// 后焦微调
        /// </summary>
        CCD_RearFocus,
        /// <summary>
        /// 透雾开
        /// </summary>
        CCD_PenetratingFogOpen,
        /// <summary>
        /// 透雾关
        /// </summary>
        CCD_PenetratingFogOff,
        /// <summary>
        /// 白光 开
        /// </summary>
        CCD_Open,
        /// <summary>
        /// 白光 关
        /// </summary>
        CCD_Off,
        /// <summary>
        /// 视场值查询
        /// </summary>
        CCD_TurnShortQuery,
        /// <summary>
        /// 聚焦值查询
        /// </summary>
        CCD_FocusLongQuery
    }
    /// <summary>
    /// 
    /// </summary>
    public enum IRCommand
    {
        /// <summary>
        /// 视场+
        /// </summary>
        IR_TurnLong,
        /// <summary>
        /// 视场+ 停
        /// </summary>
        IR_TurnLongStop,
        /// <summary>
        /// 视场-
        /// </summary>
        IR_TurnShort,
        /// <summary>
        /// 视场- 停
        /// </summary>
        IR_TurnShortStop,
        /// <summary>
        /// 聚焦+
        /// </summary>
        IR_FocusLong,
        /// <summary>
        /// 聚焦停
        /// </summary>
        IR_FocusStop,
        /// <summary>
        /// 聚焦-
        /// </summary>
        IR_FocusShort,
        /// <summary>
        /// 十字叉 开
        /// </summary>
        IR_CrossForksOpen,
        /// <summary>
        /// 十字叉 关
        /// </summary>
        IR_CrossForksOff,
        /// <summary>
        /// 图像增强 开
        /// </summary>
        IR_ImageEnhancementOpen,
        /// <summary>
        /// 图像增强 关
        /// </summary>
        IR_ImageEnhancementOff,
        /// <summary>
        /// 白热模式
        /// </summary>
        IR_WhiteHeatModel,
        /// <summary>
        /// 黑热模式
        /// </summary>
        IR_BlackHeatModel,
        /// <summary>
        /// 1X镜头
        /// </summary>
        IR_1XLens,
        /// <summary>
        /// 2X镜头
        /// </summary>
        IR_2XLens,
        /// <summary>
        /// 自动聚焦 开
        /// </summary>
        IR_AutofocusOpen,
        /// <summary>
        /// 自动聚焦 关
        /// </summary>
        IR_AutofocusOff,
        /// <summary>
        /// 手动
        /// </summary>
        IR_ManualCorrection,
        /// <summary>
        /// 背景
        /// </summary>
        IR_BackgroundCorrection,
        /// <summary>
        /// 伽马
        /// </summary>
        IR_GammaCorrection,
        /// <summary>
        /// 快门
        /// </summary>
        IR_ShutterCorrection,
        /// <summary>
        /// 红外 开
        /// </summary>
        IR_Open,
        /// <summary>
        /// 红外 关
        /// </summary>
        IR_Off,
        /// <summary>
        /// 亮度
        /// </summary>
        IR_Brightness,
        /// <summary>
        /// 对比度
        /// </summary>
        IR_ContrastRatio,
        /// <summary>
        /// 伪彩
        /// </summary>
        IR_FalseColor,
        /// <summary>
        /// 自动校正 开
        /// </summary>
        IR_AutomaticCorrectionOpen,
        /// <summary>
        /// 自动校正 关
        /// </summary>
        IR_AutomaticCorrectionOff,
        /// <summary>
        /// 红外变倍
        /// </summary>
        IR_TurnShortQuery
    }
    /// <summary>
    /// 转台方位、俯仰；镜头变倍聚焦；等控制
    /// </summary>
    public class ControlData
    {
        public Guid? VideoGuid;//视频GUID
        public int VideoType;//视频类型
        public Guid? UserGuid;//用户GUDI 备用
        public int iAction;//设备动作
        public int iSpeed;//设备速度
        public int Parameter; //设备控制值

    }
    /// <summary>
    /// 转台扇扫数据
    /// </summary>
    public class SectorScanData
    {
        public Guid? VideoGuid;
        public int i_HorizontalSt;
        public int i_HorizontalEnd;
        public int i_Hspeed;
        public int i_VerticalSt;
        public int i_VerticalEnd;
        public int i_Vspeed;
    }
    /// <summary>
    /// 转台预置位
    /// </summary>
    public class TurntablePresetData
    {
        public Guid? PresetGuid;
        public string PresetName;
        public Guid? VideoGuid;
        public Guid? UserGuid;
        public int AlarmType;
        public int Time;
    }
    /// <summary>
    /// 转台状态返回数据
    /// </summary>
    public class TurntableStateData
    {
        public Guid? VideoGuid;
        public Guid? UserGuid;
        public double iHorizontalData;
        public double iVerticalData;
        public int iDepth;
        public int iFocus;
    }
}
