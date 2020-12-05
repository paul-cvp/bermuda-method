namespace Bermuda
{
    partial class Mapping
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
            this.pbScreenshot = new System.Windows.Forms.PictureBox();
            this.richtbDbQuery = new System.Windows.Forms.RichTextBox();
            this.dataFromSql = new System.Windows.Forms.DataGridView();
            this.buttonAddMappingToGraph = new System.Windows.Forms.Button();
            this.buttonRunOneSQL = new System.Windows.Forms.Button();
            this.buttonRunAllSQLInGraph = new System.Windows.Forms.Button();
            this.buttonSaveEventLog = new System.Windows.Forms.Button();
            this.buttonSaveAll = new System.Windows.Forms.Button();
            this.comboBoxSelectDbConnection = new System.Windows.Forms.ComboBox();
            this.buttonNewConnectionString = new System.Windows.Forms.Button();
            this.rtbRegulatoryRules = new System.Windows.Forms.RichTextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonImportDCREvents = new System.Windows.Forms.Button();
            this.dataGridViewEvents = new System.Windows.Forms.DataGridView();
            this.EventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Screnshot = new System.Windows.Forms.DataGridViewImageColumn();
            this.Sql = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsComplete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddSql = new System.Windows.Forms.Button();
            this.btnAddScreenshot = new System.Windows.Forms.Button();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataFromSql)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbScreenshot
            // 
            this.pbScreenshot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbScreenshot.Location = new System.Drawing.Point(706, 60);
            this.pbScreenshot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbScreenshot.Name = "pbScreenshot";
            this.pbScreenshot.Size = new System.Drawing.Size(675, 357);
            this.pbScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbScreenshot.TabIndex = 0;
            this.pbScreenshot.TabStop = false;
            this.pbScreenshot.Click += new System.EventHandler(this.pbScreenshot_Click);
            // 
            // richtbDbQuery
            // 
            this.richtbDbQuery.Location = new System.Drawing.Point(1401, 58);
            this.richtbDbQuery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richtbDbQuery.Name = "richtbDbQuery";
            this.richtbDbQuery.Size = new System.Drawing.Size(673, 355);
            this.richtbDbQuery.TabIndex = 2;
            this.richtbDbQuery.Text = "";
            // 
            // dataFromSql
            // 
            this.dataFromSql.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFromSql.Location = new System.Drawing.Point(1402, 474);
            this.dataFromSql.Name = "dataFromSql";
            this.dataFromSql.ReadOnly = true;
            this.dataFromSql.RowHeadersWidth = 62;
            this.dataFromSql.RowTemplate.Height = 28;
            this.dataFromSql.Size = new System.Drawing.Size(672, 776);
            this.dataFromSql.TabIndex = 4;
            // 
            // buttonAddMappingToGraph
            // 
            this.buttonAddMappingToGraph.Location = new System.Drawing.Point(52, 27);
            this.buttonAddMappingToGraph.Name = "buttonAddMappingToGraph";
            this.buttonAddMappingToGraph.Size = new System.Drawing.Size(213, 43);
            this.buttonAddMappingToGraph.TabIndex = 5;
            this.buttonAddMappingToGraph.Text = "Add New Mapping";
            this.buttonAddMappingToGraph.UseVisualStyleBackColor = true;
            this.buttonAddMappingToGraph.Click += new System.EventHandler(this.buttonAddMappingToGraph_Click);
            // 
            // buttonRunOneSQL
            // 
            this.buttonRunOneSQL.Location = new System.Drawing.Point(1861, 423);
            this.buttonRunOneSQL.Name = "buttonRunOneSQL";
            this.buttonRunOneSQL.Size = new System.Drawing.Size(213, 43);
            this.buttonRunOneSQL.TabIndex = 6;
            this.buttonRunOneSQL.Text = "Run Current SQL Script";
            this.buttonRunOneSQL.UseVisualStyleBackColor = true;
            this.buttonRunOneSQL.Click += new System.EventHandler(this.buttonRunOneSQL_Click);
            // 
            // buttonRunAllSQLInGraph
            // 
            this.buttonRunAllSQLInGraph.Location = new System.Drawing.Point(1162, 1256);
            this.buttonRunAllSQLInGraph.Name = "buttonRunAllSQLInGraph";
            this.buttonRunAllSQLInGraph.Size = new System.Drawing.Size(213, 43);
            this.buttonRunAllSQLInGraph.TabIndex = 7;
            this.buttonRunAllSQLInGraph.Text = "Run all Scripts from List";
            this.buttonRunAllSQLInGraph.UseVisualStyleBackColor = true;
            this.buttonRunAllSQLInGraph.Click += new System.EventHandler(this.buttonRunAllSQLInGraph_Click);
            // 
            // buttonSaveEventLog
            // 
            this.buttonSaveEventLog.Location = new System.Drawing.Point(1862, 1256);
            this.buttonSaveEventLog.Name = "buttonSaveEventLog";
            this.buttonSaveEventLog.Size = new System.Drawing.Size(213, 43);
            this.buttonSaveEventLog.TabIndex = 8;
            this.buttonSaveEventLog.Text = "Save Event Log Data";
            this.buttonSaveEventLog.UseVisualStyleBackColor = true;
            this.buttonSaveEventLog.Click += new System.EventHandler(this.buttonSaveEventLog_Click);
            // 
            // buttonSaveAll
            // 
            this.buttonSaveAll.Location = new System.Drawing.Point(1643, 1256);
            this.buttonSaveAll.Name = "buttonSaveAll";
            this.buttonSaveAll.Size = new System.Drawing.Size(213, 43);
            this.buttonSaveAll.TabIndex = 9;
            this.buttonSaveAll.Text = "Save Mapping to file";
            this.buttonSaveAll.UseVisualStyleBackColor = true;
            this.buttonSaveAll.Click += new System.EventHandler(this.buttonSaveAll_Click);
            // 
            // comboBoxSelectDbConnection
            // 
            this.comboBoxSelectDbConnection.FormattingEnabled = true;
            this.comboBoxSelectDbConnection.Location = new System.Drawing.Point(1620, 431);
            this.comboBoxSelectDbConnection.Name = "comboBoxSelectDbConnection";
            this.comboBoxSelectDbConnection.Size = new System.Drawing.Size(235, 28);
            this.comboBoxSelectDbConnection.TabIndex = 10;
            this.comboBoxSelectDbConnection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBoxSelectDbConnection_MouseDown);
            // 
            // buttonNewConnectionString
            // 
            this.buttonNewConnectionString.Location = new System.Drawing.Point(1401, 423);
            this.buttonNewConnectionString.Name = "buttonNewConnectionString";
            this.buttonNewConnectionString.Size = new System.Drawing.Size(213, 43);
            this.buttonNewConnectionString.TabIndex = 11;
            this.buttonNewConnectionString.Text = "Manage Connections";
            this.buttonNewConnectionString.UseVisualStyleBackColor = true;
            this.buttonNewConnectionString.Click += new System.EventHandler(this.buttonNewConnectionString_Click);
            // 
            // rtbRegulatoryRules
            // 
            this.rtbRegulatoryRules.Location = new System.Drawing.Point(13, 60);
            this.rtbRegulatoryRules.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbRegulatoryRules.Name = "rtbRegulatoryRules";
            this.rtbRegulatoryRules.Size = new System.Drawing.Size(673, 355);
            this.rtbRegulatoryRules.TabIndex = 12;
            this.rtbRegulatoryRules.Text = "";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(1424, 1256);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(213, 43);
            this.buttonReset.TabIndex = 13;
            this.buttonReset.Text = "Clear All";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Visible = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonImportDCREvents
            // 
            this.buttonImportDCREvents.Location = new System.Drawing.Point(16, 1256);
            this.buttonImportDCREvents.Name = "buttonImportDCREvents";
            this.buttonImportDCREvents.Size = new System.Drawing.Size(213, 43);
            this.buttonImportDCREvents.TabIndex = 14;
            this.buttonImportDCREvents.Text = "Import Events from XML";
            this.buttonImportDCREvents.UseVisualStyleBackColor = true;
            this.buttonImportDCREvents.Click += new System.EventHandler(this.buttonImportDCREvents_Click);
            // 
            // dataGridViewEvents
            // 
            this.dataGridViewEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EventID,
            this.EventLabel,
            this.Rule,
            this.Screnshot,
            this.Sql,
            this.IsComplete,
            this.Delete});
            this.dataGridViewEvents.Location = new System.Drawing.Point(16, 523);
            this.dataGridViewEvents.Name = "dataGridViewEvents";
            this.dataGridViewEvents.RowHeadersWidth = 62;
            this.dataGridViewEvents.RowTemplate.Height = 28;
            this.dataGridViewEvents.Size = new System.Drawing.Size(1359, 727);
            this.dataGridViewEvents.TabIndex = 15;
            this.dataGridViewEvents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEvents_CellContentClick);
            this.dataGridViewEvents.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEvents_CellEndEdit);
            this.dataGridViewEvents.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEvents_CellValueChanged);
            this.dataGridViewEvents.SelectionChanged += new System.EventHandler(this.dataGridViewEvents_SelectionChanged);
            // 
            // EventID
            // 
            this.EventID.HeaderText = "Event ID";
            this.EventID.MinimumWidth = 8;
            this.EventID.Name = "EventID";
            this.EventID.Width = 150;
            // 
            // EventLabel
            // 
            this.EventLabel.HeaderText = "Event Label";
            this.EventLabel.MinimumWidth = 8;
            this.EventLabel.Name = "EventLabel";
            this.EventLabel.Width = 150;
            // 
            // Rule
            // 
            this.Rule.HeaderText = "Rule";
            this.Rule.MinimumWidth = 8;
            this.Rule.Name = "Rule";
            this.Rule.Width = 150;
            // 
            // Screnshot
            // 
            this.Screnshot.HeaderText = "Screenshot";
            this.Screnshot.MinimumWidth = 8;
            this.Screnshot.Name = "Screnshot";
            this.Screnshot.Width = 150;
            // 
            // Sql
            // 
            this.Sql.HeaderText = "Sql";
            this.Sql.MinimumWidth = 8;
            this.Sql.Name = "Sql";
            this.Sql.Width = 150;
            // 
            // IsComplete
            // 
            this.IsComplete.HeaderText = "IsComplete";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Add Domain Event";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(702, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Add Screenshot";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1398, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 30);
            this.label5.TabIndex = 22;
            this.label5.Text = "Add SQL Script";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddSql);
            this.groupBox1.Controls.Add(this.btnAddScreenshot);
            this.groupBox1.Controls.Add(this.btnAddRule);
            this.groupBox1.Location = new System.Drawing.Point(16, 431);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(670, 86);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add individual elements to list at selected rows";
            // 
            // btnAddSql
            // 
            this.btnAddSql.Location = new System.Drawing.Point(451, 27);
            this.btnAddSql.Name = "btnAddSql";
            this.btnAddSql.Size = new System.Drawing.Size(213, 43);
            this.btnAddSql.TabIndex = 26;
            this.btnAddSql.Text = "Add SQL Script";
            this.btnAddSql.UseVisualStyleBackColor = true;
            this.btnAddSql.Click += new System.EventHandler(this.btnAddSql_Click);
            // 
            // btnAddScreenshot
            // 
            this.btnAddScreenshot.Location = new System.Drawing.Point(229, 27);
            this.btnAddScreenshot.Name = "btnAddScreenshot";
            this.btnAddScreenshot.Size = new System.Drawing.Size(213, 43);
            this.btnAddScreenshot.TabIndex = 25;
            this.btnAddScreenshot.Text = "Add Screenshot";
            this.btnAddScreenshot.UseVisualStyleBackColor = true;
            this.btnAddScreenshot.Click += new System.EventHandler(this.btnAddScreenshot_Click);
            // 
            // btnAddRule
            // 
            this.btnAddRule.Location = new System.Drawing.Point(10, 27);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(213, 43);
            this.btnAddRule.TabIndex = 24;
            this.btnAddRule.Text = "Add Domain Event";
            this.btnAddRule.UseVisualStyleBackColor = true;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonAddMappingToGraph);
            this.groupBox2.Location = new System.Drawing.Point(866, 431);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 86);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add all 3 elements to list at selected rows";
            // 
            // Mapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2093, 1316);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewEvents);
            this.Controls.Add(this.buttonImportDCREvents);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.rtbRegulatoryRules);
            this.Controls.Add(this.buttonNewConnectionString);
            this.Controls.Add(this.comboBoxSelectDbConnection);
            this.Controls.Add(this.buttonSaveAll);
            this.Controls.Add(this.buttonSaveEventLog);
            this.Controls.Add(this.buttonRunAllSQLInGraph);
            this.Controls.Add(this.buttonRunOneSQL);
            this.Controls.Add(this.dataFromSql);
            this.Controls.Add(this.richtbDbQuery);
            this.Controls.Add(this.pbScreenshot);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Mapping";
            this.Text = "Mapping";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mapping_FormClosing);
            this.Load += new System.EventHandler(this.Mapping_Load);
            this.Shown += new System.EventHandler(this.Mapping_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataFromSql)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbScreenshot;
        private System.Windows.Forms.RichTextBox richtbDbQuery;
        private System.Windows.Forms.DataGridView dataFromSql;
        private System.Windows.Forms.Button buttonAddMappingToGraph;
        private System.Windows.Forms.Button buttonRunOneSQL;
        private System.Windows.Forms.Button buttonRunAllSQLInGraph;
        private System.Windows.Forms.Button buttonSaveEventLog;
        private System.Windows.Forms.Button buttonSaveAll;
        private System.Windows.Forms.ComboBox comboBoxSelectDbConnection;
        private System.Windows.Forms.Button buttonNewConnectionString;
        private System.Windows.Forms.RichTextBox rtbRegulatoryRules;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonImportDCREvents;
        private System.Windows.Forms.DataGridView dataGridViewEvents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rule;
        private System.Windows.Forms.DataGridViewImageColumn Screnshot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sql;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsComplete;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddSql;
        private System.Windows.Forms.Button btnAddScreenshot;
        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}