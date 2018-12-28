namespace IntegratedManagement
{
    partial class AlarmInfoForm
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
            this.dataGridView_AlarmInfo = new System.Windows.Forms.DataGridView();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx_Search = new DevComponents.DotNetBar.PanelEx();
            this.comboBoxEx_TargetAttribute = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboBoxEx_AlarmType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.dateTimeInput_TimeEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonX_Clear = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Search = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.dateTimeInput_TimeStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.flyout_Search = new DevComponents.DotNetBar.Controls.Flyout(this.components);
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AlarmInfo)).BeginInit();
            this.panelEx_Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_TimeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_TimeStart)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
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
            this.panelEx3.TabIndex = 34;
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
            this.buttonX_Edit.Visible = false;
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
            // dataGridView_AlarmInfo
            // 
            this.dataGridView_AlarmInfo.AllowUserToAddRows = false;
            this.dataGridView_AlarmInfo.AllowUserToDeleteRows = false;
            this.dataGridView_AlarmInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_AlarmInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_AlarmInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column28,
            this.Column29,
            this.Column30,
            this.Column31,
            this.Column32,
            this.Column33,
            this.Column34,
            this.Column35});
            this.dataGridView_AlarmInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_AlarmInfo.Location = new System.Drawing.Point(0, 55);
            this.dataGridView_AlarmInfo.Name = "dataGridView_AlarmInfo";
            this.dataGridView_AlarmInfo.ReadOnly = true;
            this.dataGridView_AlarmInfo.RowTemplate.Height = 23;
            this.dataGridView_AlarmInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_AlarmInfo.Size = new System.Drawing.Size(1000, 495);
            this.dataGridView_AlarmInfo.TabIndex = 35;
            // 
            // Column28
            // 
            this.Column28.DataPropertyName = "ID";
            this.Column28.HeaderText = "ID";
            this.Column28.Name = "Column28";
            this.Column28.ReadOnly = true;
            this.Column28.Visible = false;
            // 
            // Column29
            // 
            this.Column29.DataPropertyName = "AlarmID";
            this.Column29.HeaderText = "AlarmID";
            this.Column29.Name = "Column29";
            this.Column29.ReadOnly = true;
            this.Column29.Visible = false;
            // 
            // Column30
            // 
            this.Column30.DataPropertyName = "AlarmTime";
            this.Column30.HeaderText = "报警时间";
            this.Column30.Name = "Column30";
            this.Column30.ReadOnly = true;
            // 
            // Column31
            // 
            this.Column31.DataPropertyName = "AlarmLocation";
            this.Column31.HeaderText = "报警地点";
            this.Column31.Name = "Column31";
            this.Column31.ReadOnly = true;
            // 
            // Column32
            // 
            this.Column32.DataPropertyName = "AlarmType";
            this.Column32.HeaderText = "报警类别";
            this.Column32.Name = "Column32";
            this.Column32.ReadOnly = true;
            // 
            // Column33
            // 
            this.Column33.DataPropertyName = "TargetAttribute";
            this.Column33.HeaderText = "目标性质";
            this.Column33.Name = "Column33";
            this.Column33.ReadOnly = true;
            // 
            // Column34
            // 
            this.Column34.DataPropertyName = "Description";
            this.Column34.HeaderText = "事件说明";
            this.Column34.Name = "Column34";
            this.Column34.ReadOnly = true;
            // 
            // Column35
            // 
            this.Column35.DataPropertyName = "Mark";
            this.Column35.HeaderText = "Mark";
            this.Column35.Name = "Column35";
            this.Column35.ReadOnly = true;
            this.Column35.Visible = false;
            // 
            // panelEx_Search
            // 
            this.panelEx_Search.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Search.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Search.Controls.Add(this.comboBoxEx_TargetAttribute);
            this.panelEx_Search.Controls.Add(this.comboBoxEx_AlarmType);
            this.panelEx_Search.Controls.Add(this.dateTimeInput_TimeEnd);
            this.panelEx_Search.Controls.Add(this.labelX1);
            this.panelEx_Search.Controls.Add(this.buttonX_Clear);
            this.panelEx_Search.Controls.Add(this.buttonX_Search);
            this.panelEx_Search.Controls.Add(this.labelX6);
            this.panelEx_Search.Controls.Add(this.labelX5);
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
            this.panelEx_Search.TabIndex = 54;
            this.panelEx_Search.Visible = false;
            // 
            // comboBoxEx_TargetAttribute
            // 
            this.comboBoxEx_TargetAttribute.DisplayMember = "Text";
            this.comboBoxEx_TargetAttribute.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx_TargetAttribute.FormattingEnabled = true;
            this.comboBoxEx_TargetAttribute.ItemHeight = 15;
            this.comboBoxEx_TargetAttribute.Items.AddRange(new object[] {
            this.comboItem6,
            this.comboItem7,
            this.comboItem8});
            this.comboBoxEx_TargetAttribute.Location = new System.Drawing.Point(158, 176);
            this.comboBoxEx_TargetAttribute.Name = "comboBoxEx_TargetAttribute";
            this.comboBoxEx_TargetAttribute.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEx_TargetAttribute.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx_TargetAttribute.TabIndex = 21;
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "其他";
            this.comboItem6.Value = "0";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "人";
            this.comboItem7.Value = "1";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "车";
            this.comboItem8.Value = "2";
            // 
            // comboBoxEx_AlarmType
            // 
            this.comboBoxEx_AlarmType.DisplayMember = "Text";
            this.comboBoxEx_AlarmType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx_AlarmType.FormattingEnabled = true;
            this.comboBoxEx_AlarmType.ItemHeight = 15;
            this.comboBoxEx_AlarmType.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5});
            this.comboBoxEx_AlarmType.Location = new System.Drawing.Point(158, 133);
            this.comboBoxEx_AlarmType.Name = "comboBoxEx_AlarmType";
            this.comboBoxEx_AlarmType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEx_AlarmType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx_AlarmType.TabIndex = 20;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "其他";
            this.comboItem1.Value = "0";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "视频";
            this.comboItem2.Value = "1";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "雷达";
            this.comboItem3.Value = "2";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "震动光缆";
            this.comboItem4.Value = "3";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "微波墙";
            this.comboItem5.Value = "4";
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
            this.dateTimeInput_TimeEnd.Location = new System.Drawing.Point(158, 89);
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
            this.labelX1.Location = new System.Drawing.Point(32, 89);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(120, 23);
            this.labelX1.TabIndex = 18;
            this.labelX1.Text = "起始时间：";
            // 
            // buttonX_Clear
            // 
            this.buttonX_Clear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Clear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Clear.Location = new System.Drawing.Point(223, 237);
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
            this.buttonX_Search.Location = new System.Drawing.Point(68, 237);
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
            this.labelX6.Location = new System.Drawing.Point(32, 176);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(120, 23);
            this.labelX6.TabIndex = 15;
            this.labelX6.Text = "目标性质：";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(32, 133);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(120, 23);
            this.labelX5.TabIndex = 13;
            this.labelX5.Text = "报警类别：";
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
            this.dateTimeInput_TimeStart.Location = new System.Drawing.Point(158, 45);
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
            this.labelX3.Location = new System.Drawing.Point(32, 45);
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
            // AlarmInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.panelEx_Search);
            this.Controls.Add(this.dataGridView_AlarmInfo);
            this.Controls.Add(this.panelEx3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlarmInfoForm";
            this.Text = "AlarmInfoForm";
            this.Load += new System.EventHandler(this.AlarmInfoForm_Load);
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AlarmInfo)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView_AlarmInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column28;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column29;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column30;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column31;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column32;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column33;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column34;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column35;
        private DevComponents.DotNetBar.PanelEx panelEx_Search;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput_TimeEnd;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX buttonX_Clear;
        private DevComponents.DotNetBar.ButtonX buttonX_Search;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput_TimeStart;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx_AlarmType;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx_TargetAttribute;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.DotNetBar.Controls.Flyout flyout_Search;
    }
}