namespace OMClient
{
    partial class LogServerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx_Log = new DevComponents.DotNetBar.PanelEx();
            this.panelEx_Bottom = new DevComponents.DotNetBar.PanelEx();
            this.panelEx_ErrLog = new DevComponents.DotNetBar.PanelEx();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX_ErrGenerateExcel = new DevComponents.DotNetBar.ButtonX();
            this.myPageControl_ErrLog = new MyControls.MyPageControl();
            this.groupPanel_ErrLog = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dataGridView_ErrLog = new System.Windows.Forms.DataGridView();
            this.panelEx_RunLog = new DevComponents.DotNetBar.PanelEx();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX_RunGenerateExcel = new DevComponents.DotNetBar.ButtonX();
            this.myPageControl_RunLog = new MyControls.MyPageControl();
            this.groupPanel_RunLog = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dataGridView_RunLog = new System.Windows.Forms.DataGridView();
            this.panelEx_Top = new DevComponents.DotNetBar.PanelEx();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX_AlarmGenerateExcel = new DevComponents.DotNetBar.ButtonX();
            this.myPageControl_AlarmLog = new MyControls.MyPageControl();
            this.groupPanel_AlarmLog = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dataGridView_AlarmLog = new System.Windows.Forms.DataGridView();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_AlarmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_AlarmDeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_AlarmType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_AlarmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_AlarmLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_AlarmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_AlarmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DisposeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_AlarmOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Lon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Lat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Alt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_RunLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OperationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OperationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_RunOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_OperationContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnErrLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ErrType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ErrTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ErrClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ErrMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ErrContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx_Log.SuspendLayout();
            this.panelEx_Bottom.SuspendLayout();
            this.panelEx_ErrLog.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.groupPanel_ErrLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ErrLog)).BeginInit();
            this.panelEx_RunLog.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.groupPanel_RunLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RunLog)).BeginInit();
            this.panelEx_Top.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.groupPanel_AlarmLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AlarmLog)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx_Log
            // 
            this.panelEx_Log.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Log.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Log.Controls.Add(this.panelEx_Bottom);
            this.panelEx_Log.Controls.Add(this.panelEx_Top);
            this.panelEx_Log.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_Log.Location = new System.Drawing.Point(0, 0);
            this.panelEx_Log.Name = "panelEx_Log";
            this.panelEx_Log.Size = new System.Drawing.Size(1904, 992);
            this.panelEx_Log.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Log.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_Log.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_Log.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Log.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Log.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Log.Style.GradientAngle = 90;
            this.panelEx_Log.TabIndex = 0;
            this.panelEx_Log.Text = "panelEx1";
            // 
            // panelEx_Bottom
            // 
            this.panelEx_Bottom.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Bottom.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Bottom.Controls.Add(this.panelEx_ErrLog);
            this.panelEx_Bottom.Controls.Add(this.panelEx_RunLog);
            this.panelEx_Bottom.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_Bottom.Location = new System.Drawing.Point(0, 491);
            this.panelEx_Bottom.Name = "panelEx_Bottom";
            this.panelEx_Bottom.Size = new System.Drawing.Size(1904, 501);
            this.panelEx_Bottom.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Bottom.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_Bottom.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_Bottom.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Bottom.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Bottom.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Bottom.Style.GradientAngle = 90;
            this.panelEx_Bottom.TabIndex = 14;
            this.panelEx_Bottom.Text = "panelEx1";
            // 
            // panelEx_ErrLog
            // 
            this.panelEx_ErrLog.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_ErrLog.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_ErrLog.Controls.Add(this.panelEx3);
            this.panelEx_ErrLog.Controls.Add(this.groupPanel_ErrLog);
            this.panelEx_ErrLog.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_ErrLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_ErrLog.Location = new System.Drawing.Point(954, 0);
            this.panelEx_ErrLog.Name = "panelEx_ErrLog";
            this.panelEx_ErrLog.Size = new System.Drawing.Size(950, 501);
            this.panelEx_ErrLog.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_ErrLog.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_ErrLog.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_ErrLog.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_ErrLog.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_ErrLog.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_ErrLog.Style.GradientAngle = 90;
            this.panelEx_ErrLog.TabIndex = 23;
            this.panelEx_ErrLog.Text = "panelEx4";
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.buttonX_ErrGenerateExcel);
            this.panelEx3.Controls.Add(this.myPageControl_ErrLog);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx3.Location = new System.Drawing.Point(0, 456);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(950, 45);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 9;
            // 
            // buttonX_ErrGenerateExcel
            // 
            this.buttonX_ErrGenerateExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_ErrGenerateExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_ErrGenerateExcel.Location = new System.Drawing.Point(6, 5);
            this.buttonX_ErrGenerateExcel.Name = "buttonX_ErrGenerateExcel";
            this.buttonX_ErrGenerateExcel.Size = new System.Drawing.Size(75, 34);
            this.buttonX_ErrGenerateExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_ErrGenerateExcel.TabIndex = 25;
            this.buttonX_ErrGenerateExcel.Text = "导出报表";
            this.buttonX_ErrGenerateExcel.Click += new System.EventHandler(this.buttonX_ErrGenerateExcel_Click);
            // 
            // myPageControl_ErrLog
            // 
            this.myPageControl_ErrLog.BackColor = System.Drawing.Color.Transparent;
            this.myPageControl_ErrLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.myPageControl_ErrLog.Location = new System.Drawing.Point(209, 0);
            this.myPageControl_ErrLog.Name = "myPageControl_ErrLog";
            this.myPageControl_ErrLog.PageIndex = 1;
            this.myPageControl_ErrLog.PageRecordCount = 0;
            this.myPageControl_ErrLog.PageRecordNumber = 20;
            this.myPageControl_ErrLog.Size = new System.Drawing.Size(741, 45);
            this.myPageControl_ErrLog.TabIndex = 8;
            this.myPageControl_ErrLog.OnPageChanged += new System.EventHandler(this.myPageControl_ErrLog_OnPageChanged);
            // 
            // groupPanel_ErrLog
            // 
            this.groupPanel_ErrLog.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_ErrLog.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_ErrLog.Controls.Add(this.dataGridView_ErrLog);
            this.groupPanel_ErrLog.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel_ErrLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel_ErrLog.Font = new System.Drawing.Font("宋体", 9F);
            this.groupPanel_ErrLog.Location = new System.Drawing.Point(0, 0);
            this.groupPanel_ErrLog.Name = "groupPanel_ErrLog";
            this.groupPanel_ErrLog.Size = new System.Drawing.Size(950, 381);
            // 
            // 
            // 
            this.groupPanel_ErrLog.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_ErrLog.Style.BackColorGradientAngle = 90;
            this.groupPanel_ErrLog.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_ErrLog.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_ErrLog.Style.BorderBottomWidth = 1;
            this.groupPanel_ErrLog.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_ErrLog.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_ErrLog.Style.BorderLeftWidth = 1;
            this.groupPanel_ErrLog.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_ErrLog.Style.BorderRightWidth = 1;
            this.groupPanel_ErrLog.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_ErrLog.Style.BorderTopWidth = 1;
            this.groupPanel_ErrLog.Style.CornerDiameter = 4;
            this.groupPanel_ErrLog.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_ErrLog.Style.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel_ErrLog.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_ErrLog.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_ErrLog.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_ErrLog.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_ErrLog.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_ErrLog.TabIndex = 7;
            this.groupPanel_ErrLog.Text = "异常日志";
            // 
            // dataGridView_ErrLog
            // 
            this.dataGridView_ErrLog.AllowUserToAddRows = false;
            this.dataGridView_ErrLog.AllowUserToDeleteRows = false;
            this.dataGridView_ErrLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ErrLog.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ErrLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_ErrLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ErrLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnErrLogID,
            this.Column_ErrType,
            this.Column_ErrTime,
            this.Column_ErrClass,
            this.Column_ErrMethod,
            this.Column_ErrContent});
            this.dataGridView_ErrLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ErrLog.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_ErrLog.Name = "dataGridView_ErrLog";
            this.dataGridView_ErrLog.ReadOnly = true;
            this.dataGridView_ErrLog.RowTemplate.Height = 23;
            this.dataGridView_ErrLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ErrLog.Size = new System.Drawing.Size(944, 348);
            this.dataGridView_ErrLog.TabIndex = 0;
            this.dataGridView_ErrLog.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ErrLog_CellDoubleClick);
            // 
            // panelEx_RunLog
            // 
            this.panelEx_RunLog.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_RunLog.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_RunLog.Controls.Add(this.panelEx2);
            this.panelEx_RunLog.Controls.Add(this.groupPanel_RunLog);
            this.panelEx_RunLog.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_RunLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx_RunLog.Location = new System.Drawing.Point(0, 0);
            this.panelEx_RunLog.Name = "panelEx_RunLog";
            this.panelEx_RunLog.Size = new System.Drawing.Size(954, 501);
            this.panelEx_RunLog.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_RunLog.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_RunLog.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_RunLog.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_RunLog.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_RunLog.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_RunLog.Style.GradientAngle = 90;
            this.panelEx_RunLog.TabIndex = 19;
            this.panelEx_RunLog.Text = "panelEx3";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.buttonX_RunGenerateExcel);
            this.panelEx2.Controls.Add(this.myPageControl_RunLog);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 456);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(954, 45);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 8;
            // 
            // buttonX_RunGenerateExcel
            // 
            this.buttonX_RunGenerateExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_RunGenerateExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_RunGenerateExcel.Location = new System.Drawing.Point(12, 5);
            this.buttonX_RunGenerateExcel.Name = "buttonX_RunGenerateExcel";
            this.buttonX_RunGenerateExcel.Size = new System.Drawing.Size(75, 34);
            this.buttonX_RunGenerateExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_RunGenerateExcel.TabIndex = 24;
            this.buttonX_RunGenerateExcel.Text = "导出报表";
            this.buttonX_RunGenerateExcel.Click += new System.EventHandler(this.buttonX_RunGenerateExcel_Click);
            // 
            // myPageControl_RunLog
            // 
            this.myPageControl_RunLog.BackColor = System.Drawing.Color.Transparent;
            this.myPageControl_RunLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.myPageControl_RunLog.Location = new System.Drawing.Point(213, 0);
            this.myPageControl_RunLog.Name = "myPageControl_RunLog";
            this.myPageControl_RunLog.PageIndex = 1;
            this.myPageControl_RunLog.PageRecordCount = 0;
            this.myPageControl_RunLog.PageRecordNumber = 20;
            this.myPageControl_RunLog.Size = new System.Drawing.Size(741, 45);
            this.myPageControl_RunLog.TabIndex = 0;
            this.myPageControl_RunLog.OnPageChanged += new System.EventHandler(this.myPageControl_RunLog_OnPageChanged);
            // 
            // groupPanel_RunLog
            // 
            this.groupPanel_RunLog.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_RunLog.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_RunLog.Controls.Add(this.dataGridView_RunLog);
            this.groupPanel_RunLog.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel_RunLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel_RunLog.Font = new System.Drawing.Font("宋体", 9F);
            this.groupPanel_RunLog.Location = new System.Drawing.Point(0, 0);
            this.groupPanel_RunLog.Name = "groupPanel_RunLog";
            this.groupPanel_RunLog.Size = new System.Drawing.Size(954, 501);
            // 
            // 
            // 
            this.groupPanel_RunLog.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_RunLog.Style.BackColorGradientAngle = 90;
            this.groupPanel_RunLog.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_RunLog.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_RunLog.Style.BorderBottomWidth = 1;
            this.groupPanel_RunLog.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_RunLog.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_RunLog.Style.BorderLeftWidth = 1;
            this.groupPanel_RunLog.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_RunLog.Style.BorderRightWidth = 1;
            this.groupPanel_RunLog.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_RunLog.Style.BorderTopWidth = 1;
            this.groupPanel_RunLog.Style.CornerDiameter = 4;
            this.groupPanel_RunLog.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_RunLog.Style.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel_RunLog.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_RunLog.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_RunLog.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_RunLog.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_RunLog.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_RunLog.TabIndex = 7;
            this.groupPanel_RunLog.Text = "运行日志";
            // 
            // dataGridView_RunLog
            // 
            this.dataGridView_RunLog.AllowUserToAddRows = false;
            this.dataGridView_RunLog.AllowUserToDeleteRows = false;
            this.dataGridView_RunLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_RunLog.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_RunLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_RunLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RunLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_RunLogID,
            this.Column_OperationType,
            this.Column_OperationTime,
            this.Column_RunOperator,
            this.Column_OperationContent});
            this.dataGridView_RunLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_RunLog.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_RunLog.Name = "dataGridView_RunLog";
            this.dataGridView_RunLog.ReadOnly = true;
            this.dataGridView_RunLog.RowTemplate.Height = 23;
            this.dataGridView_RunLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_RunLog.Size = new System.Drawing.Size(948, 468);
            this.dataGridView_RunLog.TabIndex = 1;
            // 
            // panelEx_Top
            // 
            this.panelEx_Top.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Top.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Top.Controls.Add(this.panelEx1);
            this.panelEx_Top.Controls.Add(this.groupPanel_AlarmLog);
            this.panelEx_Top.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx_Top.Location = new System.Drawing.Point(0, 0);
            this.panelEx_Top.Name = "panelEx_Top";
            this.panelEx_Top.Size = new System.Drawing.Size(1904, 491);
            this.panelEx_Top.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Top.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_Top.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_Top.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Top.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Top.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Top.Style.GradientAngle = 90;
            this.panelEx_Top.TabIndex = 10;
            this.panelEx_Top.Text = "panelEx1";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.buttonX_AlarmGenerateExcel);
            this.panelEx1.Controls.Add(this.myPageControl_AlarmLog);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 446);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1904, 45);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 10;
            // 
            // buttonX_AlarmGenerateExcel
            // 
            this.buttonX_AlarmGenerateExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_AlarmGenerateExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_AlarmGenerateExcel.Location = new System.Drawing.Point(12, 5);
            this.buttonX_AlarmGenerateExcel.Name = "buttonX_AlarmGenerateExcel";
            this.buttonX_AlarmGenerateExcel.Size = new System.Drawing.Size(75, 34);
            this.buttonX_AlarmGenerateExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_AlarmGenerateExcel.TabIndex = 23;
            this.buttonX_AlarmGenerateExcel.Text = "导出报表";
            this.buttonX_AlarmGenerateExcel.Click += new System.EventHandler(this.buttonX_AlarmGenerateExcel_Click);
            // 
            // myPageControl_AlarmLog
            // 
            this.myPageControl_AlarmLog.BackColor = System.Drawing.Color.Transparent;
            this.myPageControl_AlarmLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.myPageControl_AlarmLog.Location = new System.Drawing.Point(954, 0);
            this.myPageControl_AlarmLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.myPageControl_AlarmLog.Name = "myPageControl_AlarmLog";
            this.myPageControl_AlarmLog.PageIndex = 1;
            this.myPageControl_AlarmLog.PageRecordCount = 0;
            this.myPageControl_AlarmLog.PageRecordNumber = 20;
            this.myPageControl_AlarmLog.Size = new System.Drawing.Size(950, 45);
            this.myPageControl_AlarmLog.TabIndex = 8;
            this.myPageControl_AlarmLog.OnPageChanged += new System.EventHandler(this.myPageControl_AlarmLog_OnPageChanged);
            // 
            // groupPanel_AlarmLog
            // 
            this.groupPanel_AlarmLog.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_AlarmLog.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_AlarmLog.Controls.Add(this.dataGridView_AlarmLog);
            this.groupPanel_AlarmLog.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel_AlarmLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel_AlarmLog.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel_AlarmLog.Location = new System.Drawing.Point(0, 0);
            this.groupPanel_AlarmLog.Name = "groupPanel_AlarmLog";
            this.groupPanel_AlarmLog.Size = new System.Drawing.Size(1904, 491);
            // 
            // 
            // 
            this.groupPanel_AlarmLog.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_AlarmLog.Style.BackColorGradientAngle = 90;
            this.groupPanel_AlarmLog.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_AlarmLog.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_AlarmLog.Style.BorderBottomWidth = 1;
            this.groupPanel_AlarmLog.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_AlarmLog.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_AlarmLog.Style.BorderLeftWidth = 1;
            this.groupPanel_AlarmLog.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_AlarmLog.Style.BorderRightWidth = 1;
            this.groupPanel_AlarmLog.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_AlarmLog.Style.BorderTopWidth = 1;
            this.groupPanel_AlarmLog.Style.CornerDiameter = 4;
            this.groupPanel_AlarmLog.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_AlarmLog.Style.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel_AlarmLog.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_AlarmLog.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_AlarmLog.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_AlarmLog.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_AlarmLog.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_AlarmLog.TabIndex = 9;
            this.groupPanel_AlarmLog.Text = "报警日志";
            // 
            // dataGridView_AlarmLog
            // 
            this.dataGridView_AlarmLog.AllowUserToAddRows = false;
            this.dataGridView_AlarmLog.AllowUserToDeleteRows = false;
            this.dataGridView_AlarmLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_AlarmLog.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridView_AlarmLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_AlarmLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_AlarmLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_AlarmLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ID,
            this.Column_AlarmID,
            this.Column_AlarmDeviceID,
            this.Column_AlarmType,
            this.Column_AlarmName,
            this.Column_AlarmLevel,
            this.Column_AlarmTime,
            this.Column_AlarmStatus,
            this.Column_DisposeTime,
            this.Column_AlarmOperator,
            this.Column_Lon,
            this.Column_Lat,
            this.Column_Alt});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_AlarmLog.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_AlarmLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_AlarmLog.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_AlarmLog.MultiSelect = false;
            this.dataGridView_AlarmLog.Name = "dataGridView_AlarmLog";
            this.dataGridView_AlarmLog.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_AlarmLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_AlarmLog.RowTemplate.Height = 23;
            this.dataGridView_AlarmLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_AlarmLog.Size = new System.Drawing.Size(1898, 458);
            this.dataGridView_AlarmLog.TabIndex = 1;
            // 
            // Column_ID
            // 
            this.Column_ID.DataPropertyName = "ID";
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.ReadOnly = true;
            this.Column_ID.Visible = false;
            // 
            // Column_AlarmID
            // 
            this.Column_AlarmID.DataPropertyName = "AlarmID";
            this.Column_AlarmID.HeaderText = "报警唯一编号";
            this.Column_AlarmID.Name = "Column_AlarmID";
            this.Column_AlarmID.ReadOnly = true;
            // 
            // Column_AlarmDeviceID
            // 
            this.Column_AlarmDeviceID.DataPropertyName = "AlarmDeviceID";
            this.Column_AlarmDeviceID.HeaderText = "报警设备编号";
            this.Column_AlarmDeviceID.Name = "Column_AlarmDeviceID";
            this.Column_AlarmDeviceID.ReadOnly = true;
            this.Column_AlarmDeviceID.Visible = false;
            // 
            // Column_AlarmType
            // 
            this.Column_AlarmType.DataPropertyName = "AlarmType";
            this.Column_AlarmType.HeaderText = "报警类型";
            this.Column_AlarmType.Name = "Column_AlarmType";
            this.Column_AlarmType.ReadOnly = true;
            // 
            // Column_AlarmName
            // 
            this.Column_AlarmName.DataPropertyName = "AlarmName";
            this.Column_AlarmName.HeaderText = "报警名称";
            this.Column_AlarmName.Name = "Column_AlarmName";
            this.Column_AlarmName.ReadOnly = true;
            // 
            // Column_AlarmLevel
            // 
            this.Column_AlarmLevel.DataPropertyName = "AlarmLevel";
            this.Column_AlarmLevel.HeaderText = "报警等级";
            this.Column_AlarmLevel.Name = "Column_AlarmLevel";
            this.Column_AlarmLevel.ReadOnly = true;
            // 
            // Column_AlarmTime
            // 
            this.Column_AlarmTime.DataPropertyName = "AlarmTime";
            this.Column_AlarmTime.HeaderText = "报警时间";
            this.Column_AlarmTime.Name = "Column_AlarmTime";
            this.Column_AlarmTime.ReadOnly = true;
            // 
            // Column_AlarmStatus
            // 
            this.Column_AlarmStatus.DataPropertyName = "AlarmStatus";
            this.Column_AlarmStatus.HeaderText = "报警状态";
            this.Column_AlarmStatus.Name = "Column_AlarmStatus";
            this.Column_AlarmStatus.ReadOnly = true;
            // 
            // Column_DisposeTime
            // 
            this.Column_DisposeTime.DataPropertyName = "DisposeTime";
            this.Column_DisposeTime.HeaderText = "处理时间";
            this.Column_DisposeTime.Name = "Column_DisposeTime";
            this.Column_DisposeTime.ReadOnly = true;
            // 
            // Column_AlarmOperator
            // 
            this.Column_AlarmOperator.DataPropertyName = "Operator";
            this.Column_AlarmOperator.HeaderText = "操作人员";
            this.Column_AlarmOperator.Name = "Column_AlarmOperator";
            this.Column_AlarmOperator.ReadOnly = true;
            // 
            // Column_Lon
            // 
            this.Column_Lon.DataPropertyName = "Lon";
            this.Column_Lon.HeaderText = "经度";
            this.Column_Lon.Name = "Column_Lon";
            this.Column_Lon.ReadOnly = true;
            // 
            // Column_Lat
            // 
            this.Column_Lat.DataPropertyName = "Lat";
            this.Column_Lat.HeaderText = "纬度";
            this.Column_Lat.Name = "Column_Lat";
            this.Column_Lat.ReadOnly = true;
            // 
            // Column_Alt
            // 
            this.Column_Alt.DataPropertyName = "Alt";
            this.Column_Alt.HeaderText = "高度";
            this.Column_Alt.Name = "Column_Alt";
            this.Column_Alt.ReadOnly = true;
            // 
            // Column_RunLogID
            // 
            this.Column_RunLogID.DataPropertyName = "ID";
            this.Column_RunLogID.HeaderText = "ID";
            this.Column_RunLogID.Name = "Column_RunLogID";
            this.Column_RunLogID.ReadOnly = true;
            this.Column_RunLogID.Visible = false;
            // 
            // Column_OperationType
            // 
            this.Column_OperationType.DataPropertyName = "OperationType";
            this.Column_OperationType.HeaderText = "操作类型";
            this.Column_OperationType.Name = "Column_OperationType";
            this.Column_OperationType.ReadOnly = true;
            // 
            // Column_OperationTime
            // 
            this.Column_OperationTime.DataPropertyName = "OperationTime";
            this.Column_OperationTime.HeaderText = "操作时间";
            this.Column_OperationTime.Name = "Column_OperationTime";
            this.Column_OperationTime.ReadOnly = true;
            // 
            // Column_RunOperator
            // 
            this.Column_RunOperator.DataPropertyName = "Operator";
            this.Column_RunOperator.HeaderText = "操作人员";
            this.Column_RunOperator.Name = "Column_RunOperator";
            this.Column_RunOperator.ReadOnly = true;
            // 
            // Column_OperationContent
            // 
            this.Column_OperationContent.DataPropertyName = "OperationContent";
            this.Column_OperationContent.HeaderText = "操作内容";
            this.Column_OperationContent.Name = "Column_OperationContent";
            this.Column_OperationContent.ReadOnly = true;
            // 
            // ColumnErrLogID
            // 
            this.ColumnErrLogID.DataPropertyName = "ID";
            this.ColumnErrLogID.HeaderText = "ID";
            this.ColumnErrLogID.Name = "ColumnErrLogID";
            this.ColumnErrLogID.ReadOnly = true;
            this.ColumnErrLogID.Visible = false;
            // 
            // Column_ErrType
            // 
            this.Column_ErrType.DataPropertyName = "ErrType";
            this.Column_ErrType.HeaderText = "异常类型";
            this.Column_ErrType.Name = "Column_ErrType";
            this.Column_ErrType.ReadOnly = true;
            // 
            // Column_ErrTime
            // 
            this.Column_ErrTime.DataPropertyName = "ErrTime";
            this.Column_ErrTime.HeaderText = "异常时间";
            this.Column_ErrTime.Name = "Column_ErrTime";
            this.Column_ErrTime.ReadOnly = true;
            // 
            // Column_ErrClass
            // 
            this.Column_ErrClass.DataPropertyName = "ErrClass";
            this.Column_ErrClass.HeaderText = "异常类";
            this.Column_ErrClass.Name = "Column_ErrClass";
            this.Column_ErrClass.ReadOnly = true;
            // 
            // Column_ErrMethod
            // 
            this.Column_ErrMethod.DataPropertyName = "ErrMethod";
            this.Column_ErrMethod.HeaderText = "异常方法";
            this.Column_ErrMethod.Name = "Column_ErrMethod";
            this.Column_ErrMethod.ReadOnly = true;
            // 
            // Column_ErrContent
            // 
            this.Column_ErrContent.DataPropertyName = "ErrContent";
            this.Column_ErrContent.HeaderText = "异常分析处理";
            this.Column_ErrContent.Name = "Column_ErrContent";
            this.Column_ErrContent.ReadOnly = true;
            // 
            // LogServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 992);
            this.Controls.Add(this.panelEx_Log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LogServerForm";
            this.Text = "LogServerForm";
            this.panelEx_Log.ResumeLayout(false);
            this.panelEx_Bottom.ResumeLayout(false);
            this.panelEx_ErrLog.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.groupPanel_ErrLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ErrLog)).EndInit();
            this.panelEx_RunLog.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.groupPanel_RunLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RunLog)).EndInit();
            this.panelEx_Top.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.groupPanel_AlarmLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AlarmLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx_Log;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel_AlarmLog;
        private System.Windows.Forms.DataGridView dataGridView_AlarmLog;
        private DevComponents.DotNetBar.PanelEx panelEx_Top;
        private MyControls.MyPageControl myPageControl_AlarmLog;
        private DevComponents.DotNetBar.PanelEx panelEx_Bottom;
        private DevComponents.DotNetBar.PanelEx panelEx_RunLog;
        private MyControls.MyPageControl myPageControl_RunLog;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel_RunLog;
        private System.Windows.Forms.DataGridView dataGridView_RunLog;
        private DevComponents.DotNetBar.PanelEx panelEx_ErrLog;
        private MyControls.MyPageControl myPageControl_ErrLog;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel_ErrLog;
        private System.Windows.Forms.DataGridView dataGridView_ErrLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_AlarmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_AlarmDeviceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_AlarmType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_AlarmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_AlarmLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_AlarmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_AlarmStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DisposeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_AlarmOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Lon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Lat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Alt;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX buttonX_AlarmGenerateExcel;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.ButtonX buttonX_RunGenerateExcel;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ButtonX buttonX_ErrGenerateExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RunLogID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OperationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OperationTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RunOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_OperationContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnErrLogID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ErrType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ErrTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ErrClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ErrMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ErrContent;
    }
}