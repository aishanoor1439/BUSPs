using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BUSPs.Forms
{
    public partial class UserDashboardForm : Form
    {
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;

        // Event triggered when the form is loaded
        private void UserDashboardForm_Load(object sender, EventArgs e)
        {
            LoadSocieties();
            LoadElections();
        }

        // Method to load societies data into dataGridView1
        private void LoadSocieties()
        {
            string query = "SELECT ID AS 'ID', Name AS 'Name', Description AS 'Description' FROM society";
            string connectionString = "Server=localhost;Database=busps;Uid=root;Pwd=;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection); 
                    DataTable table = new DataTable();
                    adapter.Fill(table); // Fill the DataTable with query results

                    dataGridView1.DataSource = table; // Bind data to dataGridView1
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading societies: " + ex.Message);
            }
        }

        // Method to load elections data into dataGridView2
        private void LoadElections()
        {
            string query = "SELECT ElectionID AS 'ID', ElectionDate AS 'Date', Status AS 'Status' FROM elections";
            string connectionString = "Server=localhost;Database=busps;Uid=root;Pwd=;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Fetch data using SqlDataAdapter
                    DataTable table = new DataTable();
                    adapter.Fill(table); // Fill the DataTable with query results

                    dataGridView2.DataSource = table; // Bind data to dataGridView2
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading elections: " + ex.Message);
            }
        }

        // Event handler for the "View Results" button
        private void button1_Click(object sender, EventArgs e)
        {
            ElectionResultsForm resultsForm = new ElectionResultsForm();
            resultsForm.Show();
            this.Hide();
        }

        // Event handler for the "Logout" button
        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
