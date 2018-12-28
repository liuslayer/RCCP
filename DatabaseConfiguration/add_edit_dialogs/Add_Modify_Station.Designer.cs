namespace DatabaseConfiguration.add_edit_dialogs
{
    partial class Add_Modify_Station
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
            this.txtname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtlat = new System.Windows.Forms.TextBox();
            this.txtlon = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtdescription = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsure = new System.Windows.Forms.Button();
            this.cbxtypename = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(85, 44);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(231, 21);
            this.txtname.TabIndex = 173;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(20, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 172;
            this.label2.Text = "名    称：";
            // 
            // txtlat
            // 
            this.txtlat.Location = new System.Drawing.Point(85, 124);
            this.txtlat.Name = "txtlat";
            this.txtlat.Size = new System.Drawing.Size(231, 21);
            this.txtlat.TabIndex = 192;
            this.txtlat.Text = "30.206586";
            // 
            // txtlon
            // 
            this.txtlon.Location = new System.Drawing.Point(85, 97);
            this.txtlon.Name = "txtlon";
            this.txtlon.Size = new System.Drawing.Size(231, 21);
            this.txtlon.TabIndex = 191;
            this.txtlon.Text = "104.240708";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(20, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 190;
            this.label10.Text = "纬    度：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(20, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 189;
            this.label11.Text = "经    度：";
            // 
            // txtdescription
            // 
            this.txtdescription.Location = new System.Drawing.Point(46, 176);
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(279, 96);
            this.txtdescription.TabIndex = 194;
            this.txtdescription.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(12, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 193;
            this.label8.Text = "描  述：";
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(211, 308);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(43, 23);
            this.btncancel.TabIndex = 196;
            this.btncancel.Text = "取消";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsure
            // 
            this.btnsure.Location = new System.Drawing.Point(85, 308);
            this.btnsure.Name = "btnsure";
            this.btnsure.Size = new System.Drawing.Size(43, 23);
            this.btnsure.TabIndex = 195;
            this.btnsure.Text = "确定";
            this.btnsure.UseVisualStyleBackColor = true;
            this.btnsure.Click += new System.EventHandler(this.btnsure_Click);
            // 
            // cbxtypename
            // 
            this.cbxtypename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxtypename.FormattingEnabled = true;
            this.cbxtypename.Location = new System.Drawing.Point(85, 14);
            this.cbxtypename.Name = "cbxtypename";
            this.cbxtypename.Size = new System.Drawing.Size(231, 20);
            this.cbxtypename.TabIndex = 198;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(20, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 197;
            this.label9.Text = "类    型：";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(85, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(231, 20);
            this.comboBox1.TabIndex = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(10, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 199;
            this.label1.Text = "上级工作站：";
            // 
            // Add_Modify_Station
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(349, 343);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxtypename);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsure);
            this.Controls.Add(this.txtdescription);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtlat);
            this.Controls.Add(this.txtlon);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label2);
            this.Name = "Add_Modify_Station";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工作站";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtlat;
        private System.Windows.Forms.TextBox txtlon;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox txtdescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsure;
        private System.Windows.Forms.ComboBox cbxtypename;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}