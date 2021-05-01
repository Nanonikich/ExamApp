﻿using System;
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
            if (MainWin.User[10].ToString() == "False")
            {
                var dtbl = new DataTable();
                db.OpenConnection();
                dtbl.Load(new SqlCommand($"SELECT * FROM Orders WHERE ord_cust_id = N'{MainWin.User[0]}'", db.GetConnection()).ExecuteReader());
                db.CloseConnection();
                dgvOrders.DataSource = dtbl;
            }
            else
            {
                var dtbl = new DataTable();
                db.OpenConnection();
                dtbl.Load(new SqlCommand("SELECT * FROM Orders", db.GetConnection()).ExecuteReader());
                db.CloseConnection();
                dgvOrders.DataSource = dtbl;
            }
            
        }


        private void HistoryOrders_Load(object sender, EventArgs e)
        {
            UpdateTable();

            #region Заголовки
            var i = 0;
            foreach (var j in new string[] { "ID", "Customer", "Product", "Count", "Worker", "Price", "Start date", "Over date" })
            {
                dgvOrders.Columns[i].HeaderText = j;
                i += 1;
            }
            #endregion
        }


        private void HistoryOrders_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;

        #endregion
    }
}
