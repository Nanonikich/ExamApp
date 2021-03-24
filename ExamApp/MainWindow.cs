using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamApp
{
    public partial class MainWindow : Form
    {
        List<MyUserControl> products;
        public MainWindow()
        {
            InitializeComponent();
            LoadProduct();
        }

        private void LoadProduct()
        {
            var db = new DB();
            
            var dtbl = new DataTable();
            SqlCommand cmd3 = new SqlCommand(@"SELECT prod_name,  prod_vendcode, prod_type,  prod_price FROM Product ", db.getConnection());
            int count = 0; //
            int z = 0; //
            SqlCommand query = new SqlCommand(@"SELECT COUNT(*) FROM Product", db.getConnection()); //
            db.getConnection().Open();
            count = (int)query.ExecuteScalar(); //

            List<MyUserControl> products = new List<MyUserControl>()
            {
                new MyUserControl()
                {
                    Name = cmd3.ExecuteScalar().ToString(),
                    Artikul = cmd3.ExecuteScalar().ToString(),
                    Nalichie = cmd3.ExecuteScalar().ToString(),
                    Price = cmd3.ExecuteScalar().ToString(),
                }
            };
            foreach (MyUserControl item in products)
            {
                flowLayout.Controls.Add(item);
            }
        }
    }
}
