namespace Student_Information_System
{
    using System.Windows.Forms;
    using System.Drawing;

    public partial class StudentManagementForm
    {
        private DataGridView dgvStudents;
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
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Student Management";
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Font = new Font("Segoe UI", 10F);

            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(12)
            };

            dgvStudents = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 320,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            searchPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                Padding = new Padding(0, 8, 0, 8)
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
                Left = 70,
                Top = 8,
                Width = 260
            };
            searchPanel.Controls.Add(lblSearch);
            searchPanel.Controls.Add(txtSearch);

            int baseLeft = 12;
            int baseTop = 370;
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

            btnAdd = new Button { Text = "Add Student", Left = baseLeft, Top = baseTop + rowGap * 3 + 18, Width = 150, Height = 34 };

            btnUpdate = new Button { Text = "Update Student", Left = btnAdd.Right + 12, Top = btnAdd.Top, Width = 150, Height = 34, Enabled = false };

            btnDelete = new Button { Text = "Delete Student", Left = btnUpdate.Right + 12, Top = btnAdd.Top, Width = 150, Height = 34, Enabled = false };

            btnClear = new Button { Text = "Clear", Left = btnDelete.Right + 12, Top = btnAdd.Top, Width = 100, Height = 34 };

            contentPanel.SuspendLayout();
            contentPanel.Controls.Add(dgvStudents);
            contentPanel.Controls.Add(searchPanel);
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

            this.Controls.Add(contentPanel);

            this.ResumeLayout(false);
        }
    }
}

