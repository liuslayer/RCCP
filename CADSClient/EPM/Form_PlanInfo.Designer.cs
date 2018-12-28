namespace EPM
{
    partial class Form_PlanInfo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PlanInfo));
            this.Title_panel = new System.Windows.Forms.Panel();
            this.btn_QuikSearch = new ns1.BunifuImageButton();
            this.SearchText = new ns1.BunifuMaterialTextbox();
            this.btn_Dutyadd = new ns1.BunifuFlatButton();
            this.btn_DutyEdit = new ns1.BunifuFlatButton();
            this.btnDelete = new ns1.BunifuFlatButton();
            this.btn_Export = new ns1.BunifuFlatButton();
            this.Panel_Condition = new System.Windows.Forms.Panel();
            this.btnSearch = new ns1.BunifuFlatButton();
            this.txtPlanContent = new System.Windows.Forms.TextBox();
            this.txtPlanNo = new System.Windows.Forms.TextBox();
            this.lbl_Name = new ns1.BunifuCustomLabel();
            this.lblName = new ns1.BunifuCustomLabel();
            this.myPageControl1 = new MyControls.MyPageControl();
            this.dgvPlanInfos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_OpenFile = new ns1.BunifuFlatButton();
            this.Title_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_QuikSearch)).BeginInit();
            this.Panel_Condition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanInfos)).BeginInit();
            this.SuspendLayout();
            // 
            // Title_panel
            // 
            this.Title_panel.BackColor = System.Drawing.Color.Silver;
            this.Title_panel.Controls.Add(this.btn_OpenFile);
            this.Title_panel.Controls.Add(this.btn_QuikSearch);
            this.Title_panel.Controls.Add(this.SearchText);
            this.Title_panel.Controls.Add(this.btn_Dutyadd);
            this.Title_panel.Controls.Add(this.btn_DutyEdit);
            this.Title_panel.Controls.Add(this.btnDelete);
            this.Title_panel.Controls.Add(this.btn_Export);
            this.Title_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title_panel.Location = new System.Drawing.Point(0, 0);
            this.Title_panel.Name = "Title_panel";
            this.Title_panel.Size = new System.Drawing.Size(1009, 41);
            this.Title_panel.TabIndex = 1;
            // 
            // btn_QuikSearch
            // 
            this.btn_QuikSearch.BackColor = System.Drawing.Color.Transparent;
            this.btn_QuikSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_QuikSearch.Image = ((System.Drawing.Image)(resources.GetObject("btn_QuikSearch.Image")));
            this.btn_QuikSearch.ImageActive = null;
            this.btn_QuikSearch.Location = new System.Drawing.Point(172, 0);
            this.btn_QuikSearch.Name = "btn_QuikSearch";
            this.btn_QuikSearch.Size = new System.Drawing.Size(24, 41);
            this.btn_QuikSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_QuikSearch.TabIndex = 8;
            this.btn_QuikSearch.TabStop = false;
            this.btn_QuikSearch.Zoom = 10;
            this.btn_QuikSearch.Click += new System.EventHandler(this.btn_QuikSearch_Click);
            // 
            // SearchText
            // 
            this.SearchText.BackColor = System.Drawing.Color.Silver;
            this.SearchText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchText.Dock = System.Windows.Forms.DockStyle.Left;
            this.SearchText.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.SearchText.ForeColor = System.Drawing.Color.Black;
            this.SearchText.HintForeColor = System.Drawing.Color.Empty;
            this.SearchText.HintText = "";
            this.SearchText.isPassword = false;
            this.SearchText.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SearchText.LineIdleColor = System.Drawing.Color.White;
            this.SearchText.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SearchText.LineThickness = 2;
            this.SearchText.Location = new System.Drawing.Point(0, 0);
            this.SearchText.Margin = new System.Windows.Forms.Padding(4);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(172, 41);
            this.SearchText.TabIndex = 7;
            this.SearchText.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btn_Dutyadd
            // 
            this.btn_Dutyadd.Activecolor = System.Drawing.Color.Black;
            this.btn_Dutyadd.BackColor = System.Drawing.Color.Transparent;
            this.btn_Dutyadd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Dutyadd.BorderRadius = 0;
            this.btn_Dutyadd.ButtonText = "    预案添加";
            this.btn_Dutyadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Dutyadd.DisabledColor = System.Drawing.Color.Gray;
            this.btn_Dutyadd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Dutyadd.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_Dutyadd.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_Dutyadd.Iconimage")));
            this.btn_Dutyadd.Iconimage_right = null;
            this.btn_Dutyadd.Iconimage_right_Selected = null;
            this.btn_Dutyadd.Iconimage_Selected = null;
            this.btn_Dutyadd.IconMarginLeft = 0;
            this.btn_Dutyadd.IconMarginRight = 0;
            this.btn_Dutyadd.IconRightVisible = true;
            this.btn_Dutyadd.IconRightZoom = 0D;
            this.btn_Dutyadd.IconVisible = true;
            this.btn_Dutyadd.IconZoom = 60D;
            this.btn_Dutyadd.IsTab = false;
            this.btn_Dutyadd.Location = new System.Drawing.Point(469, 0);
            this.btn_Dutyadd.Name = "btn_Dutyadd";
            this.btn_Dutyadd.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_Dutyadd.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_Dutyadd.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_Dutyadd.selected = false;
            this.btn_Dutyadd.Size = new System.Drawing.Size(135, 41);
            this.btn_Dutyadd.TabIndex = 6;
            this.btn_Dutyadd.Text = "    预案添加";
            this.btn_Dutyadd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Dutyadd.Textcolor = System.Drawing.Color.White;
            this.btn_Dutyadd.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dutyadd.Click += new System.EventHandler(this.btn_Dutyadd_Click);
            // 
            // btn_DutyEdit
            // 
            this.btn_DutyEdit.Activecolor = System.Drawing.Color.Black;
            this.btn_DutyEdit.BackColor = System.Drawing.Color.Transparent;
            this.btn_DutyEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DutyEdit.BorderRadius = 0;
            this.btn_DutyEdit.ButtonText = "    预案编辑";
            this.btn_DutyEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DutyEdit.DisabledColor = System.Drawing.Color.Gray;
            this.btn_DutyEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_DutyEdit.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_DutyEdit.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_DutyEdit.Iconimage")));
            this.btn_DutyEdit.Iconimage_right = null;
            this.btn_DutyEdit.Iconimage_right_Selected = null;
            this.btn_DutyEdit.Iconimage_Selected = null;
            this.btn_DutyEdit.IconMarginLeft = 0;
            this.btn_DutyEdit.IconMarginRight = 0;
            this.btn_DutyEdit.IconRightVisible = true;
            this.btn_DutyEdit.IconRightZoom = 0D;
            this.btn_DutyEdit.IconVisible = true;
            this.btn_DutyEdit.IconZoom = 60D;
            this.btn_DutyEdit.IsTab = false;
            this.btn_DutyEdit.Location = new System.Drawing.Point(604, 0);
            this.btn_DutyEdit.Name = "btn_DutyEdit";
            this.btn_DutyEdit.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_DutyEdit.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_DutyEdit.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_DutyEdit.selected = false;
            this.btn_DutyEdit.Size = new System.Drawing.Size(135, 41);
            this.btn_DutyEdit.TabIndex = 5;
            this.btn_DutyEdit.Text = "    预案编辑";
            this.btn_DutyEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DutyEdit.Textcolor = System.Drawing.Color.White;
            this.btn_DutyEdit.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DutyEdit.Click += new System.EventHandler(this.btn_DutyEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Activecolor = System.Drawing.Color.Black;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.BorderRadius = 0;
            this.btnDelete.ButtonText = "    预案删除";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.DisabledColor = System.Drawing.Color.Gray;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDelete.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDelete.Iconimage")));
            this.btnDelete.Iconimage_right = null;
            this.btnDelete.Iconimage_right_Selected = null;
            this.btnDelete.Iconimage_Selected = null;
            this.btnDelete.IconMarginLeft = 0;
            this.btnDelete.IconMarginRight = 0;
            this.btnDelete.IconRightVisible = true;
            this.btnDelete.IconRightZoom = 0D;
            this.btnDelete.IconVisible = true;
            this.btnDelete.IconZoom = 60D;
            this.btnDelete.IsTab = false;
            this.btnDelete.Location = new System.Drawing.Point(739, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Normalcolor = System.Drawing.Color.Transparent;
            this.btnDelete.OnHovercolor = System.Drawing.Color.Gray;
            this.btnDelete.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDelete.selected = false;
            this.btnDelete.Size = new System.Drawing.Size(135, 41);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "    预案删除";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Textcolor = System.Drawing.Color.White;
            this.btnDelete.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btn_Export.Location = new System.Drawing.Point(874, 0);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_Export.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_Export.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_Export.selected = false;
            this.btn_Export.Size = new System.Drawing.Size(135, 41);
            this.btn_Export.TabIndex = 3;
            this.btn_Export.Text = "    导出报表";
            this.btn_Export.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Export.Textcolor = System.Drawing.Color.White;
            this.btn_Export.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // Panel_Condition
            // 
            this.Panel_Condition.Controls.Add(this.btnSearch);
            this.Panel_Condition.Controls.Add(this.txtPlanContent);
            this.Panel_Condition.Controls.Add(this.txtPlanNo);
            this.Panel_Condition.Controls.Add(this.lbl_Name);
            this.Panel_Condition.Controls.Add(this.lblName);
            this.Panel_Condition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Condition.Location = new System.Drawing.Point(0, 563);
            this.Panel_Condition.Name = "Panel_Condition";
            this.Panel_Condition.Size = new System.Drawing.Size(1009, 80);
            this.Panel_Condition.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.BorderRadius = 0;
            this.btnSearch.ButtonText = "查询";
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.DisabledColor = System.Drawing.Color.Gray;
            this.btnSearch.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSearch.Iconimage = null;
            this.btnSearch.Iconimage_right = null;
            this.btnSearch.Iconimage_right_Selected = null;
            this.btnSearch.Iconimage_Selected = null;
            this.btnSearch.IconMarginLeft = 0;
            this.btnSearch.IconMarginRight = 0;
            this.btnSearch.IconRightVisible = true;
            this.btnSearch.IconRightZoom = 0D;
            this.btnSearch.IconVisible = true;
            this.btnSearch.IconZoom = 90D;
            this.btnSearch.IsTab = false;
            this.btnSearch.Location = new System.Drawing.Point(494, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnSearch.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnSearch.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSearch.selected = false;
            this.btnSearch.Size = new System.Drawing.Size(88, 30);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查询";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSearch.Textcolor = System.Drawing.Color.White;
            this.btnSearch.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPlanContent
            // 
            this.txtPlanContent.Location = new System.Drawing.Point(338, 33);
            this.txtPlanContent.Name = "txtPlanContent";
            this.txtPlanContent.Size = new System.Drawing.Size(100, 21);
            this.txtPlanContent.TabIndex = 6;
            // 
            // txtPlanNo
            // 
            this.txtPlanNo.Location = new System.Drawing.Point(106, 33);
            this.txtPlanNo.Name = "txtPlanNo";
            this.txtPlanNo.Size = new System.Drawing.Size(100, 21);
            this.txtPlanNo.TabIndex = 3;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Name.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Name.ForeColor = System.Drawing.Color.Black;
            this.lbl_Name.Location = new System.Drawing.Point(12, 33);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(88, 16);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "预案编号：";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("宋体", 12F);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(244, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(88, 16);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "预案标题：";
            // 
            // myPageControl1
            // 
            this.myPageControl1.BackColor = System.Drawing.SystemColors.Control;
            this.myPageControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.myPageControl1.Location = new System.Drawing.Point(0, 532);
            this.myPageControl1.Name = "myPageControl1";
            this.myPageControl1.PageIndex = 1;
            this.myPageControl1.PageRecordCount = 0;
            this.myPageControl1.PageRecordNumber = 10;
            this.myPageControl1.Size = new System.Drawing.Size(1009, 31);
            this.myPageControl1.TabIndex = 5;
            // 
            // dgvPlanInfos
            // 
            this.dgvPlanInfos.AllowUserToAddRows = false;
            this.dgvPlanInfos.AllowUserToDeleteRows = false;
            this.dgvPlanInfos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanInfos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvPlanInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlanInfos.Location = new System.Drawing.Point(0, 41);
            this.dgvPlanInfos.Name = "dgvPlanInfos";
            this.dgvPlanInfos.ReadOnly = true;
            this.dgvPlanInfos.RowTemplate.Height = 23;
            this.dgvPlanInfos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanInfos.Size = new System.Drawing.Size(1009, 491);
            this.dgvPlanInfos.TabIndex = 6;
            this.dgvPlanInfos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanInfos_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PlanID";
            this.Column2.HeaderText = "预案编号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "PlanTitle";
            this.Column3.HeaderText = "预案标题";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Description";
            this.Column4.HeaderText = "预案描述";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 400;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Path";
            this.Column5.HeaderText = "预案路径";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Mark";
            this.Column6.HeaderText = "Mark";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // btn_OpenFile
            // 
            this.btn_OpenFile.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_OpenFile.BackColor = System.Drawing.Color.Gray;
            this.btn_OpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_OpenFile.BorderRadius = 0;
            this.btn_OpenFile.ButtonText = "  浏览预案";
            this.btn_OpenFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OpenFile.DisabledColor = System.Drawing.Color.Gray;
            this.btn_OpenFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_OpenFile.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_OpenFile.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_OpenFile.Iconimage")));
            this.btn_OpenFile.Iconimage_right = null;
            this.btn_OpenFile.Iconimage_right_Selected = null;
            this.btn_OpenFile.Iconimage_Selected = null;
            this.btn_OpenFile.IconMarginLeft = 0;
            this.btn_OpenFile.IconMarginRight = 0;
            this.btn_OpenFile.IconRightVisible = true;
            this.btn_OpenFile.IconRightZoom = 0D;
            this.btn_OpenFile.IconVisible = true;
            this.btn_OpenFile.IconZoom = 70D;
            this.btn_OpenFile.IsTab = false;
            this.btn_OpenFile.Location = new System.Drawing.Point(342, 0);
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.Normalcolor = System.Drawing.Color.Gray;
            this.btn_OpenFile.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_OpenFile.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_OpenFile.selected = false;
            this.btn_OpenFile.Size = new System.Drawing.Size(127, 41);
            this.btn_OpenFile.TabIndex = 9;
            this.btn_OpenFile.Text = "  浏览预案";
            this.btn_OpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_OpenFile.Textcolor = System.Drawing.Color.White;
            this.btn_OpenFile.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
            // 
            // Form_PlanInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 643);
            this.Controls.Add(this.dgvPlanInfos);
            this.Controls.Add(this.myPageControl1);
            this.Controls.Add(this.Panel_Condition);
            this.Controls.Add(this.Title_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_PlanInfo";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.EPM_MainForm_Load);
            this.Title_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_QuikSearch)).EndInit();
            this.Panel_Condition.ResumeLayout(false);
            this.Panel_Condition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanInfos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Title_panel;
        private ns1.BunifuFlatButton btn_Export;
        private ns1.BunifuFlatButton btnDelete;
        private ns1.BunifuFlatButton btn_DutyEdit;
        private ns1.BunifuFlatButton btn_Dutyadd;
        private System.Windows.Forms.Panel Panel_Condition;
        private ns1.BunifuCustomLabel lbl_Name;
        private ns1.BunifuCustomLabel lblName;
        private System.Windows.Forms.TextBox txtPlanNo;
        private System.Windows.Forms.TextBox txtPlanContent;
        private ns1.BunifuFlatButton btnSearch;
        private MyControls.MyPageControl myPageControl1;
        private System.Windows.Forms.DataGridView dgvPlanInfos;
        private ns1.BunifuImageButton btn_QuikSearch;
        private ns1.BunifuMaterialTextbox SearchText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private ns1.BunifuFlatButton btn_OpenFile;


    }
}

