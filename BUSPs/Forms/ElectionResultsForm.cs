using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BUSPS.Forms
{
    public partial class ElectionResultsForm : Form
    {
        public ElectionResultsForm()
        {
            InitializeComponent();
        }

        private void ElectionResultsForm_Load(object sender, EventArgs e)
        {
            LoadElections();
        }

        private void LoadElections()
        {
            string query = "SELECT ID AS ElectionID, Name AS ElectionTitle FROM election";
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    comboBox1.DataSource = table;
                    comboBox1.DisplayMember = "ElectionTitle";
                    comboBox1.ValueMember = "ElectionID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading elections: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                string selectedElectionId = comboBox1.SelectedValue.ToString();
                LoadElectionResults(selectedElectionId);
            }
        }

        private void LoadElectionResults(string electionId)
        {
            string query = "SELECT CandidateName, Votes FROM election_results WHERE ElectionID = @ElectionID";
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@ElectionID", electionId);

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading election results: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDashboardForm dashboard = new UserDashboardForm();
            dashboard.Show();
            this.Close();
        }
    }
}