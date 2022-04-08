using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Inventory_Management_System
{
    class OLEDBCONNECTION
    {
        public OleDbConnection con;

        public void Connection()
        {
            //con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/GSK/Inventory_Management_System/Inventory_Management_System/test.accdb");
            //con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\BKKSFWN002\_inventorydb$\test.accdb");
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/Inventory_Management_System/test.accdb");
        }
    }
}
