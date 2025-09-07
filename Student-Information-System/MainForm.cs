namespace Student_Information_System
{
    using System;
    using System.Windows.Forms;

    public class MainForm : Form
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem studentsMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        private ToolStripStatusLabel clockLabel;

        private Panel headerPanel;
        private Label titleLabel;
        private Button btnOpenStudents;
        private Label lblStudentsCount;
        private Label lblDbStatus;
        private Timer uiTimer;

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }

        private void InitializeComponent()
        {
            Text = "Student Information System - Dashboard";
            Width = 900;
            Height = 600;
            StartPosition = FormStartPosition.CenterScreen;

            menuStrip = new MenuStrip();
            studentsMenuItem = new ToolStripMenuItem("Students");
            studentsMenuItem.Click += StudentsMenuItem_Click;
            menuStrip.Items.Add(studentsMenuItem);
            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);

            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel("Ready");
            clockLabel = new ToolStripStatusLabel(DateTime.Now.ToString("f"));
            statusStrip.Items.Add(statusLabel);
            statusStrip.Items.Add(new ToolStripStatusLabel("|") { Spring = false });
            statusStrip.Items.Add(clockLabel);
            Controls.Add(statusStrip);

            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
            };
            titleLabel = new Label
            {
                Text = "Student Information System",
                AutoSize = false,
                Left = 20,
                Top = 20,
                Width = 600,
                Height = 40,
                Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold)
            };
            btnOpenStudents = new Button
            {
                Text = "Manage Students",
                Width = 180,
                Height = 40,
                Left = 20,
                Top = 70
            };
            btnOpenStudents.Click += StudentsMenuItem_Click;
            lblStudentsCount = new Label
            {
                Text = "Students: -",
                AutoSize = true,
                Left = 230,
                Top = 78,
                Font = new System.Drawing.Font("Segoe UI", 10F)
            };
            lblDbStatus = new Label
            {
                Text = "DB: Unknown",
                AutoSize = true,
                Left = 360,
                Top = 78,
                ForeColor = System.Drawing.Color.DimGray,
                Font = new System.Drawing.Font("Segoe UI", 10F)
            };
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(btnOpenStudents);
            headerPanel.Controls.Add(lblStudentsCount);
            headerPanel.Controls.Add(lblDbStatus);
            Controls.Add(headerPanel);

            uiTimer = new Timer { Interval = 1000 };
            uiTimer.Tick += (s, e) => { clockLabel.Text = DateTime.Now.ToString("f"); };
            uiTimer.Start();
        }

        private void StudentsMenuItem_Click(object? sender, EventArgs e)
        {
            using var form = new StudentManagementForm();
            form.ShowDialog(this);
            LoadDashboardStats();
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            LoadDashboardStats();
        }

        private void LoadDashboardStats()
        {
            try
            {
                using var conn = Database.OpenConnection();
                using var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(*) FROM students", conn);
                var count = Convert.ToInt32(cmd.ExecuteScalar());
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

