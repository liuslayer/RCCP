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
    
    public partial class ConfigCameraInfo : Form
    {

        List<CameraList> tmpListCamera;
        CameraList _tmpCameraList = new CameraList();
        Camera_Command tmpCamera_Command = new Camera_Command();

        List<DeviceTypeList> tmpListDeviceType;
        DeviceTypeList _tmpDeviceTypeList = new DeviceTypeList();
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();

        List<StreamMediaList> tmpListStreamMedia;
        StreamMediaList _tmpStreamMediaList = new StreamMediaList();
        StreamMedia_Command tmpStreamMediaCommand = new StreamMedia_Command();

        List<TurnTableList> tmpListTurnTable;
        TurnTableList _tmpTurnTableList = new TurnTableList();
        TurnTable_Command tmpTurnTable_Command = new TurnTable_Command();

        public ConfigCameraInfo()
        {
            InitializeComponent();
            GetCameraList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[14].Visible = false;
        }
        public void GetCameraList()
        {
            tmpListCamera = tmpCamera_Command._QueryData();
            tmpListDeviceType = tmpDeviceTypeCommand._QueryData();
            tmpListStreamMedia = tmpStreamMediaCommand._QueryData();
            tmpListTurnTable = tmpTurnTable_Command._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpListCamera.Count > 0)
            {
                for(int i=0;i< tmpListCamera.Count;i++)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = tmpListCamera[i].DeviceID;
                    dataGridView1.Rows[index].Cells[1].Value = tmpListCamera[i].VideoName;
                    //设备所属类型
                    if (tmpListDeviceType.Count > 0)
                    {
                        for (int j = 0; j < tmpListDeviceType.Count; j++)
                        {
                            if (tmpListCamera[i].TypeID == tmpListDeviceType[j].TypeID)
                            {
                                dataGridView1.Rows[index].Cells[2].Value = tmpListDeviceType[j].TypeName;
                                dataGridView1.Rows[index].Cells[3].Value = tmpListDeviceType[j].ID.ToString();
                                break;
                            }
                        }
                    }
                    else
                    {
                        dataGridView1.Rows[index].Cells[2].Value = null;
                        dataGridView1.Rows[index].Cells[3].Value = null;
                    }

                    //设备所属流媒体
                    if (tmpListStreamMedia.Count > 0)
                    {
                        for (int k = 0; k < tmpListStreamMedia.Count; k++)
                        {
                            if (tmpListCamera[i].StreamMedia_DeviceID == tmpListStreamMedia[k].DeviceID)
                            {
                                dataGridView1.Rows[index].Cells[4].Value = tmpListStreamMedia[k].Name;
                                dataGridView1.Rows[index].Cells[5].Value = tmpListStreamMedia[k].DeviceID.ToString();
                                break;
                            }
                        }
                    }
                    else
                    {
                        dataGridView1.Rows[index].Cells[4].Value = null;
                        dataGridView1.Rows[index].Cells[5].Value = null;
                    }
                    dataGridView1.Rows[index].Cells[6].Value = tmpListCamera[i].VideoChannel;

                    if (Convert.ToInt32( tmpListCamera[i].VideoType) == (int)VideoCommandType.VideoCCD)
                    {
                        dataGridView1.Rows[index].Cells[7].Value = "白光";
                    }
                    else if (Convert.ToInt32(tmpListCamera[i].VideoType) == (int)VideoCommandType.VideoIR)
                    {
                        dataGridView1.Rows[index].Cells[7].Value = "红外";
                    }
                    else if (Convert.ToInt32(tmpListCamera[i].VideoType) == (int)VideoCommandType.VideoPTZ)
                    {
                        dataGridView1.Rows[index].Cells[7].Value = "球机";
                    }
                    dataGridView1.Rows[index].Cells[8].Value = tmpListCamera[i].DepthMAX;
                    dataGridView1.Rows[index].Cells[9].Value = tmpListCamera[i].FocusMAX;
                    dataGridView1.Rows[index].Cells[10].Value = tmpListCamera[i].HorizontalMAX;
                    dataGridView1.Rows[index].Cells[11].Value = tmpListCamera[i].VerticalMAX;
                    dataGridView1.Rows[index].Cells[12].Value = tmpListCamera[i].VisualDistanceMAX;
                    //所属转台
                    if (tmpListTurnTable.Count > 0)
                    {
                        for (int k = 0; k < tmpListTurnTable.Count; k++)
                        {
                            if (tmpListCamera[i].Turntable_PTZ_DeviceID == tmpListTurnTable[k].DeviceID)
                            {
                                dataGridView1.Rows[index].Cells[13].Value = tmpListTurnTable[k].Name;
                                dataGridView1.Rows[index].Cells[14].Value = tmpListTurnTable[k].DeviceID.ToString();
                                break;
                            }
                        }
                    }
                    else
                    {
                        dataGridView1.Rows[index].Cells[13].Value = null;
                        dataGridView1.Rows[index].Cells[14].Value = null;
                    }

                    dataGridView1.Rows[index].Cells[15].Value = tmpListCamera[i].Description;
                }
            }
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _tmpCameraList.DeviceID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }
        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            CameraList _tmpData = null;
            Add_Modify_Camera tmpAdd_Modify_Camera = new Add_Modify_Camera(_tmpData);
            tmpAdd_Modify_Camera.ShowDialog();
            if(tmpAdd_Modify_Camera.result == DialogResult.OK)
            {
                GetCameraList();
            }
        }

        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            CameraList _tmpData = new CameraList();
            for (int i = 0; i < tmpListCamera.Count; i++)
            {
                if(_tmpCameraList.DeviceID == tmpListCamera[i].DeviceID)
                {
                    _tmpData = tmpListCamera[i];
                    break;
                }
            }
            Add_Modify_Camera tmpAdd_Modify_Camera = new Add_Modify_Camera(_tmpData);
            tmpAdd_Modify_Camera.ShowDialog();
            if (tmpAdd_Modify_Camera.result == DialogResult.OK)
            {
                GetCameraList();
            }
        }

        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            Guid[] _Guid = new Guid[1];
            if (_tmpCameraList.DeviceID != null)
            {
                _Guid[0] = _tmpCameraList.DeviceID;
                tmpCamera_Command._DelData(_Guid);
                GetCameraList();
            }
        }
    }
}
