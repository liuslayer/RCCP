using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalDataCentreService
{
    
    public class ControlCommandData
    {
        public enum VideoCommandType
        {
            VideoCCD = 101,
            VideoIR,
            VideoPTZ
        }
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
            VerticalQuery,
        }

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
            /// 快门校正
            /// </summary>
            CCD_ShutterCorrection,
            /// <summary>
            /// 自动聚焦
            /// </summary>
            CCD_Autofocus,
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
            CCD_Off
        }

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
            IR_Off

        }
    }
    public class ControlData
    {
        public Guid? VideoGuid;
        public int VideoType;
        public Guid? UserGuid;
        public int iAction;
        public int iSpeed;
        public int Parameter;

    }
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
