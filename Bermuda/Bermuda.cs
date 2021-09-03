using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class Bermuda : Form
    {
        public bool DoNotExit { get; set; }
        public readonly Bitmap defaultScreenshot;
        public Bermuda(UserRole role)
        {
            this.DoNotExit = false;
            InitializeComponent();
            tabBermuda.TabPages.Clear();
            switch (role)
            {
                case UserRole.DataScientist:
                    {
                        tabBermuda.TabPages.Add(this.tabPageDomain);
                        tabBermuda.TabPages.Add(this.tabPageUI);
                        tabBermuda.TabPages.Add(this.tabPageData);
                        dataGridViewEvents.Columns[2].Visible = true;
                        dataGridViewEvents.Columns[3].Visible = true;
                        dataGridViewEvents.Columns[4].Visible = true;
                        dataConnectionToolStripMenuItem.Visible = true;
                        break;
                    }
                case UserRole.Developer:
                    {
                        tabBermuda.TabPages.Add(this.tabPageUI);
                        tabBermuda.TabPages.Add(this.tabPageData);
                        dataGridViewEvents.Columns[2].Visible = false;
                        dataGridViewEvents.Columns[3].Visible = true;
                        dataGridViewEvents.Columns[4].Visible = true;

                        btnAddRule.Visible = false;
                        groupBoxAddAll3.Visible = false;
                        dataConnectionToolStripMenuItem.Visible = true;
                        break;
                    }
                case UserRole.DomainExpert:
                    {
                        tabBermuda.TabPages.Add(this.tabPageDomain);
                        tabBermuda.TabPages.Add(this.tabPageUI);
                        dataGridViewEvents.Columns[2].Visible = true;
                        dataGridViewEvents.Columns[3].Visible = true;
                        dataGridViewEvents.Columns[4].Visible = false;

                        this.btnAddSql.Visible = false;
                        groupBoxAddAll3.Visible = false;
                        this.buttonRunAllSQLInGraph.Visible = false;
                        dataConnectionToolStripMenuItem.Visible = false;
                        break;
                    }
                default:
                    {
                        tabBermuda.TabPages.Add(this.tabPageDomain);
                        tabBermuda.TabPages.Add(this.tabPageUI);
                        tabBermuda.TabPages.Add(this.tabPageData);
                        dataGridViewEvents.Columns[2].Visible = true;
                        dataGridViewEvents.Columns[3].Visible = true;
                        dataGridViewEvents.Columns[4].Visible = true;
                        break;
                    }

            }
            dataGridViewEvents.Columns[2].ReadOnly = true;
            dataGridViewEvents.Columns[3].ReadOnly = true;
            dataGridViewEvents.Columns[4].ReadOnly = true;

            dataGridViewEvents.Columns[0].Visible = false;
            dataGridViewEvents.Columns[5].Visible = false;

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
                defaultScreenshot = bmp;
                pbScreenshot.Image = defaultScreenshot;
            }
            dataGridViewEvents.AllowUserToAddRows = true;
            dataGridViewEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEvents.AllowUserToDeleteRows = true;
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


        private void buttonSaveAll_Click(object sender, EventArgs e)
        {
            this.SaveMappingProject();
        }

        private void SaveMappingProject()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JSON|*.json";
            saveFileDialog1.Title = "Save Mapping Project";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                var dk = GetDomainKnowledge();
                File.WriteAllText(saveFileDialog1.FileName, JsonConvert.SerializeObject(dk));
            }
        }

        private void LoadMappingProject()
        {
            OpenFileDialog loadFileDialog1 = new OpenFileDialog();
            loadFileDialog1.Filter = "JSON|*.json";
            loadFileDialog1.Title = "Load Mapping Project";
            loadFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (loadFileDialog1.FileName != "")
            {
                List<DomainKnowledge> dk = JsonConvert.DeserializeObject<List<DomainKnowledge>>(File.ReadAllText(loadFileDialog1.FileName));
                foreach (var dkRow in dk)
                {
                    object[] rowToAdd = new object[6];
                    rowToAdd[0] = dkRow.Event?.EventID;
                    rowToAdd[1] = dkRow.Event?.EventLabel;
                    rowToAdd[2] = dkRow.RegulatoryRule?.RuleText;
                    rowToAdd[3] = dkRow.ScreenshotImage?.ImageData;
                    rowToAdd[4] = dkRow.SqlScript?.Sql;
                    int idx = this.dataGridViewEvents.Rows.Add(rowToAdd);
                    if (IsRowComplete(idx)) {
                        dataGridViewEvents.Rows[idx].Cells[5].Value = true;
                    } else
                    {
                        dataGridViewEvents.Rows[idx].Cells[5].Value = false;
                    }
                }
            }
        }

        private List<DomainKnowledge> GetDomainKnowledge(bool saveIncompleteRows=true)
        {
            List<int> incompleteRowIdx = new List<int>();
            List<DomainKnowledge> listDk = new List<DomainKnowledge>();
            foreach (DataGridViewRow row in dataGridViewEvents.Rows)
            {
                if (row.Index != dataGridViewEvents.NewRowIndex)
                {
                    if ((saveIncompleteRows) || (bool.Parse(row.Cells[5].Value.ToString())))
                    {
                        string ev_id = null;
                        if (row.Cells[0].Value != DBNull.Value)
                        {
                            ev_id = (string)row.Cells[0].Value;
                        }
                        string ev_label = null;
                        if (row.Cells[1].Value != DBNull.Value)
                        {
                            ev_label = (string)row.Cells[1].Value;
                        }
                        Event ev = new Event(ev_id, ev_label);
                        
                        RegulatoryRule rr = null;
                        if (row.Cells[2].Value != DBNull.Value)
                        {
                            rr = new RegulatoryRule((string)row.Cells[2].Value);
                        }
                        if (row.Cells[3].Value is byte[])
                        {
                            row.Cells[3].Value = ByteArrayToImage((byte[])row.Cells[3].Value);
                        }
                        Screenshot ss = null;
                        if (row.Cells[3].Value != DBNull.Value)
                        {
                            ss = new Screenshot((Bitmap)row.Cells[3].Value);
                        }
                        SqlScript sql = null;
                        if (row.Cells[4].Value != DBNull.Value)
                        {
                            sql = new SqlScript((string)row.Cells[4].Value);
                        }
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

            }
            else
            {
                MessageBox.Show("Press run all scripts from list first!");
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ApplicationContext.Instance.ClearOnlyDomainKnowledge();
            dataGridViewEvents.Rows.Clear();
            pbScreenshot.Image = null;
            richtbDbQuery.Text = null;
            rtbRegulatoryRules.Text = null;
        }


        private void buttonImportDCREvents_Click(object sender, EventArgs e)
        {
            this.LoadDcrXml();
        }

        private void LoadDcrXml()
        {
            OpenFileDialog openDcr = new OpenFileDialog();
            if (openDcr.ShowDialog() == DialogResult.OK)
            {
                var filePath = openDcr.FileName;
                var events = DcrXmlParser.GetEventsFromDcr(filePath);
                //ApplicationContext.Instance.Events = events;
                foreach (var ev in events)
                {
                    var row = new object[] { ev.EventID, ev.EventLabel, null, null, null, false, ev.EventSequence };
                    int rowIdx = dataGridViewEvents.Rows.Add(row);
                    //dataGridViewEvents.Rows[rowIdx].Cells[1].Style.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        private void dataGridViewEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = e.RowIndex; //the event
            var column = e.ColumnIndex; // column = what was clicked
            switch (column) {
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                case 4:
                    {
                        break;
                    }
                case 5:
                    {
                        //check what is still missing
                        break;
                    }
                case 6:
                    {
                        var dialogResult = MessageBox.Show("Delete row " + (row + 1) + " " + dataGridViewEvents.Rows[row].Cells[1].Value + " ?", "Deleting row", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                dataGridViewEvents.Rows.RemoveAt(row);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        break;
                    }
                default:
                    break;
            }
        }


        private void dataGridViewEvents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = e.RowIndex; //the event
            var column = e.ColumnIndex; // column = what was clicked
            switch (column)
            {
                case 2:
                    {
                        //check and edit domain model
                        if (!string.IsNullOrWhiteSpace((string)dataGridViewEvents.Rows[row].Cells[column].Value))
                        {
                            rtbRegulatoryRules.Text = (string)dataGridViewEvents.Rows[row].Cells[column].Value;
                        }
                        break;
                    }
                case 3:
                    {
                        //check and edit screenshot
                        if (null != dataGridViewEvents.Rows[row].Cells[column].Value || defaultScreenshot != (Image)dataGridViewEvents.Rows[row].Cells[column].Value)
                        {
                            if (dataGridViewEvents.Rows[row].Cells[column].Value is Bitmap)
                            {
                                pbScreenshot.Image = (Bitmap)dataGridViewEvents.Rows[row].Cells[column].Value;
                            }
                            else
                            {
                                using (var ms = new MemoryStream((byte[])dataGridViewEvents.Rows[row].Cells[column].Value))
                                {
                                    pbScreenshot.Image = Image.FromStream(ms);
                                }
                            }
                        }
                        break;
                    }
                case 4:
                    {
                        //check and edit data location
                        //check and edit domain model
                        if (!string.IsNullOrWhiteSpace((string)dataGridViewEvents.Rows[row].Cells[column].Value))
                        {
                            richtbDbQuery.Text = (string)dataGridViewEvents.Rows[row].Cells[column].Value;
                        }
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                case 6:
                    {
                        break;
                    }
                default:
                    break;
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
            else if (dataGridViewEvents.CurrentCell != null && !dataGridViewEvents.CurrentRow.IsNewRow && dataGridViewEvents.CurrentCell.ColumnIndex == 2)
            {
                dataGridViewEvents.CurrentRow.Cells[2].Value = rtbRegulatoryRules.Text;
            }
            else
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
            else if (dataGridViewEvents.CurrentCell != null && !dataGridViewEvents.CurrentRow.IsNewRow && dataGridViewEvents.CurrentCell.ColumnIndex == 4)
            {
                dataGridViewEvents.CurrentRow.Cells[4].Value = richtbDbQuery.Text;
            }
            else
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
                    //dataGridViewEvents.Rows[row].Cells[5].Style.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    dataGridViewEvents.Rows[row].Cells[5].Value = false;
                    //dataGridViewEvents.Rows[row].Cells[5].Style.BackColor = System.Drawing.Color.Red;
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
            for (int i = 0; i < dataGridViewEvents.Columns.Count - 2; i++)
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

        private void Bermuda_Load(object sender, EventArgs e)
        {
            string lastSql = LocalSettings.GetDataFromLocalSettings("LastSql");
            string lastLaw = LocalSettings.GetDataFromLocalSettings("LastLaw");
            string lastImage = LocalSettings.GetDataFromLocalSettings("LastImage");
            DataSet lastDataSet = (DataSet)LocalSettings.GetDataFromLocalSettings<DataSet>("LastDataSet");
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

                    if (rowItems[5] != DBNull.Value && rowItems[5] != null)
                    {
                        rowItems[5] = bool.Parse(rowItems[5].ToString());
                    }
                    if (rowItems[0] == DBNull.Value)
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
                    //if ((bool)rowItems[5])
                    //{
                    //    dataGridViewEvents.Rows[idx].Cells[5].Style.BackColor = System.Drawing.Color.Green;
                    //}
                    //else
                    //{
                    //    dataGridViewEvents.Rows[idx].Cells[5].Style.BackColor = System.Drawing.Color.Red;
                    //}
                }
            }
        }
        private void Bermuda_Shown(object sender, EventArgs e)
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

        private void Bermuda_FormClosing(object sender, FormClosingEventArgs e)
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
            }
            else
            {
                LocalSettings.ResetKey("LastDataSet");
            }
            if (!this.DoNotExit)
            {
                Application.Exit();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.DoNotExit = true;
            this.Close();
            login.Show();
        }

        private void loadBPMNDomainModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog bpmnOfd = new OpenFileDialog();
            bpmnOfd.Filter = "Bpmn diagrams (*.bpmn)|*.bpmn";
            if (bpmnOfd.ShowDialog() == DialogResult.OK)
            {
                var filePath = bpmnOfd.FileName;
                var events = BpmnParser.GetEventsFromBpmn(filePath);
                //ApplicationContext.Instance.Events = events;
                foreach (var ev in events)
                {
                    var row = new object[] { ev.EventID, ev.EventLabel, null, null, null, false };
                    int rowIdx = dataGridViewEvents.Rows.Add(row);
                    //dataGridViewEvents.Rows[rowIdx].Cells[5].Style.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        private void loadDomainModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadDcrXml();
        }

        private void saveMappingProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveMappingProject();
        }

        private void loadMappingProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadMappingProject();
        }

        private void buttonRunExternal_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(richtbDbQuery.Text))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "SSMS.exe";
                    var tempFile = System.IO.Path.GetTempPath() + "\\tmp" + Guid.NewGuid().ToString() + ".sql";
                    File.WriteAllText(tempFile, richtbDbQuery.Text);
                    startInfo.Arguments = tempFile;
                    System.Diagnostics.Process.Start(startInfo);
                } else
                {
                    MessageBox.Show("Please add a query to execute!", "Error", MessageBoxButtons.OK);
                }
            } catch
            {
                MessageBox.Show("Cannot open SQL Server! Make sure SQL Server is installed on local machine.", "Error", MessageBoxButtons.OK);
            }
        }

        private void buttonEditScreenshot_Click(object sender, EventArgs e)
        {
            SaveScreenshot ss = new SaveScreenshot(pbScreenshot.Image);
            ss.FormClosed += new FormClosedEventHandler(Edit_Closed);
            ss.Show();
        }

        private void Edit_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (ApplicationContext.Instance != null && 
                    ApplicationContext.Instance.currentDK != null && 
                    ApplicationContext.Instance.currentDK.ScreenshotImage != null)
                {
                    pbScreenshot.Image = ApplicationContext.Instance.currentDK.ScreenshotImage.ImageData;
                }
            } catch
            {
                //TODO handle error
            }
        }

        private void buttonCaptureUI_Click(object sender, EventArgs e)
        {
            SelectArea area = new SelectArea();
            this.Hide();
            area.ShowDialog();
            var screenShot = ApplicationContext.Instance.currentDK?.ScreenshotImage?.ImageData;
            if (screenShot != null)
                pbScreenshot.Image = screenShot;
            this.Show();
        }

        private void buttonRunAllSQLInGraph_Click_1(object sender, EventArgs e)
        {
            //string fullQuery = "";
            //foreach (DataGridViewRow row in dataGridViewEvents.Rows)
            //{
            //    fullQuery += (string)row.Cells[4].Value + Environment.NewLine;
            //}
            //DataTableCollection res = DatabaseInspect.RunScript(fullQuery, (string)comboBoxSelectDbConnection.SelectedValue).Tables;
            //DataTable dtRes = new DataTable();
            //for (int i = 0; i < res.Count; i++)
            //{
            //    dtRes.Merge(res[i]);
            //}
            //dataFromSql.DataSource = dtRes;
            //ApplicationContext.Instance.ConcatenatedData = dtRes;
        }

        private void buttonRunOneSQL_Click_1(object sender, EventArgs e)
        {
            SqlConnect sc = new SqlConnect(richtbDbQuery.Text);
            sc.Show();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionString cs = new ConnectionString();
            cs.Show();
        }

        // https://stackoverflow.com/questions/1620947/how-could-i-drag-and-drop-datagridview-rows-under-each-other
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
        private void dataGridViewEvents_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = dataGridViewEvents.DoDragDrop(
                    dataGridViewEvents.Rows[rowIndexFromMouseDown],
                    DragDropEffects.Move);
                }
            }
        }

        private void dataGridViewEvents_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dataGridViewEvents.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                    dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dataGridViewEvents_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataGridViewEvents_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dataGridViewEvents.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop =
                dataGridViewEvents.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move && rowIndexFromMouseDown != dataGridViewEvents.NewRowIndex)
            {
                DataGridViewRow rowToMove = e.Data.GetData(
                    typeof(DataGridViewRow)) as DataGridViewRow;
                if (rowIndexOfItemUnderMouseToDrop == dataGridViewEvents.NewRowIndex)
                {
                    rowIndexOfItemUnderMouseToDrop--;
                }
                if (rowIndexOfItemUnderMouseToDrop < 0)
                {
                    rowIndexOfItemUnderMouseToDrop = dataGridViewEvents.NewRowIndex-1;
                }
                dataGridViewEvents.Rows.RemoveAt(rowIndexFromMouseDown);
                dataGridViewEvents.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);
                dataGridViewEvents.ClearSelection();
                dataGridViewEvents.Rows[rowIndexOfItemUnderMouseToDrop].Selected = true;
            }
        }

        private void imageUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var filePath = ofd.FileName;
                pbScreenshot.Image = Image.FromFile(filePath);
            }
        }
    }
}
