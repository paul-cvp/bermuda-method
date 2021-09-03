using Bermuda.Model;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            comboBoxUserRole.DataSource = Enum.GetValues(typeof(UserRole));
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            Bermuda bermuda = new Bermuda((UserRole)comboBoxUserRole.SelectedItem);
            this.Close();
            bermuda.ShowDialog();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }
    }
}
