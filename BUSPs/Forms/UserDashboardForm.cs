using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UserDashboardApp
{
    public partial class UserDashboardForm : Form
    {
        public UserDashboardForm()
        {
            InitializeComponent();
        }

        // Form Load Event
        private void UserDashboardForm_Load(object sender, EventArgs e)
        {
            LoadSocieties();
            LoadElections();
        }

        // Load societies data into dataGridView1
        private void LoadSocieties()
        {
            string query = "SELECT ID AS 'ID', Name AS 'Name', Description AS 'Description' FROM society";
            string connectionString = "your_connection_string_here";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading societies: " + ex.Message);
                }
            }
        }

        // Load elections data into dataGridView2
        private void LoadElections()
        {
            string query = "SELECT ElectionID AS 'ID', ElectionDate AS 'Date', Status AS 'Status' FROM elections";
            string connectionString = "your_connection_string_here";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView2.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading elections: " + ex.Message);
                }
            }
        }

        // View Results Button Click Event
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("View Results button clicked!");
            // Add code to navigate to the results page or display results.
        }

        // Logout Button Click Event
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout button clicked!");
            // Add code to navigate to the login page or close the form.
        }
    }
}