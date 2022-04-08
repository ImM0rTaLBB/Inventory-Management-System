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
    public partial class ITReceipt : Form
    {
        //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
        OLEDBCONNECTION conn = new OLEDBCONNECTION();
        public ITReceipt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ITReceipt2(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text).ShowDialog();
        }

        private void ITReceipt_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.Report' table. You can move, or remove it, as needed.
            this.reportTableAdapter.Fill(this.testDataSet.Report);
            disp_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        /*private void fillByUCQueryToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.reportTableAdapter.FillByUCQuery(this.testDataSet.Report);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/

        public void disp_data()
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT UserData.Name, UserData.Surname, UserData.[MUD-ID], ComputerData.Brand, ComputerData.Model, ComputerData.Serial_Number FROM(UserData INNER JOIN ComputerData ON UserData.ComID = ComputerData.ComID)";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Name")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.Name, UserData.Surname, UserData.[MUD-ID], ComputerData.Brand, ComputerData.Model, ComputerData.Serial_Number FROM(UserData INNER JOIN ComputerData ON UserData.ComID = ComputerData.ComID) where UserData.Name like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox2.Text == "Surname")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.Name, UserData.Surname, UserData.[MUD-ID], ComputerData.Brand, ComputerData.Model, ComputerData.Serial_Number FROM(UserData INNER JOIN ComputerData ON UserData.ComID = ComputerData.ComID) where UserData.Surname like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox2.Text == "MUD-ID")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.Name, UserData.Surname, UserData.[MUD-ID], ComputerData.Brand, ComputerData.Model, ComputerData.Serial_Number FROM(UserData INNER JOIN ComputerData ON UserData.ComID = ComputerData.ComID) where UserData.[MUD-ID] like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox2.Text == "Brand")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.Name, UserData.Surname, UserData.[MUD-ID], ComputerData.Brand, ComputerData.Model, ComputerData.Serial_Number FROM(UserData INNER JOIN ComputerData ON UserData.ComID = ComputerData.ComID) where ComputerData.Brand like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox2.Text == "Model")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.Name, UserData.Surname, UserData.[MUD-ID], ComputerData.Brand, ComputerData.Model, ComputerData.Serial_Number FROM(UserData INNER JOIN ComputerData ON UserData.ComID = ComputerData.ComID) where ComputerData.Model like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox2.Text == "Serial No.")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.Name, UserData.Surname, UserData.[MUD-ID], ComputerData.Brand, ComputerData.Model, ComputerData.Serial_Number FROM(UserData INNER JOIN ComputerData ON UserData.ComID = ComputerData.ComID) where ComputerData.Serial_Number like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
