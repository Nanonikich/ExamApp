using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ExamApp.Forms
{
    public partial class DescripWindow : Form
    {
        MainWindow MainWin;
        DataGridViewRow _DataThing;
        public byte[] img;


        public DescripWindow(MainWindow mw, DataGridViewRow dr)
        {
            MainWin = mw;
            _DataThing = dr;
            this.img = (byte[])dr.Cells[2].Value;

            InitializeComponent();
            ShowDataThing();
        }

        private void ButBack_Click(object sender, EventArgs e)
        {
            MainWin.Enabled = true;
            Close();
        }

        private void ShowDataThing()
        {
            labelArt.Text = _DataThing.Cells[1].Value.ToString();
            pictBoxDescr.Image = Image.FromStream(new MemoryStream((byte[])_DataThing.Cells[2].Value‌​));
            labelName.Text = _DataThing.Cells[4].Value.ToString();
            labDescr.Text = _DataThing.Cells[5].Value.ToString();
            labelPrice.Text = _DataThing.Cells[6].Value.ToString();
        }

        private void DescripWindow_FormClosed(object sender, FormClosedEventArgs e) => MainWin.Enabled = true;


        private void ButShop_Click(object sender, EventArgs e)
        {

            var db = new DB();

            var cmd = new SqlCommand($"INSERT INTO Basket VALUES('{_DataThing.Cells[4].Value}', {1}, {_DataThing.Cells[6].Value}, {MainWin.User[0]})", db.GetConnection());
            db.OpenConnection();
            cmd.ExecuteNonQuery();
            db.CloseConnection();

            MainWin.Enabled = true;
            Close();
        }
    }
}
