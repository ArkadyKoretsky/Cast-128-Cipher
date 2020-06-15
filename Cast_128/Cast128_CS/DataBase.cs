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
        string[] columns = { "ID", "Full Name", "Algorithm", "Group Number" };

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
            foreach (string column in columns)
                dataTable.Columns.Add(column);
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    ids.Remove(row.Cells[0].Value.ToString());
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
            }
            else
                MessageBox.Show("Please select rows", "Error");
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {

        }

        private void DataBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateDataBase();
        }

        private void UpdateDataBase()
        {
            File.WriteAllText(dataBasePath, null);
            foreach (DataRow row in dataTable.Rows)
            {
                string[] dataRow = new string[4];
                for (int i = 0; i < columns.Length; i++)
                    dataRow[i] = row[columns[i]].ToString();
                File.AppendAllText(dataBasePath, string.Join(",", dataRow) + "\n");
            }
        }
    }
}
