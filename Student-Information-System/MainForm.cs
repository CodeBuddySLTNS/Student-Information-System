namespace Student_Information_System
{
    using System;
    using System.Windows.Forms;
    using System.ComponentModel;

    public partial class MainForm : Form
    {
        

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }

        

        private void StudentsMenuItem_Click(object? sender, EventArgs e)
        {
            using var form = new StudentManagementForm();
            form.ShowDialog(this);
            LoadDashboardStats();
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }
            LoadDashboardStats();
        }

        private void LoadDashboardStats()
        {
            try
            {
                var count = Database.GetStudentCount();
                lblStudentsCount.Text = $"Students: {count}";
                lblDbStatus.Text = "DB: Connected";
                lblDbStatus.ForeColor = System.Drawing.Color.ForestGreen;
                statusLabel.Text = "Ready";
            }
            catch (Exception ex)
            {
                lblStudentsCount.Text = "Students: -";
                lblDbStatus.Text = "DB: Error";
                lblDbStatus.ForeColor = System.Drawing.Color.Firebrick;
                statusLabel.Text = $"Database error: {ex.Message}";
            }
        }
    }
}

