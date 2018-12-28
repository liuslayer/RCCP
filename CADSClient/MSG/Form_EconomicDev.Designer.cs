namespace MSG
{
    partial class Form_EconomicDev
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_EconomicDev));
            this.Title_panel = new System.Windows.Forms.Panel();
            this.btn_Add = new ns1.BunifuFlatButton();
            this.btn_Edit = new ns1.BunifuFlatButton();
            this.btn_Delete = new ns1.BunifuFlatButton();
            this.btn_Export = new ns1.BunifuFlatButton();
            this.Panel_Condition = new System.Windows.Forms.Panel();
            this.btn_Search = new System.Windows.Forms.Button();
            this.txt_Industry = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Agriculture = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.myPageControl1 = new MyControls.MyPageControl();
            this.DataView = new System.Windows.Forms.DataGridView();
            this.txt_Service = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Title_panel.SuspendLayout();
            this.Panel_Condition.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).BeginInit();
            this.SuspendLayout();
            // 
            // Title_panel
            // 
            this.Title_panel.BackColor = System.Drawing.Color.Silver;
            this.Title_panel.Controls.Add(this.btn_Add);
            this.Title_panel.Controls.Add(this.btn_Edit);
            this.Title_panel.Controls.Add(this.btn_Delete);
            this.Title_panel.Controls.Add(this.btn_Export);
            this.Title_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title_panel.Location = new System.Drawing.Point(0, 0);
            this.Title_panel.Name = "Title_panel";
            this.Title_panel.Size = new System.Drawing.Size(828, 41);
            this.Title_panel.TabIndex = 7;
            // 
            // btn_Add
            // 
            this.btn_Add.Activecolor = System.Drawing.Color.Black;
            this.btn_Add.BackColor = System.Drawing.Color.Transparent;
            this.btn_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Add.BorderRadius = 0;
            this.btn_Add.ButtonText = "    添加";
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
            this.btn_Add.Location = new System.Drawing.Point(288, 0);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_Add.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_Add.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_Add.selected = false;
            this.btn_Add.Size = new System.Drawing.Size(135, 41);
            this.btn_Add.TabIndex = 5;
            this.btn_Add.Text = "    添加";
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
            this.btn_Edit.ButtonText = "    编辑";
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
            this.btn_Edit.Location = new System.Drawing.Point(423, 0);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_Edit.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_Edit.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_Edit.selected = false;
            this.btn_Edit.Size = new System.Drawing.Size(135, 41);
            this.btn_Edit.TabIndex = 4;
            this.btn_Edit.Text = "    编辑";
            this.btn_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Edit.Textcolor = System.Drawing.Color.White;
            this.btn_Edit.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Activecolor = System.Drawing.Color.Black;
            this.btn_Delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Delete.BorderRadius = 0;
            this.btn_Delete.ButtonText = "    删除";
            this.btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Delete.DisabledColor = System.Drawing.Color.Gray;
            this.btn_Delete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Delete.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_Delete.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Iconimage")));
            this.btn_Delete.Iconimage_right = null;
            this.btn_Delete.Iconimage_right_Selected = null;
            this.btn_Delete.Iconimage_Selected = null;
            this.btn_Delete.IconMarginLeft = 0;
            this.btn_Delete.IconMarginRight = 0;
            this.btn_Delete.IconRightVisible = true;
            this.btn_Delete.IconRightZoom = 0D;
            this.btn_Delete.IconVisible = true;
            this.btn_Delete.IconZoom = 60D;
            this.btn_Delete.IsTab = false;
            this.btn_Delete.Location = new System.Drawing.Point(558, 0);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_Delete.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_Delete.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_Delete.selected = false;
            this.btn_Delete.Size = new System.Drawing.Size(135, 41);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "    删除";
            this.btn_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Delete.Textcolor = System.Drawing.Color.White;
            this.btn_Delete.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
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
            this.btn_Export.Location = new System.Drawing.Point(693, 0);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_Export.OnHovercolor = System.Drawing.Color.Gray;
            this.btn_Export.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_Export.selected = false;
            this.btn_Export.Size = new System.Drawing.Size(135, 41);
            this.btn_Export.TabIndex = 2;
            this.btn_Export.Text = "    导出报表";
            this.btn_Export.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Export.Textcolor = System.Drawing.Color.White;
            this.btn_Export.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // Panel_Condition
            // 
            this.Panel_Condition.Controls.Add(this.txt_Service);
            this.Panel_Condition.Controls.Add(this.label3);
            this.Panel_Condition.Controls.Add(this.btn_Search);
            this.Panel_Condition.Controls.Add(this.txt_Industry);
            this.Panel_Condition.Controls.Add(this.label2);
            this.Panel_Condition.Controls.Add(this.txt_Agriculture);
            this.Panel_Condition.Controls.Add(this.label1);
            this.Panel_Condition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Condition.Location = new System.Drawing.Point(0, 326);
            this.Panel_Condition.Name = "Panel_Condition";
            this.Panel_Condition.Size = new System.Drawing.Size(828, 80);
            this.Panel_Condition.TabIndex = 8;
            // 
            // btn_Search
            // 
            this.btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Search.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Location = new System.Drawing.Point(618, 27);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(103, 35);
            this.btn_Search.TabIndex = 4;
            this.btn_Search.Text = "查询";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txt_Industry
            // 
            this.txt_Industry.Location = new System.Drawing.Point(249, 32);
            this.txt_Industry.Name = "txt_Industry";
            this.txt_Industry.Size = new System.Drawing.Size(100, 21);
            this.txt_Industry.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(195, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "工业：";
            // 
            // txt_Agriculture
            // 
            this.txt_Agriculture.Location = new System.Drawing.Point(74, 30);
            this.txt_Agriculture.Name = "txt_Agriculture";
            this.txt_Agriculture.Size = new System.Drawing.Size(100, 21);
            this.txt_Agriculture.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(30, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "农业：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.myPageControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 294);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 32);
            this.panel1.TabIndex = 9;
            // 
            // myPageControl1
            // 
            this.myPageControl1.BackColor = System.Drawing.SystemColors.Control;
            this.myPageControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.myPageControl1.Location = new System.Drawing.Point(0, 0);
            this.myPageControl1.Name = "myPageControl1";
            this.myPageControl1.PageIndex = 1;
            this.myPageControl1.PageRecordCount = 0;
            this.myPageControl1.PageRecordNumber = 10;
            this.myPageControl1.Size = new System.Drawing.Size(989, 32);
            this.myPageControl1.TabIndex = 0;
            // 
            // DataView
            // 
            this.DataView.AllowUserToAddRows = false;
            this.DataView.AllowUserToDeleteRows = false;
            this.DataView.AllowUserToOrderColumns = true;
            this.DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataView.Location = new System.Drawing.Point(0, 41);
            this.DataView.Name = "DataView";
            this.DataView.ReadOnly = true;
            this.DataView.RowTemplate.Height = 23;
            this.DataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataView.Size = new System.Drawing.Size(828, 253);
            this.DataView.TabIndex = 10;
            // 
            // txt_Service
            // 
            this.txt_Service.Location = new System.Drawing.Point(458, 29);
            this.txt_Service.Name = "txt_Service";
            this.txt_Service.Size = new System.Drawing.Size(100, 21);
            this.txt_Service.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(374, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "服务业：";
            // 
            // Form_EconomicDev
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 406);
            this.Controls.Add(this.DataView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel_Condition);
            this.Controls.Add(this.Title_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_EconomicDev";
            this.Text = "Form_EconomicDev";
            this.Load += new System.EventHandler(this.Form_EconomicDev_Load);
            this.Title_panel.ResumeLayout(false);
            this.Panel_Condition.ResumeLayout(false);
            this.Panel_Condition.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Title_panel;
        private ns1.BunifuFlatButton btn_Add;
        private ns1.BunifuFlatButton btn_Edit;
        private ns1.BunifuFlatButton btn_Delete;
        private ns1.BunifuFlatButton btn_Export;
        private System.Windows.Forms.Panel Panel_Condition;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox txt_Industry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Agriculture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private MyControls.MyPageControl myPageControl1;
        private System.Windows.Forms.DataGridView DataView;
        private System.Windows.Forms.TextBox txt_Service;
        private System.Windows.Forms.Label label3;
    }
}