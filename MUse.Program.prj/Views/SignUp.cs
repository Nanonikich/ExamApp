using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ExamApp
{
    public partial class SignUp : Form
    {
        #region Поля

        private readonly DB db = new DB();
        private readonly SignIn _SignIn;
        private readonly string z;
        private readonly ToolTip tooltip = new ToolTip();

        #endregion Поля

        #region Конструктор

        public SignUp(SignIn sn, string id)
        {
            _SignIn = sn;
            z = id;
            InitializeComponent();
        }

        #endregion Конструктор

        #region Методы

        private void ButnReg_Click(object sender, EventArgs e)
        {
            // проверка на совпадение имени пользователя
            try
            {
                #region Проверка на пустоту

                if (string.IsNullOrEmpty(textBoxSurn.Text) || string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrEmpty(maskedTBPhone.Text) || string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxCity.Text) || string.IsNullOrEmpty(textBoxAddr.Text) || string.IsNullOrEmpty(textBoxUsname.Text) || string.IsNullOrEmpty(textBoxPassw.Text))
                {
                    MessageBox.Show("Заполните пустые поля");
                    return;
                }

                #endregion Проверка на пустоту

                #region Соглашение на обработку данных

                if (checkBoxConsent.Checked == false)
                {
                    MessageBox.Show("Для регистрации подтвердите соглашение");
                    return;
                }

                #endregion Соглашение на обработку данных

                new SqlDataAdapter($@"INSERT INTO Users(user_sur, user_name, user_patr, user_email, user_phone, user_city, user_address, user_usname, user_passw) VALUES(N'{textBoxSurn.Text}', N'{textBoxName.Text}', N'{textBoxPatr.Text}', N'{textBoxEmail.Text}', N'{maskedTBPhone.Text}', N'{textBoxCity.Text}', N'{textBoxAddr.Text}', N'{textBoxUsname.Text}', N'{textBoxPassw.Text}')",
                                    db.GetConnection()).Fill(new DataTable());

                MessageBox.Show("Вы успешно зарегистрированы");

                #region Открытие формы SignIn

                Close();
                _SignIn.butSignUp.Enabled = false;
                _SignIn.Show();

                #endregion Открытие формы SignIn
            }
            catch
            {
                MessageBox.Show("Имя пользователя уже существует");
            }
        }

        private void ButnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                db.OpenConnection();

                #region Проверка на пустоту

                if (string.IsNullOrEmpty(textBoxSurn.Text) || string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrEmpty(maskedTBPhone.Text) || string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxCity.Text) || string.IsNullOrEmpty(textBoxAddr.Text) || string.IsNullOrEmpty(textBoxUsname.Text) || string.IsNullOrEmpty(textBoxPassw.Text))
                {
                    MessageBox.Show("Заполните пустые поля");
                    return;
                }

                #endregion Проверка на пустоту

                switch (new SqlCommand($"UPDATE Users SET user_sur = N'{textBoxSurn.Text}', user_name = N'{textBoxName.Text}', user_patr = N'{textBoxPatr.Text}', user_email =  N'{textBoxEmail.Text}', user_phone = '{maskedTBPhone.Text}', user_city = N'{textBoxCity.Text}', user_address = N'{textBoxAddr.Text}', user_usname = N'{textBoxUsname.Text}', user_passw = N'{textBoxPassw.Text}' WHERE user_id = '{z}'",
                    db.GetConnection()).ExecuteNonQuery())
                {
                    case 1:
                        Close();
                        MessageBox.Show("Информация обновлена");
                        break;

                    default:
                        MessageBox.Show("Информация не обновлена");
                        break;
                }
                db.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Непредвиденная ошибка");
            }
        }

        private void ButnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Проверка эл.почты

        private void TextBoxEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var rEMail = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (textBoxEmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(textBoxEmail.Text))
                {
                    MessageBox.Show("Неверный адрес электронной почты", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxEmail.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        #endregion Проверка эл.почты

        #region Настройка textBoxes

        // Проверка имени, фамилии, отчества, города
        private void TextBoxSurn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.Match(e.KeyChar.ToString(), @"[а-яА-Я]|[a-zA-Z]").Success || e.KeyChar == (char)Keys.Back) return;
            else
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

        #endregion Настройка textBoxes

        #region Подсказка

        private void Label10_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.SetToolTip(label10, "Поле необязательно для заполнения");
        }

        #endregion Подсказка

        private void SignUp_FormClosed(object sender, FormClosedEventArgs e) => _SignIn.Enabled = true;

        #endregion Методы
    }
}