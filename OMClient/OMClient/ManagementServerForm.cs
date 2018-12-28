using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMClient
{
    public partial class ManagementServerForm : Form
    {
        private ManagementServerCommunicate managementServerCom;
        private int seletedRowsIndex;

        public ManagementServerForm(ManagementServerCommunicate managementServerCom)
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false;
            this.managementServerCom = managementServerCom;
            this.dataGridView_ServerStatus.DoubleBuffered(true);
            contextMenuStrip1.AutoClose = true;
        }

        public delegate void UpdateMyNodeStatusDel(MyNodeStatus myNodeStatus);
        public void UpdateMyNodeStatus(MyNodeStatus myNodeStatus)
        {
            if (this.InvokeRequired)
            {
                UpdateMyNodeStatusDel del = new
                 UpdateMyNodeStatusDel(UpdateMyNodeStatus);
                this.Invoke(del, myNodeStatus);
            }
            else
            {
                if (myNodeStatus == null)
                {
                    labelX_CpuUsage.Text = string.Empty;
                    labelX_MemoryUsage.Text = string.Empty;
                    labelX_TotalThreadCount.Text = string.Empty;
                    labelX_MaxWorkingThreads.Text = string.Empty;
                    labelX_AvailableWorkingThreads.Text = string.Empty;
                    labelX_MaxCompletionPortThreads.Text = string.Empty;
                    labelX_AvailableCompletionPortThreads.Text = string.Empty;
                    dataGridView_ServerStatus.DataSource = new List<MyInstancesStatus>();
                    labelX_CollectedTime.Text = string.Empty;
                    return;
                }
                MyBootstrapStatus myBootstrapStatus = myNodeStatus.MyBootstrapStatus;
                labelX_CpuUsage.Text = Math.Round(double.Parse(myBootstrapStatus.CpuUsage), 2).ToString() + "%";
                labelX_MemoryUsage.Text = myBootstrapStatus.MemoryUsage;
                labelX_TotalThreadCount.Text = myBootstrapStatus.TotalThreadCount;
                labelX_MaxWorkingThreads.Text = myBootstrapStatus.MaxWorkingThreads;
                labelX_AvailableWorkingThreads.Text = myBootstrapStatus.AvailableWorkingThreads;
                labelX_MaxCompletionPortThreads.Text = myBootstrapStatus.MaxCompletionPortThreads;
                labelX_AvailableCompletionPortThreads.Text = myBootstrapStatus.AvailableCompletionPortThreads;

                myNodeStatus.MyInstancesStatus.ForEach(_ =>
                {
                    _.IsRunning = _.IsRunning == "True" ? "运行中" : "停止";
                });

                dataGridView_ServerStatus.DataSource = myNodeStatus.MyInstancesStatus;
                dataGridView_ServerStatus.Rows[seletedRowsIndex].Selected = true;
                for (int i = 0; i < dataGridView_ServerStatus.Rows.Count; i++)
                {
                    if (dataGridView_ServerStatus.Rows[i].Cells[3].Value.ToString() == "运行中")
                    {
                        dataGridView_ServerStatus.Rows[i].Cells[3].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        dataGridView_ServerStatus.Rows[i].Cells[3].Style.BackColor = Color.Red;
                    }
                }
                labelX_CollectedTime.Text = myNodeStatus.MyInstancesStatus.Count > 0 ? myNodeStatus.MyInstancesStatus[0].CollectedTime : "";
            }
        }

        private void dataGridView_ServerStatus_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView_ServerStatus.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView_ServerStatus.ClearSelection();
                        dataGridView_ServerStatus.Rows[e.RowIndex].Selected = true;
                        seletedRowsIndex = e.RowIndex;
                    }
                    string isRunning = dataGridView_ServerStatus.Rows[e.RowIndex].Cells["Column_IsRunning"].Value.ToString();
                    if (isRunning == "运行中")
                    {
                        contextMenuStrip1.Items[0].Enabled = true;
                        contextMenuStrip1.Items[1].Enabled = false;
                        contextMenuStrip1.Items[2].Enabled = true;
                    }
                    else
                    {
                        contextMenuStrip1.Items[0].Enabled = false;
                        contextMenuStrip1.Items[1].Enabled = true;
                        contextMenuStrip1.Items[2].Enabled = false;
                    }
                    //弹出操作菜单
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
            else
            {
                if (e.RowIndex >= 0)
                {
                    seletedRowsIndex = e.RowIndex;
                }
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dataGridView_ServerStatus.SelectedRows.Count < 1)
                return;
            DataGridViewRow row = dataGridView_ServerStatus.SelectedRows[0];
            string name = row.Cells["Column_Name"].Value.ToString();
            string sendMsg = string.Empty;
            if (e.ClickedItem.Name == "Restart")
            {
                sendMsg = ManagementServerCommunicate.ManagementServerCommand.RestartServer.ToString() + " " + name + "\r\n";
                managementServerCom.SendMsgToServer(sendMsg);
            }
            else if (e.ClickedItem.Name == "Start")
            {
                sendMsg = ManagementServerCommunicate.ManagementServerCommand.StartServer.ToString() + " " + name + "\r\n";
                managementServerCom.SendMsgToServer(sendMsg);
            }
            else
            {
                sendMsg = ManagementServerCommunicate.ManagementServerCommand.StopServer.ToString() + " " + name + "\r\n";
                managementServerCom.SendMsgToServer(sendMsg);
            }
        }
    }

    public static class DoubleBuff
    {
        public static void DoubleBuffered(this System.Windows.Forms.DataGridView dgv, bool setting)
        {

            Type dgvType = dgv.GetType();

            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

    }
}
