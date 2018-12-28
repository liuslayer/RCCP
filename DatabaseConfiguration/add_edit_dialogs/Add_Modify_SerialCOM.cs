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
    public partial class Add_Modify_SerialCOM : Form
    {
        public DialogResult result = DialogResult.Cancel;
        SerialCOMList tmpSerialCOM;
        List<SerialCOMList> tmpListSerialCOM;
        //SerialCOMList _tmpSerialCOMList = new SerialCOMList();
        //SerialCOM_Command tmpSerialCOM_Command = new SerialCOM_Command();
        public Add_Modify_SerialCOM(SerialCOMList tmpData)
        {
            InitializeComponent();
            if (tmpData == null)
            {
                tmpSerialCOM = tmpData;
                TypeNameDataBinding();
            }
            else
            {
                tmpSerialCOM = tmpData;
                TypeNameDataBinding();
                SerialCOMData(tmpSerialCOM);
            }
        }
        private void TypeNameDataBinding()
        {
            DataTable TableComNo = new DataTable();
            TableComNo.Columns.Add("Text", Type.GetType("System.String"));
            TableComNo.Columns.Add("Value", Type.GetType("System.String"));
            for (int i = 1; i < 512; i++)
            {
                TableComNo.Rows.Add("COM" + i.ToString(), "COM" + i.ToString());
            }
            comboBoxCOMNo.DataSource = TableComNo;
            comboBoxCOMNo.DisplayMember = "Text";   // Text，即显式的文本
            comboBoxCOMNo.ValueMember = "Value";    // Value，即实际的值
            comboBoxCOMNo.SelectedIndex = 0;        //  设置为默认选中第一个

            comboBoxBaud.SelectedIndex = 0;

            DataTable TableDataBit = new DataTable();//45678
            TableDataBit.Columns.Add("Text", Type.GetType("System.String"));
            TableDataBit.Columns.Add("Value", Type.GetType("System.String"));
            TableDataBit.Rows.Add("5", 5);
            TableDataBit.Rows.Add("6", 6);
            TableDataBit.Rows.Add("7", 7);
            TableDataBit.Rows.Add("8", 8);
            comboBoxDataBit.DataSource = TableDataBit;
            comboBoxDataBit.DisplayMember = "Text";   // Text，即显式的文本
            comboBoxDataBit.ValueMember = "Value";    // Value，即实际的值
            comboBoxDataBit.SelectedIndex = 3;

            DataTable TableCheckBit = new DataTable();
            TableCheckBit.Columns.Add("Text", Type.GetType("System.String"));
            TableCheckBit.Columns.Add("Value", Type.GetType("System.String"));
            TableCheckBit.Rows.Add(ComCheckBit.NoneParity,(int)ComCheckBit.NoneParity);
            TableCheckBit.Rows.Add(ComCheckBit.OddParity, (int)ComCheckBit.OddParity);
            TableCheckBit.Rows.Add(ComCheckBit.EvenParity, (int)ComCheckBit.EvenParity);
            TableCheckBit.Rows.Add(ComCheckBit.MarkParity, (int)ComCheckBit.MarkParity);
            TableCheckBit.Rows.Add(ComCheckBit.SpaceParity, (int)ComCheckBit.SpaceParity); 
            comboBoxCheckBit.DataSource = TableCheckBit;
            comboBoxCheckBit.DisplayMember = "Text";   // Text，即显式的文本
            comboBoxCheckBit.ValueMember = "Value";    // Value，即实际的值
            comboBoxCheckBit.SelectedIndex = 0;


            DataTable TableStopBit = new DataTable();
            TableStopBit.Columns.Add("Text", Type.GetType("System.String"));
            TableStopBit.Columns.Add("Value", Type.GetType("System.String"));
            TableStopBit.Rows.Add(ComStopBit.None, (int)ComStopBit.None);
            TableStopBit.Rows.Add(ComStopBit.One, (int)ComStopBit.One);
            TableStopBit.Rows.Add(ComStopBit.Two, (int)ComStopBit.Two);
            TableStopBit.Rows.Add(ComStopBit.OnePointFive, (int)ComStopBit.OnePointFive);
            comboBoxStopBit.DataSource = TableStopBit;
            comboBoxStopBit.DisplayMember = "Text";   // Text，即显式的文本
            comboBoxStopBit.ValueMember = "Value";    // Value，即实际的值
            comboBoxStopBit.SelectedIndex = 0;

        }

        private void SerialCOMData(SerialCOMList _tmpData)
        {
            txtname.Text = _tmpData.Name;
            comboBoxCOMNo.SelectedValue = _tmpData.COMNo;
            comboBoxBaud.Text = _tmpData.Baud.ToString();
            comboBoxCheckBit.SelectedValue = _tmpData.CheckBit;
            comboBoxDataBit.SelectedValue = _tmpData.DataBit;
            comboBoxStopBit.SelectedValue = _tmpData.StopBit;
            txtdescription.Text = _tmpData.Description;
        }
        private void btnsure_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Trim() == "") { MessageBox.Show("请填写串口名称！"); return; }

            SerialCOMList _SerialCOMList = new SerialCOMList();
            List<SerialCOMList> tmpSerialCOMList = new List<SerialCOMList>();
            SerialCOM_Command tmpSerialCOM_Command = new SerialCOM_Command();

            if(tmpSerialCOM !=null)
            {
                _SerialCOMList.DeviceID = tmpSerialCOM.DeviceID;
            }

            _SerialCOMList.Name = txtname.Text.Trim();
            _SerialCOMList.COMNo = comboBoxCOMNo.SelectedValue.ToString();
            _SerialCOMList.Baud = Convert.ToInt32(comboBoxBaud.Text);
            _SerialCOMList.CheckBit = Convert.ToInt32(comboBoxCheckBit.SelectedValue);
            _SerialCOMList.DataBit = Convert.ToInt32(comboBoxDataBit.SelectedValue);
            _SerialCOMList.StopBit = Convert.ToInt32(comboBoxStopBit.SelectedValue);
            _SerialCOMList.Description = txtdescription.Text.Trim();

            tmpSerialCOMList.Add(_SerialCOMList);
            if (tmpSerialCOM == null)
            {
                tmpSerialCOM_Command._AddData(tmpSerialCOMList);
                result = MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK);
            }
            else
            {
                tmpSerialCOM_Command._ReviseData(tmpSerialCOMList);
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
