using System;

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
            this.btn3ViewElections = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btnManageSocieties = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btn3ViewElections);
            this.panel1.Controls.Add(this.btn2);
            this.panel1.Controls.Add(this.btnManageSocieties);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 488);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btn3ViewElections
            // 
            this.btn3ViewElections.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn3ViewElections.Location = new System.Drawing.Point(0, 117);
            this.btn3ViewElections.Name = "btn3ViewElections";
            this.btn3ViewElections.Size = new System.Drawing.Size(165, 68);
            this.btn3ViewElections.TabIndex = 2;
            this.btn3ViewElections.Text = "View Elections";
            this.btn3ViewElections.UseVisualStyleBackColor = true;
            this.btn3ViewElections.Click += new System.EventHandler(this.btnViewElections_Click);
            // 
            // btn2
            // 
            this.btn2.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn2.Location = new System.Drawing.Point(0, 57);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(165, 60);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "Schedule Election";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btnManageSocieties
            // 
            this.btnManageSocieties.AccessibleName = "";
            this.btnManageSocieties.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageSocieties.Location = new System.Drawing.Point(0, 0);
            this.btnManageSocieties.Name = "btnManageSocieties";
            this.btnManageSocieties.Size = new System.Drawing.Size(165, 57);
            this.btnManageSocieties.TabIndex = 0;
            this.btnManageSocieties.Text = "Manage Societies";
            this.btnManageSocieties.UseVisualStyleBackColor = true;
            this.btnManageSocieties.Click += new System.EventHandler(this.btnManageSocieties_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Welcome Admin!";
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 488);
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

        private void btnManageSocieties_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnScheduleElection_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnViewElections_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn3ViewElections;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btnManageSocieties;
        private System.Windows.Forms.Label label1;
    }
}