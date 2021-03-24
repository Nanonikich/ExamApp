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

        private void butSignIn_Click(object sender, EventArgs e)
        {
            var db = new DB();
            var dtbl = new DataTable();
            new SqlDataAdapter(@"SELECT * FROM Customer WHERE cust_usname = '" + textBoxUsname.Text + "' AND cust_passw = '" + textBoxPassw.Text + "'", db.getConnection()).Fill(dtbl);
            switch (dtbl.Rows.Count)
            {
                case 1:
                    {
                        Hide();
                        var mainW = new MainWindow();
                        mainW.Show();
                        break;
                    }

                default:
                    MessageBox.Show("Check your username and password");
                    break;
            }
        }

        private void butSignUp_Click(object sender, EventArgs e)
        {
            Hide();
            var signUp = new SignUp();
            signUp.butnEdit.Enabled = false;
            //signUp.butnEdit.Visible = false;
            signUp.Show();
        }

        private void Data_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
