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
    public partial class Add_Modify_Camera : Form
    {
        public DialogResult result = DialogResult.Cancel;

        CameraList tmpCamera= null;

        List<DeviceTypeList> tmpListDeviceType;
        DeviceTypeList _tmpDeviceTypeList = new DeviceTypeList();
        DeviceType_Command tmpDeviceTypeCommand = new DeviceType_Command();

        List<StreamMediaList> tmpListStreamMedia;
        StreamMediaList _tmpStreamMediaList = new StreamMediaList();
        StreamMedia_Command tmpStreamMediaCommand = new StreamMedia_Command();

        List<TurnTableList> tmpListTurnTable;
        TurnTableList _tmpTurnTableList = new TurnTableList();
        TurnTable_Command tmpTurnTable_Command = new TurnTable_Command();

        public Add_Modify_Camera(CameraList tmpData)
        {
            InitializeComponent();
            if (tmpData == null)
            {
                tmpCamera = tmpData;
                TypeNameDataBinding();
            }
            else
            {
                tmpCamera = tmpData;
                TypeNameDataBinding();
                CameraData(tmpCamera);
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
                    if (tmpListDeviceType[i].TypeID == (int)DeviceParamType.CameraDevice)
                    {
                        TableDeviceType.Rows.Add(tmpListDeviceType[i].TypeName, tmpListDeviceType[i].TypeID);
                    }
                }
                cbxtypename.DataSource = TableDeviceType;
                cbxtypename.DisplayMember = "Text";   // Text，即显式的文本
                cbxtypename.ValueMember = "Value";    // Value，即实际的值
                cbxtypename.SelectedIndex = 0;        //  设置为默认选中第一个
            }

            tmpListStreamMedia = tmpStreamMediaCommand._QueryData();
            DataTable TableStreamMedia = new DataTable();
            TableStreamMedia.Columns.Add("Text", Type.GetType("System.String"));
            TableStreamMedia.Columns.Add("Value", Type.GetType("System.String"));
            if (tmpListStreamMedia.Count > 0)
            {
                for (int i = 0; i < tmpListStreamMedia.Count; i++)
                {
                    TableStreamMedia.Rows.Add(tmpListStreamMedia[i].Name, tmpListStreamMedia[i].DeviceID);
                }
                comboBoxstreammedia.DataSource = TableStreamMedia;
                comboBoxstreammedia.DisplayMember = "Text";   // Text，即显式的文本
                comboBoxstreammedia.ValueMember = "Value";    // Value，即实际的值
                comboBoxstreammedia.SelectedIndex = 0;        //  设置为默认选中第一个
            }

            tmpListTurnTable = tmpTurnTable_Command._QueryData();
            DataTable TableTurnTable = new DataTable();
            TableTurnTable.Columns.Add("Text", Type.GetType("System.String"));
            TableTurnTable.Columns.Add("Value", Type.GetType("System.String"));
            if (tmpListTurnTable.Count > 0)
            {
                for (int i = 0; i < tmpListTurnTable.Count; i++)
                {
                    TableTurnTable.Rows.Add(tmpListTurnTable[i].Name, tmpListTurnTable[i].DeviceID);
                }
                cbx_Turntable.DataSource = TableTurnTable;
                cbx_Turntable.DisplayMember = "Text";   // Text，即显式的文本
                cbx_Turntable.ValueMember = "Value";    // Value，即实际的值
                cbx_Turntable.SelectedIndex = 0;        //  设置为默认选中第一个
            }

            DataTable TableVideotype = new DataTable();
            TableVideotype.Columns.Add("Text", Type.GetType("System.String"));
            TableVideotype.Columns.Add("Value", Type.GetType("System.String"));
            TableVideotype.Rows.Add("白光", (int)VideoCommandType.VideoCCD);
            TableVideotype.Rows.Add("红外", (int)VideoCommandType.VideoIR);
            TableVideotype.Rows.Add("球机", (int)VideoCommandType.VideoPTZ);
            comboBoxvideotype.DataSource = TableVideotype;
            comboBoxvideotype.DisplayMember = "Text";   // Text，即显式的文本
            comboBoxvideotype.ValueMember = "Value";    // Value，即实际的值
            comboBoxvideotype.SelectedIndex = 0;        //  设置为默认选中第一个
        }

        private void CameraData(CameraList _tmpData)
        {
            txtname.Text = _tmpData.VideoName;
            comboBoxstreammedia.SelectedValue = _tmpData.StreamMedia_DeviceID;
            txtchanle.Text = _tmpData.VideoChannel.ToString();
            comboBoxvideotype.SelectedValue = Convert.ToInt32(_tmpData.VideoType);
            txtdepthmax.Text = _tmpData.DepthMAX.ToString();
            txtfocusmax.Text = _tmpData.FocusMAX.ToString();
            txthorizontalmax.Text = _tmpData.HorizontalMAX.ToString();
            txtverticalmax.Text = _tmpData.VerticalMAX.ToString();
            txtdistancemax.Text = _tmpData.VisualDistanceMAX.ToString();
            cbx_Turntable.SelectedValue = _tmpData.Turntable_PTZ_DeviceID;
            txtdiscription.Text = _tmpData.Description;
        }

        private void btnsure_Click(object sender, EventArgs e)
        {
            int VideoChannel = 0;
            double DepthMAX = 0;
            double FocusMAX = 0;
            double HorizontalMAX = 0;
            double VerticalMAX = 0;
            double VisualDistanceMAX = 0;

            List<CameraList> tmpCameraList = new List<CameraList>();
            CameraList _CameraList = new CameraList();
            Camera_Command tmpCamera_Command = new Camera_Command();

            if (txtname.Text.Trim() == "") { MessageBox.Show("请填写摄像机名称！"); return; }
            else if (txtname.Text.Trim().ToString().Length > 25) { MessageBox.Show("摄像机名称超过25个字符！"); return; }
            if (txtchanle.Text.Trim() == "")
            { MessageBox.Show("请填写通道号"); return; }
            else
            {
                if (!Int32.TryParse(txtchanle.Text.Trim(), out VideoChannel))
                { MessageBox.Show("通道号为数字格式"); return; }
            }

            if (txtdepthmax.Text.Trim() == "")
            { MessageBox.Show("请填写变倍值"); return; }
            else
            {
                if (!double.TryParse(txtdepthmax.Text.Trim(), out DepthMAX))
                { MessageBox.Show("最大变倍为数字格式"); return; }
            }
            if (txtfocusmax.Text.Trim() == "")
            { MessageBox.Show("请填写聚焦值"); return; }
            else
            {
                if (!double.TryParse(txtfocusmax.Text.Trim(), out FocusMAX))
                { MessageBox.Show("最大聚焦为数字格式"); return; }
            }

            if (txthorizontalmax.Text.Trim() == "")
            { MessageBox.Show("请填写水平视场"); return; }
            else
            {
                if (!double.TryParse(txthorizontalmax.Text.Trim(), out HorizontalMAX))
                { MessageBox.Show("最大水平视场角为数字格式"); return; }
            }

            if(txtverticalmax.Text.Trim() == "")
            { MessageBox.Show("请填写俯仰视场"); return; }
            else
            {
                if (!double.TryParse(txtverticalmax.Text.Trim(), out VerticalMAX))
                { MessageBox.Show("最大俯仰视场角为数字格式"); return; }
            }
            if (txtdistancemax.Text.Trim() == "")
            { MessageBox.Show("请填写最大视距"); return; }
            else
            {
                if (!double.TryParse(txtdistancemax.Text.Trim(), out VisualDistanceMAX))
                { MessageBox.Show("最大视距为数字格式"); return; }
            }
            if(tmpCamera != null)
            {
                _CameraList.DeviceID= tmpCamera.DeviceID;
            }
            
            _CameraList.VideoName = txtname.Text.Trim();
            _CameraList.StreamMedia_DeviceID = new Guid( comboBoxstreammedia.SelectedValue.ToString());
            _CameraList.VideoChannel =Convert.ToInt32( txtchanle.Text.Trim());
            _CameraList.Stream_MainID = null;
            _CameraList.Stream_SubID = null;
            _CameraList.VideoType = comboBoxvideotype.SelectedValue.ToString();
            _CameraList.DepthMAX = Convert.ToDouble(txtdepthmax.Text.Trim());
            _CameraList.FocusMAX = Convert.ToDouble(txtfocusmax.Text.Trim());
            _CameraList.HorizontalMAX = Convert.ToDouble(txthorizontalmax.Text.Trim());
            _CameraList.VerticalMAX = Convert.ToDouble(txtverticalmax.Text.Trim());
            _CameraList.VisualDistanceMAX = Convert.ToDouble(txtdistancemax.Text.Trim());
            _CameraList.TypeID = Convert.ToInt32( cbxtypename.SelectedValue.ToString());
            _CameraList.Turntable_PTZ_DeviceID = new Guid(cbx_Turntable.SelectedValue.ToString());
            _CameraList.Description = txtdiscription.Text.Trim();

            
            tmpCameraList.Add(_CameraList);
            if (tmpCamera == null)
            {
                tmpCamera_Command._AddData(tmpCameraList);
                result = MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK);
            }
            else
            {
                tmpCamera_Command._ReviseData(tmpCameraList);
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
