namespace IntegratedManagement
{
    partial class VideoRecForm
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
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX_Add = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_SearchFlyout = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Edit = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Del = new DevComponents.DotNetBar.ButtonX();
            this.dataGridView_CameraInfo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx_Search = new DevComponents.DotNetBar.PanelEx();
            this.dateTimeInput_TimeEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonX_Clear = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Search = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX_EventType = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX_Src = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX_Location = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dateTimeInput_TimeStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.flyout_Search = new DevComponents.DotNetBar.Controls.Flyout(this.components);
            this.buttonX_GenerateExcel = new DevComponents.DotNetBar.ButtonX();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CameraInfo)).BeginInit();
            this.panelEx_Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_TimeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_TimeStart)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.buttonX_GenerateExcel);
            this.panelEx3.Controls.Add(this.buttonX_Add);
            this.panelEx3.Controls.Add(this.buttonX_SearchFlyout);
            this.panelEx3.Controls.Add(this.buttonX_Edit);
            this.panelEx3.Controls.Add(this.buttonX_Del);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(1000, 55);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 4;
            // 
            // buttonX_Add
            // 
            this.buttonX_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Add.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonX_Add.Location = new System.Drawing.Point(775, 0);
            this.buttonX_Add.Name = "buttonX_Add";
            this.buttonX_Add.Size = new System.Drawing.Size(75, 55);
            this.buttonX_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Add.TabIndex = 21;
            this.buttonX_Add.Text = "增加";
            this.buttonX_Add.Click += new System.EventHandler(this.buttonX_Add_Click);
            // 
            // buttonX_SearchFlyout
            // 
            this.buttonX_SearchFlyout.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_SearchFlyout.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_SearchFlyout.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonX_SearchFlyout.Location = new System.Drawing.Point(0, 0);
            this.buttonX_SearchFlyout.Name = "buttonX_SearchFlyout";
            this.buttonX_SearchFlyout.Size = new System.Drawing.Size(103, 55);
            this.buttonX_SearchFlyout.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_SearchFlyout.TabIndex = 13;
            this.buttonX_SearchFlyout.Text = "条件查询";
            // 
            // buttonX_Edit
            // 
            this.buttonX_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Edit.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonX_Edit.Location = new System.Drawing.Point(850, 0);
            this.buttonX_Edit.Name = "buttonX_Edit";
            this.buttonX_Edit.Size = new System.Drawing.Size(75, 55);
            this.buttonX_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Edit.TabIndex = 20;
            this.buttonX_Edit.Text = "修改";
            this.buttonX_Edit.Click += new System.EventHandler(this.buttonX_Edit_Click);
            // 
            // buttonX_Del
            // 
            this.buttonX_Del.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Del.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Del.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonX_Del.Location = new System.Drawing.Point(925, 0);
            this.buttonX_Del.Name = "buttonX_Del";
            this.buttonX_Del.Size = new System.Drawing.Size(75, 55);
            this.buttonX_Del.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Del.TabIndex = 19;
            this.buttonX_Del.Text = "删除";
            this.buttonX_Del.Click += new System.EventHandler(this.buttonX_Del_Click);
            // 
            // dataGridView_CameraInfo
            // 
            this.dataGridView_CameraInfo.AllowUserToAddRows = false;
            this.dataGridView_CameraInfo.AllowUserToDeleteRows = false;
            this.dataGridView_CameraInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_CameraInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_CameraInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column18});
            this.dataGridView_CameraInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_CameraInfo.Location = new System.Drawing.Point(0, 55);
            this.dataGridView_CameraInfo.Name = "dataGridView_CameraInfo";
            this.dataGridView_CameraInfo.ReadOnly = true;
            this.dataGridView_CameraInfo.RowTemplate.Height = 23;
            this.dataGridView_CameraInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_CameraInfo.Size = new System.Drawing.Size(1000, 495);
            this.dataGridView_CameraInfo.TabIndex = 5;
            this.dataGridView_CameraInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CameraInfo_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "VideoRecName";
            this.Column2.HeaderText = "录像名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "VideoRecPath";
            this.Column3.HeaderText = "录像存储路径";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "RecTime";
            this.Column4.HeaderText = "录像时间";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "RecLocation";
            this.Column5.HeaderText = "录像地点";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "RecSrc";
            this.Column11.HeaderText = "信息源";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "EventType";
            this.Column12.HeaderText = "事件性质";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "Description";
            this.Column13.HeaderText = "描述";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "Mark";
            this.Column18.HeaderText = "Mark";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Visible = false;
            // 
            // panelEx_Search
            // 
            this.panelEx_Search.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Search.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Search.Controls.Add(this.dateTimeInput_TimeEnd);
            this.panelEx_Search.Controls.Add(this.labelX1);
            this.panelEx_Search.Controls.Add(this.buttonX_Clear);
            this.panelEx_Search.Controls.Add(this.buttonX_Search);
            this.panelEx_Search.Controls.Add(this.labelX6);
            this.panelEx_Search.Controls.Add(this.textBoxX_EventType);
            this.panelEx_Search.Controls.Add(this.labelX5);
            this.panelEx_Search.Controls.Add(this.textBoxX_Src);
            this.panelEx_Search.Controls.Add(this.labelX4);
            this.panelEx_Search.Controls.Add(this.textBoxX_Location);
            this.panelEx_Search.Controls.Add(this.dateTimeInput_TimeStart);
            this.panelEx_Search.Controls.Add(this.labelX3);
            this.panelEx_Search.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_Search.Location = new System.Drawing.Point(12, 89);
            this.panelEx_Search.Name = "panelEx_Search";
            this.panelEx_Search.Size = new System.Drawing.Size(389, 302);
            this.panelEx_Search.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Search.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_Search.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_Search.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Search.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Search.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Search.Style.GradientAngle = 90;
            this.panelEx_Search.TabIndex = 12;
            this.panelEx_Search.Visible = false;
            // 
            // dateTimeInput_TimeEnd
            // 
            // 
            // 
            // 
            this.dateTimeInput_TimeEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput_TimeEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_TimeEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput_TimeEnd.ButtonDropDown.Visible = true;
            this.dateTimeInput_TimeEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimeInput_TimeEnd.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dateTimeInput_TimeEnd.IsPopupCalendarOpen = false;
            this.dateTimeInput_TimeEnd.Location = new System.Drawing.Point(158, 63);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateTimeInput_TimeEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_TimeEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput_TimeEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput_TimeEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput_TimeEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput_TimeEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput_TimeEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput_TimeEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput_TimeEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput_TimeEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_TimeEnd.MonthCalendar.DisplayMonth = new System.DateTime(2018, 11, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dateTimeInput_TimeEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput_TimeEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput_TimeEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput_TimeEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_TimeEnd.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput_TimeEnd.Name = "dateTimeInput_TimeEnd";
            this.dateTimeInput_TimeEnd.Size = new System.Drawing.Size(200, 21);
            this.dateTimeInput_TimeEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput_TimeEnd.TabIndex = 19;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(32, 63);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(120, 23);
            this.labelX1.TabIndex = 18;
            this.labelX1.Text = "起始时间：";
            // 
            // buttonX_Clear
            // 
            this.buttonX_Clear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Clear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Clear.Location = new System.Drawing.Point(223, 262);
            this.buttonX_Clear.Name = "buttonX_Clear";
            this.buttonX_Clear.Size = new System.Drawing.Size(75, 23);
            this.buttonX_Clear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Clear.TabIndex = 17;
            this.buttonX_Clear.Text = "清空";
            this.buttonX_Clear.Click += new System.EventHandler(this.buttonX_Clear_Click);
            // 
            // buttonX_Search
            // 
            this.buttonX_Search.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Search.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Search.Location = new System.Drawing.Point(68, 262);
            this.buttonX_Search.Name = "buttonX_Search";
            this.buttonX_Search.Size = new System.Drawing.Size(75, 23);
            this.buttonX_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Search.TabIndex = 16;
            this.buttonX_Search.Text = "查询";
            this.buttonX_Search.Click += new System.EventHandler(this.buttonX_Search_Click);
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(32, 201);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(120, 23);
            this.labelX6.TabIndex = 15;
            this.labelX6.Text = "信息事件：";
            // 
            // textBoxX_EventType
            // 
            // 
            // 
            // 
            this.textBoxX_EventType.Border.Class = "TextBoxBorder";
            this.textBoxX_EventType.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_EventType.Location = new System.Drawing.Point(158, 200);
            this.textBoxX_EventType.Name = "textBoxX_EventType";
            this.textBoxX_EventType.PreventEnterBeep = true;
            this.textBoxX_EventType.Size = new System.Drawing.Size(183, 21);
            this.textBoxX_EventType.TabIndex = 14;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(32, 158);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(120, 23);
            this.labelX5.TabIndex = 13;
            this.labelX5.Text = "信息源：";
            // 
            // textBoxX_Src
            // 
            // 
            // 
            // 
            this.textBoxX_Src.Border.Class = "TextBoxBorder";
            this.textBoxX_Src.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_Src.Location = new System.Drawing.Point(158, 157);
            this.textBoxX_Src.Name = "textBoxX_Src";
            this.textBoxX_Src.PreventEnterBeep = true;
            this.textBoxX_Src.Size = new System.Drawing.Size(183, 21);
            this.textBoxX_Src.TabIndex = 12;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(32, 110);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(120, 23);
            this.labelX4.TabIndex = 11;
            this.labelX4.Text = "录像地点：";
            // 
            // textBoxX_Location
            // 
            // 
            // 
            // 
            this.textBoxX_Location.Border.Class = "TextBoxBorder";
            this.textBoxX_Location.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_Location.Location = new System.Drawing.Point(158, 109);
            this.textBoxX_Location.Name = "textBoxX_Location";
            this.textBoxX_Location.PreventEnterBeep = true;
            this.textBoxX_Location.Size = new System.Drawing.Size(183, 21);
            this.textBoxX_Location.TabIndex = 10;
            // 
            // dateTimeInput_TimeStart
            // 
            // 
            // 
            // 
            this.dateTimeInput_TimeStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput_TimeStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_TimeStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput_TimeStart.ButtonDropDown.Visible = true;
            this.dateTimeInput_TimeStart.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimeInput_TimeStart.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dateTimeInput_TimeStart.IsPopupCalendarOpen = false;
            this.dateTimeInput_TimeStart.Location = new System.Drawing.Point(158, 19);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateTimeInput_TimeStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_TimeStart.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput_TimeStart.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput_TimeStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput_TimeStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput_TimeStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput_TimeStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput_TimeStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput_TimeStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput_TimeStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_TimeStart.MonthCalendar.DisplayMonth = new System.DateTime(2018, 11, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dateTimeInput_TimeStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput_TimeStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput_TimeStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput_TimeStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_TimeStart.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput_TimeStart.Name = "dateTimeInput_TimeStart";
            this.dateTimeInput_TimeStart.Size = new System.Drawing.Size(200, 21);
            this.dateTimeInput_TimeStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput_TimeStart.TabIndex = 9;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(32, 19);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(120, 23);
            this.labelX3.TabIndex = 8;
            this.labelX3.Text = "起始时间：";
            // 
            // flyout_Search
            // 
            this.flyout_Search.Content = this.panelEx_Search;
            this.flyout_Search.DropShadow = false;
            this.flyout_Search.TargetControl = this.buttonX_SearchFlyout;
            // 
            // buttonX_GenerateExcel
            // 
            this.buttonX_GenerateExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_GenerateExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_GenerateExcel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonX_GenerateExcel.Location = new System.Drawing.Point(700, 0);
            this.buttonX_GenerateExcel.Name = "buttonX_GenerateExcel";
            this.buttonX_GenerateExcel.Size = new System.Drawing.Size(75, 55);
            this.buttonX_GenerateExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_GenerateExcel.TabIndex = 22;
            this.buttonX_GenerateExcel.Text = "导出报表";
            this.buttonX_GenerateExcel.Click += new System.EventHandler(this.buttonX_GenerateExcel_Click);
            // 
            // VideoRecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.panelEx_Search);
            this.Controls.Add(this.dataGridView_CameraInfo);
            this.Controls.Add(this.panelEx3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VideoRecForm";
            this.Text = "VideoRecForm";
            this.Load += new System.EventHandler(this.VideoRecForm_Load);
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CameraInfo)).EndInit();
            this.panelEx_Search.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_TimeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_TimeStart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ButtonX buttonX_SearchFlyout;
        private System.Windows.Forms.DataGridView dataGridView_CameraInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private DevComponents.DotNetBar.PanelEx panelEx_Search;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput_TimeEnd;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX buttonX_Clear;
        private DevComponents.DotNetBar.ButtonX buttonX_Search;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX_EventType;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX_Src;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX_Location;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput_TimeStart;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.Flyout flyout_Search;
        private DevComponents.DotNetBar.ButtonX buttonX_Add;
        private DevComponents.DotNetBar.ButtonX buttonX_Edit;
        private DevComponents.DotNetBar.ButtonX buttonX_Del;
        private DevComponents.DotNetBar.ButtonX buttonX_GenerateExcel;
    }
}