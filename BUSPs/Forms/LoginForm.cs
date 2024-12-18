﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUSPs.Databases;

namespace BUSPs.Forms
{
    public partial class LoginForm : Form
    {
        DatabaseHelper dbHelper = new DatabaseHelper();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                try
                {
                    connection.Open(); 

                    string query = $"SELECT role FROM users WHERE username = '{username}' AND password = '{password}'";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Execute the query and fetch the result
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString();

                            if (role == "Admin")
                            {
                                MessageBox.Show("Welcome Admin!");
                                AdminDashboard adminDashboard = new AdminDashboard();
                                adminDashboard.Show();
                                this.Hide();
                            }
                            else if (role == "Student")
                            {
                                MessageBox.Show("Welcome Student!");
                                ElectionsPage electionsPage = new ElectionsPage();
                                electionsPage.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
