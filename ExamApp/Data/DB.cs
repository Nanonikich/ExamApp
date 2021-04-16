using System.Data.SqlClient;

namespace ExamApp
{
    class DB
    {
        readonly SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Acer\Desktop\rep\ExamApp\Data\Database.mdf;Integrated Security=True");

        /// Мой 
        ///SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\sharp\ExamApp\ExamApp\Data\Database.mdf;Integrated Security=True");

        public void OpenConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed) con.Open();
        }

        public void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open) con.Close();
        }

        public SqlConnection GetConnection()
        {
            return con;
        }
    }
}
