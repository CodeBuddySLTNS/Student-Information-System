namespace Student_Information_System
{
    using System.Windows.Forms;
    using System.Drawing;

    public partial class StudentManagementForm
    {
        private DataGridView dgvStudents;
        private Panel headerPanel;
        private Label headerTitle;
        private Panel contentPanel;
        private Panel searchPanel;
        private TextBox txtStudentCode;
        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private TextBox txtLastName;
        private TextBox txtPhone;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private TextBox txtSearch;
        private Label lblSearch;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Student Management";
            this.BackColor = Color.FromArgb(250, 252, 255);
            this.Font = new Font("Segoe UI", 10F);

            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(30, 58, 138)
            };
            headerTitle = new Label
            {
                Text = "Manage Students",
                AutoSize = false,
                Left = 20,
                Top = 18,
                Width = 800,
                Height = 44,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold)
            };
            headerPanel.SuspendLayout();
            headerPanel.Controls.Add(headerTitle);
            headerPanel.ResumeLayout(false);

            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(16)
            };

            dgvStudents = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 360,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                EnableHeadersVisualStyles = false
            };
            dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 175);
            dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 247, 254);
            dgvStudents.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 219, 254);
            dgvStudents.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            searchPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                Padding = new Padding(12, 8, 12, 8)
            };
            lblSearch = new Label
            {
                Text = "Search:",
                Left = 12,
                Top = 12,
                Width = 70
            };
            txtSearch = new TextBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Left = 90,
                Top = 8,
                Width = 320
            };
            searchPanel.Controls.Add(lblSearch);
            searchPanel.Controls.Add(txtSearch);

            int baseLeft = 12;
            int baseTop = 410;
            int labelWidth = 100;
            int inputWidth = 220;
            int rowGap = 38;
            int colGap = 20;

            var lblStudentCode = new Label { Text = "Student Code", Left = baseLeft, Top = baseTop, Width = labelWidth };
            txtStudentCode = new TextBox { Left = lblStudentCode.Right + 8, Top = baseTop - 4, Width = inputWidth };

            var lblFirstName = new Label { Text = "First Name", Left = baseLeft, Top = baseTop + rowGap, Width = labelWidth };
            txtFirstName = new TextBox { Left = lblFirstName.Right + 8, Top = baseTop + rowGap - 4, Width = inputWidth };

            var lblMiddleName = new Label { Text = "Middle Name", Left = baseLeft, Top = baseTop + rowGap * 2, Width = labelWidth };
            txtMiddleName = new TextBox { Left = lblMiddleName.Right + 8, Top = baseTop + rowGap * 2 - 4, Width = inputWidth };

            var lblLastName = new Label { Text = "Last Name", Left = baseLeft + labelWidth + inputWidth + colGap + 60, Top = baseTop, Width = labelWidth };
            txtLastName = new TextBox { Left = lblLastName.Right + 8, Top = baseTop - 4, Width = inputWidth };

            var lblPhone = new Label { Text = "Phone", Left = baseLeft + labelWidth + inputWidth + colGap + 60, Top = baseTop + rowGap, Width = labelWidth };
            txtPhone = new TextBox { Left = lblPhone.Right + 8, Top = baseTop + rowGap - 4, Width = inputWidth };

            btnAdd = new Button { Text = "Add Student", Left = baseLeft, Top = baseTop + rowGap * 3 + 18, Width = 170, Height = 38, FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(16, 185, 129), ForeColor = Color.White };
            btnAdd.FlatAppearance.BorderSize = 0;

            btnUpdate = new Button { Text = "Update Student", Left = btnAdd.Right + 12, Top = btnAdd.Top, Width = 170, Height = 38, Enabled = false, FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(59, 130, 246), ForeColor = Color.White };
            btnUpdate.FlatAppearance.BorderSize = 0;

            btnDelete = new Button { Text = "Delete Student", Left = btnUpdate.Right + 12, Top = btnAdd.Top, Width = 170, Height = 38, Enabled = false, FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(239, 68, 68), ForeColor = Color.White };
            btnDelete.FlatAppearance.BorderSize = 0;

            btnClear = new Button { Text = "Clear", Left = btnDelete.Right + 12, Top = btnAdd.Top, Width = 120, Height = 38, FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(107, 114, 128), ForeColor = Color.White };
            btnClear.FlatAppearance.BorderSize = 0;

            contentPanel.SuspendLayout();
            contentPanel.Controls.Add(searchPanel);
            contentPanel.Controls.Add(dgvStudents);
            contentPanel.Controls.Add(lblStudentCode);
            contentPanel.Controls.Add(txtStudentCode);
            contentPanel.Controls.Add(lblFirstName);
            contentPanel.Controls.Add(txtFirstName);
            contentPanel.Controls.Add(lblMiddleName);
            contentPanel.Controls.Add(txtMiddleName);
            contentPanel.Controls.Add(lblLastName);
            contentPanel.Controls.Add(txtLastName);
            contentPanel.Controls.Add(lblPhone);
            contentPanel.Controls.Add(txtPhone);
            contentPanel.Controls.Add(btnAdd);
            contentPanel.Controls.Add(btnUpdate);
            contentPanel.Controls.Add(btnDelete);
            contentPanel.Controls.Add(btnClear);

            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();

            this.Controls.Add(headerPanel);
            this.Controls.Add(contentPanel);

            this.ResumeLayout(false);
        }
    }
}

