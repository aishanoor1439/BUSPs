using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUSPs.Databases; // Update namespace if your DatabaseHelper is in another folder.

namespace BUSPs.Forms
{
    public partial class ElectionResultsForm : Form
    {
        // Create an instance of DatabaseHelper to handle SQL connection
        DatabaseHelper dbHelper = new DatabaseHelper();

        public ElectionResultsForm()
        {
            InitializeComponent();
        }

        // Event handler for Form Load to populate election results when the form opens
        private void ElectionResultsForm_Load(object sender, EventArgs e)
        {
            LoadElectionResults();
        }

        // Event handler for the Refresh button click
        private void button1_Click(object sender, EventArgs e)
        {
            LoadElectionResults();
        }

        // Method to fetch and load election results into the DataGridView
        private void LoadElectionResults()
        {
            try
            {
                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();

                    // SQL query to fetch election results
                    string query = @"
                        SELECT 
                            CandidateName AS 'Candidate Name', 
                            Votes AS 'Votes Received', 
                            Position AS 'Position'
                        FROM election_results";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            // Create a DataTable to hold the results
                            DataTable resultsTable = new DataTable();
                            adapter.Fill(resultsTable);

                            // Bind the results to the DataGridView
                            dataGridView1.DataSource = resultsTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Show an error message if something goes wrong
                MessageBox.Show($"An error occurred while loading results: {ex.Message}");
            }
        }
    }
}