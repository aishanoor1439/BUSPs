using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void btnManageSocieties_Click(object sender, EventArgs e)
        {
            SocietyManagementForm societyForm = new SocietyManagementForm();
            societyForm.Show(); // Show the Society Management Form
            this.Hide(); // Hide the Admin Dashboard
        }

        private void btnScheduleElection_Click(object sender, EventArgs e)
        {
            ElectionSchedulingForm electionForm = new ElectionSchedulingForm();
            electionForm.Show(); // Show the Election Scheduling Form
            this.Hide(); // Hide the Admin Dashboard
        }

        private void btnViewElections_Click(object sender, EventArgs e)
        {
            ViewElectionsForm viewElectionsForm = new ViewElectionsForm();
            viewElectionsForm.Show(); // Show the View Elections Form
            this.Hide(); // Hide the Admin Dashboard
        }
    }
}
