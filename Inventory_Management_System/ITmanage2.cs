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
    public partial class ITmanage2 : Form
    {
        //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
        OLEDBCONNECTION conn = new OLEDBCONNECTION();
        public ITmanage2()
        {
            InitializeComponent();
        }

        private void computerDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.computerDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet);

        }

        private void ITmanage2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.LaptopModel' table. You can move, or remove it, as needed.
            this.laptopModelTableAdapter.Fill(this.testDataSet.LaptopModel);
            // TODO: This line of code loads data into the 'testDataSet.ComputerData' table. You can move, or remove it, as needed.
            this.computerDataTableAdapter.Fill(this.testDataSet.ComputerData);
            disp_data();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e) //Search Engine
        {
            if (comboBox2.Text == "ComID")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComID, Brand, Model, ASSET_TAG, Computer_Name, Serial_Number, Warranty_End, User_Received_Date, Previous_UserID, Status FROM ComputerData where ComID like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                computerDataDataGridView.DataSource = dt;
            }
            else if (comboBox2.Text == "Brand")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComID, Brand, Model, ASSET_TAG, Computer_Name, Serial_Number, Warranty_End, Fix_Asset_Number, User_Received_Date, Previous_UserID, Status FROM ComputerData where Brand like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                computerDataDataGridView.DataSource = dt;
            }
            else if (comboBox2.Text == "Model")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComID, Brand, Model, ASSET_TAG, Computer_Name, Serial_Number, Warranty_End, Fix_Asset_Number, User_Received_Date, Previous_UserID, Status FROM ComputerData where Model like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                computerDataDataGridView.DataSource = dt;
            }
            else if (comboBox2.Text == "ASSET_TAG")
            {
               //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComID, Brand, Model, ASSET_TAG, Computer_Name, Serial_Number, Warranty_End, Fix_Asset_Number, User_Received_Date, Previous_UserID, Status FROM ComputerData where ASSET_TAG like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                computerDataDataGridView.DataSource = dt;
            }
            else if (comboBox2.Text == "Warranty_End")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComID, Brand, Model, ASSET_TAG, Computer_Name, Serial_Number, Warranty_End, Fix_Asset_Number, User_Received_Date, Previous_UserID, Status FROM ComputerData where Warranty_End like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                computerDataDataGridView.DataSource = dt;
            }
            else if (comboBox2.Text == "Status")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT ComID, Brand, Model, ASSET_TAG, Computer_Name, Serial_Number, Warranty_End, Fix_Asset_Number, User_Received_Date, Previous_UserID, Status FROM ComputerData where Status like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                computerDataDataGridView.DataSource = dt;
            }
        }

        public void disp_data() //select data
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from ComputerData";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            computerDataDataGridView.DataSource = dt;
            conn.con.Close();
        }

        public void disp_data2() //select data
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from LaptopModel";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            comboBox3.DataSource = dt;
            conn.con.Close();
        }

        private void btnNew_Click(object sender, EventArgs e) //insert data
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into ComputerData(Brand, Model, ASSET_TAG, Computer_Name, Serial_Number, Warranty_End, Fix_Asset_Number, User_Received_Date, Previous_UserID, Status) values('" + textBox1.Text + "','" + comboBox3.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"+textBox6.Text+"','"+textBox10.Text+"','"+textBox8.Text+"','"+textBox7.Text+"','"+comboBox1.Text+"')";
            cmd.ExecuteNonQuery();
            conn.con.Close();
            disp_data();
            MessageBox.Show("Insert Completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e) //update data
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update ComputerData set Brand='" + textBox1.Text + "', Model='" + comboBox3.Text + "', ASSET_TAG='" + textBox3.Text + "', Computer_Name='" + textBox4.Text + "', Serial_Number='" + textBox5.Text + "', Warranty_End='"+textBox6.Text+"', Fix_Asset_Number='"+textBox10.Text+"', User_Received_Date= '"+textBox8.Text+"', Previous_UserID= '"+textBox7.Text+"', Status= '"+comboBox1.Text+"' where ASSET_TAG='" + textBox3.Text + "'";
            cmd.ExecuteNonQuery();
            conn.con.Close();
            disp_data();
            MessageBox.Show("Update Completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e) //delete data
        {
            DialogResult = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                conn.Connection();
                conn.con.Open();
                OleDbCommand cmd = conn.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from ComputerData where ASSET_TAG='" + textBox3.Text + "'";
                cmd.ExecuteNonQuery();
                conn.con.Close();
                disp_data();
                MessageBox.Show("Delete Completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Clear();
            }  
        }

        private void btnSave_Click(object sender, EventArgs e) //display data
        {
            disp_data();
            textBox9.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void computerDataDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.computerDataDataGridView.Rows[e.RowIndex];
                textBox1.Text = row.Cells[1].Value.ToString();
                comboBox3.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[6].Value.ToString();
                textBox10.Text = row.Cells[7].Value.ToString();
                textBox8.Text = row.Cells[8].Value.ToString();
                textBox7.Text = row.Cells[9].Value.ToString();
                comboBox1.Text = row.Cells[10].Value.ToString();

                if (row.Cells[6].Value != null || row.Cells[8].Value != null)
                {
                    DateTime date1 = (DateTime)row.Cells[6].Value;
                    DateTime date2 = (DateTime)row.Cells[8].Value;
                    textBox6.Text = date1.ToShortDateString();
                    textBox8.Text = date2.ToShortDateString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into LaptopModel(Model) values('" + textBox2.Text + "')";
            cmd.ExecuteNonQuery();
            conn.con.Close();
            disp_data2();
            MessageBox.Show("Insert Completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                conn.Connection();
                conn.con.Open();
                OleDbCommand cmd = conn.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from LaptopModel where Model='" + textBox2.Text + "'";
                cmd.ExecuteNonQuery();
                conn.con.Close();
                disp_data2();
                MessageBox.Show("Delete Completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Clear();
            }
        }
    }
}
