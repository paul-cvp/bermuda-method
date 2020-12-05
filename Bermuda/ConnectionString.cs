using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bermuda
{
    public partial class ConnectionString : Form
    {
        public ConnectionString()
        {
            InitializeComponent();
            comboBox1.DataSource = ApplicationContext.Instance.connectionStrings.ToList();
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string value = textBox2.Text;
            if (ApplicationContext.Instance.connectionStrings.Keys.Contains(name))
            {
                MessageBox.Show("Connection string already exists!");
            }
            else
            {
                ApplicationContext.Instance.connectionStrings.Add(name, value);
                comboBox1.DataSource = ApplicationContext.Instance.connectionStrings.ToList();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var kvpair = (KeyValuePair<string,string>)comboBox1.SelectedItem;
            if (kvpair.Key == "New")
            {
                textBox1.ReadOnly = false;
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                textBox1.ReadOnly = true;
                textBox1.Text = kvpair.Key;
                textBox2.Text = kvpair.Value;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var key = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
            if (key != "New")
            {
                ApplicationContext.Instance.connectionStrings.Remove(key);
                MessageBox.Show("Connection string " + key + " deleted!");
                comboBox1.DataSource = ApplicationContext.Instance.connectionStrings.ToList();
            }
        }
    }
}
