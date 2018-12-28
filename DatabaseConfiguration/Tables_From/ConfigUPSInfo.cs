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
    public partial class ConfigUPSInfo : Form
    {
        List<UPSList> tmpListUPS;
        UPSList _tmpUPSList = new UPSList();
        UPSData_Command tmpUPSData_Command = new UPSData_Command();

        List<DeviceTypeList> tmpListDeviceType;
        DeviceTypeList _tmpDeviceTypeList = new DeviceTypeList();
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();

        List<ProtocolTypeList> tmpListProtocolType;
        ProtocolTypeList _tmpProtocolTypeList = new ProtocolTypeList();
        ProtocolType_Command tmpProtocolTypeCommand = new ProtocolType_Command();

        List<StationList> tmpListStation;
        StationList _tmpStationList = new StationList();
        Station_Command tmpStationCommand = new Station_Command();

        List<SerialCOMList> tmpListSerialCOM;
        SerialCOMList _tmpSerialCOMList = new SerialCOMList();
        SerialCOM_Command tmpSerialCOM_Command = new SerialCOM_Command();

        public ConfigUPSInfo()
        {
            InitializeComponent();
            GetUPSList();
            dataGridView1.Columns[0].Visible = false;
        }

        private void GetUPSList()
        {
            tmpListUPS = tmpUPSData_Command._QueryData();
            tmpListDeviceType = tmpDeviceTypeCommand._QueryData();
            tmpListProtocolType = tmpProtocolTypeCommand._QueryData();
            tmpListStation = tmpStationCommand._QueryData();
            tmpListSerialCOM = tmpSerialCOM_Command._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpListUPS.Count > 0)
            {
                for (int i = 0; i < tmpListUPS.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = tmpListUPS[i].DeviceID;
                    dataGridView1.Rows[index].Cells[1].Value = tmpListUPS[i].Name;
                    if (tmpListDeviceType.Count > 0)
                    {
                        for (int j = 0; j < tmpListDeviceType.Count; j++)
                        {
                            if(tmpListUPS[i].TypeID == tmpListDeviceType[j].TypeID)
                            {
                                dataGridView1.Rows[index].Cells[2].Value = tmpListDeviceType[j].TypeName;
                                break;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[3].Value = tmpListUPS[i].Lon;
                    dataGridView1.Rows[index].Cells[4].Value = tmpListUPS[i].Lat;
                    dataGridView1.Rows[index].Cells[5].Value = tmpListUPS[i].Alt;
                    if(tmpListProtocolType.Count>0)
                    {
                        for (int k = 0; k < tmpListProtocolType.Count; k++)
                        {
                            if (tmpListUPS[i].ProtocolType == tmpListProtocolType[k].ProtocolTypeID)
                            {
                                dataGridView1.Rows[index].Cells[6].Value = tmpListProtocolType[k].ProtocolTypeName;
                                break;
                            }
                        }
                    }
                    if(tmpListUPS[i].CommunicationType == (int)CommunicationMode.NoneType)
                    {
                        dataGridView1.Rows[index].Cells[7].Value = "无";
                    }
                    else if(tmpListUPS[i].CommunicationType == (int)CommunicationMode.ComType)
                    {
                        dataGridView1.Rows[index].Cells[7].Value = "串口通信";
                        if (tmpListSerialCOM.Count > 0)
                        {
                            for (int m = 0; m < tmpListSerialCOM.Count; m++)
                            {
                                if (tmpListUPS[i].CommunicationID != null)
                                {
                                    if (tmpListUPS[i].CommunicationID == tmpListSerialCOM[m].DeviceID)
                                    {
                                        dataGridView1.Rows[index].Cells[8].Value = tmpListSerialCOM[m].Name;
                                        break;
                                    }
                                }
                                else
                                {
                                    dataGridView1.Rows[index].Cells[8].Value = "无";
                                }
                                
                            }
                        }
                    }
                    else if(tmpListUPS[i].CommunicationType == (int)CommunicationMode.NetworkType)
                    {
                        dataGridView1.Rows[index].Cells[7].Value = "网络通信";
                    }
                    
                    if (tmpListStation.Count > 0)
                    {
                        for (int l = 0; l < tmpListStation.Count; l++)
                        {
                            if (tmpListUPS[i].StationID != null)
                            {
                                if (tmpListUPS[i].StationID == tmpListStation[l].StationID)
                                {
                                    dataGridView1.Rows[index].Cells[9].Value = tmpListStation[l].Name;
                                    break;
                                }
                            }
                            else
                            {
                                dataGridView1.Rows[index].Cells[9].Value = "无";
                            }
                            
                        }
                    }
                    dataGridView1.Rows[index].Cells[10].Value = tmpListUPS[i].Description;
                }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _tmpUPSList.DeviceID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            UPSList _tmpData = null;
            Add_Modify_UPS tmpAdd_Modify_UPS = new Add_Modify_UPS(_tmpData);
            tmpAdd_Modify_UPS.ShowDialog();
            if (tmpAdd_Modify_UPS.result == DialogResult.OK)
            {
                GetUPSList();
            }

        }

        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            UPSList _tmpData = new UPSList();

            for (int i = 0; i < tmpListUPS.Count; i++)
            {
                if(tmpListUPS[i].DeviceID == _tmpUPSList.DeviceID)
                {
                    _tmpData = tmpListUPS[i];
                    break;
                }
            }

            Add_Modify_UPS tmpAdd_Modify_UPS = new Add_Modify_UPS(_tmpData);
            tmpAdd_Modify_UPS.ShowDialog();
            if (tmpAdd_Modify_UPS.result == DialogResult.OK)
            {
                GetUPSList();
            }
        }

        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            Guid[] _Guid = new Guid[1];
            if (_tmpUPSList.DeviceID != null)
            {
                _Guid[0] = _tmpUPSList.DeviceID;
                tmpUPSData_Command._DelData(_Guid);
                GetUPSList();
            }
        }
    }
}
