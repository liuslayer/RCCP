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
    public partial class ConfigRadarInfo : Form
    {
        List<RadarList> tmpListRadar;
        RadarList _tmpRadarList = new RadarList();
        Radar_Command tmpRadarCommand = new Radar_Command();

        List<DeviceTypeList> tmpListDeviceType;
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();

        List<StationList> tmpListStation;
        Station_Command tmpStationCommand = new Station_Command();

        List<ProtocolTypeList> tmpListProtocolType;
        ProtocolType_Command tmpProtocolTypeCommand = new ProtocolType_Command();

        List<SerialCOMList> tmpListSerialCOM;
        SerialCOM_Command tmpSerialCOM_Command = new SerialCOM_Command();

        public ConfigRadarInfo()
        {
            InitializeComponent();
            GetRadarList();
            dataGridView1.Columns[0].Visible = false;
        }
        private void GetRadarList()
        {
            tmpListRadar = tmpRadarCommand._QueryData();
            tmpListDeviceType = tmpDeviceTypeCommand._QueryData();
            tmpListStation = tmpStationCommand._QueryData();
            tmpListSerialCOM = tmpSerialCOM_Command._QueryData();
            dataGridView1.Rows.Clear();
            if(tmpListRadar!=null)
            {
                for (int i = 0; i < tmpListRadar.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = tmpListRadar[i].DeviceID;
                    dataGridView1.Rows[index].Cells[1].Value = tmpListRadar[i].Name;
                    if (tmpListDeviceType != null)
                    {
                        for (int j = 0; j < tmpListDeviceType.Count; j++)
                        {
                            if (tmpListRadar[i].TypeId == tmpListDeviceType[j].TypeID)
                            {
                                dataGridView1.Rows[index].Cells[2].Value = tmpListDeviceType[j].TypeName;
                                break;
                            }
                        }
                    }
                    else
                    {
                        dataGridView1.Rows[index].Cells[2].Value = null;
                    }

                    //经度
                    if (tmpListRadar[i].Lon != null)
                    {
                        dataGridView1.Rows[index].Cells[3].Value = tmpListRadar[i].Lon;
                    }
                    else { dataGridView1.Rows[index].Cells[3].Value = "无"; }

                    //纬度
                    if (tmpListRadar[i].Lat != null)
                    {
                        dataGridView1.Rows[index].Cells[4].Value = tmpListRadar[i].Lat;
                    }
                    else { dataGridView1.Rows[index].Cells[4].Value = "无"; }

                    //海拔
                    dataGridView1.Rows[index].Cells[5].Value = tmpListRadar[i].Alt;

                    //架设高度
                    dataGridView1.Rows[index].Cells[6].Value = tmpListRadar[i].ErectingHeight;

                    if (tmpListProtocolType != null)
                    {
                        for (int k = 0; k < tmpListProtocolType.Count; k++)
                        {
                            if (tmpListRadar[i].ProtocolType == 0)
                            { dataGridView1.Rows[index].Cells[7].Value = "无"; break; }
                            if (tmpListRadar[i].ProtocolType == tmpListProtocolType[k].ProtocolTypeID)
                            {
                                dataGridView1.Rows[index].Cells[7].Value = tmpListProtocolType[k].ProtocolTypeName;
                                break;
                            }
                        }
                    }

                    if (tmpListRadar[i].CommunicationType == (int)CommunicationMode.NoneType)
                    {
                        dataGridView1.Rows[index].Cells[8].Value = "无";
                    }
                    else if (tmpListRadar[i].CommunicationType == (int)CommunicationMode.ComType)
                    {
                        dataGridView1.Rows[index].Cells[8].Value = "串口通信";
                        if (tmpListSerialCOM.Count > 0)
                        {
                            for (int m = 0; m < tmpListSerialCOM.Count; m++)
                            {
                                if (tmpListRadar[i].CommunicationID != null)
                                {
                                    if (tmpListRadar[i].CommunicationID == tmpListSerialCOM[m].DeviceID)
                                    {
                                        dataGridView1.Rows[index].Cells[9].Value = tmpListSerialCOM[m].Name;
                                        break;
                                    }
                                }
                                else
                                {
                                    dataGridView1.Rows[index].Cells[9].Value = "无";
                                }

                            }
                        }
                    }
                    else if (tmpListRadar[i].CommunicationType == (int)CommunicationMode.NetworkType)
                    {
                        dataGridView1.Rows[index].Cells[8].Value = "网络通信";
                    }

                    //所属工作站
                    if (tmpListStation != null)
                    {
                        for (int l = 0; l < tmpListStation.Count; l++)
                        {
                            if (tmpListRadar[i].StationID != null)
                            {
                                if (tmpListRadar[i].StationID == tmpListStation[l].StationID)
                                {
                                    dataGridView1.Rows[index].Cells[10].Value = tmpListStation[l].Name;
                                    break;
                                }
                            }
                            else
                            {
                                dataGridView1.Rows[index].Cells[10].Value = "无";
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[11].Value = tmpListRadar[i].Description;
                }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _tmpRadarList.DeviceID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            RadarList tmpData = null;
            Add_Modify_Radar tmpAdd_Modify_Radar = new Add_Modify_Radar(tmpData);
            tmpAdd_Modify_Radar.ShowDialog();
            if (tmpAdd_Modify_Radar.result == DialogResult.OK)
            {
                GetRadarList();
            }
        }

        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            RadarList tmpData = new RadarList();
            for (int i = 0; i < tmpListRadar.Count; i++)
            {
                if (tmpListRadar[i].DeviceID == _tmpRadarList.DeviceID)
                {
                    tmpData = tmpListRadar[i];
                    break;
                }
            }
            Add_Modify_Radar tmpAdd_Modify_Radar = new Add_Modify_Radar(tmpData);
            tmpAdd_Modify_Radar.ShowDialog();
            if (tmpAdd_Modify_Radar.result == DialogResult.OK)
            {
                GetRadarList();
            }
        }

        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {//tmpRadar_Command._AddData(tmpRadarList);
            Guid[] tmpGudi = new Guid[1];
            if (_tmpRadarList != null)
            {
                tmpGudi[0] = _tmpRadarList.DeviceID;
                tmpRadarCommand._DelData(tmpGudi);
                GetRadarList();
            }
        }
    }
}
