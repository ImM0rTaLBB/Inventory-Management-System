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
    public partial class ITmanage4 : Form
    {
        //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
        OLEDBCONNECTION conn = new OLEDBCONNECTION();
        public ITmanage4()
        {
            InitializeComponent();
        }

        private void ipadDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ipadDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet);

        }

        private void ITmanage4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.IpadData' table. You can move, or remove it, as needed.
            this.ipadDataTableAdapter.Fill(this.testDataSet.IpadData);
            disp_data();
        }

        public void disp_data() //select data
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from IpadData";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            ipadDataDataGridView.DataSource = dt;
            conn.con.Close();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "IPADID")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT IPADID, Brand, Model, IPADName, IMEI, SIM, Received_Date, Warranty_End, User_Received_Date, Previous_UserID, Status FROM IpadData where IPADID like '" + textBox2.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ipadDataDataGridView.DataSource = dt;
            }
            else if (comboBox2.Text == "IMEI")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT IPADID, Brand, Model, IPADName, IMEI, SIM, Received_Date, Warranty_End, User_Received_Date, Previous_UserID, Status FROM IpadData where IMEI like '" + textBox2.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ipadDataDataGridView.DataSource = dt;
            }
            else if (comboBox2.Text == "SIM")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT IPADID, Brand, Model, IPADName, IMEI, SIM, Received_Date, Warranty_End, User_Received_Date, Previous_UserID, Status FROM IpadData where SIM like '" + textBox2.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ipadDataDataGridView.DataSource = dt;
            }
            else if (comboBox2.Text == "Status")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT IPADID, Brand, Model, IPADName, IMEI, SIM, Received_Date, Warranty_End, User_Received_Date, Previous_UserID, Status FROM IpadData where Status like '" + textBox2.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ipadDataDataGridView.DataSource = dt;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into IpadData(Brand, Model, IPADName, IMEI, SIM, Received_Date, Warranty_End, User_Received_Date, Previous_UserID, Status) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','"+textBox9.Text+"','" + comboBox1.Text + "')";
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
            cmd.CommandText = "update IpadData set Brand='" +textBox1.Text+ "',Model='"+textBox2.Text+"', IPADName='"+textBox3.Text+"', IMEI='"+textBox4.Text+"', SIM='"+textBox5.Text+"', Received_Date='"+textBox6.Text+"', Warranty_End='"+textBox7.Text+ "',User_Received_Date='"+textBox8.Text+ "',Previous_UserID='"+textBox9.Text+"', Status='"+comboBox1.Text+"' where Brand='"+textBox1.Text+"'";
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
                cmd.CommandText = "delete from IpadData where IMEI='" + textBox4.Text + "'";
                cmd.ExecuteNonQuery();
                conn.con.Close();
                disp_data();
                MessageBox.Show("Delete Completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Clear();
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
            textBox9.Clear();
            textBox10.Clear();
        }

        private void ipadDataDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.ipadDataDataGridView.Rows[e.RowIndex];
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[6].Value.ToString();
                textBox7.Text = row.Cells[7].Value.ToString();
                textBox8.Text = row.Cells[8].Value.ToString();
                textBox9.Text = row.Cells[9].Value.ToString();
                comboBox1.Text = row.Cells[10].Value.ToString();

                if (row.Cells[6].Value != null || row.Cells[7].Value != null || row.Cells[8].Value != null)
                {
                    DateTime date1 = (DateTime)row.Cells[6].Value;
                    DateTime date2 = (DateTime)row.Cells[7].Value;
                    DateTime date3 = (DateTime)row.Cells[8].Value;
                    textBox6.Text = date1.ToShortDateString();
                    textBox7.Text = date2.ToShortDateString();
                    textBox8.Text = date3.ToShortDateString();
                }
            }
        }
    }
}
