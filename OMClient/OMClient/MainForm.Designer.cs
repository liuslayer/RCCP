namespace OMClient
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.panelEx_Menu = new DevComponents.DotNetBar.PanelEx();
            this.buttonX_Min = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Log = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_ManagementServer = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Statistics = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Map = new DevComponents.DotNetBar.ButtonX();
            this.panelEx_Base = new DevComponents.DotNetBar.PanelEx();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.buttonX_Setting = new DevComponents.DotNetBar.ButtonX();
            this.panelEx_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx_Menu
            // 
            this.panelEx_Menu.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Menu.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Menu.Controls.Add(this.buttonX_Setting);
            this.panelEx_Menu.Controls.Add(this.buttonX_Min);
            this.panelEx_Menu.Controls.Add(this.buttonX_Close);
            this.panelEx_Menu.Controls.Add(this.buttonX_Log);
            this.panelEx_Menu.Controls.Add(this.buttonX_ManagementServer);
            this.panelEx_Menu.Controls.Add(this.buttonX_Statistics);
            this.panelEx_Menu.Controls.Add(this.buttonX_Map);
            this.panelEx_Menu.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_Menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx_Menu.Location = new System.Drawing.Point(0, 0);
            this.panelEx_Menu.Name = "panelEx_Menu";
            this.panelEx_Menu.Size = new System.Drawing.Size(984, 50);
            this.panelEx_Menu.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Menu.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_Menu.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_Menu.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Menu.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Menu.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Menu.Style.GradientAngle = 90;
            this.panelEx_Menu.TabIndex = 5;
            // 
            // buttonX_Min
            // 
            this.buttonX_Min.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Min.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Min.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonX_Min.Font = new System.Drawing.Font("Cambria", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX_Min.Location = new System.Drawing.Point(880, 0);
            this.buttonX_Min.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonX_Min.Name = "buttonX_Min";
            this.buttonX_Min.Size = new System.Drawing.Size(52, 50);
            this.buttonX_Min.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Min.TabIndex = 22;
            this.buttonX_Min.Text = "-";
            this.buttonX_Min.Click += new System.EventHandler(this.buttonX_Min_Click);
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonX_Close.Font = new System.Drawing.Font("Cambria", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX_Close.Location = new System.Drawing.Point(932, 0);
            this.buttonX_Close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(52, 50);
            this.buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Close.TabIndex = 21;
            this.buttonX_Close.Text = "X";
            this.buttonX_Close.Click += new System.EventHandler(this.buttonX_Close_Click);
            // 
            // buttonX_Log
            // 
            this.buttonX_Log.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Log.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX_Log.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX_Log.Location = new System.Drawing.Point(620, 0);
            this.buttonX_Log.Name = "buttonX_Log";
            this.buttonX_Log.Size = new System.Drawing.Size(90, 50);
            this.buttonX_Log.TabIndex = 20;
            this.buttonX_Log.Text = "日 志";
            this.buttonX_Log.Click += new System.EventHandler(this.buttonX_Log_Click);
            // 
            // buttonX_ManagementServer
            // 
            this.buttonX_ManagementServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_ManagementServer.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX_ManagementServer.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX_ManagementServer.Location = new System.Drawing.Point(530, 0);
            this.buttonX_ManagementServer.Name = "buttonX_ManagementServer";
            this.buttonX_ManagementServer.Size = new System.Drawing.Size(90, 50);
            this.buttonX_ManagementServer.TabIndex = 19;
            this.buttonX_ManagementServer.Text = "服 务";
            this.buttonX_ManagementServer.Click += new System.EventHandler(this.buttonX_ManagementServer_Click);
            // 
            // buttonX_Statistics
            // 
            this.buttonX_Statistics.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Statistics.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX_Statistics.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX_Statistics.Location = new System.Drawing.Point(440, 0);
            this.buttonX_Statistics.Name = "buttonX_Statistics";
            this.buttonX_Statistics.Size = new System.Drawing.Size(90, 50);
            this.buttonX_Statistics.TabIndex = 17;
            this.buttonX_Statistics.Text = "统 计";
            this.buttonX_Statistics.Click += new System.EventHandler(this.buttonX_Statistics_Click);
            // 
            // buttonX_Map
            // 
            this.buttonX_Map.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Map.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX_Map.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX_Map.Location = new System.Drawing.Point(350, 0);
            this.buttonX_Map.Name = "buttonX_Map";
            this.buttonX_Map.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor();
            this.buttonX_Map.Size = new System.Drawing.Size(90, 50);
            this.buttonX_Map.TabIndex = 16;
            this.buttonX_Map.Text = "地 图";
            this.buttonX_Map.Click += new System.EventHandler(this.buttonX_Map_Click);
            // 
            // panelEx_Base
            // 
            this.panelEx_Base.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Base.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Base.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_Base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_Base.Location = new System.Drawing.Point(0, 50);
            this.panelEx_Base.Name = "panelEx_Base";
            this.panelEx_Base.Size = new System.Drawing.Size(984, 512);
            this.panelEx_Base.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Base.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_Base.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_Base.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Base.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Base.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Base.Style.GradientAngle = 90;
            this.panelEx_Base.TabIndex = 9;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Black;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242))))), System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204))))));
            // 
            // buttonX_Setting
            // 
            this.buttonX_Setting.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Setting.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX_Setting.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX_Setting.Location = new System.Drawing.Point(710, 0);
            this.buttonX_Setting.Name = "buttonX_Setting";
            this.buttonX_Setting.Size = new System.Drawing.Size(90, 50);
            this.buttonX_Setting.TabIndex = 23;
            this.buttonX_Setting.Text = "设 置";
            this.buttonX_Setting.Click += new System.EventHandler(this.buttonX_Setting_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.panelEx_Base);
            this.Controls.Add(this.panelEx_Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelEx_Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx_Menu;
        private DevComponents.DotNetBar.PanelEx panelEx_Base;
        private DevComponents.DotNetBar.ButtonX buttonX_Map;
        private DevComponents.DotNetBar.ButtonX buttonX_Statistics;
        private DevComponents.DotNetBar.ButtonX buttonX_ManagementServer;
        private DevComponents.DotNetBar.ButtonX buttonX_Log;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonX buttonX_Min;
        private DevComponents.DotNetBar.ButtonX buttonX_Close;
        private DevComponents.DotNetBar.ButtonX buttonX_Setting;
    }
}