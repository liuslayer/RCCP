namespace SVM
{
    partial class Form_PlanAdd 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PlanAdd));
            this.Title = new System.Windows.Forms.Panel();
            this.Title_Lable = new ns1.BunifuCustomLabel();
            this.Title_Img = new System.Windows.Forms.PictureBox();
            this.Exit = new ns1.BunifuImageButton();
            this.Form_Move = new ns1.BunifuDragControl(this.components);
            this.Content = new System.Windows.Forms.Panel();
            this.bunifuCards1 = new ns1.BunifuCards();
            this.btn_Cancel = new ns1.BunifuThinButton2();
            this.btn_OK = new ns1.BunifuThinButton2();
            this.lbl_descript = new ns1.BunifuCustomLabel();
            this.tbx_descrip = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.tbx_PlanContent = new ns1.BunifuMaterialTextbox();
            this.lbl_PlanContent = new ns1.BunifuCustomLabel();
            this.tbx_PlanID = new ns1.BunifuMaterialTextbox();
            this.lbl_PlanID = new ns1.BunifuCustomLabel();
            this.Panel_Btn = new System.Windows.Forms.Panel();
            this.btn_Add = new ns1.BunifuFlatButton();
            this.btn_Edit = new ns1.BunifuFlatButton();
            this.btn_delete = new ns1.BunifuFlatButton();
            this.left_Panel = new System.Windows.Forms.Panel();
            this.Plan_List = new System.Windows.Forms.ListBox();
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
            this.Title.Size = new System.Drawing.Size(667, 34);
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
            this.Title_Lable.Text = "预案管理";
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
            this.Exit.Location = new System.Drawing.Point(630, 0);
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
            this.Content.Size = new System.Drawing.Size(667, 433);
            this.Content.TabIndex = 1;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.btn_Cancel);
            this.bunifuCards1.Controls.Add(this.btn_OK);
            this.bunifuCards1.Controls.Add(this.lbl_descript);
            this.bunifuCards1.Controls.Add(this.tbx_descrip);
            this.bunifuCards1.Controls.Add(this.tbx_PlanContent);
            this.bunifuCards1.Controls.Add(this.lbl_PlanContent);
            this.bunifuCards1.Controls.Add(this.tbx_PlanID);
            this.bunifuCards1.Controls.Add(this.lbl_PlanID);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(179, 39);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(488, 394);
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
            this.btn_Cancel.Location = new System.Drawing.Point(312, 327);
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
            this.btn_OK.Location = new System.Drawing.Point(61, 327);
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
            this.lbl_descript.Location = new System.Drawing.Point(59, 165);
            this.lbl_descript.Name = "lbl_descript";
            this.lbl_descript.Size = new System.Drawing.Size(56, 16);
            this.lbl_descript.TabIndex = 23;
            this.lbl_descript.Text = "描述：";
            // 
            // tbx_descrip
            // 
            this.tbx_descrip.BorderColor = System.Drawing.Color.Black;
            this.tbx_descrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_descrip.Location = new System.Drawing.Point(62, 188);
            this.tbx_descrip.Multiline = true;
            this.tbx_descrip.Name = "tbx_descrip";
            this.tbx_descrip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_descrip.Size = new System.Drawing.Size(369, 113);
            this.tbx_descrip.TabIndex = 8;
            // 
            // tbx_PlanContent
            // 
            this.tbx_PlanContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_PlanContent.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_PlanContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_PlanContent.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_PlanContent.HintText = "";
            this.tbx_PlanContent.isPassword = false;
            this.tbx_PlanContent.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_PlanContent.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_PlanContent.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_PlanContent.LineThickness = 3;
            this.tbx_PlanContent.Location = new System.Drawing.Point(154, 83);
            this.tbx_PlanContent.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_PlanContent.Name = "tbx_PlanContent";
            this.tbx_PlanContent.Size = new System.Drawing.Size(277, 31);
            this.tbx_PlanContent.TabIndex = 2;
            this.tbx_PlanContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_PlanContent
            // 
            this.lbl_PlanContent.AutoSize = true;
            this.lbl_PlanContent.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_PlanContent.Location = new System.Drawing.Point(58, 98);
            this.lbl_PlanContent.Name = "lbl_PlanContent";
            this.lbl_PlanContent.Size = new System.Drawing.Size(88, 16);
            this.lbl_PlanContent.TabIndex = 3;
            this.lbl_PlanContent.Text = "预案内容：";
            // 
            // tbx_PlanID
            // 
            this.tbx_PlanID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_PlanID.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.tbx_PlanID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_PlanID.HintForeColor = System.Drawing.Color.Empty;
            this.tbx_PlanID.HintText = "";
            this.tbx_PlanID.isPassword = false;
            this.tbx_PlanID.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_PlanID.LineIdleColor = System.Drawing.Color.Gray;
            this.tbx_PlanID.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tbx_PlanID.LineThickness = 3;
            this.tbx_PlanID.Location = new System.Drawing.Point(154, 30);
            this.tbx_PlanID.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_PlanID.Name = "tbx_PlanID";
            this.tbx_PlanID.Size = new System.Drawing.Size(277, 31);
            this.tbx_PlanID.TabIndex = 1;
            this.tbx_PlanID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_PlanID
            // 
            this.lbl_PlanID.AutoSize = true;
            this.lbl_PlanID.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_PlanID.Location = new System.Drawing.Point(59, 45);
            this.lbl_PlanID.Name = "lbl_PlanID";
            this.lbl_PlanID.Size = new System.Drawing.Size(88, 16);
            this.lbl_PlanID.TabIndex = 1;
            this.lbl_PlanID.Text = "预案编号：";
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
            this.Panel_Btn.Size = new System.Drawing.Size(488, 39);
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
            this.btn_Add.Location = new System.Drawing.Point(236, 0);
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
            this.btn_Edit.Location = new System.Drawing.Point(320, 0);
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
            this.btn_delete.Location = new System.Drawing.Point(404, 0);
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
            this.left_Panel.Controls.Add(this.Plan_List);
            this.left_Panel.Controls.Add(this.search_Panel);
            this.left_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.left_Panel.Location = new System.Drawing.Point(0, 0);
            this.left_Panel.Name = "left_Panel";
            this.left_Panel.Size = new System.Drawing.Size(179, 433);
            this.left_Panel.TabIndex = 0;
            // 
            // Plan_List
            // 
            this.Plan_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Plan_List.FormattingEnabled = true;
            this.Plan_List.ItemHeight = 12;
            this.Plan_List.Location = new System.Drawing.Point(0, 39);
            this.Plan_List.Name = "Plan_List";
            this.Plan_List.Size = new System.Drawing.Size(179, 394);
            this.Plan_List.TabIndex = 1;
            this.Plan_List.Click += new System.EventHandler(this.Plan_List_Click);
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
            // Form_PlanAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 467);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_PlanAdd";
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
        private System.Windows.Forms.ListBox Plan_List;
        private ns1.BunifuCards bunifuCards1;
        private ns1.BunifuMaterialTextbox tbx_PlanID;
        private ns1.BunifuCustomLabel lbl_PlanID;
        private ns1.BunifuMaterialTextbox tbx_PlanContent;
        private ns1.BunifuCustomLabel lbl_PlanContent;
        private ns1.BunifuThinButton2 btn_OK;
        private ns1.BunifuCustomLabel lbl_descript;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox tbx_descrip;
        private ns1.BunifuThinButton2 btn_Cancel;
    }
}