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
    public partial class ITManageMDI : Form
    {
        private int childFormNumber = 0;

        public ITManageMDI()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ITManageMDI_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void userDataToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            
        }

        private void computerDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cascadeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void tileVerticalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void previousUserSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ITPreviousUserSearch frm4 = new ITPreviousUserSearch();
            frm4.MdiParent = this;
            frm4.Show();
        }

        private void previousUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void userDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ITmanage frm = new ITmanage();
            frm.MdiParent = this;
            frm.Show();
        }

        private void computerDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ITmanage2 frm2 = new ITmanage2();
            frm2.MdiParent = this;
            frm2.Show();
        }

        private void previousUserToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ITmanage3 frm5 = new ITmanage3();
            frm5.MdiParent = this;
            frm5.Show();
        }

        private void ipadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ITmanage4 frm6 = new ITmanage4();
            frm6.MdiParent = this;
            frm6.Show();
        }

        private void userAndComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ITsearch frm = new ITsearch();
            frm.MdiParent = this;
            frm.Show();
        }

        private void previousUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ITPreviousUserSearch frm = new ITPreviousUserSearch();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ipadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ITsearch2 frm = new ITsearch2();
            frm.MdiParent = this;
            frm.Show();
        }

        private void accessoriesDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ITmanage5 frm = new ITmanage5();
            frm.MdiParent = this;
            frm.Show();
        }

        private void accessoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ITsearch3 frm = new ITsearch3();
            frm.MdiParent = this;
            frm.Show();
        }

        private void computerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ITsearch1 frm = new ITsearch1();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
