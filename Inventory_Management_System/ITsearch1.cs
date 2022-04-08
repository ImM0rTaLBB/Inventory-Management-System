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
    public partial class ITsearch1 : Form
    {
        //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
        OLEDBCONNECTION conn = new OLEDBCONNECTION();
        public ITsearch1()
        {
            InitializeComponent();
        }

        private void ITsearch1_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        public void disp_data()
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ComputerData.*, PreviousUser.* FROM(ComputerData RIGHT JOIN PreviousUser ON ComputerData.Previous_UserID = PreviousUser.Previous_UserID)";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Brand")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComputerData.*, PreviousUser.* FROM(ComputerData RIGHT JOIN PreviousUser ON ComputerData.Previous_UserID = PreviousUser.Previous_UserID) where ComputerData.Brand like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "Model")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComputerData.*, PreviousUser.* FROM(ComputerData RIGHT JOIN PreviousUser ON ComputerData.Previous_UserID = PreviousUser.Previous_UserID) where ComputerData.Model like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "ASSET_TAG")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComputerData.*, PreviousUser.* FROM(ComputerData RIGHT JOIN PreviousUser ON ComputerData.Previous_UserID = PreviousUser.Previous_UserID) where ComputerData.ASSET_TAG like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "Serial_Number")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComputerData.*, PreviousUser.* FROM(ComputerData RIGHT JOIN PreviousUser ON ComputerData.Previous_UserID = PreviousUser.Previous_UserID) where ComputerData.Serial_Number like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "Warranty_End")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComputerData.*, PreviousUser.* FROM(ComputerData RIGHT JOIN PreviousUser ON ComputerData.Previous_UserID = PreviousUser.Previous_UserID) where ComputerData.Warranty_End like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "Status")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComputerData.*, PreviousUser.* FROM(ComputerData RIGHT JOIN PreviousUser ON ComputerData.Previous_UserID = PreviousUser.Previous_UserID) where ComputerData.Status like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "MUDID")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComputerData.*, PreviousUser.* FROM(ComputerData RIGHT JOIN PreviousUser ON ComputerData.Previous_UserID = PreviousUser.Previous_UserID) where PreviousUser.[MUD-ID] like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "Name")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComputerData.*, PreviousUser.* FROM(ComputerData RIGHT JOIN PreviousUser ON ComputerData.Previous_UserID = PreviousUser.Previous_UserID) where PreviousUser.Name like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "Department")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComputerData.*, PreviousUser.* FROM(ComputerData RIGHT JOIN PreviousUser ON ComputerData.Previous_UserID = PreviousUser.Previous_UserID) where PreviousUser.Department like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
