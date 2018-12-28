namespace SVM
{
    partial class Form_EquipAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_EquipAdd));
            this.Title = new System.Windows.Forms.Panel();
            this.Title_Lable = new ns1.BunifuCustomLabel();
            this.Title_Img = new System.Windows.Forms.PictureBox();
            this.Exit = new ns1.BunifuImageButton();
            this.Form_Move = new ns1.BunifuDragControl(this.components);
            this.Content = new System.Windows.Forms.Panel();
            this.bunifuCards1 = new ns1.BunifuCards();
            this.tbx_EquipmentState = new ns1.BunifuMaterialTextbox();
            this.lbl_EquipmentState = new ns1.BunifuCustomLabel();
            this.btn_Cancel = new ns1.BunifuThinButton2();
            this.btn_OK = new ns1.BunifuThinButton2();
            this.lbl_descript = new ns1.BunifuCustomLabel();
            this.tbx_descrip = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.tbx_Unit = new ns1.BunifuMaterialTextbox();
            this.lbl_Unit = new ns1.BunifuCustomLabel();
            this.TimePicker_ReturnDate = new ns1.BunifuDatepicker();
            this.lbl_ReturnDate = new ns1.BunifuCustomLabel();
            this.TimePicker_Intime = new ns1.BunifuDatepicker();
            this.lbl_AllottedDate = new ns1.BunifuCustomLabel();
            this.tbx_PersonIncharge = new ns1.BunifuMaterialTextbox();
            this.lbl_PersonIncharge = new ns1.BunifuCustomLabel();
            this.tbx_EquipType = new ns1.BunifuMaterialTextbox();
            this.lbl_EquipType = new ns1.BunifuCustomLabel();
            this.tbx_EquipNum = new ns1.BunifuMaterialTextbox();
            this.lbl_EquipNum = new ns1.BunifuCustomLabel();
            this.tbx_ID = new ns1.BunifuMaterialTextbox();
            this.lbl_ID = new ns1.BunifuCustomLabel();
            this.tbx_Name = new ns1.BunifuMaterialTextbox();
            this.lbl_Name = new ns1.BunifuCustomLabel();
            this.Panel_Btn = new System.Windows.Forms.Panel();
            this.btn_Add = new ns1.BunifuFlatButton();
            this.btn_Edit = new ns1.BunifuFlatButton();
            this.btn_delete = new ns1.BunifuFlatButton();
            this.left_Panel = new System.Windows.Forms.Panel();
            this.Equip_List = new System.Windows.Forms.ListBox();
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
            this.Title_Lable.Text = "设备管理";
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
            this.bunifuCards1.Controls.Add(this.tbx_EquipmentState);
            this.bunifuCards1.Controls.Add(this.lbl_EquipmentState);
            this.bunifuCards1.Controls.Add(this.btn_Cancel);
            this.bunifuCards1.Controls.Add(this.btn_OK);
            this.bunifuCards1.Controls.Add(this.lbl_descript);
            this.bunifuCards1.Controls.Add(this.tbx_descrip);
            this.bunifuCards1.Controls.Add(this.tbx_Unit);
            this.bunifuCards1.Controls.Add(this.lbl_Unit);
            this.bunifuCards1.Controls.Add(this.TimePicker_ReturnDate);
            this.bunifuCards1.Controls.Add(this.lbl_ReturnDate);
            this.bunifuCards1.Controls.Add(this.TimePicker_Intime);
            this.bunifuCards1.Controls.Add(this.lbl_AllottedDate);
            this.bunifuCards1.Controls.Add(this.tbx_PersonIncharge);
            this.bunifuCards1.Controls.Add(this.lbl_PersonIncharge);
            this.bunifuCards1.Controls.Add(this.tbx_EquipType);
            this.bunifuCards1.Controls.Add(this.lbl_EquipType);
            this.bunifuCards1.Controls.Add(this.tbx_EquipNum);
            this.bunifuCards1.Controls.Add(this.lbl_EquipNum);
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
            // tbx_EquipmentState
            // 
            this.tbx_EquipmentState.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_EquipmentState.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_EquipmentState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_EquipmentState.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_EquipmentState.HintText = "";
            this.tbx_EquipmentState.isPassword = false;
            this.tbx_EquipmentState.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_EquipmentState.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_EquipmentState.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_EquipmentState.LineThickness = 3;
            this.tbx_EquipmentState.Location = new System.Drawing.Point(132, 227);
            this.tbx_EquipmentState.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_EquipmentState.Name = "tbx_EquipmentState";
            this.tbx_EquipmentState.Size = new System.Drawing.Size(191, 31);
            this.tbx_EquipmentState.TabIndex = 7;
            this.tbx_EquipmentState.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_EquipmentState
            // 
            this.lbl_EquipmentState.AutoSize = true;
            this.lbl_EquipmentState.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_EquipmentState.Location = new System.Drawing.Point(54, 242);
            this.lbl_EquipmentState.Name = "lbl_EquipmentState";
            this.lbl_EquipmentState.Size = new System.Drawing.Size(88, 16);
            this.lbl_EquipmentState.TabIndex = 27;
            this.lbl_EquipmentState.Text = "设备状态：";
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
            this.btn_OK.Location = new System.Drawing.Point(129, 453);
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
            this.lbl_descript.Location = new System.Drawing.Point(55, 294);
            this.lbl_descript.Name = "lbl_descript";
            this.lbl_descript.Size = new System.Drawing.Size(88, 16);
            this.lbl_descript.TabIndex = 23;
            this.lbl_descript.Text = "个人描述：";
            // 
            // tbx_descrip
            // 
            this.tbx_descrip.BorderColor = System.Drawing.Color.Black;
            this.tbx_descrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_descrip.Location = new System.Drawing.Point(58, 317);
            this.tbx_descrip.Multiline = true;
            this.tbx_descrip.Name = "tbx_descrip";
            this.tbx_descrip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_descrip.Size = new System.Drawing.Size(574, 101);
            this.tbx_descrip.TabIndex = 8;
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
            this.tbx_Unit.Location = new System.Drawing.Point(437, 116);
            this.tbx_Unit.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Unit.Name = "tbx_Unit";
            this.tbx_Unit.Size = new System.Drawing.Size(191, 31);
            this.tbx_Unit.TabIndex = 6;
            this.tbx_Unit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_Unit
            // 
            this.lbl_Unit.AutoSize = true;
            this.lbl_Unit.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Unit.Location = new System.Drawing.Point(360, 131);
            this.lbl_Unit.Name = "lbl_Unit";
            this.lbl_Unit.Size = new System.Drawing.Size(88, 16);
            this.lbl_Unit.TabIndex = 21;
            this.lbl_Unit.Text = "所属单位：";
            // 
            // TimePicker_ReturnDate
            // 
            this.TimePicker_ReturnDate.BackColor = System.Drawing.Color.Gray;
            this.TimePicker_ReturnDate.BorderRadius = 0;
            this.TimePicker_ReturnDate.ForeColor = System.Drawing.Color.White;
            this.TimePicker_ReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.TimePicker_ReturnDate.FormatCustom = null;
            this.TimePicker_ReturnDate.Location = new System.Drawing.Point(437, 176);
            this.TimePicker_ReturnDate.Name = "TimePicker_ReturnDate";
            this.TimePicker_ReturnDate.Size = new System.Drawing.Size(195, 33);
            this.TimePicker_ReturnDate.TabIndex = 16;
            this.TimePicker_ReturnDate.Value = new System.DateTime(2017, 2, 20, 18, 1, 2, 548);
            // 
            // lbl_ReturnDate
            // 
            this.lbl_ReturnDate.AutoSize = true;
            this.lbl_ReturnDate.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_ReturnDate.Location = new System.Drawing.Point(362, 184);
            this.lbl_ReturnDate.Name = "lbl_ReturnDate";
            this.lbl_ReturnDate.Size = new System.Drawing.Size(88, 16);
            this.lbl_ReturnDate.TabIndex = 15;
            this.lbl_ReturnDate.Text = "回收时间：";
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
            // lbl_AllottedDate
            // 
            this.lbl_AllottedDate.AutoSize = true;
            this.lbl_AllottedDate.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_AllottedDate.Location = new System.Drawing.Point(54, 184);
            this.lbl_AllottedDate.Name = "lbl_AllottedDate";
            this.lbl_AllottedDate.Size = new System.Drawing.Size(88, 16);
            this.lbl_AllottedDate.TabIndex = 13;
            this.lbl_AllottedDate.Text = "配发时间：";
            // 
            // tbx_PersonIncharge
            // 
            this.tbx_PersonIncharge.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_PersonIncharge.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_PersonIncharge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_PersonIncharge.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_PersonIncharge.HintText = "";
            this.tbx_PersonIncharge.isPassword = false;
            this.tbx_PersonIncharge.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_PersonIncharge.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_PersonIncharge.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_PersonIncharge.LineThickness = 3;
            this.tbx_PersonIncharge.Location = new System.Drawing.Point(133, 116);
            this.tbx_PersonIncharge.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_PersonIncharge.Name = "tbx_PersonIncharge";
            this.tbx_PersonIncharge.Size = new System.Drawing.Size(191, 31);
            this.tbx_PersonIncharge.TabIndex = 5;
            this.tbx_PersonIncharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_PersonIncharge
            // 
            this.lbl_PersonIncharge.AutoSize = true;
            this.lbl_PersonIncharge.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_PersonIncharge.Location = new System.Drawing.Point(55, 131);
            this.lbl_PersonIncharge.Name = "lbl_PersonIncharge";
            this.lbl_PersonIncharge.Size = new System.Drawing.Size(72, 16);
            this.lbl_PersonIncharge.TabIndex = 9;
            this.lbl_PersonIncharge.Text = "责任人：";
            // 
            // tbx_EquipType
            // 
            this.tbx_EquipType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_EquipType.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_EquipType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_EquipType.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_EquipType.HintText = "";
            this.tbx_EquipType.isPassword = false;
            this.tbx_EquipType.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_EquipType.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_EquipType.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_EquipType.LineThickness = 3;
            this.tbx_EquipType.Location = new System.Drawing.Point(132, 74);
            this.tbx_EquipType.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_EquipType.Name = "tbx_EquipType";
            this.tbx_EquipType.Size = new System.Drawing.Size(191, 31);
            this.tbx_EquipType.TabIndex = 3;
            this.tbx_EquipType.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_EquipType
            // 
            this.lbl_EquipType.AutoSize = true;
            this.lbl_EquipType.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_EquipType.Location = new System.Drawing.Point(55, 89);
            this.lbl_EquipType.Name = "lbl_EquipType";
            this.lbl_EquipType.Size = new System.Drawing.Size(88, 16);
            this.lbl_EquipType.TabIndex = 5;
            this.lbl_EquipType.Text = "设备类型：";
            // 
            // tbx_EquipNum
            // 
            this.tbx_EquipNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_EquipNum.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_EquipNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_EquipNum.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_EquipNum.HintText = "";
            this.tbx_EquipNum.isPassword = false;
            this.tbx_EquipNum.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_EquipNum.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_EquipNum.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_EquipNum.LineThickness = 3;
            this.tbx_EquipNum.Location = new System.Drawing.Point(438, 74);
            this.tbx_EquipNum.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_EquipNum.Name = "tbx_EquipNum";
            this.tbx_EquipNum.Size = new System.Drawing.Size(191, 31);
            this.tbx_EquipNum.TabIndex = 4;
            this.tbx_EquipNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_EquipNum
            // 
            this.lbl_EquipNum.AutoSize = true;
            this.lbl_EquipNum.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_EquipNum.Location = new System.Drawing.Point(362, 89);
            this.lbl_EquipNum.Name = "lbl_EquipNum";
            this.lbl_EquipNum.Size = new System.Drawing.Size(88, 16);
            this.lbl_EquipNum.TabIndex = 7;
            this.lbl_EquipNum.Text = "设备型号：";
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
            this.tbx_Name.TabIndex = 1;
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
            this.lbl_Name.Text = "名称：";
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
            this.left_Panel.Controls.Add(this.Equip_List);
            this.left_Panel.Controls.Add(this.search_Panel);
            this.left_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.left_Panel.Location = new System.Drawing.Point(0, 0);
            this.left_Panel.Name = "left_Panel";
            this.left_Panel.Size = new System.Drawing.Size(216, 550);
            this.left_Panel.TabIndex = 0;
            // 
            // Equip_List
            // 
            this.Equip_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Equip_List.FormattingEnabled = true;
            this.Equip_List.ItemHeight = 12;
            this.Equip_List.Location = new System.Drawing.Point(0, 39);
            this.Equip_List.Name = "Equip_List";
            this.Equip_List.Size = new System.Drawing.Size(216, 511);
            this.Equip_List.TabIndex = 1;
            this.Equip_List.Click += new System.EventHandler(this.Person_List_SelectedIndexChanged);
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
            // Form_EquipAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 584);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_EquipAdd";
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
        private System.Windows.Forms.ListBox Equip_List;
        private ns1.BunifuCards bunifuCards1;
        private ns1.BunifuMaterialTextbox tbx_Name;
        private ns1.BunifuCustomLabel lbl_Name;
        private ns1.BunifuMaterialTextbox tbx_EquipNum;
        private ns1.BunifuCustomLabel lbl_EquipNum;
        private ns1.BunifuMaterialTextbox tbx_ID;
        private ns1.BunifuCustomLabel lbl_ID;
        private ns1.BunifuMaterialTextbox tbx_EquipType;
        private ns1.BunifuCustomLabel lbl_EquipType;
        private ns1.BunifuDatepicker TimePicker_ReturnDate;
        private ns1.BunifuCustomLabel lbl_ReturnDate;
        private ns1.BunifuDatepicker TimePicker_Intime;
        private ns1.BunifuCustomLabel lbl_AllottedDate;
        private ns1.BunifuMaterialTextbox tbx_PersonIncharge;
        private ns1.BunifuCustomLabel lbl_PersonIncharge;
        private ns1.BunifuMaterialTextbox tbx_Unit;
        private ns1.BunifuCustomLabel lbl_Unit;
        private ns1.BunifuThinButton2 btn_OK;
        private ns1.BunifuCustomLabel lbl_descript;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox tbx_descrip;
        private ns1.BunifuThinButton2 btn_Cancel;
        private ns1.BunifuMaterialTextbox tbx_EquipmentState;
        private ns1.BunifuCustomLabel lbl_EquipmentState;
    }
}