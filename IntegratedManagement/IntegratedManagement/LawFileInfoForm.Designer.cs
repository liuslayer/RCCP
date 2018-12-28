namespace IntegratedManagement
{
    partial class LawFileInfoForm
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
            this.dataGridView_LawFileInfo = new System.Windows.Forms.DataGridView();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx_Search = new DevComponents.DotNetBar.PanelEx();
            this.dateTimeInput_TimeEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonX_Clear = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Search = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX_LawFileName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX_IssueOrganization = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX_LawFileType = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dateTimeInput_TimeStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.flyout_Search = new DevComponents.DotNetBar.Controls.Flyout(this.components);
            this.buttonX_GenerateExcel = new DevComponents.DotNetBar.ButtonX();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LawFileInfo)).BeginInit();
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
            this.panelEx3.TabIndex = 30;
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
            // dataGridView_LawFileInfo
            // 
            this.dataGridView_LawFileInfo.AllowUserToAddRows = false;
            this.dataGridView_LawFileInfo.AllowUserToDeleteRows = false;
            this.dataGridView_LawFileInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_LawFileInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_LawFileInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26,
            this.Column27});
            this.dataGridView_LawFileInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_LawFileInfo.Location = new System.Drawing.Point(0, 55);
            this.dataGridView_LawFileInfo.Name = "dataGridView_LawFileInfo";
            this.dataGridView_LawFileInfo.ReadOnly = true;
            this.dataGridView_LawFileInfo.RowTemplate.Height = 23;
            this.dataGridView_LawFileInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_LawFileInfo.Size = new System.Drawing.Size(1000, 495);
            this.dataGridView_LawFileInfo.TabIndex = 46;
            this.dataGridView_LawFileInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_LawFileInfo_CellDoubleClick);
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "ID";
            this.Column19.HeaderText = "ID";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            this.Column19.Visible = false;
            // 
            // Column20
            // 
            this.Column20.DataPropertyName = "LawFileName";
            this.Column20.HeaderText = "文件名";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            // 
            // Column21
            // 
            this.Column21.DataPropertyName = "LawFilePath";
            this.Column21.HeaderText = "文件路径";
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            this.Column21.Visible = false;
            // 
            // Column22
            // 
            this.Column22.DataPropertyName = "LawFileType";
            this.Column22.HeaderText = "文件类型";
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            // 
            // Column23
            // 
            this.Column23.DataPropertyName = "IssueTime";
            this.Column23.HeaderText = "颁发时间";
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            // 
            // Column24
            // 
            this.Column24.DataPropertyName = "IssueOrganization";
            this.Column24.HeaderText = "颁发机构";
            this.Column24.Name = "Column24";
            this.Column24.ReadOnly = true;
            // 
            // Column25
            // 
            this.Column25.DataPropertyName = "IssueVersion";
            this.Column25.HeaderText = "颁发版本号";
            this.Column25.Name = "Column25";
            this.Column25.ReadOnly = true;
            // 
            // Column26
            // 
            this.Column26.DataPropertyName = "Description";
            this.Column26.HeaderText = "描述";
            this.Column26.Name = "Column26";
            this.Column26.ReadOnly = true;
            // 
            // Column27
            // 
            this.Column27.DataPropertyName = "Mark";
            this.Column27.HeaderText = "Mark";
            this.Column27.Name = "Column27";
            this.Column27.ReadOnly = true;
            this.Column27.Visible = false;
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
            this.panelEx_Search.Controls.Add(this.textBoxX_LawFileName);
            this.panelEx_Search.Controls.Add(this.labelX5);
            this.panelEx_Search.Controls.Add(this.textBoxX_IssueOrganization);
            this.panelEx_Search.Controls.Add(this.labelX4);
            this.panelEx_Search.Controls.Add(this.textBoxX_LawFileType);
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
            this.panelEx_Search.TabIndex = 50;
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
            this.labelX6.Text = "文件名：";
            // 
            // textBoxX_LawFileName
            // 
            // 
            // 
            // 
            this.textBoxX_LawFileName.Border.Class = "TextBoxBorder";
            this.textBoxX_LawFileName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_LawFileName.Location = new System.Drawing.Point(158, 200);
            this.textBoxX_LawFileName.Name = "textBoxX_LawFileName";
            this.textBoxX_LawFileName.PreventEnterBeep = true;
            this.textBoxX_LawFileName.Size = new System.Drawing.Size(183, 21);
            this.textBoxX_LawFileName.TabIndex = 14;
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
            this.labelX5.Text = "颁发机构：";
            // 
            // textBoxX_IssueOrganization
            // 
            // 
            // 
            // 
            this.textBoxX_IssueOrganization.Border.Class = "TextBoxBorder";
            this.textBoxX_IssueOrganization.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_IssueOrganization.Location = new System.Drawing.Point(158, 157);
            this.textBoxX_IssueOrganization.Name = "textBoxX_IssueOrganization";
            this.textBoxX_IssueOrganization.PreventEnterBeep = true;
            this.textBoxX_IssueOrganization.Size = new System.Drawing.Size(183, 21);
            this.textBoxX_IssueOrganization.TabIndex = 12;
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
            this.labelX4.Text = "文件类型：";
            // 
            // textBoxX_LawFileType
            // 
            // 
            // 
            // 
            this.textBoxX_LawFileType.Border.Class = "TextBoxBorder";
            this.textBoxX_LawFileType.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_LawFileType.Location = new System.Drawing.Point(158, 109);
            this.textBoxX_LawFileType.Name = "textBoxX_LawFileType";
            this.textBoxX_LawFileType.PreventEnterBeep = true;
            this.textBoxX_LawFileType.Size = new System.Drawing.Size(183, 21);
            this.textBoxX_LawFileType.TabIndex = 10;
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
            this.buttonX_GenerateExcel.TabIndex = 24;
            this.buttonX_GenerateExcel.Text = "导出报表";
            this.buttonX_GenerateExcel.Click += new System.EventHandler(this.buttonX_GenerateExcel_Click);
            // 
            // LawFileInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.panelEx_Search);
            this.Controls.Add(this.dataGridView_LawFileInfo);
            this.Controls.Add(this.panelEx3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LawFileInfoForm";
            this.Text = "LawFileInfoForm";
            this.Load += new System.EventHandler(this.LawFileInfoForm_Load);
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LawFileInfo)).EndInit();
            this.panelEx_Search.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_TimeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_TimeStart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ButtonX buttonX_Add;
        private DevComponents.DotNetBar.ButtonX buttonX_SearchFlyout;
        private DevComponents.DotNetBar.ButtonX buttonX_Edit;
        private DevComponents.DotNetBar.ButtonX buttonX_Del;
        private System.Windows.Forms.DataGridView dataGridView_LawFileInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column27;
        private DevComponents.DotNetBar.PanelEx panelEx_Search;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput_TimeEnd;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX buttonX_Clear;
        private DevComponents.DotNetBar.ButtonX buttonX_Search;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX_LawFileName;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX_IssueOrganization;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX_LawFileType;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput_TimeStart;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.Flyout flyout_Search;
        private DevComponents.DotNetBar.ButtonX buttonX_GenerateExcel;
    }
}