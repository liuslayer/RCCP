namespace OMClient
{
    partial class Form1
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
            this.myPageControl1 = new MyControls.MyPageControl();
            this.SuspendLayout();
            // 
            // myPageControl1
            // 
            this.myPageControl1.BackColor = System.Drawing.SystemColors.Control;
            this.myPageControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.myPageControl1.Location = new System.Drawing.Point(0, 470);
            this.myPageControl1.Name = "myPageControl1";
            this.myPageControl1.PageIndex = 1;
            this.myPageControl1.PageRecordCount = 0;
            this.myPageControl1.PageRecordNumber = 10;
            this.myPageControl1.Size = new System.Drawing.Size(1038, 31);
            this.myPageControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 501);
            this.Controls.Add(this.myPageControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MyControls.MyPageControl myPageControl1;
    }
}