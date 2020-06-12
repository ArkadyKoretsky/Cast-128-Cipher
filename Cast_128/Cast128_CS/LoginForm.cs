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
    public partial class LoginForm : Form
    {
        string UsersDB = @"C:\cast128\users.csv";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string[] users = File.ReadAllLines(UsersDB);
            string showMessage = "Bad!";
            foreach (string user in users)
            {
                string[] usernameAndPassword = user.Split(',');
                if (UsernameTextBox.Text == usernameAndPassword[0] && PassowrdTextBox.Text == usernameAndPassword[1])
                {
                    showMessage = "Good!";
                    break;
                }
            }
            MessageBox.Show(showMessage, "Error");
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
