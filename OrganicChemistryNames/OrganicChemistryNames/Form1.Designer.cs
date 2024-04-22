
namespace OrganicChemistryNames
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NameRTB = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.elementFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.includeOxygenCB = new System.Windows.Forms.CheckBox();
            this.carbonCountNud = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.bondChanceNud = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.subChanceNud = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.includeBondsCB = new System.Windows.Forms.CheckBox();
            this.includeCarbonCB = new System.Windows.Forms.CheckBox();
            this.includeHalogensCB = new System.Windows.Forms.CheckBox();
            this.startYNud = new System.Windows.Forms.NumericUpDown();
            this.startY = new System.Windows.Forms.Label();
            this.startXNud = new System.Windows.Forms.NumericUpDown();
            this.startX = new System.Windows.Forms.Label();
            this.maxSubNud = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.minSubNud = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.maxLCCNud = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.minLCCNud = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.indexCB = new OrganicChemistryNames.ColorButton();
            this.gridCB = new OrganicChemistryNames.ColorButton();
            this.emptyCB = new OrganicChemistryNames.ColorButton();
            this.mainPicturePanel = new System.Windows.Forms.Panel();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.guaranteeCAcidCB = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carbonCountNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bondChanceNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subChanceNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startYNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startXNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSubNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSubNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxLCCNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minLCCNud)).BeginInit();
            this.mainPicturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.NameRTB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainPicturePanel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 595);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // NameRTB
            // 
            this.NameRTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameRTB.Location = new System.Drawing.Point(153, 448);
            this.NameRTB.Name = "NameRTB";
            this.NameRTB.Size = new System.Drawing.Size(795, 122);
            this.NameRTB.TabIndex = 2;
            this.NameRTB.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tableLayoutPanel1.SetRowSpan(this.tabControl1, 2);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(144, 589);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.elementFLP);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(136, 465);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "prvky";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // elementFLP
            // 
            this.elementFLP.AutoSize = true;
            this.elementFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.elementFLP.Location = new System.Drawing.Point(0, 0);
            this.elementFLP.Name = "elementFLP";
            this.elementFLP.Size = new System.Drawing.Size(136, 404);
            this.elementFLP.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.indexCB);
            this.tabPage2.Controls.Add(this.gridCB);
            this.tabPage2.Controls.Add(this.emptyCB);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(136, 563);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "nastav.";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.guaranteeCAcidCB);
            this.groupBox1.Controls.Add(this.includeOxygenCB);
            this.groupBox1.Controls.Add(this.carbonCountNud);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.bondChanceNud);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.subChanceNud);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.includeBondsCB);
            this.groupBox1.Controls.Add(this.includeCarbonCB);
            this.groupBox1.Controls.Add(this.includeHalogensCB);
            this.groupBox1.Controls.Add(this.startYNud);
            this.groupBox1.Controls.Add(this.startY);
            this.groupBox1.Controls.Add(this.startXNud);
            this.groupBox1.Controls.Add(this.startX);
            this.groupBox1.Controls.Add(this.maxSubNud);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.minSubNud);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.maxLCCNud);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.minLCCNud);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 441);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "practice settings";
            // 
            // includeOxygenCB
            // 
            this.includeOxygenCB.AutoSize = true;
            this.includeOxygenCB.Checked = true;
            this.includeOxygenCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeOxygenCB.Location = new System.Drawing.Point(3, 297);
            this.includeOxygenCB.Name = "includeOxygenCB";
            this.includeOxygenCB.Size = new System.Drawing.Size(96, 17);
            this.includeOxygenCB.TabIndex = 21;
            this.includeOxygenCB.Text = "includeOxygen";
            this.includeOxygenCB.UseVisualStyleBackColor = true;
            // 
            // carbonCountNud
            // 
            this.carbonCountNud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.carbonCountNud.Location = new System.Drawing.Point(55, 218);
            this.carbonCountNud.Name = "carbonCountNud";
            this.carbonCountNud.Size = new System.Drawing.Size(75, 20);
            this.carbonCountNud.TabIndex = 20;
            this.toolTip1.SetToolTip(this.carbonCountNud, "How likely it is for carbon being attached vs other subs");
            this.carbonCountNud.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "c count";
            // 
            // bondChanceNud
            // 
            this.bondChanceNud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.bondChanceNud.Location = new System.Drawing.Point(55, 193);
            this.bondChanceNud.Name = "bondChanceNud";
            this.bondChanceNud.Size = new System.Drawing.Size(75, 20);
            this.bondChanceNud.TabIndex = 18;
            this.toolTip1.SetToolTip(this.bondChanceNud, "Chance of bond turning into double / triple bond");
            this.bondChanceNud.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "bond ch.";
            // 
            // subChanceNud
            // 
            this.subChanceNud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.subChanceNud.Location = new System.Drawing.Point(55, 168);
            this.subChanceNud.Name = "subChanceNud";
            this.subChanceNud.Size = new System.Drawing.Size(75, 20);
            this.subChanceNud.TabIndex = 16;
            this.toolTip1.SetToolTip(this.subChanceNud, "chance of sub chain being attached");
            this.subChanceNud.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "sub ch.";
            // 
            // includeBondsCB
            // 
            this.includeBondsCB.AutoSize = true;
            this.includeBondsCB.Checked = true;
            this.includeBondsCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeBondsCB.Location = new System.Drawing.Point(3, 343);
            this.includeBondsCB.Name = "includeBondsCB";
            this.includeBondsCB.Size = new System.Drawing.Size(90, 17);
            this.includeBondsCB.TabIndex = 14;
            this.includeBondsCB.Text = "includeBonds";
            this.includeBondsCB.UseVisualStyleBackColor = true;
            // 
            // includeCarbonCB
            // 
            this.includeCarbonCB.AutoSize = true;
            this.includeCarbonCB.Checked = true;
            this.includeCarbonCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeCarbonCB.Location = new System.Drawing.Point(3, 274);
            this.includeCarbonCB.Name = "includeCarbonCB";
            this.includeCarbonCB.Size = new System.Drawing.Size(96, 17);
            this.includeCarbonCB.TabIndex = 13;
            this.includeCarbonCB.Text = "include carbon";
            this.includeCarbonCB.UseVisualStyleBackColor = true;
            // 
            // includeHalogensCB
            // 
            this.includeHalogensCB.AutoSize = true;
            this.includeHalogensCB.Checked = true;
            this.includeHalogensCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeHalogensCB.Location = new System.Drawing.Point(3, 251);
            this.includeHalogensCB.Name = "includeHalogensCB";
            this.includeHalogensCB.Size = new System.Drawing.Size(106, 17);
            this.includeHalogensCB.TabIndex = 12;
            this.includeHalogensCB.Text = "include halogens";
            this.includeHalogensCB.UseVisualStyleBackColor = true;
            // 
            // startYNud
            // 
            this.startYNud.Location = new System.Drawing.Point(55, 144);
            this.startYNud.Name = "startYNud";
            this.startYNud.Size = new System.Drawing.Size(75, 20);
            this.startYNud.TabIndex = 11;
            this.toolTip1.SetToolTip(this.startYNud, "Y coordinate of practice starting point");
            this.startYNud.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // startY
            // 
            this.startY.AutoSize = true;
            this.startY.Location = new System.Drawing.Point(3, 146);
            this.startY.Name = "startY";
            this.startY.Size = new System.Drawing.Size(37, 13);
            this.startY.TabIndex = 10;
            this.startY.Text = "start Y";
            // 
            // startXNud
            // 
            this.startXNud.Location = new System.Drawing.Point(55, 118);
            this.startXNud.Name = "startXNud";
            this.startXNud.Size = new System.Drawing.Size(75, 20);
            this.startXNud.TabIndex = 9;
            this.toolTip1.SetToolTip(this.startXNud, "X coordinate of practice starting point");
            this.startXNud.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // startX
            // 
            this.startX.AutoSize = true;
            this.startX.Location = new System.Drawing.Point(3, 120);
            this.startX.Name = "startX";
            this.startX.Size = new System.Drawing.Size(37, 13);
            this.startX.TabIndex = 8;
            this.startX.Text = "start X";
            // 
            // maxSubNud
            // 
            this.maxSubNud.Location = new System.Drawing.Point(55, 92);
            this.maxSubNud.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.maxSubNud.Name = "maxSubNud";
            this.maxSubNud.Size = new System.Drawing.Size(75, 20);
            this.maxSubNud.TabIndex = 7;
            this.toolTip1.SetToolTip(this.maxSubNud, "maximum length of sub chain");
            this.maxSubNud.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.maxSubNud.ValueChanged += new System.EventHandler(this.maxSubNud_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "max sub l.";
            // 
            // minSubNud
            // 
            this.minSubNud.Location = new System.Drawing.Point(55, 66);
            this.minSubNud.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.minSubNud.Name = "minSubNud";
            this.minSubNud.Size = new System.Drawing.Size(75, 20);
            this.minSubNud.TabIndex = 5;
            this.toolTip1.SetToolTip(this.minSubNud, "Minimum length of sub chain");
            this.minSubNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minSubNud.ValueChanged += new System.EventHandler(this.minSubNud_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "min sub l.";
            // 
            // maxLCCNud
            // 
            this.maxLCCNud.Location = new System.Drawing.Point(55, 40);
            this.maxLCCNud.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.maxLCCNud.Name = "maxLCCNud";
            this.maxLCCNud.Size = new System.Drawing.Size(75, 20);
            this.maxLCCNud.TabIndex = 3;
            this.toolTip1.SetToolTip(this.maxLCCNud, "Maximum length of main chain");
            this.maxLCCNud.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.maxLCCNud.ValueChanged += new System.EventHandler(this.maxLCCNud_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "max LCC";
            // 
            // minLCCNud
            // 
            this.minLCCNud.Location = new System.Drawing.Point(55, 14);
            this.minLCCNud.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.minLCCNud.Name = "minLCCNud";
            this.minLCCNud.Size = new System.Drawing.Size(75, 20);
            this.minLCCNud.TabIndex = 1;
            this.toolTip1.SetToolTip(this.minLCCNud, "Minimum length of main chain");
            this.minLCCNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minLCCNud.ValueChanged += new System.EventHandler(this.minLCCNud_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "min LCC";
            // 
            // indexCB
            // 
            this.indexCB.Color = System.Drawing.Color.Red;
            this.indexCB.Location = new System.Drawing.Point(11, 59);
            this.indexCB.Margin = new System.Windows.Forms.Padding(4);
            this.indexCB.Name = "indexCB";
            this.indexCB.Size = new System.Drawing.Size(43, 42);
            this.indexCB.TabIndex = 2;
            this.toolTip1.SetToolTip(this.indexCB, "Color of main chain indices");
            // 
            // gridCB
            // 
            this.gridCB.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridCB.Location = new System.Drawing.Point(60, 11);
            this.gridCB.Margin = new System.Windows.Forms.Padding(4);
            this.gridCB.Name = "gridCB";
            this.gridCB.Size = new System.Drawing.Size(43, 42);
            this.gridCB.TabIndex = 1;
            this.toolTip1.SetToolTip(this.gridCB, "Color of the grid");
            // 
            // emptyCB
            // 
            this.emptyCB.Color = System.Drawing.Color.Gray;
            this.emptyCB.Location = new System.Drawing.Point(11, 11);
            this.emptyCB.Margin = new System.Windows.Forms.Padding(4);
            this.emptyCB.Name = "emptyCB";
            this.emptyCB.Size = new System.Drawing.Size(43, 42);
            this.emptyCB.TabIndex = 0;
            this.toolTip1.SetToolTip(this.emptyCB, "Color of empty grid cells");
            // 
            // mainPicturePanel
            // 
            this.mainPicturePanel.AutoScroll = true;
            this.mainPicturePanel.Controls.Add(this.mainPictureBox);
            this.mainPicturePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPicturePanel.Location = new System.Drawing.Point(153, 3);
            this.mainPicturePanel.Name = "mainPicturePanel";
            this.mainPicturePanel.Size = new System.Drawing.Size(795, 439);
            this.mainPicturePanel.TabIndex = 1;
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mainPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(619, 330);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Click += new System.EventHandler(this.mainPictureBox_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(951, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(67, 17);
            this.StatusLabel.Text = "StatusLabel";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5500;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 110;
            // 
            // guaranteeCAcidCB
            // 
            this.guaranteeCAcidCB.AutoSize = true;
            this.guaranteeCAcidCB.Checked = true;
            this.guaranteeCAcidCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.guaranteeCAcidCB.Location = new System.Drawing.Point(3, 320);
            this.guaranteeCAcidCB.Name = "guaranteeCAcidCB";
            this.guaranteeCAcidCB.Size = new System.Drawing.Size(102, 17);
            this.guaranteeCAcidCB.TabIndex = 22;
            this.guaranteeCAcidCB.Text = "guaranteeCAcid";
            this.guaranteeCAcidCB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 595);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carbonCountNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bondChanceNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subChanceNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startYNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startXNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSubNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSubNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxLCCNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minLCCNud)).EndInit();
            this.mainPicturePanel.ResumeLayout(false);
            this.mainPicturePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel mainPicturePanel;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.FlowLayoutPanel elementFLP;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.RichTextBox NameRTB;
        private ColorButton gridCB;
        private ColorButton emptyCB;
        private ColorButton indexCB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox includeBondsCB;
        private System.Windows.Forms.CheckBox includeCarbonCB;
        private System.Windows.Forms.CheckBox includeHalogensCB;
        private System.Windows.Forms.NumericUpDown startYNud;
        private System.Windows.Forms.Label startY;
        private System.Windows.Forms.NumericUpDown startXNud;
        private System.Windows.Forms.Label startX;
        private System.Windows.Forms.NumericUpDown maxSubNud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown minSubNud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown maxLCCNud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown minLCCNud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown subChanceNud;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown bondChanceNud;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown carbonCountNud;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox includeOxygenCB;
        private System.Windows.Forms.CheckBox guaranteeCAcidCB;
    }
}

