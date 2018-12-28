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
    public partial class ConfigComputerInfo : Form
    {
        List<ComputerList> tmpListComputer;
        ComputerList _tmpComputerList = new ComputerList();
        Computer_Command tmpComputerCommand = new Computer_Command();

        List<DeviceTypeList> tmpListDeviceType;
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();

        List<StationList> tmpListStation;
        Station_Command tmpStationCommand = new Station_Command();

        public ConfigComputerInfo()
        {
            InitializeComponent();
            GetComputerList();
            dataGridView1.Columns[0].Visible = false;
        }

        public void GetComputerList()
        {
            tmpListComputer = tmpComputerCommand._QueryData();
            tmpListDeviceType = tmpDeviceTypeCommand._QueryData();
            tmpListStation = tmpStationCommand._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpListComputer.Count > 0)
            {
                for (int i = 0; i < tmpListComputer.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    //设备ID
                    dataGridView1.Rows[index].Cells[0].Value = tmpListComputer[i].DeviceID;
                    dataGridView1.Rows[index].Cells[1].Value = tmpListComputer[i].Name;
                    if (tmpListDeviceType.Count > 0)
                    {
                        for(int j=0;j<tmpListDeviceType.Count;j++)
                        {
                            if (tmpListComputer[i].TypeID == tmpListDeviceType[j].TypeID)
                            {
                                dataGridView1.Rows[index].Cells[2].Value = tmpListDeviceType[j].TypeName;
                                break;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[3].Value = tmpListComputer[i].Ip;

                    if (tmpListStation.Count > 0)
                    {
                        for (int k = 0; k < tmpListStation.Count; k++)
                        {
                            if(tmpListComputer[i].StationID == tmpListStation[k].StationID)
                            {
                                dataGridView1.Rows[index].Cells[4].Value = tmpListStation[k].Name;
                                break;
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[5].Value = tmpListComputer[i].Description; 
                }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _tmpComputerList.DeviceID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            ComputerList _tmpData = null;
            Add_Modify_Computer tmpAdd_Modify_Computer = new Add_Modify_Computer(_tmpData);
            tmpAdd_Modify_Computer.ShowDialog();
            if (tmpAdd_Modify_Computer.result == DialogResult.OK)
            {
                GetComputerList();
            } 
        }

        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            ComputerList _tmpData = new ComputerList();
            for (int i = 0; i < tmpListComputer.Count; i++)
            {
                if (_tmpComputerList.DeviceID == tmpListComputer[i].DeviceID)
                {
                    _tmpData = tmpListComputer[i];
                    break;
                }
            }
            Add_Modify_Computer tmpAdd_Modify_Computer = new Add_Modify_Computer(_tmpData);
            tmpAdd_Modify_Computer.ShowDialog();
            if (tmpAdd_Modify_Computer.result == DialogResult.OK)
            {
                GetComputerList();
            }
        }

        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            Guid[] _Guid = new Guid[1];
            if (_tmpComputerList.DeviceID != null)
            {
                _Guid[0] = _tmpComputerList.DeviceID;
                tmpComputerCommand._DelData(_Guid);
                GetComputerList();
            }
        }
    }
}
