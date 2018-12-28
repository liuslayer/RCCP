namespace OMClient
{
    partial class StatisticsForm
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
            this.panelEx_Statistics = new DevComponents.DotNetBar.PanelEx();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx_Left = new DevComponents.DotNetBar.PanelEx();
            this.panelEx_LeftBottom = new DevComponents.DotNetBar.PanelEx();
            this.panelEx_LeftTop = new DevComponents.DotNetBar.PanelEx();
            this.advTree_Station = new DevComponents.AdvTree.AdvTree();
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.panelEx_Right = new DevComponents.DotNetBar.PanelEx();
            this.tabControl_Statistics = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel_Current = new DevComponents.DotNetBar.TabControlPanel();
            this.statisticsUnitControl3 = new OMClient.StatisticsUnitControl();
            this.statisticsUnitControl2 = new OMClient.StatisticsUnitControl();
            this.statisticsUnitControl1 = new OMClient.StatisticsUnitControl();
            this.tabItem_current = new DevComponents.DotNetBar.TabItem(this.components);
            this.panelEx_Statistics.SuspendLayout();
            this.panelEx_Left.SuspendLayout();
            this.panelEx_LeftTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree_Station)).BeginInit();
            this.panelEx_Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl_Statistics)).BeginInit();
            this.tabControl_Statistics.SuspendLayout();
            this.tabControlPanel_Current.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx_Statistics
            // 
            this.panelEx_Statistics.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Statistics.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Statistics.Controls.Add(this.expandableSplitter1);
            this.panelEx_Statistics.Controls.Add(this.panelEx_Right);
            this.panelEx_Statistics.Controls.Add(this.panelEx_Left);
            this.panelEx_Statistics.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_Statistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_Statistics.Location = new System.Drawing.Point(0, 0);
            this.panelEx_Statistics.Name = "panelEx_Statistics";
            this.panelEx_Statistics.Size = new System.Drawing.Size(1920, 1030);
            this.panelEx_Statistics.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Statistics.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_Statistics.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_Statistics.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Statistics.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Statistics.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Statistics.Style.GradientAngle = 90;
            this.panelEx_Statistics.TabIndex = 49;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandableControl = this.panelEx_Left;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(200, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(10, 1030);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 5;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx_Left
            // 
            this.panelEx_Left.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Left.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Left.Controls.Add(this.panelEx_LeftBottom);
            this.panelEx_Left.Controls.Add(this.panelEx_LeftTop);
            this.panelEx_Left.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx_Left.Location = new System.Drawing.Point(0, 0);
            this.panelEx_Left.Name = "panelEx_Left";
            this.panelEx_Left.Size = new System.Drawing.Size(200, 1030);
            this.panelEx_Left.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Left.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_Left.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_Left.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Left.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Left.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Left.Style.GradientAngle = 90;
            this.panelEx_Left.TabIndex = 0;
            // 
            // panelEx_LeftBottom
            // 
            this.panelEx_LeftBottom.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_LeftBottom.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_LeftBottom.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_LeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx_LeftBottom.Location = new System.Drawing.Point(0, 830);
            this.panelEx_LeftBottom.Name = "panelEx_LeftBottom";
            this.panelEx_LeftBottom.Size = new System.Drawing.Size(200, 200);
            this.panelEx_LeftBottom.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_LeftBottom.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_LeftBottom.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_LeftBottom.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_LeftBottom.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_LeftBottom.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_LeftBottom.Style.GradientAngle = 90;
            this.panelEx_LeftBottom.TabIndex = 4;
            // 
            // panelEx_LeftTop
            // 
            this.panelEx_LeftTop.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_LeftTop.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_LeftTop.Controls.Add(this.advTree_Station);
            this.panelEx_LeftTop.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_LeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_LeftTop.Location = new System.Drawing.Point(0, 0);
            this.panelEx_LeftTop.Name = "panelEx_LeftTop";
            this.panelEx_LeftTop.Size = new System.Drawing.Size(200, 1030);
            this.panelEx_LeftTop.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_LeftTop.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_LeftTop.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_LeftTop.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_LeftTop.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_LeftTop.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_LeftTop.Style.GradientAngle = 90;
            this.panelEx_LeftTop.TabIndex = 0;
            // 
            // advTree_Station
            // 
            this.advTree_Station.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree_Station.AllowDrop = true;
            this.advTree_Station.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree_Station.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree_Station.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree_Station.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree_Station.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.advTree_Station.Location = new System.Drawing.Point(0, 0);
            this.advTree_Station.Name = "advTree_Station";
            this.advTree_Station.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.advTree_Station.NodesConnector = this.nodeConnector1;
            this.advTree_Station.NodeStyle = this.elementStyle3;
            this.advTree_Station.PathSeparator = ";";
            this.advTree_Station.Size = new System.Drawing.Size(200, 1030);
            this.advTree_Station.Styles.Add(this.elementStyle1);
            this.advTree_Station.Styles.Add(this.elementStyle2);
            this.advTree_Station.Styles.Add(this.elementStyle3);
            this.advTree_Station.TabIndex = 0;
            this.advTree_Station.Text = "advTree1";
            this.advTree_Station.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTree_Station_NodeClick);
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Text = "站点索引";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle3
            // 
            this.elementStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(232)))));
            this.elementStyle3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(170)))));
            this.elementStyle3.BackColorGradientAngle = 90;
            this.elementStyle3.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderBottomWidth = 1;
            this.elementStyle3.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle3.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderLeftWidth = 1;
            this.elementStyle3.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderRightWidth = 1;
            this.elementStyle3.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle3.BorderTopWidth = 1;
            this.elementStyle3.CornerDiameter = 4;
            this.elementStyle3.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle3.Description = "Silver";
            this.elementStyle3.Name = "elementStyle3";
            this.elementStyle3.PaddingBottom = 1;
            this.elementStyle3.PaddingLeft = 1;
            this.elementStyle3.PaddingRight = 1;
            this.elementStyle3.PaddingTop = 1;
            this.elementStyle3.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle2
            // 
            this.elementStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.elementStyle2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(224)))), ((int)(((byte)(252)))));
            this.elementStyle2.BackColorGradientAngle = 90;
            this.elementStyle2.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderBottomWidth = 1;
            this.elementStyle2.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle2.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderLeftWidth = 1;
            this.elementStyle2.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderRightWidth = 1;
            this.elementStyle2.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderTopWidth = 1;
            this.elementStyle2.CornerDiameter = 4;
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Description = "BlueLight";
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.PaddingBottom = 1;
            this.elementStyle2.PaddingLeft = 1;
            this.elementStyle2.PaddingRight = 1;
            this.elementStyle2.PaddingTop = 1;
            this.elementStyle2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(84)))), ((int)(((byte)(115)))));
            // 
            // panelEx_Right
            // 
            this.panelEx_Right.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx_Right.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx_Right.Controls.Add(this.tabControl_Statistics);
            this.panelEx_Right.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx_Right.Location = new System.Drawing.Point(200, 0);
            this.panelEx_Right.Name = "panelEx_Right";
            this.panelEx_Right.Size = new System.Drawing.Size(1720, 1030);
            this.panelEx_Right.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx_Right.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx_Right.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx_Right.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx_Right.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx_Right.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx_Right.Style.GradientAngle = 90;
            this.panelEx_Right.TabIndex = 4;
            // 
            // tabControl_Statistics
            // 
            this.tabControl_Statistics.BackColor = System.Drawing.Color.Transparent;
            this.tabControl_Statistics.CanReorderTabs = true;
            this.tabControl_Statistics.ColorScheme.TabBackground = System.Drawing.SystemColors.Control;
            this.tabControl_Statistics.ColorScheme.TabBackground2 = System.Drawing.SystemColors.ControlDarkDark;
            this.tabControl_Statistics.ColorScheme.TabItemBackground = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemBackground2 = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemBorder = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemBorderDark = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemBorderLight = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemHotBackground = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemHotBackground2 = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemHotBorder = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemHotBorderDark = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemHotBorderLight = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemHotText = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemSelectedBackground = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemSelectedBackground2 = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemSelectedBorder = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemSelectedBorderDark = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabItemSelectedBorderLight = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabPanelBackground = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabPanelBackground2 = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.ColorScheme.TabPanelBorder = System.Drawing.SystemColors.ControlDark;
            this.tabControl_Statistics.Controls.Add(this.tabControlPanel_Current);
            this.tabControl_Statistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Statistics.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Statistics.Name = "tabControl_Statistics";
            this.tabControl_Statistics.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl_Statistics.SelectedTabIndex = 0;
            this.tabControl_Statistics.Size = new System.Drawing.Size(1720, 1030);
            this.tabControl_Statistics.TabIndex = 0;
            this.tabControl_Statistics.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl_Statistics.Tabs.Add(this.tabItem_current);
            // 
            // tabControlPanel_Current
            // 
            this.tabControlPanel_Current.CanvasColor = System.Drawing.Color.Silver;
            this.tabControlPanel_Current.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.tabControlPanel_Current.Controls.Add(this.statisticsUnitControl3);
            this.tabControlPanel_Current.Controls.Add(this.statisticsUnitControl2);
            this.tabControlPanel_Current.Controls.Add(this.statisticsUnitControl1);
            this.tabControlPanel_Current.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel_Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel_Current.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel_Current.Name = "tabControlPanel_Current";
            this.tabControlPanel_Current.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel_Current.Size = new System.Drawing.Size(1720, 1004);
            this.tabControlPanel_Current.Style.BackColor1.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel_Current.Style.BackColor2.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel_Current.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel_Current.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel_Current.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel_Current.Style.GradientAngle = 90;
            this.tabControlPanel_Current.TabIndex = 1;
            this.tabControlPanel_Current.TabItem = this.tabItem_current;
            // 
            // statisticsUnitControl3
            // 
            this.statisticsUnitControl3.BackColor = System.Drawing.Color.Transparent;
            this.statisticsUnitControl3.Location = new System.Drawing.Point(1159, 63);
            this.statisticsUnitControl3.Name = "statisticsUnitControl3";
            this.statisticsUnitControl3.Size = new System.Drawing.Size(400, 400);
            this.statisticsUnitControl3.TabIndex = 8;
            // 
            // statisticsUnitControl2
            // 
            this.statisticsUnitControl2.BackColor = System.Drawing.Color.Transparent;
            this.statisticsUnitControl2.Location = new System.Drawing.Point(613, 63);
            this.statisticsUnitControl2.Name = "statisticsUnitControl2";
            this.statisticsUnitControl2.Size = new System.Drawing.Size(400, 400);
            this.statisticsUnitControl2.TabIndex = 7;
            // 
            // statisticsUnitControl1
            // 
            this.statisticsUnitControl1.BackColor = System.Drawing.Color.Transparent;
            this.statisticsUnitControl1.Location = new System.Drawing.Point(82, 63);
            this.statisticsUnitControl1.Name = "statisticsUnitControl1";
            this.statisticsUnitControl1.Size = new System.Drawing.Size(400, 400);
            this.statisticsUnitControl1.TabIndex = 6;
            // 
            // tabItem_current
            // 
            this.tabItem_current.AttachedControl = this.tabControlPanel_Current;
            this.tabItem_current.Name = "tabItem_current";
            this.tabItem_current.Text = "实时统计";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1030);
            this.Controls.Add(this.panelEx_Statistics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatisticsForm";
            this.Text = "StatisticsForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.panelEx_Statistics.ResumeLayout(false);
            this.panelEx_Left.ResumeLayout(false);
            this.panelEx_LeftTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree_Station)).EndInit();
            this.panelEx_Right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl_Statistics)).EndInit();
            this.tabControl_Statistics.ResumeLayout(false);
            this.tabControlPanel_Current.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx_Statistics;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.PanelEx panelEx_Left;
        private DevComponents.DotNetBar.PanelEx panelEx_LeftBottom;
        private DevComponents.DotNetBar.PanelEx panelEx_LeftTop;
        private DevComponents.AdvTree.AdvTree advTree_Station;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.PanelEx panelEx_Right;
        private DevComponents.DotNetBar.TabControl tabControl_Statistics;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel_Current;
        private DevComponents.DotNetBar.TabItem tabItem_current;
        private StatisticsUnitControl statisticsUnitControl1;
        private StatisticsUnitControl statisticsUnitControl3;
        private StatisticsUnitControl statisticsUnitControl2;
        private DevComponents.DotNetBar.ElementStyle elementStyle3;
    }
}