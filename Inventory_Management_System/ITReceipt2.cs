using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_System
{
    public partial class ITReceipt2 : Form
    {
        private string name;
        private string surname;
        private string mudid;
        private string brand;
        private string model;
        private string serial;

        /*public ITReceipt2()
        {
            
        }*/

        public ITReceipt2(string name, string surname, string mudid, string brand, string model, string serial)
        {
            this.name = name;
            this.surname = surname;
            this.mudid = mudid;
            this.brand = brand;
            this.model = model;
            this.serial = serial;
            InitializeComponent();
        }

        private void ITReceipt2_Load(object sender, EventArgs e)
        {
            ITCrystalReport ob = new ITCrystalReport();
            ob.SetParameterValue("Name", name);
            ob.SetParameterValue("Surname", surname);
            ob.SetParameterValue("MUD-ID", mudid);
            ob.SetParameterValue("Brand", brand);
            ob.SetParameterValue("Model", model);
            ob.SetParameterValue("Serial", serial);
            crystalReportViewer1.ReportSource = ob;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }
    }
}
