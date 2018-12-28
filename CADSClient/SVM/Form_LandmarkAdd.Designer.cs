namespace SVM
{
    partial class Form_LandmarkAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LandmarkAdd));
            this.Title = new System.Windows.Forms.Panel();
            this.landmark_Label = new ns1.BunifuCustomLabel();
            this.Title_Img = new System.Windows.Forms.PictureBox();
            this.Exit = new ns1.BunifuImageButton();
            this.Content = new System.Windows.Forms.Panel();
            this.bunifuCards1 = new ns1.BunifuCards();
            this.tbx_QTY = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel8 = new ns1.BunifuCustomLabel();
            this.tbx_Unit = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel7 = new ns1.BunifuCustomLabel();
            this.tbx_LandmarkType = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel6 = new ns1.BunifuCustomLabel();
            this.bunifuCustomLabel4 = new ns1.BunifuCustomLabel();
            this.tbx_AdminDivision = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel3 = new ns1.BunifuCustomLabel();
            this.tbx_OrganizationName = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel2 = new ns1.BunifuCustomLabel();
            this.tbx_LandmarkID = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.btn_Cancel = new ns1.BunifuThinButton2();
            this.btn_OK = new ns1.BunifuThinButton2();
            this.lbl_descript = new ns1.BunifuCustomLabel();
            this.tbx_LandmarkDescription = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.tbx_LandmarkName = new ns1.BunifuMaterialTextbox();
            this.Panel_Btn = new System.Windows.Forms.Panel();
            this.btn_Add = new ns1.BunifuFlatButton();
            this.btn_Edit = new ns1.BunifuFlatButton();
            this.btn_delete = new ns1.BunifuFlatButton();
            this.left_Panel = new System.Windows.Forms.Panel();
            this.landmark_List = new System.Windows.Forms.ListBox();
            this.search_Panel = new System.Windows.Forms.Panel();
            this.tbx_Search = new ns1.BunifuMaterialTextbox();
            this.SearchBtn = new ns1.BunifuImageButton();
            this.Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Title_Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.Content.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            this.Panel_Btn.SuspendLayout();
            this.left_Panel.SuspendLayout();
            this.search_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Silver;
            this.Title.Controls.Add(this.landmark_Label);
            this.Title.Controls.Add(this.Title_Img);
            this.Title.Controls.Add(this.Exit);
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(902, 34);
            this.Title.TabIndex = 2;
            // 
            // landmark_Label
            // 
            this.landmark_Label.AutoSize = true;
            this.landmark_Label.Font = new System.Drawing.Font("宋体", 12F);
            this.landmark_Label.ForeColor = System.Drawing.Color.White;
            this.landmark_Label.Location = new System.Drawing.Point(48, 9);
            this.landmark_Label.Name = "landmark_Label";
            this.landmark_Label.Size = new System.Drawing.Size(104, 16);
            this.landmark_Label.TabIndex = 2;
            this.landmark_Label.Text = "重要地标管理";
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
            this.Exit.Location = new System.Drawing.Point(865, 0);
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
            this.Content.Controls.Add(this.Panel_Btn);
            this.Content.Controls.Add(this.left_Panel);
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(0, 34);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(902, 600);
            this.Content.TabIndex = 3;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.tbx_QTY);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel8);
            this.bunifuCards1.Controls.Add(this.tbx_Unit);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel7);
            this.bunifuCards1.Controls.Add(this.tbx_LandmarkType);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel6);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel4);
            this.bunifuCards1.Controls.Add(this.tbx_AdminDivision);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel3);
            this.bunifuCards1.Controls.Add(this.tbx_OrganizationName);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel2);
            this.bunifuCards1.Controls.Add(this.tbx_LandmarkID);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuCards1.Controls.Add(this.btn_Cancel);
            this.bunifuCards1.Controls.Add(this.btn_OK);
            this.bunifuCards1.Controls.Add(this.lbl_descript);
            this.bunifuCards1.Controls.Add(this.tbx_LandmarkDescription);
            this.bunifuCards1.Controls.Add(this.tbx_LandmarkName);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(179, 39);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(723, 561);
            this.bunifuCards1.TabIndex = 2;
            // 
            // tbx_QTY
            // 
            this.tbx_QTY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_QTY.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_QTY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_QTY.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_QTY.HintText = "";
            this.tbx_QTY.isPassword = false;
            this.tbx_QTY.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_QTY.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_QTY.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_QTY.LineThickness = 3;
            this.tbx_QTY.Location = new System.Drawing.Point(154, 239);
            this.tbx_QTY.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_QTY.Name = "tbx_QTY";
            this.tbx_QTY.Size = new System.Drawing.Size(185, 31);
            this.tbx_QTY.TabIndex = 40;
            this.tbx_QTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(58, 254);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(56, 16);
            this.bunifuCustomLabel8.TabIndex = 41;
            this.bunifuCustomLabel8.Text = "数量：";
            // 
            // tbx_Unit
            // 
            this.tbx_Unit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_Unit.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_Unit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_Unit.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_Unit.HintText = "";
            this.tbx_Unit.isPassword = false;
            this.tbx_Unit.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_Unit.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_Unit.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_Unit.LineThickness = 3;
            this.tbx_Unit.Location = new System.Drawing.Point(487, 168);
            this.tbx_Unit.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Unit.Name = "tbx_Unit";
            this.tbx_Unit.Size = new System.Drawing.Size(185, 31);
            this.tbx_Unit.TabIndex = 38;
            this.tbx_Unit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.AutoSize = true;
            this.bunifuCustomLabel7.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(391, 183);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(56, 16);
            this.bunifuCustomLabel7.TabIndex = 39;
            this.bunifuCustomLabel7.Text = "单位：";
            // 
            // tbx_LandmarkType
            // 
            this.tbx_LandmarkType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_LandmarkType.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_LandmarkType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_LandmarkType.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_LandmarkType.HintText = "";
            this.tbx_LandmarkType.isPassword = false;
            this.tbx_LandmarkType.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_LandmarkType.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_LandmarkType.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_LandmarkType.LineThickness = 3;
            this.tbx_LandmarkType.Location = new System.Drawing.Point(154, 168);
            this.tbx_LandmarkType.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_LandmarkType.Name = "tbx_LandmarkType";
            this.tbx_LandmarkType.Size = new System.Drawing.Size(185, 31);
            this.tbx_LandmarkType.TabIndex = 36;
            this.tbx_LandmarkType.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(58, 183);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel6.TabIndex = 37;
            this.bunifuCustomLabel6.Text = "地标性质：";
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(391, 43);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel4.TabIndex = 30;
            this.bunifuCustomLabel4.Text = "地标名称：";
            // 
            // tbx_AdminDivision
            // 
            this.tbx_AdminDivision.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_AdminDivision.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_AdminDivision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_AdminDivision.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_AdminDivision.HintText = "";
            this.tbx_AdminDivision.isPassword = false;
            this.tbx_AdminDivision.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_AdminDivision.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_AdminDivision.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_AdminDivision.LineThickness = 3;
            this.tbx_AdminDivision.Location = new System.Drawing.Point(487, 95);
            this.tbx_AdminDivision.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_AdminDivision.Name = "tbx_AdminDivision";
            this.tbx_AdminDivision.Size = new System.Drawing.Size(185, 31);
            this.tbx_AdminDivision.TabIndex = 28;
            this.tbx_AdminDivision.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(391, 110);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel3.TabIndex = 29;
            this.bunifuCustomLabel3.Text = "行政区划：";
            // 
            // tbx_OrganizationName
            // 
            this.tbx_OrganizationName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_OrganizationName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_OrganizationName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_OrganizationName.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_OrganizationName.HintText = "";
            this.tbx_OrganizationName.isPassword = false;
            this.tbx_OrganizationName.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_OrganizationName.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_OrganizationName.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_OrganizationName.LineThickness = 3;
            this.tbx_OrganizationName.Location = new System.Drawing.Point(154, 95);
            this.tbx_OrganizationName.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_OrganizationName.Name = "tbx_OrganizationName";
            this.tbx_OrganizationName.Size = new System.Drawing.Size(185, 31);
            this.tbx_OrganizationName.TabIndex = 26;
            this.tbx_OrganizationName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(58, 110);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel2.TabIndex = 27;
            this.bunifuCustomLabel2.Text = "单位名称：";
            // 
            // tbx_LandmarkID
            // 
            this.tbx_LandmarkID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_LandmarkID.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_LandmarkID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_LandmarkID.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_LandmarkID.HintText = "";
            this.tbx_LandmarkID.isPassword = false;
            this.tbx_LandmarkID.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_LandmarkID.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_LandmarkID.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_LandmarkID.LineThickness = 3;
            this.tbx_LandmarkID.Location = new System.Drawing.Point(154, 28);
            this.tbx_LandmarkID.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_LandmarkID.Name = "tbx_LandmarkID";
            this.tbx_LandmarkID.Size = new System.Drawing.Size(185, 31);
            this.tbx_LandmarkID.TabIndex = 24;
            this.tbx_LandmarkID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(58, 43);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel1.TabIndex = 25;
            this.bunifuCustomLabel1.Text = "地标编号：";
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
            this.btn_Cancel.Location = new System.Drawing.Point(405, 489);
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
            this.btn_OK.Location = new System.Drawing.Point(154, 489);
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
            this.lbl_descript.Location = new System.Drawing.Point(58, 331);
            this.lbl_descript.Name = "lbl_descript";
            this.lbl_descript.Size = new System.Drawing.Size(88, 16);
            this.lbl_descript.TabIndex = 23;
            this.lbl_descript.Text = "相关说明：";
            // 
            // tbx_LandmarkDescription
            // 
            this.tbx_LandmarkDescription.BorderColor = System.Drawing.Color.Black;
            this.tbx_LandmarkDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_LandmarkDescription.Location = new System.Drawing.Point(61, 354);
            this.tbx_LandmarkDescription.Multiline = true;
            this.tbx_LandmarkDescription.Name = "tbx_LandmarkDescription";
            this.tbx_LandmarkDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_LandmarkDescription.Size = new System.Drawing.Size(611, 113);
            this.tbx_LandmarkDescription.TabIndex = 8;
            // 
            // tbx_LandmarkName
            // 
            this.tbx_LandmarkName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_LandmarkName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_LandmarkName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_LandmarkName.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_LandmarkName.HintText = "";
            this.tbx_LandmarkName.isPassword = false;
            this.tbx_LandmarkName.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_LandmarkName.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_LandmarkName.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_LandmarkName.LineThickness = 3;
            this.tbx_LandmarkName.Location = new System.Drawing.Point(487, 28);
            this.tbx_LandmarkName.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_LandmarkName.Name = "tbx_LandmarkName";
            this.tbx_LandmarkName.Size = new System.Drawing.Size(185, 31);
            this.tbx_LandmarkName.TabIndex = 2;
            this.tbx_LandmarkName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Panel_Btn
            // 
            this.Panel_Btn.BackColor = System.Drawing.Color.Gray;
            this.Panel_Btn.Controls.Add(this.btn_Add);
            this.Panel_Btn.Controls.Add(this.btn_Edit);
            this.Panel_Btn.Controls.Add(this.btn_delete);
            this.Panel_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Btn.Location = new System.Drawing.Point(179, 0);
            this.Panel_Btn.Name = "Panel_Btn";
            this.Panel_Btn.Size = new System.Drawing.Size(723, 39);
            this.Panel_Btn.TabIndex = 1;
            // 
            // btn_Add
            // 
            this.btn_Add.Activecolor = System.Drawing.Color.Black;
            this.btn_Add.BackColor = System.Drawing.Color.Transparent;
            this.btn_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Add.BorderRadius = 0;
            this.btn_Add.ButtonText = " 添加";
            this.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Add.DisabledColor = System.Drawing.Color.Gray;
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Add.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_Add.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_Add.Iconimage")));
            this.btn_Add.Iconimage_right = null;
            this.btn_Add.Iconimage_right_Selected = null;
            this.btn_Add.Iconimage_Selected = null;
            this.btn_Add.IconMarginLeft = 0;
            this.btn_Add.IconMarginRight = 0;
            this.btn_Add.IconRightVisible = true;
            this.btn_Add.IconRightZoom = 0D;
            this.btn_Add.IconVisible = true;
            this.btn_Add.IconZoom = 60D;
            this.btn_Add.IsTab = false;
            this.btn_Add.Location = new System.Drawing.Point(471, 0);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_Add.OnHovercolor = System.Drawing.Color.Silver;
            this.btn_Add.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_Add.selected = false;
            this.btn_Add.Size = new System.Drawing.Size(84, 39);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = " 添加";
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.Textcolor = System.Drawing.Color.White;
            this.btn_Add.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Activecolor = System.Drawing.Color.Black;
            this.btn_Edit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Edit.BorderRadius = 0;
            this.btn_Edit.ButtonText = "编辑";
            this.btn_Edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Edit.DisabledColor = System.Drawing.Color.Gray;
            this.btn_Edit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Edit.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_Edit.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_Edit.Iconimage")));
            this.btn_Edit.Iconimage_right = null;
            this.btn_Edit.Iconimage_right_Selected = null;
            this.btn_Edit.Iconimage_Selected = null;
            this.btn_Edit.IconMarginLeft = 0;
            this.btn_Edit.IconMarginRight = 0;
            this.btn_Edit.IconRightVisible = true;
            this.btn_Edit.IconRightZoom = 0D;
            this.btn_Edit.IconVisible = true;
            this.btn_Edit.IconZoom = 60D;
            this.btn_Edit.IsTab = false;
            this.btn_Edit.Location = new System.Drawing.Point(555, 0);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_Edit.OnHovercolor = System.Drawing.Color.Silver;
            this.btn_Edit.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_Edit.selected = false;
            this.btn_Edit.Size = new System.Drawing.Size(84, 39);
            this.btn_Edit.TabIndex = 1;
            this.btn_Edit.Text = "编辑";
            this.btn_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Edit.Textcolor = System.Drawing.Color.White;
            this.btn_Edit.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Activecolor = System.Drawing.Color.Black;
            this.btn_delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_delete.BorderRadius = 0;
            this.btn_delete.ButtonText = "删除";
            this.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.DisabledColor = System.Drawing.Color.Gray;
            this.btn_delete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_delete.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_delete.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_delete.Iconimage")));
            this.btn_delete.Iconimage_right = null;
            this.btn_delete.Iconimage_right_Selected = null;
            this.btn_delete.Iconimage_Selected = null;
            this.btn_delete.IconMarginLeft = 0;
            this.btn_delete.IconMarginRight = 0;
            this.btn_delete.IconRightVisible = true;
            this.btn_delete.IconRightZoom = 0D;
            this.btn_delete.IconVisible = true;
            this.btn_delete.IconZoom = 60D;
            this.btn_delete.IsTab = false;
            this.btn_delete.Location = new System.Drawing.Point(639, 0);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_delete.OnHovercolor = System.Drawing.Color.Silver;
            this.btn_delete.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_delete.selected = false;
            this.btn_delete.Size = new System.Drawing.Size(84, 39);
            this.btn_delete.TabIndex = 0;
            this.btn_delete.Text = "删除";
            this.btn_delete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delete.Textcolor = System.Drawing.Color.White;
            this.btn_delete.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // left_Panel
            // 
            this.left_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.left_Panel.Controls.Add(this.landmark_List);
            this.left_Panel.Controls.Add(this.search_Panel);
            this.left_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.left_Panel.Location = new System.Drawing.Point(0, 0);
            this.left_Panel.Name = "left_Panel";
            this.left_Panel.Size = new System.Drawing.Size(179, 600);
            this.left_Panel.TabIndex = 0;
            // 
            // landmark_List
            // 
            this.landmark_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.landmark_List.FormattingEnabled = true;
            this.landmark_List.ItemHeight = 12;
            this.landmark_List.Location = new System.Drawing.Point(0, 39);
            this.landmark_List.Name = "landmark_List";
            this.landmark_List.Size = new System.Drawing.Size(179, 561);
            this.landmark_List.TabIndex = 1;
            this.landmark_List.Click += new System.EventHandler(this.landmark_List_Click);
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
            this.tbx_Search.Text = "请输入地标名称";
            this.tbx_Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbx_Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_Search_KeyPress);
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
            // Form_LandmarkAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 634);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_LandmarkAdd";
            this.Text = "Form_Landmark";
            this.Title.ResumeLayout(false);
            this.Title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Title_Img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.Content.ResumeLayout(false);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.Panel_Btn.ResumeLayout(false);
            this.left_Panel.ResumeLayout(false);
            this.search_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SearchBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Title;
        private ns1.BunifuCustomLabel landmark_Label;
        private System.Windows.Forms.PictureBox Title_Img;
        private ns1.BunifuImageButton Exit;
        private System.Windows.Forms.Panel Content;
        private ns1.BunifuCards bunifuCards1;
        private ns1.BunifuCustomLabel bunifuCustomLabel4;
        private ns1.BunifuMaterialTextbox tbx_AdminDivision;
        private ns1.BunifuCustomLabel bunifuCustomLabel3;
        private ns1.BunifuMaterialTextbox tbx_OrganizationName;
        private ns1.BunifuCustomLabel bunifuCustomLabel2;
        private ns1.BunifuMaterialTextbox tbx_LandmarkID;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private ns1.BunifuThinButton2 btn_Cancel;
        private ns1.BunifuThinButton2 btn_OK;
        private ns1.BunifuCustomLabel lbl_descript;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox tbx_LandmarkDescription;
        private ns1.BunifuMaterialTextbox tbx_LandmarkName;
        private System.Windows.Forms.Panel Panel_Btn;
        private ns1.BunifuFlatButton btn_Add;
        private ns1.BunifuFlatButton btn_Edit;
        private ns1.BunifuFlatButton btn_delete;
        private System.Windows.Forms.Panel left_Panel;
        private System.Windows.Forms.ListBox landmark_List;
        private System.Windows.Forms.Panel search_Panel;
        private ns1.BunifuMaterialTextbox tbx_Search;
        private ns1.BunifuImageButton SearchBtn;
        private ns1.BunifuMaterialTextbox tbx_QTY;
        private ns1.BunifuCustomLabel bunifuCustomLabel8;
        private ns1.BunifuMaterialTextbox tbx_Unit;
        private ns1.BunifuCustomLabel bunifuCustomLabel7;
        private ns1.BunifuMaterialTextbox tbx_LandmarkType;
        private ns1.BunifuCustomLabel bunifuCustomLabel6;
    }
}