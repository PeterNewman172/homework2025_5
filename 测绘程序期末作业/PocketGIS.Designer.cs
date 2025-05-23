namespace 测绘程序期末作业
{
    partial class PocketGIS
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PocketGIS));
            toolStrip1 = new ToolStrip();
            选中 = new ToolStripLabel();
            tsbSelect = new ToolStripButton();
            点 = new ToolStripLabel();
            tsbPoint = new ToolStripButton();
            直线 = new ToolStripLabel();
            tsbLine = new ToolStripButton();
            drawingPanel = new Panel();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            文件ToolStripMenuItem = new ToolStripMenuItem();
            打开ToolStripMenuItem = new ToolStripMenuItem();
            新建ToolStripMenuItem = new ToolStripMenuItem();
            保存ToolStripMenuItem = new ToolStripMenuItem();
            推出ToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            layerToolStripMenuItem = new ToolStripMenuItem();
            currentLayerToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            layer1ToolStripMenuItem = new ToolStripMenuItem();
            layer2ToolStripMenuItem = new ToolStripMenuItem();
            layer3ToolStripMenuItem = new ToolStripMenuItem();
            menuMain = new MenuStrip();
            visibilityToolStripMenuItem = new ToolStripMenuItem();
            layerVisible1 = new ToolStripMenuItem();
            layerVisible2 = new ToolStripMenuItem();
            layerVisible3 = new ToolStripMenuItem();
            openCsvDialog1 = new OpenFileDialog();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuMain.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Left;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { 选中, tsbSelect, 点, tsbPoint, 直线, tsbLine });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(40, 422);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.Click += toolButton_Click;
            // 
            // 选中
            // 
            选中.Name = "选中";
            选中.Size = new Size(37, 20);
            选中.Text = "选择";
            // 
            // tsbSelect
            // 
            tsbSelect.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSelect.Image = (Image)resources.GetObject("tsbSelect.Image");
            tsbSelect.ImageTransparentColor = Color.Magenta;
            tsbSelect.Name = "tsbSelect";
            tsbSelect.Size = new Size(37, 24);
            tsbSelect.Tag = ToolType.Select;
            tsbSelect.Text = "toolStripButton3";
            tsbSelect.Click += toolButton_Click;
            // 
            // 点
            // 
            点.Name = "点";
            点.Size = new Size(37, 20);
            点.Text = "点";
            // 
            // tsbPoint
            // 
            tsbPoint.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbPoint.Image = (Image)resources.GetObject("tsbPoint.Image");
            tsbPoint.ImageTransparentColor = Color.Magenta;
            tsbPoint.Name = "tsbPoint";
            tsbPoint.Size = new Size(37, 24);
            tsbPoint.Tag = ToolType.Point;
            tsbPoint.Text = "toolStripButton1";
            tsbPoint.Click += toolButton_Click;
            // 
            // 直线
            // 
            直线.Name = "直线";
            直线.Size = new Size(37, 20);
            直线.Text = "直线";
            // 
            // tsbLine
            // 
            tsbLine.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbLine.Image = (Image)resources.GetObject("tsbLine.Image");
            tsbLine.ImageTransparentColor = Color.Magenta;
            tsbLine.Name = "tsbLine";
            tsbLine.Size = new Size(37, 24);
            tsbLine.Tag = ToolType.Line;
            tsbLine.Text = "toolStripButton2";
            tsbLine.Click += toolButton_Click;
            // 
            // drawingPanel
            // 
            drawingPanel.AutoScroll = true;
            drawingPanel.Dock = DockStyle.Fill;
            drawingPanel.Location = new Point(40, 28);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(760, 422);
            drawingPanel.TabIndex = 2;
            drawingPanel.Paint += drawingPanel_Paint;
            drawingPanel.MouseDown += DrawingPanel_MouseDown;
            drawingPanel.MouseMove += DrawingPanel_MouseMove;
            drawingPanel.MouseUp += DrawingPanel_MouseUp;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(40, 424);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(760, 26);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(69, 20);
            toolStripStatusLabel1.Text = "工具状态";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(39, 20);
            toolStripStatusLabel2.Text = "坐标";
            // 
            // 文件ToolStripMenuItem
            // 
            文件ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 打开ToolStripMenuItem, 新建ToolStripMenuItem, 保存ToolStripMenuItem, 推出ToolStripMenuItem });
            文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            文件ToolStripMenuItem.Size = new Size(55, 24);
            文件ToolStripMenuItem.Text = "Files";
            // 
            // 打开ToolStripMenuItem
            // 
            打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            打开ToolStripMenuItem.Size = new Size(224, 26);
            打开ToolStripMenuItem.Text = "打开";
            打开ToolStripMenuItem.Click += menuOpen_Click;
            // 
            // 新建ToolStripMenuItem
            // 
            新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            新建ToolStripMenuItem.Size = new Size(224, 26);
            新建ToolStripMenuItem.Text = "新建";
            新建ToolStripMenuItem.Click += menuNew_Click;
            // 
            // 保存ToolStripMenuItem
            // 
            保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            保存ToolStripMenuItem.Size = new Size(224, 26);
            保存ToolStripMenuItem.Text = "保存为...";
            保存ToolStripMenuItem.Click += menuSave_Click;
            // 
            // 推出ToolStripMenuItem
            // 
            推出ToolStripMenuItem.Name = "推出ToolStripMenuItem";
            推出ToolStripMenuItem.Size = new Size(224, 26);
            推出ToolStripMenuItem.Text = "退出";
            推出ToolStripMenuItem.Click += menuExit_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(51, 24);
            editToolStripMenuItem.Text = "Edit";
            // 
            // layerToolStripMenuItem
            // 
            layerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { currentLayerToolStripMenuItem, toolStripSeparator2, layer1ToolStripMenuItem, layer2ToolStripMenuItem, layer3ToolStripMenuItem });
            layerToolStripMenuItem.Name = "layerToolStripMenuItem";
            layerToolStripMenuItem.Size = new Size(62, 24);
            layerToolStripMenuItem.Text = "Layer";
            layerToolStripMenuItem.Click += LayerMenuItem_Click;
            // 
            // currentLayerToolStripMenuItem
            // 
            currentLayerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator1 });
            currentLayerToolStripMenuItem.Enabled = false;
            currentLayerToolStripMenuItem.Name = "currentLayerToolStripMenuItem";
            currentLayerToolStripMenuItem.Size = new Size(219, 26);
            currentLayerToolStripMenuItem.Text = "当前图层：Layer 1";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(71, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(216, 6);
            // 
            // layer1ToolStripMenuItem
            // 
            layer1ToolStripMenuItem.Checked = true;
            layer1ToolStripMenuItem.CheckOnClick = true;
            layer1ToolStripMenuItem.CheckState = CheckState.Checked;
            layer1ToolStripMenuItem.Name = "layer1ToolStripMenuItem";
            layer1ToolStripMenuItem.Size = new Size(219, 26);
            layer1ToolStripMenuItem.Tag = 0;
            layer1ToolStripMenuItem.Text = "Layer 1";
            layer1ToolStripMenuItem.Click += LayerMenuItem_Click;
            // 
            // layer2ToolStripMenuItem
            // 
            layer2ToolStripMenuItem.CheckOnClick = true;
            layer2ToolStripMenuItem.Name = "layer2ToolStripMenuItem";
            layer2ToolStripMenuItem.Size = new Size(219, 26);
            layer2ToolStripMenuItem.Tag = 1;
            layer2ToolStripMenuItem.Text = "Layer 2";
            layer2ToolStripMenuItem.Click += LayerMenuItem_Click;
            // 
            // layer3ToolStripMenuItem
            // 
            layer3ToolStripMenuItem.CheckOnClick = true;
            layer3ToolStripMenuItem.Name = "layer3ToolStripMenuItem";
            layer3ToolStripMenuItem.Size = new Size(219, 26);
            layer3ToolStripMenuItem.Tag = 2;
            layer3ToolStripMenuItem.Text = "Layer 3";
            layer3ToolStripMenuItem.Click += LayerMenuItem_Click;
            // 
            // menuMain
            // 
            menuMain.ImageScalingSize = new Size(20, 20);
            menuMain.Items.AddRange(new ToolStripItem[] { 文件ToolStripMenuItem, editToolStripMenuItem, layerToolStripMenuItem, visibilityToolStripMenuItem });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(800, 28);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuStrip1";
            // 
            // visibilityToolStripMenuItem
            // 
            visibilityToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { layerVisible1, layerVisible2, layerVisible3 });
            visibilityToolStripMenuItem.Name = "visibilityToolStripMenuItem";
            visibilityToolStripMenuItem.Size = new Size(68, 24);
            visibilityToolStripMenuItem.Text = "可视性";
            visibilityToolStripMenuItem.Click += 可视性ToolStripMenuItem_Click;
            // 
            // layerVisible1
            // 
            layerVisible1.Checked = true;
            layerVisible1.CheckOnClick = true;
            layerVisible1.CheckState = CheckState.Checked;
            layerVisible1.Name = "layerVisible1";
            layerVisible1.Size = new Size(131, 26);
            layerVisible1.Text = "图层1";
            layerVisible1.Click += layerVisible1_Click;
            // 
            // layerVisible2
            // 
            layerVisible2.Checked = true;
            layerVisible2.CheckOnClick = true;
            layerVisible2.CheckState = CheckState.Checked;
            layerVisible2.Name = "layerVisible2";
            layerVisible2.Size = new Size(131, 26);
            layerVisible2.Text = "图层2";
            layerVisible2.Click += layerVisible2_Click;
            // 
            // layerVisible3
            // 
            layerVisible3.Checked = true;
            layerVisible3.CheckOnClick = true;
            layerVisible3.CheckState = CheckState.Checked;
            layerVisible3.Name = "layerVisible3";
            layerVisible3.Size = new Size(131, 26);
            layerVisible3.Text = "图层3";
            layerVisible3.Click += layerVisible3_Click;
            // 
            // openCsvDialog1
            // 
            openCsvDialog1.FileName = "openFileDialog1";
            openCsvDialog1.Filter = "全站仪CSV数据|*.csv";
            // 
            // PocketGIS
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(drawingPanel);
            Controls.Add(toolStrip1);
            Controls.Add(menuMain);
            Name = "PocketGIS";
            Text = "PocketGIS";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripLabel 点;
        private ToolStripButton tsbPoint;
        private ToolStripLabel 直线;
        private ToolStripButton tsbLine;
        private Panel drawingPanel;
        private StatusStrip statusStrip1;
        private ToolStripLabel 选中;
        private ToolStripButton tsbSelect;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem 打开ToolStripMenuItem;
        private ToolStripMenuItem 新建ToolStripMenuItem;
        private ToolStripMenuItem 保存ToolStripMenuItem;
        private ToolStripMenuItem 推出ToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem layerToolStripMenuItem;
        private MenuStrip menuMain;
        private ToolStripMenuItem currentLayerToolStripMenuItem;
        private ToolStripMenuItem layer1ToolStripMenuItem;
        private ToolStripMenuItem layer2ToolStripMenuItem;
        private ToolStripMenuItem layer3ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem visibilityToolStripMenuItem;
        private ToolStripMenuItem layerVisible1;
        private ToolStripMenuItem layerVisible2;
        private ToolStripMenuItem layerVisible3;
        private OpenFileDialog openCsvDialog1;
    }
}
