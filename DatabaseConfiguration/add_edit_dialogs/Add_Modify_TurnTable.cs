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
    public partial class Add_Modify_TurnTable : Form
    {
        public DialogResult result = DialogResult.Cancel;
        TurnTableList tmpStation;

        List<ProtocolTypeList> _tmpListProtocolType;
        ProtocolType_Command tmpProtocolTypeCommand = new ProtocolType_Command();

        List<StationList> _tmpStationList = new List<StationList>();
        Station_Command tmpStationDataCommand = new Station_Command();

        List<SerialCOMList> _tmpListSerialCOM;
        SerialCOM_Command tmpSerialCOM_Command = new SerialCOM_Command();
        public Add_Modify_TurnTable(TurnTableList _tmpData)
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
                TurnTableData(tmpStation);
            }
        }

        public void TypeNameDataBinding()
        {
            DataTable TableHeightMeasurementType = new DataTable();
            TableHeightMeasurementType.Columns.Add("Text", Type.GetType("System.String"));
            TableHeightMeasurementType.Columns.Add("Value", Type.GetType("System.String"));
            //TableHeightMeasurementType.Rows.Add("无", null);
            TableHeightMeasurementType.Rows.Add("用户测量", (int)HeightMeasurementType.UserMeasurement);
            TableHeightMeasurementType.Rows.Add("北斗测量", (int)HeightMeasurementType.BeiDouMeasurement);
            comboBox2.DataSource = TableHeightMeasurementType;
            comboBox2.DisplayMember = "Text";   // Text，即显式的文本
            comboBox2.ValueMember = "Value";    // Value，即实际的值
            comboBox2.SelectedIndex = 0;        //  设置为默认选中第一个

            _tmpListProtocolType = tmpProtocolTypeCommand._QueryData();
            DataTable TableProtocolType = new DataTable();
            TableProtocolType.Columns.Add("Text", Type.GetType("System.String"));
            TableProtocolType.Columns.Add("Value", Type.GetType("System.String"));
            TableProtocolType.Rows.Add("无", 0);
            if (_tmpListProtocolType.Count > 0)
            {
                for (int j = 0; j < _tmpListProtocolType.Count; j++)
                {
                    if (_tmpListProtocolType[j].TypeID == (int)DeviceParamType.TurnTableDevice)
                    {
                        TableProtocolType.Rows.Add(_tmpListProtocolType[j].ProtocolTypeName, _tmpListProtocolType[j].ProtocolTypeID);
                    }
                }
                comboBoxProtocolType.DataSource = TableProtocolType;
                comboBoxProtocolType.DisplayMember = "Text";   // Text，即显式的文本
                comboBoxProtocolType.ValueMember = "Value";    // Value，即实际的值
                comboBoxProtocolType.SelectedIndex = 0;        //  设置为默认选中第一个
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
            if (_tmpListSerialCOM.Count > 0)
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
        public void TurnTableData(TurnTableList _tmpData)
        {
            txtname.Text = _tmpData.Name;
            txtlon.Text = _tmpData.Lon.ToString();
            txtlat.Text = _tmpData.Lat.ToString();
            txtalt.Text = _tmpData.Alt.ToString();
            comboBox2.SelectedValue = _tmpData.ErectingHeightType;
            txterectingheight.Text = _tmpData.ErectingHeight.ToString();
            txtazimuthangle.Text = _tmpData.AzimuthAngle.ToString();
            comboBoxProtocolType.SelectedValue = _tmpData.ProtocolType;
            txtTurntableAddr.Text = _tmpData.TurntableAddr.ToString();
            txtCCDAddr.Text = _tmpData.CCDAddr.ToString();
            txtIRAddr.Text = _tmpData.IRAddr.ToString();
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
            double lon = 0.0, lat = 0.0, alt = 0.0, height = 0.0;
            int Taddr=0,CCDaddr=0,IRaddr=0;
            List<TurnTableList> tmpTurnTableList = new List<TurnTableList>();
            TurnTableList _TurnTableList = new TurnTableList();
            TurnTable_Command tmpTurnTable_Command = new TurnTable_Command();

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

            if(txterectingheight.Text.Trim() == "")
            { MessageBox.Show("请填写架设高度");return; }
            else
            {
                if(!double.TryParse(txterectingheight.Text.Trim(),out height)) { MessageBox.Show("架设高度为数值类型");return; }
            }

            if (txtazimuthangle.Text.Trim() == "")
            { MessageBox.Show("请填写偏北角"); return; }
            else
            {
                if (!double.TryParse(txtazimuthangle.Text.Trim(), out height)) { MessageBox.Show("偏北角为数值类型"); return; }
            }

            if (txtTurntableAddr.Text.Trim() == "")
            { MessageBox.Show("请填写转台地址"); return; }
            else
            {
                if (!Int32.TryParse(txtTurntableAddr.Text.Trim(), out Taddr)) { MessageBox.Show("转台地址为数值类型"); return; }
            }

            if (txtCCDAddr.Text.Trim() == "")
            { MessageBox.Show("请填写白光地址"); return; }
            else
            {
                if (!Int32.TryParse(txtCCDAddr.Text.Trim(), out CCDaddr)) { MessageBox.Show("白光地址为数值类型"); return; }
            }

            if (txtIRAddr.Text.Trim() == "")
            { MessageBox.Show("请填写红外地址"); return; }
            else
            {
                if (!Int32.TryParse(txtIRAddr.Text.Trim(), out IRaddr)) { MessageBox.Show("红外地址为数值类型"); return; }
            }
            if(tmpStation != null)
            {
                _TurnTableList.DeviceID = tmpStation.DeviceID;
            }

            _TurnTableList.Name = txtname.Text.Trim();

            if(comboBox1.SelectedValue.ToString() !=null)
            { _TurnTableList.StationID = new Guid(comboBox1.SelectedValue.ToString()); }
            else { _TurnTableList.StationID = null; }
            
            _TurnTableList.TypeID = Convert.ToInt32(DeviceParamType.TurnTableDevice);
            _TurnTableList.Lon = Convert.ToDouble(txtlon.Text.Trim());
            _TurnTableList.Lat = Convert.ToDouble(txtlat.Text.Trim());
            _TurnTableList.Alt = Convert.ToDouble(txtalt.Text.Trim());
            _TurnTableList.ErectingHeight = Convert.ToDouble(txterectingheight.Text.Trim());
            _TurnTableList.ErectingHeightType = Convert.ToInt32(comboBox2.SelectedValue);
            _TurnTableList.AzimuthAngle = Convert.ToInt32(txtazimuthangle.Text.Trim());
            _TurnTableList.ProtocolType = Convert.ToInt32(comboBoxProtocolType.SelectedValue);
            _TurnTableList.TurntableAddr = Convert.ToInt32(txtTurntableAddr.Text.Trim());
            _TurnTableList.CCDAddr = Convert.ToInt32(txtCCDAddr.Text.Trim());
            _TurnTableList.IRAddr = Convert.ToInt32(txtIRAddr.Text.Trim());
            _TurnTableList.CommunicationType = Convert.ToInt32(comboBoxCommunicationInternet.SelectedValue);
            if(comboBox3.SelectedValue.ToString()!="")
            {
                _TurnTableList.CommunicationID = new Guid(comboBox3.SelectedValue.ToString());
            }
            else { _TurnTableList.CommunicationID = null; }
            
            _TurnTableList.Description = txtdescription.Text.Trim();
            tmpTurnTableList.Add(_TurnTableList);
            if (tmpStation == null)
            {
                tmpTurnTable_Command._AddData(tmpTurnTableList);
                result = MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK);
            }
            else if (tmpStation != null)
            {
                tmpTurnTable_Command._ReviseData(tmpTurnTableList);
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
