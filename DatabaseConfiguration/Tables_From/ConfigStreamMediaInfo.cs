using DatabaseConfiguration.add_edit_dialogs;
using DatabaseConfiguration.CommandFunction;
using DatabaseConfiguration.DeviceEntitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseConfiguration.Tables_From
{
    public partial class ConfigStreamMediaInfo : Form
    {
        List<StreamMediaList> tmpListStreamMedia;
        StreamMediaList _tmpStreamMediaList = new StreamMediaList();
        StreamMedia_Command tmpStreamMediaCommand = new StreamMedia_Command();

        List<DeviceTypeList> tmpListDeviceType;
        DeviceTypeList _tmpDeviceTypeList = new DeviceTypeList();
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();

        List<StationList> tmpListStation;
        Station_Command tmpStationCommand = new Station_Command();

        public ConfigStreamMediaInfo()
        {
            InitializeComponent();
            getStreamMediaList();
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
        }
        /// <summary>
        /// 查询
        /// </summary>
        public void getStreamMediaList()
        {
            tmpListStreamMedia = tmpStreamMediaCommand._QueryData();
            tmpListDeviceType = tmpDeviceTypeCommand._QueryData();
            tmpListStation = tmpStationCommand._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpListStreamMedia.Count > 0)
            {
                for (int i = 0; i < tmpListStreamMedia.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = tmpListStreamMedia[i].Name;
                    if (tmpListDeviceType.Count > 0)
                    {
                        for (int j = 0; j < tmpListDeviceType.Count; j++)
                       {
                            if(tmpListStreamMedia[i].TypeID == tmpListDeviceType[j].TypeID)
                            {
                                dataGridView1.Rows[index].Cells[1].Value = tmpListDeviceType[j].TypeName;
                                dataGridView1.Rows[index].Cells[10].Value = tmpListDeviceType[j].ID.ToString() ;
                                break;
                            }
                       }
                     }
                    else
                    {
                        dataGridView1.Rows[index].Cells[1].Value = null;
                    }
                    
                    dataGridView1.Rows[index].Cells[2].Value = tmpListStreamMedia[i].VideoIP;
                    dataGridView1.Rows[index].Cells[3].Value = tmpListStreamMedia[i].UserName;
                    dataGridView1.Rows[index].Cells[4].Value = tmpListStreamMedia[i].PassWord;
                    dataGridView1.Rows[index].Cells[5].Value = tmpListStreamMedia[i].Port;
                    dataGridView1.Rows[index].Cells[6].Value = tmpListStreamMedia[i].ChannelNum;
                    dataGridView1.Rows[index].Cells[7].Value = tmpListStreamMedia[i].Description;
                    dataGridView1.Rows[index].Cells[8].Value = tmpListStreamMedia[i].DeviceID;
                    dataGridView1.Rows[index].Cells[9].Value = tmpListStreamMedia[i].StreamServerID;
                    if(tmpListStation.Count>0)
                    {
                        for(int k =0; k<tmpListStation.Count; k++)
                        {
                            if(tmpListStreamMedia[i].StationID ==null)
                            {
                                dataGridView1.Rows[index].Cells[11].Value = "无";
                                break;
                            }
                            if (tmpListStreamMedia[i].StationID == tmpListStation[k].StationID)
                            {
                                dataGridView1.Rows[index].Cells[11].Value = tmpListStation[k].Name;
                                break;
                            }
                        }
                    }
                }
            } else { } 
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _tmpStreamMediaList.DeviceID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            StreamMediaList tmpStreamMediaData = null;
            List<DeviceTypeList> tmpDeviceTypeList = tmpListDeviceType;
            Add_Modify_StreamMedia tmp = new Add_Modify_StreamMedia(tmpStreamMediaData, tmpDeviceTypeList);
            tmp.ShowDialog();
            if (tmp.result == DialogResult.OK)
            {
                getStreamMediaList();
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            StreamMediaList tmpStreamMediaData = new StreamMediaList();
            List<DeviceTypeList> tmpDeviceTypeList = tmpListDeviceType;
            for (int i = 0; i < tmpListStreamMedia.Count; i++)
            {
                if(tmpListStreamMedia[i].DeviceID == _tmpStreamMediaList.DeviceID)
                {
                    tmpStreamMediaData = tmpListStreamMedia[i];
                    break;
                }
            }
            Add_Modify_StreamMedia tmp = new Add_Modify_StreamMedia(tmpStreamMediaData, tmpDeviceTypeList);
            tmp.ShowDialog();
            if (tmp.result == DialogResult.OK)
            {
                getStreamMediaList();
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {

            Guid[] _Guid = new Guid[1];
            if (_tmpStreamMediaList.DeviceID != null)
            {
                _Guid[0] = _tmpStreamMediaList.DeviceID;
                tmpStreamMediaCommand._DelData(_Guid);
                getStreamMediaList();
            }
        }
    }
}
