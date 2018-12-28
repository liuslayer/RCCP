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
    public partial class Add_Modify_Computer : Form
    {
        public DialogResult result = DialogResult.Cancel;
        ComputerList tmpStation;

        List<StationList> _tmpStationList = new List<StationList>();
        Station_Command tmpStationDataCommand = new Station_Command();

        public Add_Modify_Computer(ComputerList _tmpData)
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
                ComputerData(tmpStation);
            }
        }
        private void TypeNameDataBinding()
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

        private void ComputerData(ComputerList _tmpData)
        {
            txtname.Text = _tmpData.Name;
            txtip.Text = _tmpData.Ip;
            if (_tmpData.StationID != null)
            {
                comboBox1.SelectedValue = _tmpData.StationID;
            }
            txtdescription.Text = _tmpData.Description;
        }
        private void btnsure_Click(object sender, EventArgs e)
        {
            List<ComputerList> tmpComputerList = new List<ComputerList>();
            ComputerList _ComputerList = new ComputerList();
            Computer_Command tmpComputer_Command = new Computer_Command();

            if (txtname.Text.Trim() == "") { MessageBox.Show("请填写计算机名称！"); return; }
            else if (txtname.Text.Trim().ToString().Length > 25) { MessageBox.Show("计算机名称超过25个字符！"); return; }

            string[] ipstring = txtip.Text.Trim().Split('.');
            if (ipstring.Length == 0) { MessageBox.Show("请填写IP"); return; }
            else
            {
                if (ipstring.Length == 4)
                {
                    int string_to_int = 0;
                    for (int i = 0; i < ipstring.Length; i++)
                    {
                        if (!int.TryParse(ipstring[i], out string_to_int))
                        { MessageBox.Show("IP格式不合法"); return; }
                        if (string_to_int > 254 || string_to_int < 0 || string_to_int.ToString() != ipstring[i])
                        { MessageBox.Show("IP格式不合法"); return; }
                    }
                }
                else { MessageBox.Show("IP格式不合法"); return; }
            }
            if (tmpStation != null)
            {
                _ComputerList.DeviceID = tmpStation.DeviceID;
            }
            _ComputerList.Name = txtname.Text.Trim();
            _ComputerList.Ip = txtip.Text.Trim();
            _ComputerList.TypeID = Convert.ToInt32(DeviceParamType.ComputerDevice);
            if (comboBox1.SelectedValue.ToString() != "")
            { _ComputerList.StationID = new Guid(comboBox1.SelectedValue.ToString()); }
            else { _ComputerList.StationID = null; }
            _ComputerList.Description = txtdescription.Text.Trim();
            tmpComputerList.Add(_ComputerList);
            if (tmpStation == null)
            {
                tmpComputer_Command._AddData(tmpComputerList);
                result = MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK);
            }
            else
            {
                tmpComputer_Command._ReviseData(tmpComputerList);
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
