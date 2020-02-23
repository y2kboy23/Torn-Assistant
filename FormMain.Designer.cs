using System.Drawing;

namespace Torn_Assistant
{
    partial class FormMain
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
            this.buttonTorn = new System.Windows.Forms.Button();
            this.buttonUser = new System.Windows.Forms.Button();
            this.buttonFaction = new System.Windows.Forms.Button();
            this.buttonTravel = new System.Windows.Forms.Button();
            this.buttonCompany = new System.Windows.Forms.Button();
            this.buttonItemMarket = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxName = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelCompanyFactionProperties = new System.Windows.Forms.TableLayoutPanel();
            this.labelEnd = new System.Windows.Forms.Label();
            this.labelInt = new System.Windows.Forms.Label();
            this.labelLabor = new System.Windows.Forms.Label();
            this.labelDex = new System.Windows.Forms.Label();
            this.labelSpd = new System.Windows.Forms.Label();
            this.labelDef = new System.Windows.Forms.Label();
            this.labelStr = new System.Windows.Forms.Label();
            this.labelMoney = new System.Windows.Forms.Label();
            this.labelLife = new System.Windows.Forms.Label();
            this.labelHappy = new System.Windows.Forms.Label();
            this.labelNerve = new System.Windows.Forms.Label();
            this.labelEnergy = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.labelNetworth = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDownRefresh = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.buttonGo = new System.Windows.Forms.Button();
            this.labelItemSearch = new System.Windows.Forms.Label();
            this.comboBoxItemSelect = new System.Windows.Forms.ComboBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.groupBoxName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTorn
            // 
            this.buttonTorn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTorn.Location = new System.Drawing.Point(897, 12);
            this.buttonTorn.Name = "buttonTorn";
            this.buttonTorn.Size = new System.Drawing.Size(107, 44);
            this.buttonTorn.TabIndex = 0;
            this.buttonTorn.TabStop = false;
            this.buttonTorn.Text = "Torn";
            this.buttonTorn.UseVisualStyleBackColor = true;
            // 
            // buttonUser
            // 
            this.buttonUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUser.Location = new System.Drawing.Point(897, 62);
            this.buttonUser.Name = "buttonUser";
            this.buttonUser.Size = new System.Drawing.Size(107, 44);
            this.buttonUser.TabIndex = 1;
            this.buttonUser.TabStop = false;
            this.buttonUser.Text = "User";
            this.buttonUser.UseVisualStyleBackColor = true;
            // 
            // buttonFaction
            // 
            this.buttonFaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFaction.Location = new System.Drawing.Point(897, 112);
            this.buttonFaction.Name = "buttonFaction";
            this.buttonFaction.Size = new System.Drawing.Size(107, 44);
            this.buttonFaction.TabIndex = 2;
            this.buttonFaction.TabStop = false;
            this.buttonFaction.Text = "Faction";
            this.buttonFaction.UseVisualStyleBackColor = true;
            // 
            // buttonTravel
            // 
            this.buttonTravel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTravel.Enabled = false;
            this.buttonTravel.Location = new System.Drawing.Point(897, 162);
            this.buttonTravel.Name = "buttonTravel";
            this.buttonTravel.Size = new System.Drawing.Size(107, 44);
            this.buttonTravel.TabIndex = 3;
            this.buttonTravel.TabStop = false;
            this.buttonTravel.Text = "Travel";
            this.buttonTravel.UseVisualStyleBackColor = true;
            this.buttonTravel.Click += new System.EventHandler(this.buttonTravel_Click);
            // 
            // buttonCompany
            // 
            this.buttonCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCompany.Enabled = false;
            this.buttonCompany.Location = new System.Drawing.Point(897, 212);
            this.buttonCompany.Name = "buttonCompany";
            this.buttonCompany.Size = new System.Drawing.Size(107, 44);
            this.buttonCompany.TabIndex = 4;
            this.buttonCompany.TabStop = false;
            this.buttonCompany.Text = "Company";
            this.buttonCompany.UseVisualStyleBackColor = true;
            this.buttonCompany.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonCompany_MouseClick);
            // 
            // buttonItemMarket
            // 
            this.buttonItemMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonItemMarket.Location = new System.Drawing.Point(897, 262);
            this.buttonItemMarket.Name = "buttonItemMarket";
            this.buttonItemMarket.Size = new System.Drawing.Size(107, 44);
            this.buttonItemMarket.TabIndex = 5;
            this.buttonItemMarket.TabStop = false;
            this.buttonItemMarket.Text = "Item Market";
            this.buttonItemMarket.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1016, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(82, 17);
            this.toolStripStatusLabel1.Text = "Last Updated: ";
            // 
            // groupBoxName
            // 
            this.groupBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxName.Controls.Add(this.tableLayoutPanelCompanyFactionProperties);
            this.groupBoxName.Controls.Add(this.labelEnd);
            this.groupBoxName.Controls.Add(this.labelInt);
            this.groupBoxName.Controls.Add(this.labelLabor);
            this.groupBoxName.Controls.Add(this.labelDex);
            this.groupBoxName.Controls.Add(this.labelSpd);
            this.groupBoxName.Controls.Add(this.labelDef);
            this.groupBoxName.Controls.Add(this.labelStr);
            this.groupBoxName.Controls.Add(this.labelMoney);
            this.groupBoxName.Controls.Add(this.labelLife);
            this.groupBoxName.Controls.Add(this.labelHappy);
            this.groupBoxName.Controls.Add(this.labelNerve);
            this.groupBoxName.Controls.Add(this.labelEnergy);
            this.groupBoxName.Controls.Add(this.labelPoints);
            this.groupBoxName.Controls.Add(this.labelLevel);
            this.groupBoxName.Controls.Add(this.labelAge);
            this.groupBoxName.Controls.Add(this.labelNetworth);
            this.groupBoxName.Location = new System.Drawing.Point(12, 12);
            this.groupBoxName.Name = "groupBoxName";
            this.groupBoxName.Padding = new System.Windows.Forms.Padding(3, 5, 5, 5);
            this.groupBoxName.Size = new System.Drawing.Size(197, 410);
            this.groupBoxName.TabIndex = 0;
            this.groupBoxName.TabStop = false;
            this.groupBoxName.Text = "Name";
            // 
            // tableLayoutPanelCompanyFactionProperties
            // 
            this.tableLayoutPanelCompanyFactionProperties.AutoSize = true;
            this.tableLayoutPanelCompanyFactionProperties.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelCompanyFactionProperties.ColumnCount = 1;
            this.tableLayoutPanelCompanyFactionProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCompanyFactionProperties.Enabled = false;
            this.tableLayoutPanelCompanyFactionProperties.Location = new System.Drawing.Point(6, 351);
            this.tableLayoutPanelCompanyFactionProperties.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelCompanyFactionProperties.Name = "tableLayoutPanelCompanyFactionProperties";
            this.tableLayoutPanelCompanyFactionProperties.RowCount = 2;
            this.tableLayoutPanelCompanyFactionProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCompanyFactionProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCompanyFactionProperties.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanelCompanyFactionProperties.TabIndex = 0;
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Location = new System.Drawing.Point(6, 313);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.labelEnd.Size = new System.Drawing.Size(62, 38);
            this.labelEnd.TabIndex = 15;
            this.labelEnd.Text = "Endurance:";
            // 
            // labelInt
            // 
            this.labelInt.AutoSize = true;
            this.labelInt.Location = new System.Drawing.Point(6, 298);
            this.labelInt.Name = "labelInt";
            this.labelInt.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelInt.Size = new System.Drawing.Size(64, 15);
            this.labelInt.TabIndex = 14;
            this.labelInt.Text = "Intelligence:";
            // 
            // labelLabor
            // 
            this.labelLabor.AutoSize = true;
            this.labelLabor.Location = new System.Drawing.Point(6, 283);
            this.labelLabor.Name = "labelLabor";
            this.labelLabor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelLabor.Size = new System.Drawing.Size(75, 15);
            this.labelLabor.TabIndex = 13;
            this.labelLabor.Text = "Manual Labor:";
            // 
            // labelDex
            // 
            this.labelDex.AutoSize = true;
            this.labelDex.Location = new System.Drawing.Point(6, 245);
            this.labelDex.Name = "labelDex";
            this.labelDex.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.labelDex.Size = new System.Drawing.Size(51, 38);
            this.labelDex.TabIndex = 12;
            this.labelDex.Text = "Dexterity:";
            // 
            // labelSpd
            // 
            this.labelSpd.AutoSize = true;
            this.labelSpd.Location = new System.Drawing.Point(6, 230);
            this.labelSpd.Name = "labelSpd";
            this.labelSpd.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelSpd.Size = new System.Drawing.Size(41, 15);
            this.labelSpd.TabIndex = 11;
            this.labelSpd.Text = "Speed:";
            // 
            // labelDef
            // 
            this.labelDef.AutoSize = true;
            this.labelDef.Location = new System.Drawing.Point(6, 215);
            this.labelDef.Name = "labelDef";
            this.labelDef.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelDef.Size = new System.Drawing.Size(50, 15);
            this.labelDef.TabIndex = 10;
            this.labelDef.Text = "Defense:";
            // 
            // labelStr
            // 
            this.labelStr.AutoSize = true;
            this.labelStr.Location = new System.Drawing.Point(6, 200);
            this.labelStr.Name = "labelStr";
            this.labelStr.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelStr.Size = new System.Drawing.Size(50, 15);
            this.labelStr.TabIndex = 9;
            this.labelStr.Text = "Strength:";
            // 
            // labelMoney
            // 
            this.labelMoney.AutoSize = true;
            this.labelMoney.Location = new System.Drawing.Point(6, 49);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelMoney.Size = new System.Drawing.Size(42, 15);
            this.labelMoney.TabIndex = 8;
            this.labelMoney.Text = "Money:";
            // 
            // labelLife
            // 
            this.labelLife.AutoSize = true;
            this.labelLife.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(67)))), ((int)(((byte)(207)))));
            this.labelLife.Location = new System.Drawing.Point(6, 162);
            this.labelLife.Name = "labelLife";
            this.labelLife.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.labelLife.Size = new System.Drawing.Size(27, 38);
            this.labelLife.TabIndex = 7;
            this.labelLife.Text = "Life:";
            // 
            // labelHappy
            // 
            this.labelHappy.AutoSize = true;
            this.labelHappy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(153)))), ((int)(((byte)(44)))));
            this.labelHappy.Location = new System.Drawing.Point(6, 147);
            this.labelHappy.Name = "labelHappy";
            this.labelHappy.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelHappy.Size = new System.Drawing.Size(60, 15);
            this.labelHappy.TabIndex = 6;
            this.labelHappy.Text = "Happiness:";
            // 
            // labelNerve
            // 
            this.labelNerve.AutoSize = true;
            this.labelNerve.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(56)))), ((int)(((byte)(44)))));
            this.labelNerve.Location = new System.Drawing.Point(6, 132);
            this.labelNerve.Name = "labelNerve";
            this.labelNerve.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelNerve.Size = new System.Drawing.Size(39, 15);
            this.labelNerve.TabIndex = 5;
            this.labelNerve.Text = "Nerve:";
            // 
            // labelEnergy
            // 
            this.labelEnergy.AutoSize = true;
            this.labelEnergy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(124)))), ((int)(((byte)(30)))));
            this.labelEnergy.Location = new System.Drawing.Point(6, 117);
            this.labelEnergy.Name = "labelEnergy";
            this.labelEnergy.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelEnergy.Size = new System.Drawing.Size(43, 15);
            this.labelEnergy.TabIndex = 4;
            this.labelEnergy.Text = "Energy:";
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Location = new System.Drawing.Point(6, 79);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.labelPoints.Size = new System.Drawing.Size(39, 38);
            this.labelPoints.TabIndex = 3;
            this.labelPoints.Text = "Points:";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(6, 34);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelLevel.Size = new System.Drawing.Size(36, 15);
            this.labelLevel.TabIndex = 2;
            this.labelLevel.Text = "Level:";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(6, 19);
            this.labelAge.Name = "labelAge";
            this.labelAge.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelAge.Size = new System.Drawing.Size(32, 15);
            this.labelAge.TabIndex = 1;
            this.labelAge.Text = "Age: ";
            // 
            // labelNetworth
            // 
            this.labelNetworth.AutoSize = true;
            this.labelNetworth.Location = new System.Drawing.Point(6, 64);
            this.labelNetworth.Name = "labelNetworth";
            this.labelNetworth.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelNetworth.Size = new System.Drawing.Size(56, 15);
            this.labelNetworth.TabIndex = 0;
            this.labelNetworth.Text = "Networth: ";
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // numericUpDownRefresh
            // 
            this.numericUpDownRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownRefresh.Enabled = false;
            this.numericUpDownRefresh.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownRefresh.Location = new System.Drawing.Point(959, 325);
            this.numericUpDownRefresh.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDownRefresh.Name = "numericUpDownRefresh";
            this.numericUpDownRefresh.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownRefresh.TabIndex = 1;
            this.numericUpDownRefresh.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownRefresh.ValueChanged += new System.EventHandler(this.NumericUpDownRefresh_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(906, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Refresh:";
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(215, 46);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.Size = new System.Drawing.Size(676, 376);
            this.dataGridViewItems.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.buttonGo);
            this.groupBox1.Controls.Add(this.labelItemSearch);
            this.groupBox1.Controls.Add(this.comboBoxItemSelect);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(215, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 34);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Enabled = false;
            this.radioButton4.Location = new System.Drawing.Point(306, 10);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(61, 17);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Attacks";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // buttonGo
            // 
            this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGo.Enabled = false;
            this.buttonGo.Location = new System.Drawing.Point(625, 9);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(45, 21);
            this.buttonGo.TabIndex = 3;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // labelItemSearch
            // 
            this.labelItemSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelItemSearch.AutoSize = true;
            this.labelItemSearch.Location = new System.Drawing.Point(425, 12);
            this.labelItemSearch.Name = "labelItemSearch";
            this.labelItemSearch.Size = new System.Drawing.Size(67, 13);
            this.labelItemSearch.TabIndex = 0;
            this.labelItemSearch.Text = "Item Search:";
            // 
            // comboBoxItemSelect
            // 
            this.comboBoxItemSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxItemSelect.DropDownWidth = 200;
            this.comboBoxItemSelect.Enabled = false;
            this.comboBoxItemSelect.FormattingEnabled = true;
            this.comboBoxItemSelect.Location = new System.Drawing.Point(498, 9);
            this.comboBoxItemSelect.Name = "comboBoxItemSelect";
            this.comboBoxItemSelect.Size = new System.Drawing.Size(121, 21);
            this.comboBoxItemSelect.TabIndex = 0;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Enabled = false;
            this.radioButton3.Location = new System.Drawing.Point(206, 10);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(91, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Scan Markets";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(106, 10);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(90, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Sell to Market";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 10);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(91, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Sell to Vendor";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1016, 447);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownRefresh);
            this.Controls.Add(this.groupBoxName);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonItemMarket);
            this.Controls.Add(this.buttonCompany);
            this.Controls.Add(this.buttonTravel);
            this.Controls.Add(this.buttonFaction);
            this.Controls.Add(this.buttonUser);
            this.Controls.Add(this.buttonTorn);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FormMain";
            this.Text = "Torn Assistant";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxName.ResumeLayout(false);
            this.groupBoxName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTorn;
        private System.Windows.Forms.Button buttonUser;
        private System.Windows.Forms.Button buttonFaction;
        private System.Windows.Forms.Button buttonTravel;
        private System.Windows.Forms.Button buttonCompany;
        private System.Windows.Forms.Button buttonItemMarket;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBoxName;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Label labelNetworth;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.Label labelLife;
        private System.Windows.Forms.Label labelHappy;
        private System.Windows.Forms.Label labelNerve;
        private System.Windows.Forms.Label labelEnergy;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.Label labelInt;
        private System.Windows.Forms.Label labelLabor;
        private System.Windows.Forms.Label labelDex;
        private System.Windows.Forms.Label labelSpd;
        private System.Windows.Forms.Label labelDef;
        private System.Windows.Forms.Label labelStr;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDownRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label labelItemSearch;
        private System.Windows.Forms.ComboBox comboBoxItemSelect;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCompanyFactionProperties;
    }
}

