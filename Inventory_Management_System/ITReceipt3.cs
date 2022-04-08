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
    public partial class ITReceipt3 : Form
    {
        //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
        OLEDBCONNECTION conn = new OLEDBCONNECTION();
        public ITReceipt3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ITReceipt4(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text).ShowDialog();
        }

        private void ITReceipt3_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        public void disp_data()
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT UserData.Name, UserData.Surname, UserData.[MUD-ID], IpadData.Brand, IpadData.Model, IpadData.IPADNAME, IpadData.IMEI, IpadData.SIM FROM(UserData INNER JOIN IpadData ON UserData.IPADID = IpadData.IPADID)";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox7.Text = row.Cells[6].Value.ToString();
                textBox8.Text = row.Cells[7].Value.ToString();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Name")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.Name, UserData.Surname, UserData.[MUD-ID], IpadData.Brand, IpadData.Model, IpadData.IPADNAME, IpadData.IMEI, IpadData.SIM FROM(UserData INNER JOIN IpadData ON UserData.IPADID = IpadData.IPADID) where UserData.Name like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox2.Text == "MUD-ID")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.Name, UserData.Surname, UserData.[MUD-ID], IpadData.Brand, IpadData.Model, IpadData.IPADNAME, IpadData.IMEI, IpadData.SIM FROM(UserData INNER JOIN IpadData ON UserData.IPADID = IpadData.IPADID) where UserData.[MUD-ID] like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox2.Text == "Ipad Name")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.Name, UserData.Surname, UserData.[MUD-ID], IpadData.Brand, IpadData.Model, IpadData.IPADNAME, IpadData.IMEI, IpadData.SIM FROM(UserData INNER JOIN IpadData ON UserData.IPADID = IpadData.IPADID) where IpadData.IPADNAME like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox2.Text == "IMEI")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.Name, UserData.Surname, UserData.[MUD-ID], IpadData.Brand, IpadData.Model, IpadData.IPADNAME, IpadData.IMEI, IpadData.SIM FROM(UserData INNER JOIN IpadData ON UserData.IPADID = IpadData.IPADID) where IpadData.IMEI like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox2.Text == "SIM")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT UserData.Name, UserData.Surname, UserData.[MUD-ID], IpadData.Brand, IpadData.Model, IpadData.IPADNAME, IpadData.IMEI, IpadData.SIM FROM(UserData INNER JOIN IpadData ON UserData.IPADID = IpadData.IPADID) where IpadData.SIM like '" + textBox9.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
