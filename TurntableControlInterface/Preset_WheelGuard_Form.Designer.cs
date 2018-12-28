namespace TurntableControlInterface
{
    partial class Preset_WheelGuard_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preset_WheelGuard_Form));
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.dgvWheelGuard = new System.Windows.Forms.DataGridView();
            this.PresetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WheelTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_sure = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.wheelGuard = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.subToListView = new System.Windows.Forms.Button();
            this.addToListView = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWheelGuard)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(330, 319);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(84, 16);
            this.checkBox2.TabIndex = 59;
            this.checkBox2.Text = "轮巡布撤防";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // dgvWheelGuard
            // 
            this.dgvWheelGuard.AllowUserToAddRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.White;
            this.dgvWheelGuard.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvWheelGuard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWheelGuard.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvWheelGuard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWheelGuard.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvWheelGuard.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(70)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWheelGuard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgvWheelGuard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWheelGuard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PresetName,
            this.WheelTime});
            this.dgvWheelGuard.EnableHeadersVisualStyles = false;
            this.dgvWheelGuard.Location = new System.Drawing.Point(167, 81);
            this.dgvWheelGuard.Name = "dgvWheelGuard";
            this.dgvWheelGuard.ReadOnly = true;
            this.dgvWheelGuard.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvWheelGuard.RowHeadersVisible = false;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(204)))), ((int)(((byte)(226)))));
            this.dgvWheelGuard.RowsDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvWheelGuard.RowTemplate.Height = 23;
            this.dgvWheelGuard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWheelGuard.Size = new System.Drawing.Size(270, 182);
            this.dgvWheelGuard.TabIndex = 58;
            this.dgvWheelGuard.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWheelGuard_CellClick);
            // 
            // PresetName
            // 
            this.PresetName.HeaderText = "预置位名称";
            this.PresetName.Name = "PresetName";
            this.PresetName.ReadOnly = true;
            this.PresetName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WheelTime
            // 
            this.WheelTime.HeaderText = "轮巡时间（S）";
            this.WheelTime.Name = "WheelTime";
            this.WheelTime.ReadOnly = true;
            this.WheelTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button_sure
            // 
            this.button_sure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(132)))), ((int)(((byte)(201)))));
            this.button_sure.FlatAppearance.BorderSize = 0;
            this.button_sure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sure.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_sure.ForeColor = System.Drawing.Color.White;
            this.button_sure.Location = new System.Drawing.Point(393, 276);
            this.button_sure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_sure.Name = "button_sure";
            this.button_sure.Size = new System.Drawing.Size(44, 22);
            this.button_sure.TabIndex = 57;
            this.button_sure.Text = "确定";
            this.button_sure.UseVisualStyleBackColor = false;
            this.button_sure.Click += new System.EventHandler(this.button_sure_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(176, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 17);
            this.label6.TabIndex = 56;
            this.label6.Text = "修改选中行的轮巡时间";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(310, 274);
            this.txtTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(67, 21);
            this.txtTime.TabIndex = 55;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(171, 318);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(144, 16);
            this.checkBox1.TabIndex = 54;
            this.checkBox1.Text = "统一应用当前时间间隔";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(132)))), ((int)(((byte)(201)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(303, 378);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(80, 32);
            this.button6.TabIndex = 53;
            this.button6.Text = "停止";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // wheelGuard
            // 
            this.wheelGuard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(132)))), ((int)(((byte)(201)))));
            this.wheelGuard.FlatAppearance.BorderSize = 0;
            this.wheelGuard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wheelGuard.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wheelGuard.ForeColor = System.Drawing.Color.White;
            this.wheelGuard.Location = new System.Drawing.Point(203, 378);
            this.wheelGuard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wheelGuard.Name = "wheelGuard";
            this.wheelGuard.Size = new System.Drawing.Size(80, 32);
            this.wheelGuard.TabIndex = 52;
            this.wheelGuard.Text = "启动";
            this.wheelGuard.UseVisualStyleBackColor = false;
            this.wheelGuard.Click += new System.EventHandler(this.wheelGuard_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(391, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 51;
            this.label5.Text = "秒";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "15",
            "20",
            "25",
            "30",
            "35",
            "40"});
            this.comboBox1.Location = new System.Drawing.Point(298, 341);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(84, 20);
            this.comboBox1.TabIndex = 50;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(172, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 49;
            this.label4.Text = "轮巡时间间隔选择：";
            // 
            // buttonDown
            // 
            this.buttonDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(132)))), ((int)(((byte)(201)))));
            this.buttonDown.FlatAppearance.BorderSize = 0;
            this.buttonDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDown.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.buttonDown.ForeColor = System.Drawing.Color.White;
            this.buttonDown.Location = new System.Drawing.Point(448, 200);
            this.buttonDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(30, 30);
            this.buttonDown.TabIndex = 48;
            this.buttonDown.Text = "∨";
            this.buttonDown.UseVisualStyleBackColor = false;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(132)))), ((int)(((byte)(201)))));
            this.buttonUp.FlatAppearance.BorderSize = 0;
            this.buttonUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.buttonUp.ForeColor = System.Drawing.Color.White;
            this.buttonUp.Location = new System.Drawing.Point(448, 132);
            this.buttonUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(30, 30);
            this.buttonUp.TabIndex = 47;
            this.buttonUp.Text = "∧";
            this.buttonUp.UseVisualStyleBackColor = false;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // subToListView
            // 
            this.subToListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(132)))), ((int)(((byte)(201)))));
            this.subToListView.FlatAppearance.BorderSize = 0;
            this.subToListView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subToListView.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.subToListView.ForeColor = System.Drawing.Color.White;
            this.subToListView.Location = new System.Drawing.Point(130, 200);
            this.subToListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.subToListView.Name = "subToListView";
            this.subToListView.Size = new System.Drawing.Size(30, 30);
            this.subToListView.TabIndex = 46;
            this.subToListView.Text = "＜";
            this.subToListView.UseVisualStyleBackColor = false;
            this.subToListView.Click += new System.EventHandler(this.subToListView_Click);
            // 
            // addToListView
            // 
            this.addToListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(132)))), ((int)(((byte)(201)))));
            this.addToListView.FlatAppearance.BorderSize = 0;
            this.addToListView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addToListView.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.addToListView.ForeColor = System.Drawing.Color.White;
            this.addToListView.Location = new System.Drawing.Point(130, 132);
            this.addToListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addToListView.Name = "addToListView";
            this.addToListView.Size = new System.Drawing.Size(30, 30);
            this.addToListView.TabIndex = 45;
            this.addToListView.Text = "＞";
            this.addToListView.UseVisualStyleBackColor = false;
            this.addToListView.Click += new System.EventHandler(this.addToListView_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(169, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "已选择预置位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 42;
            this.label2.Text = "预置位列表：";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 40);
            this.panel1.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "预置轮巡";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(456, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "×";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 81);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(112, 292);
            this.listBox1.TabIndex = 61;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // Preset_WheelGuard_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(491, 423);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.dgvWheelGuard);
            this.Controls.Add(this.button_sure);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.wheelGuard);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.subToListView);
            this.Controls.Add(this.addToListView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Preset_WheelGuard_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preset_WheelGuard_Form";
            this.Load += new System.EventHandler(this.Preset_WheelGuard_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWheelGuard)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.DataGridView dgvWheelGuard;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WheelTime;
        private System.Windows.Forms.Button button_sure;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button wheelGuard;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button subToListView;
        private System.Windows.Forms.Button addToListView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
    }
}