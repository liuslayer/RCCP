namespace MSSM
{
    partial class Form_MsSearchAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MsSearchAdd));
            this.Title = new System.Windows.Forms.Panel();
            this.Title_Label = new ns1.BunifuCustomLabel();
            this.Title_Lable = new ns1.BunifuCustomLabel();
            this.Exit = new ns1.BunifuImageButton();
            this.txt_MessTitle = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel5 = new ns1.BunifuCustomLabel();
            this.txt_ReceiveOrg = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel3 = new ns1.BunifuCustomLabel();
            this.txt_Receiver = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel2 = new ns1.BunifuCustomLabel();
            this.txt_MessID = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.btn_Cancel = new ns1.BunifuThinButton2();
            this.btn_OK = new ns1.BunifuThinButton2();
            this.lbl_descript = new ns1.BunifuCustomLabel();
            this.txt_MessContent = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel4 = new ns1.BunifuCustomLabel();
            this.cbx_IsHandle = new System.Windows.Forms.ComboBox();
            this.txt_Attachment = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel6 = new ns1.BunifuCustomLabel();
            this.btnAttachmentInput = new ns1.BunifuThinButton2();
            this.Content = new System.Windows.Forms.Panel();
            this.bunifuCards1 = new ns1.BunifuCards();
            this.Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.Content.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Silver;
            this.Title.Controls.Add(this.Title_Label);
            this.Title.Controls.Add(this.Title_Lable);
            this.Title.Controls.Add(this.Exit);
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(721, 34);
            this.Title.TabIndex = 2;
            // 
            // Title_Label
            // 
            this.Title_Label.AutoSize = true;
            this.Title_Label.Font = new System.Drawing.Font("宋体", 12F);
            this.Title_Label.ForeColor = System.Drawing.Color.White;
            this.Title_Label.Location = new System.Drawing.Point(12, 9);
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.Size = new System.Drawing.Size(72, 16);
            this.Title_Label.TabIndex = 3;
            this.Title_Label.Text = "文电管理";
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
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.ImageActive = null;
            this.Exit.Location = new System.Drawing.Point(684, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(37, 34);
            this.Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Exit.TabIndex = 0;
            this.Exit.TabStop = false;
            this.Exit.Zoom = 10;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // txt_MessTitle
            // 
            this.txt_MessTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MessTitle.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_MessTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_MessTitle.HintForeColor = System.Drawing.Color.Empty;
            this.txt_MessTitle.HintText = "";
            this.txt_MessTitle.isPassword = false;
            this.txt_MessTitle.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_MessTitle.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_MessTitle.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_MessTitle.LineThickness = 3;
            this.txt_MessTitle.Location = new System.Drawing.Point(144, 140);
            this.txt_MessTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MessTitle.Name = "txt_MessTitle";
            this.txt_MessTitle.Size = new System.Drawing.Size(502, 31);
            this.txt_MessTitle.TabIndex = 47;
            this.txt_MessTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(49, 155);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel5.TabIndex = 46;
            this.bunifuCustomLabel5.Text = "文电标题：";
            // 
            // txt_ReceiveOrg
            // 
            this.txt_ReceiveOrg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ReceiveOrg.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_ReceiveOrg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_ReceiveOrg.HintForeColor = System.Drawing.Color.Empty;
            this.txt_ReceiveOrg.HintText = "";
            this.txt_ReceiveOrg.isPassword = false;
            this.txt_ReceiveOrg.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_ReceiveOrg.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_ReceiveOrg.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_ReceiveOrg.LineThickness = 3;
            this.txt_ReceiveOrg.Location = new System.Drawing.Point(144, 77);
            this.txt_ReceiveOrg.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ReceiveOrg.Name = "txt_ReceiveOrg";
            this.txt_ReceiveOrg.Size = new System.Drawing.Size(191, 31);
            this.txt_ReceiveOrg.TabIndex = 43;
            this.txt_ReceiveOrg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(49, 92);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel3.TabIndex = 42;
            this.bunifuCustomLabel3.Text = "接收单位：";
            // 
            // txt_Receiver
            // 
            this.txt_Receiver.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Receiver.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_Receiver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Receiver.HintForeColor = System.Drawing.Color.Empty;
            this.txt_Receiver.HintText = "";
            this.txt_Receiver.isPassword = false;
            this.txt_Receiver.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_Receiver.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_Receiver.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_Receiver.LineThickness = 3;
            this.txt_Receiver.Location = new System.Drawing.Point(455, 20);
            this.txt_Receiver.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Receiver.Name = "txt_Receiver";
            this.txt_Receiver.Size = new System.Drawing.Size(191, 31);
            this.txt_Receiver.TabIndex = 41;
            this.txt_Receiver.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(360, 35);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(72, 16);
            this.bunifuCustomLabel2.TabIndex = 40;
            this.bunifuCustomLabel2.Text = "接收人：";
            // 
            // txt_MessID
            // 
            this.txt_MessID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MessID.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_MessID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_MessID.HintForeColor = System.Drawing.Color.Empty;
            this.txt_MessID.HintText = "";
            this.txt_MessID.isPassword = false;
            this.txt_MessID.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_MessID.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_MessID.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_MessID.LineThickness = 3;
            this.txt_MessID.Location = new System.Drawing.Point(144, 20);
            this.txt_MessID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MessID.Name = "txt_MessID";
            this.txt_MessID.Size = new System.Drawing.Size(191, 31);
            this.txt_MessID.TabIndex = 39;
            this.txt_MessID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(49, 35);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel1.TabIndex = 38;
            this.bunifuCustomLabel1.Text = "文电编号：";
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
            this.btn_Cancel.Location = new System.Drawing.Point(411, 496);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(101, 48);
            this.btn_Cancel.TabIndex = 36;
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
            this.btn_OK.Location = new System.Drawing.Point(158, 496);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(5);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(101, 48);
            this.btn_OK.TabIndex = 35;
            this.btn_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_descript
            // 
            this.lbl_descript.AutoSize = true;
            this.lbl_descript.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_descript.Location = new System.Drawing.Point(49, 210);
            this.lbl_descript.Name = "lbl_descript";
            this.lbl_descript.Size = new System.Drawing.Size(88, 16);
            this.lbl_descript.TabIndex = 37;
            this.lbl_descript.Text = "文电内容：";
            // 
            // txt_MessContent
            // 
            this.txt_MessContent.BorderColor = System.Drawing.Color.Black;
            this.txt_MessContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_MessContent.Location = new System.Drawing.Point(52, 249);
            this.txt_MessContent.Multiline = true;
            this.txt_MessContent.Name = "txt_MessContent";
            this.txt_MessContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_MessContent.Size = new System.Drawing.Size(594, 154);
            this.txt_MessContent.TabIndex = 34;
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(360, 91);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(104, 16);
            this.bunifuCustomLabel4.TabIndex = 48;
            this.bunifuCustomLabel4.Text = "是否已处理：";
            // 
            // cbx_IsHandle
            // 
            this.cbx_IsHandle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_IsHandle.FormattingEnabled = true;
            this.cbx_IsHandle.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbx_IsHandle.Location = new System.Drawing.Point(470, 92);
            this.cbx_IsHandle.Name = "cbx_IsHandle";
            this.cbx_IsHandle.Size = new System.Drawing.Size(121, 20);
            this.cbx_IsHandle.TabIndex = 50;
            // 
            // txt_Attachment
            // 
            this.txt_Attachment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Attachment.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_Attachment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Attachment.HintForeColor = System.Drawing.Color.Empty;
            this.txt_Attachment.HintText = "";
            this.txt_Attachment.isPassword = false;
            this.txt_Attachment.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_Attachment.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_Attachment.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_Attachment.LineThickness = 3;
            this.txt_Attachment.Location = new System.Drawing.Point(112, 423);
            this.txt_Attachment.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Attachment.Name = "txt_Attachment";
            this.txt_Attachment.Size = new System.Drawing.Size(424, 31);
            this.txt_Attachment.TabIndex = 52;
            this.txt_Attachment.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(49, 438);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(56, 16);
            this.bunifuCustomLabel6.TabIndex = 51;
            this.bunifuCustomLabel6.Text = "附件：";
            // 
            // btnAttachmentInput
            // 
            this.btnAttachmentInput.ActiveBorderThickness = 1;
            this.btnAttachmentInput.ActiveCornerRadius = 5;
            this.btnAttachmentInput.ActiveFillColor = System.Drawing.Color.White;
            this.btnAttachmentInput.ActiveForecolor = System.Drawing.Color.Black;
            this.btnAttachmentInput.ActiveLineColor = System.Drawing.Color.Black;
            this.btnAttachmentInput.BackColor = System.Drawing.Color.White;
            this.btnAttachmentInput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAttachmentInput.BackgroundImage")));
            this.btnAttachmentInput.ButtonText = "导入附件";
            this.btnAttachmentInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAttachmentInput.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachmentInput.ForeColor = System.Drawing.Color.Black;
            this.btnAttachmentInput.IdleBorderThickness = 1;
            this.btnAttachmentInput.IdleCornerRadius = 5;
            this.btnAttachmentInput.IdleFillColor = System.Drawing.Color.Gray;
            this.btnAttachmentInput.IdleForecolor = System.Drawing.Color.White;
            this.btnAttachmentInput.IdleLineColor = System.Drawing.Color.Black;
            this.btnAttachmentInput.Location = new System.Drawing.Point(545, 423);
            this.btnAttachmentInput.Margin = new System.Windows.Forms.Padding(5);
            this.btnAttachmentInput.Name = "btnAttachmentInput";
            this.btnAttachmentInput.Size = new System.Drawing.Size(101, 35);
            this.btnAttachmentInput.TabIndex = 53;
            this.btnAttachmentInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAttachmentInput.Click += new System.EventHandler(this.btnAttachmentInput_Click);
            // 
            // Content
            // 
            this.Content.Controls.Add(this.bunifuCards1);
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(0, 34);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(721, 594);
            this.Content.TabIndex = 54;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.btnAttachmentInput);
            this.bunifuCards1.Controls.Add(this.txt_Attachment);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel6);
            this.bunifuCards1.Controls.Add(this.cbx_IsHandle);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel4);
            this.bunifuCards1.Controls.Add(this.txt_MessContent);
            this.bunifuCards1.Controls.Add(this.txt_MessTitle);
            this.bunifuCards1.Controls.Add(this.lbl_descript);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel5);
            this.bunifuCards1.Controls.Add(this.btn_OK);
            this.bunifuCards1.Controls.Add(this.txt_ReceiveOrg);
            this.bunifuCards1.Controls.Add(this.btn_Cancel);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel3);
            this.bunifuCards1.Controls.Add(this.txt_MessID);
            this.bunifuCards1.Controls.Add(this.txt_Receiver);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel2);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(721, 594);
            this.bunifuCards1.TabIndex = 3;
            // 
            // Form_MsSearchAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 628);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_MsSearchAdd";
            this.Text = "Form_MsSearchAdd";
            this.Load += new System.EventHandler(this.Form_MsSearchAdd_Load);
            this.Title.ResumeLayout(false);
            this.Title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.Content.ResumeLayout(false);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Title;
        public ns1.BunifuCustomLabel Title_Label;
        private ns1.BunifuCustomLabel Title_Lable;
        private ns1.BunifuImageButton Exit;
        private ns1.BunifuMaterialTextbox txt_MessTitle;
        private ns1.BunifuCustomLabel bunifuCustomLabel5;
        private ns1.BunifuMaterialTextbox txt_ReceiveOrg;
        private ns1.BunifuCustomLabel bunifuCustomLabel3;
        private ns1.BunifuMaterialTextbox txt_Receiver;
        private ns1.BunifuCustomLabel bunifuCustomLabel2;
        private ns1.BunifuMaterialTextbox txt_MessID;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private ns1.BunifuThinButton2 btn_Cancel;
        private ns1.BunifuThinButton2 btn_OK;
        private ns1.BunifuCustomLabel lbl_descript;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txt_MessContent;
        private ns1.BunifuCustomLabel bunifuCustomLabel4;
        private System.Windows.Forms.ComboBox cbx_IsHandle;
        private ns1.BunifuMaterialTextbox txt_Attachment;
        private ns1.BunifuCustomLabel bunifuCustomLabel6;
        private ns1.BunifuThinButton2 btnAttachmentInput;
        private System.Windows.Forms.Panel Content;
        private ns1.BunifuCards bunifuCards1;
    }
}