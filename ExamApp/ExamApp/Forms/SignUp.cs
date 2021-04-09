using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;

namespace ExamApp
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void ButnBack_Click(object sender, EventArgs e)
        {
            Close();
            new SignIn().Show();
        }

        private void ButnReg_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var _ in (new string[] { ".", ",", "/", "*", "(", ")", "%", "!", "?", ">", "<", "'", ":", ";", "{", "}", "[", "]", "-", "_", "+", "=", "&", "^", "$", "|", "@", "~", "`", "№", ";", " " }).Where(v => 
                                       textBoxSurn.Text.Contains(v) || textBoxName.Text.Contains(v) || textBoxPatr.Text.Contains(v) || textBoxPhone.Text.Contains(v) || textBoxCity.Text.Contains(v) || textBoxUsname.Text.Contains(v) || textBoxPassw.Text.Contains(v) ||
                                       string.IsNullOrEmpty(textBoxSurn.Text) || string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrEmpty(textBoxPatr.Text) || string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxPhone.Text) || string.IsNullOrEmpty(textBoxCity.Text) || string.IsNullOrEmpty(textBoxAddr.Text) || string.IsNullOrEmpty(textBoxUsname.Text) || string.IsNullOrEmpty(textBoxPassw.Text)).Select(v => new { }))
                {
                    MessageBox.Show("Check the fields");
                    return;
                }

                var db = new DB();
                new SqlDataAdapter(@"INSERT INTO Users(user_sur, user_name, user_patr, user_email, user_phone, user_city, user_address, user_usname, user_passw) VALUES('" + textBoxSurn.Text + "', '" + textBoxName.Text + "', '" + textBoxPatr.Text + "', '" + textBoxEmail.Text + "', '" + textBoxPhone.Text + "', '" + textBoxCity.Text + "', '" + textBoxAddr.Text + "', '" + textBoxUsname.Text + "', '" + textBoxPassw.Text + "')", db.GetConnection()).Fill(new DataTable());

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

    

