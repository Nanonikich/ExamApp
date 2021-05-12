using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExamApp
{
    public partial class SignUp : Form
    {
        #region Поля
        readonly DB db = new DB();
        readonly SignIn _SignIn;
        private readonly string z;
        #endregion

        #region Конструктор
        public SignUp(SignIn sn, string id)
        {
            _SignIn = sn;
            z = id;
            InitializeComponent();
        }
        #endregion

        #region Методы

        private void ButnReg_Click(object sender, EventArgs e)
        {
            // проверка на совпадение имени пользователя
            //try
            //{
                #region Проверка на пустоту
                if (string.IsNullOrEmpty(textBoxSurn.Text) || string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrEmpty(textBoxPatr.Text) || string.IsNullOrEmpty(textBoxPhone.Text) || string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxCity.Text) || string.IsNullOrEmpty(textBoxAddr.Text) || string.IsNullOrEmpty(textBoxUsname.Text) || string.IsNullOrEmpty(textBoxPassw.Text))
                {
                    MessageBox.Show("Fill in the blank fields");
                    return;
                }
                #endregion

                new SqlDataAdapter($@"INSERT INTO Users(user_sur, user_name, user_patr, user_email, user_phone, user_city, user_address, user_usname, user_passw) VALUES(N'{textBoxSurn.Text}', N'{textBoxName.Text}', N'{textBoxPatr.Text}', N'{textBoxEmail.Text}', N'{textBoxPhone.Text}', N'{textBoxCity.Text}', N'{textBoxAddr.Text}', N'{textBoxUsname.Text}', N'{textBoxPassw.Text}')",
                                    db.GetConnection()).Fill(new DataTable());

                MessageBox.Show("You have successfully registered");

                #region Открытие формы SignIn
                Close();
                _SignIn.butSignUp.Enabled = false;
                _SignIn.Show();
                #endregion
            //}
            //catch
            //{
            //    MessageBox.Show("This username is already in the system");
            //}
        }


        private void ButnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                db.OpenConnection();

                #region Проверка на пустоту
                if (string.IsNullOrEmpty(textBoxSurn.Text) || string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrEmpty(textBoxPatr.Text) || string.IsNullOrEmpty(textBoxPhone.Text) || string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxCity.Text) || string.IsNullOrEmpty(textBoxAddr.Text) || string.IsNullOrEmpty(textBoxUsname.Text) || string.IsNullOrEmpty(textBoxPassw.Text))
                {
                    MessageBox.Show("Fill in the blank fields");
                    return;
                }
                #endregion

                switch (new SqlCommand($"UPDATE Users SET user_sur = N'{textBoxSurn.Text}', user_name = N'{textBoxName.Text}', user_patr = N'{textBoxPatr.Text}', user_email =  N'{textBoxEmail.Text}', user_phone = '{textBoxPhone.Text}', user_city = N'{textBoxCity.Text}', user_address = N'{textBoxAddr.Text}', user_usname = N'{textBoxUsname.Text}', user_passw = N'{textBoxPassw.Text}' WHERE user_id = '{z}'",
                    db.GetConnection()).ExecuteNonQuery())
                {
                    case 1:
                        Close();
                        MessageBox.Show("Data Updated");
                        break;
                    default:
                        MessageBox.Show("Data not updated");
                        break;
                }
                db.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Unexpected error");
            }
        }

        #region Проверка эл.почты
        private void TextBoxEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (textBoxEmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(textBoxEmail.Text))
                {
                    MessageBox.Show("Invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxEmail.SelectAll();
                    e.Cancel = true;
                }
            }
        }
        #endregion


        private void ButnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Настройка textBoxes
        // Проверка имени, фамилии, отчества, города
        private void TextBoxSurn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.Match(e.KeyChar.ToString(), @"[а-яА-Я]|[a-zA-Z]").Success || e.KeyChar == (char)Keys.Back) return;
            else
                e.Handled = true;
        }

        // Проверка телефонного номера
        private void TextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        // Имя пользователя и пароль
        private void TextBoxUsname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.Match(e.KeyChar.ToString(), @"[0-9]|[a-zA-Z]").Success || e.KeyChar == (char)Keys.Back) return;
            else
                e.Handled = true;
        }

        // Проверка всех боксов на Enter
        private void TextBoxSurn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        private void SignUp_FormClosed(object sender, FormClosedEventArgs e) => _SignIn.Enabled = true;


        #endregion
        
    }
}