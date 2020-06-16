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
    public partial class AddNewRow : Form
    {
        List<string> ids;
        DataTable dataTable;
        string dataBasePath;
        enum columns { id, fullName, algorithm, groupNumber };

        public AddNewRow(ref List<string> ids, ref DataTable dataTable, string dataBasePath)
        {
            InitializeComponent();
            this.ids = ids;
            this.dataTable = dataTable;
            this.dataBasePath = dataBasePath;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string[] newStudent = new string[4];

            newStudent[(int)columns.id] = this.IdTextBox.Text;
            newStudent[(int)columns.fullName] = this.FullNameTextBox.Text;
            newStudent[(int)columns.algorithm] = this.AlgorithmTextBox.Text;
            newStudent[(int)columns.groupNumber] = this.GroupNumber.Value.ToString();

            if (newStudent.Contains("") || newStudent.Contains(null))
                MessageBox.Show("Please fill all the fields", "Error");

            else if (ids.Contains(this.IdTextBox.Text))
                MessageBox.Show("This student already exists in the data base", "Error");

            else
            {
                dataTable.Rows.Add(newStudent);
                ids.Add(newStudent[(int)columns.id]);
                MessageBox.Show("Student added successfully", "Success");
                ClearFields();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFields()
        {
            this.IdTextBox.Text = "";
            this.FullNameTextBox.Text = "";
            this.AlgorithmTextBox.Text = "";
            this.GroupNumber.Value = 1;
        }
    }
}
