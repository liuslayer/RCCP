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
    public partial class Add_Modify_Station : Form
    {
        public DialogResult result = DialogResult.Cancel;
        StationList tmpStation = null;

        List<DeviceTypeList> tmpListDeviceType;
        DeviceTypeList _tmpDeviceTypeList = new DeviceTypeList();
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();

        List<StationList> _tmpStationList = new List<StationList>();
        StationList StationList_ = new StationList();
        Station_Command tmpStationDataCommand = new Station_Command();


        public Add_Modify_Station(StationList _tmpData)
        {
            InitializeComponent();
            if (_tmpData == null)
            {
                tmpStation = _tmpData;
                TypeNameDataBinding();
            }
            else
            {
                tmpStation = _tmpData;
                TypeNameDataBinding();
                StationData(tmpStation);
            }
        }

        private void TypeNameDataBinding()
        {
            tmpListDeviceType = tmpDeviceTypeCommand._QueryData();
            DataTable TableDeviceType = new DataTable();
            TableDeviceType.Columns.Add("Text", Type.GetType("System.String"));
            TableDeviceType.Columns.Add("Value", Type.GetType("System.String"));
            if (tmpListDeviceType.Count > 0)
            {
                for (int i = 0; i < tmpListDeviceType.Count; i++)
                {
                    if (tmpListDeviceType[i].TypeID == (int)DeviceParamType.Station)
                    {
                        TableDeviceType.Rows.Add(tmpListDeviceType[i].TypeName, tmpListDeviceType[i].TypeID);
                    }
                }
                //if()
                cbxtypename.DataSource = TableDeviceType;
                cbxtypename.DisplayMember = "Text";   // Text，即显式的文本
                cbxtypename.ValueMember = "Value";    // Value，即实际的值
                cbxtypename.SelectedIndex = 0;        //  设置为默认选中第一个
            }

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

        private void StationData(StationList _tmpData)
        {
            cbxtypename.SelectedValue = _tmpData.TypeID;
            if(_tmpData.PStationID !=null)
            {
                comboBox1.SelectedValue = _tmpData.PStationID;
            }
            
            txtname.Text = _tmpData.Name;
            txtlon.Text = _tmpData.Lon.ToString();
            txtlat.Text = _tmpData.Lat.ToString();
            txtdescription.Text = _tmpData.Description;
        }

        private void btnsure_Click(object sender, EventArgs e)
        {
            double lon = 0.0, lat = 0.0;
            List<StationList> tmpStationList = new List<StationList>();
            StationList _StationList = new StationList();
            Station_Command tmpStationData_Command = new Station_Command();

            if (txtname.Text.Trim()=="")
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
            if(tmpStation !=null)
            {
                _StationList.StationID = tmpStation.StationID;
                _StationList.PStationID = tmpStation.PStationID;
            }
            _StationList.Name = txtname.Text;
            if (comboBox1.SelectedValue.ToString() !="")
            {
                _StationList.PStationID = new Guid(comboBox1.SelectedValue.ToString());
            }
            else
            { _StationList.PStationID = null; }

            
            _StationList.TypeID = Convert.ToInt32(cbxtypename.SelectedValue.ToString());
            _StationList.Lon = Convert.ToDouble(txtlon.Text.Trim());
            _StationList.Lat = Convert.ToDouble(txtlat.Text.Trim());
            _StationList.Description = txtdescription.Text;
            _StationList.Mark = null;
            tmpStationList.Add(_StationList);
            
            if (tmpStation == null)
            {
                tmpStationData_Command._AddData(tmpStationList);
                result = MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK);
            }
            else
            {
                tmpStationData_Command._ReviseData(tmpStationList);
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
