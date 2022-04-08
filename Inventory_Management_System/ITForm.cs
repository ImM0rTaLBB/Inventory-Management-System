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
    public partial class ITForm : Form
    {
        public ITForm(string Role)
        {
            InitializeComponent();
            label2.Text = Role;
        }

        private void ITForm_Load(object sender, EventArgs e)
        {

        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            ITSearchMDI frm = new ITSearchMDI();
            frm.Show();
        }

        private void managebtn_Click(object sender, EventArgs e)
        {
            ITManageMDI frm = new ITManageMDI();
            frm.Show();
        }

        private void reportbtn_Click(object sender, EventArgs e)
        {
            ITReceipt0 frm = new ITReceipt0();
            frm.Show();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            //Logout from the session
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

        private void ITForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void ITForm_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
    }
}
