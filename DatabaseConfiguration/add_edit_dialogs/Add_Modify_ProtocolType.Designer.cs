namespace DatabaseConfiguration.add_edit_dialogs
{
    partial class Add_Modify_ProtocolType
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbxtypename = new System.Windows.Forms.ComboBox();
            this.txtprotocoltypeid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(126, 37);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(141, 21);
            this.txtname.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(31, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 46;
            this.label3.Text = "协议类型名称：";
            // 
            // cbxtypename
            // 
            this.cbxtypename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxtypename.FormattingEnabled = true;
            this.cbxtypename.Location = new System.Drawing.Point(126, 90);
            this.cbxtypename.Name = "cbxtypename";
            this.cbxtypename.Size = new System.Drawing.Size(141, 20);
            this.cbxtypename.TabIndex = 53;
            // 
            // txtprotocoltypeid
            // 
            this.txtprotocoltypeid.Location = new System.Drawing.Point(126, 64);
            this.txtprotocoltypeid.Name = "txtprotocoltypeid";
            this.txtprotocoltypeid.Size = new System.Drawing.Size(141, 21);
            this.txtprotocoltypeid.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(31, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 51;
            this.label6.Text = "设备类别：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(31, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 50;
            this.label5.Text = "协议类型ID：";
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(147, 166);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(39, 23);
            this.btncancel.TabIndex = 59;
            this.btncancel.Text = "取消";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsure
            // 
            this.btnsure.Location = new System.Drawing.Point(81, 166);
            this.btnsure.Name = "btnsure";
            this.btnsure.Size = new System.Drawing.Size(39, 23);
            this.btnsure.TabIndex = 58;
            this.btnsure.Text = "确定";
            this.btnsure.UseVisualStyleBackColor = true;
            this.btnsure.Click += new System.EventHandler(this.btnsure_Click);
            // 
            // Add_Modify_ProtocolType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(302, 262);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsure);
            this.Controls.Add(this.cbxtypename);
            this.Controls.Add(this.txtprotocoltypeid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label3);
            this.Name = "Add_Modify_ProtocolType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Modify_ProtocolType";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxtypename;
        private System.Windows.Forms.TextBox txtprotocoltypeid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsure;
    }
}