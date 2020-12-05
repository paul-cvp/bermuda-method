using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Bermuda.Connector;
using Bermuda.Model;
using Newtonsoft.Json;

namespace Bermuda
{
    public partial class Mapping : Form
    {
        public Mapping()
        {
            InitializeComponent();
            comboBoxSelectDbConnection.DataSource = ApplicationContext.Instance.connectionStrings.ToList();
            comboBoxSelectDbConnection.DisplayMember = "Key";
            comboBoxSelectDbConnection.ValueMember = "Value";
            if (comboBoxSelectDbConnection.Items.Count > 1)
            {
                comboBoxSelectDbConnection.SelectedIndex = 1;
            }
            var screenShot = ApplicationContext.Instance.currentDK?.ScreenshotImage?.ImageData;
            if (screenShot != null)
                pbScreenshot.Image = screenShot;
            else
            {
                //https://stackoverflow.com/questions/6311545/c-sharp-write-text-on-bitmap
                Bitmap bmp = new Bitmap(500, 400);
                RectangleF rectf = new RectangleF(50, 50, 300, 300);
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawString("Click here to take a screenshot", new Font("Calibri", 16), Brushes.Black, rectf);

                g.Flush();
                pbScreenshot.Image = bmp;
            }
            dataGridViewEvents.AllowUserToAddRows = true;
            dataGridViewEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEvents.AllowUserToDeleteRows = true;
            dataFromSql.AllowUserToDeleteRows = false;
            dataFromSql.AllowUserToAddRows = false;
            dataFromSql.ReadOnly = true;
        }

        private Image ByteArrayToImage(byte[] imageBytes)
        {
            using (MemoryStream mStream = new MemoryStream(imageBytes))
            {
                return Image.FromStream(mStream);
            }
        }

        private void pbScreenshot_Click(object sender, EventArgs e)
        {
            SelectArea area = new SelectArea();
            this.Hide();
            area.ShowDialog();
            var screenShot = ApplicationContext.Instance.currentDK?.ScreenshotImage?.ImageData;
            if (screenShot != null)
                pbScreenshot.Image = screenShot;
            this.Show();
        }

        private void Mapping_FormClosing(object sender, FormClosingEventArgs e)
        {
            LocalSettings.SaveToLocalSettings("ConnStrings", ApplicationContext.Instance.connectionStrings);
            if (richtbDbQuery.Text.Length > 0)
            {
                LocalSettings.SaveToLocalSettings("LastSql", richtbDbQuery.Text);
            }
            else
            {
                LocalSettings.ResetKey("LastSql");
            }
            if (rtbRegulatoryRules.Text.Length > 0)
            {
                LocalSettings.SaveToLocalSettings("LastLaw", rtbRegulatoryRules.Text);
            }
            else
            {
                LocalSettings.ResetKey("LastLaw");
            }
            if (pbScreenshot.Image != null)
            {
                LocalSettings.SaveToLocalSettings("LastImage", pbScreenshot.ImageLocation);
            }
            else
            {
                LocalSettings.ResetKey("LastImage");
            }
            if (dataGridViewEvents.Rows.Count > 0 && dataGridViewEvents.Rows[0].Index != dataGridViewEvents.NewRowIndex)
            {
                
                DataSet ds = new DataSet();
                ds.Tables.Add(WriteTodDataTable());
                LocalSettings.SaveToLocalSettings("LastDataSet", ds);
            } else
            {
                LocalSettings.ResetKey("LastDataSet");
            }
            Application.Exit();
        }

