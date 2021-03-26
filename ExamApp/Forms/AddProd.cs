using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ExamApp
{
    public partial class AddProd : Form
    {
        private string i;
        private string imageUrl = null;


        public AddProd(string id)
        {
            i = id;
            InitializeComponent();
        }

        private void ButtonPict_Click(object sender, EventArgs e)
        {
            var db = new DB();
            db.GetConnection();
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageUrl = ofd.FileName;
                    try
                    {
                        pictureBox.Image = Image.FromFile(ofd.FileName);
                    }
                    catch 
                    { 
                        MessageBox.Show("Not enough memory");
                    }
                }
            }
        }

        private void ButtAddPr_Click(object sender, EventArgs e)
        {
            var converter = new ImageConverter();
            var arr = (byte[])converter.ConvertTo(pictureBox.Image, typeof(byte[]));
            
            if (string.IsNullOrEmpty(textBoxVC.Text) || string.IsNullOrEmpty(arr.ToString()) || string.IsNullOrEmpty(imageUrl) || string.IsNullOrEmpty(textBoxNam.Text) || string.IsNullOrEmpty(textBoxDesc.Text) || string.IsNullOrEmpty(textBoxPr.Text) || string.IsNullOrEmpty(textBoxCat.Text))
            {
                MessageBox.Show("Fill in the blank fields");
                return;
            }

            try
            {
                var db = new DB();
                db.GetConnection().Open();

                EditData(arr, db);
                MessageBox.Show("Product saved");

                MainWindow mw = UpdDGW(db);
                Close();
                mw.Show();
            }
            catch
            {
                MessageBox.Show("Invalid data format");
            }
        }

        private void EditData(byte[] arr, DB db)
        {
            var cmd = new SqlCommand("INSERT INTO Products (prod_vendcode, prod_image, prod_imgUrl, prod_name, prod_descr, prod_price, prod_category) VALUES (@Vend, @Photo, @PhotoUrl, @Product, @Descr, @Price, @Categ)", db.GetConnection());
            cmd.Parameters.AddWithValue("@Vend", textBoxVC.Text);
            cmd.Parameters.AddWithValue("@Photo", arr);
            cmd.Parameters.AddWithValue("@PhotoUrl", imageUrl);
            cmd.Parameters.AddWithValue("@Product", textBoxNam.Text);
            cmd.Parameters.AddWithValue("@Descr", textBoxDesc.Text);
            cmd.Parameters.AddWithValue("@Price", textBoxPr.Text);
            cmd.Parameters.AddWithValue("@Categ", textBoxCat.Text);
            cmd.ExecuteNonQuery();
        }

        private void ButtBack_Click(object sender, EventArgs e)
        {
            Close();
            var mw = new MainWindow();
            mw.Show();
        }

        private void ButtEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new DB();
                var command = new SqlCommand(@"UPDATE Products SET prod_vendcode = '" + textBoxVC.Text + "', prod_image = @Photo, prod_name ='" + textBoxNam.Text + "', prod_descr ='" + textBoxDesc.Text + "', prod_price ='" + textBoxPr.Text + "', prod_category ='" + textBoxCat.Text + "' WHERE prod_id = '" + i + "'", db.GetConnection());
                db.GetConnection().Open();
                command.Parameters.AddWithValue("@Photo", (byte[])new ImageConverter().ConvertTo(pictureBox.Image, typeof(byte[])));
                switch (command.ExecuteNonQuery())
                {
                    case 1:
                        MessageBox.Show("Data Updated");
                        break;
                    default:
                        MessageBox.Show("Data not updated");
                        break;
                }
                Close();

                MainWindow mw = UpdDGW(db);
                mw.Show();
            }
            catch
            {
                MessageBox.Show("Fuck");
            }
        }

        private static MainWindow UpdDGW(DB db)
        {
            var mw = new MainWindow();
            var dtbl = new DataTable();
            dtbl.Load(new SqlCommand("SELECT * FROM Products", db.GetConnection()).ExecuteReader());
            db.GetConnection().Close();
            mw.dataGridView.DataSource = dtbl;
            return mw;
        }
    }
}
