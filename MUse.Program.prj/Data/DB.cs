using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamApp
{
    internal class DB
    {
        private readonly SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\Data\Database.mdf;Integrated Security = True");

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