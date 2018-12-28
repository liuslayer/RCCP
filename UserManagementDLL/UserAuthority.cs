using Client.Entities.UserEntity;
using DeviceBaseData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemSetupDLL
{
    public partial class UserAuthority : Form
    {
        public UserAuthority()
        {
            InitializeComponent();
        }

        private void UserAuthority_Load(object sender, EventArgs e)
        {
            GetInfo();
        }
        private void GetInfo()
        {
            //连接服务器获取权限列表
            string message = "GetUserAuthorityList\r\n";
            byte[] data = Encoding.UTF8.GetBytes(message);
            if (CommunicationClass.stream2 == null)
            {
                if (!CommunicationClass.Init())
                {
                    MessageBox.Show("服务器连接失败！");
                    return;
                }
            }
            CommunicationClass.stream2.Write(data, 0, data.Length);

            Thread th = new Thread(new ThreadStart(ReceiveInfo));
            th.IsBackground = true;
            th.Start();

        }

        private void ReceiveInfo()
        {
            byte[] data = new byte[1024 * 100];
            string responseData = string.Empty;
            long bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
            responseData = Encoding.UTF8.GetString(data,0,(int)bytes);
            List<UserPermissionList> userPermission = JsonConvert.DeserializeObject<List<UserPermissionList>>(responseData);
            listBox1.DataSource = userPermission;
            Action action = delegate () { listBox1.DisplayMember = "UserPermissionName"; };
            Invoke(action);
            action = delegate () { listBox1.ValueMember = "UserPermissionID"; };
            Invoke(action);
            action = delegate () { Refresh(); };
            Invoke(action);
        }
        //删除权限
        private void button2_Click(object sender, EventArgs e)
        {  //连接服务器获取权限列表
            string DelGuid = listBox1.SelectedValue.ToString();
            string message = "DelUserAuthority/"+DelGuid+"\r\n";
            byte[] data = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(data, 0, data.Length);
            data = new byte[100];
            string responseData = string.Empty;
            long bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
            responseData = Encoding.UTF8.GetString(data, 0, (int)bytes).Replace("\r\n", "");
            switch (responseData)
            {
                case "True":
                    MessageBox.Show("删除成功！");
                    listBox1.DataSource = null;
                    GetInfo();
                    break;
                case "False":
                    MessageBox.Show("删除失败！");
                    break;
            }

        }
        //保存权限
        private void button3_Click(object sender, EventArgs e)
        {
            UserPermissionList newPermission = new UserPermissionList();
            newPermission.UserPermissionName = textBox1.Text;
            if(checkBox1.Checked)
            {
                newPermission.BEWSSAuthority = true;
            }
            else
            {
                newPermission.BEWSSAuthority = false;
            }
            if (checkBox2.Checked)
            {
                newPermission.RTSMSAuthority = true;
            }
            else
            {
                newPermission.RTSMSAuthority = false;
            }
            if (checkBox3.Checked)
            {
                newPermission.OMManagementAuthority = true;
            }
            else
            {
                newPermission.OMManagementAuthority = false;
            }
            if (checkBox4.Checked)
            {
                newPermission.CommandDispatchAuthority = true;
            }
            else
            {
                newPermission.CommandDispatchAuthority = false;
            }
            if (checkBox5.Checked)
            {
                newPermission.ManagementOfMessagesAuthority = true;
            }
            else
            {
                newPermission.ManagementOfMessagesAuthority = false;
            }
            if (checkBox6.Checked)
            {
                newPermission.InformationManagementAuthority = true;
            }
            else
            {
                newPermission.InformationManagementAuthority = false;
            }

            //连接服务器获取权限列表
            string message = "AddUserAuthority/"+ JsonConvert.SerializeObject(newPermission)+"\r\n";
            byte[] data = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(data, 0, data.Length);
            data = new byte[100];
            string responseData = string.Empty;
            long bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
            responseData = Encoding.UTF8.GetString(data, 0, (int)bytes).Replace("\r\n", "");
            switch(responseData)
            {
                case "True":
                    MessageBox.Show("添加成功！");
                    listBox1.DataSource = null;
                    GetInfo();
                    break;
                case "False":
                    MessageBox.Show("添加失败！");
                    break;
            }
        }
    }
}
