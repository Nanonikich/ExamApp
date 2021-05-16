using ExamApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ExamApp.Forms
{
    public partial class HistoryOrders : Form
    {
        #region Поля

        private readonly MainWindow MainWin;
        private readonly DB db = new DB();
        private DataTable _TableWithAllOrders;

        #endregion Поля

        #region Свойства

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

        #endregion Свойства

        #region Конструктор

        public HistoryOrders(MainWindow mw)
        {
            MainWin = mw;
            TableWithAllOrders = new DataTable();
            InitializeComponent();
        }

        #endregion Конструктор

        #region Методы

        private void ButBack_Click(object sender, EventArgs e)
        {
            MainWin.Enabled = true;
            Close();
        }

        private void SetComboBox()
        {
            DataGridViewComboBoxColumn cbbx = new DataGridViewComboBoxColumn
            {
                Name = "Статус заказа",   /// Название столбца
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
            var reader = new SqlCommand("SELECT * FROM Orders ORDER BY ord_start_date DESC", db.GetConnection()).ExecuteReader();

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
        /// Заполняет из базы данных лист с объектами(Модели) - Conditions
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

        #endregion Заполнение свойств Моделей

        /// <summary>
        /// Устанавливает Базовые колонки для таблицы без  ComboBox
        /// </summary>
        public void SetColumn()
        {
            DataColumn[] dataColumns = new DataColumn[]
            {
                new DataColumn("ID"),
                new DataColumn("Покупатель"),
                new DataColumn("Товар"),
                new DataColumn("Количество"),
                new DataColumn("Поставщик"),
                new DataColumn("Цена"),
                new DataColumn("Дата начала"),
                new DataColumn("Дата окончания")
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
            if (id == -1)
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
                                        order.ord_start_date.ToString("dd.MM.yyyy HH:mm:ss"),
                                        order.ord_over_date.ToString("dd.MM.yyyy"),
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
                                        order.ord_start_date.ToString("dd.MM.yyyy HH:mm:ss"),
                                        order.ord_over_date.ToString("dd.MM.yyyy"),
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
                                        order.ord_start_date.ToString("dd.MM.yyyy HH:mm:ss"),
                                        order.ord_over_date.ToString("dd.MM.yyyy"),
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
                        Name = "Статус",
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
            if (MainWin.User[10].ToString() == "False") // покупатель
            {
                SetValue((int)MainWin.User[0]);

                #region Невидимые элементы

                comboBoxOrder.Visible = false;
                label5.Visible = false;
                comboBoxPokup.Visible = false;
                label2.Visible = false;
                comboBoxPost.Visible = false;
                label3.Visible = false;
                comboBoxSt.Visible = false;
                label4.Visible = false;
                panel3.Visible = false;
                dgvOrders.Top = 51;
                dgvOrders.Size = new Size(1366, 768);

                #endregion Невидимые элементы

                dgvOrders.DataSource = TableWithAllOrders;
                dgvOrders.ReadOnly = true;
            }
            else if (MainWin.User[10].ToString() == "True" && (int)MainWin.User[0] != 25) // раб
            {
                SetValue((int)MainWin.User[0]);
                comboBoxPost.Visible = false;
                label3.Visible = false;
                label4.Left = 340;
                comboBoxSt.Left = 415;
                dgvOrders.AutoGenerateColumns = false;
                dgvOrders.DataSource = TableWithAllOrders;
                ComboBoxUpd();
            }
            else // админ
            {
                SetValue();
                dgvOrders.AutoGenerateColumns = false;
                dgvOrders.DataSource = TableWithAllOrders;
                ComboBoxUpd();
            }

            ComboBoxPostUpd();
            ComboBoxPokupUpd();
            ComboBoxOrderUpd();

            db.CloseConnection();
        }

        private void HistoryOrders_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void DgvOrders_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // результативность обработки изменения в таблице
            if (dgvOrders.IsCurrentCellDirty)
            {
                dgvOrders.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// Изменение статуса заказа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #region Сортировки

        // сортировка для админа и работников

        #region Сортировка по статусу

        private void ComboBoxUpd()
        {
            if (dgvOrders.Rows.Count > 0 && dgvOrders.Rows != null)
            {
                var dAdapter = new SqlDataAdapter("SELECT condit_id, condit_name FROM Condition", db.GetConnection());
                var source = new DataTable();
                dAdapter.Fill(source);
                comboBoxSt.DataSource = source;
                comboBoxSt.ValueMember = "condit_id";
                comboBoxSt.DisplayMember = "condit_name";
            }
        }

        private void ComboBoxSt_SelectedIndexChanged(object sender, EventArgs e)
        {
            TableWithAllOrders.Clear();

            // сортировка для админа
            if (MainWin.User[0].ToString() == "25" && MainWin.User[10].ToString() == "True")
            {
                foreach (var order in _Orders.Where(o => o.ord_status == comboBoxSt.SelectedIndex + 1).ToList())
                {
                    TableWithAllOrders.Rows.Add
                        (
                            order.ord_id,
                            order.ord_cust_id,
                            order.ord_prod_id,
                            order.ord_prod_count,
                            order.ord_worker_id,
                            order.ord_price,
                            order.ord_start_date.ToString("dd.MM.yyyy HH:mm:ss"),
                            order.ord_over_date.ToString("dd.MM.yyyy"),
                            order.ord_status
                        );
                }
            }

            // сортировка для работника
            else if (MainWin.User[10].ToString() == "True")
            {
                foreach (var order in _Orders.Where(o => (o.ord_status == comboBoxSt.SelectedIndex + 1) && (o.ord_worker_id.ToString() == MainWin.User[0].ToString())).ToList())
                {
                    TableWithAllOrders.Rows.Add
                        (
                            order.ord_id,
                            order.ord_cust_id,
                            order.ord_prod_id,
                            order.ord_prod_count,
                            order.ord_worker_id,
                            order.ord_price,
                            order.ord_start_date.ToString("dd.MM.yyyy HH:mm:ss"),
                            order.ord_over_date.ToString("dd.MM.yyyy"),
                            order.ord_status
                        );
                }
            }

            dgvOrders.DataSource = TableWithAllOrders;
        }

        #endregion Сортировка по статусу

        // сортировка только для админа

        #region Сортировка по поставщику

        private void ComboBoxPostUpd()
        {
            comboBoxPost.Items.Clear();
            foreach (var row in from DataGridViewRow row in dgvOrders.Rows
                                where !comboBoxPost.Items.Contains(row.Cells[4].Value.ToString())
                                select row)
            {
                comboBoxPost.Items.Add(row.Cells[4].Value.ToString());
            }
        }

        private void ComboBoxPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            TableWithAllOrders.Clear();

            var OnlyUsersOrders = _Orders.Where(o => o.ord_worker_id.ToString() == comboBoxPost.Text).ToList();

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
                        order.ord_start_date.ToString("dd.MM.yyyy HH:mm:ss"),
                        order.ord_over_date.ToString("dd.MM.yyyy"),
                        order.ord_status
                    );
            }

            dgvOrders.DataSource = TableWithAllOrders;
        }

        #endregion Сортировка по поставщику

        // сортировка для админа и работников

        #region Сортировка по пользователю

        private void ComboBoxPokupUpd()
        {
            comboBoxPokup.Items.Clear();
            foreach (var row in from DataGridViewRow row in dgvOrders.Rows
                                where !comboBoxPokup.Items.Contains(row.Cells[1].Value.ToString())
                                select row)
            {
                comboBoxPokup.Items.Add(row.Cells[1].Value.ToString());
            }
        }

        private void ComboBoxPokup_SelectedIndexChanged(object sender, EventArgs e)
        {
            TableWithAllOrders.Clear();

            // для админа
            if (MainWin.User[0].ToString() == "25" && MainWin.User[10].ToString() == "True")
            {
                foreach (var order in _Orders.Where(o => o.ord_cust_id.ToString() == comboBoxPokup.Text).ToList())
                {
                    TableWithAllOrders.Rows.Add
                        (
                            order.ord_id,
                            order.ord_cust_id,
                            order.ord_prod_id,
                            order.ord_prod_count,
                            order.ord_worker_id,
                            order.ord_price,
                            order.ord_start_date.ToString("dd.MM.yyyy HH:mm:ss"),
                            order.ord_over_date.ToString("dd.MM.yyyy"),
                            order.ord_status
                        );
                }
            }

            // для работника
            else if (MainWin.User[10].ToString() == "True")
            {
                foreach (var order in _Orders.Where(o => (o.ord_cust_id.ToString() == comboBoxPokup.Text) && (o.ord_worker_id.ToString() == MainWin.User[0].ToString())).ToList())
                {
                    TableWithAllOrders.Rows.Add
                        (
                            order.ord_id,
                            order.ord_cust_id,
                            order.ord_prod_id,
                            order.ord_prod_count,
                            order.ord_worker_id,
                            order.ord_price,
                            order.ord_start_date.ToString("dd.MM.yyyy HH:mm:ss"),
                            order.ord_over_date.ToString("dd.MM.yyyy"),
                            order.ord_status
                        );
                }
            }

            dgvOrders.DataSource = TableWithAllOrders;
        }

        #endregion Сортировка по пользователю

        // сортировка для админа и работников

        #region Сортировка по заказам

        private void ComboBoxOrderUpd()
        {
            comboBoxOrder.Items.Clear();
            foreach (var row in from DataGridViewRow row in dgvOrders.Rows
                                where !comboBoxOrder.Items.Contains(row.Cells[0].Value.ToString())
                                select row)
            {
                comboBoxOrder.Items.Add(row.Cells[0].Value.ToString());
            }
        }

        private void ComboBoxOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            TableWithAllOrders.Clear();

            // для админа
            if (MainWin.User[0].ToString() == "25" && MainWin.User[10].ToString() == "True")
            {
                foreach (var order in _Orders.Where(o => o.ord_id.ToString() == comboBoxOrder.Text).ToList())
                {
                    TableWithAllOrders.Rows.Add
                        (
                            order.ord_id,
                            order.ord_cust_id,
                            order.ord_prod_id,
                            order.ord_prod_count,
                            order.ord_worker_id,
                            order.ord_price,
                            order.ord_start_date.ToString("dd.MM.yyyy HH:mm:ss"),
                            order.ord_over_date.ToString("dd.MM.yyyy"),
                            order.ord_status
                        );
                }
            }
            // для работников
            else if (MainWin.User[10].ToString() == "True")
            {
                foreach (var order in _Orders.Where(o => (o.ord_id.ToString() == comboBoxOrder.Text) && (o.ord_worker_id.ToString() == MainWin.User[0].ToString())).ToList())
                {
                    TableWithAllOrders.Rows.Add
                        (
                            order.ord_id,
                            order.ord_cust_id,
                            order.ord_prod_id,
                            order.ord_prod_count,
                            order.ord_worker_id,
                            order.ord_price,
                            order.ord_start_date.ToString("dd.MM.yyyy HH:mm:ss"),
                            order.ord_over_date.ToString("dd.MM.yyyy"),
                            order.ord_status
                        );
                }
            }

            dgvOrders.DataSource = TableWithAllOrders;
        }

        #endregion Сортировка по заказам

        #endregion Сортировки

        private void HistoryOrders_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;

        #endregion Методы
    }
}