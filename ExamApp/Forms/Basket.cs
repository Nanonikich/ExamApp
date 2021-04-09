using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;

namespace ExamApp.Forms
{
    public partial class Basket : Form
    {
        MainWindow MainWin;
        DB db = new DB();

        public Basket(MainWindow mw)
        {
            MainWin = mw;
            InitializeComponent();
        }

        private void ButBack_Click(object sender, EventArgs e)
        {
            MainWin.Enabled = true;
            MainWin.UpdateTable();
            Close();
        }

        private void Basket_Load(object sender, EventArgs e)
        {
            db.OpenConnection();
            string sqlQuery = "SELECT bask_id, Products.prod_image, bask_name, bask_count_prod, bask_price, Users.user_id FROM Basket\n" +
                "join Products \n" +
                "on Products.prod_name = bask_name\n" +
                "join Users\n" +
                "on Users.user_id = bask_custom";

            var asquery = new SqlCommand(sqlQuery, db.GetConnection()).ExecuteReader();


            while (asquery.Read())
            {
                dgvBasket.Rows.Add(asquery[0],
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
            foreach (var row in from DataGridViewRow row in dgvBasket.Rows
                                where row.Cells[4].Value != null
                                select row)
            {
                result += Convert.ToDouble(row.Cells[4].Value);
            }

            labelTotal.Text = $"Total: {result.ToString()}";
        }
        
        /////////////////////////
        private void DgvBasket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvBasket.Rows[e.RowIndex];
            if (e.ColumnIndex == 6)
            {
                var db = new DB();
                db.OpenConnection();
                var dtbl = new DataTable();
                new SqlCommand($"DELETE FROM Basket WHERE bask_id = N'{dgvBasket.SelectedRows[0].Cells[0].Value}'", db.GetConnection()).ExecuteNonQuery();
                
                dgvBasket.DataSource = dtbl;

                db.CloseConnection();


                MessageBox.Show("Success");
            }
        }
        /////////////////////////
    }
}
