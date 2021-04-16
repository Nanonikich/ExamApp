using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;

namespace ExamApp
{
    public partial class SignUp : Form
    {
        private string z;
        SignIn _SignIn;
        public SignUp(string id, SignIn si)
        {
            z = id;
            _SignIn = si;
            InitializeComponent();
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

        private void ButnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new DB();
                var command = new SqlCommand($@"UPDATE Users SET user_sur = N'{textBoxSurn.Text}', user_name = N'{textBoxName.Text}', user_patr = N'{textBoxPatr.Text}', user_email =  N'{textBoxEmail.Text}', user_phone = '{textBoxPhone.Text}', user_city = N'{textBoxCity.Text}', user_address = N'{textBoxAddr.Text}', user_usname = N'{textBoxUsname.Text}', user_passw = N'{textBoxPassw.Text}' WHERE user_id = '" + z + "'", db.GetConnection());
                db.GetConnection().Open();
                switch (command.ExecuteNonQuery())
                {
                    case 1:
                        MessageBox.Show("Data Updated");
                        break;
                    default:
                        MessageBox.Show("Data not updated");
                        break;
                }
                Close();
                var signIn = new SignIn();
                signIn.butSignUp.Enabled = false;
                signIn.Show();
            }
            catch
            {
                MessageBox.Show("Fuck");
            }
        }

        private void ButnBack_Click(object sender, EventArgs e)
        {
            Close();
            _SignIn.Enabled = true;
        }

        private void SignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            _SignIn.Enabled = true;
            _SignIn.Show();
        }
    }
}

    

