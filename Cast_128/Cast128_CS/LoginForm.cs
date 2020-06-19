﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Cast128_CS
{
    public partial class LoginForm : Form
    {
        string UsersDBFile;
        string password;
        Thread thread;

        public LoginForm()
        {
            InitializeComponent();
            UsersDBFile = "users.csv";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

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
            string[] users = File.ReadAllLines(UsersDBFile);
            bool wrongUserNameOrPassword = true;
            foreach (string user in users)
            {
                string[] userData = user.Split(',');
                password = PassowrdTextBox.Text;
                if (UsernameTextBox.Text == userData[0] && password.GetHashCode().ToString() == userData[1])
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

        public override int GetHashCode()
        {
            return 2049348873 + EqualityComparer<string>.Default.GetHashCode(password);
        }
    }
}
