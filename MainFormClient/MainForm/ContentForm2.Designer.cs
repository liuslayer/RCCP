namespace Project2
{
    partial class ContentForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentForm2));
            this.userControl14 = new MyButton.UserControl1();
            this.label4 = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userControl14
            // 
            this.userControl14.BackColor = System.Drawing.Color.Transparent;
            this.userControl14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("userControl14.BackgroundImage")));
            this.userControl14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userControl14.BaseColor = System.Drawing.Color.Transparent;
            this.userControl14.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
            this.userControl14.ButtonText = null;
            this.userControl14.CornerRadius = 0;
            this.userControl14.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(217)))), ((int)(((byte)(255)))));
            this.userControl14.Location = new System.Drawing.Point(323, 147);
            this.userControl14.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.userControl14.Name = "userControl14";
            this.userControl14.Size = new System.Drawing.Size(90, 90);
            this.userControl14.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(332, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 28);
            this.label4.TabIndex = 16;
            this.label4.Text = "MESH";
            // 
            // back
            // 
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Location = new System.Drawing.Point(25, 28);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 19;
            this.back.Text = "<<后退";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // ContentForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 465);
            this.Controls.Add(this.back);
            this.Controls.Add(this.userControl14);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ContentForm2";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyButton.UserControl1 userControl14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button back;
    }
}