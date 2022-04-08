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
    public partial class ITmanage : Form
    {
        //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
        OLEDBCONNECTION conn = new OLEDBCONNECTION();
        public ITmanage()
        {
            InitializeComponent();
        }

        private void userDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet);

        }

        private void userDataBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.userDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet);

        }

        private void userDataBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.userDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet);

        }

        private void ITmanage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.UserData' table. You can move, or remove it, as needed.
            this.userDataTableAdapter.Fill(this.testDataSet.UserData);
            userDataBindingSource.DataSource = this.testDataSet.UserData;
            disp_data();
        }

        private void btnNew_Click(object sender, EventArgs e) //Insert data
        {
                conn.Connection();
                conn.con.Open();
                OleDbCommand cmd = conn.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into UserData([MUD-ID], Name, Surname, Department, Cx_Rx, ComID, IPADID) values('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + textBox7.Text + "','" + textBox2.Text + "')";
                cmd.ExecuteNonQuery();
                conn.con.Close();
                disp_data();
                MessageBox.Show("Insert Completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void disp_data() //show all data in datagridview
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from UserData";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            userDataDataGridView.DataSource = dt;
            conn.con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e) //update data
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update UserData set [MUD-ID]='" + textBox3.Text + "', Name='" + textBox4.Text + "', Surname='" + textBox5.Text + "', Department='" + textBox6.Text + "', Cx_Rx='"+textBox8.Text+"', ComID='" + textBox7.Text + "', IPADID='" + textBox2.Text + "' where [MUD-ID]='" + textBox3.Text + "'";
            cmd.ExecuteNonQuery();
            conn.con.Close();
            disp_data();
            MessageBox.Show("Update Completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e) //delete data
        {
            DialogResult =  MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(DialogResult == DialogResult.Yes)
            {
                conn.Connection();
                conn.con.Open();
                OleDbCommand cmd = conn.con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from UserData where [MUD-ID]='" + textBox3.Text + "'";
                cmd.ExecuteNonQuery();
                conn.con.Close();
                disp_data();
                MessageBox.Show("Delete Completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox2.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e) //Display all data
        {
            disp_data();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox2.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //Search Engine
        {
            if (comboBox1.Text == "Name")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserID, [MUD-ID], Name, Surname, Department, ComID, IPADID FROM UserData where Name like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                userDataDataGridView.DataSource = dt;
            }
            else if (comboBox1.Text == "MUD_ID")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserID, [MUD-ID], Name, Surname, Department, ComID, IPADID FROM UserData where [MUD-ID] like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                userDataDataGridView.DataSource = dt;
            }
            else if (comboBox1.Text == "Department")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserID, [MUD-ID], Name, Surname, Department, ComID, IPADID FROM UserData where Department like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                userDataDataGridView.DataSource = dt;
            }
        }

        private void userDataDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.userDataDataGridView.Rows[e.RowIndex];
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[2].Value.ToString();
                textBox5.Text = row.Cells[3].Value.ToString();
                textBox6.Text = row.Cells[4].Value.ToString();
                textBox8.Text = row.Cells[5].Value.ToString();
                textBox7.Text = row.Cells[6].Value.ToString();
                textBox2.Text = row.Cells[7].Value.ToString();
            }
        }
    }
}
