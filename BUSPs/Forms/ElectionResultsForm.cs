using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BUSPs.Databases;


namespace BUSPS.Forms
{
    public partial class ElectionResultsForm : Form
    {
        DatabaseHelper dbHelper = new DatabaseHelper();

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
            string query = "SELECT ID, Name FROM election";

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    comboBox1.DataSource = table;
                    comboBox1.DisplayMember = "ElectionTitle";
                    comboBox1.ValueMember = "ElectionID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading elections: " + ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedElectionId = comboBox1.SelectedValue.ToString();
            LoadElectionResults(selectedElectionId);
        }

        private void LoadElectionResults(string electionId)
        {
            string query = @"";

            using (SqlConnection connection = dbHelper.GetConnection())
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
                    MessageBox.Show("Error loading election results: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // Back Button
        {
            UserDashboardForm dashboard = new UserDashboardForm();
            dashboard.Show();
            this.Close();
        }
        {
    ElectionResultsForm resultsForm = new ElectionResultsForm();
        resultsForm.Show();
    this.Hide();
    }
}
}
