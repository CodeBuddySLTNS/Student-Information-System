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

        public MainForm()
        {
            InitializeComponent();
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
            statusStrip.Items.Add(statusLabel);
            Controls.Add(statusStrip);
        }

        private void StudentsMenuItem_Click(object? sender, EventArgs e)
        {
            using var form = new StudentManagementForm();
            form.ShowDialog(this);
        }
    }
}

