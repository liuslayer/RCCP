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
    public partial class ConfigDVRorNVRSwitchTypeInfo : Form
    {//ConfigStreamMediaInfo
        public ConfigDVRorNVRSwitchTypeInfo()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                //_tmpDeviceTypeList.ID = new Guid(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
            }
        }
    }
}
