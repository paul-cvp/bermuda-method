using Bermuda.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bermuda
{
    public partial class SqlConnect : Form
    {
        public SqlConnect(string sql)
        {
            InitializeComponent();

            richtbDbQuery.Text = sql;

            dataFromSql.AllowUserToDeleteRows = false;
            dataFromSql.AllowUserToAddRows = false;
            dataFromSql.ReadOnly = true;


            //if (ApplicationContext.Instance?.connectionStrings != null)
            //{
            comboBoxSelectDbConnection.DataSource = ApplicationContext.Instance?.connectionStrings?.ToList();
            comboBoxSelectDbConnection.DisplayMember = "Key";
            comboBoxSelectDbConnection.ValueMember = "Value";
            if (comboBoxSelectDbConnection.Items.Count > 1)
            {
                comboBoxSelectDbConnection.SelectedIndex = 1;
            }
            //}
            }

        private void buttonRunOneSQL_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectDbConnection.SelectedValue != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    var data = DatabaseInspect.RunScript(richtbDbQuery.Text, (string)comboBoxSelectDbConnection.SelectedValue);
                    dataFromSql.DataSource = data.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error running the script! Error Message: " + ex.Message, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please select connection!");
            }
        }

        private void comboBoxSelectDbConnection_MouseDown(object sender, MouseEventArgs e)
        {
            comboBoxSelectDbConnection.DataSource = ApplicationContext.Instance.connectionStrings.ToList();
        }
        private void buttonSaveEventLog_Click(object sender, EventArgs e)
        {
            if (dataFromSql.Rows.Count > 0)
            {
                var sb = new StringBuilder();

                var headers = dataFromSql.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(";", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

                foreach (DataGridViewRow row in dataFromSql.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();
                    sb.AppendLine(string.Join(";", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
                }

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "CSV|*.csv";
                saveFileDialog1.Title = "Save to CSV";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    File.WriteAllText(saveFileDialog1.FileName, sb.ToString());
                }
            }
            else
            {
                MessageBox.Show("No rows to save! Please run query first!", "Error", MessageBoxButtons.OK);
            }
        }

        private void SqlConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void buttonNewConnectionString_Click(object sender, EventArgs e)
        {
            ConnectionString cs = new ConnectionString();
            cs.Show();
        }

    }
}
