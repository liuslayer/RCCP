namespace SVM
{
    partial class Form_LawFileAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LawFileAdd));
            this.Title = new System.Windows.Forms.Panel();
            this.Title_Label = new ns1.BunifuCustomLabel();
            this.Title_Img = new System.Windows.Forms.PictureBox();
            this.Exit = new ns1.BunifuImageButton();
            this.Content = new System.Windows.Forms.Panel();
            this.bunifuCards1 = new ns1.BunifuCards();
            this.tbx_IssueVersion = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel4 = new ns1.BunifuCustomLabel();
            this.tbx_IssueOrganization = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel3 = new ns1.BunifuCustomLabel();
            this.dtp_IssueTime = new System.Windows.Forms.DateTimePicker();
            this.bunifuCustomLabel2 = new ns1.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.cbx_FileType = new System.Windows.Forms.ComboBox();
            this.btnFileInput = new ns1.BunifuThinButton2();
            this.tbx_FilePath = new ns1.BunifuMaterialTextbox();
            this.btn_Cancel = new ns1.BunifuThinButton2();
            this.btn_OK = new ns1.BunifuThinButton2();
            this.lbl_descript = new ns1.BunifuCustomLabel();
            this.tbx_Descrpition = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.tbx_FileName = new ns1.BunifuMaterialTextbox();
            this.lbl_FileName = new ns1.BunifuCustomLabel();
            this.left_Panel = new System.Windows.Forms.Panel();
            this.LawFile_List = new System.Windows.Forms.ListBox();
            this.search_Panel = new System.Windows.Forms.Panel();
            this.tbx_Search = new ns1.BunifuMaterialTextbox();
            this.SearchBtn = new ns1.BunifuImageButton();
            this.Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Title_Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.Content.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            this.left_Panel.SuspendLayout();
            this.search_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Silver;
            this.Title.Controls.Add(this.Title_Label);
            this.Title.Controls.Add(this.Title_Img);
            this.Title.Controls.Add(this.Exit);
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(736, 34);
            this.Title.TabIndex = 1;
            // 
            // Title_Label
            // 
            this.Title_Label.AutoSize = true;
            this.Title_Label.Font = new System.Drawing.Font("宋体", 12F);
            this.Title_Label.ForeColor = System.Drawing.Color.White;
            this.Title_Label.Location = new System.Drawing.Point(48, 9);
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.Size = new System.Drawing.Size(104, 16);
            this.Title_Label.TabIndex = 2;
            this.Title_Label.Text = "文件法规管理";
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
            this.Exit.Location = new System.Drawing.Point(699, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(37, 34);
            this.Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Exit.TabIndex = 0;
            this.Exit.TabStop = false;
            this.Exit.Zoom = 10;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Content
            // 
            this.Content.Controls.Add(this.bunifuCards1);
            this.Content.Controls.Add(this.left_Panel);
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(0, 34);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(736, 569);
            this.Content.TabIndex = 2;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.tbx_IssueVersion);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel4);
            this.bunifuCards1.Controls.Add(this.tbx_IssueOrganization);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel3);
            this.bunifuCards1.Controls.Add(this.dtp_IssueTime);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel2);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuCards1.Controls.Add(this.cbx_FileType);
            this.bunifuCards1.Controls.Add(this.btnFileInput);
            this.bunifuCards1.Controls.Add(this.tbx_FilePath);
            this.bunifuCards1.Controls.Add(this.btn_Cancel);
            this.bunifuCards1.Controls.Add(this.btn_OK);
            this.bunifuCards1.Controls.Add(this.lbl_descript);
            this.bunifuCards1.Controls.Add(this.tbx_Descrpition);
            this.bunifuCards1.Controls.Add(this.tbx_FileName);
            this.bunifuCards1.Controls.Add(this.lbl_FileName);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(179, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(557, 569);
            this.bunifuCards1.TabIndex = 2;
            // 
            // tbx_IssueVersion
            // 
            this.tbx_IssueVersion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_IssueVersion.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_IssueVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_IssueVersion.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_IssueVersion.HintText = "";
            this.tbx_IssueVersion.isPassword = false;
            this.tbx_IssueVersion.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_IssueVersion.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_IssueVersion.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_IssueVersion.LineThickness = 3;
            this.tbx_IssueVersion.Location = new System.Drawing.Point(153, 240);
            this.tbx_IssueVersion.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_IssueVersion.Name = "tbx_IssueVersion";
            this.tbx_IssueVersion.Size = new System.Drawing.Size(277, 31);
            this.tbx_IssueVersion.TabIndex = 33;
            this.tbx_IssueVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(58, 255);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(104, 16);
            this.bunifuCustomLabel4.TabIndex = 32;
            this.bunifuCustomLabel4.Text = "发布版本号：";
            // 
            // tbx_IssueOrganization
            // 
            this.tbx_IssueOrganization.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_IssueOrganization.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_IssueOrganization.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_IssueOrganization.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_IssueOrganization.HintText = "";
            this.tbx_IssueOrganization.isPassword = false;
            this.tbx_IssueOrganization.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_IssueOrganization.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_IssueOrganization.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_IssueOrganization.LineThickness = 3;
            this.tbx_IssueOrganization.Location = new System.Drawing.Point(154, 188);
            this.tbx_IssueOrganization.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_IssueOrganization.Name = "tbx_IssueOrganization";
            this.tbx_IssueOrganization.Size = new System.Drawing.Size(277, 31);
            this.tbx_IssueOrganization.TabIndex = 31;
            this.tbx_IssueOrganization.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(59, 203);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel3.TabIndex = 30;
            this.bunifuCustomLabel3.Text = "发布单位：";
            // 
            // dtp_IssueTime
            // 
            this.dtp_IssueTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_IssueTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_IssueTime.Location = new System.Drawing.Point(154, 151);
            this.dtp_IssueTime.Name = "dtp_IssueTime";
            this.dtp_IssueTime.Size = new System.Drawing.Size(200, 21);
            this.dtp_IssueTime.TabIndex = 29;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(59, 151);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel2.TabIndex = 28;
            this.bunifuCustomLabel2.Text = "发布时间：";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(58, 97);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel1.TabIndex = 27;
            this.bunifuCustomLabel1.Text = "文件类型：";
            // 
            // cbx_FileType
            // 
            this.cbx_FileType.FormattingEnabled = true;
            this.cbx_FileType.Location = new System.Drawing.Point(154, 98);
            this.cbx_FileType.Name = "cbx_FileType";
            this.cbx_FileType.Size = new System.Drawing.Size(132, 20);
            this.cbx_FileType.TabIndex = 26;
            // 
            // btnFileInput
            // 
            this.btnFileInput.ActiveBorderThickness = 1;
            this.btnFileInput.ActiveCornerRadius = 5;
            this.btnFileInput.ActiveFillColor = System.Drawing.Color.White;
            this.btnFileInput.ActiveForecolor = System.Drawing.Color.Black;
            this.btnFileInput.ActiveLineColor = System.Drawing.Color.Black;
            this.btnFileInput.BackColor = System.Drawing.Color.White;
            this.btnFileInput.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFileInput.BackgroundImage")));
            this.btnFileInput.ButtonText = "导入文件";
            this.btnFileInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFileInput.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileInput.ForeColor = System.Drawing.Color.Black;
            this.btnFileInput.IdleBorderThickness = 1;
            this.btnFileInput.IdleCornerRadius = 5;
            this.btnFileInput.IdleFillColor = System.Drawing.Color.Gray;
            this.btnFileInput.IdleForecolor = System.Drawing.Color.White;
            this.btnFileInput.IdleLineColor = System.Drawing.Color.Black;
            this.btnFileInput.Location = new System.Drawing.Point(331, 290);
            this.btnFileInput.Margin = new System.Windows.Forms.Padding(5);
            this.btnFileInput.Name = "btnFileInput";
            this.btnFileInput.Size = new System.Drawing.Size(101, 35);
            this.btnFileInput.TabIndex = 25;
            this.btnFileInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFileInput.Click += new System.EventHandler(this.btnFileInput_Click);
            // 
            // tbx_FilePath
            // 
            this.tbx_FilePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_FilePath.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_FilePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_FilePath.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_FilePath.HintText = "";
            this.tbx_FilePath.isPassword = false;
            this.tbx_FilePath.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_FilePath.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_FilePath.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_FilePath.LineThickness = 3;
            this.tbx_FilePath.Location = new System.Drawing.Point(62, 290);
            this.tbx_FilePath.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_FilePath.Name = "tbx_FilePath";
            this.tbx_FilePath.Size = new System.Drawing.Size(260, 31);
            this.tbx_FilePath.TabIndex = 24;
            this.tbx_FilePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.btn_Cancel.Location = new System.Drawing.Point(312, 501);
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
            this.btn_OK.Location = new System.Drawing.Point(61, 501);
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
            this.lbl_descript.Location = new System.Drawing.Point(59, 339);
            this.lbl_descript.Name = "lbl_descript";
            this.lbl_descript.Size = new System.Drawing.Size(56, 16);
            this.lbl_descript.TabIndex = 23;
            this.lbl_descript.Text = "描述：";
            // 
            // tbx_Descrpition
            // 
            this.tbx_Descrpition.BorderColor = System.Drawing.Color.Black;
            this.tbx_Descrpition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_Descrpition.Location = new System.Drawing.Point(62, 362);
            this.tbx_Descrpition.Multiline = true;
            this.tbx_Descrpition.Name = "tbx_Descrpition";
            this.tbx_Descrpition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Descrpition.Size = new System.Drawing.Size(369, 113);
            this.tbx_Descrpition.TabIndex = 8;
            // 
            // tbx_FileName
            // 
            this.tbx_FileName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_FileName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_FileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_FileName.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_FileName.HintText = "";
            this.tbx_FileName.isPassword = false;
            this.tbx_FileName.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_FileName.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_FileName.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_FileName.LineThickness = 3;
            this.tbx_FileName.Location = new System.Drawing.Point(154, 30);
            this.tbx_FileName.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_FileName.Name = "tbx_FileName";
            this.tbx_FileName.Size = new System.Drawing.Size(277, 31);
            this.tbx_FileName.TabIndex = 1;
            this.tbx_FileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.AutoSize = true;
            this.lbl_FileName.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_FileName.Location = new System.Drawing.Point(59, 45);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(72, 16);
            this.lbl_FileName.TabIndex = 1;
            this.lbl_FileName.Text = "文件名：";
            // 
            // left_Panel
            // 
            this.left_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.left_Panel.Controls.Add(this.LawFile_List);
            this.left_Panel.Controls.Add(this.search_Panel);
            this.left_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.left_Panel.Location = new System.Drawing.Point(0, 0);
            this.left_Panel.Name = "left_Panel";
            this.left_Panel.Size = new System.Drawing.Size(179, 569);
            this.left_Panel.TabIndex = 0;
            // 
            // LawFile_List
            // 
            this.LawFile_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LawFile_List.FormattingEnabled = true;
            this.LawFile_List.ItemHeight = 12;
            this.LawFile_List.Location = new System.Drawing.Point(0, 39);
            this.LawFile_List.Name = "LawFile_List";
            this.LawFile_List.Size = new System.Drawing.Size(179, 530);
            this.LawFile_List.TabIndex = 1;
            // 
            // search_Panel
            // 
            this.search_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.search_Panel.Controls.Add(this.tbx_Search);
            this.search_Panel.Controls.Add(this.SearchBtn);
            this.search_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.search_Panel.Location = new System.Drawing.Point(0, 0);
            this.search_Panel.Name = "search_Panel";
            this.search_Panel.Size = new System.Drawing.Size(179, 39);
            this.search_Panel.TabIndex = 0;
            // 
            // tbx_Search
            // 
            this.tbx_Search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_Search.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_Search.ForeColor = System.Drawing.Color.Black;
            this.tbx_Search.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_Search.HintText = "";
            this.tbx_Search.isPassword = false;
            this.tbx_Search.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbx_Search.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_Search.LineMouseHoverColor = System.Drawing.Color.Black;
            this.tbx_Search.LineThickness = 1;
            this.tbx_Search.Location = new System.Drawing.Point(4, 7);
            this.tbx_Search.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Search.Name = "tbx_Search";
            this.tbx_Search.Size = new System.Drawing.Size(134, 28);
            this.tbx_Search.TabIndex = 2;
            this.tbx_Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.Transparent;
            this.SearchBtn.Image = ((System.Drawing.Image)(resources.GetObject("SearchBtn.Image")));
            this.SearchBtn.ImageActive = null;
            this.SearchBtn.Location = new System.Drawing.Point(145, 6);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(28, 29);
            this.SearchBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SearchBtn.TabIndex = 1;
            this.SearchBtn.TabStop = false;
            this.SearchBtn.Zoom = 10;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // Form_LawFileAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 603);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_LawFileAdd";
            this.Text = "Form_LawFileAdd";
            this.Load += new System.EventHandler(this.Form_LawFileAdd_Load);
            this.Title.ResumeLayout(false);
            this.Title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Title_Img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.Content.ResumeLayout(false);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.left_Panel.ResumeLayout(false);
            this.search_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SearchBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Title;
        public ns1.BunifuCustomLabel Title_Label;
        private System.Windows.Forms.PictureBox Title_Img;
        private ns1.BunifuImageButton Exit;
        private System.Windows.Forms.Panel Content;
        private ns1.BunifuCards bunifuCards1;
        private ns1.BunifuThinButton2 btnFileInput;
        private ns1.BunifuMaterialTextbox tbx_FilePath;
        private ns1.BunifuThinButton2 btn_Cancel;
        private ns1.BunifuThinButton2 btn_OK;
        private ns1.BunifuCustomLabel lbl_descript;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox tbx_Descrpition;
        private ns1.BunifuMaterialTextbox tbx_FileName;
        private ns1.BunifuCustomLabel lbl_FileName;
        private System.Windows.Forms.Panel left_Panel;
        private System.Windows.Forms.ListBox LawFile_List;
        private System.Windows.Forms.Panel search_Panel;
        private ns1.BunifuMaterialTextbox tbx_Search;
        private ns1.BunifuImageButton SearchBtn;
        private ns1.BunifuMaterialTextbox tbx_IssueOrganization;
        private ns1.BunifuCustomLabel bunifuCustomLabel3;
        private System.Windows.Forms.DateTimePicker dtp_IssueTime;
        private ns1.BunifuCustomLabel bunifuCustomLabel2;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.ComboBox cbx_FileType;
        private ns1.BunifuMaterialTextbox tbx_IssueVersion;
        private ns1.BunifuCustomLabel bunifuCustomLabel4;
    }
}