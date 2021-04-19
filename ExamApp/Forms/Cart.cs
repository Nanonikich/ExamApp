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
            MainWin.UpdateTable();
            Close();
        }


        private void LoadNewDataFormCart()
        {
            db.OpenConnection();

            var asquery = new SqlCommand("SELECT cart_id, Products.prod_image, cart_name, cart_count_prod, cart_price, Users.user_id FROM Cart\n" +
                                "JOIN Products ON Products.prod_name = cart_name\n" +
                                "JOIN Users ON Users.user_id = cart_custom " +
                                $"WHERE cart_custom = N'{MainWin.User[0]}'",
                                db.GetConnection())
                .ExecuteReader();


            TableWithAllCartsProducts.Clear();
            TableWithAllCartsProducts.Load(asquery);

            dgvCart.DataSource = TableWithAllCartsProducts;

            db.CloseConnection();

        }

        private void Basket_Load(object sender, EventArgs e)
        {
            
            LoadNewDataFormCart();


            #region Колонки
            dgvCart.Columns[0].HeaderText = "ID";
            dgvCart.Columns[1].HeaderText = "Image";
            dgvCart.Columns[2].HeaderText = "Name";
            dgvCart.Columns[3].HeaderText = "Count";
            dgvCart.Columns[4].HeaderText = "Price";
            dgvCart.Columns[5].Visible = false;
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
            dgvCart.Columns[4].ReadOnly = true;

            

            TotalAmout();
        }

        public void TotalAmout()
        {
            Double result = 0;
            foreach (var row in from DataGridViewRow row in dgvCart.Rows
                                where row.Cells[4].Value != null
                                select row)
            {
                result += (Convert.ToDouble(row.Cells[4].Value) * Convert.ToDouble(row.Cells[3].Value));
            }
            labelTotal.Text = $"Total: {result}";
        }

        private void DgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var selectRow = dgvCart.CurrentRow;


            if (e.ColumnIndex == 6)
            {

                db.OpenConnection();

                var row = dgvCart.Rows[e.RowIndex].Cells[0].Value;

                string queryString = $"DELETE FROM Cart WHERE cart_id = {row}";

                new SqlCommand(queryString, db.GetConnection()).ExecuteNonQuery();
                db.CloseConnection();
                // сделать обновление


                /// Количество удалённого товара прибавляется к кол-ву продукта в гл.окне
                //var d = Convert.ToInt32(MainWin.dataGridView.CurrentRow.Cells[6].Value) + Convert.ToInt32(dgvCart.SelectedRows[0].Cells[0].Value);
                //new SqlCommand($"UPDATE Products SET prod_count = N'{d}' WHERE prod_name = N'{dgvCart.CurrentRow.Cells[1].Value}'", db.GetConnection()).ExecuteNonQuery();
                //MainWin.UpdateTable();

                LoadNewDataFormCart();

                

                MessageBox.Show("Success");
            }
        }

        private void DgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 3 && dgvCart.RowCount > 0)
            {
                SqlCommand cmd = db.GetConnection().CreateCommand();
                cmd.CommandType = CommandType.Text;
                db.OpenConnection();
                cmd.CommandText = $"UPDATE Cart SET cart_count_prod = N'{dgvCart.CurrentRow.Cells[3].Value}' WHERE cart_id = N'{dgvCart.SelectedRows[0].Cells[0].Value}'";
                cmd.ExecuteNonQuery();


                new SqlCommand($"UPDATE Products SET prod_count = N'{Convert.ToInt32(MainWin.dataGridView.CurrentRow.Cells[6].Value) - Convert.ToInt32(dgvCart.CurrentRow.Cells[3].Value)}' WHERE prod_name = N'{dgvCart.SelectedRows[0].Cells[2].Value}'", db.GetConnection()).ExecuteNonQuery();
                MainWin.UpdateTable();

                db.CloseConnection();
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
        /// Обновление количества
        private void Basket_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;
    }
}
