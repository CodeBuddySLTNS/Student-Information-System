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
            components = new System.ComponentModel.Container();
            menuStrip = new MenuStrip();
            studentsMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            clockLabel = new ToolStripStatusLabel();
            headerPanel = new Panel();
            titleLabel = new Label();
            btnOpenStudents = new Button();
            lblStudentsCount = new Label();
            lblDbStatus = new Label();
            uiTimer = new Timer(components);
            pictureBox1 = new PictureBox();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { studentsMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(900, 24);
            menuStrip.TabIndex = 2;
            // 
            // studentsMenuItem
            // 
            studentsMenuItem.Name = "studentsMenuItem";
            studentsMenuItem.Size = new Size(65, 20);
            studentsMenuItem.Text = "Students";
            studentsMenuItem.Click += StudentsMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel, clockLabel });
            statusStrip.Location = new Point(0, 578);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(900, 22);
            statusStrip.TabIndex = 1;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(39, 17);
            statusLabel.Text = "Ready";
            // 
            // clockLabel
            // 
            clockLabel.Name = "clockLabel";
            clockLabel.Size = new Size(205, 17);
            clockLabel.Text = "Monday, September 8, 2025 10:13 AM";
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(245, 247, 250);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(btnOpenStudents);
            headerPanel.Controls.Add(lblStudentsCount);
            headerPanel.Controls.Add(lblDbStatus);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 24);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(900, 120);
            headerPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(20, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(600, 40);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Student Information System";
            // 
            // btnOpenStudents
            // 
            btnOpenStudents.Location = new Point(20, 70);
            btnOpenStudents.Name = "btnOpenStudents";
            btnOpenStudents.Size = new Size(180, 40);
            btnOpenStudents.TabIndex = 1;
            btnOpenStudents.Text = "Manage Students";
            btnOpenStudents.Click += StudentsMenuItem_Click;
            // 
            // lblStudentsCount
            // 
            lblStudentsCount.AutoSize = true;
            lblStudentsCount.Font = new Font("Segoe UI", 10F);
            lblStudentsCount.Location = new Point(230, 78);
            lblStudentsCount.Name = "lblStudentsCount";
            lblStudentsCount.Size = new Size(76, 19);
            lblStudentsCount.TabIndex = 2;
            lblStudentsCount.Text = "Students: -";
            // 
            // lblDbStatus
            // 
            lblDbStatus.AutoSize = true;
            lblDbStatus.Font = new Font("Segoe UI", 10F);
            lblDbStatus.ForeColor = Color.DimGray;
            lblDbStatus.Location = new Point(360, 78);
            lblDbStatus.Name = "lblDbStatus";
            lblDbStatus.Size = new Size(93, 19);
            lblDbStatus.TabIndex = 3;
            lblDbStatus.Text = "DB: Unknown";
            // 
            // uiTimer
            // 
            uiTimer.Interval = 1000;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources.paclogo;
            pictureBox1.Location = new Point(0, 166);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(900, 409);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(pictureBox1);
            Controls.Add(headerPanel);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Information System - Dashboard";
            WindowState = FormWindowState.Maximized;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.ComponentModel.IContainer components;
        private PictureBox pictureBox1;
    }
}

