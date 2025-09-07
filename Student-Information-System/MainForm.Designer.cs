namespace Student_Information_System
{
    using System;
    using System.Windows.Forms;

    public partial class MainForm
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Student Information System - Dashboard";
            this.Name = "MainForm";

            menuStrip = new MenuStrip();
            menuStrip.Name = "menuStrip";
            studentsMenuItem = new ToolStripMenuItem("Students");
            studentsMenuItem.Name = "studentsMenuItem";
            studentsMenuItem.Click += StudentsMenuItem_Click;
            menuStrip.Items.Add(studentsMenuItem);
            this.MainMenuStrip = menuStrip;

            statusStrip = new StatusStrip();
            statusStrip.Name = "statusStrip";
            statusLabel = new ToolStripStatusLabel("Ready");
            statusLabel.Name = "statusLabel";
            clockLabel = new ToolStripStatusLabel(DateTime.Now.ToString("f"));
            clockLabel.Name = "clockLabel";
            statusStrip.Items.Add(statusLabel);
            statusStrip.Items.Add(new ToolStripStatusLabel("|") { Spring = false });
            statusStrip.Items.Add(clockLabel);

            headerPanel = new Panel();
            headerPanel.Name = "headerPanel";
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 120;
            headerPanel.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);

            titleLabel = new Label();
            titleLabel.Name = "titleLabel";
            titleLabel.Text = "Student Information System";
            titleLabel.AutoSize = false;
            titleLabel.Left = 20;
            titleLabel.Top = 20;
            titleLabel.Width = 600;
            titleLabel.Height = 40;
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);

            btnOpenStudents = new Button();
            btnOpenStudents.Name = "btnOpenStudents";
            btnOpenStudents.Text = "Manage Students";
            btnOpenStudents.Width = 180;
            btnOpenStudents.Height = 40;
            btnOpenStudents.Left = 20;
            btnOpenStudents.Top = 70;
            btnOpenStudents.Click += StudentsMenuItem_Click;

            lblStudentsCount = new Label();
            lblStudentsCount.Name = "lblStudentsCount";
            lblStudentsCount.Text = "Students: -";
            lblStudentsCount.AutoSize = true;
            lblStudentsCount.Left = 230;
            lblStudentsCount.Top = 78;
            lblStudentsCount.Font = new System.Drawing.Font("Segoe UI", 10F);

            lblDbStatus = new Label();
            lblDbStatus.Name = "lblDbStatus";
            lblDbStatus.Text = "DB: Unknown";
            lblDbStatus.AutoSize = true;
            lblDbStatus.Left = 360;
            lblDbStatus.Top = 78;
            lblDbStatus.ForeColor = System.Drawing.Color.DimGray;
            lblDbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);

            headerPanel.SuspendLayout();
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(btnOpenStudents);
            headerPanel.Controls.Add(lblStudentsCount);
            headerPanel.Controls.Add(lblDbStatus);
            headerPanel.ResumeLayout(false);

            this.Controls.Add(headerPanel);
            this.Controls.Add(statusStrip);
            this.Controls.Add(menuStrip);

            uiTimer = new Timer();
            uiTimer.Interval = 1000;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

