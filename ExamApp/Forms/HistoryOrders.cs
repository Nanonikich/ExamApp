using ExamApp.Models;
using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ExamApp.Forms
{
    public partial class HistoryOrders : Form
    {

        #region Поля
        readonly MainWindow MainWin;
        readonly DB db = new DB();
        private DataTable _TableWithAllOrders;
        #endregion

        #region Свойство
        public DataTable TableWithAllOrders
        {
            get => _TableWithAllOrders;
            set
            {
                _TableWithAllOrders = value;
            }
        }
        
        private List<Condition> _Conditions;

        private List<Orders> _Orders;

        #endregion

        #region Конструктор
        public HistoryOrders(MainWindow mw)
        {
            MainWin = mw;
            TableWithAllOrders = new DataTable();
            InitializeComponent();
        }
        #endregion

        #region Методы

        /// <summary>
        /// Кнопка назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButBack_Click(object sender, EventArgs e)
        {
            MainWin.Enabled = true;
            Close();
        }

        /// <summary>
        /// Устанавливает настройки ComboBox
        /// </summary>
        private void SetComboBox()
        {

            DataGridViewComboBoxColumn cbbx = new DataGridViewComboBoxColumn
            {
                Name = "ord_status",   /// Название столбца 
                DataPropertyName = "ord_status", /// Свойство связывающее с названием столбца в DataTable
                DataSource = _Conditions, /// Источники ComboBox берется из свойства List<Condition> _Conditions
                DisplayMember = "condit_name", /// отображает имя из объекта Condition
                ValueMember = "condit_id" /// значение для сравнения с DataPropertyName
            };

            dgvOrders.Columns.Add(cbbx);
            return;

        }

        #region Заполнение свойств Моделей

        /// <summary>
        /// Заполняет из базы данных лист с объектам(Модели) - Orders
        /// </summary>
        public void SetValueOrders()
        {

            _Orders = new List<Orders>();

            db.OpenConnection();
            var reader = new SqlCommand("SELECT * FROM Orders", db.GetConnection()).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _Orders.Add
                        (
                            new Orders()
                            {
                                ord_id = (int)reader[0],
                                ord_cust_id = (int)reader[1],
                                ord_prod_id = (int)reader[2],
                                ord_prod_count = (int)reader[3],
                                ord_worker_id = (int)reader[4],
                                ord_price = (int)reader[5],
                                ord_start_date = (DateTime)reader[6],
                                ord_over_date = (DateTime)reader[7],
                                ord_status = (int)reader[8],
                            }
                        );
                }
            }

            else return;

            db.CloseConnection();

        }

        /// <summary>
        /// Заполняет из базы данных лист с объектам(Модели) - Conditions
        /// </summary>
        private void SetValueConditions()
        {
            _Conditions = new List<Condition>();

            db.OpenConnection();
            var reader = new SqlCommand("SELECT * FROM Condition", db.GetConnection()).ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _Conditions.Add
                    (
                        new Condition()
                        {
                            condit_id = (int)reader[0],
                            condit_name = (string)reader[1],
                        }
                    );
                }
            }
            
            db.CloseConnection();

        }

        #endregion

        /// <summary>
        /// Устанавливает Базовые колонки для Таблицы 
        /// Без ord_statusm или же ComboBox
        /// </summary>
        public void SetColumn()
        {

            DataColumn[] dataColumns = new DataColumn[]
            {
                new DataColumn("ID"),
                new DataColumn("ord_cust_id"),
                new DataColumn("ord_prod_id"),
                new DataColumn("ord_prod_count"),
                new DataColumn("ord_worker_id"),
                new DataColumn("ord_price"),
                new DataColumn("ord_start_date"),
                new DataColumn("ord_over_date")

            };

            foreach (var column in dataColumns)
            {
                dgvOrders.Columns.Add
                    (
                        new DataGridViewTextBoxColumn()
                        {
                            Name = column.ColumnName,
                            DataPropertyName = column.ColumnName
                        }
                    );
            }

            TableWithAllOrders.Columns.AddRange(dataColumns);

        }

        /// <summary>
        /// Устанавливает значение в таблицу | 
        /// Принимает параметр с id пользователя или рабочего
        /// ! Если это админ, то берется базовое значение -1 
        /// и при вызове не нужно уточнять id
        /// </summary>
        /// <param name="id">
        /// Принимает параметр с id пользователя или рабочего
        /// ! Если это админ, то берется базовое значение -1 
        /// и при вызове не нужно уточнять id
        /// </param>
        private void SetValue(int id = -1)
        {
            if(id == -1)
            {
                foreach (var order in _Orders)
                {

                    TableWithAllOrders.Rows.Add
                        (
                            order.ord_id,
                            order.ord_cust_id,
                            order.ord_prod_id,
                            order.ord_prod_count,
                            order.ord_worker_id,
                            order.ord_price,
                            order.ord_start_date,
                            order.ord_over_date,
                            order.ord_status
                        );
                        
                }
            }
            else if (MainWin.User[10].ToString() == "True")
            {
                var OnlyUsersOrders = _Orders.Where(o => o.ord_worker_id == id).ToList();

                foreach (var order in OnlyUsersOrders)
                {

                    TableWithAllOrders.Rows.Add
                        (
                            order.ord_id,
                            order.ord_cust_id,
                            order.ord_prod_id,
                            order.ord_prod_count,
                            order.ord_worker_id,
                            order.ord_price,
                            order.ord_start_date,
                            order.ord_over_date,
                            order.ord_status
                        );
                }
            }
            else
            {
                var OnlyUsersOrders = _Orders.Where(o => o.ord_cust_id == id).ToList();

                foreach (var order in OnlyUsersOrders)
                {

                    TableWithAllOrders.Rows.Add
                        (
                            order.ord_id,
                            order.ord_cust_id,
                            order.ord_prod_id,
                            order.ord_prod_count,
                            order.ord_worker_id,
                            order.ord_price,
                            order.ord_start_date,
                            order.ord_over_date,
                            _Conditions.SingleOrDefault(c => c.condit_id == order.ord_status).condit_name
                        ); 

                }
            }
        }

        /// <summary>
        /// Устанавливает колонки с учетом статуса в системе
        /// </summary>
        private void SetColumnOnStatus()
        {
            /// заполняет базовые колонки
            SetColumn();

            if (MainWin.User[10].ToString() == "False")
            {
                TableWithAllOrders.Columns.Add(new DataColumn("ord_status"));
                dgvOrders.Columns.Add(
                    new DataGridViewTextBoxColumn()
                    {
                        Name = "ord_status",
                        DataPropertyName = "ord_status"
                    }
                );
            }
            else if (MainWin.User[10].ToString() == "True")
            {
                TableWithAllOrders.Columns.Add(new DataColumn("ord_status", typeof(Int32)));
                SetComboBox();
            }
            else
            {
                TableWithAllOrders.Columns.Add(new DataColumn("ord_status", typeof(Int32)));
                SetComboBox();
            }
        }

        /// <summary>
        /// Обновляет полностью таблицу
        /// </summary>
        public void UpdateTable()
        {
            /// Подгружает значения 
            SetValueConditions();
            SetValueOrders();

            /// Проверяет наличие столбцов 
            /// Если нет то заполняет
            if (dgvOrders.Columns.Count < 1)
            {
                SetColumnOnStatus();
            }

            /// Отчищает таблицу от данных
            TableWithAllOrders.Clear();

            /// заполняет с учетом статуса
            if (MainWin.User[10].ToString() == "False")
            {
                SetValue((int)MainWin.User[0]);

                dgvOrders.DataSource = TableWithAllOrders;
                dgvOrders.ReadOnly = true;
            }
            else if (MainWin.User[10].ToString() == "True")
            {
                SetValue((int)MainWin.User[0]);

                dgvOrders.AutoGenerateColumns = false;
                dgvOrders.DataSource = TableWithAllOrders;
            }
            else
            {
                SetValue();
                dgvOrders.AutoGenerateColumns = false;
                dgvOrders.DataSource = TableWithAllOrders;
            }

            db.CloseConnection();
        }

        #endregion

        #region Команды

        private void HistoryOrders_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void DgvOrders_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvOrders.IsCurrentCellDirty)
            {
                dgvOrders.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvOrders_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {

                var newValue = dgvOrders.CurrentRow.Cells[8].Value;
                var id = dgvOrders.CurrentRow.Cells[0].Value;

                db.OpenConnection();
                new SqlCommand($"UPDATE Orders \n" +
                               $"SET ord_status = {newValue} \n" +
                               $"WHERE ord_id = {id}", 
                    db.GetConnection()).ExecuteNonQuery();
                db.CloseConnection();
                UpdateTable();
                return;
            }
        }

        private void HistoryOrders_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;

        #endregion

    }
}
