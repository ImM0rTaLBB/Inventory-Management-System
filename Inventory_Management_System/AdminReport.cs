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
using Excel = Microsoft.Office.Interop.Excel;

namespace Inventory_Management_System
{
    public partial class AdminReport : Form
    {
        OLEDBCONNECTION conn = new OLEDBCONNECTION();
        public AdminReport()
        {
            InitializeComponent();
        }

        private void accessoriesDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.accessoriesDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet);

        }

        private void AdminReport_Load(object sender, EventArgs e)
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
            cmd.CommandText = "SELECT AccessoriesData.*, UserData.[MUD-ID], UserData.Name, UserData.Surname, UserData.Department, UserData.Cx_Rx FROM(AccessoriesData INNER JOIN UserData ON AccessoriesData.UserID = UserData.UserID)";
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
                textBox1.Text = row.Cells[2].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();
                textBox3.Text = row.Cells[4].Value.ToString();
                textBox4.Text = row.Cells[5].Value.ToString();
                textBox5.Text = row.Cells[6].Value.ToString();
                textBox6.Text = row.Cells[7].Value.ToString();
                textBox7.Text = row.Cells[8].Value.ToString();
                textBox8.Text = row.Cells[9].Value.ToString();
                textBox9.Text = row.Cells[10].Value.ToString();
                textBox10.Text = row.Cells[11].Value.ToString();
                textBox11.Text = row.Cells[12].Value.ToString();
                textBox12.Text = row.Cells[13].Value.ToString();
                if (row.Cells[7].Value != null || row.Cells[8].Value != null)
                {
                    DateTime date1 = (DateTime)row.Cells[7].Value;
                    DateTime date2 = (DateTime)row.Cells[8].Value;
                    textBox6.Text = date1.ToShortDateString();
                    textBox7.Text = date2.ToShortDateString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = String.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xls files (*.xls)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
            }
            else
            {
                return;
            }

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;

            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridView1[j, i];
                    xlWorkSheet.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText;
                    xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                }
            }

            //xlWorkBook.SaveAs("U:\\Accessories Query.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            //MessageBox.Show("Excel file created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}

