using System.Data.SqlClient;

namespace ExamApp
{
    class DB
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Acer\Desktop\repository\ExamApp\Data\Database.mdf;Integrated Security=True");

        /// Пк в 5.112
        /// Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\ExamApp\ExamApp\Data\Database.mdf;Integrated Security=True

        /// Даниил 
        ///SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\sharp\ExamApp\ExamApp\Data\Database.mdf;Integrated Security=True");

        public void OpenConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed) con.Open();
        }

        public void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open) con.Close();
        }

        public SqlConnection GetConnection() => con;
    }
}
