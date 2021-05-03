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
            var dtbl = new DataTable();
            db.OpenConnection();
            dtbl.Load(new SqlCommand("SELECT * FROM Users", db.GetConnection()).ExecuteReader());
            db.CloseConnection();

            dgvUsers.DataSource = dtbl;
        }


        private void UsersWin_Load(object sender, EventArgs e)
        {
            UpdateTable();


            var i = 0;
            foreach (var j in new string[] { "ID", "Surname", "Name", "Patronymic", "Email", "Phone", "City", "Address", "Username", "Password", "Status" })
            {
                dgvUsers.Columns[i].HeaderText = j;
                i += 1;
            }
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
        }

        private void DgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 11)
                {
                    db.OpenConnection();

                    new SqlCommand($"DELETE FROM Users WHERE user_id = {dgvUsers.Rows[e.RowIndex].Cells[0].Value}", db.GetConnection()).ExecuteNonQuery();

                    db.CloseConnection();

                    UpdateTable();

                    MessageBox.Show("Success");
                }
            }
            catch 
            { 
                MessageBox.Show("You are in the system");
            }
        }


        private void DgvUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                if (dgvUsers.Columns[e.ColumnIndex].Name == "Status")
                {
                    DataGridViewCheckBoxCell checkCell =
                        (DataGridViewCheckBoxCell)dgvUsers.
                        Rows[e.RowIndex].Cells["CheckBoxes"];

                    dgvUsers.Invalidate();
                }
            }
            UpdateTable();
        }

        private void ButBack_Click(object sender, EventArgs e)
        {
            MainWin.Enabled = true;
            Close();
        }


        private void UsersWin_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;
        #endregion

        
    }
}
