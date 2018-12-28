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
    public partial class ConfigStationInfo : Form
    {
        List<StationList> tmpListStation;
        StationList _tmpStationList = new StationList();
        Station_Command tmpStationCommand = new Station_Command();

        List<DeviceTypeList> tmpListDeviceType;
        DeviceTypeList _tmpDeviceTypeList = new DeviceTypeList();
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();
        public ConfigStationInfo()
        {
            InitializeComponent();
            GetStationList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }
        private void GetStationList()
        {
            tmpListStation = tmpStationCommand._QueryData();
            tmpListDeviceType = tmpDeviceTypeCommand._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpListStation.Count > 0)
            {
                for(int i =0;i< tmpListStation.Count;i++)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = tmpListStation[i].StationID;
                    dataGridView1.Rows[index].Cells[1].Value = tmpListStation[i].Name;
                    for (int k = 0; k < tmpListStation.Count; k++)
                    {
                        if (tmpListStation[k].StationID == tmpListStation[i].PStationID)
                        {
                            dataGridView1.Rows[index].Cells[2].Value = tmpListStation[k].Name;
                            break;
                        }
                    }
                    dataGridView1.Rows[index].Cells[3].Value = tmpListStation[i].PStationID;
                    
                    
                    if (tmpListDeviceType.Count > 0)
                    {
                        for (int j = 0; j < tmpListDeviceType.Count; j++)
                        {
                            if(tmpListStation[i].TypeID == tmpListDeviceType[j].TypeID)
                            {
                                dataGridView1.Rows[index].Cells[4].Value = tmpListDeviceType[j].TypeName;
                                dataGridView1.Rows[index].Cells[5].Value = tmpListDeviceType[j].ID;
                                break;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[6].Value = tmpListStation[i].Lon;
                    dataGridView1.Rows[index].Cells[7].Value = tmpListStation[i].Lat;
                    dataGridView1.Rows[index].Cells[8].Value = tmpListStation[i].Description;
                }
            }
        }
        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            StationList _tmpData = null;
            Add_Modify_Station tmpAdd_Modify_Station = new Add_Modify_Station(_tmpData);
            tmpAdd_Modify_Station.ShowDialog();
            if (tmpAdd_Modify_Station.result == DialogResult.OK)
            {
                GetStationList();
            }
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _tmpStationList.StationID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }
        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            StationList _tmpData = new StationList();

            for (int i = 0; i < tmpListStation.Count; i++)
            {
                if (_tmpStationList.StationID == tmpListStation[i].StationID)
                {
                    _tmpData = tmpListStation[i];
                    break;
                }
            }
            Add_Modify_Station tmpAdd_Modify_Station = new Add_Modify_Station(_tmpData);
            tmpAdd_Modify_Station.ShowDialog();
            if (tmpAdd_Modify_Station.result == DialogResult.OK)
            {
                GetStationList();
            }
        }

        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            Guid[] _Guid = new Guid[1];
            if (_tmpStationList.StationID != null)
            {
                _Guid[0] = _tmpStationList.StationID;
                tmpStationCommand._DelData(_Guid);
                GetStationList();
            }
        }
    }
}
