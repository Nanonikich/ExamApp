using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ExamApp.Forms
{
    public partial class Cart : Form
    {
        SignIn _SignIn;
        MainWindow MainWin;
        DB db = new DB();

        public Cart(SignIn sn, MainWindow mw)
        {
            _SignIn = sn;
            MainWin = mw;
            InitializeComponent();
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            db.OpenConnection();

            var asquery = new SqlCommand("SELECT cart_id, Products.prod_image, cart_name, cart_count_prod, cart_price, Users.user_id FROM Cart\n" +
                                "JOIN Products ON Products.prod_name = cart_name\n" +
                                "JOIN Users ON Users.user_id = cart_custom " +
                                $"WHERE cart_custom = N'{MainWin.User[0]}'", db.GetConnection()).ExecuteReader();


            while (asquery.Read())
            {
                dgvCart.Rows.Add(asquery[0],
                                   asquery[1],
                                   asquery[2].ToString(),
                                   asquery[3].ToString(),
                                   asquery[4].ToString(),
                                   asquery[5].ToString());
            }

            db.CloseConnection();

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
            if (e.ColumnIndex == 6)
            {
                db.OpenConnection();
                new SqlCommand($"DELETE FROM Cart WHERE cart_id = N'{dgvCart.SelectedRows[0].Cells[0].Value}'", db.GetConnection()).ExecuteNonQuery();

                /// Организовать обновление после удаления \\\
                new Cart(_SignIn, MainWin).Show();
                Close();
                db.CloseConnection();

                MessageBox.Show("Success");
            }
        }

        /// Обновление количества
        private void DgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 3)
            //{
            //    SqlCommand cmd = db.GetConnection().CreateCommand();
            //    cmd.CommandType = CommandType.Text;
            //    db.OpenConnection();
            //    cmd.CommandText = $"UPDATE Basket SET bask_count_prod = N'{0}' WHERE bask_id = N'{172}'";
            //    cmd.ExecuteNonQuery();
            //    db.CloseConnection();
            //}
        }

        private void EdProf_Click(object sender, EventArgs e)
        {
            Enabled = false;
            ReadVal();
        }

        private void ButBack_Click(object sender, EventArgs e)
        {
            MainWin.Enabled = true;
            MainWin.UpdateTable();
            Close();
        }


        private void ReadVal()
        {
            db.OpenConnection();
            var asquery = new SqlCommand($"Select * FROM Users WHERE user_id = N'{MainWin.User[0]}'", db.GetConnection()).ExecuteReader();
            var edProf = new SignUp(MainWin.User[0].ToString(), _SignIn);
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
            edProf.butnReg.Enabled = false;
            Close();
            MainWin.Close();
            edProf.Show();
        }

        private void Cart_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;
    }
}
