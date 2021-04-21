using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;

namespace ExamApp.Forms
{
    public partial class Cart : Form
    {
        SignIn _SignIn;
        MainWindow MainWin;
        DB db = new DB();
        private DataTable _TableWithAllCartsProducts;

        public DataTable TableWithAllCartsProducts
        {
            get => _TableWithAllCartsProducts;
            set
            {
                _TableWithAllCartsProducts = value;
            }
        }

        public Cart(SignIn sn, MainWindow mw)
        {
            _SignIn = sn;
            MainWin = mw;
            TableWithAllCartsProducts = new DataTable();
            InitializeComponent();
        }

        private void ButBack_Click(object sender, EventArgs e)
        {
            MainWin.Enabled = true;
            Close();
        }

        private void LoadNewDataFormCart()
        {
            db.OpenConnection();

            var asquery = new SqlCommand("SELECT cart_id, cart_prod_id, Products.prod_image, cart_name, cart_count_prod, cart_price, Users.user_id FROM Cart\n" +
                                "JOIN Products ON Products.prod_id = cart_prod_id\n" +
                                "JOIN Users ON Users.user_id = cart_custom " +
                                $"WHERE cart_custom = N'{MainWin.User[0]}'",
                                db.GetConnection())
                .ExecuteReader();
            
            TableWithAllCartsProducts.Clear();
            TableWithAllCartsProducts.Load(asquery);
            TotalAmout();
            dgvCart.DataSource = TableWithAllCartsProducts;

            db.CloseConnection();

        }

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

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Delete";
            btn.Name = "button";
            btn.Text = "DELETE";
            btn.UseColumnTextForButtonValue = true;
            dgvCart.Columns.Add(btn);



            dgvCart.Columns[0].ReadOnly = true;
            dgvCart.Columns[1].ReadOnly = true;
            dgvCart.Columns[2].ReadOnly = true;
            dgvCart.Columns[3].ReadOnly = true;
            dgvCart.Columns[5].ReadOnly = true;

            

            TotalAmout();
        }


        // Общая цена за выбранные товары
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

        // Удаление товара из корзины по кнопке
        private void DgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var selectRow = dgvCart.CurrentRow;


            if (e.ColumnIndex == 7)
            {

                db.OpenConnection();

                var row = dgvCart.Rows[e.RowIndex].Cells[0].Value;

                string queryString = $"DELETE FROM Cart WHERE cart_id = {row}";

                new SqlCommand(queryString, db.GetConnection()).ExecuteNonQuery();

                db.CloseConnection();

                LoadNewDataFormCart();

                MainWin.UpdateTable();
                

                MessageBox.Show("Success");
            }
        }

        // Изменение количества в корзине
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

        private void EdProf_Click(object sender, EventArgs e)
        {
            Enabled = false;
            ReadVal();
        }

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


        private void Basket_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;


        private void ButApply_Click(object sender, EventArgs e)
        {
            if (dgvCart.RowCount > 0 || dgvCart.Columns[6] == MainWin.User[0])
                //db.OpenConnection();
                //new SqlCommand($"INSERT INTO Orders VALUES(cart_custom, cart_id, cart_count_prod, {0}, cart_price, '{2020 - 12 - 02}', {2020 - 12 - 29}) WHERE cart_custom == {MainWin.User[0]}", db.GetConnection()).ExecuteNonQuery();
                //db.CloseConnection();
            MessageBox.Show("Your order is accepted");
        }
    }
}
