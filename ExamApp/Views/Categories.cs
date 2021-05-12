using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamApp.Forms
{
    public partial class Categories : Form
    {
        #region Поля
        readonly AddProd AddEddWin;
        readonly DB db = new DB();
        readonly MainWindow MainWin;
        #endregion

        #region Конструктор
        public Categories(AddProd ae, MainWindow mw)
        {
            AddEddWin = ae;
            MainWin = mw;
            InitializeComponent();
        }
        #endregion

        #region Методы

        private void UpdateWin()
        {
            var dtbl = new DataTable();
            db.OpenConnection();

            dtbl.Load(new SqlCommand("SELECT categ_id, categ_name FROM Categories",
                                            db.GetConnection())
                                            .ExecuteReader());

            dgvCateg.DataSource = dtbl;

            #region Настройки таблицы
            dgvCateg.ReadOnly = true;
            dgvCateg.Columns[0].Visible = false;
            dgvCateg.Columns[1].HeaderText = "Category";
            #endregion

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
                if (textBoxCat.Text.ToString() == System.Convert.ToString(dgvCateg.Rows[i].Cells[1].Value) && dgvCateg.RowCount > 0 || textBoxCat.Text == "")
                {
                    MessageBox.Show("Error");
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
            foreach (DataGridViewRow row in MainWin.dataGridView.Rows)
            { 
                if (row.Cells[8].Value.ToString() == dgvCateg.CurrentRow.Cells[1].Value.ToString())
                {
                    MessageBox.Show("Can't be deleted");
                    return;
                }
            }
            db.OpenConnection();
            new SqlCommand($"DELETE FROM Categories WHERE categ_id = N'{dgvCateg.CurrentRow.Cells[0].Value}'", db.GetConnection()).ExecuteNonQuery();
            db.CloseConnection();
            UpdateWin();
            MessageBox.Show("Success");
        }

        private void ButtBack_Click(object sender, EventArgs e)
        {
            AddEddWin.Enabled = true;
            Close();

            #region Загрузка новых данных в ComboBox
            var dAdapter = new SqlDataAdapter("SELECT categ_id, categ_name FROM Categories", db.GetConnection());
            var source = new DataTable();
            dAdapter.Fill(source);
            AddEddWin.combBoxCateg.DataSource = source;
            AddEddWin.combBoxCateg.ValueMember = "categ_id";
            AddEddWin.combBoxCateg.DisplayMember = "categ_name";
            #endregion
        }

        #region Настройка textbox
        private void TextBoxCat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        private void Categories_FormClosed(object sender, FormClosedEventArgs e) => AddEddWin.Enabled = true;

        #endregion

    }
}
