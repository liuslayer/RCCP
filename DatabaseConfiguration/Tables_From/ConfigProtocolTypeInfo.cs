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
    public partial class ConfigProtocolTypeInfo : Form
    {
        List<ProtocolTypeList> tmpListProtocolType;
        ProtocolTypeList _tmpProtocolTypeList = new ProtocolTypeList();
        ProtocolType_Command tmpProtocolTypeCommand = new ProtocolType_Command();

        List<DeviceTypeList> tmpListDeviceType;
        DeviceTypeList _tmpDeviceTypeList = new DeviceTypeList();
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();

        public ConfigProtocolTypeInfo()
        {
            InitializeComponent();
            GetProtocolTypeList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        private void GetProtocolTypeList()
        {
            tmpListProtocolType = tmpProtocolTypeCommand._QueryData();
            tmpListDeviceType = tmpDeviceTypeCommand._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpListProtocolType.Count > 0)
            {
                for (int i = 0; i < tmpListProtocolType.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = tmpListProtocolType[i].ID;
                    dataGridView1.Rows[index].Cells[1].Value = tmpListProtocolType[i].ProtocolTypeName;
                    dataGridView1.Rows[index].Cells[2].Value = tmpListProtocolType[i].ProtocolTypeID;
                    //
                    if (tmpListDeviceType.Count > 0)
                    {
                        for (int j = 0; j < tmpListDeviceType.Count; j++)
                        {
                            if(tmpListProtocolType[i].TypeID == tmpListDeviceType[j].TypeID)
                            {
                                dataGridView1.Rows[index].Cells[3].Value = tmpListDeviceType[j].TypeName;
                                dataGridView1.Rows[index].Cells[4].Value = tmpListDeviceType[j].ID;
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _tmpProtocolTypeList.ID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            ProtocolTypeList _tmpData = null;
            Add_Modify_ProtocolType tmpAdd_Modify_ProtocolType = new Add_Modify_ProtocolType(_tmpData);
            tmpAdd_Modify_ProtocolType.ShowDialog();
            if (tmpAdd_Modify_ProtocolType.result == DialogResult.OK)
            {
                GetProtocolTypeList();
            }
        }

        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            ProtocolTypeList _tmpData = new ProtocolTypeList();
            for (int i = 0; i < tmpListProtocolType.Count; i++)
            {
                if(_tmpProtocolTypeList.ID == tmpListProtocolType[i].ID)
                {
                    _tmpData = tmpListProtocolType[i];
                    break;
                }
            }
            Add_Modify_ProtocolType tmpAdd_Modify_ProtocolType = new Add_Modify_ProtocolType(_tmpData);
            tmpAdd_Modify_ProtocolType.ShowDialog();
            if (tmpAdd_Modify_ProtocolType.result == DialogResult.OK)
            {
                GetProtocolTypeList();
            }
        }

        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            Guid[] _Guid = new Guid[1];
            if (_tmpProtocolTypeList.ID != null)
            {
                _Guid[0] = _tmpProtocolTypeList.ID;
                tmpProtocolTypeCommand._DelData(_Guid);
                GetProtocolTypeList();
            }
        }
    }
}
