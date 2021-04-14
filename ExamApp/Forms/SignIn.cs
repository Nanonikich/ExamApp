using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamApp
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void ButSignIn_Click(object sender, EventArgs e)
        {
            var dtbl = new DataTable();
            new SqlDataAdapter(@"SELECT * FROM Users WHERE user_usname = '" + textBoxUsname.Text + "' AND user_passw = '" + textBoxPassw.Text + "'", new DB().GetConnection()).Fill(dtbl);

            switch (dtbl.Rows.Count)
            {
                case 1:
                    {
                        butSignUp.Enabled = false;
                        Hide();
                        new MainWindow(this, dtbl.Rows[0]).Show();
                        break;
                    }

                default:
                    MessageBox.Show("Check your username and password");
                    break;
            }
        }

        private void ButSignUp_Click(object sender, EventArgs e)
        {
            Hide();
            var signUp = new SignUp("0");
            signUp.butnEdit.Enabled = false;
            signUp.Show();
        }

        private void Data_FormClosing(object sender, FormClosingEventArgs e) => Environment.Exit(0);
    }
}