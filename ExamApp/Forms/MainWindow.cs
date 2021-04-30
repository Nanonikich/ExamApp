using ExamApp.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace ExamApp
{
    public partial class MainWindow : Form
    {
        #region Поля
        readonly SignIn _SignIn;
        readonly DataRow _User;
        readonly DB db = new DB();
        #endregion

        #region Конструктор
        public MainWindow(SignIn sn, DataRow us)
        {
            _SignIn = sn;
            _User = us;
            InitializeComponent();
        }
        #endregion

        #region Свойства
        public DataRow User { get => _User; }
        #endregion

        #region Методы

        public int GetCountFromCartByName(string name)
        {
            try
            {
                var db = new DB();
                db.OpenConnection();
                var reader = new SqlCommand("SELECT SUM(cart_count_prod) FROM Cart\n" +
                                            $"Where cart_name = N'{name}'", db.GetConnection()).ExecuteReader();
                var sum = 0;
                while (reader.Read())
                    sum = reader.GetInt32(0);
                return sum;
            }
            catch 
            {
                return 0;
            }
        }


        public void UpdateTable()
        {
            var dtbl = new DataTable();
            db.OpenConnection();
            dtbl.Load(new SqlCommand("SELECT prod_id, prod_image, prod_imgUrl, prod_name, prod_descr, prod_price, prod_count, prod_category, Categories.categ_name FROM Products \n" +
                "JOIN Categories ON Categories.categ_id = prod_category", db.GetConnection()).ExecuteReader());
            db.CloseConnection();


            #region Иллюзия

            for (int row = 0; row < dtbl.Rows.Count; row++)
            {
                dtbl.Rows[row][6] = (int)dtbl.Rows[row][6] - GetCountFromCartByName((string)dtbl.Rows[row][3]);

            }

            #endregion

            dataGridView.DataSource = dtbl;
            ComboBoxUpd();

            #region Разделение на пользователей
            if (User[10].ToString() == "False")
            {
                ButAdd.Visible = false;
                ButEdit.Visible = false;
                ButDel.Visible = false;
                ButHistOrd.Visible = false;
                ButUsers.Visible = false;
            }
            else
            {
                ButCart.Enabled = false;
            }
            #endregion
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }


        #region Значения для редактирования
        private void ReadingValues()
        {
            var edPr = new AddProd(dataGridView.CurrentRow.Cells[0].Value.ToString(), this);

            edPr.textBoxVC.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            edPr.pictureBox.Image = Image.FromStream(new MemoryStream((byte[])dataGridView.CurrentRow.Cells[1].Value‌​));
            edPr.textBoxNam.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            edPr.textBoxDesc.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            edPr.textBoxPr.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            edPr.textBoxCount.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();

            edPr.buttAddPr.Visible = false;
            edPr.Show();
            edPr.combBoxCateg.SelectedIndex = -1;
            edPr.combBoxCateg.SelectedText = dataGridView.CurrentRow.Cells[8].Value.ToString();
        }
        #endregion


        private void ButAdd_Click(object sender, EventArgs e)
        {
            Enabled = false;
            var adPr = new AddProd(this);
            adPr.buttEdit.Visible = false;
            adPr.Show();
            adPr.combBoxCateg.SelectedIndex = -1;
        }


        private void ButEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 0 && dataGridView.Rows != null)
            {
                ReadingValues();
                Enabled = false;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }


        private void ButDel_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Do you want delete?", "Open", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    {
                        db.OpenConnection();
                        new SqlCommand($"DELETE FROM Products WHERE prod_id = N'{dataGridView.SelectedRows[0].Cells[0].Value}'", db.GetConnection()).ExecuteNonQuery();
                        db.CloseConnection();
                        UpdateTable();
                        MessageBox.Show("Success");
                        break;
                    }

                default:
                    MessageBox.Show("Not deleted");
                    break;
            }
        }


        private void ButPerson_Click(object sender, EventArgs e)
        {
            ReadVal();
        }

        #region Чтение пользователя
        private void ReadVal()
        {
            db.OpenConnection();
            using (var asquery = new SqlCommand($"Select * FROM Users WHERE user_id = N'{User[0]}'", db.GetConnection()).ExecuteReader())
            {
                var edProf = new SignUp(_SignIn, User[0].ToString());
                while (asquery.Read())
                {
                    edProf.textBoxSurn.Text = asquery.GetString(1);
                    edProf.textBoxName.Text = asquery.GetString(2);
                    edProf.textBoxPatr.Text = asquery.GetString(3);
                    edProf.textBoxEmail.Text = asquery.GetString(4);
                    edProf.textBoxPhone.Text = asquery.GetString(5);
                    edProf.textBoxCity.Text = asquery.GetString(6);
                    edProf.textBoxAddr.Text = asquery.GetString(7);
                    edProf.textBoxUsname.Text = asquery.GetString(8);
                    edProf.textBoxPassw.Text = asquery.GetString(9);
                    break;
                }
                edProf.butnReg.Visible = false;
                edProf.Show();
            }
            db.CloseConnection();
        }
        #endregion



        private void TxtSearch_TextChanged(object sender, EventArgs e) => dataGridView.DataSource = new BindingSource
            {
                DataSource = dataGridView.DataSource,
                Filter = "prod_name like '%" + txtSearch.Text + "%'"
            };


        #region ComboBox
        private void ComboBoxUpd()
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("All");
            foreach (var row in from DataGridViewRow row in dataGridView.Rows
                                where !comboBox.Items.Contains(row.Cells[8].Value.ToString())
                                select row)
            {
                comboBox.Items.Add(row.Cells[8].Value.ToString());
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dtbl = new DataTable();
            
            db.OpenConnection();

            if (comboBox.Text == "All")
            {
                dtbl.Load(new SqlCommand("SELECT prod_id, prod_image, prod_imgUrl, prod_name, prod_descr, prod_price, prod_count, prod_category, Categories.categ_name FROM Products \n" +
                                        "JOIN Categories ON Categories.categ_id = prod_category", db.GetConnection()).ExecuteReader());
                db.CloseConnection();

                dataGridView.DataSource = dtbl;
            }
            else
            {
                dtbl.Load(new SqlCommand($"SELECT prod_id, prod_image, prod_imgUrl, prod_name, prod_descr, prod_price, prod_count, prod_category, Categories.categ_name FROM Products \n" +
                                        "JOIN Categories ON Categories.categ_id = prod_category " +
                                        $"WHERE Categories.categ_name = N'{comboBox.Text}'", db.GetConnection()).ExecuteReader());
                db.CloseConnection();

                dataGridView.DataSource = dtbl;
            }
        }
        #endregion


        private void DataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Rows.Count > 0 && dataGridView.Rows != null)
            {
                Enabled = false;
                new DescripWindow(this, dataGridView.CurrentRow).Show();
            }
        }


        private void ButUsers_Click(object sender, EventArgs e)
        {
            Enabled = false;
            var uswin = new UsersWin(this);
            uswin.Show();
        }


        private void ButHistOrd_Click(object sender, EventArgs e)
        {
            Enabled = false;
            new HistoryOrders(this).Show();
        }


        private void ButCart_Click(object sender, EventArgs e)
        {
            Enabled = false;
            new Cart(this).Show();
        }


        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e) => _SignIn.Show();


        #endregion
    }
}
