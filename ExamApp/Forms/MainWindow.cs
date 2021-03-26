using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ExamApp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButAdd_Click(object sender, EventArgs e)
        {
            Hide();
            var adPr = new AddProd("0");
            adPr.buttEdit.Enabled = false;
            adPr.Show();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.databaseDataSet.Products);
        }

        private void ButEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 0 && dataGridView.Rows != null)
            {
                ReadingValues();
                Hide();
            }
            else 
            { 
                MessageBox.Show("Error"); 
            }
        }

        private void ReadingValues()
        {
            var edPr = new AddProd(dataGridView.CurrentRow.Cells[0].Value.ToString());
            edPr.textBoxVC.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            edPr.pictureBox.Image = Image.FromStream(new MemoryStream((byte[])dataGridView.CurrentRow.Cells[2].Value‌​));
            edPr.textBoxNam.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            edPr.textBoxDesc.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            edPr.textBoxPr.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
            edPr.textBoxCat.Text = dataGridView.CurrentRow.Cells[7].Value.ToString();

            edPr.buttAddPr.Enabled = false;
            edPr.Show();
        }

        private void ButDel_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Do you want delete?", "Open", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    {
                        var db = new DB();
                        var v = new SqlCommand(@"DELETE FROM Products WHERE prod_id = '" + dataGridView.SelectedRows[0].Cells[0].Value.ToString() + "'", db.GetConnection());
                        db.OpenConnection();
                        v.ExecuteNonQuery();
                        db.CloseConnection();
                        dataGridView.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
                        MessageBox.Show("Success");
                        break;
                    }

                default:
                    MessageBox.Show("Not deleted");
                    break;
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var binding1 = new BindingSource();
            binding1.DataSource = databaseDataSet.Products;
            dataGridView.DataSource = binding1;
            if (comboBox.Text == "All")
            {
                var db = new DB();
                var dtbl = new DataTable();
                db.OpenConnection();
                dtbl.Load(new SqlCommand("SELECT * FROM Products", db.GetConnection()).ExecuteReader());
                db.GetConnection().Close();
                
                dataGridView.DataSource = dtbl;
            }
            else
            {
                binding1.Filter = "prod_category = '" + comboBox.Text + "'";
            }
        }
    }
}