        private DataTable WriteTodDataTable()
        {
            DataTable dataTable = new DataTable();
            //create columns
            for (int i = 0; i < dataGridViewEvents.Columns.Count; i++)
            {
                dataTable.Columns.Add(dataGridViewEvents.Columns[i].HeaderText);
            }
            dataTable.Columns[3].DataType = typeof(byte[]);

            //populate data
            foreach (DataGridViewRow row in dataGridViewEvents.Rows)
            {
                if (row.Index != dataGridViewEvents.NewRowIndex)
                {
                    DataRow dr = dataTable.NewRow();
                    for (int j = 0; j < dataGridViewEvents.Columns.Count; j++)
                    {
                        if (j == 3 && (row.Cells[j].Value is Image))
                        {
                            dr[j] = imageToByteArray((System.Drawing.Image)row.Cells[j].Value);
                        }
                        else
                        {
                            var value = row.Cells[j].Value;
                            if (value is DBNull)
                            {
                                dr[j] = null;
                            }
                            else
                            {
                                dr[j] = value;
                            }
                        }
                    }

                    dataTable.Rows.Add(dr);
                }
            }

            return dataTable;
        }

        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            var img = new Bitmap(imageIn);
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void buttonNewConnectionString_Click(object sender, EventArgs e)
        {
            ConnectionString cs = new ConnectionString();
            cs.Show();
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

        private void buttonRunAllSQLInGraph_Click(object sender, EventArgs e)
        {
            string fullQuery = "";
            foreach(DataGridViewRow row in dataGridViewEvents.Rows)
            {
                fullQuery+=(string)row.Cells[4].Value+Environment.NewLine;
            }
            DataTableCollection res = DatabaseInspect.RunScript(fullQuery, (string)comboBoxSelectDbConnection.SelectedValue).Tables;
            DataTable dtRes = new DataTable();
            for (int i = 0; i < res.Count; i++)
            {
                dtRes.Merge(res[i]);
            }
            dataFromSql.DataSource = dtRes;
            ApplicationContext.Instance.ConcatenatedData = dtRes;
        }

        private void buttonSaveAll_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JSON|*.json";
            saveFileDialog1.Title = "Save a data File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                var dk = GetDomainKnowledge();
                File.WriteAllText(saveFileDialog1.FileName, JsonConvert.SerializeObject(dk));
            }
        }

        private List<DomainKnowledge> GetDomainKnowledge()
        {
            List<int> incompleteRowIdx = new List<int>();
            List<DomainKnowledge> listDk = new List<DomainKnowledge>();
            foreach (DataGridViewRow row in dataGridViewEvents.Rows)
            {
                if (row.Index != dataGridViewEvents.NewRowIndex)
                {
                    if (bool.Parse(row.Cells[5].Value.ToString()))
                    {
                        Event ev = new Event((string)row.Cells[0].Value, (string)row.Cells[1].Value);
                        RegulatoryRule rr = new RegulatoryRule((string)row.Cells[2].Value);
                        if (row.Cells[3].Value is byte[])
                        {
                            row.Cells[3].Value = ByteArrayToImage((byte[]) row.Cells[3].Value);
                        }
                        Screenshot ss = new Screenshot((Image)row.Cells[3].Value);
                        SqlScript sql = new SqlScript((string)row.Cells[4].Value);
                        listDk.Add(new DomainKnowledge(ss, rr, sql, ev));
                    }
                    else
                    {
                        incompleteRowIdx.Add(row.Index);
                    }
                }
            }
            return listDk;
        }

