using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace BUSPs.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Retrieving connection string from App.config
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;

            // Using the connection string to establish a connection
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT Role FROM user WHERE Name = '{username}' AND Password = '{password}'";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Executing the query and fetch the result
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString();

                            if (role == "Admin")
                            {
                                MessageBox.Show("Welcome Admin!");
                                AdminDashboard adminDashboard = new AdminDashboard();
                                adminDashboard.Show();
                                this.Hide();
                            }
                            else if (role == "Student")
                            {
                                MessageBox.Show("Welcome Student!");
                                UserDashboardForm userDashboard = new UserDashboardForm();
                                userDashboard.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
