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
    public partial class ITPreviousUser : Form
    {
        public ITPreviousUser()
        {
            InitializeComponent();
        }

        private void previousUserBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.previousUserBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet);

        }

        private void ITPreviousUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.PreviousUser' table. You can move, or remove it, as needed.
            this.previousUserTableAdapter.Fill(this.testDataSet.PreviousUser);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
