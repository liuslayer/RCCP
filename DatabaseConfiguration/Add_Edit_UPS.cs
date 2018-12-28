using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAssemblyClass;
using BaseDataClass;
using DataInterfaceModule;
using System.Net;
using BSCong;
using System.Diagnostics;
namespace BSCong
{
    public partial class Add_Edit_UPS : Form
    {
        public Add_Edit_UPS(string Operate_Type)
        {
            InitializeComponent();
            Set_ControlIndex.Set_TabIndex(this);
            this.Operate_Type = Operate_Type;
            this.Text = Operate_Type;
            //this.MainObj = MainObj;
            txtcategory.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            //获取坐标信息
            ((Form1)Form.FromHandle((Process.GetCurrentProcess().MainWindowHandle))).ViewchangeEvent_Example += Get_LLA;
        }
        public object Obj = null;
        string Operate_Type = "";
        DataTable CommunicationInternettable;//平台通讯
        //Main MainObj = null;
        public assembly_UPS UPS_Obj = null;
        DeviceTypeList devicetype = null;
        deviceInfo deviceInfo_Obj = new deviceInfo();
        public Point location = new Point(700, 300);//设置加载位置
        string error = "";
        private void Add_Edit_UPS_Load(object sender, EventArgs e)
        {
            this.Location = location;
            //this.Location = new Point(MainObj.Location.X + MainObj.Width - 550 - this.Width, MainObj.Location.Y + Convert.ToInt32((MainObj.Height - this.Height) / 2));
            if (Operate_Type.Contains("添加"))
            {
                UPS_Obj = new assembly_UPS();
                //UPS_Obj.DeviceTypeBase = Obj as DeviceTypeList;
                //UPS_Obj.UPSBase.TypeID = UPS_Obj.DeviceTypeBase.TypeID;
            }
            else
            {
                //UPS_Obj = Obj as assembly_UPS;
                txtname.Text = UPS_Obj.UPSBase.Name;
                txtlon.Text = UPS_Obj.UPSBase.Lon;
                txtlat.Text = UPS_Obj.UPSBase.Lat;
                txtalt.Text = UPS_Obj.UPSBase.Alt;
                txtusername.Text = UPS_Obj.UPSBase.UserName;
                txtpassword.Text = UPS_Obj.UPSBase.Password;
                txtip.Text = UPS_Obj.UPSBase.Ip;
                txtport.Text = UPS_Obj.UPSBase.Port;
                txtdescription.Text = UPS_Obj.UPSBase.Description;
            }
            //公用代码
            //txtcategory.Text = UPS_Obj.DeviceTypeBase.InstanceTable;
            TypeNameDataBinding();
            //串口
            DataTable SerialCOMtable = new DataTable();
            DataColumn SerialCOM_Column_name = new DataColumn("name", typeof(string));
            DataColumn SerialCOM_Column_value = new DataColumn("value", typeof(string));
            SerialCOMtable.Columns.Add(SerialCOM_Column_name);
            SerialCOMtable.Columns.Add(SerialCOM_Column_value);
            DataRow norow = SerialCOMtable.NewRow();
            norow[0] = "(无)";
            norow[1] = "-1";
            SerialCOMtable.Rows.Add(norow);

            //平台通讯
            CommunicationInternettable = new DataTable();
            DataColumn CommunicationInternet_Column_name = new DataColumn("name", typeof(string));
            DataColumn CommunicationInternet_Column_value = new DataColumn("value", typeof(string));
            CommunicationInternettable.Columns.Add(CommunicationInternet_Column_name);
            CommunicationInternettable.Columns.Add(CommunicationInternet_Column_value);
            norow = CommunicationInternettable.NewRow();
            norow[0] = "无";
            norow[1] = "";
            CommunicationInternettable.Rows.Add(norow);

            foreach (string SerialCOMID in DictionaryDBClass.SerialCOMListDictionary.Keys)
            {
                DataRow row = SerialCOMtable.NewRow();
                row[0] = DictionaryDBClass.SerialCOMListDictionary[SerialCOMID].SerialCOMBase.Name;
                row[1] = SerialCOMID;
                SerialCOMtable.Rows.Add(row);
            }
            //平台通讯列表
            foreach (string CommunicationInternetID in DictionaryDBClass.communicationInternetDictionary.Keys)
            {
                DataRow row = CommunicationInternettable.NewRow();
                row[0] = DictionaryDBClass.communicationInternetDictionary[CommunicationInternetID].CommunicationInternet_base.Name;
                row[1] = CommunicationInternetID;
                CommunicationInternettable.Rows.Add(row);
            }
            comboBoxCommunicationInternet.DataSource = CommunicationInternettable;
            comboBoxCommunicationInternet.DisplayMember = "name";
            comboBoxCommunicationInternet.ValueMember = "value";
            //串口列表
            foreach (string SerialCOMID in DictionaryDBClass.SerialCOMListDictionary.Keys)
            {
                DataRow row = SerialCOMtable.NewRow();
                row[0] = DictionaryDBClass.SerialCOMListDictionary[SerialCOMID].SerialCOMBase.Name;
                row[1] = SerialCOMID;
                SerialCOMtable.Rows.Add(row);
            }
            comboBoxSerialCOM.DataSource = SerialCOMtable;
            comboBoxSerialCOM.DisplayMember = "name";
            comboBoxSerialCOM.ValueMember = "value";
            if (Operate_Type.Contains("添加"))
            {
                comboBoxSerialCOM.Text = "(无)";
            }
            else
            {
                if (UPS_Obj.UPSBase.COM == "")
                {
                    comboBoxSerialCOM.Text = "(无)";
                }
                comboBoxSerialCOM.Text = UPS_Obj.SerialCOM_assembly.SerialCOMBase.Name;
                if (UPS_Obj.UPSBase.CommunicationInternetID != "")
                {
                    comboBoxCommunicationInternet.SelectedValue = UPS_Obj.UPSBase.CommunicationInternetID;
                }
            }
        }
        private void btnsure_Click(object sender, EventArgs e)
        {
            double lon = 0.0, lat = 0.0, alt = 0.0;
            if (txtlon.Text.Trim() == "")
            {
                MessageBox.Show("请填写经度");
                return;
            }
            else
            {
                if (!double.TryParse(txtlon.Text.Trim(), out lon))
                {
                    MessageBox.Show("经度为数值类型");
                    return;
                }
            }
            if (txtlat.Text.Trim() == "")
            {
                MessageBox.Show("请填写纬度");
                return;
            }
            else
            {
                if (!double.TryParse(txtlat.Text.Trim(), out lat))
                {
                    MessageBox.Show("纬度为数值类型");
                    return;
                }
            }
            if (txtalt.Text.Trim() == "")
            {
                MessageBox.Show("请填写海拔");
                return;
            }
            else
            {
                if (!double.TryParse(txtalt.Text.Trim(), out alt))
                {
                    MessageBox.Show("海拔为数值类型");
                    return;
                }
            }
            if (comboBoxSerialCOM.Text.Trim() == "" || comboBoxSerialCOM.Text.Trim() == "(无)")
            {
                UPS_Obj.UPSBase.COM = "";
            }
            else
            {
                if (DictionaryDBClass.SerialCOMListDictionary.ContainsKey(comboBoxSerialCOM.SelectedValue.ToString()))
                {
                    UPS_Obj.SerialCOM_assembly = DictionaryDBClass.SerialCOMListDictionary[comboBoxSerialCOM.SelectedValue.ToString()];
                    UPS_Obj.UPSBase.COM = UPS_Obj.SerialCOM_assembly.SerialCOMBase.DeviceID;
                }
                else
                {
                    MessageBox.Show("选择的串口不存在");
                    return;
                }
            }
            if (txtname.Text.Trim() == "")
            {
                MessageBox.Show("请填写名称");
                return;
            }
            if (txtname.Text.Trim() != "")
            {

                if (Operate_Type.Contains("添加"))
                {
                    foreach (assembly_UPS name in DictionaryDBClass.UPSDictionary.Values)
                    {
                        if (txtname.Text.Trim() == name.UPSBase.Name)
                        {
                            MessageBox.Show("此UPS名称已存在，请修改后重试！");
                            return;
                        }
                    }
                }
                else
                {
                    foreach (assembly_UPS name in DictionaryDBClass.UPSDictionary.Values)
                    {
                        if (txtname.Text.Trim() == name.UPSBase.Name && txtname.Text.Trim() != UPS_Obj.UPSBase.Name)
                        {
                            MessageBox.Show("此UPS名称已存在，请修改后重试！");
                            return;
                        }
                    }
                }
            }
            if (txtusername.Text.Trim() == "")
            {
                MessageBox.Show("请填写用户名");
                return;
            }
            string[] ipstring = txtip.Text.Trim().Split('.');
            if (ipstring.Length == 0)
            {
                MessageBox.Show("请填写IP");
                return;
            }
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
                else
                {
                    MessageBox.Show("IP格式不合法");
                    return;
                }
            }

