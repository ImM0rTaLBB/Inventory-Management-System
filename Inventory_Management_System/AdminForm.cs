using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_System
{
    public partial class AdminForm : Form
    {
        public AdminForm(string Role)
        {
            InitializeComponent();
            label2.Text = Role;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            AdminSearchMDI frm = new AdminSearchMDI();
            frm.Show();
        }

        private void managebtn_Click(object sender, EventArgs e)
        {
            ITmanage5 frm = new ITmanage5();
            frm.Show();
        }

        private void reportbtn_Click(object sender, EventArgs e)
        {
            AdminReport frm = new AdminReport();
            frm.Show();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have logged out from the Inventory", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
            Login frm = new Login();
            frm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ITabout frm = new ITabout();
            frm.Show();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void AdminForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
        }
    }
}
