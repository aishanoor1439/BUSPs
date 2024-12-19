namespace BUSPs.Forms
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnViewElections = new System.Windows.Forms.Button();
            this.btnScheduleElection = new System.Windows.Forms.Button();
            this.btnManageSocieties = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnViewElections);
            this.panel1.Controls.Add(this.btnScheduleElection);
            this.panel1.Controls.Add(this.btnManageSocieties);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 461);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnViewElections
            // 
            this.btnViewElections.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewElections.Location = new System.Drawing.Point(0, 117);
            this.btnViewElections.Name = "btnViewElections";
            this.btnViewElections.Size = new System.Drawing.Size(110, 68);
            this.btnViewElections.TabIndex = 2;
            this.btnViewElections.Text = "View Elections";
            this.btnViewElections.UseVisualStyleBackColor = true;
            this.btnViewElections.Click += new System.EventHandler(this.btnViewElections_Click);
            // 
            // btnScheduleElection
            // 
            this.btnScheduleElection.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnScheduleElection.Location = new System.Drawing.Point(0, 57);
            this.btnScheduleElection.Name = "btnScheduleElection";
            this.btnScheduleElection.Size = new System.Drawing.Size(110, 60);
            this.btnScheduleElection.TabIndex = 1;
            this.btnScheduleElection.Text = "Schedule Election";
            this.btnScheduleElection.UseVisualStyleBackColor = true;
            this.btnScheduleElection.Click += new System.EventHandler(this.btnScheduleElection_Click);
            // 
            // btnManageSocieties
            // 
            this.btnManageSocieties.AccessibleName = "";
            this.btnManageSocieties.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageSocieties.Location = new System.Drawing.Point(0, 0);
            this.btnManageSocieties.Name = "btnManageSocieties";
            this.btnManageSocieties.Size = new System.Drawing.Size(110, 57);
            this.btnManageSocieties.TabIndex = 0;
            this.btnManageSocieties.Text = "Manage Societies";
            this.btnManageSocieties.UseVisualStyleBackColor = true;
            this.btnManageSocieties.Click += new System.EventHandler(this.btnManageSocieties_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Welcome Admin!";
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AdminDashboard";
            this.ShowInTaskbar = false;
            this.Text = "AdminDashboard";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnViewElections;
        private System.Windows.Forms.Button btnScheduleElection;
        private System.Windows.Forms.Button btnManageSocieties;
        private System.Windows.Forms.Label label1;
    }
}