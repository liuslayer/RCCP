namespace SVM
{
    partial class Form_OndutyAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_OndutyAdd));
            this.Title = new System.Windows.Forms.Panel();
            this.Title_Lable = new ns1.BunifuCustomLabel();
            this.Title_Img = new System.Windows.Forms.PictureBox();
            this.Exit = new ns1.BunifuImageButton();
            this.Form_Move = new ns1.BunifuDragControl(this.components);
            this.Content = new System.Windows.Forms.Panel();
            this.bunifuCards1 = new ns1.BunifuCards();
            this.cbx_Plan = new System.Windows.Forms.ComboBox();
            this.lbl_Plan = new ns1.BunifuCustomLabel();
            this.tbx_DutyRoute = new ns1.BunifuMaterialTextbox();
            this.lbl_DutyRoute = new ns1.BunifuCustomLabel();
            this.tbx_DutyEvent = new ns1.BunifuMaterialTextbox();
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
            this.TimePicker_DutyDate = new System.Windows.Forms.DateTimePicker();
            this.TimePicker_DutyEventTime = new System.Windows.Forms.DateTimePicker();
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
            this.Title.Size = new System.Drawing.Size(694, 34);
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
            this.Exit.Location = new System.Drawing.Point(657, 0);
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
            this.Content.Size = new System.Drawing.Size(694, 550);
            this.Content.TabIndex = 1;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.TimePicker_DutyEventTime);
            this.bunifuCards1.Controls.Add(this.TimePicker_DutyDate);
            this.bunifuCards1.Controls.Add(this.cbx_Plan);
            this.bunifuCards1.Controls.Add(this.lbl_Plan);
            this.bunifuCards1.Controls.Add(this.tbx_DutyRoute);
            this.bunifuCards1.Controls.Add(this.lbl_DutyRoute);
            this.bunifuCards1.Controls.Add(this.tbx_DutyEvent);
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
            this.bunifuCards1.Size = new System.Drawing.Size(694, 511);
            this.bunifuCards1.TabIndex = 2;
            // 
            // cbx_Plan
            // 
            this.cbx_Plan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Plan.FormattingEnabled = true;
            this.cbx_Plan.Location = new System.Drawing.Point(444, 152);
            this.cbx_Plan.Name = "cbx_Plan";
            this.cbx_Plan.Size = new System.Drawing.Size(174, 20);
            this.cbx_Plan.TabIndex = 31;
            // 
            // lbl_Plan
            // 
            this.lbl_Plan.AutoSize = true;
            this.lbl_Plan.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Plan.Location = new System.Drawing.Point(332, 157);
            this.lbl_Plan.Name = "lbl_Plan";
            this.lbl_Plan.Size = new System.Drawing.Size(120, 16);
            this.lbl_Plan.TabIndex = 30;
            this.lbl_Plan.Text = "事件预案处理：";
            // 
            // tbx_DutyRoute
            // 
            this.tbx_DutyRoute.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_DutyRoute.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_DutyRoute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_DutyRoute.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_DutyRoute.HintText = "";
            this.tbx_DutyRoute.isPassword = false;
            this.tbx_DutyRoute.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_DutyRoute.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_DutyRoute.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_DutyRoute.LineThickness = 3;
            this.tbx_DutyRoute.Location = new System.Drawing.Point(133, 196);
            this.tbx_DutyRoute.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_DutyRoute.Name = "tbx_DutyRoute";
            this.tbx_DutyRoute.Size = new System.Drawing.Size(496, 31);
            this.tbx_DutyRoute.TabIndex = 28;
            this.tbx_DutyRoute.Text = "执勤路线地名之间请用符号-—隔开";
            this.tbx_DutyRoute.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_DutyRoute
            // 
            this.lbl_DutyRoute.AutoSize = true;
            this.lbl_DutyRoute.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_DutyRoute.Location = new System.Drawing.Point(55, 211);
            this.lbl_DutyRoute.Name = "lbl_DutyRoute";
            this.lbl_DutyRoute.Size = new System.Drawing.Size(88, 16);
            this.lbl_DutyRoute.TabIndex = 29;
            this.lbl_DutyRoute.Text = "执勤路线：";
            // 
            // tbx_DutyEvent
            // 
            this.tbx_DutyEvent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_DutyEvent.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_DutyEvent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_DutyEvent.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_DutyEvent.HintText = "";
            this.tbx_DutyEvent.isPassword = false;
            this.tbx_DutyEvent.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_DutyEvent.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_DutyEvent.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_DutyEvent.LineThickness = 3;
            this.tbx_DutyEvent.Location = new System.Drawing.Point(133, 142);
            this.tbx_DutyEvent.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_DutyEvent.Name = "tbx_DutyEvent";
            this.tbx_DutyEvent.Size = new System.Drawing.Size(192, 31);
            this.tbx_DutyEvent.TabIndex = 7;
            this.tbx_DutyEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_DutyEvent
            // 
            this.lbl_DutyEvent.AutoSize = true;
            this.lbl_DutyEvent.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_DutyEvent.Location = new System.Drawing.Point(55, 157);
            this.lbl_DutyEvent.Name = "lbl_DutyEvent";
            this.lbl_DutyEvent.Size = new System.Drawing.Size(88, 16);
            this.lbl_DutyEvent.TabIndex = 27;
            this.lbl_DutyEvent.Text = "事件记录：";
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
            this.btn_Cancel.Location = new System.Drawing.Point(444, 453);
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
            this.btn_OK.Location = new System.Drawing.Point(146, 453);
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
            this.lbl_descript.Location = new System.Drawing.Point(55, 256);
            this.lbl_descript.Name = "lbl_descript";
            this.lbl_descript.Size = new System.Drawing.Size(88, 16);
            this.lbl_descript.TabIndex = 23;
            this.lbl_descript.Text = "详细描述：";
            // 
            // tbx_descrip
            // 
            this.tbx_descrip.BorderColor = System.Drawing.Color.Black;
            this.tbx_descrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_descrip.Location = new System.Drawing.Point(58, 292);
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
            this.lbl_ReturnDate.Location = new System.Drawing.Point(331, 100);
            this.lbl_ReturnDate.Name = "lbl_ReturnDate";
            this.lbl_ReturnDate.Size = new System.Drawing.Size(120, 16);
            this.lbl_ReturnDate.TabIndex = 15;
            this.lbl_ReturnDate.Text = "事件发生时间：";
            // 
            // lbl_DutyDate
            // 
            this.lbl_DutyDate.AutoSize = true;
            this.lbl_DutyDate.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_DutyDate.Location = new System.Drawing.Point(55, 100);
            this.lbl_DutyDate.Name = "lbl_DutyDate";
            this.lbl_DutyDate.Size = new System.Drawing.Size(88, 16);
            this.lbl_DutyDate.TabIndex = 13;
            this.lbl_DutyDate.Text = "执勤日期：";
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
            this.tbx_ID.Location = new System.Drawing.Point(438, 35);
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
            this.lbl_ID.Location = new System.Drawing.Point(346, 50);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(104, 16);
            this.lbl_ID.TabIndex = 3;
            this.lbl_ID.Text = "执勤人编号：";
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
            this.tbx_Name.Location = new System.Drawing.Point(132, 35);
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
            this.lbl_Name.Location = new System.Drawing.Point(55, 50);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(64, 16);
            this.lbl_Name.TabIndex = 1;
            this.lbl_Name.Text = "执勤人:";
            // 
            // Panel_Btn
            // 
            this.Panel_Btn.BackColor = System.Drawing.Color.Gray;
            this.Panel_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Btn.Location = new System.Drawing.Point(0, 0);
            this.Panel_Btn.Name = "Panel_Btn";
            this.Panel_Btn.Size = new System.Drawing.Size(694, 39);
            this.Panel_Btn.TabIndex = 1;
            // 
            // TimePicker_DutyDate
            // 
            this.TimePicker_DutyDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.TimePicker_DutyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePicker_DutyDate.Location = new System.Drawing.Point(132, 100);
            this.TimePicker_DutyDate.Name = "TimePicker_DutyDate";
            this.TimePicker_DutyDate.Size = new System.Drawing.Size(193, 21);
            this.TimePicker_DutyDate.TabIndex = 32;
            // 
            // TimePicker_DutyEventTime
            // 
            this.TimePicker_DutyEventTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.TimePicker_DutyEventTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePicker_DutyEventTime.Location = new System.Drawing.Point(436, 100);
            this.TimePicker_DutyEventTime.Name = "TimePicker_DutyEventTime";
            this.TimePicker_DutyEventTime.Size = new System.Drawing.Size(193, 21);
            this.TimePicker_DutyEventTime.TabIndex = 33;
            // 
            // Form_OndutyAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 584);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_OndutyAdd";
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
        private ns1.BunifuMaterialTextbox tbx_DutyEvent;
        private ns1.BunifuCustomLabel lbl_DutyEvent;
        private ns1.BunifuMaterialTextbox tbx_DutyRoute;
        private ns1.BunifuCustomLabel lbl_DutyRoute;
        private System.Windows.Forms.Panel Panel_Btn;
        private ns1.BunifuCustomLabel lbl_Plan;
        private System.Windows.Forms.ComboBox cbx_Plan;
        private System.Windows.Forms.DateTimePicker TimePicker_DutyDate;
        private System.Windows.Forms.DateTimePicker TimePicker_DutyEventTime;
    }
}