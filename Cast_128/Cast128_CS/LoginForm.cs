using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography; // for generating hashed password

namespace Cast128_CS
{
    public partial class LoginForm : Form
    {
        string UsersDBFile;
        string hashedPassword;
        Thread thread;

        public LoginForm()
        {
            InitializeComponent();
            UsersDBFile = "users.csv";
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginVerification();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenDataBase(string user)
        {
            Application.Run(new DataBase(user));
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginVerification();
        }

        private void LoginVerification()
        {
            if (UsernameTextBox.Text == "" || UsernameTextBox.Text == null || PassowrdTextBox.Text == "" || PassowrdTextBox.Text == null)
                MessageBox.Show("Please fill all the fields", "Error");
            else
            {
                string[] users = File.ReadAllLines(UsersDBFile);
                bool wrongUserNameOrPassword = true;
                foreach (string user in users)
                {
                    string[] userData = user.Split(',');
                    hashedPassword = GetHash(PassowrdTextBox.Text, UsernameTextBox.Text);
                    if (UsernameTextBox.Text == userData[0] && hashedPassword == userData[1])
                    {
                        wrongUserNameOrPassword = false;
                        this.Close();
                        thread = new Thread(() => OpenDataBase(userData[2]));
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.Start();
                        break;
                    }
                }
                if (wrongUserNameOrPassword)
                    MessageBox.Show("Wrong user name or password", "Error");
            }
        }

        private string GetHash(string password, string salt)
        {
            byte[] passwordAndSaltBytes = Encoding.UTF8.GetBytes(password + salt);
            byte[] hashBytes = new SHA256Managed().ComputeHash(passwordAndSaltBytes);
            string hashString = Convert.ToBase64String(hashBytes);

            return hashString;
        }
    }
}
