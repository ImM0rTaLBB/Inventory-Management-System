using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Inventory_Management_System
{
    public partial class ITPreviousUserSearch : Form
    {
        //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
        OLEDBCONNECTION conn = new OLEDBCONNECTION();
        public ITPreviousUserSearch()
        {
            InitializeComponent();
        }

        private void previousUserBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.previousUserBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet);
            disp_data();
        }

        private void ITPreviousUserSearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.PreviousUser' table. You can move, or remove it, as needed.
            this.previousUserTableAdapter.Fill(this.testDataSet.PreviousUser);
            disp_data();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Previous UserID")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT Previous_UserID, [MUD-ID], [DateTime], Name, Surname, Department FROM PreviousUser where Previous_UserID like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                previousUserDataGridView.DataSource = dt;
            }
            else if (comboBox1.Text == "MUD_ID")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT Previous_UserID, [MUD-ID], [DateTime], Name, Surname, Department FROM PreviousUser where [MUD-ID] like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                previousUserDataGridView.DataSource = dt;
            }
            else if (comboBox1.Text == "DateTime")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT Previous_UserID, [MUD-ID], [DateTime], Name, Surname, Department FROM PreviousUser where DateTime like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                previousUserDataGridView.DataSource = dt;
            }
        }

        public void disp_data()
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from PreviousUser";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            previousUserDataGridView.DataSource = dt;
            conn.con.Close();
        }
    }
}
