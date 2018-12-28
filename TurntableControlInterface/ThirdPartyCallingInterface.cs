using Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurntableControlInterface
{
    public class ThirdPartyCallingInterface
    {
        /// <summary>
        /// 添加预置位
        /// </summary>
        /// <param name="VideoGuid">视频GUID</param>
        /// <param name="PresetName">预置位名字</param>
        /// <returns>成功返回预置位的GUID</returns>
        public static Guid? PresetAddInterface(Guid VideoGuid, string PresetName)
        {
            Guid? result = null;
            TurntablePresetData tmp_AddPreset = new TurntablePresetData();
            if (VideoGuid != null && PresetName != null)
            {
                tmp_AddPreset.VideoGuid = VideoGuid;
                tmp_AddPreset.PresetName = PresetName;
                TurntablePresetData tmp_AddPreset1 = new TurntablePresetData();
                tmp_AddPreset1 = Control_Command.PresetAddControl(tmp_AddPreset);
                result = tmp_AddPreset1.PresetGuid;
            }
            return result;
        }
        /// <summary>
        /// 删除或调用预置位
        /// </summary>
        /// <param name="PreseGuid">预置位的GUID</param>
        /// <param name="Action">删除：1，调用：2</param>
        /// <returns>成功：1，失败：-1</returns>
        public static int PresetSetOrDelInterface(Guid PreseGuid, int Action)
        {
            int result = -1;
            TurntablePresetData tmp_AddPreset = new TurntablePresetData();
            if (Action == 1)//删除
            {
                tmp_AddPreset.PresetGuid = PreseGuid;
                Control_Command.PresetDelControl(tmp_AddPreset);
                result = 1;
            }
            else if(Action == 2)//调用
            {
                tmp_AddPreset.PresetGuid = PreseGuid;
                Control_Command.PresetSetControl(tmp_AddPreset);
                result = 1;
            }
            return result;
        }
    }
}
