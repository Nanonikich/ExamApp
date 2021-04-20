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
    public partial class HistoryOrders : Form
    {
        MainWindow MainWin;
        public HistoryOrders(MainWindow mw)
        {
            MainWin = mw;
            InitializeComponent();
        }

        private void ButBack_Click(object sender, EventArgs e)
        {
            MainWin.Enabled = true;
            Close();
        }

        public void UpdateTable()
        {
            var db = new DB();
            var dtbl = new DataTable();
            db.OpenConnection();
            dtbl.Load(new SqlCommand("SELECT * FROM Orders", db.GetConnection()).ExecuteReader());
            db.GetConnection().Close();

            

            dgvOrders.DataSource = dtbl;
        }

        private void HistoryOrders_Load(object sender, EventArgs e)
        {
            UpdateTable();

            #region Колонки
            dgvOrders.Columns[0].HeaderText = "ID";
            dgvOrders.Columns[1].HeaderText = "Customer";
            dgvOrders.Columns[2].HeaderText = "Product";
            dgvOrders.Columns[3].HeaderText = "Count";
            dgvOrders.Columns[4].HeaderText = "Worker";
            dgvOrders.Columns[5].HeaderText = "Price";
            dgvOrders.Columns[6].HeaderText = "Start date";
            dgvOrders.Columns[7].HeaderText = "Over date";
            #endregion
        }
    }
}
