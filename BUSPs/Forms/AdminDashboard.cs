using System;
using System.Windows.Forms;

namespace BUSPs.Forms
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        // Button to open the Society Management Form
        private void btn1_Click(object sender, EventArgs e)
        {
            SocietyManagementForm societyForm = new SocietyManagementForm();
            societyForm.Show();
            this.Hide();
        }

        // Button to open the Election Scheduling Form
        private void btn2_Click(object sender, EventArgs e)
        {
            ElectionSchedulingForm electionForm = new ElectionSchedulingForm();
            electionForm.Show();
            this.Hide();
        }

        // Button to open the Election Results Form
        private void btn3_Click(object sender, EventArgs e)
        {
            ElectionResultsForm resultsForm = new ElectionResultsForm();
            resultsForm.Show();
            this.Hide();
        }
    }
}
