namespace IntegratedManagement
{
    partial class StationForm
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
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX_PostStaion = new DevComponents.DotNetBar.ButtonX();
            this.dataGridView_StationInfo = new System.Windows.Forms.DataGridView();
            this.StationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_StationInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.buttonX_PostStaion);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(1000, 55);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 8;
            // 
            // buttonX_PostStaion
            // 
            this.buttonX_PostStaion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_PostStaion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_PostStaion.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonX_PostStaion.Location = new System.Drawing.Point(895, 0);
            this.buttonX_PostStaion.Name = "buttonX_PostStaion";
            this.buttonX_PostStaion.Size = new System.Drawing.Size(105, 55);
            this.buttonX_PostStaion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_PostStaion.TabIndex = 19;
            this.buttonX_PostStaion.Text = "上传监控信息";
            this.buttonX_PostStaion.Click += new System.EventHandler(this.buttonX_PostStaion_Click);
            // 
            // dataGridView_StationInfo
            // 
            this.dataGridView_StationInfo.AllowUserToAddRows = false;
            this.dataGridView_StationInfo.AllowUserToDeleteRows = false;
            this.dataGridView_StationInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_StationInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_StationInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StationID,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column13,
            this.Column18});
            this.dataGridView_StationInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_StationInfo.Location = new System.Drawing.Point(0, 55);
            this.dataGridView_StationInfo.Name = "dataGridView_StationInfo";
            this.dataGridView_StationInfo.ReadOnly = true;
            this.dataGridView_StationInfo.RowTemplate.Height = 23;
            this.dataGridView_StationInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_StationInfo.Size = new System.Drawing.Size(1000, 495);
            this.dataGridView_StationInfo.TabIndex = 9;
            // 
            // StationID
            // 
            this.StationID.DataPropertyName = "StationID";
            this.StationID.HeaderText = "StationID";
            this.StationID.Name = "StationID";
            this.StationID.ReadOnly = true;
            this.StationID.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "监控站名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Lon";
            this.Column2.HeaderText = "经度";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Lat";
            this.Column3.HeaderText = "纬度";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "Description";
            this.Column13.HeaderText = "描述";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "Mark";
            this.Column18.HeaderText = "Mark";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Visible = false;
            // 
            // StationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.dataGridView_StationInfo);
            this.Controls.Add(this.panelEx3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StationForm";
            this.Text = "StationForm";
            this.Load += new System.EventHandler(this.StationForm_Load);
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_StationInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ButtonX buttonX_PostStaion;
        private System.Windows.Forms.DataGridView dataGridView_StationInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
    }
}