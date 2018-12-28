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
    public partial class ConfigPersonnelInformationInfo : Form
    {
        List<PersonnelInformationList> tmpListPersonnelInformation;
        PersonnelInformationList _PersonnelInformationList = new PersonnelInformationList();
        PersonnelInformation_Command tmpPersonnelInformationCommand = new PersonnelInformation_Command();

        List<StationList> tmpListStation;
        Station_Command tmpStationCommand = new Station_Command();

        public ConfigPersonnelInformationInfo()
        {
            InitializeComponent();
            GetPersonnelInformationList();
            dataGridView1.Columns[0].Visible = false;
        }
        private void GetPersonnelInformationList()
        {
            tmpListStation = tmpStationCommand._QueryData();
            tmpListPersonnelInformation = tmpPersonnelInformationCommand._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpListPersonnelInformation != null)
            {
                for (int i = 0; i < tmpListPersonnelInformation.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = tmpListPersonnelInformation[i].ID;
                    dataGridView1.Rows[index].Cells[1].Value = tmpListPersonnelInformation[i].Name;
                    if (tmpListStation != null)
                    {
                        for (int l = 0; l < tmpListStation.Count; l++)
                        {
                            if (tmpListPersonnelInformation[i].StationID != null)
                            {
                                if (tmpListPersonnelInformation[i].StationID == tmpListStation[l].StationID)
                                {
                                    dataGridView1.Rows[index].Cells[2].Value = tmpListStation[l].Name;
                                    break;
                                }
                            }
                            else
                            {
                                dataGridView1.Rows[index].Cells[3].Value = "无";
                            }
                        }
                    }
                    dataGridView1.Rows[index].Cells[3].Value = tmpListPersonnelInformation[i].NumberOfPersonnel;
                    dataGridView1.Rows[index].Cells[4].Value = tmpListPersonnelInformation[i].EquipmentQuantity;
                    dataGridView1.Rows[index].Cells[5].Value = tmpListPersonnelInformation[i].Description;
                }
            }
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _PersonnelInformationList.ID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }
        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            PersonnelInformationList tmpData = null;
            Add_Modify_PersonnelInformation tmpAdd_Modify_PersonnelInformation = new Add_Modify_PersonnelInformation(tmpData);
            tmpAdd_Modify_PersonnelInformation.ShowDialog();
            if (tmpAdd_Modify_PersonnelInformation.result == DialogResult.OK)
            {
                GetPersonnelInformationList();
            }
        }

        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            PersonnelInformationList tmpData = new PersonnelInformationList();
            for (int i = 0; i < tmpListPersonnelInformation.Count; i++)
            {
                if (tmpListPersonnelInformation[i].ID == _PersonnelInformationList.ID)
                {
                    tmpData = tmpListPersonnelInformation[i];
                    break;
                }
            }
            Add_Modify_PersonnelInformation tmpAdd_Modify_PersonnelInformation = new Add_Modify_PersonnelInformation(tmpData);
            tmpAdd_Modify_PersonnelInformation.ShowDialog();
            if (tmpAdd_Modify_PersonnelInformation.result == DialogResult.OK)
            {
                GetPersonnelInformationList();
            }
        }

        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            Guid[] tmpGudi = new Guid[1];
            if (_PersonnelInformationList != null)
            {
                tmpGudi[0] = _PersonnelInformationList.ID;
                tmpPersonnelInformationCommand._DelData(tmpGudi);
                GetPersonnelInformationList();
            }
        }
    }
}
