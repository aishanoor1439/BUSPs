using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUSPs.Databases;

namespace BUSPs.Forms
{
    public partial class SocietyManagementForm : Form
    {
        DatabaseHelper dbHelper = new DatabaseHelper();

        public SocietyManagementForm()
        {
            InitializeComponent();
            LoadSocieties();
        }

        private void LoadSocieties()
        {
            try
            {
                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT ID AS 'ID', Name AS 'Name', Description AS 'Description' FROM society";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading societies: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add Society
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string description = textBox2.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO society (Name, Description) VALUES (@name, @description)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Society added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                        textBox2.Clear();
                        LoadSocieties(); // Refresh list
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding society: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update Society
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a society to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            string name = textBox1.Text;
            string description = textBox2.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE society SET Name = @name, Description = @description WHERE ID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Society updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                        textBox2.Clear();
                        LoadSocieties(); // Refresh list
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating society: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete Society
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a society to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

            try
            {
                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM society WHERE ID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Society deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSocieties(); // Refresh list
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting society: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
