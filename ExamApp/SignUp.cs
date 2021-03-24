﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamApp
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void butnBack_Click(object sender, EventArgs e)
        {
            Close();
            var signIn = new SignIn();
            signIn.Show();
        }

        private void butnReg_Click(object sender, EventArgs e)
        {
            string[] array = new string[] { ".", ",", "/", "*", "(", ")", "%", "!", "?", ">", "<", "'", ":", ";", "{", "}", "[", "]", "-", "_", "+", "=", "&", "^", "$", "|", "@", "~", "`", "№", ";", " " };
            try
            {
                foreach (string v in array)
                {
                    if (textBoxSurn.Text.Contains(v) || textBoxName.Text.Contains(v) || textBoxPatr.Text.Contains(v) || textBoxPhone.Text.Contains(v) || textBoxCity.Text.Contains(v) || textBoxUsname.Text.Contains(v) || textBoxPassw.Text.Contains(v) ||
                    (string.IsNullOrEmpty(textBoxSurn.Text) || string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrEmpty(textBoxPatr.Text) || string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxPhone.Text) || string.IsNullOrEmpty(textBoxCity.Text) || string.IsNullOrEmpty(textBoxAddr.Text) || string.IsNullOrEmpty(textBoxUsname.Text) || string.IsNullOrEmpty(textBoxPassw.Text)))
                    {
                        MessageBox.Show("Check the fields");
                        return;
                    }
                }
                var db = new DB();
                var adapter = new SqlDataAdapter(@"INSERT INTO Customer(cust_sur, cust_name, cust_patr, cust_email, cust_phone, cust_city, cust_address, cust_usname, cust_passw) VALUES('" + textBoxSurn.Text + "', '" + textBoxName.Text + "', '" + textBoxPatr.Text + "', '" + textBoxEmail.Text + "', '" + textBoxPhone.Text + "', '" + textBoxCity.Text + "', '" + textBoxAddr.Text + "', '" + textBoxUsname.Text + "', '" + textBoxPassw.Text + "')", db.getConnection());
                var dtbl = new DataTable();
                adapter.Fill(dtbl);

                MessageBox.Show("You have successfully registered");
                Close();
                var signIn = new SignIn();
                signIn.butSignUp.Enabled = false;
                signIn.Show();
            }
            catch
            {
                MessageBox.Show("This username is already in the system");
            }
        }
    }
}

    

