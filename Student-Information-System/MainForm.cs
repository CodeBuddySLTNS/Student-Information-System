namespace Student_Information_System
{
    using System;
    using System.Windows.Forms;
    using System.ComponentModel;

    public partial class MainForm : Form
    {
        studentsForm studentForm = new studentsForm();
        coursesForm coursesForm = new coursesForm();
        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
            uiTimer.Tick += (s, e) => { clockLabel.Text = DateTime.Now.ToString("f"); };
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                uiTimer.Start();
            }
        }



        private void StudentsMenuItem_Click(object? sender, EventArgs e)
        {
            studentForm.ShowDialog();
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

        private void couToolStripMenuItem_Click(object sender, EventArgs e)
        {
            coursesForm.ShowDialog();
        }
    }
}

