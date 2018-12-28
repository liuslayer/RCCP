using Client.Entities.UserEntity;
using DeviceBaseData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserManagementDLL
{
    public partial class UserRoleForm : Form
    {
        #region 窗体特效
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        public const int AW_CENTER = 0x00000010;//
        public const int AW_HIDE = 0x00010000;//
        #endregion

        List<UserRole> roles1;
        //List<UserRole> roles2;
        List<UserPermissionList> permissions;
        public UserRoleForm()
        {
            InitializeComponent();
            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果

            RefreshForm();

        }

        public void RefreshForm()
        {
            string message = "GetAllUserRoles\r\n";
            string responseData = GetObject(message, 1024 * 256);
            if (responseData != "NULL")
            {
                try
                {
                    roles1 = JsonConvert.DeserializeObject<List<UserRole>>(responseData);
                    
                    //父级角色下拉列表
                    DataTable dt = new DataTable();
                    dt.Columns.Add("TYPE_NAME");
                    dt.Columns.Add("TYPE_ID");
                    dt.Rows.Add("超级管理员", 1);
                    dt.Rows.Add("管理员", 2);
                    dt.Rows.Add("普通用户", 3);
                    dt.Rows.Add("游客", 4);
                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "TYPE_NAME";
                    comboBox2.ValueMember = "TYPE_ID";

                    //添加子角色
                    foreach(TreeNode node in treeView1.Nodes[0].Nodes)
                    {
                        node.Nodes.Clear();
                        for (int i = 0; i < roles1.Count; i++)
                        {
                            if(roles1[i].Parent_UR_id==Convert.ToInt32(node.Tag))
                            {
                                TreeNode n = new TreeNode(roles1[i].RoleName);
                                n.Tag = roles1[i].RoleID;
                                node.Nodes.Add(n);
                            }
                        }
                    }
                }
                catch(Exception ex) { }
                treeView1.ExpandAll();
                responseData = "NULL";
            }
            message = "GetUserAuthorityList\r\n";
            responseData = GetObject(message, 1024 * 256);
            if (responseData != "NULL")
            {
                try
                {
                    permissions = JsonConvert.DeserializeObject<List<UserPermissionList>>(responseData);
                    comboBox1.DataSource = permissions;
                    comboBox1.DisplayMember = "UserPermissionName";
                    comboBox1.ValueMember = "UserPermissionID";
                }
                catch { }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UserRole newRole = new UserRole();
            string roleName = textBox1.Text;
           
            
            if (roleName == "")
                MessageBox.Show("请输入角色名称！");
            else
            {
                newRole.RoleName = roleName;
                if (comboBox2.SelectedValue != null && comboBox1.SelectedValue != null)
                {
                    string Parent_UR_id = comboBox2.SelectedValue.ToString();
                    string Permission_ID = comboBox1.SelectedValue.ToString();
                    newRole.Parent_UR_id = int.Parse(Parent_UR_id);
                    //newRole.Permission_ID = int.Parse(Permission_ID);
                }
                string data = JsonConvert.SerializeObject(newRole);
                string message = "AddUserRole/" + data + "\r\n" ;
                string responseData = GetObject(message, 256);
                switch (responseData)
                {
                    case "True":
                        MessageBox.Show("添加成功！");
                        RefreshForm();
                        break;
                    case "False":
                        MessageBox.Show("添加失败！");
                        break;
                }
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
            try
            {
                int bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
                responseData = Encoding.UTF8.GetString(data, 0, bytes).Replace("\r\n", "");
            }
            catch { }

            return responseData;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        int x, y;

        private void UserRoleForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }
       
        //删除角色
        private void DelRole_Click(object sender, EventArgs e)
        {
            int role_id = Convert.ToInt32(treeView1.SelectedNode.Tag);
            string message = "DelUserRole/" + role_id + "\r\n";
            string responseData = GetObject(message, 256);
            switch(responseData)
            {
                case "True":
                    MessageBox.Show("删除成功！");
                    RefreshForm();
                    break;
                case "False":
                    MessageBox.Show("删除失败！");
                    break;
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            treeView1.SelectedNode = node;
            if (e.Button == MouseButtons.Right && node.Level == 2)
            {
                treeView1.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void UserRoleForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
        }
    }
}
