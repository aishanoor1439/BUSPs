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

    public partial class SocietyManagementForm : Form
    {

        DatabaseHelper dbHelper = new DatabaseHelper();
        public SocietyManagementForm()
        {
            InitializeComponent();
        }

        private void LoadSocieties()
{
    using (SqlConnection connection = dbHelper.GetConnection())
    {
        connection.Open();
        string query = "SELECT * FROM societies";
        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        dataGridViewSocieties.DataSource = dt;
    }
}


        private void dataGridViewSocieties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string societyName = textBox1.Text;
                string description = textBox2.Text;

                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = $"INSERT INTO societies (Name, Description) VALUES ('{societyName}', '{description}')";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Society added successfully!");
                    LoadSocieties();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int societyId = int.Parse(dataGridViewSocieties.SelectedRows[0].Cells["id"].Value.ToString());
            string societyName = textBox1.Text;
            string description = textBox2.Text;

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                connection.Open();
                string query = $"UPDATE societies SET name = '{societyName}', description = '{description}' WHERE id = {societyId}";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Society updated successfully!");
                LoadSocieties();
            }
        }

    }
}
