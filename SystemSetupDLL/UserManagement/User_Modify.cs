using Client.Entities.UserEntity;
using DeviceBaseData;
using Encryption;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Windows.Forms;

namespace SystemSetupDLL.UserManagement
{
    public partial class User_Modify : Form
    {
        UserList userList;
        public User_Modify()
        {
            InitializeComponent();
        }
        public User_Modify(UserList userList)
        {
            InitializeComponent();
            this.userList = userList;
            //用户名
            textBox1.Text = userList.Username;
            textBox6.Text = userList.Description;
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
            //userList.UserPermissionID = comboBox1.SelectedValue;
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
    }
}
