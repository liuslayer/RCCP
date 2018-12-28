namespace MSG
{
    partial class Form_GeographyEnvAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_GeographyEnvAdd));
            this.Title = new System.Windows.Forms.Panel();
            this.Title_Label = new ns1.BunifuCustomLabel();
            this.Title_Lable = new ns1.BunifuCustomLabel();
            this.Exit = new ns1.BunifuImageButton();
            this.Content = new System.Windows.Forms.Panel();
            this.txt_Description = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.lbl_descript = new ns1.BunifuCustomLabel();
            this.btn_OK = new ns1.BunifuThinButton2();
            this.btn_Cancel = new ns1.BunifuThinButton2();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.txt_ZoneID = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel2 = new ns1.BunifuCustomLabel();
            this.txt_ZoneScale = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel3 = new ns1.BunifuCustomLabel();
            this.txt_GeographyEnv = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel4 = new ns1.BunifuCustomLabel();
            this.txt_RoadTransport = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel5 = new ns1.BunifuCustomLabel();
            this.txt_WaterSystem = new ns1.BunifuMaterialTextbox();
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
            this.Title.TabIndex = 1;
            // 
            // Title_Label
            // 
            this.Title_Label.AutoSize = true;
            this.Title_Label.Font = new System.Drawing.Font("宋体", 12F);
            this.Title_Label.ForeColor = System.Drawing.Color.White;
            this.Title_Label.Location = new System.Drawing.Point(12, 9);
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.Size = new System.Drawing.Size(104, 16);
            this.Title_Label.TabIndex = 3;
            this.Title_Label.Text = "战区地理环境";
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
            // Content
            // 
            this.Content.Controls.Add(this.bunifuCards1);
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(0, 34);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(721, 594);
            this.Content.TabIndex = 4;
            // 
            // txt_Description
            // 
            this.txt_Description.BorderColor = System.Drawing.Color.Black;
            this.txt_Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Description.Location = new System.Drawing.Point(58, 264);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Description.Size = new System.Drawing.Size(594, 154);
            this.txt_Description.TabIndex = 8;
            // 
            // lbl_descript
            // 
            this.lbl_descript.AutoSize = true;
            this.lbl_descript.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_descript.Location = new System.Drawing.Point(55, 225);
            this.lbl_descript.Name = "lbl_descript";
            this.lbl_descript.Size = new System.Drawing.Size(88, 16);
            this.lbl_descript.TabIndex = 23;
            this.lbl_descript.Text = "详细描述：";
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
            this.btn_OK.Location = new System.Drawing.Point(161, 483);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(5);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(101, 48);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
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
            this.btn_Cancel.Location = new System.Drawing.Point(414, 483);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(101, 48);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(55, 50);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel1.TabIndex = 24;
            this.bunifuCustomLabel1.Text = "战区编号：";
            // 
            // txt_ZoneID
            // 
            this.txt_ZoneID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ZoneID.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_ZoneID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_ZoneID.HintForeColor = System.Drawing.Color.Empty;
            this.txt_ZoneID.HintText = "";
            this.txt_ZoneID.isPassword = false;
            this.txt_ZoneID.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_ZoneID.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_ZoneID.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_ZoneID.LineThickness = 3;
            this.txt_ZoneID.Location = new System.Drawing.Point(150, 35);
            this.txt_ZoneID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ZoneID.Name = "txt_ZoneID";
            this.txt_ZoneID.Size = new System.Drawing.Size(191, 31);
            this.txt_ZoneID.TabIndex = 25;
            this.txt_ZoneID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(366, 50);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel2.TabIndex = 26;
            this.bunifuCustomLabel2.Text = "作战范围：";
            // 
            // txt_ZoneScale
            // 
            this.txt_ZoneScale.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ZoneScale.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_ZoneScale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_ZoneScale.HintForeColor = System.Drawing.Color.Empty;
            this.txt_ZoneScale.HintText = "";
            this.txt_ZoneScale.isPassword = false;
            this.txt_ZoneScale.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_ZoneScale.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_ZoneScale.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_ZoneScale.LineThickness = 3;
            this.txt_ZoneScale.Location = new System.Drawing.Point(461, 35);
            this.txt_ZoneScale.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ZoneScale.Name = "txt_ZoneScale";
            this.txt_ZoneScale.Size = new System.Drawing.Size(191, 31);
            this.txt_ZoneScale.TabIndex = 27;
            this.txt_ZoneScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(55, 107);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel3.TabIndex = 28;
            this.bunifuCustomLabel3.Text = "地形环境：";
            // 
            // txt_GeographyEnv
            // 
            this.txt_GeographyEnv.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_GeographyEnv.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_GeographyEnv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_GeographyEnv.HintForeColor = System.Drawing.Color.Empty;
            this.txt_GeographyEnv.HintText = "";
            this.txt_GeographyEnv.isPassword = false;
            this.txt_GeographyEnv.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_GeographyEnv.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_GeographyEnv.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_GeographyEnv.LineThickness = 3;
            this.txt_GeographyEnv.Location = new System.Drawing.Point(150, 92);
            this.txt_GeographyEnv.Margin = new System.Windows.Forms.Padding(4);
            this.txt_GeographyEnv.Name = "txt_GeographyEnv";
            this.txt_GeographyEnv.Size = new System.Drawing.Size(191, 31);
            this.txt_GeographyEnv.TabIndex = 29;
            this.txt_GeographyEnv.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(366, 107);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(88, 16);
            this.bunifuCustomLabel4.TabIndex = 30;
            this.bunifuCustomLabel4.Text = "道路交通：";
            // 
            // txt_RoadTransport
            // 
            this.txt_RoadTransport.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_RoadTransport.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_RoadTransport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_RoadTransport.HintForeColor = System.Drawing.Color.Empty;
            this.txt_RoadTransport.HintText = "";
            this.txt_RoadTransport.isPassword = false;
            this.txt_RoadTransport.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_RoadTransport.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_RoadTransport.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_RoadTransport.LineThickness = 3;
            this.txt_RoadTransport.Location = new System.Drawing.Point(461, 92);
            this.txt_RoadTransport.Margin = new System.Windows.Forms.Padding(4);
            this.txt_RoadTransport.Name = "txt_RoadTransport";
            this.txt_RoadTransport.Size = new System.Drawing.Size(191, 31);
            this.txt_RoadTransport.TabIndex = 31;
            this.txt_RoadTransport.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("宋体", 12F);
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(55, 170);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(56, 16);
            this.bunifuCustomLabel5.TabIndex = 32;
            this.bunifuCustomLabel5.Text = "水系：";
            // 
            // txt_WaterSystem
            // 
            this.txt_WaterSystem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_WaterSystem.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_WaterSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_WaterSystem.HintForeColor = System.Drawing.Color.Empty;
            this.txt_WaterSystem.HintText = "";
            this.txt_WaterSystem.isPassword = false;
            this.txt_WaterSystem.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_WaterSystem.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_WaterSystem.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.txt_WaterSystem.LineThickness = 3;
            this.txt_WaterSystem.Location = new System.Drawing.Point(150, 155);
            this.txt_WaterSystem.Margin = new System.Windows.Forms.Padding(4);
            this.txt_WaterSystem.Name = "txt_WaterSystem";
            this.txt_WaterSystem.Size = new System.Drawing.Size(191, 31);
            this.txt_WaterSystem.TabIndex = 33;
            this.txt_WaterSystem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.Tomato;
            this.bunifuCards1.Controls.Add(this.txt_WaterSystem);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel5);
            this.bunifuCards1.Controls.Add(this.txt_RoadTransport);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel4);
            this.bunifuCards1.Controls.Add(this.txt_GeographyEnv);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel3);
            this.bunifuCards1.Controls.Add(this.txt_ZoneScale);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel2);
            this.bunifuCards1.Controls.Add(this.txt_ZoneID);
            this.bunifuCards1.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuCards1.Controls.Add(this.btn_Cancel);
            this.bunifuCards1.Controls.Add(this.btn_OK);
            this.bunifuCards1.Controls.Add(this.lbl_descript);
            this.bunifuCards1.Controls.Add(this.txt_Description);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(721, 594);
            this.bunifuCards1.TabIndex = 3;
            // 
            // Form_GeographyEnvAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 628);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_GeographyEnvAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_GeographyEnvAdd";
            this.Load += new System.EventHandler(this.Form_GeographyEnvAdd_Load);
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
        private ns1.BunifuCustomLabel Title_Lable;
        private ns1.BunifuImageButton Exit;
        public ns1.BunifuCustomLabel Title_Label;
        private System.Windows.Forms.Panel Content;
        private ns1.BunifuCards bunifuCards1;
        private ns1.BunifuMaterialTextbox txt_WaterSystem;
        private ns1.BunifuCustomLabel bunifuCustomLabel5;
        private ns1.BunifuMaterialTextbox txt_RoadTransport;
        private ns1.BunifuCustomLabel bunifuCustomLabel4;
        private ns1.BunifuMaterialTextbox txt_GeographyEnv;
        private ns1.BunifuCustomLabel bunifuCustomLabel3;
        private ns1.BunifuMaterialTextbox txt_ZoneScale;
        private ns1.BunifuCustomLabel bunifuCustomLabel2;
        private ns1.BunifuMaterialTextbox txt_ZoneID;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private ns1.BunifuThinButton2 btn_Cancel;
        private ns1.BunifuThinButton2 btn_OK;
        private ns1.BunifuCustomLabel lbl_descript;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txt_Description;
    }
}