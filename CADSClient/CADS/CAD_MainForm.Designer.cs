namespace CADS
{
    partial class CAD_MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAD_MainForm));
            this.btnEPM = new MyButton.UserControl1();
            this.btnSVM = new MyButton.UserControl1();
            this.btnMSSM = new MyButton.UserControl1();
            this.btnMSG = new MyButton.UserControl1();
            this.button_help = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.button_min = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.label_SVM = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEPM
            // 
            this.btnEPM.BackColor = System.Drawing.Color.Transparent;
            this.btnEPM.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(78)))), ((int)(((byte)(140)))));
            this.btnEPM.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(84)))), ((int)(((byte)(170)))));
            this.btnEPM.ButtonText = null;
            this.btnEPM.CornerRadius = 0;
            this.btnEPM.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btnEPM.Location = new System.Drawing.Point(424, 0);
            this.btnEPM.Name = "btnEPM";
            this.btnEPM.Size = new System.Drawing.Size(115, 63);
            this.btnEPM.TabIndex = 0;
            this.btnEPM.Click += new System.EventHandler(this.btnEPM_Click);
            // 
            // btnSVM
            // 
            this.btnSVM.BackColor = System.Drawing.Color.Transparent;
            this.btnSVM.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(78)))), ((int)(((byte)(140)))));
            this.btnSVM.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(84)))), ((int)(((byte)(170)))));
            this.btnSVM.ButtonText = null;
            this.btnSVM.CornerRadius = 0;
            this.btnSVM.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btnSVM.Location = new System.Drawing.Point(539, 0);
            this.btnSVM.Name = "btnSVM";
            this.btnSVM.Size = new System.Drawing.Size(115, 63);
            this.btnSVM.TabIndex = 1;
            this.btnSVM.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSVM_MouseClick);
            // 
            // btnMSSM
            // 
            this.btnMSSM.BackColor = System.Drawing.Color.Transparent;
            this.btnMSSM.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(78)))), ((int)(((byte)(140)))));
            this.btnMSSM.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(84)))), ((int)(((byte)(170)))));
            this.btnMSSM.ButtonText = null;
            this.btnMSSM.CornerRadius = 0;
            this.btnMSSM.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btnMSSM.Location = new System.Drawing.Point(654, 0);
            this.btnMSSM.Name = "btnMSSM";
            this.btnMSSM.Size = new System.Drawing.Size(115, 63);
            this.btnMSSM.TabIndex = 2;
            this.btnMSSM.Click += new System.EventHandler(this.btnMSSM_Click);
            // 
            // btnMSG
            // 
            this.btnMSG.BackColor = System.Drawing.Color.Transparent;
            this.btnMSG.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(78)))), ((int)(((byte)(140)))));
            this.btnMSG.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(84)))), ((int)(((byte)(170)))));
            this.btnMSG.ButtonText = null;
            this.btnMSG.CornerRadius = 0;
            this.btnMSG.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.btnMSG.Location = new System.Drawing.Point(769, 0);
            this.btnMSG.Name = "btnMSG";
            this.btnMSG.Size = new System.Drawing.Size(115, 63);
            this.btnMSG.TabIndex = 3;
            this.btnMSG.Click += new System.EventHandler(this.btnMSG_Click);
            // 
            // button_help
            // 
            this.button_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_help.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(109)))), ((int)(((byte)(171)))));
            this.button_help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_help.FlatAppearance.BorderSize = 0;
            this.button_help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_help.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_help.ForeColor = System.Drawing.SystemColors.Control;
            this.button_help.Location = new System.Drawing.Point(1010, 0);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(30, 30);
            this.button_help.TabIndex = 25;
            this.button_help.Text = "?";
            this.button_help.UseVisualStyleBackColor = true;
            // 
            // button_close
            // 
            this.button_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(109)))), ((int)(((byte)(171)))));
            this.button_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_close.FlatAppearance.BorderSize = 0;
            this.button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_close.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_close.ForeColor = System.Drawing.SystemColors.Control;
            this.button_close.Location = new System.Drawing.Point(1070, 0);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(30, 30);
            this.button_close.TabIndex = 27;
            this.button_close.Text = "×";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_min
            // 
            this.button_min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(109)))), ((int)(((byte)(171)))));
            this.button_min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_min.FlatAppearance.BorderSize = 0;
            this.button_min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_min.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_min.ForeColor = System.Drawing.SystemColors.Control;
            this.button_min.Location = new System.Drawing.Point(1040, 0);
            this.button_min.Name = "button_min";
            this.button_min.Size = new System.Drawing.Size(30, 30);
            this.button_min.TabIndex = 26;
            this.button_min.Text = "－";
            this.button_min.UseVisualStyleBackColor = true;
            this.button_min.Click += new System.EventHandler(this.button_min_Click);
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.logo.BackgroundImage = global::CADS.Properties.Resources.logo;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logo.Location = new System.Drawing.Point(12, 13);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(50, 50);
            this.logo.TabIndex = 31;
            this.logo.TabStop = false;
            // 
            // label_SVM
            // 
            this.label_SVM.AutoSize = true;
            this.label_SVM.BackColor = System.Drawing.Color.Transparent;
            this.label_SVM.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SVM.Location = new System.Drawing.Point(116, 13);
            this.label_SVM.Name = "label_SVM";
            this.label_SVM.Size = new System.Drawing.Size(193, 29);
            this.label_SVM.TabIndex = 32;
            this.label_SVM.Text = "勤务管理系统";
            // 
            // CAD_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CADS.Properties.Resources.背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.label_SVM);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_min);
            this.Controls.Add(this.btnMSG);
            this.Controls.Add(this.btnMSSM);
            this.Controls.Add(this.btnSVM);
            this.Controls.Add(this.btnEPM);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CAD_MainForm";
            this.Text = "指挥调度系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CADMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyButton.UserControl1 btnEPM;
        private MyButton.UserControl1 btnSVM;
        private MyButton.UserControl1 btnMSSM;
        private MyButton.UserControl1 btnMSG;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_min;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label label_SVM;
    }
}

