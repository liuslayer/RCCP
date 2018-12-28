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
    public partial class ConfigServerInfo : Form
    {
        List<ServerList> tmpListServer;
        ServerList _tmpServerList = new ServerList();
        Server_Command tmpServerCommand = new Server_Command();

        List<DeviceTypeList> tmpListDeviceType;
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();

        List<StationList> tmpListStation;
        Station_Command tmpStationCommand = new Station_Command();
        public ConfigServerInfo()
        {
            InitializeComponent();
            GetServerList();
            dataGridView1.Columns[0].Visible = false;
        }
        private void GetServerList()
        {
            tmpListServer = tmpServerCommand._QueryData();
            tmpListDeviceType = tmpDeviceTypeCommand._QueryData();
            tmpListStation = tmpStationCommand._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpListServer!= null)
            {
                for (int i = 0; i < tmpListServer.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    //设备ID
                    dataGridView1.Rows[index].Cells[0].Value = tmpListServer[i].DeviceID;
                    dataGridView1.Rows[index].Cells[1].Value = tmpListServer[i].Name;
                    if (tmpListDeviceType.Count > 0)
                    {
                        for (int j = 0; j < tmpListDeviceType.Count; j++)
                        {
                            if (tmpListServer[i].TypeID == tmpListDeviceType[j].TypeID)
                            {
                                dataGridView1.Rows[index].Cells[2].Value = tmpListDeviceType[j].TypeName;
                                break;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[3].Value = tmpListServer[i].Ip;

                    if (tmpListStation.Count > 0)
                    {
                        for (int k = 0; k < tmpListStation.Count; k++)
                        {
                            if (tmpListServer[i].StationID == tmpListStation[k].StationID)
                            {
                                dataGridView1.Rows[index].Cells[4].Value = tmpListStation[k].Name;
                                break;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[5].Value = tmpListServer[i].Description;
                }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _tmpServerList.DeviceID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            ServerList _tmpData = null;
            Add_Modify_Server tmpAdd_Modify_Computer = new Add_Modify_Server(_tmpData);
            tmpAdd_Modify_Computer.ShowDialog();
            if (tmpAdd_Modify_Computer.result == DialogResult.OK)
            {
                GetServerList();
            }
        }

        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            ServerList _tmpData = new ServerList();
            for (int i = 0; i < tmpListServer.Count; i++)
            {
                if (_tmpServerList.DeviceID == tmpListServer[i].DeviceID)
                {
                    _tmpData = tmpListServer[i];
                    break;
                }
            }
            Add_Modify_Server tmpAdd_Modify_Server = new Add_Modify_Server(_tmpData);
            tmpAdd_Modify_Server.ShowDialog();
            if (tmpAdd_Modify_Server.result == DialogResult.OK)
            {
                GetServerList();
            }
        }

        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            Guid[] _Guid = new Guid[1];
            if (_tmpServerList.DeviceID != null)
            {
                _Guid[0] = _tmpServerList.DeviceID;
                tmpServerCommand._DelData(_Guid);
                GetServerList();
            }
        }
    }
}
