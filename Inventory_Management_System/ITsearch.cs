using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;


namespace Inventory_Management_System
{
    public partial class ITsearch : Form
    {
        //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
        OLEDBCONNECTION conn = new OLEDBCONNECTION();

        public ITsearch()
        {
            InitializeComponent();
        }

        private void ITsearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.testDataSet.User);
            // TODO: This line of code loads data into the 'testDataSet.ComputerData' table. You can move, or remove it, as needed.
            this.computerDataTableAdapter.Fill(this.testDataSet.ComputerData);
            // TODO: This line of code loads data into the 'testDataSet.UserData' table. You can move, or remove it, as needed.
            this.userDataTableAdapter.Fill(this.testDataSet.UserData);
            disp_data();
        }

        public void disp_data()
        {
            conn.Connection(); //call class don't forget
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT UserData.UserID, UserData.Name, UserData.Surname, UserData.[MUD-ID], UserData.Department, UserData.Cx_Rx, ComputerData.ComID, ComputerData.Brand, ComputerData.Model, ComputerData.Serial_Number, ComputerData.Warranty_End FROM(UserData INNER JOIN ComputerData ON UserData.ComID = ComputerData.ComID)";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.con.Close();
        }

        private void userDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet);
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Clear Search for UserData
        {
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //Search Engine for UserData
        {
            if (comboBox1.Text == "Name")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.UserID, UserData.Name, UserData.Surname, UserData.[MUD-ID], UserData.Department, UserData.Cx_Rx, ComputerData.ComID, ComputerData.Brand, ComputerData.Model, ComputerData.Serial_Number, ComputerData.Warranty_End FROM(UserData INNER JOIN ComputerData ON UserData.ComID = ComputerData.ComID) where UserData.Name like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "MUD_ID")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.UserID, UserData.Name, UserData.Surname, UserData.[MUD-ID], UserData.Department, UserData.Cx_Rx, ComputerData.ComID, ComputerData.Brand, ComputerData.Model, ComputerData.Serial_Number, ComputerData.Warranty_End FROM(UserData INNER JOIN ComputerData ON UserData.ComID = ComputerData.ComID) where UserData.[MUD-ID] like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "Department")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.UserID, UserData.Name, UserData.Surname, UserData.[MUD-ID], UserData.Department, UserData.Cx_Rx, ComputerData.ComID, ComputerData.Brand, ComputerData.Model, ComputerData.Serial_Number, ComputerData.Warranty_End FROM(UserData INNER JOIN ComputerData ON UserData.ComID = ComputerData.ComID) where UserData.Department like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.Text == "Cx/Rx")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.UserID, UserData.Name, UserData.Surname, UserData.[MUD-ID], UserData.Department, UserData.Cx_Rx, ComputerData.ComID, ComputerData.Brand, ComputerData.Model, ComputerData.Serial_Number, ComputerData.Warranty_End FROM(UserData INNER JOIN ComputerData ON UserData.ComID = ComputerData.ComID) where UserData.Cx_Rx like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void userDataDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
