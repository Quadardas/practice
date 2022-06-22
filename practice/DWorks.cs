using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace practice
{
   
        class DWorks
        {
            //string Credentials = string.Empty;
            SqlConnection connection;
            public DWorks(string Credentials)
            {
                //this.Credentials = Credentials;
                connection = new SqlConnection(Credentials);
                connection.Open(); GC.SuppressFinalize(this);
            }
            ~DWorks()
            {
                connection.Close();
            }
            public DataSet dataSet(string Columns, string Tables, string Arguments)
            {
                DataSet Temp = new DataSet();
                SqlDataAdapter sqlData = new SqlDataAdapter($"SELECT {Columns} FROM {Tables} {Arguments}", connection);
                sqlData.Fill(Temp);
                return Temp;
            }
            public DataSet ReturnTable(string Columns, string TablesName, string Arguments)
            {
                SqlDataAdapter sqlData = new SqlDataAdapter($"SELECT {Columns} FROM {TablesName} {Arguments}", connection);
                DataSet dataSet = new DataSet();
                sqlData.Fill(dataSet);
                return dataSet;
            }

        public DataSet ReturnTable1(string Columns, string TablesName, string Arguments, string Find)
        {
            SqlDataAdapter sqlData = new SqlDataAdapter($"SELECT {Columns} FROM {TablesName} WHERE {Arguments} = '{Find}'", connection);
            DataSet dataSet = new DataSet();
           // form1.label4.Text = $"SELECT {Columns} FROM {TablesName} WHERE {Arguments} = '{Find}'";
            sqlData.Fill(dataSet);
            
            return dataSet;
        }


    }
}



