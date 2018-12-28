namespace SVM
{
    partial class CommandForm
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
            this.cbx_Station = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SendCommand = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_PatrolRoute = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_Description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_PatrolTime = new System.Windows.Forms.TextBox();
            this.btn_SendMsg = new System.Windows.Forms.Button();
            this.tbx_SendMsg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_Msg = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_StationName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbx_Station
            // 
            this.cbx_Station.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Station.FormattingEnabled = true;
            this.cbx_Station.Items.AddRange(new object[] {
            "监控站1",
            "监控站2",
            "监控站3"});
            this.cbx_Station.Location = new System.Drawing.Point(71, 20);
            this.cbx_Station.Name = "cbx_Station";
            this.cbx_Station.Size = new System.Drawing.Size(121, 20);
            this.cbx_Station.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "监控站：";
            // 
            // btn_SendCommand
            // 
            this.btn_SendCommand.Location = new System.Drawing.Point(12, 303);
            this.btn_SendCommand.Name = "btn_SendCommand";
            this.btn_SendCommand.Size = new System.Drawing.Size(128, 23);
            this.btn_SendCommand.TabIndex = 2;
            this.btn_SendCommand.Text = "下达巡逻命令";
            this.btn_SendCommand.UseVisualStyleBackColor = true;
            this.btn_SendCommand.Click += new System.EventHandler(this.btn_SendCommand_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "巡逻路线：";
            // 
            // tbx_PatrolRoute
            // 
            this.tbx_PatrolRoute.Location = new System.Drawing.Point(83, 18);
            this.tbx_PatrolRoute.Name = "tbx_PatrolRoute";
            this.tbx_PatrolRoute.Size = new System.Drawing.Size(100, 21);
            this.tbx_PatrolRoute.TabIndex = 4;
            this.tbx_PatrolRoute.Text = "铁列克提-丘尔丘特-塔斯提";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.tbx_Description);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.tbx_PatrolTime);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btn_SendCommand);
            this.splitContainer1.Panel1.Controls.Add(this.tbx_PatrolRoute);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_SendMsg);
            this.splitContainer1.Panel2.Controls.Add(this.tbx_SendMsg);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.tbx_Msg);
            this.splitContainer1.Size = new System.Drawing.Size(557, 370);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "描述：";
            // 
            // tbx_Description
            // 
            this.tbx_Description.Location = new System.Drawing.Point(14, 145);
            this.tbx_Description.Multiline = true;
            this.tbx_Description.Name = "tbx_Description";
            this.tbx_Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Description.Size = new System.Drawing.Size(169, 143);
            this.tbx_Description.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "巡逻时间：";
            // 
            // tbx_PatrolTime
            // 
            this.tbx_PatrolTime.Location = new System.Drawing.Point(83, 65);
            this.tbx_PatrolTime.Name = "tbx_PatrolTime";
            this.tbx_PatrolTime.Size = new System.Drawing.Size(100, 21);
            this.tbx_PatrolTime.TabIndex = 6;
            // 
            // btn_SendMsg
            // 
            this.btn_SendMsg.Location = new System.Drawing.Point(264, 286);
            this.btn_SendMsg.Name = "btn_SendMsg";
            this.btn_SendMsg.Size = new System.Drawing.Size(69, 57);
            this.btn_SendMsg.TabIndex = 12;
            this.btn_SendMsg.Text = "发送";
            this.btn_SendMsg.UseVisualStyleBackColor = true;
            this.btn_SendMsg.Click += new System.EventHandler(this.btn_SendMsg_Click);
            // 
            // tbx_SendMsg
            // 
            this.tbx_SendMsg.Location = new System.Drawing.Point(24, 286);
            this.tbx_SendMsg.Multiline = true;
            this.tbx_SendMsg.Name = "tbx_SendMsg";
            this.tbx_SendMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_SendMsg.Size = new System.Drawing.Size(234, 57);
            this.tbx_SendMsg.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "消息：";
            // 
            // tbx_Msg
            // 
            this.tbx_Msg.Location = new System.Drawing.Point(24, 50);
            this.tbx_Msg.Multiline = true;
            this.tbx_Msg.Name = "tbx_Msg";
            this.tbx_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Msg.Size = new System.Drawing.Size(309, 204);
            this.tbx_Msg.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lb_StationName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbx_Station);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 59);
            this.panel1.TabIndex = 6;
            // 
            // lb_StationName
            // 
            this.lb_StationName.AutoSize = true;
            this.lb_StationName.Location = new System.Drawing.Point(317, 23);
            this.lb_StationName.Name = "lb_StationName";
            this.lb_StationName.Size = new System.Drawing.Size(47, 12);
            this.lb_StationName.TabIndex = 15;
            this.lb_StationName.Text = "军分区A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(246, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "本级名称：";
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.Location = new System.Drawing.Point(488, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(69, 59);
            this.btn_Close.TabIndex = 13;
            this.btn_Close.Text = "关闭";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(557, 370);
            this.panel2.TabIndex = 7;
            // 
            // CommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 429);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CommandForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CommandForm";
            this.Load += new System.EventHandler(this.CommandForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_Station;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SendCommand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_PatrolRoute;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_PatrolTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_Description;
        private System.Windows.Forms.Button btn_SendMsg;
        private System.Windows.Forms.TextBox tbx_SendMsg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_Msg;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lb_StationName;
    }
}