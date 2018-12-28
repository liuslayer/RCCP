namespace SVM
{
    partial class Form_AttendanceRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AttendanceRecord));
            this.Title_panel = new System.Windows.Forms.Panel();
            this.btn_SwitchAdd = new ns1.BunifuFlatButton();
            this.btn_Dutyadd = new ns1.BunifuFlatButton();
            this.btn_DutyEdit = new ns1.BunifuFlatButton();
            this.btn_DutyDelete = new ns1.BunifuFlatButton();
            this.btn_Export = new ns1.BunifuFlatButton();
            this.DataView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.myPageControl1 = new MyControls.MyPageControl();
            this.Panel_Condition = new System.Windows.Forms.Panel();
            this.TimePicker = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.bunifuCustomLabel2 = new ns1.BunifuCustomLabel();
            this.cbx_Isabsent = new System.Windows.Forms.ComboBox();
            this.btn_Ok = new DevComponents.DotNetBar.ButtonX();
            this.tbx_Name = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.lbl_Name = new ns1.BunifuCustomLabel();
            this.Title_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).BeginInit();
            this.panel1.SuspendLayout();
            this.Panel_Condition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimePicker)).BeginInit();
            this.SuspendLayout();
            // 
            // Title_panel
            // 
            this.Title_panel.BackColor = System.Drawing.Color.Silver;
            this.Title_panel.Controls.Add(this.btn_SwitchAdd);
            this.Title_panel.Controls.Add(this.btn_Dutyadd);
            this.Title_panel.Controls.Add(this.btn_DutyEdit);
            this.Title_panel.Controls.Add(this.btn_DutyDelete);
            this.Title_panel.Controls.Add(this.btn_Export);
            this.Title_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title_panel.Location = new System.Drawing.Point(0, 0);
            this.Title_panel.Name = "Title_panel";
            this.Title_panel.Size = new System.Drawing.Size(989, 41);
            this.Title_panel.TabIndex = 0;
            // 
            // btn_SwitchAdd
            // 
            this.btn_SwitchAdd.Activecolor = System.Drawing.Color.Black;
            this.btn_SwitchAdd.BackColor = System.Drawing.Color.Transparent;
            this.btn_SwitchAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_SwitchAdd.BorderRadius = 0;
            this.btn_SwitchAdd.ButtonText = "    交接班管理";
            this.btn_SwitchAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SwitchAdd.DisabledColor = System.Drawing.Color.Gray;
            this.btn_SwitchAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_SwitchAdd.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_SwitchAdd.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_SwitchAdd.Iconimage")));
            this.btn_SwitchAdd.Iconimage_right = null;
            this.btn_SwitchAdd.Iconimage_right_Selected = null;
            this.btn_SwitchAdd.Iconimage_Selected = null;
            this.btn_SwitchAdd.IconMarginLeft = 0;
            this.btn_SwitchAdd.IconMarginRight = 0;
            this.btn_SwitchAdd.IconRightVisible = true;
            this.btn_SwitchAdd.IconRightZoom = 0D;
            this.btn_SwitchAdd.IconVisible = true;
            this.btn_SwitchAdd.IconZoom = 60D;
            this.btn_SwitchAdd.IsTab = false;
            this.btn_SwitchAdd.Location = new System.Drawing.Point(314, 0);
            this.btn_SwitchAdd.Name = "btn_SwitchAdd";
            this.btn_SwitchAdd.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_SwitchAdd.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_SwitchAdd.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_SwitchAdd.selected = false;
            this.btn_SwitchAdd.Size = new System.Drawing.Size(135, 41);
            this.btn_SwitchAdd.TabIndex = 7;
            this.btn_SwitchAdd.Text = "    交接班管理";
            this.btn_SwitchAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SwitchAdd.Textcolor = System.Drawing.Color.White;
            this.btn_SwitchAdd.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SwitchAdd.Click += new System.EventHandler(this.btn_SwitchAdd_Click);
            // 
            // btn_Dutyadd
            // 
            this.btn_Dutyadd.Activecolor = System.Drawing.Color.Black;
            this.btn_Dutyadd.BackColor = System.Drawing.Color.Transparent;
            this.btn_Dutyadd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Dutyadd.BorderRadius = 0;
            this.btn_Dutyadd.ButtonText = "    值班添加";
            this.btn_Dutyadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Dutyadd.DisabledColor = System.Drawing.Color.Gray;
            this.btn_Dutyadd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Dutyadd.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_Dutyadd.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_Dutyadd.Iconimage")));
            this.btn_Dutyadd.Iconimage_right = null;
            this.btn_Dutyadd.Iconimage_right_Selected = null;
            this.btn_Dutyadd.Iconimage_Selected = null;
            this.btn_Dutyadd.IconMarginLeft = 0;
            this.btn_Dutyadd.IconMarginRight = 0;
            this.btn_Dutyadd.IconRightVisible = true;
            this.btn_Dutyadd.IconRightZoom = 0D;
            this.btn_Dutyadd.IconVisible = true;
            this.btn_Dutyadd.IconZoom = 60D;
            this.btn_Dutyadd.IsTab = false;
            this.btn_Dutyadd.Location = new System.Drawing.Point(449, 0);
            this.btn_Dutyadd.Name = "btn_Dutyadd";
            this.btn_Dutyadd.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_Dutyadd.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_Dutyadd.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_Dutyadd.selected = false;
            this.btn_Dutyadd.Size = new System.Drawing.Size(135, 41);
            this.btn_Dutyadd.TabIndex = 5;
            this.btn_Dutyadd.Text = "    值班添加";
            this.btn_Dutyadd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Dutyadd.Textcolor = System.Drawing.Color.White;
            this.btn_Dutyadd.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dutyadd.Click += new System.EventHandler(this.btn_Dutyadd_Click);
            // 
            // btn_DutyEdit
            // 
            this.btn_DutyEdit.Activecolor = System.Drawing.Color.Black;
            this.btn_DutyEdit.BackColor = System.Drawing.Color.Transparent;
            this.btn_DutyEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DutyEdit.BorderRadius = 0;
            this.btn_DutyEdit.ButtonText = "    值班编辑";
            this.btn_DutyEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DutyEdit.DisabledColor = System.Drawing.Color.Gray;
            this.btn_DutyEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_DutyEdit.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_DutyEdit.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_DutyEdit.Iconimage")));
            this.btn_DutyEdit.Iconimage_right = null;
            this.btn_DutyEdit.Iconimage_right_Selected = null;
            this.btn_DutyEdit.Iconimage_Selected = null;
            this.btn_DutyEdit.IconMarginLeft = 0;
            this.btn_DutyEdit.IconMarginRight = 0;
            this.btn_DutyEdit.IconRightVisible = true;
            this.btn_DutyEdit.IconRightZoom = 0D;
            this.btn_DutyEdit.IconVisible = true;
            this.btn_DutyEdit.IconZoom = 60D;
            this.btn_DutyEdit.IsTab = false;
            this.btn_DutyEdit.Location = new System.Drawing.Point(584, 0);
            this.btn_DutyEdit.Name = "btn_DutyEdit";
            this.btn_DutyEdit.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_DutyEdit.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_DutyEdit.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_DutyEdit.selected = false;
            this.btn_DutyEdit.Size = new System.Drawing.Size(135, 41);
            this.btn_DutyEdit.TabIndex = 4;
            this.btn_DutyEdit.Text = "    值班编辑";
            this.btn_DutyEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DutyEdit.Textcolor = System.Drawing.Color.White;
            this.btn_DutyEdit.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DutyEdit.Click += new System.EventHandler(this.btn_DutyEdit_Click);
            // 
            // btn_DutyDelete
            // 
            this.btn_DutyDelete.Activecolor = System.Drawing.Color.Black;
            this.btn_DutyDelete.BackColor = System.Drawing.Color.Transparent;
            this.btn_DutyDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DutyDelete.BorderRadius = 0;
            this.btn_DutyDelete.ButtonText = "    值班删除";
            this.btn_DutyDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DutyDelete.DisabledColor = System.Drawing.Color.Gray;
            this.btn_DutyDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_DutyDelete.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_DutyDelete.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_DutyDelete.Iconimage")));
            this.btn_DutyDelete.Iconimage_right = null;
            this.btn_DutyDelete.Iconimage_right_Selected = null;
            this.btn_DutyDelete.Iconimage_Selected = null;
            this.btn_DutyDelete.IconMarginLeft = 0;
            this.btn_DutyDelete.IconMarginRight = 0;
            this.btn_DutyDelete.IconRightVisible = true;
            this.btn_DutyDelete.IconRightZoom = 0D;
            this.btn_DutyDelete.IconVisible = true;
            this.btn_DutyDelete.IconZoom = 60D;
            this.btn_DutyDelete.IsTab = false;
            this.btn_DutyDelete.Location = new System.Drawing.Point(719, 0);
            this.btn_DutyDelete.Name = "btn_DutyDelete";
            this.btn_DutyDelete.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_DutyDelete.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_DutyDelete.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_DutyDelete.selected = false;
            this.btn_DutyDelete.Size = new System.Drawing.Size(135, 41);
            this.btn_DutyDelete.TabIndex = 3;
            this.btn_DutyDelete.Text = "    值班删除";
            this.btn_DutyDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DutyDelete.Textcolor = System.Drawing.Color.White;
            this.btn_DutyDelete.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DutyDelete.Click += new System.EventHandler(this.btn_DutyDelete_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Activecolor = System.Drawing.Color.Black;
            this.btn_Export.BackColor = System.Drawing.Color.Transparent;
            this.btn_Export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Export.BorderRadius = 0;
            this.btn_Export.ButtonText = "    导出报表";
            this.btn_Export.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Export.DisabledColor = System.Drawing.Color.Gray;
            this.btn_Export.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Export.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_Export.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_Export.Iconimage")));
            this.btn_Export.Iconimage_right = null;
            this.btn_Export.Iconimage_right_Selected = null;
            this.btn_Export.Iconimage_Selected = null;
            this.btn_Export.IconMarginLeft = 0;
            this.btn_Export.IconMarginRight = 0;
            this.btn_Export.IconRightVisible = true;
            this.btn_Export.IconRightZoom = 0D;
            this.btn_Export.IconVisible = true;
            this.btn_Export.IconZoom = 70D;
            this.btn_Export.IsTab = false;
            this.btn_Export.Location = new System.Drawing.Point(854, 0);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_Export.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_Export.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_Export.selected = false;
            this.btn_Export.Size = new System.Drawing.Size(135, 41);
            this.btn_Export.TabIndex = 2;
            this.btn_Export.Text = "    导出报表";
            this.btn_Export.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Export.Textcolor = System.Drawing.Color.White;
            this.btn_Export.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // DataView
            // 
            this.DataView.AllowUserToAddRows = false;
            this.DataView.AllowUserToDeleteRows = false;
            this.DataView.AllowUserToOrderColumns = true;
            this.DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataView.Location = new System.Drawing.Point(0, 41);
            this.DataView.Name = "DataView";
            this.DataView.ReadOnly = true;
            this.DataView.RowTemplate.Height = 23;
            this.DataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataView.Size = new System.Drawing.Size(989, 525);
            this.DataView.TabIndex = 1;
            this.DataView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataView_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.myPageControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 566);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(989, 32);
            this.panel1.TabIndex = 2;
            // 
            // myPageControl1
            // 
            this.myPageControl1.BackColor = System.Drawing.SystemColors.Control;
            this.myPageControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.myPageControl1.Location = new System.Drawing.Point(0, 0);
            this.myPageControl1.Name = "myPageControl1";
            this.myPageControl1.PageIndex = 1;
            this.myPageControl1.PageRecordCount = 0;
            this.myPageControl1.PageRecordNumber = 10;
            this.myPageControl1.Size = new System.Drawing.Size(989, 32);
            this.myPageControl1.TabIndex = 0;
            this.myPageControl1.OnPageChanged += new System.EventHandler(this.myPageControl1_OnPageChanged);
            // 
            // Panel_Condition
            // 
            this.Panel_Condition.Controls.Add(this.TimePicker);
            this.Panel_Condition.Controls.Add(this.bunifuCustomLabel2);
            this.Panel_Condition.Controls.Add(this.cbx_Isabsent);
            this.Panel_Condition.Controls.Add(this.btn_Ok);
            this.Panel_Condition.Controls.Add(this.tbx_Name);
            this.Panel_Condition.Controls.Add(this.bunifuCustomLabel1);
            this.Panel_Condition.Controls.Add(this.lbl_Name);
            this.Panel_Condition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Condition.Location = new System.Drawing.Point(0, 598);
            this.Panel_Condition.Name = "Panel_Condition";
            this.Panel_Condition.Size = new System.Drawing.Size(989, 80);
            this.Panel_Condition.TabIndex = 3;
            // 
            // TimePicker
            // 
            // 
            // 
            // 
            this.TimePicker.BackgroundStyle.Class = "DateTimeInputBackground";
            this.TimePicker.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TimePicker.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.TimePicker.ButtonDropDown.Visible = true;
            this.TimePicker.IsPopupCalendarOpen = false;
            this.TimePicker.Location = new System.Drawing.Point(307, 29);
            // 
            // 
            // 
            // 
            // 
            // 
            this.TimePicker.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TimePicker.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.TimePicker.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.TimePicker.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.TimePicker.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.TimePicker.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.TimePicker.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.TimePicker.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.TimePicker.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.TimePicker.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TimePicker.MonthCalendar.DisplayMonth = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.TimePicker.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.TimePicker.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.TimePicker.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.TimePicker.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TimePicker.MonthCalendar.TodayButtonVisible = true;
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.Size = new System.Drawing.Size(148, 21);
            this.TimePicker.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.TimePicker.TabIndex = 11;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(476, 32);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel2.TabIndex = 10;
            this.bunifuCustomLabel2.Text = "是否缺席：";
            // 
            // cbx_Isabsent
            // 
            this.cbx_Isabsent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Isabsent.FormattingEnabled = true;
            this.cbx_Isabsent.Items.AddRange(new object[] {
            "全部",
            "是",
            "否"});
            this.cbx_Isabsent.Location = new System.Drawing.Point(570, 31);
            this.cbx_Isabsent.Name = "cbx_Isabsent";
            this.cbx_Isabsent.Size = new System.Drawing.Size(94, 20);
            this.cbx_Isabsent.TabIndex = 8;
            // 
            // btn_Ok
            // 
            this.btn_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Ok.Location = new System.Drawing.Point(774, 22);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(80, 29);
            this.btn_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Ok.TabIndex = 7;
            this.btn_Ok.Text = "查 询";
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // tbx_Name
            // 
            // 
            // 
            // 
            this.tbx_Name.Border.Class = "TextBoxBorder";
            this.tbx_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbx_Name.Location = new System.Drawing.Point(60, 32);
            this.tbx_Name.Name = "tbx_Name";
            this.tbx_Name.PreventEnterBeep = true;
            this.tbx_Name.Size = new System.Drawing.Size(149, 21);
            this.tbx_Name.TabIndex = 6;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(225, 32);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "考勤日期：";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Name.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Name.ForeColor = System.Drawing.Color.Black;
            this.lbl_Name.Location = new System.Drawing.Point(12, 33);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(56, 16);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "姓名：";
            // 
            // Form_AttendanceRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 678);
            this.Controls.Add(this.DataView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Title_panel);
            this.Controls.Add(this.Panel_Condition);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_AttendanceRecord";
            this.Text = "Onduty_Form";
            this.Load += new System.EventHandler(this.Form_AttendanceRecord_Load);
            this.Title_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.Panel_Condition.ResumeLayout(false);
            this.Panel_Condition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimePicker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Title_panel;
        private ns1.BunifuFlatButton btn_Export;
        private ns1.BunifuFlatButton btn_DutyDelete;
        private System.Windows.Forms.DataGridView DataView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Panel_Condition;
        private MyControls.MyPageControl myPageControl1;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private ns1.BunifuCustomLabel lbl_Name;
        private DevComponents.DotNetBar.Controls.TextBoxX tbx_Name;
        private DevComponents.DotNetBar.ButtonX btn_Ok;
        private ns1.BunifuFlatButton btn_Dutyadd;
        private ns1.BunifuFlatButton btn_DutyEdit;
        private System.Windows.Forms.ComboBox cbx_Isabsent;
        private ns1.BunifuCustomLabel bunifuCustomLabel2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput TimePicker;
        private ns1.BunifuFlatButton btn_SwitchAdd;

    }
}