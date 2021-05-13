using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;

namespace ExamApp.Forms
{
    public partial class Categories : Form
    {
        #region Поля

        private readonly AddProd AddEddWin;
        private readonly DB db = new DB();
        private readonly MainWindow MainWin;
        private readonly DataTable dtbl = new DataTable();

        #endregion Поля

        #region Конструктор

        public Categories(AddProd ae, MainWindow mw)
        {
            AddEddWin = ae;
            MainWin = mw;
            InitializeComponent();
        }

        #endregion Конструктор

        #region Методы

        private void UpdateWin()
        {
            dtbl.Clear();
            db.OpenConnection();
            dtbl.Load(new SqlCommand("SELECT categ_id, categ_name FROM Categories", db.GetConnection()).ExecuteReader());
            db.CloseConnection();
            dgvCateg.DataSource = dtbl;

            #region Настройки таблицы

            dgvCateg.ReadOnly = true;
            dgvCateg.Columns[0].Visible = false;
            dgvCateg.Columns[1].HeaderText = "Категория";

            #endregion Настройки таблицы

            db.CloseConnection();
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            UpdateWin();
        }

        private void ButAddCat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvCateg.Rows.Count; i++)
            {
                if ((textBoxCat.Text.ToString() == Convert.ToString(dgvCateg.Rows[i].Cells[1].Value) && dgvCateg.RowCount > 0) || textBoxCat.Text == "")
                {
                    MessageBox.Show("Ошибка");
                    return;
                }
            }
            db.OpenConnection();
            new SqlCommand($"INSERT INTO Categories (categ_name) VALUES (N'{textBoxCat.Text}')", db.GetConnection()).ExecuteNonQuery();
            db.CloseConnection();
            UpdateWin();
        }

        private void ButCategDel_Click(object sender, EventArgs e)
        {
            foreach (var _ in from DataGridViewRow row in MainWin.dataGridView.Rows
                              where row.Cells[8].Value.ToString() == dgvCateg.CurrentRow.Cells[1].Value.ToString()
                              select new { })
            {
                MessageBox.Show("Категория используется и не может быть удалена");
                return;
            }

            db.OpenConnection();
            new SqlCommand($"DELETE FROM Categories WHERE categ_id = N'{dgvCateg.CurrentRow.Cells[0].Value}'", db.GetConnection()).ExecuteNonQuery();
            db.CloseConnection();
            UpdateWin();
            MessageBox.Show("Категория успешно удалена");
        }

        private void ButtBack_Click(object sender, EventArgs e)
        {
            AddEddWin.Enabled = true;
            Close();

            #region Загрузка новых данных в ComboBox

            db.OpenConnection();
            dtbl.Load(new SqlCommand("SELECT categ_id, categ_name FROM Categories", db.GetConnection()).ExecuteReader());
            AddEddWin.combBoxCateg.DataSource = dtbl;
            AddEddWin.combBoxCateg.ValueMember = "categ_id";
            AddEddWin.combBoxCateg.DisplayMember = "categ_name";
            db.CloseConnection();

            #endregion Загрузка новых данных в ComboBox
        }

        #region Настройка textbox

        // Запрет символов и цифр
        private void TextBoxCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.Match(e.KeyChar.ToString(), @"[а-яА-Я]|[a-zA-Z]").Success || e.KeyChar == (char)Keys.Back) return;
            else
                e.Handled = true;
        }

        // Запрет Enter
        private void TextBoxCat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        #endregion Настройка textbox

        private void Categories_FormClosed(object sender, FormClosedEventArgs e) => AddEddWin.Enabled = true;

        #endregion Методы
    }
}