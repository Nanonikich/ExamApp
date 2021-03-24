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
    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }

        public MyUserControl(SqlConnection sqlConnection)
        {
            SqlConnection = sqlConnection;
        }

        public string Name
        {
            get => ProdN.Text;
            set => ProdN.Text = value;
        }
        public string Artikul
        {
            get => ProdArt.Text;
            set => ProdArt.Text = value;
        }
        public string Nalichie
        {
            get => ProdNalich.Text;
            set => ProdNalich.Text = value;
        }
        public string Price
        {
            get => ProdPri.Text;
            set => ProdPri.Text = value;
        }
        public SqlConnection SqlConnection { get; }
    }
}
