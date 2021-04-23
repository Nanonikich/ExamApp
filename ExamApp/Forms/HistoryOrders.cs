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
            #region Кнопка возврата
            private void ButBack_Click(object sender, EventArgs e)
            {
                MainWin.Enabled = true;
                Close();
            }
            #endregion

            #region Обновление таблицы
            public void UpdateTable()
            {
                var dtbl = new DataTable();
                db.OpenConnection();
                dtbl.Load(new SqlCommand("SELECT * FROM Orders", db.GetConnection()).ExecuteReader());
                db.CloseConnection();

                dgvOrders.DataSource = dtbl;
            }
            #endregion

            #region Загрузка окна
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
            #endregion

            #region Закрытие формы
            private void HistoryOrders_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;
            #endregion
        #endregion
    }
}
