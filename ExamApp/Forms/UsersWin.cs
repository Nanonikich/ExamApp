using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamApp.Forms
{
    public partial class UsersWin : Form
    {

        #region Поля
        readonly MainWindow MainWin;
        readonly DB db = new DB();
        private DataTable dtbl = new DataTable();
        #endregion

        #region Конструктор
        public UsersWin(MainWindow mw)
        {
            MainWin = mw;
            InitializeComponent();
        }
        #endregion

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
            if (MainWin.User[0].ToString() != "25")
            {
                dgvUsers.ReadOnly = true;
                dgvUsers.Columns[7].Visible = false;
                dgvUsers.Columns[8].Visible = false;
                dgvUsers.Columns[9].Visible = false;
            }


            var i = 0;
            foreach (var j in new string[] { "ID", "Surname", "Name", "Patronymic", "Email", "Phone", "City", "Address", "Username", "Password", "Status" })
            {
                dgvUsers.Columns[i].HeaderText = j;
                i += 1;
            }
            #endregion

            BtnDel();
        }

        private void BtnDel()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Name = "button",
                Text = "DELETE",
                UseColumnTextForButtonValue = true
            };
            dgvUsers.Columns.Add(btn);

            if (MainWin.User[0].ToString() != "25")
            {
                btn.Visible = false;
            }
        }

        private void DgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                if (dgvUsers.CurrentRow.Cells[0].Value.ToString() != "25")
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
                    MessageBox.Show("Admin!");
                    UpdateTable();
                }
            }

            if (e.ColumnIndex == 11)
            {
                if (dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString() == "25")
                {
                    MessageBox.Show("Admin id cannot be deleted");
                }
                else
                {
                    db.OpenConnection();
                    new SqlCommand($"DELETE FROM Users WHERE user_id = {dgvUsers.Rows[e.RowIndex].Cells[0].Value} AND user_id != {25}", db.GetConnection()).ExecuteNonQuery();
                    db.CloseConnection();
                    UpdateTable();
                    MessageBox.Show("Success");
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
            if (dgvUsers.IsCurrentCellDirty)
            {
                dgvUsers.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void UsersWin_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;
        #endregion
    }
}
