using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace ExamApp
{
    public partial class AddProd : Form
    {
        #region Поля
        readonly MainWindow MainWin;
        readonly DB db = new DB();
        private readonly string i;
        private string imageUrl = null;
        #endregion

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
        #endregion

        #region Методы

            #region Кнопка взятия изображения
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
                            MessageBox.Show("Not enough memory");
                        }
                    }
                }
            }
            #endregion

            #region Кнопка добавления
            private void ButtAddPr_Click(object sender, EventArgs e)
            {
                var arr = (byte[])new ImageConverter().ConvertTo(pictureBox.Image, typeof(byte[]));

                #region Проверка на содержание
                foreach (var _ in (new string[] { ".", ",", "/", "*", "(", ")", "%", "!", "?", ">", "<", "'", ":", ";", "{", "}", "[", "]", "-", "_", "+", "=", "&", "^", "$", "|", "@", "~", "`", "№", ";", " " }).Where(v =>
                                       textBoxVC.Text.Contains(v) || textBoxPr.Text.Contains(v) || textBoxCount.Text.Contains(v) || textBoxCat.Text.Contains(v) ||
                                       string.IsNullOrEmpty(textBoxVC.Text) || string.IsNullOrEmpty(arr.ToString()) || string.IsNullOrEmpty(imageUrl) || string.IsNullOrEmpty(textBoxNam.Text) || string.IsNullOrEmpty(textBoxDesc.Text) || string.IsNullOrEmpty(textBoxPr.Text) || string.IsNullOrEmpty(textBoxCount.Text) || string.IsNullOrEmpty(textBoxCat.Text)).Select(v => new { }))
                {
                    MessageBox.Show("Fill in the blank fields");
                    return;
                }
                #endregion

                try
                {
                    db.OpenConnection();
                    EditData(arr, db);
                    db.CloseConnection();

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
            #endregion

            #region Вставка и редактирование данных
            private void EditData(byte[] arr, DB db)
            {
                var cmd = new SqlCommand("INSERT INTO Products (prod_id, prod_image, prod_imgUrl, prod_name, prod_descr, prod_price, prod_count, prod_category) VALUES (@Vend, @Photo, @PhotoUrl, @Product, @Descr, @Price, @Count, @Categ)", db.GetConnection());
                cmd.Parameters.AddWithValue("@Vend", textBoxVC.Text);
                cmd.Parameters.AddWithValue("@Photo", arr);
                cmd.Parameters.AddWithValue("@PhotoUrl", imageUrl);
                cmd.Parameters.AddWithValue("@Product", textBoxNam.Text);
                cmd.Parameters.AddWithValue("@Descr", textBoxDesc.Text);
                cmd.Parameters.AddWithValue("@Price", textBoxPr.Text);
                cmd.Parameters.AddWithValue("@Count", textBoxCount.Text);
                cmd.Parameters.AddWithValue("@Categ", textBoxCat.Text);
                cmd.ExecuteNonQuery();
            }
            #endregion

            #region Кнопка закрытия формы
            private void ButtBack_Click(object sender, EventArgs e)
            {
                MainWin.Enabled = true;
                Close();
            }
            #endregion

            #region Кнопка редактирования
            private void ButtEdit_Click(object sender, EventArgs e)
            {
                var command = new SqlCommand($@"UPDATE Products SET prod_id = N'{textBoxVC.Text}', prod_image = @Photo, prod_name = N'{textBoxNam.Text}', prod_descr =  N'{textBoxDesc.Text}', prod_price = '{textBoxPr.Text}', prod_count = '{textBoxCount.Text}', prod_category = N'{textBoxCat.Text}' WHERE prod_id = '" + i + "'", db.GetConnection());
            
                #region Проверка на содержание
                foreach (var _ in (new string[] { ".", ",", "/", "*", "(", ")", "%", "!", "?", ">", "<", "'", ":", ";", "{", "}", "[", "]", "-", "_", "+", "=", "&", "^", "$", "|", "@", "~", "`", "№", ";", " " }).Where(v =>
                                       textBoxVC.Text.Contains(v) || textBoxPr.Text.Contains(v) || textBoxCount.Text.Contains(v) || textBoxCat.Text.Contains(v) ||
                                       string.IsNullOrEmpty(textBoxVC.Text) || string.IsNullOrEmpty(textBoxNam.Text) || string.IsNullOrEmpty(textBoxDesc.Text) || string.IsNullOrEmpty(textBoxPr.Text) || string.IsNullOrEmpty(textBoxCount.Text) || string.IsNullOrEmpty(textBoxCat.Text)).Select(v => new { }))
                {
                    MessageBox.Show("Fill in the blank fields");
                    return;
                }
                #endregion

                db.OpenConnection();
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
                db.CloseConnection();

                UpdDGW(db);
                Close();

            }
            #endregion

            #region Обновление таблицы
            private void UpdDGW(DB db)
            {
                var dtbl = new DataTable();
                db.OpenConnection();
                dtbl.Load(new SqlCommand("SELECT * FROM Products", db.GetConnection()).ExecuteReader());
                db.CloseConnection();
                MainWin.dataGridView.DataSource = dtbl;
            }
            #endregion

            #region Закрытие формы
            private void AddProd_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;
            #endregion

        #endregion
    }
}
