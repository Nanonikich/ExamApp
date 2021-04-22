using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamApp.Forms
{
    public partial class HistoryOrders : Form
    {
        MainWindow MainWin;
        DB db = new DB();
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
            var i = 0;
            foreach (var j in new string[] { "ID", "Customer", "Product", "Count", "Worker", "Price", "Start date", "Over date" })
            {
                dgvOrders.Columns[i].HeaderText = j;
                i += 1;
            }
            #endregion
        }

        private void HistoryOrders_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;
    }
}
