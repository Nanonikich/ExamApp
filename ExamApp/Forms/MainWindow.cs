using ExamApp.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ExamApp
{
    public partial class MainWindow : Form
    {

        SignIn _SignIn;
        DataRow _User;
        public MainWindow(SignIn sn, DataRow us)
        {
            _SignIn = sn;
            _User = us;
            InitializeComponent();
        }

        public DataRow User { get => _User; }


        public int GetCountFromCartByName(string name)
        {
            var cart = new Cart(_SignIn, this);
            try
            {
                var db = new DB();
                db.OpenConnection();
                var reader = new SqlCommand("SELECT SUM(cart_count_prod) FROM Cart\n" +
                                            $"Where cart_name = N'{name}'", db.GetConnection()).ExecuteReader();
                int sum = 0;
                while (reader.Read())
                    sum = reader.GetInt32(0);
                return sum;
            }
            catch {return 0;}
                

        }

        public void UpdateTable()
        {
            var db = new DB();
            var dtbl = new DataTable();
            db.OpenConnection();
            dtbl.Load(new SqlCommand("SELECT * FROM Products", db.GetConnection()).ExecuteReader());
            db.GetConnection().Close();


            #region Работа с Таблицей продуктов

            for (int row = 0; row < dtbl.Rows.Count; row++)
            {
                var currentRow = dtbl.Rows[row];
                var nameProduct = (string)currentRow[3];
                currentRow[6] = (int)currentRow[6] - GetCountFromCartByName(nameProduct);

            }
            

            #endregion


            dataGridView.DataSource = dtbl;

            #region Разделение на пользователей
            if (User[10].ToString() == "False")
            {
                ButAdd.Visible = false;
                ButEdit.Visible = false;
                ButDel.Visible = false;
                ButHistOrd.Visible = false;
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
            ComboBoxUpd();
        }

        private void ComboBoxUpd()
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("All");
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!comboBox.Items.Contains(row.Cells[7].Value.ToString()))
                {
                    comboBox.Items.Add(row.Cells[7].Value.ToString());
                }
            }
        }

        private void ReadingValues()
        {
            var edPr = new AddProd(dataGridView.CurrentRow.Cells[0].Value.ToString(), this);

            var i = (byte[])dataGridView.CurrentRow.Cells[1].Value‌​;

            edPr.textBoxVC.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            edPr.pictureBox.Image = Image.FromStream(new MemoryStream((byte[])dataGridView.CurrentRow.Cells[1].Value‌​));
            edPr.textBoxNam.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            edPr.textBoxDesc.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            edPr.textBoxPr.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            edPr.textBoxCount.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
            edPr.textBoxCat.Text = dataGridView.CurrentRow.Cells[7].Value.ToString();

            edPr.buttAddPr.Visible = false;
            edPr.Show();
        }



        private void ButEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 0 && dataGridView.Rows != null)
            {
                ReadingValues();
                this.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void ButAdd_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            var adPr = new AddProd(this);
            adPr.buttEdit.Visible = false;
            adPr.Show();
        }

        private void ButDel_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Do you want delete?", "Open", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    {
                        var db = new DB();
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

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _SignIn.Show();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            var bs = new BindingSource
            {
                DataSource = dataGridView.DataSource,
                Filter = "prod_name like '%" + txtSearch.Text + "%'"
            };
            dataGridView.DataSource = bs;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var db = new DB();
            var dtbl = new DataTable();
            
            db.OpenConnection();


            if (comboBox.Text == "All")
            {
                dtbl.Load(new SqlCommand("SELECT * FROM Products ", db.GetConnection()).ExecuteReader());
                db.CloseConnection();

                dataGridView.DataSource = dtbl;
            }
            else
            {
                dtbl.Load(new SqlCommand($"SELECT * FROM Products WHERE prod_category = N'{comboBox.Text}'", db.GetConnection()).ExecuteReader());
                db.CloseConnection();

                dataGridView.DataSource = dtbl;
            }
        }

        private void DataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Rows.Count > 0 && dataGridView.Rows != null)
            {
                this.Enabled = false;
                var data = dataGridView.CurrentRow;
                var dw = new DescripWindow(this, data);
                dw.Show();
            }
        }


        #region Кол-во товара



        

        #endregion

        private void ButCart_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var cw = new Cart(_SignIn, this);
            cw.Show();
        }

        private void ButHistOrd_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            var histOrd = new HistoryOrders(this);
            histOrd.Show();
        }
    }
}
