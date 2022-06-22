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
        //string Credentials =
        //   @"Server = WS0116\SQLEXPRESS;" +
        //   "Integrated security = SSPI;" +
        //   "database = CalcPWork;";
        string Credentials =
           @"Server = localhost;" +
           "Integrated security = SSPI;" +
           "database = CalcPWork;";
        //int tempeID = -1;
        //string selectedTable;
        List<string> tables = new List<string>();
        void tUpdate()
        {
            DWorks database = new DWorks(Credentials);
            dataGridView1.DataSource = database.ReturnTable("name_buhgaltera", "FIOBuhgalter", null).Tables[0].DefaultView;
        }

        List<string> days = new List<string>();
        private void monthCalendar1_MouseDown(object sender, MouseEventArgs e)
        {
            MonthCalendar.HitTestInfo info = monthCalendar1.HitTest(e.Location);
            if (info.HitArea == MonthCalendar.HitArea.Date)
            {
                if (monthCalendar1.BoldedDates.Contains(info.Time))
                {
                    monthCalendar1.RemoveBoldedDate(info.Time);
                    days.Remove(Convert.ToString(info.Time));

                }


                else
                {
                    monthCalendar1.AddBoldedDate(info.Time);
                    monthCalendar1.UpdateBoldedDates();
                    days.Add(Convert.ToString(info.Time));

                }
            }

            //for (int i = 0; i < monthCalendar1.BoldedDates.Count(); i++)
            //{
            // days.Add(monthCalendar1.BoldedDates.ToString());
            //}
            listBox1.Items.Clear();
            foreach (string i in days)
            {
                listBox1.Items.Add(i.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DWorks database = new DWorks(Credentials);
            // label4.Text = listBox1.Items[0].ToString().Split(' ').First();
            dataGridView2.DataSource = database.ReturnTable1("__date", "ADS", "__date", listBox1.Items[0].ToString().Split(' ').First()).Tables[0].DefaultView;

           
        
        }
    }
}