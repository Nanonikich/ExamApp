using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamApp.Forms
{
    public partial class Basket : Form
    {
        MainWindow MainWin;
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
            var db = new DB();
            var dtbl = new DataTable();
            db.OpenConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(@"SELECT * FROM Basket", db.GetConnection());
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Basket");
            dgvBasket.DataSource = ds.Tables[0];
            db.CloseConnection();
        }
    }
}
