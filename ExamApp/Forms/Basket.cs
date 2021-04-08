using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            var dtbl = new DataTable();


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


            // итоговая сумма

            Double result = 0;
            foreach (DataGridViewRow row in dgvBasket.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    result += Convert.ToDouble(row.Cells[4].Value);
                }
            }
            labelTotal.Text = "Total: " + result.ToString();
        }
        

        private void DgvBasket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (MessageBox.Show("Do you want delete?", "Open", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                {
                    var db = new DB();
                    var v = new SqlCommand($"DELETE FROM Basket WHERE bask_id = N'{dgvBasket.SelectedRows[0].Cells[0].Value.ToString()}'", db.GetConnection());
                    db.OpenConnection();
                    v.ExecuteNonQuery();
                    db.CloseConnection();
                    MessageBox.Show("Success");
                    break;
                }

                default:
                    MessageBox.Show("Not deleted");
                    break;
            }
        }
    }
}
