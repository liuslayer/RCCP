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
    public partial class ConfigSolarEnergyInfo : Form
    {

        List<SolarEnergyList> tmpListSolarEnergy;
        SolarEnergyList _SolarEnergyList = new SolarEnergyList();
        SolarEnergy_Command tmpSolarEnergyCommand = new SolarEnergy_Command();

        List<DeviceTypeList> tmpListDeviceType;
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();

        List<ProtocolTypeList> tmpListProtocolType;
        ProtocolType_Command tmpProtocolTypeCommand = new ProtocolType_Command();

        List<StationList> tmpListStation;
        Station_Command tmpStationCommand = new Station_Command();

        List<SerialCOMList> tmpListSerialCOM;
        SerialCOM_Command tmpSerialCOM_Command = new SerialCOM_Command();
        public ConfigSolarEnergyInfo()
        {
            InitializeComponent();
            GetSolarEnergyList();
            dataGridView1.Columns[0].Visible = false;
        }
        private void GetSolarEnergyList()
        {
            tmpListSolarEnergy = tmpSolarEnergyCommand._QueryData();
            tmpListDeviceType = tmpDeviceTypeCommand._QueryData();
            tmpListProtocolType = tmpProtocolTypeCommand._QueryData();
            tmpListStation = tmpStationCommand._QueryData();
            tmpListSerialCOM = tmpSerialCOM_Command._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpListSolarEnergy.Count > 0)
            {
                for (int i = 0; i < tmpListSolarEnergy.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    //设备ID
                    dataGridView1.Rows[index].Cells[0].Value = tmpListSolarEnergy[i].DeviceID;
                    //设备名称
                    dataGridView1.Rows[index].Cells[1].Value = tmpListSolarEnergy[i].Name;

                    //设备类型
                    if (tmpListDeviceType.Count > 0)
                    {
                        for (int j = 0; j < tmpListDeviceType.Count; j++)
                        {
                            if (tmpListSolarEnergy[i].TypeID == tmpListDeviceType[j].TypeID)
                            {
                                dataGridView1.Rows[index].Cells[2].Value = tmpListDeviceType[j].TypeName;
                                break;
                            }
                        }
                    }

                    //设备IP
                    //dataGridView1.Rows[index].Cells[3].Value = tmpListSolarEnergy[i].IP;
                    //设备端口号
                    //dataGridView1.Rows[index].Cells[4].Value = tmpListSolarEnergy[i].Port;
                    //设备用户名
                    //dataGridView1.Rows[index].Cells[5].Value = tmpListSolarEnergy[i].UserName;
                    //设备密码
                    //dataGridView1.Rows[index].Cells[6].Value = tmpListSolarEnergy[i].Password;
                    //经度
                    dataGridView1.Rows[index].Cells[3].Value = tmpListSolarEnergy[i].Lon;
                    //纬度
                    dataGridView1.Rows[index].Cells[4].Value = tmpListSolarEnergy[i].Lat;
                    //海拔
                    dataGridView1.Rows[index].Cells[5].Value = tmpListSolarEnergy[i].Alt;
                    //架设高度
                    dataGridView1.Rows[index].Cells[6].Value = tmpListSolarEnergy[i].ErectingHeight;

                    //协议类型
                    if (tmpListProtocolType.Count > 0)
                    {
                        for (int k = 0; k < tmpListProtocolType.Count; k++)
                        {
                            if (tmpListSolarEnergy[i].ProtocolType == 0)
                            { dataGridView1.Rows[index].Cells[7].Value = "无"; break; }
                            if (tmpListSolarEnergy[i].ProtocolType == tmpListProtocolType[k].ProtocolTypeID)
                            {
                                dataGridView1.Rows[index].Cells[7].Value = tmpListProtocolType[k].ProtocolTypeName;
                                break;
                            }
                        }
                    }

                    if (tmpListSolarEnergy[i].CommunicationType == (int)CommunicationMode.NoneType)
                    {
                        dataGridView1.Rows[index].Cells[8].Value = "无";
                    }
                    else if (tmpListSolarEnergy[i].CommunicationType == (int)CommunicationMode.ComType)
                    {
                        dataGridView1.Rows[index].Cells[8].Value = "串口通信";
                        if (tmpListSerialCOM.Count > 0)
                        {
                            for (int m = 0; m < tmpListSerialCOM.Count; m++)
                            {
                                if (tmpListSolarEnergy[i].CommunicationID != null)
                                {
                                    if (tmpListSolarEnergy[i].CommunicationID == tmpListSerialCOM[m].DeviceID)
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
                    else if (tmpListSolarEnergy[i].CommunicationType == (int)CommunicationMode.NetworkType)
                    {
                        dataGridView1.Rows[index].Cells[8].Value = "网络通信";
                    }

                    //所属工作站
                    if (tmpListStation.Count > 0)
                    {
                        for (int l = 0; l < tmpListStation.Count; l++)
                        {
                            if (tmpListSolarEnergy[i].StationID != null)
                            {
                                if (tmpListSolarEnergy[i].StationID == tmpListStation[l].StationID)
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
                    dataGridView1.Rows[index].Cells[11].Value = tmpListSolarEnergy[i].Description;
                }
            }
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _SolarEnergyList.DeviceID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }


        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            SolarEnergyList _tmpData = null;
            Add_Modify_SolarEnergy tmpAdd_Modify_SolarEnergy = new Add_Modify_SolarEnergy(_tmpData);
            tmpAdd_Modify_SolarEnergy.ShowDialog();
            if (tmpAdd_Modify_SolarEnergy.result == DialogResult.OK)
            {
                GetSolarEnergyList();
            }
        }

        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            SolarEnergyList tmpData = new SolarEnergyList();
            for (int i = 0; i < tmpListSolarEnergy.Count; i++)
            {
                if (tmpListSolarEnergy[i].DeviceID == _SolarEnergyList.DeviceID)
                {
                    tmpData = tmpListSolarEnergy[i];
                    break;
                }
            }
            Add_Modify_SolarEnergy tmpAdd_Modify_SolarEnergy = new Add_Modify_SolarEnergy(tmpData);
            tmpAdd_Modify_SolarEnergy.ShowDialog();
            if (tmpAdd_Modify_SolarEnergy.result == DialogResult.OK)
            {
                GetSolarEnergyList();
            }
        }

        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            Guid[] tmpGudi = new Guid[1];
            if (_SolarEnergyList != null)
            {
                tmpGudi[0] = _SolarEnergyList.DeviceID;
                tmpSolarEnergyCommand._DelData(tmpGudi);
                GetSolarEnergyList();
            }
        }
    }
}
