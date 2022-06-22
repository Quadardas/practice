using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tUpdate();

        }
        string Credentials =
           @"Server = WS0116\SQLEXPRESS;" +
           "Integrated security = SSPI;" +
           "database = CalcPWork;";
        int tempeID = -1;
        string selectedTable;
        List<string> tables = new List<string>();
        void tUpdate()
        {
            DWorks database = new DWorks(Credentials);
            dataGridView1.DataSource = database.ReturnTable("name_buhgaltera", "FIOBuhgalter", null).Tables[0].DefaultView;
        }

    }
}
