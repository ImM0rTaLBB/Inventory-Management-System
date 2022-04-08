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
    public partial class ITsearch2 : Form
    {
        //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
        OLEDBCONNECTION conn = new OLEDBCONNECTION();
        public ITsearch2()
        {
            InitializeComponent();
        }

        private void ipadDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ipadDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet);

        }

        private void ITsearch2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.IpadData' table. You can move, or remove it, as needed.
            this.ipadDataTableAdapter.Fill(this.testDataSet.IpadData);
            disp_data();
        }

        public void disp_data()
        {
            conn.Connection();
            conn.con.Open();
            OleDbCommand cmd = conn.con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM IpadData";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            ipadDataDataGridView.DataSource = dt;
            conn.con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "IPADID")
            {
                //OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT IPADID, Brand, Model, IPADName, IMEI, SIM, Received_Date, Warranty_End, User_Received_Date, Previous_UserID, Status FROM IpadData where IPADID like '" + textBox2.Text + "%'", conn.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ipadDataDataGridView.DataSource = dt;
            }
            else if(comboBox2.Text == "IMEI")
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
    }
}
