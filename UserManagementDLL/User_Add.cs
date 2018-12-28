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
    public partial class User_Add : Form
    {
        #region 窗体特效
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        public const int AW_CENTER = 0x00000010;//
        public const int AW_HIDE = 0x00010000;//
        #endregion
        public User_Add()
        {
            InitializeComponent();
            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果

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

        private void button15_Click(object sender, EventArgs e)
        {
            //判断用户名是否已存在
            string message = "SearchUsername/" + textBox1.Text + "\r\n";
            string responseData =GetObject(message,256);
            if (responseData=="True")
            {
                reminder1.Visible = true;
                return;
            }
            //判断密码是否一致
            if (textBox2.Text!=textBox3.Text)
            {
                MessageBox.Show("密码不一致！请重新输入");
                textBox2.Text = "";
                textBox3.Text = "";
                return;
            }
            string password = Encrypt.EncryptPassword(textBox2.Text);
            UserList user = new UserList();
            user.Username = textBox1.Text;
            user.UserPassword = password;
            user.UserPermissionID = Convert.ToInt32(comboBox1.SelectedValue);
            user.UserRoleID = Convert.ToInt32(comboBox2.SelectedValue);
            user.Description = textBox6.Text;
            string UserData = JsonConvert.SerializeObject(user);
            message = "AddUser/"+UserData+"\r\n";
            responseData = GetObject(message,256);
            switch(responseData)
            {
                case "True":
                    MessageBox.Show("添加成功！");
                    Close();
                    break;
                case "False":
                    MessageBox.Show("添加失败！");
                    break;
            }
        }

        public string GetObject(string message,int length)
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

        private void button1_Click(object sender, EventArgs e)
        {
            AnimateWindow(Handle, 300, AW_HIDE + AW_CENTER);
            Close();
        }
        int x, y;

        private void User_Add_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void User_Add_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
        }
    }
}
