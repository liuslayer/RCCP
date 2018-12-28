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
    
    public partial class Add_Modify_StreamMedia : Form
    {
        StreamMediaList tmpStreamMedia = null;
        List<DeviceTypeList> tmpDeviceTypeList = null;
        public DialogResult result = DialogResult.Cancel;
        List<DeviceTypeList> tmpListDeviceType;

        DeviceTypeList _tmpDeviceTypeList = new DeviceTypeList();
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();

        List<StationList> _tmpStationList;
        Station_Command tmpStationDataCommand = new Station_Command();

        public Add_Modify_StreamMedia(StreamMediaList tmpData, List<DeviceTypeList> tmpData1)
        {
            InitializeComponent();
            
            if (tmpData == null)
            {
                tmpStreamMedia = tmpData;
                TypeNameDataBinding();
            }
            else
            {
                TypeNameDataBinding();
                tmpStreamMedia = tmpData;
                tmpDeviceTypeList = tmpData1;
                StreamMediaData(tmpStreamMedia);
            }
            
        }
        private void TypeNameDataBinding()
        {
            tmpListDeviceType = tmpDeviceTypeCommand._QueryData();
            DataTable Typenametable = new DataTable();
            Typenametable.Columns.Add("Text", Type.GetType("System.String"));
            Typenametable.Columns.Add("Value", Type.GetType("System.String"));
            if(tmpListDeviceType.Count > 0)
            {
                for(int i = 0; i < tmpListDeviceType.Count; i++)
                {
                    if (tmpListDeviceType[i].TypeID == (int)DeviceParamType.NVRDevice || tmpListDeviceType[i].TypeID == (int)DeviceParamType.DVRDevice || tmpListDeviceType[i].TypeID == (int)DeviceParamType.StreamMediaDevice)
                    {
                        Typenametable.Rows.Add(tmpListDeviceType[i].TypeName, tmpListDeviceType[i].TypeID);
                    }
                }
                cbxtypename.DataSource = Typenametable;
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
        private void StreamMediaData(StreamMediaList _tmpDeviceData)
        { 
            
            txtname.Text = _tmpDeviceData.Name;
            txtusername.Text = _tmpDeviceData.UserName;
            txtpassword.Text = _tmpDeviceData.PassWord;
            txtip.Text = _tmpDeviceData.VideoIP;
            txtport.Text = _tmpDeviceData.Port.ToString();
            txtchanlenum.Text = _tmpDeviceData.ChannelNum.ToString();
            txtdescription.Text = _tmpDeviceData.Description;
            if(_tmpDeviceData.StationID !=null)
            {
                comboBox1.SelectedValue = _tmpDeviceData.StationID;
            }
            if (_tmpDeviceData.TypeID != null)
            {
                cbxtypename.SelectedValue = _tmpDeviceData.TypeID;
            }
            
        }
        private void btnsure_Click(object sender, EventArgs e)
        {
            StreamMediaList _StreamMediaList = new StreamMediaList();
            StreamMedia_Command tmpStreamMedia_Command = new StreamMedia_Command();
            List<StreamMediaList> tmpStreamMediaList = new List<StreamMediaList>();


            if (txtname.Text.Trim() == "")
            { MessageBox.Show("请填写设备名字"); return; }

            if (txtusername.Text.Trim() == "")
            { MessageBox.Show("请填写用户名"); return; }

            if (txtpassword.Text.Trim() == "")
            { MessageBox.Show("请填写密码"); return; }

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
                        {
                            MessageBox.Show("IP格式不合法");
                            return;
                        }
                        if (string_to_int > 254 || string_to_int < 0 || string_to_int.ToString() != ipstring[i])
                        {
                            MessageBox.Show("IP格式不合法");
                            return;
                        }
                    }
                }
                else { MessageBox.Show("IP格式不合法"); return; }
            }

            if (txtport.Text.Trim() == "") { MessageBox.Show("请填写端口号"); return; }
            else
            {
                int port = 0;
                if (!int.TryParse(txtport.Text.Trim(), out port)) { MessageBox.Show("端口号要为数字"); return; }
            }

            if (txtchanlenum.Text.Trim() == "") { MessageBox.Show("请填写通道数"); return; }
            else
            {
                int channelnum = 0;
                if (!int.TryParse(txtchanlenum.Text.Trim(), out channelnum)) { MessageBox.Show("通道数要为数字"); return; }
            }



            //private Guid _deviceid;
            //private Guid? _streamserverid;
            //private Guid? _serialcomid;

            //private int _streammediaport;


            if(tmpStreamMedia !=null)
            {
                _StreamMediaList.DeviceID = tmpStreamMedia.DeviceID;
                _StreamMediaList.StreamServerID = tmpStreamMedia.StreamServerID;
                _StreamMediaList.SerialCOMID = tmpStreamMedia.SerialCOMID;
            }

            _StreamMediaList.TypeID = Convert.ToInt32(cbxtypename.SelectedValue.ToString()) ;
            _StreamMediaList.Name = txtname.Text.Trim();
            _StreamMediaList.UserName = txtusername.Text.Trim();
            _StreamMediaList.PassWord = txtpassword.Text.Trim();
            _StreamMediaList.VideoIP = txtip.Text.Trim();
            _StreamMediaList.Port = Convert.ToInt32(txtport.Text.Trim());
            _StreamMediaList.ChannelNum = Convert.ToInt32(txtchanlenum.Text.Trim());
            _StreamMediaList.Description = txtdescription.Text.Trim();
            _StreamMediaList.StationID = new Guid( comboBox1.SelectedValue.ToString());
            tmpStreamMediaList.Add(_StreamMediaList);
            if (tmpStreamMedia == null)
            {
                tmpStreamMedia_Command._AddData(tmpStreamMediaList);
                result = MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK);
            }
            else
            {
                tmpStreamMedia_Command._ReviseData(tmpStreamMediaList);
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
