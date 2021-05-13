using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using ExamApp.Forms;

namespace ExamApp
{
    public partial class AddProd : Form
    {
        #region Поля

        private readonly MainWindow MainWin;
        private readonly DB db = new DB();
        private readonly string i;
        private string imageUrl = null;
        private readonly DataTable dtbl = new DataTable();

        #endregion Поля

        #region Конструкторы

        public AddProd(string id, MainWindow mw)
        {
            i = id;
            MainWin = mw;
            InitializeComponent();
        }

        public AddProd(MainWindow mw)
        {
            MainWin = mw;
            InitializeComponent();
        }

        #endregion Конструкторы

        #region Методы

        private void AddProd_Load(object sender, EventArgs e)
        {
            ComboBx();
        }

        #region Добавление изображения

        private void ButtonPict_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageUrl = ofd.FileName;
                    // проверка на вес изображения
                    try
                    {
                        pictureBox.Image = Image.FromFile(ofd.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Слишком большой размер изображения!");
                    }
                }
            }
        }

        #endregion Добавление изображения

        #region Добавление категории

        private void ComboBx()
        {
            db.OpenConnection();
            dtbl.Load(new SqlCommand("SELECT categ_id, categ_name FROM Categories", db.GetConnection()).ExecuteReader());
            combBoxCateg.DataSource = dtbl;
            combBoxCateg.ValueMember = "categ_id";
            combBoxCateg.DisplayMember = "categ_name";
            db.CloseConnection();
        }

        private void ButCategAdd_Click(object sender, EventArgs e)
        {
            Enabled = false;
            var cat = new Categories(this, MainWin);
            cat.Show();
        }

        #endregion Добавление категории

        private void ButtAddPr_Click(object sender, EventArgs e)
        {
            #region Проверка на пустоту

            if (string.IsNullOrEmpty(textBoxVC.Text) || string.IsNullOrEmpty(textBoxNam.Text) || string.IsNullOrEmpty(textBoxDesc.Text) || string.IsNullOrEmpty(textBoxPr.Text) || string.IsNullOrEmpty(textBoxCount.Text) || string.IsNullOrEmpty(combBoxCateg.Text))
            {
                MessageBox.Show("Заполните пустые поля");
                return;
            }

            #endregion Проверка на пустоту

            try
            {
                db.OpenConnection();
                EditData((byte[])new ImageConverter().ConvertTo(pictureBox.Image, typeof(byte[])), db);
                db.CloseConnection();

                MessageBox.Show("Товар добавлен");

                MainWin.Enabled = true;
                MainWin.UpdateTable();
                Close();
            }
            catch
            {
                MessageBox.Show("Неверный формат данных");
            }
        }

        /// <summary>
        /// Добавление данных в таблицу
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="db"></param>
        private void EditData(byte[] arr, DB db)
        {
            using (var cmd = new SqlCommand("INSERT INTO Products (prod_id, prod_image, prod_imgUrl, prod_name, prod_descr, prod_price, prod_count, prod_category) VALUES (@Vend, @Photo, @PhotoUrl, @Product, @Descr, @Price, @Count, @Categ)", db.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Vend", textBoxVC.Text);
                cmd.Parameters.AddWithValue("@Photo", arr);
                cmd.Parameters.AddWithValue("@PhotoUrl", imageUrl);
                cmd.Parameters.AddWithValue("@Product", textBoxNam.Text);
                cmd.Parameters.AddWithValue("@Descr", textBoxDesc.Text);
                cmd.Parameters.AddWithValue("@Price", textBoxPr.Text);
                cmd.Parameters.AddWithValue("@Count", textBoxCount.Text);
                cmd.Parameters.AddWithValue("@Categ", ((int)combBoxCateg.SelectedValue).ToString());
                cmd.ExecuteNonQuery();
            }
        }

        private void ButtBack_Click(object sender, EventArgs e)
        {
            MainWin.Enabled = true;
            Close();
        }

        private void ButtEdit_Click(object sender, EventArgs e)
        {
            #region Проверка на пустоту

            if (string.IsNullOrEmpty(textBoxVC.Text) || string.IsNullOrEmpty(textBoxNam.Text) || string.IsNullOrEmpty(textBoxDesc.Text) || string.IsNullOrEmpty(textBoxPr.Text) || string.IsNullOrEmpty(textBoxCount.Text) || string.IsNullOrEmpty(combBoxCateg.Text))
            {
                MessageBox.Show("Заполните пустые поля");
                return;
            }

            #endregion Проверка на пустоту

            using (var command = new SqlCommand($@"UPDATE Products SET prod_id = N'{textBoxVC.Text}', prod_image = @Photo, prod_name = N'{textBoxNam.Text}', prod_descr =  N'{textBoxDesc.Text}', prod_price = '{textBoxPr.Text}', prod_count = '{textBoxCount.Text}', prod_category = N'{(int)combBoxCateg.SelectedValue}' WHERE prod_id = '" + i + "'", db.GetConnection()))
            {
                db.OpenConnection();
                command.Parameters.AddWithValue("@Photo", (byte[])new ImageConverter().ConvertTo(pictureBox.Image, typeof(byte[])));
                switch (command.ExecuteNonQuery())
                {
                    case 1:
                        MessageBox.Show("Информация о товаре обновлена");
                        break;

                    default:
                        MessageBox.Show("Информация о товаре не обновлена");
                        break;
                }
            }
            db.CloseConnection();

            UpdDGW(db);
            Close();
        }

        private void UpdDGW(DB db)
        {
            dtbl.Clear();
            db.OpenConnection();
            dtbl.Load(new SqlCommand("SELECT prod_id, prod_image, prod_imgUrl, prod_name, prod_descr, prod_price, prod_count, prod_category, Categories.categ_name FROM Products \n" +
                "JOIN Categories ON Categories.categ_id = prod_category", db.GetConnection()).ExecuteReader());
            db.CloseConnection();
            MainWin.dataGridView.DataSource = dtbl;
            MainWin.ComboBoxUpd();
        }

        #region Настройка textboxes

        // проверка на цифры атрибута, цены и количества
        private void TextBoxVC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        // Проверка на Enter всех textboxes
        private void TextBoxVC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        #endregion Настройка textboxes

        private void AddProd_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;

        #endregion Методы
    }
}