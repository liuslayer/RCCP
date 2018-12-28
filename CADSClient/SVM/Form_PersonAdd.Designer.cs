namespace SVM
{
    partial class Form_PersonAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PersonAdd));
            this.Title = new System.Windows.Forms.Panel();
            this.Title_Lable = new ns1.BunifuCustomLabel();
            this.Title_Img = new System.Windows.Forms.PictureBox();
            this.Exit = new ns1.BunifuImageButton();
            this.Form_Move = new ns1.BunifuDragControl(this.components);
            this.Content = new System.Windows.Forms.Panel();
            this.bunifuCards1 = new ns1.BunifuCards();
            this.btn_Cancel = new ns1.BunifuThinButton2();
            this.TimePicker_DateOfBirth = new ns1.BunifuDatepicker();
            this.btn_OK = new ns1.BunifuThinButton2();
            this.lbl_descript = new ns1.BunifuCustomLabel();
            this.tbx_descrip = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.tbx_Unit = new ns1.BunifuMaterialTextbox();
            this.lbl_Unit = new ns1.BunifuCustomLabel();
            this.tbx_post = new ns1.BunifuMaterialTextbox();
            this.lbl_post = new ns1.BunifuCustomLabel();
            this.tbx_contactinfo = new ns1.BunifuMaterialTextbox();
            this.lbl_contactinfo = new ns1.BunifuCustomLabel();
            this.TimePicker_Outtime = new ns1.BunifuDatepicker();
            this.lbl_OutTime = new ns1.BunifuCustomLabel();
            this.TimePicker_Intime = new ns1.BunifuDatepicker();
            this.lbl_Intime = new ns1.BunifuCustomLabel();
            this.tbx_DegreeOfEducation = new ns1.BunifuMaterialTextbox();
            this.lbl_DegreeOfEducation = new ns1.BunifuCustomLabel();
            this.lbl_DateOfBirth = new ns1.BunifuCustomLabel();
            this.tbx_place = new ns1.BunifuMaterialTextbox();
            this.lbl_Place = new ns1.BunifuCustomLabel();
            this.tbx_Nation = new ns1.BunifuMaterialTextbox();
            this.lbl_Nation = new ns1.BunifuCustomLabel();
            this.tbx_ID = new ns1.BunifuMaterialTextbox();
            this.lbl_ID = new ns1.BunifuCustomLabel();
            this.tbx_Name = new ns1.BunifuMaterialTextbox();
            this.lbl_Name = new ns1.BunifuCustomLabel();
            this.Panel_Btn = new System.Windows.Forms.Panel();
            this.btn_Add = new ns1.BunifuFlatButton();
            this.btn_Edit = new ns1.BunifuFlatButton();
            this.btn_delete = new ns1.BunifuFlatButton();
            this.left_Panel = new System.Windows.Forms.Panel();
            this.Person_List = new System.Windows.Forms.ListBox();
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
            this.Title.Controls.Add(this.Title_Lable);
            this.Title.Controls.Add(this.Title_Img);
            this.Title.Controls.Add(this.Exit);
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(901, 34);
            this.Title.TabIndex = 0;
            // 
            // Title_Lable
            // 
            this.Title_Lable.AutoSize = true;
            this.Title_Lable.Font = new System.Drawing.Font("宋体", 12F);
            this.Title_Lable.ForeColor = System.Drawing.Color.White;
            this.Title_Lable.Location = new System.Drawing.Point(48, 9);
            this.Title_Lable.Name = "Title_Lable";
            this.Title_Lable.Size = new System.Drawing.Size(72, 16);
            this.Title_Lable.TabIndex = 2;
            this.Title_Lable.Text = "人员管理";
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
            this.Exit.Location = new System.Drawing.Point(864, 0);
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
            this.Content.Controls.Add(this.left_Panel);
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(0, 34);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(901, 550);
            this.Content.TabIndex = 1;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.btn_Cancel);
            this.bunifuCards1.Controls.Add(this.TimePicker_DateOfBirth);
            this.bunifuCards1.Controls.Add(this.btn_OK);
            this.bunifuCards1.Controls.Add(this.lbl_descript);
            this.bunifuCards1.Controls.Add(this.tbx_descrip);
            this.bunifuCards1.Controls.Add(this.tbx_Unit);
            this.bunifuCards1.Controls.Add(this.lbl_Unit);
            this.bunifuCards1.Controls.Add(this.tbx_post);
            this.bunifuCards1.Controls.Add(this.lbl_post);
            this.bunifuCards1.Controls.Add(this.tbx_contactinfo);
            this.bunifuCards1.Controls.Add(this.lbl_contactinfo);
            this.bunifuCards1.Controls.Add(this.TimePicker_Outtime);
            this.bunifuCards1.Controls.Add(this.lbl_OutTime);
            this.bunifuCards1.Controls.Add(this.TimePicker_Intime);
            this.bunifuCards1.Controls.Add(this.lbl_Intime);
            this.bunifuCards1.Controls.Add(this.tbx_DegreeOfEducation);
            this.bunifuCards1.Controls.Add(this.lbl_DegreeOfEducation);
            this.bunifuCards1.Controls.Add(this.lbl_DateOfBirth);
            this.bunifuCards1.Controls.Add(this.tbx_place);
            this.bunifuCards1.Controls.Add(this.lbl_Place);
            this.bunifuCards1.Controls.Add(this.tbx_Nation);
            this.bunifuCards1.Controls.Add(this.lbl_Nation);
            this.bunifuCards1.Controls.Add(this.tbx_ID);
            this.bunifuCards1.Controls.Add(this.lbl_ID);
            this.bunifuCards1.Controls.Add(this.tbx_Name);
            this.bunifuCards1.Controls.Add(this.lbl_Name);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(216, 39);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(685, 511);
            this.bunifuCards1.TabIndex = 2;
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
            this.btn_Cancel.Location = new System.Drawing.Point(380, 453);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(101, 48);
            this.btn_Cancel.TabIndex = 26;
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // TimePicker_DateOfBirth
            // 
            this.TimePicker_DateOfBirth.BackColor = System.Drawing.Color.Gray;
            this.TimePicker_DateOfBirth.BorderRadius = 0;
            this.TimePicker_DateOfBirth.ForeColor = System.Drawing.Color.White;
            this.TimePicker_DateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.TimePicker_DateOfBirth.FormatCustom = null;
            this.TimePicker_DateOfBirth.Location = new System.Drawing.Point(438, 122);
            this.TimePicker_DateOfBirth.Name = "TimePicker_DateOfBirth";
            this.TimePicker_DateOfBirth.Size = new System.Drawing.Size(195, 33);
            this.TimePicker_DateOfBirth.TabIndex = 12;
            this.TimePicker_DateOfBirth.Value = new System.DateTime(2017, 2, 20, 18, 1, 2, 548);
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
            this.btn_OK.Location = new System.Drawing.Point(129, 453);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(5);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(101, 48);
            this.btn_OK.TabIndex = 25;
            this.btn_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_descript
            // 
            this.lbl_descript.AutoSize = true;
            this.lbl_descript.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_descript.Location = new System.Drawing.Point(55, 315);
            this.lbl_descript.Name = "lbl_descript";
            this.lbl_descript.Size = new System.Drawing.Size(88, 16);
            this.lbl_descript.TabIndex = 23;
            this.lbl_descript.Text = "个人描述：";
            // 
            // tbx_descrip
            // 
            this.tbx_descrip.BorderColor = System.Drawing.Color.Black;
            this.tbx_descrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_descrip.Location = new System.Drawing.Point(58, 338);
            this.tbx_descrip.Multiline = true;
            this.tbx_descrip.Name = "tbx_descrip";
            this.tbx_descrip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_descrip.Size = new System.Drawing.Size(574, 101);
            this.tbx_descrip.TabIndex = 24;
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
            this.tbx_Unit.Location = new System.Drawing.Point(130, 263);
            this.tbx_Unit.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Unit.Name = "tbx_Unit";
            this.tbx_Unit.Size = new System.Drawing.Size(500, 31);
            this.tbx_Unit.TabIndex = 22;
            this.tbx_Unit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_Unit
            // 
            this.lbl_Unit.AutoSize = true;
            this.lbl_Unit.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Unit.Location = new System.Drawing.Point(53, 278);
            this.lbl_Unit.Name = "lbl_Unit";
            this.lbl_Unit.Size = new System.Drawing.Size(88, 16);
            this.lbl_Unit.TabIndex = 21;
            this.lbl_Unit.Text = "所属单位：";
            // 
            // tbx_post
            // 
            this.tbx_post.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_post.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_post.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_post.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_post.HintText = "";
            this.tbx_post.isPassword = false;
            this.tbx_post.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_post.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_post.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_post.LineThickness = 3;
            this.tbx_post.Location = new System.Drawing.Point(438, 218);
            this.tbx_post.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_post.Name = "tbx_post";
            this.tbx_post.Size = new System.Drawing.Size(191, 31);
            this.tbx_post.TabIndex = 20;
            this.tbx_post.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_post
            // 
            this.lbl_post.AutoSize = true;
            this.lbl_post.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_post.Location = new System.Drawing.Point(393, 233);
            this.lbl_post.Name = "lbl_post";
            this.lbl_post.Size = new System.Drawing.Size(56, 16);
            this.lbl_post.TabIndex = 19;
            this.lbl_post.Text = "职务：";
            // 
            // tbx_contactinfo
            // 
            this.tbx_contactinfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_contactinfo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_contactinfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_contactinfo.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_contactinfo.HintText = "";
            this.tbx_contactinfo.isPassword = false;
            this.tbx_contactinfo.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_contactinfo.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_contactinfo.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_contactinfo.LineThickness = 3;
            this.tbx_contactinfo.Location = new System.Drawing.Point(132, 218);
            this.tbx_contactinfo.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_contactinfo.Name = "tbx_contactinfo";
            this.tbx_contactinfo.Size = new System.Drawing.Size(191, 31);
            this.tbx_contactinfo.TabIndex = 18;
            this.tbx_contactinfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_contactinfo
            // 
            this.lbl_contactinfo.AutoSize = true;
            this.lbl_contactinfo.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_contactinfo.Location = new System.Drawing.Point(55, 233);
            this.lbl_contactinfo.Name = "lbl_contactinfo";
            this.lbl_contactinfo.Size = new System.Drawing.Size(88, 16);
            this.lbl_contactinfo.TabIndex = 17;
            this.lbl_contactinfo.Text = "联系方式：";
            // 
            // TimePicker_Outtime
            // 
            this.TimePicker_Outtime.BackColor = System.Drawing.Color.Gray;
            this.TimePicker_Outtime.BorderRadius = 0;
            this.TimePicker_Outtime.ForeColor = System.Drawing.Color.White;
            this.TimePicker_Outtime.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.TimePicker_Outtime.FormatCustom = null;
            this.TimePicker_Outtime.Location = new System.Drawing.Point(437, 176);
            this.TimePicker_Outtime.Name = "TimePicker_Outtime";
            this.TimePicker_Outtime.Size = new System.Drawing.Size(195, 33);
            this.TimePicker_Outtime.TabIndex = 16;
            this.TimePicker_Outtime.Value = new System.DateTime(2017, 2, 20, 18, 1, 2, 548);
            // 
            // lbl_OutTime
            // 
            this.lbl_OutTime.AutoSize = true;
            this.lbl_OutTime.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_OutTime.Location = new System.Drawing.Point(362, 184);
            this.lbl_OutTime.Name = "lbl_OutTime";
            this.lbl_OutTime.Size = new System.Drawing.Size(88, 16);
            this.lbl_OutTime.TabIndex = 15;
            this.lbl_OutTime.Text = "退伍时间：";
            // 
            // TimePicker_Intime
            // 
            this.TimePicker_Intime.BackColor = System.Drawing.Color.Gray;
            this.TimePicker_Intime.BorderRadius = 0;
            this.TimePicker_Intime.ForeColor = System.Drawing.Color.White;
            this.TimePicker_Intime.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.TimePicker_Intime.FormatCustom = null;
            this.TimePicker_Intime.Location = new System.Drawing.Point(129, 176);
            this.TimePicker_Intime.Name = "TimePicker_Intime";
            this.TimePicker_Intime.Size = new System.Drawing.Size(195, 33);
            this.TimePicker_Intime.TabIndex = 14;
            this.TimePicker_Intime.Value = new System.DateTime(2017, 2, 20, 18, 1, 2, 548);
            // 
            // lbl_Intime
            // 
            this.lbl_Intime.AutoSize = true;
            this.lbl_Intime.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Intime.Location = new System.Drawing.Point(54, 184);
            this.lbl_Intime.Name = "lbl_Intime";
            this.lbl_Intime.Size = new System.Drawing.Size(88, 16);
            this.lbl_Intime.TabIndex = 13;
            this.lbl_Intime.Text = "入伍时间：";
            // 
            // tbx_DegreeOfEducation
            // 
            this.tbx_DegreeOfEducation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_DegreeOfEducation.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_DegreeOfEducation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_DegreeOfEducation.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_DegreeOfEducation.HintText = "";
            this.tbx_DegreeOfEducation.isPassword = false;
            this.tbx_DegreeOfEducation.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_DegreeOfEducation.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_DegreeOfEducation.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_DegreeOfEducation.LineThickness = 3;
            this.tbx_DegreeOfEducation.Location = new System.Drawing.Point(133, 116);
            this.tbx_DegreeOfEducation.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_DegreeOfEducation.Name = "tbx_DegreeOfEducation";
            this.tbx_DegreeOfEducation.Size = new System.Drawing.Size(191, 31);
            this.tbx_DegreeOfEducation.TabIndex = 10;
            this.tbx_DegreeOfEducation.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_DegreeOfEducation
            // 
            this.lbl_DegreeOfEducation.AutoSize = true;
            this.lbl_DegreeOfEducation.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_DegreeOfEducation.Location = new System.Drawing.Point(55, 131);
            this.lbl_DegreeOfEducation.Name = "lbl_DegreeOfEducation";
            this.lbl_DegreeOfEducation.Size = new System.Drawing.Size(88, 16);
            this.lbl_DegreeOfEducation.TabIndex = 9;
            this.lbl_DegreeOfEducation.Text = "文化程度：";
            // 
            // lbl_DateOfBirth
            // 
            this.lbl_DateOfBirth.AutoSize = true;
            this.lbl_DateOfBirth.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_DateOfBirth.Location = new System.Drawing.Point(361, 131);
            this.lbl_DateOfBirth.Name = "lbl_DateOfBirth";
            this.lbl_DateOfBirth.Size = new System.Drawing.Size(88, 16);
            this.lbl_DateOfBirth.TabIndex = 11;
            this.lbl_DateOfBirth.Text = "出生日期：";
            // 
            // tbx_place
            // 
            this.tbx_place.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_place.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_place.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_place.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_place.HintText = "";
            this.tbx_place.isPassword = false;
            this.tbx_place.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_place.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_place.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_place.LineThickness = 3;
            this.tbx_place.Location = new System.Drawing.Point(132, 74);
            this.tbx_place.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_place.Name = "tbx_place";
            this.tbx_place.Size = new System.Drawing.Size(191, 31);
            this.tbx_place.TabIndex = 6;
            this.tbx_place.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_Place
            // 
            this.lbl_Place.AutoSize = true;
            this.lbl_Place.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Place.Location = new System.Drawing.Point(86, 89);
            this.lbl_Place.Name = "lbl_Place";
            this.lbl_Place.Size = new System.Drawing.Size(56, 16);
            this.lbl_Place.TabIndex = 5;
            this.lbl_Place.Text = "籍贯：";
            // 
            // tbx_Nation
            // 
            this.tbx_Nation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_Nation.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_Nation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_Nation.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_Nation.HintText = "";
            this.tbx_Nation.isPassword = false;
            this.tbx_Nation.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_Nation.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_Nation.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_Nation.LineThickness = 3;
            this.tbx_Nation.Location = new System.Drawing.Point(438, 74);
            this.tbx_Nation.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Nation.Name = "tbx_Nation";
            this.tbx_Nation.Size = new System.Drawing.Size(191, 31);
            this.tbx_Nation.TabIndex = 8;
            this.tbx_Nation.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_Nation
            // 
            this.lbl_Nation.AutoSize = true;
            this.lbl_Nation.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Nation.Location = new System.Drawing.Point(393, 89);
            this.lbl_Nation.Name = "lbl_Nation";
            this.lbl_Nation.Size = new System.Drawing.Size(56, 16);
            this.lbl_Nation.TabIndex = 7;
            this.lbl_Nation.Text = "民族：";
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
            this.tbx_ID.TabIndex = 4;
            this.tbx_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_ID.Location = new System.Drawing.Point(392, 50);
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
            this.tbx_Name.Location = new System.Drawing.Point(132, 35);
            this.tbx_Name.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Name.Name = "tbx_Name";
            this.tbx_Name.Size = new System.Drawing.Size(191, 31);
            this.tbx_Name.TabIndex = 2;
            this.tbx_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Name.Location = new System.Drawing.Point(86, 50);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(56, 16);
            this.lbl_Name.TabIndex = 1;
            this.lbl_Name.Text = "姓名：";
            // 
            // Panel_Btn
            // 
            this.Panel_Btn.BackColor = System.Drawing.Color.Gray;
            this.Panel_Btn.Controls.Add(this.btn_Add);
            this.Panel_Btn.Controls.Add(this.btn_Edit);
            this.Panel_Btn.Controls.Add(this.btn_delete);
            this.Panel_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Btn.Location = new System.Drawing.Point(216, 0);
            this.Panel_Btn.Name = "Panel_Btn";
            this.Panel_Btn.Size = new System.Drawing.Size(685, 39);
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
            this.btn_Add.Location = new System.Drawing.Point(433, 0);
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
            this.btn_Edit.Location = new System.Drawing.Point(517, 0);
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
            this.btn_delete.Location = new System.Drawing.Point(601, 0);
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
            this.left_Panel.Controls.Add(this.Person_List);
            this.left_Panel.Controls.Add(this.search_Panel);
            this.left_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.left_Panel.Location = new System.Drawing.Point(0, 0);
            this.left_Panel.Name = "left_Panel";
            this.left_Panel.Size = new System.Drawing.Size(216, 550);
            this.left_Panel.TabIndex = 0;
            // 
            // Person_List
            // 
            this.Person_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Person_List.FormattingEnabled = true;
            this.Person_List.ItemHeight = 12;
            this.Person_List.Location = new System.Drawing.Point(0, 39);
            this.Person_List.Name = "Person_List";
            this.Person_List.Size = new System.Drawing.Size(216, 511);
            this.Person_List.TabIndex = 1;
            this.Person_List.Click += new System.EventHandler(this.Person_List_SelectedIndexChanged);
            // 
            // search_Panel
            // 
            this.search_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.search_Panel.Controls.Add(this.tbx_Search);
            this.search_Panel.Controls.Add(this.SearchBtn);
            this.search_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.search_Panel.Location = new System.Drawing.Point(0, 0);
            this.search_Panel.Name = "search_Panel";
            this.search_Panel.Size = new System.Drawing.Size(216, 39);
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
            this.tbx_Search.Size = new System.Drawing.Size(174, 28);
            this.tbx_Search.TabIndex = 2;
            this.tbx_Search.Text = "请输入姓名！";
            this.tbx_Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbx_Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_Search_KeyPress);
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.Transparent;
            this.SearchBtn.Image = ((System.Drawing.Image)(resources.GetObject("SearchBtn.Image")));
            this.SearchBtn.ImageActive = null;
            this.SearchBtn.Location = new System.Drawing.Point(185, 6);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(28, 29);
            this.SearchBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SearchBtn.TabIndex = 1;
            this.SearchBtn.TabStop = false;
            this.SearchBtn.Zoom = 10;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // Form_PersonAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 584);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_PersonAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_PersonAdd";
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
        private ns1.BunifuDragControl Form_Move;
        private ns1.BunifuImageButton Exit;
        private ns1.BunifuCustomLabel Title_Lable;
        private System.Windows.Forms.PictureBox Title_Img;
        private System.Windows.Forms.Panel Content;
        private System.Windows.Forms.Panel left_Panel;
        private System.Windows.Forms.Panel search_Panel;
        private ns1.BunifuImageButton SearchBtn;
        private ns1.BunifuMaterialTextbox tbx_Search;
        private System.Windows.Forms.Panel Panel_Btn;
        private ns1.BunifuFlatButton btn_delete;
        private ns1.BunifuFlatButton btn_Edit;
        private ns1.BunifuFlatButton btn_Add;
        private System.Windows.Forms.ListBox Person_List;
        private ns1.BunifuCards bunifuCards1;
        private ns1.BunifuMaterialTextbox tbx_Name;
        private ns1.BunifuCustomLabel lbl_Name;
        private ns1.BunifuMaterialTextbox tbx_Nation;
        private ns1.BunifuCustomLabel lbl_Nation;
        private ns1.BunifuMaterialTextbox tbx_ID;
        private ns1.BunifuCustomLabel lbl_ID;
        private ns1.BunifuCustomLabel lbl_DateOfBirth;
        private ns1.BunifuMaterialTextbox tbx_place;
        private ns1.BunifuCustomLabel lbl_Place;
        private ns1.BunifuDatepicker TimePicker_Outtime;
        private ns1.BunifuCustomLabel lbl_OutTime;
        private ns1.BunifuDatepicker TimePicker_Intime;
        private ns1.BunifuCustomLabel lbl_Intime;
        private ns1.BunifuMaterialTextbox tbx_DegreeOfEducation;
        private ns1.BunifuCustomLabel lbl_DegreeOfEducation;
        private ns1.BunifuMaterialTextbox tbx_post;
        private ns1.BunifuCustomLabel lbl_post;
        private ns1.BunifuMaterialTextbox tbx_contactinfo;
        private ns1.BunifuCustomLabel lbl_contactinfo;
        private ns1.BunifuMaterialTextbox tbx_Unit;
        private ns1.BunifuCustomLabel lbl_Unit;
        private ns1.BunifuThinButton2 btn_OK;
        private ns1.BunifuCustomLabel lbl_descript;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox tbx_descrip;
        private ns1.BunifuDatepicker TimePicker_DateOfBirth;
        private ns1.BunifuThinButton2 btn_Cancel;
    }
}