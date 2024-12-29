using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUSPs.Databases;
using UserDashboardApp;

namespace BUSPs.Forms
{
    public partial class VotingForm : Form
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        private string userId; // Logged-in User's ID
        private string electionId; // Selected Election's ID

        public VotingForm(string loggedInUserId, string selectedElectionId)
        {
            InitializeComponent();
            userId = loggedInUserId; // Pass the logged-in user's ID
            electionId = selectedElectionId; // Pass the selected election's ID
        }

        private void VotingForm_Load(object sender, EventArgs e)
        {
            LoadElectionDetails();
            LoadCandidates();
        }

        private void LoadElectionDetails()
        {
            string query = "SELECT Name, StartDate FROM election WHERE ID = @ElectionID";

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ElectionID", electionId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        label2.Text = "Election Title: " + reader["ElectionTitle"].ToString();
                        label3.Text = "Election Date: " + Convert.ToDateTime(reader["ElectionDate"]).ToString("dd-MM-yyyy");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading election details: " + ex.Message);
                }
            }
        }

        private void LoadCandidates()
        {
            string query = @"
    SELECT 
        c.CandidateID, 
        u.Name AS CandidateName 
    FROM 
        Candidates c
    INNER JOIN 
        Users u ON c.UserID = u.UserID
    WHERE 
        c.ElectionID = @ElectionID";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@ElectionID", electionId);

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading candidates: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // Submit Vote Button
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string selectedCandidateId = dataGridView1.SelectedRows[0].Cells["CandidateID"].Value.ToString();

                string query = "INSERT INTO vote (ElectionID, CandidateID, UserID) VALUES (@ElectionID, @CandidateID, @UserID)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ElectionID", electionId);
                        command.Parameters.AddWithValue("@CandidateID", selectedCandidateId);
                        command.Parameters.AddWithValue("@UserID", userId);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Your vote has been successfully cast!");

                        // Optionally, disable further voting for the user in this election.
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error casting vote: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a candidate before submitting your vote.");
            }
        }

        private void button2_Click(object sender, EventArgs e) // Back Button
        {
            UserDashboardForm dashboard = new UserDashboardForm();
            dashboard.Show();
            this.Close();
        }
    }
    private void buttonVoteNow_Click(object sender, EventArgs e)
    {
        string selectedElectionId = dataGridViewElections.SelectedRows[0].Cells["ElectionID"].Value.ToString();
        VotingForm votingForm = new VotingForm(loggedInUserId, selectedElectionId);
        votingForm.Show();
        this.Hide();
    }