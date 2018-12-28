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
    public partial class ConfigTurnTableInfo : Form
    {
        List<TurnTableList> tmpListTurnTable;
        TurnTableList _TurnTableList = new TurnTableList();
        TurnTable_Command tmpTurnTableCommand = new TurnTable_Command();

        List<DeviceTypeList> tmpListDeviceType;
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();

        List<ProtocolTypeList> tmpListProtocolType;
        ProtocolType_Command tmpProtocolTypeCommand = new ProtocolType_Command();

        List<StationList> tmpListStation;
        Station_Command tmpStationCommand = new Station_Command();

        List<SerialCOMList> tmpListSerialCOM;
        SerialCOM_Command tmpSerialCOM_Command = new SerialCOM_Command();

        public ConfigTurnTableInfo()
        {
            InitializeComponent();
            GetTurnTableList();
            dataGridView1.Columns[0].Visible = false;
        }

        private void GetTurnTableList()
        {
            tmpListTurnTable = tmpTurnTableCommand._QueryData();
            tmpListDeviceType = tmpDeviceTypeCommand._QueryData();
            tmpListProtocolType = tmpProtocolTypeCommand._QueryData();
            tmpListStation = tmpStationCommand._QueryData();
            tmpListSerialCOM = tmpSerialCOM_Command._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpListTurnTable != null)
            {
                for (int i = 0; i < tmpListTurnTable.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    //设备ID
                    dataGridView1.Rows[index].Cells[0].Value = tmpListTurnTable[i].DeviceID;
                    //设备名称
                    dataGridView1.Rows[index].Cells[1].Value = tmpListTurnTable[i].Name;
                    //设备类型
                    if (tmpListDeviceType.Count > 0)
                    {
                        for (int j = 0; j < tmpListDeviceType.Count; j++)
                        {
                            if (tmpListTurnTable[i].TypeID == tmpListDeviceType[j].TypeID)
                            {
                                dataGridView1.Rows[index].Cells[2].Value = tmpListDeviceType[j].TypeName;
                                break;
                            }
                        }
                    }
                    //经度
                    if (tmpListTurnTable[i].Lon != null)
                    {
                        dataGridView1.Rows[index].Cells[3].Value = tmpListTurnTable[i].Lon;
                    }
                    else { dataGridView1.Rows[index].Cells[3].Value = "无"; }

                    //纬度
                    if (tmpListTurnTable[i].Lat != null)
                    {
                        dataGridView1.Rows[index].Cells[4].Value = tmpListTurnTable[i].Lat;
                    }
                    else { dataGridView1.Rows[index].Cells[4].Value = "无"; }

                    //海拔
                    dataGridView1.Rows[index].Cells[5].Value = tmpListTurnTable[i].Alt;

                    //高度测试方式
                    if (tmpListTurnTable[i].ErectingHeightType == (int)HeightMeasurementType.UserMeasurement)
                    {
                        dataGridView1.Rows[index].Cells[6].Value = "用户测量";
                    }
                    else if (tmpListTurnTable[i].ErectingHeightType == (int)HeightMeasurementType.BeiDouMeasurement)
                    {
                        dataGridView1.Rows[index].Cells[6].Value = "北斗测量";
                    }

                    //架设高度
                    dataGridView1.Rows[index].Cells[7].Value = tmpListTurnTable[i].ErectingHeight;

                    //偏北角
                    dataGridView1.Rows[index].Cells[8].Value = tmpListTurnTable[i].AzimuthAngle;

                    //协议类型
                    if (tmpListProtocolType.Count > 0)
                    {
                        for (int k = 0; k < tmpListProtocolType.Count; k++)
                        {
                            if (tmpListTurnTable[i].ProtocolType == 0)
                            { dataGridView1.Rows[index].Cells[9].Value = "无"; break; }
                            if (tmpListTurnTable[i].ProtocolType == tmpListProtocolType[k].ProtocolTypeID)
                            {
                                dataGridView1.Rows[index].Cells[9].Value = tmpListProtocolType[k].ProtocolTypeName;
                                break;
                            }
                        }
                    }

                    dataGridView1.Rows[index].Cells[10].Value = tmpListTurnTable[i].TurntableAddr;

                    dataGridView1.Rows[index].Cells[11].Value = tmpListTurnTable[i].CCDAddr;

                    dataGridView1.Rows[index].Cells[12].Value = tmpListTurnTable[i].IRAddr;

                    //所属工作站
                    if (tmpListStation.Count > 0)
                    {
                        for (int l = 0; l < tmpListStation.Count; l++)
                        {
                            if (tmpListTurnTable[i].StationID != null)
                            {
                                if (tmpListTurnTable[i].StationID == tmpListStation[l].StationID)
                                {
                                    dataGridView1.Rows[index].Cells[13].Value = tmpListStation[l].Name;
                                    break;
                                }
                            }
                            else
                            {
                                dataGridView1.Rows[index].Cells[13].Value = "无";
                            }
                        }
                    }

                    if (tmpListTurnTable[i].CommunicationType == (int)CommunicationMode.NoneType)
                    {
                        dataGridView1.Rows[index].Cells[14].Value = "无";
                    }
                    else if (tmpListTurnTable[i].CommunicationType == (int)CommunicationMode.ComType)
                    {
                        dataGridView1.Rows[index].Cells[14].Value = "串口通信";
                        if (tmpListSerialCOM.Count > 0)
                        {
                            for (int m = 0; m < tmpListSerialCOM.Count; m++)
                            {
                                if (tmpListTurnTable[i].CommunicationID != null)
                                {
                                    if (tmpListTurnTable[i].CommunicationID == tmpListSerialCOM[m].DeviceID)
                                    {
                                        dataGridView1.Rows[index].Cells[15].Value = tmpListSerialCOM[m].Name;
                                        break;
                                    }
                                }
                                else
                                {
                                    dataGridView1.Rows[index].Cells[15].Value = "无";
                                }

                            }
                        }
                    }
                    else if (tmpListTurnTable[i].CommunicationType == (int)CommunicationMode.NetworkType)
                    {
                        dataGridView1.Rows[index].Cells[14].Value = "网络通信";
                    }

                    dataGridView1.Rows[index].Cells[16].Value = tmpListTurnTable[i].Description;
                }
            }

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _TurnTableList.DeviceID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }


        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            TurnTableList tmpData = null;
            Add_Modify_TurnTable tmpAdd_Modify_TurnTable = new Add_Modify_TurnTable(tmpData);
            tmpAdd_Modify_TurnTable.ShowDialog();
            if(tmpAdd_Modify_TurnTable.result == DialogResult.OK)
            {
                GetTurnTableList();
            }
        }

        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            TurnTableList tmpData = new TurnTableList();
            for(int i=0;i< tmpListTurnTable.Count;i++)
            {
                if(tmpListTurnTable[i].DeviceID == _TurnTableList.DeviceID)
                {
                    tmpData = tmpListTurnTable[i];
                    break;
                }
            }
            Add_Modify_TurnTable tmpAdd_Modify_TurnTable = new Add_Modify_TurnTable(tmpData);
            tmpAdd_Modify_TurnTable.ShowDialog();
            if(tmpAdd_Modify_TurnTable.result == DialogResult.OK)
            {
                GetTurnTableList();
            }
        }

        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            Guid[] tmpGudi = new Guid[1];
            if(_TurnTableList !=null)
            {
                tmpGudi[0] = _TurnTableList.DeviceID;
                tmpTurnTableCommand._DelData(tmpGudi);
                GetTurnTableList();
            }
        }
    }
}
