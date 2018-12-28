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
    public partial class ConfigSerialCOMInfo : Form
    {
        List<SerialCOMList> tmpListSerialCOM;
        SerialCOMList _tmpSerialCOMList = new SerialCOMList();
        SerialCOM_Command tmpSerialCOM_Command = new SerialCOM_Command();

        public ConfigSerialCOMInfo()
        {
            InitializeComponent();
            GetSerialCOMaList();
            dataGridView1.Columns[0].Visible = false;
        }

        public void GetSerialCOMaList()
        {
            tmpListSerialCOM = tmpSerialCOM_Command._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpListSerialCOM.Count > 0)
            {
                for(int i=0;i< tmpListSerialCOM.Count;i++)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = tmpListSerialCOM[i].DeviceID;
                    dataGridView1.Rows[index].Cells[1].Value = tmpListSerialCOM[i].Name;
                    dataGridView1.Rows[index].Cells[2].Value = tmpListSerialCOM[i].COMNo;
                    dataGridView1.Rows[index].Cells[3].Value = tmpListSerialCOM[i].Baud;
                    dataGridView1.Rows[index].Cells[4].Value = tmpListSerialCOM[i].DataBit;

                    //校验位: 0 None parity(无)、1 Odd parity(奇)、2 Even parity(偶)、3 Mark parity(标志)、4 Space parity(空格)
                    switch (tmpListSerialCOM[i].CheckBit)
                    {
                        //case (int)ComCheckBit.NoneParity:
                        //    { dataGridView1.Rows[index].Cells[5].Value = "NoneParity(无)"; }
                        //    break;
                        //case (int)ComCheckBit.OddParity:
                        //    { dataGridView1.Rows[index].Cells[5].Value = "OddParity(奇)"; }
                        //    break;
                        //case (int)ComCheckBit.EvenParity:
                        //    { dataGridView1.Rows[index].Cells[5].Value = "EvenParity(偶)"; }
                        //    break;
                        //case (int)ComCheckBit.MarkParity:
                        //    { dataGridView1.Rows[index].Cells[5].Value = "MarkParity(标志)"; }
                        //    break;
                        //case (int)ComCheckBit.SpaceParity:
                        //    { dataGridView1.Rows[index].Cells[5].Value = "SpaceParity(空格)"; }
                        //    break;

                        case (int)ComCheckBit.NoneParity:
                            { dataGridView1.Rows[index].Cells[5].Value = ComCheckBit.NoneParity; }
                            break;
                        case (int)ComCheckBit.OddParity:
                            { dataGridView1.Rows[index].Cells[5].Value = ComCheckBit.OddParity; }
                            break;
                        case (int)ComCheckBit.EvenParity:
                            { dataGridView1.Rows[index].Cells[5].Value = ComCheckBit.EvenParity; }
                            break;
                        case (int)ComCheckBit.MarkParity:
                            { dataGridView1.Rows[index].Cells[5].Value = ComCheckBit.MarkParity; }
                            break;
                        case (int)ComCheckBit.SpaceParity:
                            { dataGridView1.Rows[index].Cells[5].Value = ComCheckBit.SpaceParity; }
                            break;

                    }
                    //停止位：0 None、1 One、2 Two、3 OnePointFive
                    switch(tmpListSerialCOM[i].StopBit)
                    {
                        case (int)ComStopBit.None:
                            { dataGridView1.Rows[index].Cells[6].Value = (int)ComStopBit.None; }
                            break;
                        case (int)ComStopBit.One:
                            { dataGridView1.Rows[index].Cells[6].Value = (int)ComStopBit.One; }
                            break;
                        case (int)ComStopBit.Two:
                            { dataGridView1.Rows[index].Cells[6].Value = (int)ComStopBit.Two; }
                            break;
                        case (int)ComStopBit.OnePointFive:
                            { dataGridView1.Rows[index].Cells[6].Value = (int)ComStopBit.OnePointFive; }
                            break;
                    }
                    dataGridView1.Rows[index].Cells[7].Value = tmpListSerialCOM[i].Description;
                }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _tmpSerialCOMList.DeviceID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            SerialCOMList _tmpData = null;
            Add_Modify_SerialCOM tmpAdd_Modify_SerialCOM = new Add_Modify_SerialCOM(_tmpData);
            tmpAdd_Modify_SerialCOM.ShowDialog();
            if (tmpAdd_Modify_SerialCOM.result == DialogResult.OK)
            {
                GetSerialCOMaList();
            }
        }

        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            SerialCOMList _tmpData = new SerialCOMList();
            for (int i = 0; i < tmpListSerialCOM.Count; i++)
            {
                if(_tmpSerialCOMList.DeviceID == tmpListSerialCOM[i].DeviceID)
                {
                    _tmpData = tmpListSerialCOM[i];
                }
            }
            Add_Modify_SerialCOM tmpAdd_Modify_SerialCOM = new Add_Modify_SerialCOM(_tmpData);
            tmpAdd_Modify_SerialCOM.ShowDialog();
            if (tmpAdd_Modify_SerialCOM.result == DialogResult.OK)
            {
                GetSerialCOMaList();
            }
        }

        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            Guid[] _Guid = new Guid[1];
            if (_tmpSerialCOMList.DeviceID != null)
            {
                _Guid[0] = _tmpSerialCOMList.DeviceID;
                tmpSerialCOM_Command._DelData(_Guid);
                GetSerialCOMaList();
            }
        }
    }
}
