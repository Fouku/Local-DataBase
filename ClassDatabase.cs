using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace Local_DataBase
{
    internal class ClassDatabase
    {
        public SqlConnection sqlConnection = null; 
        public void OpenConnection() 
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            sqlConnection.Open();
        }

        public void CloseConnection()
        {
            sqlConnection.Close();
        }

        public void CheckConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    MessageBox.Show("Подключение установлено");
                }
            }
        }

        public DataTable GetAllData()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TestTable",sqlConnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet.Tables[0];
        }
    }
}
