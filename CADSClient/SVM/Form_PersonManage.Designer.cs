namespace SVM
{
    partial class Form_PersonManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PersonManage));
            this.Title_panel = new System.Windows.Forms.Panel();
            this.btn_PersonManage = new ns1.BunifuFlatButton();
            this.btn_Export = new ns1.BunifuFlatButton();
            this.btn_Search = new ns1.BunifuImageButton();
            this.SearchText = new ns1.BunifuMaterialTextbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.myPageControl1 = new MyControls.MyPageControl();
            this.Panel_Condition = new System.Windows.Forms.Panel();
            this.btn_Ok = new DevComponents.DotNetBar.ButtonX();
            this.tbx_Name = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dtp_Intime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.lbl_Name = new ns1.BunifuCustomLabel();
            this.DataView = new System.Windows.Forms.DataGridView();
            this.Title_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Search)).BeginInit();
            this.panel1.SuspendLayout();
            this.Panel_Condition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_Intime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).BeginInit();
            this.SuspendLayout();
            // 
            // Title_panel
            // 
            this.Title_panel.BackColor = System.Drawing.Color.Silver;
            this.Title_panel.Controls.Add(this.btn_PersonManage);
            this.Title_panel.Controls.Add(this.btn_Export);
            this.Title_panel.Controls.Add(this.btn_Search);
            this.Title_panel.Controls.Add(this.SearchText);
            this.Title_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title_panel.Location = new System.Drawing.Point(0, 0);
            this.Title_panel.Name = "Title_panel";
            this.Title_panel.Size = new System.Drawing.Size(989, 41);
            this.Title_panel.TabIndex = 0;
            // 
            // btn_PersonManage
            // 
            this.btn_PersonManage.Activecolor = System.Drawing.Color.Black;
            this.btn_PersonManage.BackColor = System.Drawing.Color.Transparent;
            this.btn_PersonManage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_PersonManage.BorderRadius = 0;
            this.btn_PersonManage.ButtonText = "    人员管理";
            this.btn_PersonManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PersonManage.DisabledColor = System.Drawing.Color.Gray;
            this.btn_PersonManage.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_PersonManage.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_PersonManage.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_PersonManage.Iconimage")));
            this.btn_PersonManage.Iconimage_right = null;
            this.btn_PersonManage.Iconimage_right_Selected = null;
            this.btn_PersonManage.Iconimage_Selected = null;
            this.btn_PersonManage.IconMarginLeft = 0;
            this.btn_PersonManage.IconMarginRight = 0;
            this.btn_PersonManage.IconRightVisible = true;
            this.btn_PersonManage.IconRightZoom = 0D;
            this.btn_PersonManage.IconVisible = true;
            this.btn_PersonManage.IconZoom = 70D;
            this.btn_PersonManage.IsTab = false;
            this.btn_PersonManage.Location = new System.Drawing.Point(719, 0);
            this.btn_PersonManage.Name = "btn_PersonManage";
            this.btn_PersonManage.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_PersonManage.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_PersonManage.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_PersonManage.selected = false;
            this.btn_PersonManage.Size = new System.Drawing.Size(135, 41);
            this.btn_PersonManage.TabIndex = 3;
            this.btn_PersonManage.Text = "    人员管理";
            this.btn_PersonManage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PersonManage.Textcolor = System.Drawing.Color.White;
            this.btn_PersonManage.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PersonManage.Click += new System.EventHandler(this.btn_PersonManage_Click);
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
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.Transparent;
            this.btn_Search.Image = ((System.Drawing.Image)(resources.GetObject("btn_Search.Image")));
            this.btn_Search.ImageActive = null;
            this.btn_Search.Location = new System.Drawing.Point(181, 14);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(24, 24);
            this.btn_Search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Search.TabIndex = 1;
            this.btn_Search.TabStop = false;
            this.btn_Search.Zoom = 10;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // SearchText
            // 
            this.SearchText.BackColor = System.Drawing.Color.Silver;
            this.SearchText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchText.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.SearchText.ForeColor = System.Drawing.Color.Black;
            this.SearchText.HintForeColor = System.Drawing.Color.Empty;
            this.SearchText.HintText = "";
            this.SearchText.isPassword = false;
            this.SearchText.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SearchText.LineIdleColor = System.Drawing.Color.White;
            this.SearchText.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SearchText.LineThickness = 2;
            this.SearchText.Location = new System.Drawing.Point(2, 9);
            this.SearchText.Margin = new System.Windows.Forms.Padding(4);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(172, 28);
            this.SearchText.TabIndex = 0;
            this.SearchText.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.Panel_Condition.Controls.Add(this.btn_Ok);
            this.Panel_Condition.Controls.Add(this.tbx_Name);
            this.Panel_Condition.Controls.Add(this.dtp_Intime);
            this.Panel_Condition.Controls.Add(this.bunifuCustomLabel1);
            this.Panel_Condition.Controls.Add(this.lbl_Name);
            this.Panel_Condition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Condition.Location = new System.Drawing.Point(0, 598);
            this.Panel_Condition.Name = "Panel_Condition";
            this.Panel_Condition.Size = new System.Drawing.Size(989, 80);
            this.Panel_Condition.TabIndex = 3;
            // 
            // btn_Ok
            // 
            this.btn_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Ok.Location = new System.Drawing.Point(719, 26);
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
            this.tbx_Name.Location = new System.Drawing.Point(75, 33);
            this.tbx_Name.Name = "tbx_Name";
            this.tbx_Name.PreventEnterBeep = true;
            this.tbx_Name.Size = new System.Drawing.Size(158, 21);
            this.tbx_Name.TabIndex = 6;
            // 
            // dtp_Intime
            // 
            // 
            // 
            // 
            this.dtp_Intime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_Intime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtp_Intime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtp_Intime.ButtonDropDown.Visible = true;
            this.dtp_Intime.IsPopupCalendarOpen = false;
            this.dtp_Intime.Location = new System.Drawing.Point(410, 33);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtp_Intime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtp_Intime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtp_Intime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtp_Intime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtp_Intime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_Intime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtp_Intime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtp_Intime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtp_Intime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtp_Intime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtp_Intime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtp_Intime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtp_Intime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_Intime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtp_Intime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtp_Intime.MonthCalendar.TodayButtonVisible = true;
            this.dtp_Intime.Name = "dtp_Intime";
            this.dtp_Intime.Size = new System.Drawing.Size(163, 21);
            this.dtp_Intime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtp_Intime.TabIndex = 5;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(326, 33);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "入伍时间：";
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
            // DataView
            // 
            this.DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataView.Location = new System.Drawing.Point(0, 41);
            this.DataView.Name = "DataView";
            this.DataView.RowTemplate.Height = 23;
            this.DataView.Size = new System.Drawing.Size(989, 525);
            this.DataView.TabIndex = 1;
            // 
            // Form_PersonManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 678);
            this.Controls.Add(this.DataView);
            this.Controls.Add(this.Title_panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel_Condition);
            this.ForeColor = System.Drawing.Color.DarkGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_PersonManage";
            this.Text = "Onduty_Form";
            this.Load += new System.EventHandler(this.Form_PersonManage_Load);
            this.Title_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Search)).EndInit();
            this.panel1.ResumeLayout(false);
            this.Panel_Condition.ResumeLayout(false);
            this.Panel_Condition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_Intime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Title_panel;
        private ns1.BunifuMaterialTextbox SearchText;
        private ns1.BunifuImageButton btn_Search;
        private ns1.BunifuFlatButton btn_Export;
        private ns1.BunifuFlatButton btn_PersonManage;
        private System.Windows.Forms.DataGridView DataView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Panel_Condition;
        private MyControls.MyPageControl myPageControl1;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private ns1.BunifuCustomLabel lbl_Name;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_Intime;
        private DevComponents.DotNetBar.Controls.TextBoxX tbx_Name;
        private DevComponents.DotNetBar.ButtonX btn_Ok;

    }
}