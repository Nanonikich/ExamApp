using ExamApp.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace ExamApp
{
    public partial class MainWindow : Form
    {
        #region Поля
        readonly SignIn _SignIn;
        readonly DataRow _User;
        readonly DB db = new DB();
        #endregion

        #region Конструктор
        public MainWindow(SignIn sn, DataRow us)
        {
            _SignIn = sn;
            _User = us;
            InitializeComponent();
        }
        #endregion

        #region Свойства
        public DataRow User { get => _User; }
        #endregion

        #region Методы

            #region Иллюзия количества
        public int GetCountFromCartByName(string name)
            {
                try
                {
                    var db = new DB();
                    db.OpenConnection();
                    var reader = new SqlCommand("SELECT SUM(cart_count_prod) FROM Cart\n" +
                                                $"Where cart_name = N'{name}'", db.GetConnection()).ExecuteReader();
                    var sum = 0;
                    while (reader.Read())
                        sum = reader.GetInt32(0);
                    return sum;
                }
                catch 
                {
                    return 0;
                }
            }
            #endregion

            #region Обновление таблицы
            public void UpdateTable()
            {
                var dtbl = new DataTable();
                db.OpenConnection();
                dtbl.Load(new SqlCommand("SELECT * FROM Products", db.GetConnection()).ExecuteReader());
                db.CloseConnection();


                #region Иллюзия 2

                for (int row = 0; row < dtbl.Rows.Count; row++)
                {
                    dtbl.Rows[row][6] = (int)dtbl.Rows[row][6] - GetCountFromCartByName((string)dtbl.Rows[row][3]);

                }

                #endregion

                dataGridView.DataSource = dtbl;
                ComboBoxUpd();

                #region Разделение на пользователей
                if (User[10].ToString() == "False")
                {
                    ButAdd.Visible = false;
                    ButEdit.Visible = false;
                    ButDel.Visible = false;
                    ButHistOrd.Visible = false;
                    ButUsers.Visible = false;
                }
                else
                {
                    ButCart.Enabled = false;  
                }
                #endregion
            }
            #endregion

            #region Загрузка окна
            private void MainWindow_Load(object sender, EventArgs e)
            {
                UpdateTable();
            }
            #endregion

            #region Значения для редактирования
            private void ReadingValues()
            {
                var edPr = new AddProd(dataGridView.CurrentRow.Cells[0].Value.ToString(), this);

                edPr.textBoxVC.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
                edPr.pictureBox.Image = Image.FromStream(new MemoryStream((byte[])dataGridView.CurrentRow.Cells[1].Value‌​));
                edPr.textBoxNam.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
                edPr.textBoxDesc.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
                edPr.textBoxPr.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
                edPr.textBoxCount.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
                edPr.textBoxCat.Text = dataGridView.CurrentRow.Cells[7].Value.ToString();

                edPr.buttAddPr.Visible = false;
                edPr.Show();
            }
            #endregion

            #region Кнопка Добавить
            private void ButAdd_Click(object sender, EventArgs e)
            {
                Enabled = false;
                var adPr = new AddProd(this);
                adPr.buttEdit.Visible = false;
                adPr.Show();
            }
            #endregion

            #region Кнопка Редактирование
            private void ButEdit_Click(object sender, EventArgs e)
            {
                if (dataGridView.Rows.Count > 0 && dataGridView.Rows != null)
                {
                    ReadingValues();
                    Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            #endregion

            #region Кнопка Удаления
            private void ButDel_Click(object sender, EventArgs e)
            {
                switch (MessageBox.Show("Do you want delete?", "Open", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        {
                            db.OpenConnection();
                            new SqlCommand($"DELETE FROM Products WHERE prod_id = N'{dataGridView.SelectedRows[0].Cells[0].Value}'", db.GetConnection()).ExecuteNonQuery();
                            db.CloseConnection();
                            UpdateTable();
                            MessageBox.Show("Success");
                            break;
                        }

                    default:
                        MessageBox.Show("Not deleted");
                        break;
                }
            }
            #endregion

            #region Поиск по тексту
            private void TxtSearch_TextChanged(object sender, EventArgs e) => dataGridView.DataSource = new BindingSource
            {
                DataSource = dataGridView.DataSource,
                Filter = "prod_name like '%" + txtSearch.Text + "%'"
            };
            #endregion

            #region ComboBox
            private void ComboBoxUpd()
            {
                comboBox.Items.Clear();
                comboBox.Items.Add("All");
                foreach (var row in from DataGridViewRow row in dataGridView.Rows
                                    where !comboBox.Items.Contains(row.Cells[7].Value.ToString())
                                    select row)
                {
                    comboBox.Items.Add(row.Cells[7].Value.ToString());
                }
            }

            private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                var dtbl = new DataTable();
            
                db.OpenConnection();

                if (comboBox.Text == "All")
                {
                    dtbl.Load(new SqlCommand("SELECT * FROM Products ", db.GetConnection()).ExecuteReader());
                    db.CloseConnection();

                    dataGridView.DataSource = dtbl;
                }
                else
                {
                    dtbl.Load(new SqlCommand($"SELECT * FROM Products WHERE prod_category = N'{comboBox.Text}'", db.GetConnection()).ExecuteReader());
                    db.CloseConnection();

                    dataGridView.DataSource = dtbl;
                }
            }
            #endregion

            #region Открытие окна Описание
            private void DataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                if (dataGridView.Rows.Count > 0 && dataGridView.Rows != null)
                {
                    Enabled = false;
                    new DescripWindow(this, dataGridView.CurrentRow).Show();
                }
            }
            #endregion

            #region Кнопка Пользователи
            private void ButUsers_Click(object sender, EventArgs e)
            {
                Enabled = false;
                var uswin = new UsersWin(this);
                uswin.Show();
            }
            #endregion

            #region Кол-во товара





            #endregion

            #region Окно История товара
            private void ButHistOrd_Click(object sender, EventArgs e)
                {
                    Enabled = false;
                    new HistoryOrders(this).Show();
                }
                #endregion

            #region Корзина
            private void ButCart_Click(object sender, EventArgs e)
            {
                Enabled = false;
                new Cart(_SignIn, this).Show();
            }
            #endregion

            #region Закрытие окна
            private void MainWindow_FormClosed(object sender, FormClosedEventArgs e) => _SignIn.Show();
        #endregion

        #endregion

    }
}
