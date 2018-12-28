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
    public partial class Add_Modify_PersonnelInformation : Form
    {
        public DialogResult result = DialogResult.Cancel;
        PersonnelInformationList tmpStation;

        List<StationList> _tmpStationList = new List<StationList>();
        Station_Command tmpStationDataCommand = new Station_Command();
        public Add_Modify_PersonnelInformation(PersonnelInformationList _tmpData)
        {
            InitializeComponent();
            if (_tmpData == null)
            {
                TypeNameDataBinding();
            }
            else if (_tmpData != null)
            {
                tmpStation = _tmpData;
                TypeNameDataBinding();
                PersonnelInformationData(tmpStation);
            }
        }
        public void TypeNameDataBinding()
        {
            _tmpStationList = tmpStationDataCommand._QueryData();
            DataTable TableStation = new DataTable();
            TableStation.Columns.Add("Text", Type.GetType("System.String"));
            TableStation.Columns.Add("Value", Type.GetType("System.String"));
            TableStation.Rows.Add("无", null);
            if (_tmpStationList.Count > 0)
            {
                for (int j = 0; j < _tmpStationList.Count; j++)
                {
                    TableStation.Rows.Add(_tmpStationList[j].Name, _tmpStationList[j].StationID);
                }
                comboBox1.DataSource = TableStation;
                comboBox1.DisplayMember = "Text";   // Text，即显式的文本
                comboBox1.ValueMember = "Value";    // Value，即实际的值
                comboBox1.SelectedIndex = 0;        //  设置为默认选中第一个
            }
        }
        public void PersonnelInformationData(PersonnelInformationList _tmpData)
        {
            txtname.Text = _tmpData.Name;
            txtlon.Text = _tmpData.NumberOfPersonnel.ToString();
            txtlat.Text = _tmpData.EquipmentQuantity.ToString();
            if (_tmpData.StationID != null)
            {
                comboBox1.SelectedValue = _tmpData.StationID;
            }
            txtdescription.Text = _tmpData.Description;
        }

        private void btnsure_Click(object sender, EventArgs e)
        {
            List<PersonnelInformationList> tmpPersonnelInformationList = new List<PersonnelInformationList>();
            PersonnelInformationList _PersonnelInformationList = new PersonnelInformationList();
            PersonnelInformation_Command tmpPersonnelInformation_Command = new PersonnelInformation_Command();

            int lon = 0, lat = 0;
            if (txtname.Text.Trim() == "")
            { MessageBox.Show("请填写设备名字"); return; }

            if (txtlon.Text.Trim() == "")
            { MessageBox.Show("请填写人员数量"); }
            else
            {
                if (!Int32.TryParse(txtlon.Text.Trim(), out lon))
                {
                    MessageBox.Show("人员数量为数值类型");
                    return;
                }
            }

            if (txtlat.Text.Trim() == "")
            { MessageBox.Show("请填装备数量"); return; }
            else
            {
                if (!Int32.TryParse(txtlat.Text.Trim(), out lat))
                {
                    MessageBox.Show("装备数量为数值类型");
                    return;
                }
            }

            if (tmpStation != null)
            {
                _PersonnelInformationList.ID = tmpStation.ID;
            }
            _PersonnelInformationList.Name = txtname.Text.Trim();
            _PersonnelInformationList.NumberOfPersonnel = Convert.ToInt32(txtlon.Text.Trim());
            _PersonnelInformationList.EquipmentQuantity = Convert.ToInt32(txtlat.Text.Trim());

            if (comboBox1.SelectedValue.ToString() != null)
            { _PersonnelInformationList.StationID = new Guid(comboBox1.SelectedValue.ToString()); }
            else { _PersonnelInformationList.StationID = null; }

            _PersonnelInformationList.Description = txtdescription.Text.Trim();
            tmpPersonnelInformationList.Add(_PersonnelInformationList);

            if (tmpStation == null)
            {
                tmpPersonnelInformation_Command._AddData(tmpPersonnelInformationList);
                result = MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK);
            }
            else if (tmpStation != null)
            {
                tmpPersonnelInformation_Command._ReviseData(tmpPersonnelInformationList);
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
