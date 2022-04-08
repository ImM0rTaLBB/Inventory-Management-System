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
    public partial class ITmanage3 : Form
    {
        //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
        OLEDBCONNECTION conn = new OLEDBCONNECTION();
        public ITmanage3()
        {
            InitializeComponent();
        }

        private void previousUserBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.previousUserBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet);

        }

        private void ITmanage3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.PreviousUser' table. You can move, or remove it, as needed.
            this.previousUserTableAdapter.Fill(this.testDataSet.PreviousUser);
            disp_data();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "MUD_ID")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT * FROM PreviousUser where [MUD-ID] like '" + textBox1.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                previousUserDataGridView.DataSource = dt;
            }
            else if (comboBox1.Text == "DateTime")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT * FROM PreviousUser where [DateTime] like '" + textBox1.Text + "%'", conn.con);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into PreviousUser([MUD-ID], [DateTime], Name, Surname, Department, PreviousComID) values('" + textBox2.Text + "','" + textBox3.Text + "','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"', '"+textBox7.Text+"')";
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
            cmd.CommandText = "update PreviousUser set [MUD-ID]='" + textBox2.Text + "', [DateTime]='" + textBox3.Text + "', Name='"+textBox4.Text+"', Surname='"+textBox5.Text+"', Department='"+textBox6.Text+"', PreviousComID= '"+textBox7.Text+"' where [MUD-ID]='" + textBox2.Text + "'";
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
                cmd.CommandText = "delete from PreviousUser where [MUD-ID]='" + textBox2.Text + "'";
                cmd.ExecuteNonQuery();
                conn.con.Close();
                disp_data();
                MessageBox.Show("Delete Completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Clear();
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
        }

        private void previousUserDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.previousUserDataGridView.Rows[e.RowIndex];
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox7.Text = row.Cells[6].Value.ToString();

                if (row.Cells[2].Value != null)
                {
                    DateTime date1 = (DateTime)row.Cells[2].Value;
                    textBox3.Text = date1.ToShortDateString();
                }
            }
        }
    }
}
