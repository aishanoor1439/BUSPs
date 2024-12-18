using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUSPs.Databases;

namespace BUSPs.Forms
{

    public partial class ElectionSchedulingForm : Form
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        public ElectionSchedulingForm()
        {
            InitializeComponent();
        }

        private void LoadElections()
        {
            using (SqlConnection connection = dbHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM election";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewElections.DataSource = dt;
            }
        }

        private void ElectionSchedulingForm_Load(object sender, EventArgs e)
        {
            LoadElections();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string electionName = txtElectionName.Text;
                DateTime startDate = dateTimePickerStartDate.Value;
                DateTime endDate = dateTimePickerEndDate.Value;

                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = $"INSERT INTO election (ID, Name, ) VALUES ('{electionName}', '{startDate}', '{endDate}')";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Election scheduled successfully!");
                    LoadElections();
                }
            }
        }
    }
}
