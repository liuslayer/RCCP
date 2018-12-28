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
    public partial class ConfigImportantLandmarkInfo : Form
    {
        List<ImportantLandmarkList> tmpListImportantLandmark;
        ImportantLandmarkList _ImportantLandmarkList = new ImportantLandmarkList();
        ImportantLandmark_Command tmpImportantLandmarkCommand = new ImportantLandmark_Command();
        public ConfigImportantLandmarkInfo()
        {
            InitializeComponent();
            GetImportantLandmarkList();
            dataGridView1.Columns[0].Visible = false;
        }
        public void GetImportantLandmarkList()
        {
            tmpListImportantLandmark = tmpImportantLandmarkCommand._QueryData();
            dataGridView1.Rows.Clear();
            if (tmpListImportantLandmark != null)
            {
                for (int i = 0; i < tmpListImportantLandmark.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    //ID
                    dataGridView1.Rows[index].Cells[0].Value = tmpListImportantLandmark[i].ID;
                    //名称
                    dataGridView1.Rows[index].Cells[1].Value = tmpListImportantLandmark[i].Name;

                    //经度
                    if (tmpListImportantLandmark[i].Lon != null)
                    {
                        dataGridView1.Rows[index].Cells[2].Value = tmpListImportantLandmark[i].Lon;
                    }
                    else { dataGridView1.Rows[index].Cells[2].Value = "无"; }

                    //纬度
                    if (tmpListImportantLandmark[i].Lat != null)
                    {
                        dataGridView1.Rows[index].Cells[3].Value = tmpListImportantLandmark[i].Lat;
                    }
                    else { dataGridView1.Rows[index].Cells[3].Value = "无"; }

                    //海拔
                    dataGridView1.Rows[index].Cells[4].Value = tmpListImportantLandmark[i].Alt;

                    dataGridView1.Rows[index].Cells[5].Value = tmpListImportantLandmark[i].Description;
                }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                _ImportantLandmarkList.ID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void ToolStripMenuItem_add_Click(object sender, EventArgs e)
        {
            ImportantLandmarkList tmpData = null;
            Add_Modify_ImportantLandmark tmpAdd_Modify_ImportantLandmark = new Add_Modify_ImportantLandmark(tmpData);
            tmpAdd_Modify_ImportantLandmark.ShowDialog();
            if (tmpAdd_Modify_ImportantLandmark.result == DialogResult.OK)
            {
                GetImportantLandmarkList();
            }
        }

        private void ToolStripMenuItem_edittype_Click(object sender, EventArgs e)
        {
            ImportantLandmarkList tmpData = new ImportantLandmarkList();
            for (int i = 0; i < tmpListImportantLandmark.Count; i++)
            {
                if (tmpListImportantLandmark[i].ID == _ImportantLandmarkList.ID)
                {
                    tmpData = tmpListImportantLandmark[i];
                    break;
                }
            }
            Add_Modify_ImportantLandmark tmpAdd_Modify_ImportantLandmark = new Add_Modify_ImportantLandmark(tmpData);
            tmpAdd_Modify_ImportantLandmark.ShowDialog();
            if (tmpAdd_Modify_ImportantLandmark.result == DialogResult.OK)
            {
                GetImportantLandmarkList();
            }
        }

        private void ToolStripMenuItem_Del_Click(object sender, EventArgs e)
        {
            Guid[] tmpGudi = new Guid[1];
            if (_ImportantLandmarkList != null)
            {
                tmpGudi[0] = _ImportantLandmarkList.ID;
                tmpImportantLandmarkCommand._DelData(tmpGudi);
                GetImportantLandmarkList();
            }
        }
    }
}
