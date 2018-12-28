using Client.Entities.UserEntity;
using DeviceBaseData;
using Encryption;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Windows.Forms;

namespace SystemSetupDLL.UserManagement
{
    public partial class User_Add : Form
    {
        public User_Add()
        {
            InitializeComponent();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //判断用户名是否已存在

            //判断密码是否一致
            if(textBox2.Text!=textBox3.Text)
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
            //user.UserPermissionID = (Guid)comboBox1.SelectedValue;
            user.Description = textBox6.Text;
            string UserData = JsonConvert.SerializeObject(user);
            string message = "AddUser/"+UserData+"\r\n";
            byte[] data = Encoding.UTF8.GetBytes(message);
            if(CommunicationClass.stream2==null)
            {
                MessageBox.Show("服务器连接失败！");
                return;
            }
            CommunicationClass.stream2.Write(data, 0, data.Length);

            string responseData = string.Empty;
            data = new byte[256];

            int bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
            responseData = Encoding.UTF8.GetString(data, 0, bytes).Replace("\r\n","");
            switch(responseData)
            {
                case "True":
                    MessageBox.Show("添加成功！");
                    break;
                case "False":
                    MessageBox.Show("添加失败！");
                    break;
            }
            
        }

       
    }
}
