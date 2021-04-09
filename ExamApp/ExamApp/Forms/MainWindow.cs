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

        public void UpdateTable()
        {
            var db = new DB();
            var dtbl = new DataTable();
            db.OpenConnection();
            dtbl.Load(new SqlCommand("SELECT * FROM Products", db.GetConnection()).ExecuteReader());
            db.CloseConnection();

            dataGridView.DataSource = dtbl;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void ReadingValues()
        {
            var edPr = new AddProd(dataGridView.CurrentRow.Cells[0].Value.ToString(), this);

            var i = (byte[])dataGridView.CurrentRow.Cells[2].Value‌​;

            edPr.textBoxVC.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            edPr.pictureBox.Image = Image.FromStream(new MemoryStream((byte[])dataGridView.CurrentRow.Cells[2].Value‌​));
            edPr.textBoxNam.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            edPr.textBoxDesc.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            edPr.textBoxPr.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
            edPr.textBoxCat.Text = dataGridView.CurrentRow.Cells[7].Value.ToString();

            edPr.buttAddPr.Enabled = false;
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
            adPr.buttEdit.Enabled = false;
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

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e) => _SignIn.Show();

        private void TxtSearch_TextChanged(object sender, EventArgs e) => dataGridView.DataSource = new BindingSource
        {
            DataSource = dataGridView.DataSource,
            Filter = "prod_name like '%" + txtSearch.Text + "%'"
        };

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
                new DescripWindow(this, dataGridView.CurrentRow).Show();
            }
        }

        private void ToolStripButBasket_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            new Basket(this).Show();
        }
    }
}
