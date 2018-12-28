namespace SVM
{
    partial class Form_AttendanceRecordAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AttendanceRecordAdd));
            this.Title = new System.Windows.Forms.Panel();
            this.Title_Lable = new ns1.BunifuCustomLabel();
            this.Title_Img = new System.Windows.Forms.PictureBox();
            this.Exit = new ns1.BunifuImageButton();
            this.Form_Move = new ns1.BunifuDragControl(this.components);
            this.Content = new System.Windows.Forms.Panel();
            this.bunifuCards1 = new ns1.BunifuCards();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.tbx_Leader = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.cbx_IsAbsent = new System.Windows.Forms.ComboBox();
            this.lbl_Plan = new ns1.BunifuCustomLabel();
            this.tbx_Reasons = new ns1.BunifuMaterialTextbox();
            this.lbl_DutyEvent = new ns1.BunifuCustomLabel();
            this.btn_Cancel = new ns1.BunifuThinButton2();
            this.btn_OK = new ns1.BunifuThinButton2();
            this.lbl_descript = new ns1.BunifuCustomLabel();
            this.tbx_descrip = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.lbl_ReturnDate = new ns1.BunifuCustomLabel();
            this.lbl_DutyDate = new ns1.BunifuCustomLabel();
            this.tbx_ID = new ns1.BunifuMaterialTextbox();
            this.lbl_ID = new ns1.BunifuCustomLabel();
            this.tbx_Name = new ns1.BunifuMaterialTextbox();
            this.lbl_Name = new ns1.BunifuCustomLabel();
            this.Panel_Btn = new System.Windows.Forms.Panel();
            this.Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Title_Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.Content.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Silver;
            this.Title.Controls.Add(this.Title_Lable);
            this.Title.Controls.Add(this.Title_Img);
            this.Title.Controls.Add(this.Exit);
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(684, 34);
            this.Title.TabIndex = 0;
            // 
            // Title_Lable
            // 
            this.Title_Lable.AutoSize = true;
            this.Title_Lable.Font = new System.Drawing.Font("宋体", 12F);
            this.Title_Lable.ForeColor = System.Drawing.Color.White;
            this.Title_Lable.Location = new System.Drawing.Point(48, 9);
            this.Title_Lable.Name = "Title_Lable";
            this.Title_Lable.Size = new System.Drawing.Size(0, 16);
            this.Title_Lable.TabIndex = 2;
            // 
            // Title_Img
            // 
            this.Title_Img.Image = ((System.Drawing.Image)(resources.GetObject("Title_Img.Image")));
            this.Title_Img.Location = new System.Drawing.Point(12, 4);
            this.Title_Img.Name = "Title_Img";
            this.Title_Img.Size = new System.Drawing.Size(30, 27);
            this.Title_Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Title_Img.TabIndex = 1;
            this.Title_Img.TabStop = false;
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.ImageActive = null;
            this.Exit.Location = new System.Drawing.Point(647, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(37, 34);
            this.Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Exit.TabIndex = 0;
            this.Exit.TabStop = false;
            this.Exit.Zoom = 10;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Form_Move
            // 
            this.Form_Move.Fixed = true;
            this.Form_Move.Horizontal = true;
            this.Form_Move.TargetControl = this.Title;
            this.Form_Move.Vertical = true;
            // 
            // Content
            // 
            this.Content.Controls.Add(this.bunifuCards1);
            this.Content.Controls.Add(this.Panel_Btn);
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(0, 34);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(684, 577);
            this.Content.TabIndex = 1;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.dtp_end);
            this.bunifuCards1.Controls.Add(this.dtp_start);
            this.bunifuCards1.Controls.Add(this.tbx_Leader);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuCards1.Controls.Add(this.cbx_IsAbsent);
            this.bunifuCards1.Controls.Add(this.lbl_Plan);
            this.bunifuCards1.Controls.Add(this.tbx_Reasons);
            this.bunifuCards1.Controls.Add(this.lbl_DutyEvent);
            this.bunifuCards1.Controls.Add(this.btn_Cancel);
            this.bunifuCards1.Controls.Add(this.btn_OK);
            this.bunifuCards1.Controls.Add(this.lbl_descript);
            this.bunifuCards1.Controls.Add(this.tbx_descrip);
            this.bunifuCards1.Controls.Add(this.lbl_ReturnDate);
            this.bunifuCards1.Controls.Add(this.lbl_DutyDate);
            this.bunifuCards1.Controls.Add(this.tbx_ID);
            this.bunifuCards1.Controls.Add(this.lbl_ID);
            this.bunifuCards1.Controls.Add(this.tbx_Name);
            this.bunifuCards1.Controls.Add(this.lbl_Name);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 39);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(684, 538);
            this.bunifuCards1.TabIndex = 2;
            // 
            // dtp_end
            // 
            this.dtp_end.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_end.Location = new System.Drawing.Point(441, 154);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(189, 21);
            this.dtp_end.TabIndex = 35;
            // 
            // dtp_start
            // 
            this.dtp_start.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_start.Location = new System.Drawing.Point(130, 149);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(191, 21);
            this.dtp_start.TabIndex = 34;
            // 
            // tbx_Leader
            // 
            this.tbx_Leader.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_Leader.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_Leader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_Leader.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_Leader.HintText = "";
            this.tbx_Leader.isPassword = false;
            this.tbx_Leader.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_Leader.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_Leader.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_Leader.LineThickness = 3;
            this.tbx_Leader.Location = new System.Drawing.Point(439, 83);
            this.tbx_Leader.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Leader.Name = "tbx_Leader";
            this.tbx_Leader.Size = new System.Drawing.Size(191, 31);
            this.tbx_Leader.TabIndex = 33;
            this.tbx_Leader.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(363, 98);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel1.TabIndex = 32;
            this.bunifuCustomLabel1.Text = "值班领导：";
            // 
            // cbx_IsAbsent
            // 
            this.cbx_IsAbsent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_IsAbsent.FormattingEnabled = true;
            this.cbx_IsAbsent.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbx_IsAbsent.Location = new System.Drawing.Point(136, 206);
            this.cbx_IsAbsent.Name = "cbx_IsAbsent";
            this.cbx_IsAbsent.Size = new System.Drawing.Size(174, 20);
            this.cbx_IsAbsent.TabIndex = 31;
            // 
            // lbl_Plan
            // 
            this.lbl_Plan.AutoSize = true;
            this.lbl_Plan.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Plan.Location = new System.Drawing.Point(55, 211);
            this.lbl_Plan.Name = "lbl_Plan";
            this.lbl_Plan.Size = new System.Drawing.Size(88, 16);
            this.lbl_Plan.TabIndex = 30;
            this.lbl_Plan.Text = "是否缺席：";
            // 
            // tbx_Reasons
            // 
            this.tbx_Reasons.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_Reasons.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_Reasons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_Reasons.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_Reasons.HintText = "";
            this.tbx_Reasons.isPassword = false;
            this.tbx_Reasons.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_Reasons.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_Reasons.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_Reasons.LineThickness = 3;
            this.tbx_Reasons.Location = new System.Drawing.Point(441, 196);
            this.tbx_Reasons.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Reasons.Name = "tbx_Reasons";
            this.tbx_Reasons.Size = new System.Drawing.Size(192, 31);
            this.tbx_Reasons.TabIndex = 7;
            this.tbx_Reasons.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_DutyEvent
            // 
            this.lbl_DutyEvent.AutoSize = true;
            this.lbl_DutyEvent.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_DutyEvent.Location = new System.Drawing.Point(363, 211);
            this.lbl_DutyEvent.Name = "lbl_DutyEvent";
            this.lbl_DutyEvent.Size = new System.Drawing.Size(88, 16);
            this.lbl_DutyEvent.TabIndex = 27;
            this.lbl_DutyEvent.Text = "缺席缘由：";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.ActiveBorderThickness = 1;
            this.btn_Cancel.ActiveCornerRadius = 5;
            this.btn_Cancel.ActiveFillColor = System.Drawing.Color.White;
            this.btn_Cancel.ActiveForecolor = System.Drawing.Color.Black;
            this.btn_Cancel.ActiveLineColor = System.Drawing.Color.Black;
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.BackgroundImage")));
            this.btn_Cancel.ButtonText = "取 消";
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.IdleBorderThickness = 1;
            this.btn_Cancel.IdleCornerRadius = 5;
            this.btn_Cancel.IdleFillColor = System.Drawing.Color.Gray;
            this.btn_Cancel.IdleForecolor = System.Drawing.Color.White;
            this.btn_Cancel.IdleLineColor = System.Drawing.Color.Black;
            this.btn_Cancel.Location = new System.Drawing.Point(381, 454);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(101, 48);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.ActiveBorderThickness = 1;
            this.btn_OK.ActiveCornerRadius = 5;
            this.btn_OK.ActiveFillColor = System.Drawing.Color.White;
            this.btn_OK.ActiveForecolor = System.Drawing.Color.Black;
            this.btn_OK.ActiveLineColor = System.Drawing.Color.Black;
            this.btn_OK.BackColor = System.Drawing.Color.White;
            this.btn_OK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_OK.BackgroundImage")));
            this.btn_OK.ButtonText = "确 定";
            this.btn_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OK.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OK.ForeColor = System.Drawing.Color.Black;
            this.btn_OK.IdleBorderThickness = 1;
            this.btn_OK.IdleCornerRadius = 5;
            this.btn_OK.IdleFillColor = System.Drawing.Color.Gray;
            this.btn_OK.IdleForecolor = System.Drawing.Color.White;
            this.btn_OK.IdleLineColor = System.Drawing.Color.Black;
            this.btn_OK.Location = new System.Drawing.Point(130, 454);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(5);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(101, 48);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_descript
            // 
            this.lbl_descript.AutoSize = true;
            this.lbl_descript.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_descript.Location = new System.Drawing.Point(55, 264);
            this.lbl_descript.Name = "lbl_descript";
            this.lbl_descript.Size = new System.Drawing.Size(88, 16);
            this.lbl_descript.TabIndex = 23;
            this.lbl_descript.Text = "详细描述：";
            // 
            // tbx_descrip
            // 
            this.tbx_descrip.BorderColor = System.Drawing.Color.Black;
            this.tbx_descrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_descrip.Location = new System.Drawing.Point(58, 300);
            this.tbx_descrip.Multiline = true;
            this.tbx_descrip.Name = "tbx_descrip";
            this.tbx_descrip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_descrip.Size = new System.Drawing.Size(574, 126);
            this.tbx_descrip.TabIndex = 8;
            // 
            // lbl_ReturnDate
            // 
            this.lbl_ReturnDate.AutoSize = true;
            this.lbl_ReturnDate.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_ReturnDate.Location = new System.Drawing.Point(363, 154);
            this.lbl_ReturnDate.Name = "lbl_ReturnDate";
            this.lbl_ReturnDate.Size = new System.Drawing.Size(88, 16);
            this.lbl_ReturnDate.TabIndex = 15;
            this.lbl_ReturnDate.Text = "结束时间：";
            // 
            // lbl_DutyDate
            // 
            this.lbl_DutyDate.AutoSize = true;
            this.lbl_DutyDate.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_DutyDate.Location = new System.Drawing.Point(55, 154);
            this.lbl_DutyDate.Name = "lbl_DutyDate";
            this.lbl_DutyDate.Size = new System.Drawing.Size(88, 16);
            this.lbl_DutyDate.TabIndex = 13;
            this.lbl_DutyDate.Text = "起始时间：";
            // 
            // tbx_ID
            // 
            this.tbx_ID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_ID.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_ID.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_ID.HintText = "";
            this.tbx_ID.isPassword = false;
            this.tbx_ID.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_ID.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_ID.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_ID.LineThickness = 3;
            this.tbx_ID.Location = new System.Drawing.Point(130, 37);
            this.tbx_ID.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_ID.Name = "tbx_ID";
            this.tbx_ID.Size = new System.Drawing.Size(191, 31);
            this.tbx_ID.TabIndex = 2;
            this.tbx_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_ID.Location = new System.Drawing.Point(87, 52);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(56, 16);
            this.lbl_ID.TabIndex = 3;
            this.lbl_ID.Text = "编号：";
            // 
            // tbx_Name
            // 
            this.tbx_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_Name.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_Name.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_Name.HintText = "";
            this.tbx_Name.isPassword = false;
            this.tbx_Name.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_Name.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_Name.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_Name.LineThickness = 3;
            this.tbx_Name.Location = new System.Drawing.Point(132, 83);
            this.tbx_Name.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Name.Name = "tbx_Name";
            this.tbx_Name.Size = new System.Drawing.Size(191, 31);
            this.tbx_Name.TabIndex = 1;
            this.tbx_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Name.Location = new System.Drawing.Point(71, 98);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(72, 16);
            this.lbl_Name.TabIndex = 1;
            this.lbl_Name.Text = "值班员：";
            // 
            // Panel_Btn
            // 
            this.Panel_Btn.BackColor = System.Drawing.Color.Gray;
            this.Panel_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Btn.Location = new System.Drawing.Point(0, 0);
            this.Panel_Btn.Name = "Panel_Btn";
            this.Panel_Btn.Size = new System.Drawing.Size(684, 39);
            this.Panel_Btn.TabIndex = 1;
            // 
            // Form_AttendanceRecordAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 611);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_AttendanceRecordAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_PersonAdd";
            this.Load += new System.EventHandler(this.Form_OndutyAdd_Load);
            this.Title.ResumeLayout(false);
            this.Title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Title_Img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.Content.ResumeLayout(false);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Title;
        private ns1.BunifuDragControl Form_Move;
        private ns1.BunifuImageButton Exit;
        private ns1.BunifuCustomLabel Title_Lable;
        private System.Windows.Forms.PictureBox Title_Img;
        private System.Windows.Forms.Panel Content;
        private ns1.BunifuCards bunifuCards1;
        private ns1.BunifuMaterialTextbox tbx_Name;
        private ns1.BunifuCustomLabel lbl_Name;
        private ns1.BunifuMaterialTextbox tbx_ID;
        private ns1.BunifuCustomLabel lbl_ID;
        private ns1.BunifuCustomLabel lbl_ReturnDate;
        private ns1.BunifuCustomLabel lbl_DutyDate;
        private ns1.BunifuThinButton2 btn_OK;
        private ns1.BunifuCustomLabel lbl_descript;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox tbx_descrip;
        private ns1.BunifuThinButton2 btn_Cancel;
        private ns1.BunifuMaterialTextbox tbx_Reasons;
        private ns1.BunifuCustomLabel lbl_DutyEvent;
        private System.Windows.Forms.Panel Panel_Btn;
        private ns1.BunifuCustomLabel lbl_Plan;
        private System.Windows.Forms.ComboBox cbx_IsAbsent;
        private ns1.BunifuMaterialTextbox tbx_Leader;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.DateTimePicker dtp_end;
    }
}