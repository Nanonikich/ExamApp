using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamApp.Forms
{
    public partial class UsersWin : Form
    {
        #region Поля

        private readonly MainWindow MainWin;
        private readonly DB db = new DB();
        private readonly DataTable dtbl = new DataTable();

        #endregion Поля

        #region Конструктор

        public UsersWin(MainWindow mw)
        {
            MainWin = mw;
            InitializeComponent();
        }

        #endregion Конструктор

        #region Методы

        public void UpdateTable()
        {
            dtbl.Clear();
            db.OpenConnection();
            dtbl.Load(new SqlCommand("SELECT * FROM Users", db.GetConnection()).ExecuteReader());
            db.CloseConnection();

            dgvUsers.DataSource = dtbl;
        }

        private void UsersWin_Load(object sender, EventArgs e)
        {
            UpdateTable();

            #region Настройки таблицы

            if (MainWin.User[0].ToString() != "1")
            {
                dgvUsers.ReadOnly = true;
                dgvUsers.Columns[7].Visible = false;
                dgvUsers.Columns[8].Visible = false;
                dgvUsers.Columns[9].Visible = false;
            }

            var i = 0;
            foreach (var j in new string[] { "ID", "Фамилия", "Имя", "Отчество", "Email", "Телефон", "Город", "Адрес", "Логин", "Пароль", "Статус" })
            {
                dgvUsers.Columns[i].HeaderText = j;
                i += 1;
            }

            #endregion Настройки таблицы

            BtnDel();
        }

        private void BtnDel()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = "Удаление",
                Name = "button",
                Text = "УДАЛИТЬ",
                UseColumnTextForButtonValue = true
            };
            dgvUsers.Columns.Add(btn);

            if (MainWin.User[0].ToString() != "1")
            {
                btn.Visible = false;
            }
        }

        /// <summary>
        /// Выдача статуса пользователям. Удаление пользователей из системы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                if (dgvUsers.CurrentRow.Cells[0].Value.ToString() != "1")
                {
                    if (!DBNull.Value.Equals(((DataGridViewCheckBoxCell)dgvUsers[e.ColumnIndex, e.RowIndex]).Value) && (bool)((DataGridViewCheckBoxCell)dgvUsers[e.ColumnIndex, e.RowIndex]).Value)
                    {
                        db.OpenConnection();
                        new SqlCommand($"UPDATE Users SET user_status = '{true}' WHERE user_id = {dgvUsers.CurrentRow.Cells[0].Value}", db.GetConnection()).ExecuteNonQuery();
                        db.CloseConnection();
                        UpdateTable();
                    }
                    else
                    {
                        db.OpenConnection();
                        new SqlCommand($"UPDATE Users SET user_status = '{false}' WHERE user_id = {dgvUsers.CurrentRow.Cells[0].Value}", db.GetConnection()).ExecuteNonQuery();
                        db.CloseConnection();
                        UpdateTable();
                    }
                }
                else
                {
                    MessageBox.Show("Статус админа изменить нельзя!");
                    UpdateTable();
                }
            }

            if (e.ColumnIndex == 11)
            {
                if (dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString() == "1")
                {
                    MessageBox.Show("Админ не может быть удалён");
                }
                else
                {
                    db.OpenConnection();
                    new SqlCommand($"DELETE FROM Users WHERE user_id = {dgvUsers.Rows[e.RowIndex].Cells[0].Value} AND user_id != {1}", db.GetConnection()).ExecuteNonQuery();
                    db.CloseConnection();
                    UpdateTable();
                    MessageBox.Show("Пользователь успешно удалён");
                }
            }
        }

        private void ButBack_Click(object sender, EventArgs e)
        {
            MainWin.Enabled = true;
            Close();
        }

        private void DgvUsers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // результативность обработки изменения в таблице
            if (dgvUsers.IsCurrentCellDirty)
            {
                dgvUsers.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void UsersWin_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;

        #endregion Методы
    }
}