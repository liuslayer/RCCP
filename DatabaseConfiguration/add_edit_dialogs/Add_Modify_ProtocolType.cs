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
    public partial class Add_Modify_ProtocolType : Form
    {
        public DialogResult result = DialogResult.Cancel;
        
        ProtocolTypeList tmpProtocolType = null;

        List<ProtocolTypeList> tmpListProtocolType;
        ProtocolTypeList _tmpProtocolTypeList = new ProtocolTypeList();
        ProtocolType_Command tmpProtocolTypeCommand = new ProtocolType_Command();

        List<DeviceTypeList> tmpListDeviceType;
        DeviceTypeList _tmpDeviceTypeList = new DeviceTypeList();
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();
        public Add_Modify_ProtocolType(ProtocolTypeList _tmpData)
        {
            InitializeComponent();
            if(_tmpData == null)
            {
                tmpProtocolType = _tmpData;
                TypeNameDataBinding();
            }
            else
            {
                tmpProtocolType = _tmpData;
                TypeNameDataBinding();
                ProtocolTypeData(tmpProtocolType);
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
                    TableDeviceType.Rows.Add(tmpListDeviceType[i].TypeName, tmpListDeviceType[i].TypeID);
                }
                cbxtypename.DataSource = TableDeviceType;
                cbxtypename.DisplayMember = "Text";   // Text，即显式的文本
                cbxtypename.ValueMember = "Value";    // Value，即实际的值
                cbxtypename.SelectedIndex = 0;        //  设置为默认选中第一个
            }
        }

        private void ProtocolTypeData(ProtocolTypeList _ProtocolTypeData)
        {
            txtname.Text = _ProtocolTypeData.ProtocolTypeName;
            txtprotocoltypeid.Text = _ProtocolTypeData.ProtocolTypeID.ToString();
            cbxtypename.SelectedValue = _ProtocolTypeData.TypeID;
        }
        private void btnsure_Click(object sender, EventArgs e)
        {
            int iprotocoltypeid = 0;
            List<ProtocolTypeList> tmpProtocolTypeList = new List<ProtocolTypeList>();
            ProtocolTypeList _tmpProtocolType = new ProtocolTypeList();
            if (txtname.Text.Trim() == "") { MessageBox.Show("请填写协议类型名称！"); return; }

            if (txtprotocoltypeid.Text.Trim() == "") { MessageBox.Show("请填写协议类型编号！"); return; }
            else
            {
                if (!Int32.TryParse(txtprotocoltypeid.Text.Trim(), out iprotocoltypeid))
                {
                    MessageBox.Show("协议类型编号为数字格式");
                    return;
                }
            }

            if(tmpProtocolType != null)
            {
                _tmpProtocolType.ID = tmpProtocolType.ID;
            }
            _tmpProtocolType.ProtocolTypeName = txtname.Text.Trim();
            _tmpProtocolType.ProtocolTypeID = Convert.ToInt32(txtprotocoltypeid.Text.Trim());
            _tmpProtocolType.TypeID = Convert.ToInt32(cbxtypename.SelectedValue.ToString());
            tmpProtocolTypeList.Add(_tmpProtocolType);
            if (tmpProtocolType == null)
            {
                tmpProtocolTypeCommand._AddData(tmpProtocolTypeList);
                result = MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK);
            }
            else
            {
                tmpProtocolTypeCommand._ReviseData(tmpProtocolTypeList);
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
