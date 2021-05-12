﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;

namespace ExamApp.Forms
{
    public partial class Cart : Form
    {
        #region Поля

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
        public Cart(MainWindow mw)
        {
            MainWin = mw;
            TableWithAllCartsProducts = new DataTable();
            InitializeComponent();
        }
        #endregion

        #region Методы
        private void ButBack_Click(object sender, EventArgs e)
        {
            MainWin.Enabled = true;
            Close();
        }

        #region Загрузка
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
            dgvCart.Columns[0].Visible = false;
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

        /// <summary>
        /// Подсчёт итоговой цены за все товары
        /// </summary>
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

        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Изменение количества товара в корзине
        /// Если изменения произошли в четвёртом столбце и введённые значения не противоречат данным
        /// в этой таблице и других таблицах. Происходит обновление количества товара в корзине(+ бронирование)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && dgvCart.RowCount > 0)
            {
                foreach (DataGridViewRow r in MainWin.dataGridView.Rows)
                {
                    if (Convert.ToInt32(dgvCart.CurrentRow.Cells[4].Value) < 1 || Convert.ToInt32(r.Cells[6].Value) < 0)
                    {
                        db.OpenConnection();
                        new SqlCommand($"UPDATE Cart SET cart_count_prod = N'{1}' WHERE cart_prod_id = N'{r.Cells[0].Value}' AND cart_custom = N'{MainWin.User[0]}'", db.GetConnection()).ExecuteNonQuery();
                        TotalAmout();
                        db.CloseConnection();
                        LoadNewDataFormCart();
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        db.OpenConnection();

                        new SqlCommand($"UPDATE Cart SET cart_count_prod = N'{dgvCart.CurrentRow.Cells[4].Value}' WHERE cart_id = N'{dgvCart.SelectedRows[0].Cells[0].Value}'", db.GetConnection()).ExecuteNonQuery();
                        TotalAmout();
                        db.CloseConnection();

                        LoadNewDataFormCart();
                        MainWin.UpdateTable();
                    }
                }
            }
        }


        // Покупка товара
        private void ButApply_Click(object sender, EventArgs e)
        {
            if (dgvCart.RowCount > 0 || dgvCart.Columns[6] == MainWin.User[0])
            {
                if (!String.IsNullOrWhiteSpace(textBoxNumb.Text) && !String.IsNullOrWhiteSpace(textBoxCvv.Text) && !String.IsNullOrWhiteSpace(textBoxMM.Text) && !String.IsNullOrWhiteSpace(textBoxYear.Text))
                {
                    #region Сохранение заказа в истории
                    db.OpenConnection();
                    new SqlCommand($"INSERT INTO Orders(ord_cust_id, ord_prod_id, ord_prod_count, ord_worker_id, ord_price, ord_start_date, ord_over_date) SELECT cart_custom, cart_prod_id, cart_count_prod, Users.user_id, cart_price, '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', '{DateTime.Today.AddDays(18):yyyy-MM-dd}' FROM Cart\n" +
                                   $"JOIN Users ON Users.user_status = 'True'\n" +
                                   $"WHERE cart_custom = { MainWin.User[0] } AND Users.user_id != N'{25}'", db.GetConnection()).ExecuteNonQuery();
                    new SqlCommand($"DELETE Cart WHERE cart_custom = { MainWin.User[0] }", db.GetConnection()).ExecuteNonQuery();

                    LoadNewDataFormCart();

                    db.CloseConnection();
                    #endregion

                    MessageBox.Show("Your order is accepted");
                }
                else 
                {
                    MessageBox.Show("Fields are not filled");
                }
            }
            else
            {
                MessageBox.Show("Empty cart");
            }
        }

        #region Настройка textBoxes 
        private void TextBoxNumb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void TextBoxNumb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        #region Input in Cell
        private void DgvCart_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Cell_KeyPress);
        }

        private void Cell_KeyPress(object Sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.KeyChar = Convert.ToChar("\0");
        }
        #endregion

        private void Basket_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;
        #endregion
    }
}
