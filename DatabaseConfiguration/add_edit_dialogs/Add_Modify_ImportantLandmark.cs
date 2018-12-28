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

namespace DatabaseConfiguration.add_edit_dialogs
{
    public partial class Add_Modify_ImportantLandmark : Form
    {
        public DialogResult result = DialogResult.Cancel;
        ImportantLandmarkList tmpStation;
        public Add_Modify_ImportantLandmark(ImportantLandmarkList _tmpData)
        {
            InitializeComponent();
            if (_tmpData == null)
            {
                //TypeNameDataBinding();
            }
            else if (_tmpData != null)
            {
                tmpStation = _tmpData;
                //TypeNameDataBinding();
                ImportantLandmarkData(tmpStation);
            }
        }

        public void TypeNameDataBinding()
        {

        }

        public void ImportantLandmarkData(ImportantLandmarkList _tmpData)
        {
            txtname.Text = _tmpData.Name;
            txtlon.Text = _tmpData.Lon.ToString();
            txtlat.Text = _tmpData.Lat.ToString();
            txtalt.Text = _tmpData.Alt.ToString();
            txtdescription.Text = _tmpData.Description;
        }

        private void btnsure_Click(object sender, EventArgs e)
        {
            double lon = 0.0, lat = 0.0, alt = 0.0;

            List<ImportantLandmarkList> tmpImportantLandmarkList = new List<ImportantLandmarkList>();
            ImportantLandmarkList _ImportantLandmarkList = new ImportantLandmarkList();
            ImportantLandmark_Command tmpImportantLandmark_Command = new ImportantLandmark_Command();

            if (txtname.Text.Trim() == "")
            { MessageBox.Show("请填写设备名字"); return; }

            if (txtlon.Text.Trim() == "")
            { MessageBox.Show("请填写经度"); }
            else
            {
                if (!double.TryParse(txtlon.Text.Trim(), out lon))
                {
                    MessageBox.Show("经度为数值类型");
                    return;
                }
            }
            if (txtlat.Text.Trim() == "")
            { MessageBox.Show("请填写纬度"); return; }
            else
            {
                if (!double.TryParse(txtlat.Text.Trim(), out lat))
                {
                    MessageBox.Show("纬度为数值类型");
                    return;
                }
            }

            if (txtalt.Text.Trim() == "")
            { MessageBox.Show("请填写海拔"); return; }
            else
            {
                if (!double.TryParse(txtalt.Text.Trim(), out alt))
                {
                    MessageBox.Show("海拔为数值类型");
                    return;
                }
            }

            if (tmpStation != null)
            {
                _ImportantLandmarkList.ID = tmpStation.ID;
            }
            _ImportantLandmarkList.Name = txtname.Text.Trim();
            _ImportantLandmarkList.Lon = Convert.ToDouble(txtlon.Text.Trim());
            _ImportantLandmarkList.Lat = Convert.ToDouble(txtlat.Text.Trim());
            _ImportantLandmarkList.Alt = Convert.ToDouble(txtalt.Text.Trim());
            _ImportantLandmarkList.Description = txtdescription.Text.Trim();
            tmpImportantLandmarkList.Add(_ImportantLandmarkList);

            if (tmpStation == null)
            {
                tmpImportantLandmark_Command._AddData(tmpImportantLandmarkList);
                result = MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK);
            }
            else if (tmpStation != null)
            {
                tmpImportantLandmark_Command._ReviseData(tmpImportantLandmarkList);
                result = MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK);
            }

            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
