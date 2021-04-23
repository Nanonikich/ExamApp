using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;

namespace ExamApp.Forms
{
    public partial class Cart : Form
    {
        #region Поля
        readonly SignIn _SignIn;
        readonly MainWindow MainWin;
        readonly DB db = new DB();
        private DataTable _TableWithAllCartsProducts;
        #endregion

        #region Свойство
        public DataTable TableWithAllCartsProducts
        {
            get => _TableWithAllCartsProducts;
            set
            {
                _TableWithAllCartsProducts = value;
            }
        }
        #endregion

        #region Конструктор
        public Cart(SignIn sn, MainWindow mw)
        {
            _SignIn = sn;
            MainWin = mw;
            TableWithAllCartsProducts = new DataTable();
            InitializeComponent();
        }
        #endregion

        #region Методы

            #region Кнопка возврата
            private void ButBack_Click(object sender, EventArgs e)
            {
                MainWin.Enabled = true;
                Close();
            }
            #endregion

            #region Обновление формы
            private void LoadNewDataFormCart()
            {
                db.OpenConnection();

                TableWithAllCartsProducts.Clear();
                TableWithAllCartsProducts.Load(new SqlCommand("SELECT cart_id, cart_prod_id, Products.prod_image, cart_name, cart_count_prod, cart_price, Users.user_id FROM Cart\n" +
                                                "JOIN Products ON Products.prod_id = cart_prod_id\n" +
                                                "JOIN Users ON Users.user_id = cart_custom " +
                                                $"WHERE cart_custom = N'{MainWin.User[0]}'",
                                                db.GetConnection())
                                                .ExecuteReader());

                TotalAmout();

                dgvCart.DataSource = TableWithAllCartsProducts;

                db.CloseConnection();

                StretchToImage();
            }
            #endregion

            #region Загрузка формы
            private void Basket_Load(object sender, EventArgs e)
            {
                LoadNewDataFormCart();

                #region Колонки
                dgvCart.Columns[0].HeaderText = "ID";
                dgvCart.Columns[1].HeaderText = "Vendor code";
                dgvCart.Columns[2].HeaderText = "Image";
                dgvCart.Columns[3].HeaderText = "Name";
                dgvCart.Columns[4].HeaderText = "Count";
                dgvCart.Columns[5].HeaderText = "Price";
                dgvCart.Columns[6].Visible = false;
                #endregion

                BtnDel();

                #region Доступ к чтению
                dgvCart.Columns[0].ReadOnly = true;
                dgvCart.Columns[1].ReadOnly = true;
                dgvCart.Columns[2].ReadOnly = true;
                dgvCart.Columns[3].ReadOnly = true;
                dgvCart.Columns[5].ReadOnly = true;
                #endregion

                TotalAmout();
            }
            #endregion

            #region Кнопка удаления в таблице
            private void BtnDel()
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn
                {
                    HeaderText = "Delete",
                    Name = "button",
                    Text = "DELETE",
                    UseColumnTextForButtonValue = true
                };
                dgvCart.Columns.Add(btn);
            }
            #endregion

            #region Отображение изображения в ячейке
            public void StretchToImage()
            {
                foreach (var dc in from DataGridViewRow dr in dgvCart.Rows
                                   from DataGridViewCell dc in dr.Cells
                                   where dc.GetType() == typeof(DataGridViewImageCell)
                                   select dc)
                {
                    ((DataGridViewImageCell)dc).ImageLayout = DataGridViewImageCellLayout.Stretch;
                }
            }
            #endregion

            #region Общая цена за товары
            public void TotalAmout()
            {
                Double result = 0;
                foreach (var row in from DataGridViewRow row in dgvCart.Rows
                                    where row.Cells[5].Value != null
                                    select row)
                {
                    result += (Convert.ToDouble(row.Cells[5].Value) * Convert.ToDouble(row.Cells[4].Value));
                }
                labelTotal.Text = $"Total: {result}";
            }
            #endregion

            #region Удаление товара
            private void DgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == 7)
                {
                    db.OpenConnection();

                    new SqlCommand($"DELETE FROM Cart WHERE cart_id = {dgvCart.Rows[e.RowIndex].Cells[0].Value}", db.GetConnection()).ExecuteNonQuery();

                    db.CloseConnection();

                    LoadNewDataFormCart();
                    MainWin.UpdateTable();
                
                    MessageBox.Show("Success");
                }
            }
            #endregion

            #region Изменения количества товаров
            private void DgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == 4 && dgvCart.RowCount > 0)
                {
                    db.OpenConnection();
                    new SqlCommand($"UPDATE Cart SET cart_count_prod = N'{dgvCart.CurrentRow.Cells[4].Value}' WHERE cart_id = N'{dgvCart.SelectedRows[0].Cells[0].Value}'", db.GetConnection()).ExecuteNonQuery();
                    TotalAmout();
                    db.CloseConnection();

                    LoadNewDataFormCart();
                    MainWin.UpdateTable();
                }
            }
            #endregion

            #region Редактирование профиля
            private void EdProf_Click(object sender, EventArgs e)
            {
                Enabled = false;
                ReadVal();
            }
            #endregion

            #region Чтение информации о пользователе
            private void ReadVal()
            {
                db.OpenConnection();
                var asquery = new SqlCommand($"Select * FROM Users WHERE user_id = N'{MainWin.User[0]}'", db.GetConnection()).ExecuteReader();
                var edProf = new SignUp(_SignIn, MainWin.User[0].ToString());
                while (asquery.Read())
                {
                    edProf.textBoxSurn.Text = asquery.GetString(1);
                    edProf.textBoxName.Text = asquery.GetString(2);
                    edProf.textBoxPatr.Text = asquery.GetString(3);
                    edProf.textBoxEmail.Text = asquery.GetString(4);
                    edProf.textBoxPhone.Text = asquery.GetString(5);
                    edProf.textBoxCity.Text = asquery.GetString(6);
                    edProf.textBoxAddr.Text = asquery.GetString(7);
                    edProf.textBoxUsname.Text = asquery.GetString(8);
                    edProf.textBoxPassw.Text = asquery.GetString(9);
                }

                Close();
                MainWin.Close();
                edProf.butnReg.Visible = false;
                edProf.Show();
            }
            #endregion

            #region Кнопка Оплата
            private void ButApply_Click(object sender, EventArgs e)
            {
                if (dgvCart.RowCount > 0 || dgvCart.Columns[6] == MainWin.User[0])
                {
                    #region Передача заказа в Историю заказов
                    db.OpenConnection();
                    new SqlCommand($"INSERT INTO Orders(ord_cust_id, ord_prod_id, ord_prod_count, ord_worker_id, ord_price, ord_start_date, ord_over_date) SELECT cart_custom, cart_prod_id, cart_count_prod, Users.user_id, cart_price, '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', '{DateTime.Today.AddDays(18):yyyy-MM-dd}' FROM Cart\n" +
                        $"JOIN Users ON Users.user_status = 'True' \n" +
                        $"WHERE cart_custom = { MainWin.User[0] }", db.GetConnection()).ExecuteNonQuery();
                    new SqlCommand($"DELETE Cart WHERE cart_custom = { MainWin.User[0] }", db.GetConnection()).ExecuteNonQuery();

                    LoadNewDataFormCart();

                    db.CloseConnection();
                    #endregion

                    MessageBox.Show("Your order is accepted");
                }
                else
                {
                    MessageBox.Show("Empty cart");
                }
            }
            #endregion

            #region Закрытие формы
            private void Basket_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;
            #endregion

        #endregion
    }
}
