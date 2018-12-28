using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.Text;
using System.Threading;
using Encryption;
using DeviceBaseData;
using Client.Entities.UserEntity;
using Newtonsoft.Json;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using RecDll.ole;

namespace Client
{
    public partial class Login : Form
    {
        #region 窗体特效
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        public const Int32 AW_CENTER = 0x00000010;//
        public const Int32 AW_HIDE = 0x00010000;//
        #endregion

        public DialogResult result=DialogResult.Cancel;
        DialogResult isCloseForm;//是否关闭窗体
        public Login()
        {
            InitializeComponent();
            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果
        }
        
        // 关闭按钮事件
        private void buttonClose_Click(object sender, EventArgs e)
        {
            isCloseForm = MessageBox.Show("请确认是否退出?", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (isCloseForm==DialogResult.OK)
            {
                AnimateWindow(Handle, 300, AW_HIDE + AW_CENTER);
                Close();
                Application.Exit();
            }
        }
        // 鼠标进入图像改变为2.png
        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Image.FromFile(@".\images\login\"+btn.Name+"2.png");
        }
        // 鼠标离开图片变回1.png
        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Image.FromFile(@".\images\login\" + btn.Name + "1.png");
        }
        // 鼠标按下图片变为1.png
        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Image.FromFile(@".\images\login\" + btn.Name + "1.png");
        }
        // 鼠标弹起图片变为2.png
        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (result == DialogResult.OK)
            {
                btn.BackgroundImage = Image.FromFile(@".\images\login\" + btn.Name + "1.png");
            }
            else
            {
                btn.BackgroundImage = Image.FromFile(@".\images\login\" + btn.Name + "2.png");
            }
           
        }
        // 点击登录按钮事件    
        private void loginBtn_Click(object sender, EventArgs e)
        {
            username = userNameCombo.Text;//获取用户名的文本信息
            string pass = Encrypt.EncryptPassword(passWord.Text);
            if (username == "")
            {
                result = MessageBox.Show("用户名不能为空", "提示", MessageBoxButtons.OK);
            }
            else
            {
                if (pass == "")
                {
                    result = MessageBox.Show("密码不能为空", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    try
                    {
                        string message = "CheckUser/" + username + "," + pass + "\r\n";
                        byte[] data = Encoding.UTF8.GetBytes(message);
                        CommunicationClass.stream2.Write(data, 0, data.Length);
                        ReceiveData();
                        //Thread th = new Thread(new ThreadStart(ReceiveData));
                        //th.IsBackground = true;
                        //th.Start();
                    }
                    catch(Exception ex) {
                        if (!CommunicationClass.Init())
                            MessageBox.Show("服务器连接失败！");
                    }
                }
            }
        }
        /// <summary>
        /// 接收服务器返回的用户登录验证结果
        /// </summary>
        private void ReceiveData()
        {
            string responseData = string.Empty;
            byte[] data = new byte[1024*100];
            Int64 bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
            responseData = Encoding.UTF8.GetString(data, 0, (int)bytes);
            responseData = responseData.Replace("\r\n", "");
            string[] str = responseData.Split(new char[] { '_' });
            UserLog log = new UserLog();
            log.UserName = username;
            log.OperationDate = DateTime.Now.ToString("yyyy-MM-dd");
            log.OperationTime = DateTime.Now.ToString("HH:mm:ss");
            log.Operation = "用户登录";
            string errorInfo = "";
            switch (str[0])
            {
                case "True":
                    result = DialogResult.OK;
                    CheckForIllegalCrossThreadCalls = false;
                    Close();
                    log.Description = "成功";
                    break;
                case "False":
                    log.Description = "失败";
                    MessageBox.Show("登录失败！");
                    break;
            }
            UserLogClass.InsertData(log, ref errorInfo);
            if (str.Length==2&&str[1]!="")
            {
                try
                {
                    Class1.loginUserInfomation= JsonConvert.DeserializeObject<LoginUserInfomation>(str[1]);
                   
                }
                catch(Exception ex)
                { }
            }

        }

        /// <summary>
        /// 点击取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        /// <summary>
        /// 鼠标按下实现拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        int x, y;
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
        }
        /// <summary>
        /// 鼠标移动实现效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }
       

       


        //在密码框中点击enter键时触发“登录”按钮点击事件
        private void passWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn_Click(null, null);
            }
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            userNameCombo.Focus();
        }

        ArrayList userList = new ArrayList();  //创建一个用户列表集合，用于记录登录过的用户名，将其显示在用户下拉列表中       
        string username;//接收文本框的用户名
        private void Login_Load(object sender, EventArgs e)
        {
            //软件初始化时将user.xml文件里面用户名读取到userList集合中
            ReadXML();
            if (userList.Count != 0)
            {
                userNameCombo.Text = (string)userList[userList.Count - 1];
                for (int i = 0; i < userList.Count; i++)
                {
                    userNameCombo.Items.Add(userList[userList.Count - 1 - i]);
                }
            }
        }
        //读用户
        void ReadXML()
        {
            XmlDocument user = new XmlDocument();
            user.Load("user.xml");
            XmlNodeList user_list = user.SelectSingleNode("root").ChildNodes;
            foreach (XmlNode xnf in user_list)
            {
                //将xml文件里面的所有用户名放入userList中，用于显示在登录界面用户名下拉列表中
                userList.Add(xnf.Attributes["NUM"].Value);
            }
        }
        //写用户
        void WriteXml()
        {
            XmlDocument user = new XmlDocument();
            user.Load("user.xml");//加载xml文件
            XmlNode root = user.SelectSingleNode("root");//查找<root>
            XmlElement xmlEUser = user.CreateElement("user");//创建一个user节点
            xmlEUser.SetAttribute("NUM", username);//设置该节点的NUM属性
            root.AppendChild(xmlEUser);
            user.Save("user.xml");
        }

        private void Login_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.DarkGray, 0, 0, Width - 1, Height - 1);
        }

        //删除用户
        void DelXml(string name)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("user.xml");
            XmlNode xnl = xmlDoc.SelectSingleNode("root");
            foreach (XmlNode xn in xnl.ChildNodes)
            {
                if (xn.Attributes["NUM"].Value == name)
                {
                    xnl.RemoveChild(xn);
                    break;
                }
            }
            xmlDoc.Save("user.xml");
        }
        
    }
}
