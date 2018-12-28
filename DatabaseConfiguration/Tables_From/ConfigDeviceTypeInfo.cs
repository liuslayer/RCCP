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
    public partial class ConfigDeviceTypeInfo : Form
    {
        List<DeviceTypeList> tmpDeviceTypeList;
        DeviceTypeList _tmpDeviceTypeList = new DeviceTypeList();
        DeviceType_Command tmp = new DeviceType_Command();
        public ConfigDeviceTypeInfo()
        {
            InitializeComponent();
            getDeviceTypeList();
            dataGridView1.Columns[6].Visible = false;

        }
        public void getDeviceTypeList()
        {
            tmpDeviceTypeList = tmp._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpDeviceTypeList.Count > 0)
            {
                for(int i =0;i< tmpDeviceTypeList.Count;i++)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = tmpDeviceTypeList[i].TypeID;
                    dataGridView1.Rows[index].Cells[1].Value = tmpDeviceTypeList[i].TypeName;

                    if(tmpDeviceTypeList[i].Image1 !=null)
                    { dataGridView1.Rows[index].Cells[2].Value = "有"; }
                    else { dataGridView1.Rows[index].Cells[2].Value = "无"; }

                    if (tmpDeviceTypeList[i].Image2 != null)
                    { dataGridView1.Rows[index].Cells[3].Value = "有"; }
                    else { dataGridView1.Rows[index].Cells[3].Value = "无"; }

                    if (tmpDeviceTypeList[i].Image3 != null)
                    { dataGridView1.Rows[index].Cells[4].Value = "有"; }
                    else { dataGridView1.Rows[index].Cells[4].Value = "无"; }

                    dataGridView1.Rows[index].Cells[5].Value = tmpDeviceTypeList[i].Description;
                    dataGridView1.Rows[index].Cells[6].Value = tmpDeviceTypeList[i].ID;
                }
            }
            else
            {

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _tmpDeviceTypeList.ID =new Guid (dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
            }
        }

        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            DeviceTypeList tmpData = null;
            Add_Modify_DeviceType tmpAdd_Modify_DeviceType = new Add_Modify_DeviceType(tmpData);
            tmpAdd_Modify_DeviceType.ShowDialog();
            if (tmpAdd_Modify_DeviceType.result == DialogResult.OK)
            {
                getDeviceTypeList();
            }
        }

        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            DeviceTypeList tmpData = new DeviceTypeList();
            for (int i=0;i< tmpDeviceTypeList.Count;i++)
            {
                if(tmpDeviceTypeList[i].ID == _tmpDeviceTypeList.ID)
                {
                    tmpData = tmpDeviceTypeList[i];
                    break;
                }
            }
            Add_Modify_DeviceType tmpAdd_Modify_DeviceType = new Add_Modify_DeviceType(tmpData);
            tmpAdd_Modify_DeviceType.ShowDialog();
            if(tmpAdd_Modify_DeviceType.result == DialogResult.OK)
            {
                getDeviceTypeList();
            }
        }

        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            Guid[] _Guid = new Guid[1];
            if(_tmpDeviceTypeList.ID!=null)
            {
                _Guid[0] = _tmpDeviceTypeList.ID;
                tmp._DelData(_Guid);
                getDeviceTypeList();
            }
        }
    }
}
