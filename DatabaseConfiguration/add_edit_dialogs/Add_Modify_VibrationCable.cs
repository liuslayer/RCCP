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
    public partial class Add_Modify_VibrationCable : Form
    {
        public DialogResult result = DialogResult.Cancel;
        VibrationCableList tmpStation;

        List<ProtocolTypeList> _tmpListProtocolType;
        ProtocolType_Command tmpProtocolTypeCommand = new ProtocolType_Command();

        List<StationList> _tmpStationList = new List<StationList>();
        Station_Command tmpStationDataCommand = new Station_Command();

        List<SerialCOMList> _tmpListSerialCOM;
        SerialCOM_Command tmpSerialCOM_Command = new SerialCOM_Command();

        public Add_Modify_VibrationCable(VibrationCableList _tmpData)
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
                VibrationCableData(tmpStation);
            }
        }

        public void TypeNameDataBinding()
        {
            _tmpListProtocolType = tmpProtocolTypeCommand._QueryData();
            DataTable TableProtocolType = new DataTable();
            TableProtocolType.Columns.Add("Text", Type.GetType("System.String"));
            TableProtocolType.Columns.Add("Value", Type.GetType("System.String"));
            TableProtocolType.Rows.Add("无", 0);
            if (_tmpListProtocolType != null)
            {
                for (int j = 0; j < _tmpListProtocolType.Count; j++)
                {
                    if (_tmpListProtocolType[j].TypeID == (int)DeviceParamType.VibrationCableDevice)
                    {
                        TableProtocolType.Rows.Add(_tmpListProtocolType[j].ProtocolTypeName, _tmpListProtocolType[j].ProtocolTypeID);
                    }
                }
                comboBoxProtocolType.DataSource = TableProtocolType;
                comboBoxProtocolType.DisplayMember = "Text";   // Text，即显式的文本
                comboBoxProtocolType.ValueMember = "Value";    // Value，即实际的值
                comboBoxProtocolType.SelectedIndex = 0;        //  设置为默认选中第一个
            }

            //所属监控站
            _tmpStationList = tmpStationDataCommand._QueryData();
            DataTable TableStation = new DataTable();
            TableStation.Columns.Add("Text", Type.GetType("System.String"));
            TableStation.Columns.Add("Value", Type.GetType("System.String"));
            TableStation.Rows.Add("无", null);
            if (_tmpStationList != null)
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
            //通信
            DataTable TableCommunicationMode = new DataTable();
            TableCommunicationMode.Columns.Add("Text", Type.GetType("System.String"));
            TableCommunicationMode.Columns.Add("Value", Type.GetType("System.String"));
            TableCommunicationMode.Rows.Add("无", 0);
            TableCommunicationMode.Rows.Add("串口通信", (int)CommunicationMode.ComType);
            TableCommunicationMode.Rows.Add("网络通信", (int)CommunicationMode.NetworkType);
            comboBoxCommunicationInternet.DataSource = TableCommunicationMode;
            comboBoxCommunicationInternet.DisplayMember = "Text";   // Text，即显式的文本
            comboBoxCommunicationInternet.ValueMember = "Value";    // Value，即实际的值
            comboBoxCommunicationInternet.SelectedIndex = 0;        //  设置为默认选中第一个


            _tmpListSerialCOM = tmpSerialCOM_Command._QueryData();
            DataTable TableSerialCOM = new DataTable();
            TableSerialCOM.Columns.Add("Text", Type.GetType("System.String"));
            TableSerialCOM.Columns.Add("Value", Type.GetType("System.String"));
            TableSerialCOM.Rows.Add("无", null);
            if (_tmpListSerialCOM != null)
            {
                for (int j = 0; j < _tmpListSerialCOM.Count; j++)
                {
                    TableSerialCOM.Rows.Add(_tmpListSerialCOM[j].Name, _tmpListSerialCOM[j].DeviceID);
                }
                comboBox3.DataSource = TableSerialCOM;
                comboBox3.DisplayMember = "Text";   // Text，即显式的文本
                comboBox3.ValueMember = "Value";    // Value，即实际的值
                comboBox3.SelectedIndex = 0;        //  设置为默认选中第一个
            }
        }

        public void VibrationCableData(VibrationCableList _tmpData)
        {
            txtname.Text = _tmpData.Name;
            txtlon.Text = _tmpData.Lon.ToString();
            txtlat.Text = _tmpData.Lat.ToString();
            txtalt.Text = _tmpData.Alt.ToString();
            comboBoxProtocolType.SelectedValue = _tmpData.ProtocolType;
            if (_tmpData.StationID != null)
            {
                comboBox1.SelectedValue = _tmpData.StationID;
            }
            comboBoxCommunicationInternet.SelectedValue = _tmpData.CommunicationType;
            if (_tmpData.CommunicationID != null)
            {
                comboBox3.SelectedValue = _tmpData.CommunicationID;
            }
            txtdescription.Text = _tmpData.Description;
        }


        private void btnsure_Click(object sender, EventArgs e)
        {
            double lon = 0.0, lat = 0.0, alt = 0.0;
            List<VibrationCableList> tmpVibrationCableList = new List<VibrationCableList>();
            VibrationCableList _VibrationCableList = new VibrationCableList();
            VibrationCable_Command tmpVibrationCable_Command = new VibrationCable_Command();

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
                _VibrationCableList.DeviceID = tmpStation.DeviceID;
            }

            _VibrationCableList.Name = txtname.Text.Trim();
            if (comboBox1.SelectedValue.ToString() != "")
            { _VibrationCableList.StationID = new Guid(comboBox1.SelectedValue.ToString()); }
            else { _VibrationCableList.StationID = null; }

            _VibrationCableList.TypeID = Convert.ToInt32(DeviceParamType.VibrationCableDevice);
            _VibrationCableList.Lon = Convert.ToDouble(txtlon.Text.Trim());
            _VibrationCableList.Lat = Convert.ToDouble(txtlat.Text.Trim());
            _VibrationCableList.Alt = Convert.ToDouble(txtalt.Text.Trim());
            if (comboBoxProtocolType.SelectedValue.ToString() != "")
            {
                _VibrationCableList.ProtocolType = Convert.ToInt32(comboBoxProtocolType.SelectedValue);
            }
            else { _VibrationCableList.ProtocolType = 0; }
            if (comboBoxCommunicationInternet.SelectedValue.ToString() != "")
            {
                _VibrationCableList.CommunicationType = Convert.ToInt32(comboBoxCommunicationInternet.SelectedValue);
            }
            else { _VibrationCableList.CommunicationType = 0; }

            if (comboBox3.SelectedValue.ToString() == "")
            {
                _VibrationCableList.CommunicationID = null;
            }
            else
            {
                _VibrationCableList.CommunicationID = new Guid(comboBox3.SelectedValue.ToString());
            }

            _VibrationCableList.Description = txtdescription.Text.Trim();
            tmpVibrationCableList.Add(_VibrationCableList);
            if (tmpStation == null)
            {
                tmpVibrationCable_Command._AddData(tmpVibrationCableList);
                result = MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK);
            }
            else if (tmpStation != null)
            {
                tmpVibrationCable_Command._ReviseData(tmpVibrationCableList);
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