            if (txtport.Text.Trim() == "")
            {
                MessageBox.Show("请填写端口");
                return;
            }
            else
            {
                int port = 0;
                if (!int.TryParse(txtport.Text.Trim(), out port))
                {
                    MessageBox.Show("端口号要为数字");
                    return;
                }
            }

            if (comboBoxCommunicationInternet.SelectedValue.ToString() != "")
            {
                UPS_Obj.CommunicationAssembly = DictionaryDBClass.communicationInternetDictionary[comboBoxCommunicationInternet.SelectedValue.ToString()];
                UPS_Obj.UPSBase.CommunicationInternetID = comboBoxCommunicationInternet.SelectedValue.ToString();
            }
            else
            {
                UPS_Obj.CommunicationAssembly = new assembly_communicationInternet();
                UPS_Obj.UPSBase.CommunicationInternetID = "";
            }
            bool operateresult = false;
            UPS_Obj.UPSBase.Name = txtname.Text.Trim();
            UPS_Obj.UPSBase.UserName = txtusername.Text.Trim();
            UPS_Obj.UPSBase.Password = txtpassword.Text.Trim();
            UPS_Obj.UPSBase.Ip = txtip.Text.Trim();
            UPS_Obj.UPSBase.Port = txtport.Text.Trim();
            UPS_Obj.UPSBase.Lon = txtlon.Text.Trim();
            UPS_Obj.UPSBase.Lat = txtlat.Text.Trim();
            UPS_Obj.UPSBase.Alt = txtalt.Text.Trim();
            UPS_Obj.UPSBase.Description = txtdescription.Text.Trim();
            string opresult = "";
            try
            {
                if (Operate_Type.Contains("添加"))
                {
                    object[] obj_list = deviceInfo_Obj.GetAllObjects(BaseDataClassNames.UPSList);
                    int id = 18001;
                    if (obj_list != null)
                    {
                        int[] id_list = new int[obj_list.Length];
                        for (int i = 0; i < obj_list.Length; i++)
                        {
                            id_list[i] = Convert.ToInt32((obj_list[i] as UPSList).DeviceID);
                        }
                        CountIDClass CountIDClass_Obj = new CountIDClass();
                        id = CountIDClass_Obj.CountID(id_list, 18001, 19000);
                    }
                    if (id == -1)
                    {
                        MessageBox.Show("DeviceID字段已用完");
                    }
                    else
                    {
                        UPS_Obj.UPSBase.DeviceID = id.ToString();
                        operateresult = deviceInfo_Obj.AddBaseList(UPS_Obj.UPSBase, ref error);
                        DictionaryDBClass.UPSDictionary.Add(UPS_Obj.UPSBase.DeviceID, UPS_Obj);
                        opresult = CompletenessCheck.CheckUPSComplete(UPS_Obj);
                        DictionaryDBClass.UPSDictionary_State.Add(UPS_Obj.UPSBase.DeviceID, opresult);

                    }
                }
                else
                {
                    operateresult = deviceInfo_Obj.UpdateBaselist(UPS_Obj.UPSBase, ref error);
                    DictionaryDBClass.UPSDictionary[UPS_Obj.UPSBase.DeviceID] = UPS_Obj;
                    opresult = CompletenessCheck.CheckUPSComplete(UPS_Obj);
                    DictionaryDBClass.UPSDictionary_State[UPS_Obj.UPSBase.DeviceID] = opresult;

                }
                string Useroperation = txtname.Text.Trim();

                if (Operate_Type.Contains("添加"))
                {
                    Useroperation = "添加元素实例-" + Useroperation;
                    MessageBox.Show("添加成功");
                    UpdateTree.AddUPS(UPS_Obj, opresult);
                }
                else
                {
                    Useroperation = "修改元素实例-" + Useroperation;
                    MessageBox.Show("修改成功");
                    UpdateTree.EditUPS(UPS_Obj, opresult);
                }
                this.Close();
            }
            catch (System.Exception ex)
            {
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TypeNameDataBinding()
        {
            DataTable Typenametable = new DataTable();
            DataColumn Typename_Column_name = new DataColumn("name", typeof(string));
            DataColumn Typename_Column_value = new DataColumn("value", typeof(string));
            Typenametable.Columns.Add(Typename_Column_name);
            Typenametable.Columns.Add(Typename_Column_value);

            //类型列表
            foreach (string TypeId in DictionaryDBClass.DeviceTypeListDictionary.Keys)
            {
                if (DictionaryDBClass.DeviceTypeListDictionary[TypeId].InstanceTable == "UPS")
                {
                    DataRow rows = Typenametable.NewRow();
                    rows[0] = DictionaryDBClass.DeviceTypeListDictionary[TypeId].Name;
                    rows[1] = TypeId;
                    Typenametable.Rows.Add(rows);
                }
            }
            cbxtypename.DataSource = Typenametable;
            cbxtypename.DisplayMember = "name";
            cbxtypename.ValueMember = "value";
            if (Operate_Type.Contains("添加"))
            {
                if (devicetype == null)
                {
                    cbxtypename.SelectedValue = Typenametable.Rows[0]["value"].ToString();
                    devicetype = DictionaryDBClass.DeviceTypeListDictionary[Typenametable.Rows[0]["value"].ToString()];
                }
                else
                {
                    cbxtypename.SelectedValue = devicetype.TypeID;
                }
                UPS_Obj.DeviceTypeBase = devicetype;
                UPS_Obj.UPSBase.TypeID = devicetype.TypeID;

            }
            if (Operate_Type.Contains("修改"))
            {
                cbxtypename.SelectedValue = UPS_Obj.DeviceTypeBase.TypeID;
            }
            txtcategory.Text = UPS_Obj.DeviceTypeBase.InstanceTable;
        }

        private void btnComadd_Click(object sender, EventArgs e)
        {
            DeviceTypeList DeviceTypeList_Obj = null;
            foreach (DeviceTypeList DTL in DictionaryDBClass.DeviceTypeListDictionary.Values)
            {
                if (DTL.InstanceTable == "串口")
                {
                    DeviceTypeList_Obj = DTL;
                }
            }
            Add_Edit_SerialCOM addSeria = new Add_Edit_SerialCOM("添加串口实例");
            //addSeria.Obj = DeviceTypeList_Obj;
            addSeria.ShowDialog(this);
            if (addSeria.DialogResult == DialogResult.OK)
            {
                DataTable SerialCOMtable = comboBoxSerialCOM.DataSource as DataTable;
                DataRow row = SerialCOMtable.NewRow();
                row[0] = addSeria.SerialCOM_Obj.SerialCOMBase.Name;
                row[1] = addSeria.SerialCOM_Obj.SerialCOMBase.DeviceID;
                SerialCOMtable.Rows.Add(row);
                comboBoxSerialCOM.SelectedIndex = comboBoxSerialCOM.Items.Count - 1;
            }
        }

        private void Add_Edit_UPS_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnsure_Click(sender, e);
            }
        }
        public void Get_LLA(double lon, double lat, double alt)
        {
            txtlon.Text = lon.ToString();
            txtlat.Text = lat.ToString();
            txtalt.Text = alt.ToString();
        }
        private void Add_Edit_UPS_FormClosing(object sender, FormClosingEventArgs e)
        {
            //获取坐标信息
            ((Form1)Form.FromHandle((Process.GetCurrentProcess().MainWindowHandle))).ViewchangeEvent_Example -= Get_LLA;
        }

        private void btn_addCommunication_Click(object sender, EventArgs e)
        {
            Add_Edit_CommunicationInternet communication_form = new Add_Edit_CommunicationInternet("添加");
            communication_form.ShowDialog(this);
            if (communication_form.DialogResult == DialogResult.OK)
            {
                DataRow row = CommunicationInternettable.NewRow();
                row[0] = communication_form.communicationInternet_Obj.CommunicationInternet_base.Name;
                row[1] = communication_form.communicationInternet_Obj.CommunicationInternet_base.DeviceID;
                CommunicationInternettable.Rows.Add(row);
                comboBoxCommunicationInternet.SelectedValue = communication_form.communicationInternet_Obj.CommunicationInternet_base.DeviceID;
            }
        }
    }
}
