using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ExamApp
{
    public partial class AddProd : Form
    {
        
        string imageUrl = null;

        public AddProd()
        {
            InitializeComponent();
        }

        private void ButtonPict_Click(object sender, EventArgs e)
        {
            var db = new DB();
            db.getConnection();
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
            var img = pictureBox.Image;
            ImageConverter converter = new ImageConverter();
            var arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            var db = new DB();
            if (string.IsNullOrEmpty(textBoxVC.Text) || string.IsNullOrEmpty(arr.ToString()) || string.IsNullOrEmpty(imageUrl) || string.IsNullOrEmpty(textBoxNam.Text) || string.IsNullOrEmpty(textBoxDesc.Text) || string.IsNullOrEmpty(textBoxPr.Text) || string.IsNullOrEmpty(textBoxCat.Text) || string.IsNullOrEmpty(textBoxType.Text))
            {
                MessageBox.Show("Fill in the blank fields");
                return;
            }
            var cmd = new SqlCommand("INSERT INTO Products (prod_vendcode, prod_image, prod_imgUrl, prod_name, prod_descr, prod_price, prod_category, prod_type ) VALUES (@Vend, @Photo, @PhotoUrl, @Product, @Descr, @Price, @Categ, @Type)", db.getConnection());
            
            try
            {
                db.getConnection().Open();
                cmd.Parameters.AddWithValue("@Vend", textBoxVC.Text);
                cmd.Parameters.AddWithValue("@Photo", arr);
                cmd.Parameters.AddWithValue("@PhotoUrl", imageUrl);
                cmd.Parameters.AddWithValue("@Product", textBoxNam.Text);
                cmd.Parameters.AddWithValue("@Descr", textBoxDesc.Text);
                cmd.Parameters.AddWithValue("@Price", textBoxPr.Text);
                cmd.Parameters.AddWithValue("@Categ", textBoxCat.Text);
                cmd.Parameters.AddWithValue("@Type", textBoxType.Text);
                cmd.ExecuteNonQuery();
                db.getConnection().Close();
                MessageBox.Show("Product saved");
                Close();
                var mw = new MainWindow();
                mw.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Invalid data format");
            }
        }

        private void ButtBack_Click(object sender, EventArgs e)
        {
            Close();
            var mnWin = new MainWindow();
            mnWin.Show();
        }
    }
}
