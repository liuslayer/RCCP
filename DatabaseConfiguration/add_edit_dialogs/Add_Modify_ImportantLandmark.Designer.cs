namespace DatabaseConfiguration.add_edit_dialogs
{
    partial class Add_Modify_ImportantLandmark
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
            this.txtalt = new System.Windows.Forms.TextBox();
            this.txtlat = new System.Windows.Forms.TextBox();
            this.txtlon = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsure = new System.Windows.Forms.Button();
            this.txtdescription = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtalt
            // 
            this.txtalt.Location = new System.Drawing.Point(70, 93);
            this.txtalt.Name = "txtalt";
            this.txtalt.Size = new System.Drawing.Size(227, 21);
            this.txtalt.TabIndex = 126;
            this.txtalt.Text = "500";
            // 
            // txtlat
            // 
            this.txtlat.Location = new System.Drawing.Point(70, 66);
            this.txtlat.Name = "txtlat";
            this.txtlat.Size = new System.Drawing.Size(227, 21);
            this.txtlat.TabIndex = 125;
            this.txtlat.Text = "30";
            // 
            // txtlon
            // 
            this.txtlon.Location = new System.Drawing.Point(70, 39);
            this.txtlon.Name = "txtlon";
            this.txtlon.Size = new System.Drawing.Size(227, 21);
            this.txtlon.TabIndex = 124;
            this.txtlon.Text = "104";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(70, 12);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(227, 21);
            this.txtname.TabIndex = 123;
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(181, 261);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(39, 23);
            this.btncancel.TabIndex = 122;
            this.btncancel.Text = "取消";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsure
            // 
            this.btnsure.Location = new System.Drawing.Point(115, 261);
            this.btnsure.Name = "btnsure";
            this.btnsure.Size = new System.Drawing.Size(39, 23);
            this.btnsure.TabIndex = 121;
            this.btnsure.Text = "确定";
            this.btnsure.UseVisualStyleBackColor = true;
            this.btnsure.Click += new System.EventHandler(this.btnsure_Click);
            // 
            // txtdescription
            // 
            this.txtdescription.Location = new System.Drawing.Point(10, 149);
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(314, 96);
            this.txtdescription.TabIndex = 120;
            this.txtdescription.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(8, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 119;
            this.label13.Text = "描述：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(8, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 118;
            this.label6.Text = "海    拔：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(8, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 117;
            this.label5.Text = "纬    度：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(8, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 116;
            this.label4.Text = "经    度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(8, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 115;
            this.label3.Text = "名    称：";
            // 
            // Add_Modify_ImportantLandmark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(345, 337);
            this.Controls.Add(this.txtalt);
            this.Controls.Add(this.txtlat);
            this.Controls.Add(this.txtlon);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsure);
            this.Controls.Add(this.txtdescription);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "Add_Modify_ImportantLandmark";
            this.Text = "Add_Modify_ImportantLandmark";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtalt;
        private System.Windows.Forms.TextBox txtlat;
        private System.Windows.Forms.TextBox txtlon;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsure;
        private System.Windows.Forms.RichTextBox txtdescription;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}