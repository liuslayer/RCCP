namespace SVM
{
    partial class Form_Landmark
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Landmark));
            this.Title_panel = new System.Windows.Forms.Panel();
            this.btn_LandmarkManage = new ns1.BunifuFlatButton();
            this.btn_Export = new ns1.BunifuFlatButton();
            this.btn_Search = new ns1.BunifuImageButton();
            this.SearchText = new ns1.BunifuMaterialTextbox();
            this.Panel_Condition = new System.Windows.Forms.Panel();
            this.tbx_LandmarkName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_Ok = new DevComponents.DotNetBar.ButtonX();
            this.tbx_LandmarkID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.lbl_ID = new ns1.BunifuCustomLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.myPageControl1 = new MyControls.MyPageControl();
            this.DataView = new System.Windows.Forms.DataGridView();
            this.Title_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Search)).BeginInit();
            this.Panel_Condition.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).BeginInit();
            this.SuspendLayout();
            // 
            // Title_panel
            // 
            this.Title_panel.BackColor = System.Drawing.Color.Silver;
            this.Title_panel.Controls.Add(this.btn_LandmarkManage);
            this.Title_panel.Controls.Add(this.btn_Export);
            this.Title_panel.Controls.Add(this.btn_Search);
            this.Title_panel.Controls.Add(this.SearchText);
            this.Title_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title_panel.Location = new System.Drawing.Point(0, 0);
            this.Title_panel.Name = "Title_panel";
            this.Title_panel.Size = new System.Drawing.Size(974, 41);
            this.Title_panel.TabIndex = 1;
            // 
            // btn_LandmarkManage
            // 
            this.btn_LandmarkManage.Activecolor = System.Drawing.Color.Black;
            this.btn_LandmarkManage.BackColor = System.Drawing.Color.Transparent;
            this.btn_LandmarkManage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_LandmarkManage.BorderRadius = 0;
            this.btn_LandmarkManage.ButtonText = "    地标管理";
            this.btn_LandmarkManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_LandmarkManage.DisabledColor = System.Drawing.Color.Gray;
            this.btn_LandmarkManage.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_LandmarkManage.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_LandmarkManage.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_LandmarkManage.Iconimage")));
            this.btn_LandmarkManage.Iconimage_right = null;
            this.btn_LandmarkManage.Iconimage_right_Selected = null;
            this.btn_LandmarkManage.Iconimage_Selected = null;
            this.btn_LandmarkManage.IconMarginLeft = 0;
            this.btn_LandmarkManage.IconMarginRight = 0;
            this.btn_LandmarkManage.IconRightVisible = true;
            this.btn_LandmarkManage.IconRightZoom = 0D;
            this.btn_LandmarkManage.IconVisible = true;
            this.btn_LandmarkManage.IconZoom = 70D;
            this.btn_LandmarkManage.IsTab = false;
            this.btn_LandmarkManage.Location = new System.Drawing.Point(704, 0);
            this.btn_LandmarkManage.Name = "btn_LandmarkManage";
            this.btn_LandmarkManage.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_LandmarkManage.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_LandmarkManage.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_LandmarkManage.selected = false;
            this.btn_LandmarkManage.Size = new System.Drawing.Size(135, 41);
            this.btn_LandmarkManage.TabIndex = 3;
            this.btn_LandmarkManage.Text = "    地标管理";
            this.btn_LandmarkManage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LandmarkManage.Textcolor = System.Drawing.Color.White;
            this.btn_LandmarkManage.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LandmarkManage.Click += new System.EventHandler(this.btn_LandmarkManage_Click);
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
            this.btn_Export.Location = new System.Drawing.Point(839, 0);
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
            // Panel_Condition
            // 
            this.Panel_Condition.Controls.Add(this.tbx_LandmarkName);
            this.Panel_Condition.Controls.Add(this.btn_Ok);
            this.Panel_Condition.Controls.Add(this.tbx_LandmarkID);
            this.Panel_Condition.Controls.Add(this.bunifuCustomLabel1);
            this.Panel_Condition.Controls.Add(this.lbl_ID);
            this.Panel_Condition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Condition.Location = new System.Drawing.Point(0, 530);
            this.Panel_Condition.Name = "Panel_Condition";
            this.Panel_Condition.Size = new System.Drawing.Size(974, 80);
            this.Panel_Condition.TabIndex = 4;
            // 
            // tbx_LandmarkName
            // 
            // 
            // 
            // 
            this.tbx_LandmarkName.Border.Class = "TextBoxBorder";
            this.tbx_LandmarkName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbx_LandmarkName.Location = new System.Drawing.Point(420, 28);
            this.tbx_LandmarkName.Name = "tbx_LandmarkName";
            this.tbx_LandmarkName.PreventEnterBeep = true;
            this.tbx_LandmarkName.Size = new System.Drawing.Size(158, 21);
            this.tbx_LandmarkName.TabIndex = 8;
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
            // tbx_LandmarkID
            // 
            // 
            // 
            // 
            this.tbx_LandmarkID.Border.Class = "TextBoxBorder";
            this.tbx_LandmarkID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbx_LandmarkID.Location = new System.Drawing.Point(96, 28);
            this.tbx_LandmarkID.Name = "tbx_LandmarkID";
            this.tbx_LandmarkID.PreventEnterBeep = true;
            this.tbx_LandmarkID.Size = new System.Drawing.Size(158, 21);
            this.tbx_LandmarkID.TabIndex = 6;
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
            this.bunifuCustomLabel1.Text = "地标名称：";
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ID.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_ID.ForeColor = System.Drawing.Color.Black;
            this.lbl_ID.Location = new System.Drawing.Point(12, 33);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(88, 16);
            this.lbl_ID.TabIndex = 0;
            this.lbl_ID.Text = "地标编号：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.myPageControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 498);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 32);
            this.panel1.TabIndex = 5;
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
            // 
            // DataView
            // 
            this.DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataView.Location = new System.Drawing.Point(0, 41);
            this.DataView.Name = "DataView";
            this.DataView.ReadOnly = true;
            this.DataView.RowTemplate.Height = 23;
            this.DataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataView.Size = new System.Drawing.Size(974, 457);
            this.DataView.TabIndex = 6;
            // 
            // Form_Landmark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 610);
            this.Controls.Add(this.DataView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel_Condition);
            this.Controls.Add(this.Title_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Landmark";
            this.Text = "Form_Landmark";
            this.Load += new System.EventHandler(this.Form_Landmark_Load);
            this.Title_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Search)).EndInit();
            this.Panel_Condition.ResumeLayout(false);
            this.Panel_Condition.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Title_panel;
        private ns1.BunifuFlatButton btn_LandmarkManage;
        private ns1.BunifuFlatButton btn_Export;
        private ns1.BunifuImageButton btn_Search;
        private ns1.BunifuMaterialTextbox SearchText;
        private System.Windows.Forms.Panel Panel_Condition;
        private DevComponents.DotNetBar.ButtonX btn_Ok;
        private DevComponents.DotNetBar.Controls.TextBoxX tbx_LandmarkID;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private ns1.BunifuCustomLabel lbl_ID;
        private System.Windows.Forms.Panel panel1;
        private MyControls.MyPageControl myPageControl1;
        private System.Windows.Forms.DataGridView DataView;
        private DevComponents.DotNetBar.Controls.TextBoxX tbx_LandmarkName;
    }
}