using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Local_DataBase
{
    public partial class DBForm : Form
    {
        ClassDatabase db;
        public DBForm()
        {
            InitializeComponent();
        }

        private void DBForm_Load(object sender, EventArgs e)
        {
            db = new ClassDatabase();
            db.OpenConnection();
            db.CheckConnection();
            MessageBox.Show("Форма обновлена", "Debug");
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            dataGridView.DataSource = db.GetAllData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = $"ALTER TABLE Database ADD {ColumNameBox.Text} ";
            List<RadioButton> radioButtons = new List<RadioButton>
            {
                radioButton1,
                radioButton2,
                radioButton3,
                radioButton4,
                radioButton5,
                radioButton6,
                radioButton7,
                radioButton8,
            };
            RadioButton selectedRadioButton = radioButtons.FirstOrDefault(rb => rb.Checked);
            query += selectedRadioButton.Name switch
            {
                "radioButton1" => "nvachar(MAX)",
                "radioButton2" => "nvachar(50)",
                "radioButton3" => "date",
                "radioButton4" => "money",
                "radioButton5" => "int",
                "radioButton6" => "float",
                "radioButton7" => "bigint"

            };
            
        }
    }
}
