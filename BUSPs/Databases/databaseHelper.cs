//Adding namespace to connect with sql server
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSPs.Databases
{
    internal class DatabaseHelper
    {
        // The connection string is private to ensure that only the DatabaseHelper class can access it.
        // It's marked as 'readonly' to prevent any changes after it is initialized, 
        private readonly string connectionString = "Server=localhost;Database=busps;User Id=root;Password=;";
        //The default username for MySQL in XAMPP is root.

        // Method to establish a SQL connection
        //SqlConnection is a class from the System.Data.SqlClient namespace.
        //It represents an open connection to a SQL Server database.
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
