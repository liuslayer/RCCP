using Client.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurntableControlInterface
{
    public partial class Preset_WheelGuard_Form : Form
    {
        public Guid? tmpVideoDeviceGuid;
        public Preset_WheelGuard_Form(Guid? VideoDeviceGuid)
        {
            InitializeComponent();
            tmpVideoDeviceGuid = VideoDeviceGuid;
        }
        int m_STime = 0;
        /// <summary>
        /// 开启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wheelGuard_Click(object sender, EventArgs e)
        {
            if (TurntableControlForm.setWheelGuard.ContainsKey(tmpVideoDeviceGuid.Value))
            {

                MessageBox.Show("该设备已启动预置位轮巡功能，请先停止再进行启动！");
            }
            else
            {
                if (dgvWheelGuard.Rows.Count == 0)
                {
                    MessageBox.Show("请添加预置位！");
                    return;
                }
                //m_STime = Convert.ToInt32(comboBox1.Text);
                List<TurntablePresetData> tmp_wheelGuardList = new List<TurntablePresetData>();
                foreach (DataGridViewRow dgvr in this.dgvWheelGuard.Rows)
                {
                    TurntablePresetData tmp_wheelGuard = new TurntablePresetData();
                    tmp_wheelGuard.VideoGuid = tmpVideoDeviceGuid;
                    tmp_wheelGuard.PresetName = dgvr.Cells["PresetName"].Value.ToString();
                    tmp_wheelGuard.Time = Convert.ToInt32(dgvr.Cells["WheelTime"].Value);
                    
                    if (checkBox2.Checked)
                    {
                        tmp_wheelGuard.AlarmType = 1;
                    }
                    tmp_wheelGuardList.Add(tmp_wheelGuard);
                }
                SetWheelGuard tmp_SetWheelGuard = new SetWheelGuard();
                TurntableControlForm.setWheelGuard.Add(tmpVideoDeviceGuid.Value, tmp_SetWheelGuard);
                TurntableControlForm.setWheelGuard[tmpVideoDeviceGuid.Value].seviceInfo(tmp_wheelGuardList);
                TurntableControlForm.setWheelGuard[tmpVideoDeviceGuid.Value].ThreadOpen();
                TurntableControlForm.wheelGuardData.Add(tmpVideoDeviceGuid.Value, tmp_wheelGuardList);
                MessageBox.Show("预置位轮巡启动！");
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (TurntableControlForm.setWheelGuard.ContainsKey(tmpVideoDeviceGuid.Value))
            {
                TurntableControlForm.setWheelGuard[tmpVideoDeviceGuid.Value].ThreadStop();
                TurntableControlForm.setWheelGuard.Remove(tmpVideoDeviceGuid.Value);
                TurntableControlForm.wheelGuardData.Remove(tmpVideoDeviceGuid.Value);
                MessageBox.Show("当前设置的预置位已停止！");
                //foreach (DataGridViewRow dgvr in this.dgvWheelGuard.Rows)
                //{
                //}
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            addToListView_Click(null, null);
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvWheelGuard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTime.Text = dgvWheelGuard.Rows[dgvWheelGuard.CurrentRow.Index].Cells["WheelTime"].Value.ToString();
        }
        private void addToListView_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                DataGridViewRow dgvr = dgvWheelGuard.Rows[dgvWheelGuard.Rows.Add()];
                dgvr.Cells["PresetName"].Value = listBox1.SelectedItem.ToString();
                dgvr.Cells["WheelTime"].Value = "15";
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("请选中想要添加的项");
            }
        }

        private void subToListView_Click(object sender, EventArgs e)
        {
            /*--先判断假如正在轮巡则不能移除--*/
            //if (frm.DI.setWheelGuard.ContainsKey(frm.node.thiscamera_assembly.CameraBase.Turntable_PTZ_DeviceID))
            //{
            //    MessageBox.Show("请先停止预置位轮巡再进行移除");
            //}
            //else
            //{
            foreach (DataGridViewRow dgvr in this.dgvWheelGuard.SelectedRows)
            {
                listBox1.Items.Add(dgvr.Cells["PresetName"].Value);
                this.dgvWheelGuard.Rows.Remove(dgvr);
            }
            //}
        }

        private void Preset_WheelGuard_Form_Load(object sender, EventArgs e)
        {
            List<TurntablePresetData> presetList;
            presetList = InterfaceControl.GetPreset(tmpVideoDeviceGuid);
            if (presetList != null)
            {
                for (int i = 0; i < presetList.Count; i++)
                {
                    listBox1.Items.Add(presetList[i].PresetName);
                }
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection dgvsrc = this.dgvWheelGuard.SelectedRows;//获取选中行的集合
                if (dgvsrc.Count > 0)
                {
                    int index = this.dgvWheelGuard.SelectedRows[0].Index;//获取当前选中行的索引
                    if (index > 0)//如果该行不是第一行
                    {
                        DataGridViewRow dgvr = this.dgvWheelGuard.Rows[index - dgvsrc.Count];//获取选中行的上一行
                        this.dgvWheelGuard.Rows.RemoveAt(index - dgvsrc.Count);//删除原选中行的上一行
                        this.dgvWheelGuard.Rows.Insert((index), dgvr);//将选中行的上一行插入到选中行的后面
                        for (int i = 0; i < dgvsrc.Count; i++)//选中移动后的行
                        {
                            this.dgvWheelGuard.Rows[index - i - 1].Selected = true;
                        }
                    }

                }
            }
            catch { }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection dgvsrc = this.dgvWheelGuard.SelectedRows;//获取选中行的集合
                if (dgvsrc.Count > 0)
                {
                    int index = this.dgvWheelGuard.SelectedRows[0].Index;//获取当前选中行的索引
                    if (index >= 0 & (this.dgvWheelGuard.RowCount - 1) != index)//如果该行不是最后一行
                    {
                        DataGridViewRow dgvr = this.dgvWheelGuard.Rows[index + 1];//获取选中行的下一行
                        this.dgvWheelGuard.Rows.RemoveAt(index + 1);//删除原选中行的上一行
                        this.dgvWheelGuard.Rows.Insert((index + 1 - dgvsrc.Count), dgvr);//将选中行的上一行插入到选中行的后面
                        for (int i = 0; i < dgvsrc.Count; i++)//选中移动后的行
                        {
                            this.dgvWheelGuard.Rows[index + 1 - i].Selected = true;
                        }
                    }

                }
            }
            catch { }
        }

        private void button_sure_Click(object sender, EventArgs e)
        {
            string changeTime = txtTime.Text;
            if (changeTime != "")
            {
                foreach (DataGridViewRow dgvr in dgvWheelGuard.SelectedRows)
                {
                    dgvr.Cells["WheelTime"].Value = changeTime;
                }
                checkBox1.Checked = false;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && e.KeyChar != '.' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < dgvWheelGuard.Rows.Count; i++)
                {
                    dgvWheelGuard.Rows[i].Cells["WheelTime"].Value = comboBox1.Text;
                }
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
