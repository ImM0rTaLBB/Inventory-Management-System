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
    public partial class ITsearch3 : Form
    {
        //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
        OLEDBCONNECTION conn = new OLEDBCONNECTION();
        public ITsearch3()
        {
            InitializeComponent();
        }

        private void accessoriesDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.accessoriesDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet);

        }

        private void ITsearch3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.AccessoriesData' table. You can move, or remove it, as needed.
            this.accessoriesDataTableAdapter.Fill(this.testDataSet.AccessoriesData);
            disp_data();
        }

        public void disp_data()
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM AccessoriesData";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            accessoriesDataDataGridView.DataSource = dt;
            conn.con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Category")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT AccessoriesID, Category, Brand, Model, Device_Name, Serial_Number, UserID FROM AccessoriesData where Category like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                accessoriesDataDataGridView.DataSource = dt;
            }
            else if (comboBox1.Text == "Brand")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT AccessoriesID, Category, Brand, Model, Device_Name, Serial_Number, UserID FROM AccessoriesData where Brand like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                accessoriesDataDataGridView.DataSource = dt;
            }
            else if (comboBox1.Text == "Model")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT AccessoriesID, Category, Brand, Model, Device_Name, Serial_Number, UserID FROM AccessoriesData where Model like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                accessoriesDataDataGridView.DataSource = dt;
            }
            else if (comboBox1.Text == "Serial Number")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT AccessoriesID, Category, Brand, Model, Device_Name, Serial_Number, UserID FROM AccessoriesData where Serial_Number like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                accessoriesDataDataGridView.DataSource = dt;
            }
        }
    }
}
