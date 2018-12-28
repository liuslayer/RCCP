using Client.Entities;
using Client.Entities.ControlEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Client.Entities.ControlCommandData;

namespace TurntableControlInterface
{
    public partial class Preset_Add_Form : Form
    {
        public Guid tmpVideoGuid;
        public int tmpVideoType;
        public string tmpHorizontal_Data;
        public string tmpVertical_Data;
        public string tmpCCDorIR_Depth;
        public string tmpCCDorIR_Focus;
        public Guid? tmpUserGuid;
        List<TurntablePresetData> tmpPrese;
        //public Preset_Add_Form(Guid VideoGuid, int VideoType, string Horizontal_Data, string Vertical_Data, string CCDorIR_Depth, string CCDorIR_Focus,
            //Guid? UserGuid)
        public Preset_Add_Form(Guid VideoGuid)
        {
            InitializeComponent();
            tmpVideoGuid = VideoGuid;
            tmpPrese = Control_Command.PresetGetControl(VideoGuid);
            //tmpVideoGuid = VideoGuid;
            //tmpVideoType = VideoType;
            //tmpHorizontal_Data = Horizontal_Data;
            //tmpVertical_Data = Vertical_Data;
            //tmpCCDorIR_Depth = CCDorIR_Depth;
            //tmpCCDorIR_Focus = CCDorIR_Focus;
            //tmpUserGuid = UserGuid;
    }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (addNameText.Text.Trim() == "")
            {
                MessageBox.Show("请输入预置位名称！");
                return;
            }
            else if(addNameText.Text.Trim().Length>25)
            {
                MessageBox.Show("预置位名称过长,请重新输入！");
                return;
            }
            else
            {
                if (tmpPrese !=null)
                {
                    for (int i = 0; i < tmpPrese.Count; i++)
                    {
                        if(tmpPrese[i].PresetName == addNameText.Text.Trim())
                        {
                            MessageBox.Show("预置位名称重复,请重新输入！");
                            return;
                        }
                    }
                }
            }
            
            TurntablePresetData tmpTurntablePresetData = new TurntablePresetData();
            tmpTurntablePresetData.PresetName = addNameText.Text;
            tmpTurntablePresetData.VideoGuid = tmpVideoGuid;
            TurntablePresetData tmpTurntablePresetData1= Control_Command.PresetAddControl(tmpTurntablePresetData);
            MessageBox.Show("预置位添加成功！");
            //if (tmpTurntablePresetData1.PresetGuid != null)
            //{
            //    MessageBox.Show("预置位添加成功！");
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("预置位添加失败！");
            //}
        }
    }
}
