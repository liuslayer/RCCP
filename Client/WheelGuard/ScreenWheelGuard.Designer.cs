namespace Client
{
    partial class ScreenWheelGuard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenWheelGuard));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dgvWheelGuard = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WheelTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_sure = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.cbxTime = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.wheelGuard = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTime = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.removeFromWheelGuard = new System.Windows.Forms.Button();
            this.addToWheelGuard = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWheelGuard)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(528, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 25);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(559, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "视频轮巡";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.dgvWheelGuard);
            this.panel1.Controls.Add(this.button_sure);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtTime);
            this.panel1.Controls.Add(this.cbxTime);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.wheelGuard);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboTime);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.buttonDown);
            this.panel1.Controls.Add(this.buttonUp);
            this.panel1.Controls.Add(this.removeFromWheelGuard);
            this.panel1.Controls.Add(this.addToWheelGuard);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.Color.Teal;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 452);
            this.panel1.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.FullRowSelect = true;
            this.treeView1.Location = new System.Drawing.Point(9, 62);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowLines = false;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(181, 245);
            this.treeView1.TabIndex = 56;
            // 
            // dgvWheelGuard
            // 
            this.dgvWheelGuard.AllowUserToAddRows = false;
            this.dgvWheelGuard.AllowUserToResizeColumns = false;
            this.dgvWheelGuard.AllowUserToResizeRows = false;
            dataGridViewCellStyle40.BackColor = System.Drawing.Color.White;
            this.dgvWheelGuard.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle40;
            this.dgvWheelGuard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWheelGuard.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvWheelGuard.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle41.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle41.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWheelGuard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle41;
            this.dgvWheelGuard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWheelGuard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.WheelTime,
            this.Column3,
            this.Column2});
            this.dgvWheelGuard.EnableHeadersVisualStyles = false;
            this.dgvWheelGuard.Location = new System.Drawing.Point(248, 71);
            this.dgvWheelGuard.Name = "dgvWheelGuard";
            this.dgvWheelGuard.ReadOnly = true;
            this.dgvWheelGuard.RowHeadersVisible = false;
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(204)))), ((int)(((byte)(226)))));
            this.dgvWheelGuard.RowsDefaultCellStyle = dataGridViewCellStyle42;
            this.dgvWheelGuard.RowTemplate.Height = 23;
            this.dgvWheelGuard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWheelGuard.Size = new System.Drawing.Size(270, 182);
            this.dgvWheelGuard.TabIndex = 55;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "通道号名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WheelTime
            // 
            this.WheelTime.HeaderText = "轮巡时间（S）";
            this.WheelTime.Name = "WheelTime";
            this.WheelTime.ReadOnly = true;
            this.WheelTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "设备ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // button_sure
            // 
            this.button_sure.BackColor = System.Drawing.Color.Teal;
            this.button_sure.FlatAppearance.BorderSize = 0;
            this.button_sure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sure.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_sure.ForeColor = System.Drawing.Color.White;
            this.button_sure.Location = new System.Drawing.Point(452, 268);
            this.button_sure.Name = "button_sure";
            this.button_sure.Size = new System.Drawing.Size(44, 21);
            this.button_sure.TabIndex = 54;
            this.button_sure.Text = "确定";
            this.button_sure.UseVisualStyleBackColor = false;
            this.button_sure.Click += new System.EventHandler(this.button_sure_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Teal;
            this.label6.Location = new System.Drawing.Point(253, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 12);
            this.label6.TabIndex = 53;
            this.label6.Text = "修改选中行的轮巡时间";
            // 
            // txtTime
            // 
            this.txtTime.ForeColor = System.Drawing.Color.Teal;
            this.txtTime.Location = new System.Drawing.Point(381, 267);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(58, 21);
            this.txtTime.TabIndex = 52;
            // 
            // cbxTime
            // 
            this.cbxTime.AutoSize = true;
            this.cbxTime.ForeColor = System.Drawing.Color.Teal;
            this.cbxTime.Location = new System.Drawing.Point(262, 312);
            this.cbxTime.Name = "cbxTime";
            this.cbxTime.Size = new System.Drawing.Size(144, 16);
            this.cbxTime.TabIndex = 51;
            this.cbxTime.Text = "统一应用当前时间间隔";
            this.cbxTime.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Teal;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(370, 384);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 32);
            this.btnStop.TabIndex = 50;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // wheelGuard
            // 
            this.wheelGuard.BackColor = System.Drawing.Color.Teal;
            this.wheelGuard.FlatAppearance.BorderSize = 0;
            this.wheelGuard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wheelGuard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wheelGuard.ForeColor = System.Drawing.Color.White;
            this.wheelGuard.Location = new System.Drawing.Point(262, 384);
            this.wheelGuard.Name = "wheelGuard";
            this.wheelGuard.Size = new System.Drawing.Size(80, 32);
            this.wheelGuard.TabIndex = 49;
            this.wheelGuard.Text = "启动";
            this.wheelGuard.UseVisualStyleBackColor = false;
            this.wheelGuard.Click += new System.EventHandler(this.wheelGuard_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(433, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 48;
            this.label5.Text = "秒";
            // 
            // cboTime
            // 
            this.cboTime.ForeColor = System.Drawing.Color.Teal;
            this.cboTime.FormattingEnabled = true;
            this.cboTime.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40"});
            this.cboTime.Location = new System.Drawing.Point(354, 338);
            this.cboTime.Name = "cboTime";
            this.cboTime.Size = new System.Drawing.Size(73, 20);
            this.cboTime.TabIndex = 47;
            this.cboTime.SelectedValueChanged += new System.EventHandler(this.cboTime_SelectedValueChanged);
            this.cboTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTime_KeyPress);
            this.cboTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboTime_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(246, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 46;
            this.label4.Text = "轮巡时间间隔选择：";
            // 
            // buttonDown
            // 
            this.buttonDown.BackColor = System.Drawing.Color.Teal;
            this.buttonDown.FlatAppearance.BorderSize = 0;
            this.buttonDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDown.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDown.ForeColor = System.Drawing.Color.White;
            this.buttonDown.Location = new System.Drawing.Point(538, 163);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(30, 30);
            this.buttonDown.TabIndex = 45;
            this.buttonDown.Text = "∨";
            this.buttonDown.UseVisualStyleBackColor = false;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.BackColor = System.Drawing.Color.Teal;
            this.buttonUp.FlatAppearance.BorderSize = 0;
            this.buttonUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonUp.ForeColor = System.Drawing.Color.White;
            this.buttonUp.Location = new System.Drawing.Point(538, 115);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(30, 30);
            this.buttonUp.TabIndex = 44;
            this.buttonUp.Text = "∧";
            this.buttonUp.UseVisualStyleBackColor = false;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // removeFromWheelGuard
            // 
            this.removeFromWheelGuard.BackColor = System.Drawing.Color.Teal;
            this.removeFromWheelGuard.FlatAppearance.BorderSize = 0;
            this.removeFromWheelGuard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeFromWheelGuard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.removeFromWheelGuard.ForeColor = System.Drawing.Color.White;
            this.removeFromWheelGuard.Location = new System.Drawing.Point(207, 163);
            this.removeFromWheelGuard.Name = "removeFromWheelGuard";
            this.removeFromWheelGuard.Size = new System.Drawing.Size(30, 30);
            this.removeFromWheelGuard.TabIndex = 43;
            this.removeFromWheelGuard.Text = "＜";
            this.removeFromWheelGuard.UseVisualStyleBackColor = false;
            this.removeFromWheelGuard.Click += new System.EventHandler(this.removeFromWheelGuard_Click);
            // 
            // addToWheelGuard
            // 
            this.addToWheelGuard.BackColor = System.Drawing.Color.Teal;
            this.addToWheelGuard.FlatAppearance.BorderSize = 0;
            this.addToWheelGuard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addToWheelGuard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addToWheelGuard.ForeColor = System.Drawing.Color.White;
            this.addToWheelGuard.Location = new System.Drawing.Point(207, 115);
            this.addToWheelGuard.Name = "addToWheelGuard";
            this.addToWheelGuard.Size = new System.Drawing.Size(30, 30);
            this.addToWheelGuard.TabIndex = 42;
            this.addToWheelGuard.Text = "＞";
            this.addToWheelGuard.UseVisualStyleBackColor = false;
            this.addToWheelGuard.Click += new System.EventHandler(this.addToWheelGuard_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(246, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 12);
            this.label3.TabIndex = 40;
            this.label3.Text = "已选择视频通道：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(14, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "视频列表：";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // ScreenWheelGuard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(585, 485);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenWheelGuard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScreenWheelGuard";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenWheelGuard_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWheelGuard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvWheelGuard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn WheelTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button button_sure;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.CheckBox cbxTime;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button wheelGuard;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button removeFromWheelGuard;
        private System.Windows.Forms.Button addToWheelGuard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}