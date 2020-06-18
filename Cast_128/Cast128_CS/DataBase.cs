﻿using System;
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
        string user;
        DataTable dataTable;
        string dataBaseFile;
        List<string> ids;
        string[] columns = { "ID", "Full Name" };

        public DataBase(string user)
        {
            this.user = user;
            InitializeComponent();
            dataTable = new DataTable();
            ids = new List<string>();
            InitDataTable();
            dataGridView1.DataSource = dataTable;
            dataBaseFile = "students.csv";
            if (user != "admin")
            {
                this.AddButton.Hide();
                this.DeleteButton.Hide();
                this.UpdateButton.Hide();
                dataGridView1.ReadOnly = true;
            }
        }

        private void InitDataTable()
        {
            foreach (string column in columns)
                dataTable.Columns.Add(column);
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            string[] students = File.ReadAllLines(dataBaseFile);
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
            AddNewRow newRow = new AddNewRow(ref ids, ref dataTable, dataBaseFile);
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
            try
            {
                UpdateDataBase();
                MessageBox.Show("Data base updated successfully", "Success");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }

        private void DataBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (user == "admin")
                UpdateDataBase();
        }

        private void UpdateDataBase()
        {
            File.WriteAllText(dataBaseFile, null);
            foreach (DataRow row in dataTable.Rows)
            {
                string[] dataRow = new string[columns.Length];
                for (int i = 0; i < columns.Length; i++)
                    dataRow[i] = row[columns[i]].ToString();
                File.AppendAllText(dataBaseFile, string.Join(",", dataRow) + "\n");
            }
        }
    }
}
