using DeviceBaseData;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Client
{

    public partial class ScreenWheelGuard : Form
    {
        #region 窗体特效
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        public const Int32 AW_CENTER = 0x00000010;//
        public const Int32 AW_HIDE = 0x00010000;//
        #endregion
        #region 窗体随意拖动
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0X0112;
        public const int SC_MOVE = 0XF010;
        public const int HTCAPTION = 0X0002;
        #endregion
        
        public Videobox selectedVb;
        public ScreenWheelGuard(Videobox vb)
        {
            InitializeComponent();
            selectedVb = vb;
            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果
             
            //1、添加流媒体根节点，记录deviceID
            for (int i = 0; i < Class1.streamMediaList.Count; i++)
            {
                TreeNode root = new TreeNode();
                root.Text = Class1.streamMediaList[i].Name;
                root.Tag = Class1.streamMediaList[i].DeviceID;
                treeView1.Nodes.Add(root);
                //2、添加摄像机节点
                for (int j = 0; j < Class1.cameraList.Count; j++)
                {
                    if (Class1.cameraList[j].StreamMedia_DeviceID == Class1.streamMediaList[i].DeviceID)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = Class1.cameraList[j].VideoName;
                        tn.Tag = Class1.cameraList[j].DeviceID;
                        root.Nodes.Add(tn);
                    }
                }
            }
            treeView1.ExpandAll();
            
        }

        private void ScreenWheelGuard_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addToWheelGuard_Click(object sender, EventArgs e)
        {
            //dgvWheelGuard
            if (treeView1.SelectedNode == null) return;
            TreeNode node = treeView1.SelectedNode;
            int count = node.Nodes.Count;
            if (count == 0 && node.Parent != null)
            {
                //摄像机节点
                int i = dgvWheelGuard.Rows.Add();
                DataGridViewRow row = dgvWheelGuard.Rows[i];
                row.Cells[0].Value = node.Text;
                row.Tag = node.Parent.Tag;
                row.Cells[1].Value = "5";
                row.Cells[2].Value = node.Tag;
                treeView1.SelectedNode.Remove();
            }

            if(count!=0)
            {
                TreeNodeCollection nodes = node.Nodes;
                foreach(TreeNode tn in nodes)
                {
                    int rowNum = dgvWheelGuard.Rows.Add();
                    DataGridViewRow row = dgvWheelGuard.Rows[rowNum];
                    row.Cells[0].Value = tn.Text;
                    row.Tag = tn.Parent.Tag;
                    row.Cells[1].Value = "5";
                    row.Cells[2].Value = tn.Tag;
                   
                }
                treeView1.SelectedNode.Nodes.Clear();
            }
        }

        private void removeFromWheelGuard_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvWheelGuard.SelectedRows)
            {
                TreeNode node = new TreeNode();
                node.Text = row.Cells[0].Value.ToString();
                node.Tag = row.Cells[2].Value;
                foreach(TreeNode tn in treeView1.Nodes)
                {
                    if (tn.Tag == row.Tag)
                        tn.Nodes.Add(node);
                }
                dgvWheelGuard.Rows.Remove(row);
            }
        }

        private void button_sure_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvWheelGuard.SelectedRows)
            {
                row.Cells[1].Value = txtTime.Text;
            }
        }
        

        private void cboTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && e.KeyChar != '.' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboTime_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxTime.Checked)
            {
                foreach (DataGridViewRow row in dgvWheelGuard.Rows)
                {
                    row.Cells[1].Value = cboTime.Text;
                }
            }

        }

        private void cboTime_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbxTime.Checked)
            {
                foreach (DataGridViewRow row in dgvWheelGuard.Rows)
                {
                    row.Cells[1].Value = cboTime.Text;
                }
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvsrc = dgvWheelGuard.SelectedRows;//获取选中行的集合
            if (dgvsrc.Count > 0)
            {
                int index = dgvWheelGuard.SelectedRows[0].Index;//获取当前选中行的索引
                if (index > 0)//如果该行不是第一行
                {
                    DataGridViewRow dgvr = dgvWheelGuard.Rows[index - dgvsrc.Count];//获取选中行的上一行
                    dgvWheelGuard.Rows.RemoveAt(index - dgvsrc.Count);//删除原选中行的上一行
                    dgvWheelGuard.Rows.Insert((index), dgvr);//将选中行的上一行插入到选中行的后面
                    for (int i = 0; i < dgvsrc.Count; i++)//选中移动后的行
                    {
                        dgvWheelGuard.Rows[index - i - 1].Selected = true;
                    }
                }
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvsrc = dgvWheelGuard.SelectedRows;//获取选中行的集合
            if (dgvsrc.Count > 0)
            {
                int index = dgvWheelGuard.SelectedRows[0].Index;//获取当前选中行的索引
                if (index >= 0 & (dgvWheelGuard.RowCount - 1) != index)//如果该行不是最后一行
                {
                    DataGridViewRow dgvr = dgvWheelGuard.Rows[index + 1];//获取选中行的下一行
                    dgvWheelGuard.Rows.RemoveAt(index + 1);//删除原选中行的上一行
                    dgvWheelGuard.Rows.Insert((index + 1 - dgvsrc.Count), dgvr);//将选中行的上一行插入到选中行的后面
                    for (int i = 0; i < dgvsrc.Count; i++)//选中移动后的行
                    {
                        dgvWheelGuard.Rows[index + 1 - i].Selected = true;
                    }
                }
            }
        }

        private void wheelGuard_Click(object sender, EventArgs e)
        {
            if (selectedVb.thread!=null&&selectedVb.thread.IsAlive)
            {
                MessageBox.Show("当前视频框正在轮巡，请先停止轮巡再打开！");
                return;
            }

            WheelGuard.WheelGuardInfo WGI = new WheelGuard.WheelGuardInfo();
            WGI.DeviceIDList = new System.Collections.Generic.List<Guid>();
            WGI.WheelTime = new System.Collections.Generic.List<int>();
           
            for(int i=0;i<dgvWheelGuard.Rows.Count;i++)
            {
                WGI.DeviceIDList.Add((Guid)dgvWheelGuard.Rows[i].Cells[2].Value);
                WGI.WheelTime.Add(int.Parse(dgvWheelGuard.Rows[i].Cells[1].Value.ToString()));
            }
            selectedVb.info = WGI;

            selectedVb.thread = new System.Threading.Thread(new System.Threading.ThreadStart(selectedVb.WheelGuardThread));
            selectedVb.thread.IsBackground = true;
            selectedVb.thread.Start();


        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            selectedVb.thread.Abort();
            selectedVb.thread = null;
        }
    }
}
