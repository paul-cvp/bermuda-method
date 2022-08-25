
namespace Bermuda
{
    partial class Bermuda
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
            this.tabBermuda = new System.Windows.Forms.TabControl();
            this.tabPageUI = new System.Windows.Forms.TabPage();
            this.imageUpload = new System.Windows.Forms.Button();
            this.buttonCaptureUI = new System.Windows.Forms.Button();
            this.buttonEditScreenshot = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddScreenshot = new System.Windows.Forms.Button();
            this.pbScreenshot = new System.Windows.Forms.PictureBox();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.buttonRunExternal = new System.Windows.Forms.Button();
            this.btnAddSql = new System.Windows.Forms.Button();
            this.buttonRunOneSQL = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.richtbDbQuery = new System.Windows.Forms.RichTextBox();
            this.tabPageDomain = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbRegulatoryRules = new System.Windows.Forms.RichTextBox();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMappingProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMappingProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDomainModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBPMNDomainModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxAddAll3 = new System.Windows.Forms.GroupBox();
            this.buttonRunAllSQLInGraph = new System.Windows.Forms.Button();
            this.buttonAddMappingToGraph = new System.Windows.Forms.Button();
            this.dataGridViewEvents = new System.Windows.Forms.DataGridView();
            this.EventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Screnshot = new System.Windows.Forms.DataGridViewImageColumn();
            this.Sql = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsComplete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Sequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonImportDCREvents = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonSaveAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabBermuda.SuspendLayout();
            this.tabPageUI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).BeginInit();
            this.tabPageData.SuspendLayout();
            this.tabPageDomain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBoxAddAll3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabBermuda
            // 
            this.tabBermuda.Controls.Add(this.tabPageUI);
            this.tabBermuda.Controls.Add(this.tabPageData);
            this.tabBermuda.Controls.Add(this.tabPageDomain);
            this.tabBermuda.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabBermuda.Location = new System.Drawing.Point(0, 33);
            this.tabBermuda.Name = "tabBermuda";
            this.tabBermuda.SelectedIndex = 0;
            this.tabBermuda.Size = new System.Drawing.Size(1516, 456);
            this.tabBermuda.TabIndex = 0;
            // 
            // tabPageUI
            // 
            this.tabPageUI.Controls.Add(this.imageUpload);
            this.tabPageUI.Controls.Add(this.buttonCaptureUI);
            this.tabPageUI.Controls.Add(this.buttonEditScreenshot);
            this.tabPageUI.Controls.Add(this.label4);
            this.tabPageUI.Controls.Add(this.btnAddScreenshot);
            this.tabPageUI.Controls.Add(this.pbScreenshot);
            this.tabPageUI.Location = new System.Drawing.Point(4, 29);
            this.tabPageUI.Name = "tabPageUI";
            this.tabPageUI.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUI.Size = new System.Drawing.Size(1508, 423);
            this.tabPageUI.TabIndex = 1;
            this.tabPageUI.Text = "User Interface";
            this.tabPageUI.UseVisualStyleBackColor = true;
            // 
            // imageUpload
            // 
            this.imageUpload.Location = new System.Drawing.Point(710, 123);
            this.imageUpload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imageUpload.Name = "imageUpload";
            this.imageUpload.Size = new System.Drawing.Size(204, 40);
            this.imageUpload.TabIndex = 28;
            this.imageUpload.Text = "Upload image";
            this.imageUpload.UseVisualStyleBackColor = true;
            this.imageUpload.Click += new System.EventHandler(this.imageUpload_Click);
            // 
            // buttonCaptureUI
            // 
            this.buttonCaptureUI.Location = new System.Drawing.Point(710, 42);
            this.buttonCaptureUI.Name = "buttonCaptureUI";
            this.buttonCaptureUI.Size = new System.Drawing.Size(206, 66);
            this.buttonCaptureUI.TabIndex = 27;
            this.buttonCaptureUI.Text = "Capture New User Interface";
            this.buttonCaptureUI.UseVisualStyleBackColor = true;
            this.buttonCaptureUI.Click += new System.EventHandler(this.buttonCaptureUI_Click);
            // 
            // buttonEditScreenshot
            // 
            this.buttonEditScreenshot.Location = new System.Drawing.Point(704, 306);
            this.buttonEditScreenshot.Name = "buttonEditScreenshot";
            this.buttonEditScreenshot.Size = new System.Drawing.Size(213, 43);
            this.buttonEditScreenshot.TabIndex = 26;
            this.buttonEditScreenshot.Text = "Edit Image";
            this.buttonEditScreenshot.UseVisualStyleBackColor = true;
            this.buttonEditScreenshot.Click += new System.EventHandler(this.buttonEditScreenshot_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "User Interface element";
            // 
            // btnAddScreenshot
            // 
            this.btnAddScreenshot.Location = new System.Drawing.Point(704, 355);
            this.btnAddScreenshot.Name = "btnAddScreenshot";
            this.btnAddScreenshot.Size = new System.Drawing.Size(213, 43);
            this.btnAddScreenshot.TabIndex = 25;
            this.btnAddScreenshot.Text = "Add User Interface";
            this.btnAddScreenshot.UseVisualStyleBackColor = true;
            this.btnAddScreenshot.Click += new System.EventHandler(this.btnAddScreenshot_Click);
            // 
            // pbScreenshot
            // 
            this.pbScreenshot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbScreenshot.Location = new System.Drawing.Point(20, 40);
            this.pbScreenshot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbScreenshot.Name = "pbScreenshot";
            this.pbScreenshot.Size = new System.Drawing.Size(676, 357);
            this.pbScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbScreenshot.TabIndex = 22;
            this.pbScreenshot.TabStop = false;
            this.pbScreenshot.Click += new System.EventHandler(this.pbScreenshot_Click);
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.buttonRunExternal);
            this.tabPageData.Controls.Add(this.btnAddSql);
            this.tabPageData.Controls.Add(this.buttonRunOneSQL);
            this.tabPageData.Controls.Add(this.label5);
            this.tabPageData.Controls.Add(this.richtbDbQuery);
            this.tabPageData.Location = new System.Drawing.Point(4, 29);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Size = new System.Drawing.Size(1508, 423);
            this.tabPageData.TabIndex = 2;
            this.tabPageData.Text = "Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // buttonRunExternal
            // 
            this.buttonRunExternal.Location = new System.Drawing.Point(700, 297);
            this.buttonRunExternal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRunExternal.Name = "buttonRunExternal";
            this.buttonRunExternal.Size = new System.Drawing.Size(214, 35);
            this.buttonRunExternal.TabIndex = 31;
            this.buttonRunExternal.Text = "Run in SQL Server";
            this.buttonRunExternal.UseVisualStyleBackColor = true;
            this.buttonRunExternal.Click += new System.EventHandler(this.buttonRunExternal_Click);
            // 
            // btnAddSql
            // 
            this.btnAddSql.Location = new System.Drawing.Point(700, 340);
            this.btnAddSql.Name = "btnAddSql";
            this.btnAddSql.Size = new System.Drawing.Size(214, 43);
            this.btnAddSql.TabIndex = 26;
            this.btnAddSql.Text = "Add Data Location";
            this.btnAddSql.UseVisualStyleBackColor = true;
            this.btnAddSql.Click += new System.EventHandler(this.btnAddSql_Click);
            // 
            // buttonRunOneSQL
            // 
            this.buttonRunOneSQL.Location = new System.Drawing.Point(700, 246);
            this.buttonRunOneSQL.Name = "buttonRunOneSQL";
            this.buttonRunOneSQL.Size = new System.Drawing.Size(213, 43);
            this.buttonRunOneSQL.TabIndex = 25;
            this.buttonRunOneSQL.Text = "Run Current SQL Script";
            this.buttonRunOneSQL.UseVisualStyleBackColor = true;
            this.buttonRunOneSQL.Click += new System.EventHandler(this.buttonRunOneSQL_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Data location";
            // 
            // richtbDbQuery
            // 
            this.richtbDbQuery.Location = new System.Drawing.Point(20, 40);
            this.richtbDbQuery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richtbDbQuery.Name = "richtbDbQuery";
            this.richtbDbQuery.Size = new System.Drawing.Size(673, 355);
            this.richtbDbQuery.TabIndex = 23;
            this.richtbDbQuery.Text = "";
            // 
            // tabPageDomain
            // 
            this.tabPageDomain.Controls.Add(this.label3);
            this.tabPageDomain.Controls.Add(this.rtbRegulatoryRules);
            this.tabPageDomain.Controls.Add(this.btnAddRule);
            this.tabPageDomain.Location = new System.Drawing.Point(4, 29);
            this.tabPageDomain.Name = "tabPageDomain";
            this.tabPageDomain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDomain.Size = new System.Drawing.Size(1508, 423);
            this.tabPageDomain.TabIndex = 0;
            this.tabPageDomain.Text = "Domain";
            this.tabPageDomain.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Domain Context";
            // 
            // rtbRegulatoryRules
            // 
            this.rtbRegulatoryRules.Location = new System.Drawing.Point(8, 40);
            this.rtbRegulatoryRules.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbRegulatoryRules.Name = "rtbRegulatoryRules";
            this.rtbRegulatoryRules.Size = new System.Drawing.Size(673, 355);
            this.rtbRegulatoryRules.TabIndex = 21;
            this.rtbRegulatoryRules.Text = "";
            this.rtbRegulatoryRules.SelectionChanged += new System.EventHandler(this.rtbRegulatoryRules_SelectionChanged);
            // 
            // btnAddRule
            // 
            this.btnAddRule.Location = new System.Drawing.Point(690, 354);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(213, 43);
            this.btnAddRule.TabIndex = 24;
            this.btnAddRule.Text = "Add Domain Context";
            this.btnAddRule.UseVisualStyleBackColor = true;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.userToolStripMenuItem,
            this.dataConnectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1516, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMappingProjectToolStripMenuItem,
            this.saveMappingProjectToolStripMenuItem,
            this.loadDomainModelToolStripMenuItem,
            this.loadBPMNDomainModelToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadMappingProjectToolStripMenuItem
            // 
            this.loadMappingProjectToolStripMenuItem.Name = "loadMappingProjectToolStripMenuItem";
            this.loadMappingProjectToolStripMenuItem.Size = new System.Drawing.Size(331, 34);
            this.loadMappingProjectToolStripMenuItem.Text = "Load Mapping Project";
            this.loadMappingProjectToolStripMenuItem.Click += new System.EventHandler(this.loadMappingProjectToolStripMenuItem_Click);
            // 
            // saveMappingProjectToolStripMenuItem
            // 
            this.saveMappingProjectToolStripMenuItem.Name = "saveMappingProjectToolStripMenuItem";
            this.saveMappingProjectToolStripMenuItem.Size = new System.Drawing.Size(331, 34);
            this.saveMappingProjectToolStripMenuItem.Text = "Save Mapping Project";
            this.saveMappingProjectToolStripMenuItem.Click += new System.EventHandler(this.saveMappingProjectToolStripMenuItem_Click);
            // 
            // loadDomainModelToolStripMenuItem
            // 
            this.loadDomainModelToolStripMenuItem.Name = "loadDomainModelToolStripMenuItem";
            this.loadDomainModelToolStripMenuItem.Size = new System.Drawing.Size(331, 34);
            this.loadDomainModelToolStripMenuItem.Text = "Load DCR Domain Model";
            this.loadDomainModelToolStripMenuItem.Click += new System.EventHandler(this.loadDomainModelToolStripMenuItem_Click);
            // 
            // loadBPMNDomainModelToolStripMenuItem
            // 
            this.loadBPMNDomainModelToolStripMenuItem.Name = "loadBPMNDomainModelToolStripMenuItem";
            this.loadBPMNDomainModelToolStripMenuItem.Size = new System.Drawing.Size(331, 34);
            this.loadBPMNDomainModelToolStripMenuItem.Text = "Load BPMN Domain Model";
            this.loadBPMNDomainModelToolStripMenuItem.Click += new System.EventHandler(this.loadBPMNDomainModelToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(63, 29);
            this.userToolStripMenuItem.Text = "User";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(171, 34);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // dataConnectionToolStripMenuItem
            // 
            this.dataConnectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageToolStripMenuItem});
            this.dataConnectionToolStripMenuItem.Name = "dataConnectionToolStripMenuItem";
            this.dataConnectionToolStripMenuItem.Size = new System.Drawing.Size(160, 29);
            this.dataConnectionToolStripMenuItem.Text = "Data Connection";
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(178, 34);
            this.manageToolStripMenuItem.Text = "Manage";
            this.manageToolStripMenuItem.Click += new System.EventHandler(this.manageToolStripMenuItem_Click);
            // 
            // groupBoxAddAll3
            // 
            this.groupBoxAddAll3.Controls.Add(this.buttonRunAllSQLInGraph);
            this.groupBoxAddAll3.Controls.Add(this.buttonAddMappingToGraph);
            this.groupBoxAddAll3.Location = new System.Drawing.Point(4, 3);
            this.groupBoxAddAll3.Name = "groupBoxAddAll3";
            this.groupBoxAddAll3.Size = new System.Drawing.Size(345, 131);
            this.groupBoxAddAll3.TabIndex = 25;
            this.groupBoxAddAll3.TabStop = false;
            this.groupBoxAddAll3.Text = "Add all 3 elements to list at selected rows";
            // 
            // buttonRunAllSQLInGraph
            // 
            this.buttonRunAllSQLInGraph.Location = new System.Drawing.Point(56, 77);
            this.buttonRunAllSQLInGraph.Name = "buttonRunAllSQLInGraph";
            this.buttonRunAllSQLInGraph.Size = new System.Drawing.Size(213, 43);
            this.buttonRunAllSQLInGraph.TabIndex = 35;
            this.buttonRunAllSQLInGraph.Text = "Run all Scripts from List";
            this.buttonRunAllSQLInGraph.UseVisualStyleBackColor = true;
            this.buttonRunAllSQLInGraph.Click += new System.EventHandler(this.buttonRunAllSQLInGraph_Click_1);
            // 
            // buttonAddMappingToGraph
            // 
            this.buttonAddMappingToGraph.Location = new System.Drawing.Point(56, 28);
            this.buttonAddMappingToGraph.Name = "buttonAddMappingToGraph";
            this.buttonAddMappingToGraph.Size = new System.Drawing.Size(213, 43);
            this.buttonAddMappingToGraph.TabIndex = 5;
            this.buttonAddMappingToGraph.Text = "Add New Mapping";
            this.buttonAddMappingToGraph.UseVisualStyleBackColor = true;
            this.buttonAddMappingToGraph.Click += new System.EventHandler(this.buttonAddMappingToGraph_Click);
            // 
            // dataGridViewEvents
            // 
            this.dataGridViewEvents.AllowDrop = true;
            this.dataGridViewEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EventID,
            this.Activity,
            this.Domain,
            this.Screnshot,
            this.Sql,
            this.IsComplete,
            this.Delete,
            this.Sequence});
            this.dataGridViewEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEvents.Location = new System.Drawing.Point(0, 489);
            this.dataGridViewEvents.Name = "dataGridViewEvents";
            this.dataGridViewEvents.RowHeadersWidth = 62;
            this.dataGridViewEvents.RowTemplate.Height = 28;
            this.dataGridViewEvents.Size = new System.Drawing.Size(1516, 779);
            this.dataGridViewEvents.TabIndex = 31;
            this.dataGridViewEvents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEvents_CellContentClick);
            this.dataGridViewEvents.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEvents_CellContentDoubleClick);
            this.dataGridViewEvents.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEvents_CellEndEdit);
            this.dataGridViewEvents.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEvents_CellValueChanged);
            this.dataGridViewEvents.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewEvents_DragDrop);
            this.dataGridViewEvents.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridViewEvents_DragOver);
            this.dataGridViewEvents.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewEvents_MouseDown);
            this.dataGridViewEvents.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridViewEvents_MouseMove);
            // 
            // EventID
            // 
            this.EventID.HeaderText = "ID";
            this.EventID.MinimumWidth = 8;
            this.EventID.Name = "EventID";
            this.EventID.Width = 150;
            // 
            // Activity
            // 
            this.Activity.HeaderText = "Activity";
            this.Activity.MinimumWidth = 8;
            this.Activity.Name = "Activity";
            this.Activity.Width = 150;
            // 
            // Domain
            // 
            this.Domain.HeaderText = "Domain Context";
            this.Domain.MinimumWidth = 8;
            this.Domain.Name = "Domain";
            this.Domain.Width = 150;
            // 
            // Screnshot
            // 
            this.Screnshot.HeaderText = "User Interface";
            this.Screnshot.MinimumWidth = 8;
            this.Screnshot.Name = "Screnshot";
            this.Screnshot.Width = 150;
            // 
            // Sql
            // 
            this.Sql.HeaderText = "Data Location";
            this.Sql.MinimumWidth = 8;
            this.Sql.Name = "Sql";
            this.Sql.Width = 150;
            // 
            // IsComplete
            // 
            this.IsComplete.HeaderText = "Complete";
            this.IsComplete.MinimumWidth = 8;
            this.IsComplete.Name = "IsComplete";
            this.IsComplete.ReadOnly = true;
            this.IsComplete.Width = 150;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.MinimumWidth = 8;
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete Row";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Width = 150;
            // 
            // Sequence
            // 
            this.Sequence.HeaderText = "Sequence";
            this.Sequence.MinimumWidth = 8;
            this.Sequence.Name = "Sequence";
            this.Sequence.Width = 150;
            // 
            // buttonImportDCREvents
            // 
            this.buttonImportDCREvents.Location = new System.Drawing.Point(51, 28);
            this.buttonImportDCREvents.Name = "buttonImportDCREvents";
            this.buttonImportDCREvents.Size = new System.Drawing.Size(213, 43);
            this.buttonImportDCREvents.TabIndex = 30;
            this.buttonImportDCREvents.Text = "Load DCR Domain Model";
            this.buttonImportDCREvents.UseVisualStyleBackColor = true;
            this.buttonImportDCREvents.Click += new System.EventHandler(this.buttonImportDCREvents_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(51, 77);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(213, 43);
            this.buttonReset.TabIndex = 29;
            this.buttonReset.Text = "Clear All";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonSaveAll
            // 
            this.buttonSaveAll.Location = new System.Drawing.Point(51, 126);
            this.buttonSaveAll.Name = "buttonSaveAll";
            this.buttonSaveAll.Size = new System.Drawing.Size(213, 43);
            this.buttonSaveAll.TabIndex = 28;
            this.buttonSaveAll.Text = "Save Mapping Project";
            this.buttonSaveAll.UseVisualStyleBackColor = true;
            this.buttonSaveAll.Click += new System.EventHandler(this.buttonSaveAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonImportDCREvents);
            this.groupBox1.Controls.Add(this.buttonReset);
            this.groupBox1.Controls.Add(this.buttonSaveAll);
            this.groupBox1.Location = new System.Drawing.Point(4, 142);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(351, 189);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxAddAll3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1516, 1268);
            this.panel1.TabIndex = 33;
            // 
            // Bermuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1516, 1268);
            this.Controls.Add(this.dataGridViewEvents);
            this.Controls.Add(this.tabBermuda);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Bermuda";
            this.Text = "Bermuda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bermuda_FormClosing);
            this.Load += new System.EventHandler(this.Bermuda_Load);
            this.Shown += new System.EventHandler(this.Bermuda_Shown);
            this.tabBermuda.ResumeLayout(false);
            this.tabPageUI.ResumeLayout(false);
            this.tabPageUI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).EndInit();
            this.tabPageData.ResumeLayout(false);
            this.tabPageData.PerformLayout();
            this.tabPageDomain.ResumeLayout(false);
            this.tabPageDomain.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxAddAll3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabBermuda;
        private System.Windows.Forms.TabPage tabPageDomain;
        private System.Windows.Forms.TabPage tabPageUI;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMappingProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMappingProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDomainModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbRegulatoryRules;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbScreenshot;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richtbDbQuery;
        private System.Windows.Forms.Button buttonRunOneSQL;
        private System.Windows.Forms.Button btnAddSql;
        private System.Windows.Forms.Button btnAddScreenshot;
        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.GroupBox groupBoxAddAll3;
        private System.Windows.Forms.Button buttonAddMappingToGraph;
        private System.Windows.Forms.DataGridView dataGridViewEvents;
        private System.Windows.Forms.Button buttonImportDCREvents;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonSaveAll;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBPMNDomainModelToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonRunExternal;
        private System.Windows.Forms.Button buttonEditScreenshot;
        private System.Windows.Forms.Button buttonCaptureUI;
        private System.Windows.Forms.Button buttonRunAllSQLInGraph;
        private System.Windows.Forms.ToolStripMenuItem dataConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button imageUpload;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domain;
        private System.Windows.Forms.DataGridViewImageColumn Screnshot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sql;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsComplete;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sequence;
    }
}