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
    public partial class ConfigVibrationCableInfo : Form
    {
        List<VibrationCableList> tmpListVibrationCable;
        VibrationCableList _VibrationCableList = new VibrationCableList();
        VibrationCable_Command tmpVibrationCableCommand = new VibrationCable_Command();

        List<DeviceTypeList> tmpListDeviceType;
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();

        List<ProtocolTypeList> tmpListProtocolType;
        ProtocolType_Command tmpProtocolTypeCommand = new ProtocolType_Command();

        List<StationList> tmpListStation;
        Station_Command tmpStationCommand = new Station_Command();

        List<SerialCOMList> tmpListSerialCOM;
        SerialCOM_Command tmpSerialCOM_Command = new SerialCOM_Command();
        public ConfigVibrationCableInfo()
        {
            InitializeComponent();
            GetVibrationCableList();
            dataGridView1.Columns[0].Visible = false;
        }

        private void GetVibrationCableList()
        {
            tmpListVibrationCable = tmpVibrationCableCommand._QueryData();
            tmpListDeviceType = tmpDeviceTypeCommand._QueryData();
            tmpListProtocolType = tmpProtocolTypeCommand._QueryData();
            tmpListStation = tmpStationCommand._QueryData();
            tmpListSerialCOM = tmpSerialCOM_Command._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpListVibrationCable.Count > 0)
            {
                
                for (int i = 0; i < tmpListVibrationCable.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    //设备ID
                    dataGridView1.Rows[index].Cells[0].Value = tmpListVibrationCable[i].DeviceID;
                    //设备名称
                    dataGridView1.Rows[index].Cells[1].Value = tmpListVibrationCable[i].Name;
                    //经度
                    if (tmpListVibrationCable[i].Lon != null)
                    {
                        dataGridView1.Rows[index].Cells[3].Value = tmpListVibrationCable[i].Lon;
                    }
                    else { dataGridView1.Rows[index].Cells[3].Value = "无"; }

                    //纬度
                    if (tmpListVibrationCable[i].Lat != null)
                    {
                        dataGridView1.Rows[index].Cells[4].Value = tmpListVibrationCable[i].Lat;
                    }
                    else { dataGridView1.Rows[index].Cells[4].Value = "无"; }
                    //海拔
                    if (tmpListVibrationCable[i].Alt != null)
                    {
                        dataGridView1.Rows[index].Cells[5].Value = tmpListVibrationCable[i].Alt;
                    }
                    else { dataGridView1.Rows[index].Cells[5].Value = "无"; }

                    if (tmpListVibrationCable[i].CommunicationType == (int)CommunicationMode.NoneType)
                    {
                        dataGridView1.Rows[index].Cells[6].Value = "无";
                    }
                    else if (tmpListVibrationCable[i].CommunicationType == (int)CommunicationMode.ComType)
                    {
                        dataGridView1.Rows[index].Cells[6].Value = "串口通信";
                        if (tmpListSerialCOM.Count > 0)
                        {
                            for (int m = 0; m < tmpListSerialCOM.Count; m++)
                            {
                                if (tmpListVibrationCable[i].CommunicationID != null)
                                {
                                    if (tmpListVibrationCable[i].CommunicationID == tmpListSerialCOM[m].DeviceID)
                                    {
                                        dataGridView1.Rows[index].Cells[7].Value = tmpListSerialCOM[m].Name;
                                        break;
                                    }
                                }
                                else
                                {
                                    dataGridView1.Rows[index].Cells[7].Value = "无";
                                }

                            }
                        }
                    }
                    else if (tmpListVibrationCable[i].CommunicationType == (int)CommunicationMode.NetworkType)
                    {
                        dataGridView1.Rows[index].Cells[6].Value = "网络通信";
                        dataGridView1.Rows[index].Cells[7].Value = "无";
                    }
                    //所属工作站
                    if (tmpListStation.Count > 0)
                    {
                        for (int l = 0; l < tmpListStation.Count; l++)
                        {
                            if (tmpListVibrationCable[i].StationID != null)
                            {
                                if (tmpListVibrationCable[i].StationID == tmpListStation[l].StationID)
                                {
                                    dataGridView1.Rows[index].Cells[8].Value = tmpListStation[l].Name;
                                    break;
                                }
                            }
                            else
                            {
                                dataGridView1.Rows[index].Cells[8].Value = "无";
                            }
                        }
                    }

                    //协议类型
                    if (tmpListProtocolType.Count > 0)
                    {
                        for (int k = 0; k < tmpListProtocolType.Count; k++)
                        {
                            if (tmpListVibrationCable[i].ProtocolType == 0)
                            { dataGridView1.Rows[index].Cells[9].Value = "无"; break; }
                            if (tmpListVibrationCable[i].ProtocolType == tmpListProtocolType[k].ProtocolTypeID)
                            {
                                dataGridView1.Rows[index].Cells[9].Value = tmpListProtocolType[k].ProtocolTypeName;
                                break;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[9].Value = tmpListVibrationCable[i].Description;
                }
            }  
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _VibrationCableList.DeviceID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            VibrationCableList tmpData = null;
            Add_Modify_VibrationCable tmpAdd_Modify_VibrationCable = new Add_Modify_VibrationCable(tmpData);
            tmpAdd_Modify_VibrationCable.ShowDialog();
            if (tmpAdd_Modify_VibrationCable.result == DialogResult.OK)
            {
                GetVibrationCableList();
            }
        }

        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            VibrationCableList tmpData = new VibrationCableList();
            for (int i = 0; i < tmpListVibrationCable.Count; i++)
            {
                if (tmpListVibrationCable[i].DeviceID == _VibrationCableList.DeviceID)
                {
                    tmpData = tmpListVibrationCable[i];
                    break;
                }
            }
            Add_Modify_VibrationCable tmpAdd_Modify_VibrationCable = new Add_Modify_VibrationCable(tmpData);
            tmpAdd_Modify_VibrationCable.ShowDialog();
            if (tmpAdd_Modify_VibrationCable.result == DialogResult.OK)
            {
                GetVibrationCableList();
            }
        }

        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            Guid[] tmpGudi = new Guid[1];
            if (_VibrationCableList != null)
            {
                tmpGudi[0] = _VibrationCableList.DeviceID;
                tmpVibrationCableCommand._DelData(tmpGudi);
                GetVibrationCableList();
            }
        }
    }
}
