using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamApp
{
    public partial class SignIn : Form
    {

        #region Конструктор
        public SignIn()
        {
            InitializeComponent();
        }
        #endregion

        #region Методы

        private void ButSignIn_Click(object sender, EventArgs e)
        {
            var dtbl = new DataTable();
            new SqlDataAdapter(@"SELECT * FROM Users WHERE user_usname = '" + textBoxUsname.Text + "' AND user_passw = '" + textBoxPassw.Text + "'", new DB().GetConnection()).Fill(dtbl);
            
            #region Проверка
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
            #endregion
        }


        private void ButSignUp_Click(object sender, EventArgs e)
        {
            Enabled = false;
            var signUp = new SignUp(this, "0");
            signUp.butnEdit.Visible = false;
            signUp.Show();
        }

        #region Настройка textBoxes
        private void TextBoxUsname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        private void Data_FormClosing(object sender, FormClosingEventArgs e) => Environment.Exit(0);

        #endregion
    }
}