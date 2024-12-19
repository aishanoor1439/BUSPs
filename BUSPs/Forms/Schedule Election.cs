using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUSPs.Databases;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BUSPs.Forms
{
    public partial class ElectionSchedulingForm : Form
    {
        DatabaseHelper dbHelper = new DatabaseHelper();

        public ElectionSchedulingForm()
        {
            InitializeComponent();
            LoadScheduledElections();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string electionName = textBox1.Text; 
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            if (string.IsNullOrEmpty(electionName))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (endDate <= startDate)
            {
                MessageBox.Show("End date must be later than start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Saving to database
            try
            {
                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO elections (election_name, start_date, end_date) VALUES (@name, @startDate, @endDate)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", electionName);
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                        cmd.Parameters.AddWithValue("@endDate", endDate);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Election scheduled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Clearing fields and reloading data
                textBox1.Clear();
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                LoadScheduledElections();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadScheduledElections()
        {
            try
            {
                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT election_name AS 'Election Name', description AS 'Description', start_date AS 'Start Date', end_date AS 'End Date' FROM elections";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind data to DataGridView
                        //dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading elections: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
