using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace BUSPs.Databases
{
    internal class DatabaseHelper
    {
        // MySQL connection string
        private readonly string connectionString = "Server=localhost;Database=busps;Uid=root;Pwd=;";

        // Method to establish a MySQL connection
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
