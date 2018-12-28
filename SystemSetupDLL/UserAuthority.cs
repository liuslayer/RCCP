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
            //连接服务器获取权限列表
            string message = "GetUserAuthorityList\r\n";
            byte[] data = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(data, 0, data.Length);
            
            Thread th = new Thread(new ThreadStart(ReceiveMessage));
            th.IsBackground = true;
            th.Start();
        }

        private void ReceiveMessage()
        {
            byte[] data = new byte[1024 * 100];
            string responseData = string.Empty;
            long bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
            responseData = Encoding.UTF8.GetString(data,0,(int)bytes);
            List<UserPermissionList> userPermission = JsonConvert.DeserializeObject<List<UserPermissionList>>(responseData);
            for (int i = 0; i < userPermission.Count; i++)
            {
                listBox1.Items.Add(userPermission[i].UserPermissionName);
            }

        }
        //删除权限
        private void button2_Click(object sender, EventArgs e)
        {

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

            //连接服务器获取权限列表
            string message = "AddUserAuthority/"+ JsonConvert.SerializeObject(newPermission)+"\r\n";
            byte[] data = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(data, 0, data.Length);
            data = new byte[100];
            string responseData = string.Empty;
            long bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
            responseData = Encoding.UTF8.GetString(data, 0, (int)bytes);

        }
    }
}
