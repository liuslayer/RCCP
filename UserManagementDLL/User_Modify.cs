using Client.Entities.UserEntity;
using DeviceBaseData;
using Encryption;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SystemSetupDLL.UserManagement
{
    public partial class User_Modify : Form
    {
        #region 窗体特效
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        public const int AW_CENTER = 0x00000010;//
        public const int AW_HIDE = 0x00010000;//
        #endregion
        UserList userList;
        public User_Modify()
        {
            InitializeComponent();
            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果
        }
        public User_Modify(UserList userList)
        {
            InitializeComponent();
            this.userList = userList;
            //用户名
            textBox1.Text = userList.Username;
            textBox6.Text = userList.Description;
            //读取权限表
            string message = "GetUserAuthorityList\r\n";
            string responseData = GetObject(message, 1024 * 100);
            List<UserPermissionList> userPermission = JsonConvert.DeserializeObject<List<UserPermissionList>>(responseData);
            comboBox1.DataSource = userPermission;
            comboBox1.DisplayMember = "UserPermissionName";
            comboBox1.ValueMember = "UserPermissionID";

            //读取角色表
            //message = "GetAllUserRoles\r\n";
            //responseData = GetObject(message, 1024 * 100);
            //List<UserRole> userRole = JsonConvert.DeserializeObject<List<UserRole>>(responseData);
            //comboBox2.DataSource = userRole;
            //comboBox2.DisplayMember = "RoleName";
            //comboBox2.ValueMember = "RoleID";
        }
        //修改
        private void button15_Click(object sender, EventArgs e)
        {
              //判断旧密码是否正确
            if (Encrypt.EncryptPassword(textBox2.Text)!=userList.UserPassword)
            {
                MessageBox.Show("旧密码错误，请重新输入！");
                return;
            }
            //判断新密码是否一致
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("密码不一致！请重新输入");
                textBox3.Text = "";
                textBox4.Text = "";
                return;
            }
            //记录修改后数据
            userList.UserPassword = Encrypt.EncryptPassword(textBox3.Text);
            userList.UserPermissionID =Convert.ToInt32(comboBox1.SelectedValue);
            userList.UserRoleID = Convert.ToInt32(comboBox2.SelectedValue);
            userList.Description = textBox6.Text;
            string userData = JsonConvert.SerializeObject(userList);
            string message = "UpdateUser/" + userData + "\r\n";
            byte[] data =Encoding.UTF8.GetBytes(message);
            if(CommunicationClass.stream2==null)
            {
                MessageBox.Show("数据服务连接失败！");
                return;
            }
            CommunicationClass.stream2.Write(data, 0, data.Length);
            string responseData = string.Empty;
            data = new byte[256];

            int bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
            responseData = Encoding.UTF8.GetString(data, 0, bytes).Replace("\r\n", "");
            switch (responseData)
            {
                case "True":
                    MessageBox.Show("修改成功！");
                    break;
                case "False":
                    MessageBox.Show("修改失败！");
                    break;
            }
        }
        public string GetObject(string message, int length)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            if (CommunicationClass.stream2 == null)
            {
                MessageBox.Show("服务器连接失败！");
                return null;
            }
            CommunicationClass.stream2.Write(data, 0, data.Length);

            string responseData = string.Empty;
            data = new byte[length];

            int bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
            responseData = Encoding.UTF8.GetString(data, 0, bytes).Replace("\r\n", "");

            return responseData;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        int x, y;

        private void User_Modify_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void User_Modify_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
        }
    }
}
