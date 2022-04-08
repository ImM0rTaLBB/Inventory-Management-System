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
    public partial class Login : Form
    {
        OLEDBCONNECTION conn = new OLEDBCONNECTION();
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Open Connection
        //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Connection();
            //select which data from the database
            OleDbDataAdapter odf = new OleDbDataAdapter("select Role from [User] where Username= '"+textBox1.Text+"'and Password= '"+textBox2.Text+"' ", conn.con);
            DataTable dt = new DataTable();
            odf.Fill(dt);
            if(dt.Rows.Count == 1)
            {
                //If the user have the role of "SA", redirect to ITForm
                if (dt.Rows[0][0].ToString()=="SA") 
                {
                    MessageBox.Show("Hello Super Admin", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ITForm f1 = new ITForm(dt.Rows[0][0].ToString());
                    f1.Show();
                    this.Hide();
                }

                //If the user have the role of "AD", redirect to AdminForm
                else if (dt.Rows[0][0].ToString() == "AD") 
                {
                    MessageBox.Show("Hello Admin", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminForm f2 = new AdminForm(dt.Rows[0][0].ToString());
                    f2.Show();
                    this.Hide();
                }
            }
            else
            {
                //If the user enter wrong username and/or password
                MessageBox.Show("Your username or password is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }
    }
}
