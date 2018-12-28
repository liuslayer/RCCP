namespace OMClient
{
    partial class ManagementServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            DevComponents.DotNetBar.Layout.Background background1 = new DevComponents.DotNetBar.Layout.Background();
            DevComponents.DotNetBar.Layout.BorderPattern borderPattern1 = new DevComponents.DotNetBar.Layout.BorderPattern();
            this.panelEx_ManagementServer = new DevComponents.DotNetBar.PanelEx();
            this.panelEx_Server = new DevComponents.DotNetBar.PanelEx();
            this.panelEx_Bottom = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel_ServerStatus = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dataGridView_ServerStatus = new System.Windows.Forms.DataGridView();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_StartedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_IsRunning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_MaxConnectionNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_TotalConnections = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Listeners = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_RequestHandlingSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_TotalHandledRequests = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_AvialableSendingQueueItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_TotalSendingQueueItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_CollectedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Restart = new System.Windows.Forms.ToolStripMenuItem();
            this.Start = new System.Windows.Forms.ToolStripMenuItem();
            this.Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx_Top = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel_Summary = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX_CollectedTime = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX_CpuUsage = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX_AvailableCompletionPortThreads = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX_MaxCompletionPortThreads = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX_AvailableWorkingThreads = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX_MaxWorkingThreads = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX_TotalThreadCount = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX_MemoryUsage = new DevComponents.DotNetBar.LabelX();
            this.layoutGroup6 = new DevComponents.DotNetBar.Layout.LayoutGroup();
            this.layoutControlItem10 = new DevComponents.DotNetBar.Layout.LayoutControlItem();
            this.layoutControlItem11 = new DevComponents.DotNetBar.Layout.LayoutControlItem();
            this.panelEx_ManagementServer.SuspendLayout();
            this.panelEx_Server.SuspendLayout();
            this.panelEx_Bottom.SuspendLayout();
            this.groupPanel_ServerStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ServerStatus)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panelEx_Top.SuspendLayout();
            this.groupPanel_Summary.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx_ManagementServer
            // 
            this.panelEx_ManagementServer.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_ManagementServer.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_ManagementServer.Controls.Add(this.panelEx_Server);
            this.panelEx_ManagementServer.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_ManagementServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_ManagementServer.Location = new System.Drawing.Point(0, 0);
            this.panelEx_ManagementServer.Name = "panelEx_ManagementServer";
            this.panelEx_ManagementServer.Size = new System.Drawing.Size(1904, 992);
            this.panelEx_ManagementServer.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_ManagementServer.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_ManagementServer.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_ManagementServer.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_ManagementServer.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_ManagementServer.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_ManagementServer.Style.GradientAngle = 90;
            this.panelEx_ManagementServer.TabIndex = 0;
            // 
            // panelEx_Server
            // 
            this.panelEx_Server.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Server.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Server.Controls.Add(this.panelEx_Bottom);
            this.panelEx_Server.Controls.Add(this.panelEx_Top);
            this.panelEx_Server.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_Server.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_Server.Location = new System.Drawing.Point(0, 0);
            this.panelEx_Server.Name = "panelEx_Server";
            this.panelEx_Server.Size = new System.Drawing.Size(1904, 992);
            this.panelEx_Server.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Server.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_Server.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_Server.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Server.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Server.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Server.Style.GradientAngle = 90;
            this.panelEx_Server.TabIndex = 8;
            // 
            // panelEx_Bottom
            // 
            this.panelEx_Bottom.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Bottom.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Bottom.Controls.Add(this.groupPanel_ServerStatus);
            this.panelEx_Bottom.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_Bottom.Location = new System.Drawing.Point(0, 347);
            this.panelEx_Bottom.Name = "panelEx_Bottom";
            this.panelEx_Bottom.Size = new System.Drawing.Size(1904, 645);
            this.panelEx_Bottom.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Bottom.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_Bottom.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_Bottom.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Bottom.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Bottom.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Bottom.Style.GradientAngle = 90;
            this.panelEx_Bottom.TabIndex = 11;
            this.panelEx_Bottom.Text = "panelEx2";
            // 
            // groupPanel_ServerStatus
            // 
            this.groupPanel_ServerStatus.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_ServerStatus.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_ServerStatus.Controls.Add(this.dataGridView_ServerStatus);
            this.groupPanel_ServerStatus.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel_ServerStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel_ServerStatus.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel_ServerStatus.Location = new System.Drawing.Point(0, 0);
            this.groupPanel_ServerStatus.Name = "groupPanel_ServerStatus";
            this.groupPanel_ServerStatus.Size = new System.Drawing.Size(1904, 645);
            // 
            // 
            // 
            this.groupPanel_ServerStatus.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_ServerStatus.Style.BackColorGradientAngle = 90;
            this.groupPanel_ServerStatus.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_ServerStatus.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_ServerStatus.Style.BorderBottomWidth = 1;
            this.groupPanel_ServerStatus.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_ServerStatus.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_ServerStatus.Style.BorderLeftWidth = 1;
            this.groupPanel_ServerStatus.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_ServerStatus.Style.BorderRightWidth = 1;
            this.groupPanel_ServerStatus.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_ServerStatus.Style.BorderTopWidth = 1;
            this.groupPanel_ServerStatus.Style.CornerDiameter = 4;
            this.groupPanel_ServerStatus.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_ServerStatus.Style.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel_ServerStatus.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_ServerStatus.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_ServerStatus.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_ServerStatus.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_ServerStatus.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_ServerStatus.TabIndex = 4;
            this.groupPanel_ServerStatus.Text = "各服务状态";
            // 
            // dataGridView_ServerStatus
            // 
            this.dataGridView_ServerStatus.AllowUserToAddRows = false;
            this.dataGridView_ServerStatus.AllowUserToDeleteRows = false;
            this.dataGridView_ServerStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ServerStatus.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridView_ServerStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ServerStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_ServerStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ServerStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Name,
            this.Column_StartedTime,
            this.Column_IsRunning,
            this.Column_MaxConnectionNumber,
            this.Column_TotalConnections,
            this.Column_Listeners,
            this.Column_RequestHandlingSpeed,
            this.Column_TotalHandledRequests,
            this.Column_AvialableSendingQueueItems,
            this.Column_TotalSendingQueueItems,
            this.Column_Tag,
            this.Column_CollectedTime});
            this.dataGridView_ServerStatus.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView_ServerStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ServerStatus.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_ServerStatus.MultiSelect = false;
            this.dataGridView_ServerStatus.Name = "dataGridView_ServerStatus";
            this.dataGridView_ServerStatus.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ServerStatus.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridView_ServerStatus.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_ServerStatus.RowTemplate.Height = 23;
            this.dataGridView_ServerStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ServerStatus.Size = new System.Drawing.Size(1898, 612);
            this.dataGridView_ServerStatus.TabIndex = 5;
            this.dataGridView_ServerStatus.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_ServerStatus_CellMouseDown);
            // 
            // Column_Name
            // 
            this.Column_Name.DataPropertyName = "Name";
            this.Column_Name.HeaderText = "服务名";
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.ReadOnly = true;
            // 
            // Column_StartedTime
            // 
            this.Column_StartedTime.DataPropertyName = "StartedTime";
            this.Column_StartedTime.HeaderText = "启动时间";
            this.Column_StartedTime.Name = "Column_StartedTime";
            this.Column_StartedTime.ReadOnly = true;
            // 
            // Column_IsRunning
            // 
            this.Column_IsRunning.DataPropertyName = "IsRunning";
            this.Column_IsRunning.HeaderText = "运行状态";
            this.Column_IsRunning.Name = "Column_IsRunning";
            this.Column_IsRunning.ReadOnly = true;
            // 
            // Column_MaxConnectionNumber
            // 
            this.Column_MaxConnectionNumber.DataPropertyName = "MaxConnectionNumber";
            this.Column_MaxConnectionNumber.HeaderText = "最大允许连接数";
            this.Column_MaxConnectionNumber.Name = "Column_MaxConnectionNumber";
            this.Column_MaxConnectionNumber.ReadOnly = true;
            // 
            // Column_TotalConnections
            // 
            this.Column_TotalConnections.DataPropertyName = "TotalConnections";
            this.Column_TotalConnections.HeaderText = "当前连接数";
            this.Column_TotalConnections.Name = "Column_TotalConnections";
            this.Column_TotalConnections.ReadOnly = true;
            // 
            // Column_Listeners
            // 
            this.Column_Listeners.DataPropertyName = "Listeners";
            this.Column_Listeners.HeaderText = "监听地址";
            this.Column_Listeners.Name = "Column_Listeners";
            this.Column_Listeners.ReadOnly = true;
            // 
            // Column_RequestHandlingSpeed
            // 
            this.Column_RequestHandlingSpeed.DataPropertyName = "RequestHandlingSpeed";
            this.Column_RequestHandlingSpeed.HeaderText = "响应时间";
            this.Column_RequestHandlingSpeed.Name = "Column_RequestHandlingSpeed";
            this.Column_RequestHandlingSpeed.ReadOnly = true;
            // 
            // Column_TotalHandledRequests
            // 
            this.Column_TotalHandledRequests.DataPropertyName = "TotalHandledRequests";
            this.Column_TotalHandledRequests.HeaderText = "已处理请求数";
            this.Column_TotalHandledRequests.Name = "Column_TotalHandledRequests";
            this.Column_TotalHandledRequests.ReadOnly = true;
            // 
            // Column_AvialableSendingQueueItems
            // 
            this.Column_AvialableSendingQueueItems.DataPropertyName = "AvialableSendingQueueItems";
            this.Column_AvialableSendingQueueItems.HeaderText = "可用传输队列";
            this.Column_AvialableSendingQueueItems.Name = "Column_AvialableSendingQueueItems";
            this.Column_AvialableSendingQueueItems.ReadOnly = true;
            // 
            // Column_TotalSendingQueueItems
            // 
            this.Column_TotalSendingQueueItems.DataPropertyName = "TotalSendingQueueItems";
            this.Column_TotalSendingQueueItems.HeaderText = "最大传输队列";
            this.Column_TotalSendingQueueItems.Name = "Column_TotalSendingQueueItems";
            this.Column_TotalSendingQueueItems.ReadOnly = true;
            // 
            // Column_Tag
            // 
            this.Column_Tag.DataPropertyName = "Tag";
            this.Column_Tag.HeaderText = "Tag";
            this.Column_Tag.Name = "Column_Tag";
            this.Column_Tag.ReadOnly = true;
            this.Column_Tag.Visible = false;
            // 
            // Column_CollectedTime
            // 
            this.Column_CollectedTime.DataPropertyName = "CollectedTime";
            this.Column_CollectedTime.HeaderText = "CollectedTime";
            this.Column_CollectedTime.Name = "Column_CollectedTime";
            this.Column_CollectedTime.ReadOnly = true;
            this.Column_CollectedTime.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Restart,
            this.Start,
            this.Stop});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // Restart
            // 
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(100, 22);
            this.Restart.Text = "重启";
            // 
            // Start
            // 
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(100, 22);
            this.Start.Text = "启动";
            // 
            // Stop
            // 
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(100, 22);
            this.Stop.Text = "停止";
            // 
            // panelEx_Top
            // 
            this.panelEx_Top.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Top.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Top.Controls.Add(this.groupPanel_Summary);
            this.panelEx_Top.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx_Top.Location = new System.Drawing.Point(0, 0);
            this.panelEx_Top.Name = "panelEx_Top";
            this.panelEx_Top.Size = new System.Drawing.Size(1904, 347);
            this.panelEx_Top.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Top.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_Top.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_Top.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Top.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Top.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Top.Style.GradientAngle = 90;
            this.panelEx_Top.TabIndex = 7;
            this.panelEx_Top.Text = "panelEx1";
            // 
            // groupPanel_Summary
            // 
            this.groupPanel_Summary.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Summary.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Summary.Controls.Add(this.labelX2);
            this.groupPanel_Summary.Controls.Add(this.labelX_CollectedTime);
            this.groupPanel_Summary.Controls.Add(this.labelX1);
            this.groupPanel_Summary.Controls.Add(this.labelX_CpuUsage);
            this.groupPanel_Summary.Controls.Add(this.labelX11);
            this.groupPanel_Summary.Controls.Add(this.labelX_AvailableCompletionPortThreads);
            this.groupPanel_Summary.Controls.Add(this.labelX9);
            this.groupPanel_Summary.Controls.Add(this.labelX_MaxCompletionPortThreads);
            this.groupPanel_Summary.Controls.Add(this.labelX13);
            this.groupPanel_Summary.Controls.Add(this.labelX_AvailableWorkingThreads);
            this.groupPanel_Summary.Controls.Add(this.labelX7);
            this.groupPanel_Summary.Controls.Add(this.labelX_MaxWorkingThreads);
            this.groupPanel_Summary.Controls.Add(this.labelX5);
            this.groupPanel_Summary.Controls.Add(this.labelX_TotalThreadCount);
            this.groupPanel_Summary.Controls.Add(this.labelX3);
            this.groupPanel_Summary.Controls.Add(this.labelX_MemoryUsage);
            this.groupPanel_Summary.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel_Summary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel_Summary.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel_Summary.Location = new System.Drawing.Point(0, 0);
            this.groupPanel_Summary.Name = "groupPanel_Summary";
            this.groupPanel_Summary.Size = new System.Drawing.Size(1904, 347);
            // 
            // 
            // 
            this.groupPanel_Summary.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_Summary.Style.BackColorGradientAngle = 90;
            this.groupPanel_Summary.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_Summary.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Summary.Style.BorderBottomWidth = 1;
            this.groupPanel_Summary.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Summary.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Summary.Style.BorderLeftWidth = 1;
            this.groupPanel_Summary.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Summary.Style.BorderRightWidth = 1;
            this.groupPanel_Summary.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Summary.Style.BorderTopWidth = 1;
            this.groupPanel_Summary.Style.CornerDiameter = 4;
            this.groupPanel_Summary.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Summary.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_Summary.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_Summary.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_Summary.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_Summary.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_Summary.TabIndex = 3;
            this.groupPanel_Summary.Text = "服务器概况";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(9, 288);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(157, 23);
            this.labelX2.TabIndex = 19;
            this.labelX2.Text = "最近采集时间：";
            // 
            // labelX_CollectedTime
            // 
            // 
            // 
            // 
            this.labelX_CollectedTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_CollectedTime.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX_CollectedTime.Location = new System.Drawing.Point(172, 288);
            this.labelX_CollectedTime.Name = "labelX_CollectedTime";
            this.labelX_CollectedTime.Size = new System.Drawing.Size(233, 23);
            this.labelX_CollectedTime.TabIndex = 18;
            this.labelX_CollectedTime.Text = "0";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(44, 16);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(101, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "CPU使用率：";
            // 
            // labelX_CpuUsage
            // 
            // 
            // 
            // 
            this.labelX_CpuUsage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_CpuUsage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX_CpuUsage.Location = new System.Drawing.Point(163, 16);
            this.labelX_CpuUsage.Name = "labelX_CpuUsage";
            this.labelX_CpuUsage.Size = new System.Drawing.Size(82, 23);
            this.labelX_CpuUsage.TabIndex = 3;
            this.labelX_CpuUsage.Text = "0.00%";
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX11.Location = new System.Drawing.Point(463, 201);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(244, 23);
            this.labelX11.TabIndex = 15;
            this.labelX11.Text = "线程池可用完成端口线程数量：";
            // 
            // labelX_AvailableCompletionPortThreads
            // 
            // 
            // 
            // 
            this.labelX_AvailableCompletionPortThreads.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_AvailableCompletionPortThreads.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX_AvailableCompletionPortThreads.Location = new System.Drawing.Point(713, 201);
            this.labelX_AvailableCompletionPortThreads.Name = "labelX_AvailableCompletionPortThreads";
            this.labelX_AvailableCompletionPortThreads.Size = new System.Drawing.Size(100, 23);
            this.labelX_AvailableCompletionPortThreads.TabIndex = 16;
            this.labelX_AvailableCompletionPortThreads.Text = "0";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX9.Location = new System.Drawing.Point(9, 201);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(240, 23);
            this.labelX9.TabIndex = 13;
            this.labelX9.Text = "线程池最大完成端口线程数量：";
            // 
            // labelX_MaxCompletionPortThreads
            // 
            // 
            // 
            // 
            this.labelX_MaxCompletionPortThreads.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_MaxCompletionPortThreads.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX_MaxCompletionPortThreads.Location = new System.Drawing.Point(255, 201);
            this.labelX_MaxCompletionPortThreads.Name = "labelX_MaxCompletionPortThreads";
            this.labelX_MaxCompletionPortThreads.Size = new System.Drawing.Size(100, 23);
            this.labelX_MaxCompletionPortThreads.TabIndex = 14;
            this.labelX_MaxCompletionPortThreads.Text = "0";
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX13.Location = new System.Drawing.Point(494, 105);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(213, 23);
            this.labelX13.TabIndex = 12;
            this.labelX13.Text = "线程池可用工作线程数量：";
            // 
            // labelX_AvailableWorkingThreads
            // 
            // 
            // 
            // 
            this.labelX_AvailableWorkingThreads.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_AvailableWorkingThreads.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX_AvailableWorkingThreads.Location = new System.Drawing.Point(713, 105);
            this.labelX_AvailableWorkingThreads.Name = "labelX_AvailableWorkingThreads";
            this.labelX_AvailableWorkingThreads.Size = new System.Drawing.Size(100, 23);
            this.labelX_AvailableWorkingThreads.TabIndex = 9;
            this.labelX_AvailableWorkingThreads.Text = "0";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX7.Location = new System.Drawing.Point(44, 105);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(205, 23);
            this.labelX7.TabIndex = 6;
            this.labelX7.Text = "线程池最大工作线程数量：";
            // 
            // labelX_MaxWorkingThreads
            // 
            // 
            // 
            // 
            this.labelX_MaxWorkingThreads.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_MaxWorkingThreads.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX_MaxWorkingThreads.Location = new System.Drawing.Point(255, 105);
            this.labelX_MaxWorkingThreads.Name = "labelX_MaxWorkingThreads";
            this.labelX_MaxWorkingThreads.Size = new System.Drawing.Size(100, 23);
            this.labelX_MaxWorkingThreads.TabIndex = 7;
            this.labelX_MaxWorkingThreads.Text = "0";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(630, 16);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(77, 23);
            this.labelX5.TabIndex = 4;
            this.labelX5.Text = "总线程：";
            // 
            // labelX_TotalThreadCount
            // 
            // 
            // 
            // 
            this.labelX_TotalThreadCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_TotalThreadCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX_TotalThreadCount.Location = new System.Drawing.Point(713, 16);
            this.labelX_TotalThreadCount.Name = "labelX_TotalThreadCount";
            this.labelX_TotalThreadCount.Size = new System.Drawing.Size(100, 23);
            this.labelX_TotalThreadCount.TabIndex = 5;
            this.labelX_TotalThreadCount.Text = "0";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(279, 16);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(157, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "物理内存使用情况：";
            // 
            // labelX_MemoryUsage
            // 
            // 
            // 
            // 
            this.labelX_MemoryUsage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_MemoryUsage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX_MemoryUsage.Location = new System.Drawing.Point(442, 16);
            this.labelX_MemoryUsage.Name = "labelX_MemoryUsage";
            this.labelX_MemoryUsage.Size = new System.Drawing.Size(146, 23);
            this.labelX_MemoryUsage.TabIndex = 3;
            this.labelX_MemoryUsage.Text = "0";
            // 
            // layoutGroup6
            // 
            this.layoutGroup6.Height = 92;
            this.layoutGroup6.Items.AddRange(new DevComponents.DotNetBar.Layout.LayoutItemBase[] {
            this.layoutControlItem10,
            this.layoutControlItem11});
            this.layoutGroup6.MinSize = new System.Drawing.Size(120, 29);
            this.layoutGroup6.Name = "layoutGroup6";
            this.layoutGroup6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            background1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))))};
            this.layoutGroup6.Style.Background = background1;
            this.layoutGroup6.Style.BorderColors = new DevComponents.DotNetBar.Layout.BorderColors(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(150)))), ((int)(((byte)(238))))), System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(150)))), ((int)(((byte)(238))))), System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(150)))), ((int)(((byte)(238))))), System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(150)))), ((int)(((byte)(238))))));
            borderPattern1.Bottom = DevComponents.DotNetBar.Layout.LinePattern.Solid;
            borderPattern1.Left = DevComponents.DotNetBar.Layout.LinePattern.Solid;
            borderPattern1.Right = DevComponents.DotNetBar.Layout.LinePattern.Solid;
            borderPattern1.Top = DevComponents.DotNetBar.Layout.LinePattern.Solid;
            this.layoutGroup6.Style.BorderPattern = borderPattern1;
            this.layoutGroup6.Style.BorderThickness = new DevComponents.DotNetBar.Layout.Thickness(1D, 1D, 1D, 1D);
            this.layoutGroup6.TextPosition = DevComponents.DotNetBar.Layout.eLayoutPosition.Top;
            this.layoutGroup6.Width = 50;
            this.layoutGroup6.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Height = 26;
            this.layoutControlItem10.MinSize = new System.Drawing.Size(120, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.layoutControlItem10.Text = "Label:";
            this.layoutControlItem10.Width = 100;
            this.layoutControlItem10.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Height = 61;
            this.layoutControlItem11.MinSize = new System.Drawing.Size(64, 16);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.layoutControlItem11.Text = "Label:";
            this.layoutControlItem11.Width = 100;
            this.layoutControlItem11.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent;
            // 
            // ManagementServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 992);
            this.Controls.Add(this.panelEx_ManagementServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManagementServerForm";
            this.Text = "ManagementServer";
            this.panelEx_ManagementServer.ResumeLayout(false);
            this.panelEx_Server.ResumeLayout(false);
            this.panelEx_Bottom.ResumeLayout(false);
            this.groupPanel_ServerStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ServerStatus)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelEx_Top.ResumeLayout(false);
            this.groupPanel_Summary.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx_ManagementServer;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel_Summary;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX_AvailableCompletionPortThreads;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX_MaxCompletionPortThreads;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.LabelX labelX_AvailableWorkingThreads;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX_MaxWorkingThreads;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX_TotalThreadCount;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX_MemoryUsage;
        private DevComponents.DotNetBar.Layout.LayoutGroup layoutGroup6;
        private DevComponents.DotNetBar.Layout.LayoutControlItem layoutControlItem10;
        private DevComponents.DotNetBar.Layout.LayoutControlItem layoutControlItem11;
        private DevComponents.DotNetBar.PanelEx panelEx_Server;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX_CpuUsage;
        private DevComponents.DotNetBar.LabelX labelX_CollectedTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.ToolStripMenuItem Restart;
        private System.Windows.Forms.ToolStripMenuItem Start;
        private System.Windows.Forms.ToolStripMenuItem Stop;
        private System.Windows.Forms.DataGridView dataGridView_ServerStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_StartedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_IsRunning;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_MaxConnectionNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_TotalConnections;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Listeners;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RequestHandlingSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_TotalHandledRequests;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_AvialableSendingQueueItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_TotalSendingQueueItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_CollectedTime;
        private DevComponents.DotNetBar.PanelEx panelEx_Top;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel_ServerStatus;
        private DevComponents.DotNetBar.PanelEx panelEx_Bottom;
    }
}