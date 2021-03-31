using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ExamApp
{
    public partial class AddProd : Form
    {

        /// <summary>
        /// Переменная с главным меню
        /// </summary>
        MainWindow MainWin;


        private string i;
        private string imageUrl = null;


        /// <summary>
        /// Конструктор для Редактирования товара
        /// </summary>
        public AddProd(string id, MainWindow mw)
        {
            i = id;
            MainWin = mw;
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор для добавляения товара
        /// </summary>
        public AddProd(MainWindow mw)
        {
            MainWin = mw; // Тут я передаю контроль над главным меню окну добавления
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


                MainWin.Enabled = true;
                MainWin.UpdateTable();
                Close();
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

            /// открываю доступ главного окна
            MainWin.Enabled = true;
            Close();
        }

        private void ButtEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new DB();
                var command = new SqlCommand($@"UPDATE Products SET prod_vendcode = N'{textBoxVC.Text}', prod_image = @Photo, prod_name = N'{textBoxNam.Text}', prod_descr =  N'{textBoxDesc.Text}', prod_price = '{textBoxPr.Text}', prod_category = N'{textBoxCat.Text}' WHERE prod_id = '" + i + "'", db.GetConnection());
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


                UpdDGW(db);
                Close();
            }
            catch
            {
                MessageBox.Show("Fuck");
            }
        }


        /// <summary>
        /// Обновление данных в таблице Главного меню
        /// </summary>
        /// <param name="db"></param>
        private void UpdDGW(DB db)
        {
            var dtbl = new DataTable();
            dtbl.Load(new SqlCommand("SELECT * FROM Products", db.GetConnection()).ExecuteReader());
            db.GetConnection().Close();
            MainWin.dataGridView.DataSource = dtbl;
        }


        /// <summary>
        /// При закрытии Окна активировать главное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProd_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;

    }
}
