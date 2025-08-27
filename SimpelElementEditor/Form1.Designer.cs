namespace SimpelElementEditor
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerSearch = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.propertyGridPath = new System.Windows.Forms.PropertyGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.propertyGrid3 = new System.Windows.Forms.PropertyGrid();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.propertyGridaiPolicy = new System.Windows.Forms.PropertyGrid();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.propertyGridgShop = new System.Windows.Forms.PropertyGrid();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.propertyGridExtraDrops = new System.Windows.Forms.PropertyGrid();
            this.tabPageMapData = new System.Windows.Forms.TabPage();
            this.propertyGridMapData = new System.Windows.Forms.PropertyGrid();
            this.propertyGridElements = new ColoredPropertyGrid();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.propertyGridMaster = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPageMapData.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.propertyGridElements);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1178, 500);
            this.splitContainer1.SplitterDistance = 927;
            this.splitContainer1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 500);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1192, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // timerSearch
            // 
            this.timerSearch.Interval = 150;
            this.timerSearch.Tick += new System.EventHandler(this.timerSearch_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPageMapData);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1192, 532);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1184, 506);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Elements";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.propertyGridPath);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1184, 506);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Path";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // propertyGridPath
            // 
            this.propertyGridPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridPath.Location = new System.Drawing.Point(3, 3);
            this.propertyGridPath.Name = "propertyGridPath";
            this.propertyGridPath.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridPath.Size = new System.Drawing.Size(1178, 500);
            this.propertyGridPath.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.propertyGrid3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1184, 506);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SkillStr";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // propertyGrid3
            // 
            this.propertyGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid3.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid3.Name = "propertyGrid3";
            this.propertyGrid3.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGrid3.Size = new System.Drawing.Size(1178, 500);
            this.propertyGrid3.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.propertyGridaiPolicy);
            this.tabPage4.Controls.Add(this.listBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1184, 506);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "aiPolicy";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // propertyGridaiPolicy
            // 
            this.propertyGridaiPolicy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridaiPolicy.Location = new System.Drawing.Point(0, 0);
            this.propertyGridaiPolicy.Name = "propertyGridaiPolicy";
            this.propertyGridaiPolicy.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridaiPolicy.Size = new System.Drawing.Size(1064, 506);
            this.propertyGridaiPolicy.TabIndex = 0;
            this.propertyGridaiPolicy.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.propertyGridaiPolicy_SelectedGridItemChanged);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(1064, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 506);
            this.listBox1.TabIndex = 4;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.propertyGridgShop);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1184, 506);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "gShop";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // propertyGridgShop
            // 
            this.propertyGridgShop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridgShop.Location = new System.Drawing.Point(3, 3);
            this.propertyGridgShop.Name = "propertyGridgShop";
            this.propertyGridgShop.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridgShop.Size = new System.Drawing.Size(1178, 500);
            this.propertyGridgShop.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.propertyGridExtraDrops);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1184, 506);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Extra Drops";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // propertyGridExtraDrops
            // 
            this.propertyGridExtraDrops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridExtraDrops.Location = new System.Drawing.Point(0, 0);
            this.propertyGridExtraDrops.Name = "propertyGridExtraDrops";
            this.propertyGridExtraDrops.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridExtraDrops.Size = new System.Drawing.Size(1184, 506);
            this.propertyGridExtraDrops.TabIndex = 0;
            // 
            // tabPageMapData
            // 
            this.tabPageMapData.Controls.Add(this.propertyGridMapData);
            this.tabPageMapData.Location = new System.Drawing.Point(4, 22);
            this.tabPageMapData.Name = "tabPageMapData";
            this.tabPageMapData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMapData.Size = new System.Drawing.Size(1184, 506);
            this.tabPageMapData.TabIndex = 6;
            this.tabPageMapData.Text = "Map Data";
            this.tabPageMapData.UseVisualStyleBackColor = true;
            // 
            // propertyGridMapData
            // 
            this.propertyGridMapData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridMapData.Location = new System.Drawing.Point(3, 3);
            this.propertyGridMapData.Name = "propertyGridMapData";
            this.propertyGridMapData.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridMapData.Size = new System.Drawing.Size(1178, 500);
            this.propertyGridMapData.TabIndex = 0;
            // 
            // propertyGridElements
            // 
            this.propertyGridElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridElements.Location = new System.Drawing.Point(0, 0);
            this.propertyGridElements.Name = "propertyGridElements";
            this.propertyGridElements.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridElements.Size = new System.Drawing.Size(927, 500);
            this.propertyGridElements.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.propertyGridMaster);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1184, 506);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Text = "Master Tree";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // propertyGridMaster
            // 
            this.propertyGridMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridMaster.Location = new System.Drawing.Point(0, 0);
            this.propertyGridMaster.Name = "propertyGridMaster";
            this.propertyGridMaster.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridMaster.Size = new System.Drawing.Size(1184, 506);
            this.propertyGridMaster.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 556);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPageMapData.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColoredPropertyGrid propertyGridElements;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Timer timerSearch;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PropertyGrid propertyGridPath;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PropertyGrid propertyGrid3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PropertyGrid propertyGridaiPolicy;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.PropertyGrid propertyGridgShop;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.PropertyGrid propertyGridExtraDrops;
        private System.Windows.Forms.TabPage tabPageMapData;
        private System.Windows.Forms.PropertyGrid propertyGridMapData;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.PropertyGrid propertyGridMaster;
    }
}

