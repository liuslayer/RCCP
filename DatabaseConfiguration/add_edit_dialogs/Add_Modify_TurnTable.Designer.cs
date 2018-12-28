namespace DatabaseConfiguration.add_edit_dialogs
{
    partial class Add_Modify_TurnTable
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
            this.comboBoxProtocolType = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTurntableAddr = new System.Windows.Forms.TextBox();
            this.txtIRAddr = new System.Windows.Forms.TextBox();
            this.txtCCDAddr = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtazimuthangle = new System.Windows.Forms.TextBox();
            this.txterectingheight = new System.Windows.Forms.TextBox();
            this.txtalt = new System.Windows.Forms.TextBox();
            this.txtlat = new System.Windows.Forms.TextBox();
            this.txtlon = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsure = new System.Windows.Forms.Button();
            this.txtdescription = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxCommunicationInternet = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxProtocolType
            // 
            this.comboBoxProtocolType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProtocolType.FormattingEnabled = true;
            this.comboBoxProtocolType.Items.AddRange(new object[] {
            "209所远程转台",
            "209所中程转台",
            "209所近程转台",
            "368转台",
            "508转台",
            "大力富士能转台",
            "神戎富士能转台",
            "大力吉达转台",
            "神戎吉达转台",
            "11所转台",
            "神戎转台(内蒙)",
            "Pelco_P",
            "透明通道",
            "209 XW-EOST100",
            "高普乐",
            "OP3"});
            this.comboBoxProtocolType.Location = new System.Drawing.Point(73, 202);
            this.comboBoxProtocolType.Name = "comboBoxProtocolType";
            this.comboBoxProtocolType.Size = new System.Drawing.Size(227, 20);
            this.comboBoxProtocolType.TabIndex = 134;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.Control;
            this.label19.Location = new System.Drawing.Point(11, 205);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 133;
            this.label19.Text = "转台协议：";
            // 
            // txtTurntableAddr
            // 
            this.txtTurntableAddr.Location = new System.Drawing.Point(73, 228);
            this.txtTurntableAddr.Name = "txtTurntableAddr";
            this.txtTurntableAddr.Size = new System.Drawing.Size(227, 21);
            this.txtTurntableAddr.TabIndex = 130;
            this.txtTurntableAddr.Text = "0";
            // 
            // txtIRAddr
            // 
            this.txtIRAddr.Location = new System.Drawing.Point(73, 282);
            this.txtIRAddr.Name = "txtIRAddr";
            this.txtIRAddr.Size = new System.Drawing.Size(227, 21);
            this.txtIRAddr.TabIndex = 132;
            this.txtIRAddr.Text = "0";
            // 
            // txtCCDAddr
            // 
            this.txtCCDAddr.Location = new System.Drawing.Point(73, 255);
            this.txtCCDAddr.Name = "txtCCDAddr";
            this.txtCCDAddr.Size = new System.Drawing.Size(227, 21);
            this.txtCCDAddr.TabIndex = 131;
            this.txtCCDAddr.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.Control;
            this.label16.Location = new System.Drawing.Point(11, 285);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 129;
            this.label16.Text = "红外地址：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.Control;
            this.label17.Location = new System.Drawing.Point(11, 258);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 128;
            this.label17.Text = "白光地址：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.Control;
            this.label18.Location = new System.Drawing.Point(11, 231);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 127;
            this.label18.Text = "转台地址：";
            // 
            // txtazimuthangle
            // 
            this.txtazimuthangle.Location = new System.Drawing.Point(73, 175);
            this.txtazimuthangle.Name = "txtazimuthangle";
            this.txtazimuthangle.Size = new System.Drawing.Size(227, 21);
            this.txtazimuthangle.TabIndex = 116;
            this.txtazimuthangle.Text = "0";
            // 
            // txterectingheight
            // 
            this.txterectingheight.Location = new System.Drawing.Point(73, 148);
            this.txterectingheight.Name = "txterectingheight";
            this.txterectingheight.Size = new System.Drawing.Size(227, 21);
            this.txterectingheight.TabIndex = 115;
            this.txterectingheight.Text = "0";
            // 
            // txtalt
            // 
            this.txtalt.Location = new System.Drawing.Point(73, 95);
            this.txtalt.Name = "txtalt";
            this.txtalt.Size = new System.Drawing.Size(227, 21);
            this.txtalt.TabIndex = 114;
            this.txtalt.Text = "500";
            // 
            // txtlat
            // 
            this.txtlat.Location = new System.Drawing.Point(73, 68);
            this.txtlat.Name = "txtlat";
            this.txtlat.Size = new System.Drawing.Size(227, 21);
            this.txtlat.TabIndex = 113;
            this.txtlat.Text = "30";
            // 
            // txtlon
            // 
            this.txtlon.Location = new System.Drawing.Point(73, 41);
            this.txtlon.Name = "txtlon";
            this.txtlon.Size = new System.Drawing.Size(227, 21);
            this.txtlon.TabIndex = 112;
            this.txtlon.Text = "104";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(73, 14);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(227, 21);
            this.txtname.TabIndex = 111;
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(183, 536);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(39, 23);
            this.btncancel.TabIndex = 109;
            this.btncancel.Text = "取消";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsure
            // 
            this.btnsure.Location = new System.Drawing.Point(117, 536);
            this.btnsure.Name = "btnsure";
            this.btnsure.Size = new System.Drawing.Size(39, 23);
            this.btnsure.TabIndex = 108;
            this.btnsure.Text = "确定";
            this.btnsure.UseVisualStyleBackColor = true;
            this.btnsure.Click += new System.EventHandler(this.btnsure_Click);
            // 
            // txtdescription
            // 
            this.txtdescription.Location = new System.Drawing.Point(12, 424);
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(314, 96);
            this.txtdescription.TabIndex = 107;
            this.txtdescription.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(10, 396);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 106;
            this.label13.Text = "描述：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(11, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 101;
            this.label8.Text = "偏 北 角：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(11, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 100;
            this.label7.Text = "架设高度：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(11, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 99;
            this.label6.Text = "海    拔：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(11, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 98;
            this.label5.Text = "纬    度：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(11, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 97;
            this.label4.Text = "经    度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(11, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 96;
            this.label3.Text = "名    称：";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(73, 309);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(227, 20);
            this.comboBox1.TabIndex = 136;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(2, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 135;
            this.label1.Text = "所属工作站：";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "209所远程转台",
            "209所中程转台",
            "209所近程转台",
            "368转台",
            "508转台",
            "大力富士能转台",
            "神戎富士能转台",
            "大力吉达转台",
            "神戎吉达转台",
            "11所转台",
            "神戎转台(内蒙)",
            "Pelco_P",
            "透明通道",
            "209 XW-EOST100",
            "高普乐",
            "OP3"});
            this.comboBox2.Location = new System.Drawing.Point(73, 122);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(227, 20);
            this.comboBox2.TabIndex = 138;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(11, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 137;
            this.label2.Text = "测试方式：";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(72, 361);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(228, 20);
            this.comboBox3.TabIndex = 201;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(8, 364);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 200;
            this.label9.Text = "通信信息：";
            // 
            // comboBoxCommunicationInternet
            // 
            this.comboBoxCommunicationInternet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCommunicationInternet.FormattingEnabled = true;
            this.comboBoxCommunicationInternet.Location = new System.Drawing.Point(73, 335);
            this.comboBoxCommunicationInternet.Name = "comboBoxCommunicationInternet";
            this.comboBoxCommunicationInternet.Size = new System.Drawing.Size(227, 20);
            this.comboBoxCommunicationInternet.TabIndex = 199;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.Control;
            this.label15.Location = new System.Drawing.Point(9, 338);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 198;
            this.label15.Text = "通信类型：";
            // 
            // Add_Modify_TurnTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(344, 564);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxCommunicationInternet);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxProtocolType);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtTurntableAddr);
            this.Controls.Add(this.txtIRAddr);
            this.Controls.Add(this.txtCCDAddr);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtazimuthangle);
            this.Controls.Add(this.txterectingheight);
            this.Controls.Add(this.txtalt);
            this.Controls.Add(this.txtlat);
            this.Controls.Add(this.txtlon);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsure);
            this.Controls.Add(this.txtdescription);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "Add_Modify_TurnTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Modify_TurnTable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxProtocolType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTurntableAddr;
        private System.Windows.Forms.TextBox txtIRAddr;
        private System.Windows.Forms.TextBox txtCCDAddr;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtazimuthangle;
        private System.Windows.Forms.TextBox txterectingheight;
        private System.Windows.Forms.TextBox txtalt;
        private System.Windows.Forms.TextBox txtlat;
        private System.Windows.Forms.TextBox txtlon;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsure;
        private System.Windows.Forms.RichTextBox txtdescription;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxCommunicationInternet;
        private System.Windows.Forms.Label label15;
    }
}