        private void buttonSaveEventLog_Click(object sender, EventArgs e)
        {
            var dt = ApplicationContext.Instance.ConcatenatedData;
            if (dt != null)
            {
                // Displays a SaveFileDialog so the user can save the Image
                // assigned to Button2.
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "CSV|*.csv";
                saveFileDialog1.Title = "Save a data File";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {                //https://stackoverflow.com/questions/4959722/c-sharp-datatable-to-csv
                    StringBuilder sb = new StringBuilder();

                    IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                                      Select(column => column.ColumnName);
                    sb.AppendLine(string.Join(",", columnNames));

                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    //    sb.AppendLine(string.Join(",", fields));
                    //}
                    //to handle escaping special characters
                    foreach (DataRow row in dt.Rows)
                    {
                        IEnumerable<string> fields = row.ItemArray.Select(field =>
                          string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                        sb.AppendLine(string.Join(",", fields));
                    }
                    File.WriteAllText(saveFileDialog1.FileName, sb.ToString());
                }

            } else
            {
                MessageBox.Show("Press run all scripts from list first!");
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            //ApplicationContext.Instance.ClearOnlyDomainKnowledge();
        }

        private void comboBoxSelectDbConnection_MouseDown(object sender, MouseEventArgs e)
        {
            comboBoxSelectDbConnection.DataSource = ApplicationContext.Instance.connectionStrings.ToList();
        }

        private void Mapping_Load(object sender, EventArgs e)
        {
            string lastSql = LocalSettings.GetDataFromLocalSettings("LastSql");
            string lastLaw = LocalSettings.GetDataFromLocalSettings("LastLaw");
            string lastImage = LocalSettings.GetDataFromLocalSettings("LastImage");
            DataSet lastDataSet = (DataSet) LocalSettings.GetDataFromLocalSettings<DataSet>("LastDataSet");
            if (lastSql?.Length > 0)
            {
                this.richtbDbQuery.Text = lastSql;
            }
            if (lastLaw?.Length > 0)
            {
                this.rtbRegulatoryRules.Text = lastLaw;
            }
            if (File.Exists(lastImage))
            {
                this.pbScreenshot.ImageLocation = lastImage;
            }
            if (lastDataSet != null && lastDataSet?.Tables[0]?.Rows.Count > 0)
            {
                DataRowCollection drc = lastDataSet.Tables[0].Rows;
                foreach (DataRow row in drc)
                {
                    object[] rowItems = row.ItemArray;
                    if (rowItems[3] != System.DBNull.Value && rowItems[3] != null)
                    {
                        using (var ms = new MemoryStream((byte[])rowItems[3]))
                        {
                            rowItems[3] = Image.FromStream(ms);
                        }
                    }
                    rowItems[5] = bool.Parse(rowItems[5].ToString());
                    if (rowItems[0]==DBNull.Value)
                    {
                        rowItems[0] = null;
                    }
                    if (rowItems[1] == DBNull.Value)
                    {
                        rowItems[1] = null;
                    }
                    if (rowItems[2] == DBNull.Value)
                    {
                        rowItems[2] = null;
                    }
                    if (rowItems[4] == DBNull.Value)
                    {
                        rowItems[4] = null;
                    }
                    int idx = this.dataGridViewEvents.Rows.Add(row.ItemArray);
                    if ((bool)rowItems[5])
                    {
                        dataGridViewEvents.Rows[idx].Cells[5].Style.BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        dataGridViewEvents.Rows[idx].Cells[5].Style.BackColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void buttonImportDCREvents_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDcr = new OpenFileDialog();
            if (openDcr.ShowDialog() == DialogResult.OK)
            {
                var filePath = openDcr.FileName;
                var events = DcrXmlParser.GetEventsFromDcr(filePath);
                //ApplicationContext.Instance.Events = events;
                foreach (var ev in events)
                {
                    var row = new object[] { ev.EventID, ev.EventLabel, null, null, null, false };
                    int rowIdx = dataGridViewEvents.Rows.Add(row);
                    dataGridViewEvents.Rows[rowIdx].Cells[5].Style.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        private void dataGridViewEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = e.RowIndex; //the event
            var column = e.ColumnIndex; // column = what was clicked
            if (column == 6)
            {
                var dialogResult = MessageBox.Show("Delete row " + (row + 1) + " " + dataGridViewEvents.Rows[row].Cells[0].Value + " ?", "Deleting row", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        dataGridViewEvents.Rows.RemoveAt(row);
                    } catch (Exception ex)
                    {

                    }
                }
            }
            else if (column == 5)
            {
                //check what is still missing
            }
        }

        private void buttonAddMappingToGraph_Click(object sender, EventArgs e)
        {

            if (dataGridViewEvents.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewEvents.SelectedRows)
                {
                    row.Cells[2].Value = rtbRegulatoryRules.Text;
                    row.Cells[3].Value = pbScreenshot.Image;
                    row.Cells[4].Value = richtbDbQuery.Text;
                }
            }
            else
            {
                //add new row
                int newRowIdx = dataGridViewEvents.Rows.Add();
                dataGridViewEvents.Rows[newRowIdx].Cells[2].Value = rtbRegulatoryRules.Text;
                dataGridViewEvents.Rows[newRowIdx].Cells[3].Value = pbScreenshot.Image;
                dataGridViewEvents.Rows[newRowIdx].Cells[4].Value = richtbDbQuery.Text;
            }

        }
        private void btnAddRule_Click(object sender, EventArgs e)
        {
            if (dataGridViewEvents.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewEvents.SelectedRows)
                {
                    row.Cells[2].Value = rtbRegulatoryRules.Text;
                }
            }
            else if (dataGridViewEvents.CurrentCell != null && !dataGridViewEvents.CurrentRow.IsNewRow && dataGridViewEvents.CurrentCell.ColumnIndex==2)
            {
                dataGridViewEvents.CurrentRow.Cells[2].Value = rtbRegulatoryRules.Text;
            } else
            {
                //add new row
                int newRowIdx = dataGridViewEvents.Rows.Add();
                dataGridViewEvents.Rows[newRowIdx].Cells[2].Value = rtbRegulatoryRules.Text;
            }
        }

        private void btnAddScreenshot_Click(object sender, EventArgs e)
        {

            if (dataGridViewEvents.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewEvents.SelectedRows)
                {
                    row.Cells[3].Value = pbScreenshot.Image;
                }
            }
            else if (dataGridViewEvents.CurrentCell != null && !dataGridViewEvents.CurrentRow.IsNewRow && dataGridViewEvents.CurrentCell.ColumnIndex == 3)
            {
                dataGridViewEvents.CurrentRow.Cells[3].Value = pbScreenshot.Image;
            }
            else
            {
                //add new row
                int newRowIdx = dataGridViewEvents.Rows.Add();
                dataGridViewEvents.Rows[newRowIdx].Cells[3].Value = pbScreenshot.Image;
            }
        }

        private void btnAddSql_Click(object sender, EventArgs e)
        {

            if (dataGridViewEvents.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewEvents.SelectedRows)
                {
                    row.Cells[4].Value = richtbDbQuery.Text;
                }
            }
            else if (dataGridViewEvents.CurrentCell!=null && !dataGridViewEvents.CurrentRow.IsNewRow && dataGridViewEvents.CurrentCell.ColumnIndex == 4)
            {
                dataGridViewEvents.CurrentRow.Cells[4].Value = richtbDbQuery.Text;
            } else
            {
                //add new row
                int newRowIdx = dataGridViewEvents.Rows.Add();
                dataGridViewEvents.Rows[newRowIdx].Cells[4].Value = richtbDbQuery.Text;
            }
        }

        private void dataGridViewEvents_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var row = e.RowIndex;
            if (row >= 0)
            {
                if (IsRowComplete(row))
                {
                    dataGridViewEvents.Rows[row].Cells[5].Value = true;
                    dataGridViewEvents.Rows[row].Cells[5].Style.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    dataGridViewEvents.Rows[row].Cells[5].Value = false;
                    dataGridViewEvents.Rows[row].Cells[5].Style.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        private void dataGridViewEvents_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = e.RowIndex;
            var column = e.ColumnIndex;
            
            if (column == 0 || column == 1)
            {
                if (dataGridViewEvents.Rows[row].Cells[column].Value == DBNull.Value)
                    dataGridViewEvents.Rows[row].Cells[column].Value = null;
                var cellToCheck = (string)dataGridViewEvents.Rows[row].Cells[column].Value;
                if (cellToCheck != null && cellToCheck.Length > 0 && IsGridValueDuplicate(cellToCheck, column, row))
                {
                    MessageBox.Show("Please fill in the Event ID and Label and make sure it's not the same as an existing ones ID and Label!");
                    dataGridViewEvents.Rows[row].Cells[column].Value = null;
                }
            }
        }

        private bool IsRowComplete(int row)
        {
            bool complete = true;
            for (int i = 0; i < dataGridViewEvents.Columns.Count-2; i++)
            {
                complete &= (dataGridViewEvents.Rows[row].Cells[i].Value != null);
            }
            return complete;
        }

        private bool IsGridValueDuplicate(string value, int column, int rowToIgnore)
        {
            for (int i = 0; i < dataGridViewEvents.Rows.Count; i++)
            {
                if (dataGridViewEvents.Rows[i].Cells[column].Value == DBNull.Value)
                {
                    dataGridViewEvents.Rows[i].Cells[column].Value = null;
                }
                if (i != rowToIgnore && ((string)dataGridViewEvents.Rows[i].Cells[column].Value) == value)
                {
                    return true;
                }
            }
            return false;
        }

        private void dataGridViewEvents_SelectionChanged(object sender, EventArgs e)
        {
            int row = dataGridViewEvents.CurrentCell.RowIndex;
            int column = dataGridViewEvents.CurrentCell.ColumnIndex;
            var rule = dataGridViewEvents.Rows[row].Cells[2].Value;
            var screen = dataGridViewEvents.Rows[row].Cells[3].Value;
            var sql = dataGridViewEvents.Rows[row].Cells[4].Value;
            //rtbRegulatoryRules.Text = (string) rule;
            //pbScreenshot.Image = (Image) screen;
            //richtbDbQuery.Text = (string) sql;
        }

        private void Mapping_Shown(object sender, EventArgs e)
        {
            var screenShot = ApplicationContext.Instance.currentDK?.ScreenshotImage?.ImageData;
            if (screenShot != null)
                pbScreenshot.Image = screenShot;
            else
            {
                //https://stackoverflow.com/questions/6311545/c-sharp-write-text-on-bitmap
                Bitmap bmp = new Bitmap(500, 400);
                RectangleF rectf = new RectangleF(50, 50, 300, 300);
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawString("Click here to take a screenshot", new Font("Calibri", 16), Brushes.Black, rectf);

                g.Flush();
                pbScreenshot.Image = bmp;
            }
        }
    }
}
