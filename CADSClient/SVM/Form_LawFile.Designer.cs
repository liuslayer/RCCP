namespace SVM
{
    partial class Form_LawFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LawFile));
            this.Title = new System.Windows.Forms.Panel();
            this.btn_Exit = new System.Windows.Forms.PictureBox();
            this.btn_Export = new ns1.BunifuFlatButton();
            this.btn_AddFile = new ns1.BunifuFlatButton();
            this.btn_DutyEdit = new ns1.BunifuFlatButton();
            this.btn_OpenFile = new ns1.BunifuFlatButton();
            this.btn_DeleteFile = new ns1.BunifuFlatButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bunifuDragControl1 = new ns1.BunifuDragControl(this.components);
            this.Panel_Condition = new System.Windows.Forms.Panel();
            this.tbx_FileType = new System.Windows.Forms.ComboBox();
            this.btn_Ok = new DevComponents.DotNetBar.ButtonX();
            this.tbx_FileName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.lbl_Name = new ns1.BunifuCustomLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.myPageControl1 = new MyControls.MyPageControl();
            this.dgv_LawsFileInfo = new System.Windows.Forms.DataGridView();
            this.Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Exit)).BeginInit();
            this.Panel_Condition.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LawsFileInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Controls.Add(this.btn_Exit);
            this.Title.Controls.Add(this.btn_Export);
            this.Title.Controls.Add(this.btn_AddFile);
            this.Title.Controls.Add(this.btn_DutyEdit);
            this.Title.Controls.Add(this.btn_OpenFile);
            this.Title.Controls.Add(this.btn_DeleteFile);
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(967, 42);
            this.Title.TabIndex = 0;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.Image")));
            this.btn_Exit.Location = new System.Drawing.Point(928, 0);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(39, 42);
            this.btn_Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.TabStop = false;
            this.btn_Exit.Visible = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
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
            this.btn_Export.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.btn_Export.Location = new System.Drawing.Point(516, 0);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_Export.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_Export.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_Export.selected = false;
            this.btn_Export.Size = new System.Drawing.Size(135, 42);
            this.btn_Export.TabIndex = 4;
            this.btn_Export.Text = "    导出报表";
            this.btn_Export.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Export.Textcolor = System.Drawing.Color.White;
            this.btn_Export.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_AddFile
            // 
            this.btn_AddFile.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_AddFile.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AddFile.BorderRadius = 0;
            this.btn_AddFile.ButtonText = "  添加文件";
            this.btn_AddFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddFile.DisabledColor = System.Drawing.Color.Gray;
            this.btn_AddFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_AddFile.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_AddFile.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_AddFile.Iconimage")));
            this.btn_AddFile.Iconimage_right = null;
            this.btn_AddFile.Iconimage_right_Selected = null;
            this.btn_AddFile.Iconimage_Selected = null;
            this.btn_AddFile.IconMarginLeft = 0;
            this.btn_AddFile.IconMarginRight = 0;
            this.btn_AddFile.IconRightVisible = true;
            this.btn_AddFile.IconRightZoom = 0D;
            this.btn_AddFile.IconVisible = true;
            this.btn_AddFile.IconZoom = 70D;
            this.btn_AddFile.IsTab = false;
            this.btn_AddFile.Location = new System.Drawing.Point(389, 0);
            this.btn_AddFile.Name = "btn_AddFile";
            this.btn_AddFile.Normalcolor = System.Drawing.Color.Gray;
            this.btn_AddFile.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_AddFile.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_AddFile.selected = false;
            this.btn_AddFile.Size = new System.Drawing.Size(127, 42);
            this.btn_AddFile.TabIndex = 0;
            this.btn_AddFile.Text = "  添加文件";
            this.btn_AddFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddFile.Textcolor = System.Drawing.Color.White;
            this.btn_AddFile.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddFile.Click += new System.EventHandler(this.btn_AddFile_Click);
            // 
            // btn_DutyEdit
            // 
            this.btn_DutyEdit.Activecolor = System.Drawing.Color.Black;
            this.btn_DutyEdit.BackColor = System.Drawing.Color.Transparent;
            this.btn_DutyEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DutyEdit.BorderRadius = 0;
            this.btn_DutyEdit.ButtonText = "  编辑文件";
            this.btn_DutyEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DutyEdit.DisabledColor = System.Drawing.Color.Gray;
            this.btn_DutyEdit.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.btn_DutyEdit.Location = new System.Drawing.Point(254, 0);
            this.btn_DutyEdit.Name = "btn_DutyEdit";
            this.btn_DutyEdit.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_DutyEdit.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_DutyEdit.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_DutyEdit.selected = false;
            this.btn_DutyEdit.Size = new System.Drawing.Size(135, 42);
            this.btn_DutyEdit.TabIndex = 6;
            this.btn_DutyEdit.Text = "  编辑文件";
            this.btn_DutyEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DutyEdit.Textcolor = System.Drawing.Color.White;
            this.btn_DutyEdit.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DutyEdit.Click += new System.EventHandler(this.btn_DutyEdit_Click);
            // 
            // btn_OpenFile
            // 
            this.btn_OpenFile.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_OpenFile.BackColor = System.Drawing.Color.Transparent;
            this.btn_OpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_OpenFile.BorderRadius = 0;
            this.btn_OpenFile.ButtonText = "  打开文件";
            this.btn_OpenFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OpenFile.DisabledColor = System.Drawing.Color.Gray;
            this.btn_OpenFile.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.btn_OpenFile.Location = new System.Drawing.Point(127, 0);
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_OpenFile.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_OpenFile.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_OpenFile.selected = false;
            this.btn_OpenFile.Size = new System.Drawing.Size(127, 42);
            this.btn_OpenFile.TabIndex = 2;
            this.btn_OpenFile.Text = "  打开文件";
            this.btn_OpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_OpenFile.Textcolor = System.Drawing.Color.White;
            this.btn_OpenFile.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
            // 
            // btn_DeleteFile
            // 
            this.btn_DeleteFile.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_DeleteFile.BackColor = System.Drawing.Color.Transparent;
            this.btn_DeleteFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DeleteFile.BorderRadius = 0;
            this.btn_DeleteFile.ButtonText = "  删除文件";
            this.btn_DeleteFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteFile.DisabledColor = System.Drawing.Color.Gray;
            this.btn_DeleteFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_DeleteFile.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_DeleteFile.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_DeleteFile.Iconimage")));
            this.btn_DeleteFile.Iconimage_right = null;
            this.btn_DeleteFile.Iconimage_right_Selected = null;
            this.btn_DeleteFile.Iconimage_Selected = null;
            this.btn_DeleteFile.IconMarginLeft = 0;
            this.btn_DeleteFile.IconMarginRight = 0;
            this.btn_DeleteFile.IconRightVisible = true;
            this.btn_DeleteFile.IconRightZoom = 0D;
            this.btn_DeleteFile.IconVisible = true;
            this.btn_DeleteFile.IconZoom = 70D;
            this.btn_DeleteFile.IsTab = false;
            this.btn_DeleteFile.Location = new System.Drawing.Point(0, 0);
            this.btn_DeleteFile.Name = "btn_DeleteFile";
            this.btn_DeleteFile.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_DeleteFile.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_DeleteFile.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_DeleteFile.selected = false;
            this.btn_DeleteFile.Size = new System.Drawing.Size(127, 42);
            this.btn_DeleteFile.TabIndex = 1;
            this.btn_DeleteFile.Text = "  删除文件";
            this.btn_DeleteFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DeleteFile.Textcolor = System.Drawing.Color.White;
            this.btn_DeleteFile.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteFile.Click += new System.EventHandler(this.btn_DeleteFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.Title;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Panel_Condition
            // 
            this.Panel_Condition.Controls.Add(this.tbx_FileType);
            this.Panel_Condition.Controls.Add(this.btn_Ok);
            this.Panel_Condition.Controls.Add(this.tbx_FileName);
            this.Panel_Condition.Controls.Add(this.bunifuCustomLabel1);
            this.Panel_Condition.Controls.Add(this.lbl_Name);
            this.Panel_Condition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Condition.Location = new System.Drawing.Point(0, 475);
            this.Panel_Condition.Name = "Panel_Condition";
            this.Panel_Condition.Size = new System.Drawing.Size(967, 80);
            this.Panel_Condition.TabIndex = 4;
            // 
            // tbx_FileType
            // 
            this.tbx_FileType.FormattingEnabled = true;
            this.tbx_FileType.Location = new System.Drawing.Point(408, 33);
            this.tbx_FileType.Name = "tbx_FileType";
            this.tbx_FileType.Size = new System.Drawing.Size(121, 20);
            this.tbx_FileType.TabIndex = 8;
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
            // tbx_FileName
            // 
            // 
            // 
            // 
            this.tbx_FileName.Border.Class = "TextBoxBorder";
            this.tbx_FileName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbx_FileName.Location = new System.Drawing.Point(75, 33);
            this.tbx_FileName.Name = "tbx_FileName";
            this.tbx_FileName.PreventEnterBeep = true;
            this.tbx_FileName.Size = new System.Drawing.Size(158, 21);
            this.tbx_FileName.TabIndex = 6;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(314, 33);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "文件类型：";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Name.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_Name.ForeColor = System.Drawing.Color.Black;
            this.lbl_Name.Location = new System.Drawing.Point(12, 33);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(72, 16);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "文件名：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.myPageControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 443);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 32);
            this.panel1.TabIndex = 5;
            // 
            // myPageControl1
            // 
            this.myPageControl1.BackColor = System.Drawing.SystemColors.Control;
            this.myPageControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPageControl1.Location = new System.Drawing.Point(0, 0);
            this.myPageControl1.Name = "myPageControl1";
            this.myPageControl1.PageIndex = 1;
            this.myPageControl1.PageRecordCount = 0;
            this.myPageControl1.PageRecordNumber = 10;
            this.myPageControl1.Size = new System.Drawing.Size(967, 32);
            this.myPageControl1.TabIndex = 0;
            // 
            // dgv_LawsFileInfo
            // 
            this.dgv_LawsFileInfo.AllowUserToAddRows = false;
            this.dgv_LawsFileInfo.AllowUserToDeleteRows = false;
            this.dgv_LawsFileInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_LawsFileInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_LawsFileInfo.Location = new System.Drawing.Point(0, 42);
            this.dgv_LawsFileInfo.Name = "dgv_LawsFileInfo";
            this.dgv_LawsFileInfo.ReadOnly = true;
            this.dgv_LawsFileInfo.RowTemplate.Height = 23;
            this.dgv_LawsFileInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LawsFileInfo.Size = new System.Drawing.Size(967, 401);
            this.dgv_LawsFileInfo.TabIndex = 7;
            // 
            // Form_LawFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(967, 555);
            this.Controls.Add(this.dgv_LawsFileInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel_Condition);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_LawFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_FileLayer";
            this.Load += new System.EventHandler(this.Form_FileLayer_Load);
            this.Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Exit)).EndInit();
            this.Panel_Condition.ResumeLayout(false);
            this.Panel_Condition.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LawsFileInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Title;
        private ns1.BunifuFlatButton btn_AddFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private ns1.BunifuFlatButton btn_DeleteFile;
        private System.Windows.Forms.PictureBox btn_Exit;
        private ns1.BunifuDragControl bunifuDragControl1;
        private ns1.BunifuFlatButton btn_Export;
        private ns1.BunifuFlatButton btn_OpenFile;
        private ns1.BunifuFlatButton btn_DutyEdit;
        private System.Windows.Forms.Panel Panel_Condition;
        private DevComponents.DotNetBar.ButtonX btn_Ok;
        private DevComponents.DotNetBar.Controls.TextBoxX tbx_FileName;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private ns1.BunifuCustomLabel lbl_Name;
        private System.Windows.Forms.Panel panel1;
        private MyControls.MyPageControl myPageControl1;
        private System.Windows.Forms.ComboBox tbx_FileType;
        private System.Windows.Forms.DataGridView dgv_LawsFileInfo;
    }
}