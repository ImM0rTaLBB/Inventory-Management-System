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
    public partial class ITReceipt4 : Form
    {
        private string name;
        private string surname;
        private string mudid;
        private string brand;
        private string model;
        private string ipadname;
        private string imei;
        private string sim;

        /*public ITReceipt4()
        {
            
        }*/

        public ITReceipt4(string name, string surname, string mudid, string brand, string model, string ipadname, string imei, string sim)
        {
            this.name = name;
            this.surname = surname;
            this.mudid = mudid;
            this.brand = brand;
            this.model = model;
            this.ipadname = ipadname;
            this.imei = imei;
            this.sim = sim;
            InitializeComponent();
        }

        private void ITReceipt4_Load(object sender, EventArgs e)
        {
            CrystalReport2 ob = new CrystalReport2();
            ob.SetParameterValue("Name", name);
            ob.SetParameterValue("Surname", surname);
            ob.SetParameterValue("MUD-ID", mudid);
            ob.SetParameterValue("Brand", brand);
            ob.SetParameterValue("Model", model);
            ob.SetParameterValue("IpadName", ipadname);
            ob.SetParameterValue("IMEI", imei);
            ob.SetParameterValue("SIM", sim);
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
