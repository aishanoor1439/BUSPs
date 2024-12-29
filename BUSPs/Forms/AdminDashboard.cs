using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUSPs.Databases;
using BUSPS.Forms;

namespace BUSPs.Forms
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            SocietyManagementForm societyForm = new SocietyManagementForm();
            societyForm.Show();
            this.Hide();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            ElectionSchedulingForm electionForm = new ElectionSchedulingForm();
            electionForm.Show();
            this.Hide();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            ElectionResultsForm resultsForm = new ElectionResultsForm();
            resultsForm.Show();
            this.Hide();
        }

    }
}
