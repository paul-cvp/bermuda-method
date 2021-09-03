
namespace Bermuda
{
    partial class SqlConnect
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
            this.buttonSaveEventLog = new System.Windows.Forms.Button();
            this.dataFromSql = new System.Windows.Forms.DataGridView();
            this.buttonNewConnectionString = new System.Windows.Forms.Button();
            this.comboBoxSelectDbConnection = new System.Windows.Forms.ComboBox();
            this.buttonRunOneSQL = new System.Windows.Forms.Button();
            this.richtbDbQuery = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataFromSql)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSaveEventLog
            // 
            this.buttonSaveEventLog.Location = new System.Drawing.Point(715, 424);
            this.buttonSaveEventLog.Name = "buttonSaveEventLog";
            this.buttonSaveEventLog.Size = new System.Drawing.Size(213, 43);
            this.buttonSaveEventLog.TabIndex = 35;
            this.buttonSaveEventLog.Text = "Save Event Log Data";
            this.buttonSaveEventLog.UseVisualStyleBackColor = true;
            this.buttonSaveEventLog.Click += new System.EventHandler(this.buttonSaveEventLog_Click);
            // 
            // dataFromSql
            // 
            this.dataFromSql.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFromSql.Location = new System.Drawing.Point(948, 12);
            this.dataFromSql.Name = "dataFromSql";
            this.dataFromSql.ReadOnly = true;
            this.dataFromSql.RowHeadersWidth = 62;
            this.dataFromSql.RowTemplate.Height = 28;
            this.dataFromSql.Size = new System.Drawing.Size(672, 357);
            this.dataFromSql.TabIndex = 33;
            // 
            // buttonNewConnectionString
            // 
            this.buttonNewConnectionString.Location = new System.Drawing.Point(12, 110);
            this.buttonNewConnectionString.Name = "buttonNewConnectionString";
            this.buttonNewConnectionString.Size = new System.Drawing.Size(213, 43);
            this.buttonNewConnectionString.TabIndex = 32;
            this.buttonNewConnectionString.Text = "Manage Connections";
            this.buttonNewConnectionString.UseVisualStyleBackColor = true;
            this.buttonNewConnectionString.Click += new System.EventHandler(this.buttonNewConnectionString_Click);
            // 
            // comboBoxSelectDbConnection
            // 
            this.comboBoxSelectDbConnection.FormattingEnabled = true;
            this.comboBoxSelectDbConnection.Location = new System.Drawing.Point(12, 160);
            this.comboBoxSelectDbConnection.Name = "comboBoxSelectDbConnection";
            this.comboBoxSelectDbConnection.Size = new System.Drawing.Size(235, 28);
            this.comboBoxSelectDbConnection.TabIndex = 31;
            this.comboBoxSelectDbConnection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBoxSelectDbConnection_MouseDown);
            // 
            // buttonRunOneSQL
            // 
            this.buttonRunOneSQL.Location = new System.Drawing.Point(12, 212);
            this.buttonRunOneSQL.Name = "buttonRunOneSQL";
            this.buttonRunOneSQL.Size = new System.Drawing.Size(213, 43);
            this.buttonRunOneSQL.TabIndex = 36;
            this.buttonRunOneSQL.Text = "Run Current SQL Script";
            this.buttonRunOneSQL.UseVisualStyleBackColor = true;
            this.buttonRunOneSQL.Click += new System.EventHandler(this.buttonRunOneSQL_Click);
            // 
            // richtbDbQuery
            // 
            this.richtbDbQuery.Location = new System.Drawing.Point(254, 14);
            this.richtbDbQuery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richtbDbQuery.Name = "richtbDbQuery";
            this.richtbDbQuery.Size = new System.Drawing.Size(673, 355);
            this.richtbDbQuery.TabIndex = 37;
            this.richtbDbQuery.Text = "";
            // 
            // SqlConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1648, 644);
            this.Controls.Add(this.richtbDbQuery);
            this.Controls.Add(this.buttonRunOneSQL);
            this.Controls.Add(this.buttonSaveEventLog);
            this.Controls.Add(this.dataFromSql);
            this.Controls.Add(this.buttonNewConnectionString);
            this.Controls.Add(this.comboBoxSelectDbConnection);
            this.Name = "SqlConnect";
            this.Text = "SqlConnect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SqlConnect_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataFromSql)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveEventLog;
        private System.Windows.Forms.DataGridView dataFromSql;
        private System.Windows.Forms.Button buttonNewConnectionString;
        private System.Windows.Forms.ComboBox comboBoxSelectDbConnection;
        private System.Windows.Forms.Button buttonRunOneSQL;
        private System.Windows.Forms.RichTextBox richtbDbQuery;
    }
}