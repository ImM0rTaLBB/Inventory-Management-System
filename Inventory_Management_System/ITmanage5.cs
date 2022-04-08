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
    public partial class ITmanage5 : Form
    {
        //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
        OLEDBCONNECTION conn = new OLEDBCONNECTION();
        public ITmanage5()
        {
            InitializeComponent();
        }

        private void accessoriesDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.accessoriesDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet);

        }

        private void ITmanage5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.UserData' table. You can move, or remove it, as needed.
            this.userDataTableAdapter.Fill(this.testDataSet.UserData);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into AccessoriesData(Category, Brand, Model, Device_Name, Serial_Number, UserID, Accquired_Date, Warranty_End) values('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','"+textBox1.Text+"','"+textBox8.Text+"')";
            cmd.ExecuteNonQuery();
            conn.con.Close();
            disp_data();
            MessageBox.Show("Insert Completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update AccessoriesData set Category='" + comboBox1.Text + "', Brand='" + textBox2.Text + "', Model='" + textBox3.Text + "', Device_Name='" + textBox4.Text + "', Serial_Number='" + textBox5.Text + "', UserID='" + textBox6.Text + "', Accquired_Date='"+textBox1.Text+"', Warranty_End='"+textBox8.Text+"' where Category='"+comboBox1.Text+"'";
            cmd.ExecuteNonQuery();
            conn.con.Close();
            disp_data();
            MessageBox.Show("Update Completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                conn.Connection();
                conn.con.Open();
                OleDbCommand cmd = conn.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from AccessoriesData where Serial_Number='" + textBox4.Text + "'";
                cmd.ExecuteNonQuery();
                conn.con.Close();
                disp_data();
                MessageBox.Show("Delete Completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox5.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            disp_data();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Category")
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT AccessoriesID, Category, Brand, Model, Device_Name, Serial_Number, UserID, Accquired_Date, Warranty_End FROM AccessoriesData where Category like '" + textBox7.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                accessoriesDataDataGridView.DataSource = dt;
            }
            else if (comboBox2.Text == "Brand")
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT AccessoriesID, Category, Brand, Model, Device_Name, Serial_Number, UserID, Accquired_Date, Warranty_End FROM AccessoriesData where Brand like '" + textBox7.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                accessoriesDataDataGridView.DataSource = dt;
            }
            else if (comboBox2.Text == "Model")
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT AccessoriesID, Category, Brand, Model, Device_Name, Serial_Number, UserID, Accquired_Date, Warranty_End FROM AccessoriesData where Model like '" + textBox7.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                accessoriesDataDataGridView.DataSource = dt;
            }
            else if (comboBox2.Text == "MUD-ID")
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT AccessoriesID, Category, Brand, Model, Device_Name, Serial_Number, UserID, Accquired_Date, Warranty_End FROM AccessoriesData where MUD-ID like '" + textBox7.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                accessoriesDataDataGridView.DataSource = dt;
            }
        }

        private void accessoriesDataDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.accessoriesDataDataGridView.Rows[e.RowIndex];
                comboBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[6].Value.ToString();
                textBox1.Text = row.Cells[7].Value.ToString();
                textBox8.Text = row.Cells[8].Value.ToString();

                if (row.Cells[7].Value != null || row.Cells[8].Value != null)
                {
                    DateTime date1 = (DateTime)row.Cells[7].Value;
                    DateTime date2 = (DateTime)row.Cells[8].Value;
                    textBox1.Text = date1.ToShortDateString();
                    textBox8.Text = date2.ToShortDateString();
                }
            }
        }
    }
}
