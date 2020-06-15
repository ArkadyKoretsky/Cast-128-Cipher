using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cast128_CS
{
    public partial class DataBase : Form
    {
        DataTable dataTable;
        string dataBasePath;
        List<string> ids;

        public DataBase()
        {
            InitializeComponent();
            dataTable = new DataTable();
            ids = new List<string>();
            InitDataTable();
            dataGridView1.DataSource = dataTable;
            dataBasePath = @"D:\Cryptography\Repository\projects.csv";
        }

        private void InitDataTable()
        {
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Full Name");
            dataTable.Columns.Add("Algorithm");
            dataTable.Columns.Add("Group Number");
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            string[] students = File.ReadAllLines(dataBasePath);
            foreach (string student in students)
            {
                string[] row = student.Split(',');
                ids.Add(row[0]);
                dataTable.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddNewRow newRow = new AddNewRow(ref ids, ref dataTable, dataBasePath);
            newRow.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
