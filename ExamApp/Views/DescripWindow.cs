using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ExamApp.Forms
{
    public partial class DescripWindow : Form
    {
        #region Поля
        readonly MainWindow MainWin;
        readonly DataGridViewRow _DataThing;
        readonly DB db = new DB();
        public byte[] img;
        #endregion

        #region Конструктор
        public DescripWindow(MainWindow mw, DataGridViewRow dr)
        {
            MainWin = mw;
            _DataThing = dr;
            this.img = (byte[])dr.Cells[1].Value;

            InitializeComponent();
            ShowDataThing();
        }
        #endregion

        #region Методы

        #region Отображение описания товара
            private void ShowDataThing()
            {
                if (MainWin.User[10].ToString() == "True")
                {
                    butShop.Enabled = false;
                }

                labelArt.Text = _DataThing.Cells[0].Value.ToString();
                pictBoxDescr.Image = Image.FromStream(new MemoryStream((byte[])_DataThing.Cells[1].Value‌​));
                labelName.Text = _DataThing.Cells[3].Value.ToString();
                labDescr.Text = _DataThing.Cells[4].Value.ToString();
                labelPrice.Text = _DataThing.Cells[5].Value.ToString();
            }
            #endregion


        private void ButShop_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(_DataThing.Cells[6].Value) < 1)
            {
                MessageBox.Show("Not available");
            }
            else
            {
                db.OpenConnection();
                new SqlCommand($"INSERT INTO Cart VALUES('{_DataThing.Cells[0].Value}', '{_DataThing.Cells[3].Value}', {1}, {_DataThing.Cells[5].Value}, {MainWin.User[0]})",
                    db.GetConnection())
                    .ExecuteNonQuery();
                db.CloseConnection();

                MainWin.UpdateTable();
                MainWin.Enabled = true;
                Close();
            }
        }

        private void ButBack_Click(object sender, EventArgs e)
        {
            MainWin.Enabled = true;
            Close();
        }

        private void DescripWindow_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;

        #endregion
    }
}
