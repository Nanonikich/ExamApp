using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamApp.Forms
{
    public partial class HistoryOrders : Form
    {
        #region Поля
        readonly MainWindow MainWin;
        readonly DB db = new DB();
        #endregion

        #region Конструктор
        public HistoryOrders(MainWindow mw)
        {
            MainWin = mw;
            InitializeComponent();
        }
        #endregion


        #region Методы

        private void ButBack_Click(object sender, EventArgs e)
        {
            MainWin.Enabled = true;
            Close();
        }


        public void UpdateTable()
        {
            DataTable dtbl = new DataTable();
            if (MainWin.User[10].ToString() == "False")
            {

                db.OpenConnection();
                dtbl.Load(new SqlCommand($"SELECT * FROM Orders WHERE ord_cust_id = N'{MainWin.User[0]}'", db.GetConnection()).ExecuteReader());
                db.CloseConnection();
                dgvOrders.DataSource = dtbl;
            }
            else
            {
                db.OpenConnection();
                dtbl.Load(new SqlCommand("SELECT * FROM Orders", db.GetConnection()).ExecuteReader());
                db.CloseConnection();
                dgvOrders.DataSource = dtbl;
            }
        }


        private void HistoryOrders_Load(object sender, EventArgs e)
        {
            UpdateTable();
            ComboBoxInDGV();

            #region Заголовки и чтение
            var i = 0;
            foreach (var j in new string[] { "ID", "Customer", "Product", "Count", "Worker", "Price", "Start date", "Over date" })
            {
                dgvOrders.Columns[i].HeaderText = j;
                dgvOrders.Columns[i].ReadOnly = true;
                i += 1;
            }
            #endregion
        }


        #region ComboBox
        private void ComboBoxInDGV()
        {
            var source = new DataTable();
            new SqlDataAdapter("SELECT * FROM Condition", db.GetConnection()).Fill(source);
            
            #region Настройки ComboBox
            DataGridViewComboBoxColumn cbbx = new DataGridViewComboBoxColumn
            {
                HeaderText = "Condition",
                DataSource = source,
                ValueMember = "condit_id",
                DisplayMember = "condit_name",
            };
            #endregion
            
            dgvOrders.Columns.Add(cbbx);

            #region Отображение по умолчанию
            //foreach (DataGridViewRow row in dgvOrders.Rows)
            //{
            //    db.OpenConnection();
            //    (row.Cells[9] as DataGridViewComboBoxCell).Value = 1;
            //    db.CloseConnection();
            //}
            #endregion

            dgvOrders.CellValueChanged += new DataGridViewCellEventHandler(DgvOrders_CellValueChanged);
            

            #region Отображение пользователям
            if (MainWin.User[0].ToString() != "25")
            {
                cbbx.Visible = false;
            }
            #endregion
        }
        #endregion


        private void DgvOrders_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                db.OpenConnection();
                new SqlCommand($"UPDATE Orders SET ord_status = {dgvOrders.CurrentRow.Cells[9].Value} WHERE ord_id = N'{dgvOrders.CurrentRow.Cells[0].Value}'", db.GetConnection()).ExecuteNonQuery();
                db.CloseConnection();
                UpdateTable(); 
            }
        }

        private void DgvOrders_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvOrders.IsCurrentCellDirty)
            {
                dgvOrders.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        private void HistoryOrders_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;

        #endregion
    }
}
