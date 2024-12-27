using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUSPs.Databases;

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

    }
}
