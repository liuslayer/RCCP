namespace IntegratedManagement
{
    partial class AlarmInfoAddAndEditForm
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.textBoxX_AlarmLocation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxEx_TargetAttribute = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxEx_AlarmType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.buttonX_Cancel = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Save = new DevComponents.DotNetBar.ButtonX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX_Description = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.dateTimeInput_Time = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX_Name = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_Time)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.textBoxX_AlarmLocation);
            this.panelEx1.Controls.Add(this.comboBoxEx_TargetAttribute);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.comboBoxEx_AlarmType);
            this.panelEx1.Controls.Add(this.buttonX_Cancel);
            this.panelEx1.Controls.Add(this.buttonX_Save);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Controls.Add(this.textBoxX_Description);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.dateTimeInput_Time);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX_Name);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(400, 419);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 12;
            // 
            // textBoxX_AlarmLocation
            // 
            // 
            // 
            // 
            this.textBoxX_AlarmLocation.Border.Class = "TextBoxBorder";
            this.textBoxX_AlarmLocation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_AlarmLocation.Location = new System.Drawing.Point(130, 122);
            this.textBoxX_AlarmLocation.Name = "textBoxX_AlarmLocation";
            this.textBoxX_AlarmLocation.PreventEnterBeep = true;
            this.textBoxX_AlarmLocation.Size = new System.Drawing.Size(183, 21);
            this.textBoxX_AlarmLocation.TabIndex = 24;
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
            this.comboBoxEx_TargetAttribute.Location = new System.Drawing.Point(130, 201);
            this.comboBoxEx_TargetAttribute.Name = "comboBoxEx_TargetAttribute";
            this.comboBoxEx_TargetAttribute.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEx_TargetAttribute.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx_TargetAttribute.TabIndex = 23;
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
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(58, 201);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(66, 23);
            this.labelX1.TabIndex = 22;
            this.labelX1.Text = "目标性质：";
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
            this.comboBoxEx_AlarmType.Location = new System.Drawing.Point(130, 162);
            this.comboBoxEx_AlarmType.Name = "comboBoxEx_AlarmType";
            this.comboBoxEx_AlarmType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEx_AlarmType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx_AlarmType.TabIndex = 21;
            this.comboBoxEx_AlarmType.ValueMember = "valueMember";
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
            // buttonX_Cancel
            // 
            this.buttonX_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Cancel.Location = new System.Drawing.Point(225, 360);
            this.buttonX_Cancel.Name = "buttonX_Cancel";
            this.buttonX_Cancel.Size = new System.Drawing.Size(75, 23);
            this.buttonX_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Cancel.TabIndex = 15;
            this.buttonX_Cancel.Text = "取消";
            this.buttonX_Cancel.Click += new System.EventHandler(this.buttonX_Cancel_Click);
            // 
            // buttonX_Save
            // 
            this.buttonX_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Save.Location = new System.Drawing.Point(80, 360);
            this.buttonX_Save.Name = "buttonX_Save";
            this.buttonX_Save.Size = new System.Drawing.Size(75, 23);
            this.buttonX_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Save.TabIndex = 14;
            this.buttonX_Save.Text = "保存并上报";
            this.buttonX_Save.Click += new System.EventHandler(this.buttonX_Save_Click);
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(58, 242);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(66, 23);
            this.labelX7.TabIndex = 13;
            this.labelX7.Text = "事件说明：";
            // 
            // textBoxX_Description
            // 
            // 
            // 
            // 
            this.textBoxX_Description.Border.Class = "TextBoxBorder";
            this.textBoxX_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_Description.Location = new System.Drawing.Point(130, 242);
            this.textBoxX_Description.Multiline = true;
            this.textBoxX_Description.Name = "textBoxX_Description";
            this.textBoxX_Description.PreventEnterBeep = true;
            this.textBoxX_Description.Size = new System.Drawing.Size(183, 80);
            this.textBoxX_Description.TabIndex = 12;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(58, 162);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(66, 23);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "报警类型：";
            // 
            // dateTimeInput_Time
            // 
            // 
            // 
            // 
            this.dateTimeInput_Time.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput_Time.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_Time.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput_Time.ButtonDropDown.Visible = true;
            this.dateTimeInput_Time.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimeInput_Time.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dateTimeInput_Time.IsPopupCalendarOpen = false;
            this.dateTimeInput_Time.Location = new System.Drawing.Point(130, 81);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateTimeInput_Time.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_Time.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput_Time.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput_Time.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput_Time.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput_Time.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput_Time.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput_Time.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput_Time.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput_Time.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_Time.MonthCalendar.DisplayMonth = new System.DateTime(2018, 11, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dateTimeInput_Time.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput_Time.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput_Time.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput_Time.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput_Time.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput_Time.Name = "dateTimeInput_Time";
            this.dateTimeInput_Time.Size = new System.Drawing.Size(200, 21);
            this.dateTimeInput_Time.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput_Time.TabIndex = 5;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(58, 81);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(66, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "报警时间：";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(58, 122);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(66, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "报警方位：";
            // 
            // labelX_Name
            // 
            // 
            // 
            // 
            this.labelX_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_Name.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX_Name.Location = new System.Drawing.Point(142, 12);
            this.labelX_Name.Name = "labelX_Name";
            this.labelX_Name.Size = new System.Drawing.Size(109, 42);
            this.labelX_Name.TabIndex = 0;
            this.labelX_Name.Text = "新增报警";
            // 
            // AlarmInfoAddAndEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 419);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlarmInfoAddAndEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AlarmInfoAddAndEditForm";
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput_Time)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX buttonX_Cancel;
        private DevComponents.DotNetBar.ButtonX buttonX_Save;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX_Description;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput_Time;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX_Name;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx_AlarmType;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx_TargetAttribute;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX_AlarmLocation;
    }
}