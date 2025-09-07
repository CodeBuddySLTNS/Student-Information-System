namespace Student_Information_System
{
    using System;
    using System.Data;
    using System.Windows.Forms;
    using MySql.Data.MySqlClient;

    public class StudentManagementForm : Form
    {
        private DataGridView dgvStudents;
        private Panel headerPanel;
        private Label headerTitle;
        private Panel contentPanel;
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

        private readonly BindingSource _bindingSource = new BindingSource();
        private DataTable _studentsTable = new DataTable();

        public StudentManagementForm()
        {
            InitializeComponent();
            Load += StudentManagementForm_Load;
        }

        private void InitializeComponent()
        {
            Text = "Student Management";
            Width = 1100;
            Height = 720;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = System.Drawing.Color.FromArgb(250, 252, 255);
            Font = new System.Drawing.Font("Segoe UI", 10F);

            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = System.Drawing.Color.FromArgb(30, 58, 138)
            };
            headerTitle = new Label
            {
                Text = "Manage Students",
                AutoSize = false,
                Left = 20,
                Top = 18,
                Width = 800,
                Height = 44,
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold)
            };
            headerPanel.Controls.Add(headerTitle);

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
                BackgroundColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.None,
                EnableHeadersVisualStyles = false
            };
            dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 64, 175);
            dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvStudents.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 247, 254);
            dgvStudents.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(191, 219, 254);
            dgvStudents.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgvStudents.SelectionChanged += DgvStudents_SelectionChanged;

            lblSearch = new Label
            {
                Text = "Search:",
                Top = dgvStudents.Bottom + 10,
                Left = 12,
                Width = 70
            };

            txtSearch = new TextBox
            {
                Top = dgvStudents.Bottom + 6,
                Left = lblSearch.Right + 8,
                Width = 300
            };
            txtSearch.TextChanged += TxtSearch_TextChanged;

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

            btnAdd = new Button { Text = "Add Student", Left = baseLeft, Top = baseTop + rowGap * 3 + 18, Width = 170, Height = 38, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(16, 185, 129), ForeColor = System.Drawing.Color.White };
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Click += BtnAdd_Click;

            btnUpdate = new Button { Text = "Update Student", Left = btnAdd.Right + 12, Top = btnAdd.Top, Width = 170, Height = 38, Enabled = false, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(59, 130, 246), ForeColor = System.Drawing.Color.White };
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.Click += BtnUpdate_Click;

            btnDelete = new Button { Text = "Delete Student", Left = btnUpdate.Right + 12, Top = btnAdd.Top, Width = 170, Height = 38, Enabled = false, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(239, 68, 68), ForeColor = System.Drawing.Color.White };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += BtnDelete_Click;

            btnClear = new Button { Text = "Clear", Left = btnDelete.Right + 12, Top = btnAdd.Top, Width = 120, Height = 38, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(107, 114, 128), ForeColor = System.Drawing.Color.White };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += BtnClear_Click;

            contentPanel.Controls.Add(dgvStudents);
            contentPanel.Controls.Add(lblSearch);
            contentPanel.Controls.Add(txtSearch);
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

            Controls.Add(contentPanel);
            Controls.Add(headerPanel);
        }

        private void StudentManagementForm_Load(object? sender, EventArgs e)
        {
            ReloadStudents();
        }

        private void ReloadStudents()
        {
            using var conn = Database.OpenConnection();
            using var cmd = new MySqlCommand(
                "SELECT id, studentCode, firstName, middleName, lastName, phone FROM students ORDER BY id DESC",
                conn
            );
            using var adapter = new MySqlDataAdapter(cmd);
            _studentsTable = new DataTable();
            adapter.Fill(_studentsTable);

            _bindingSource.DataSource = _studentsTable;
            dgvStudents.DataSource = _bindingSource;

            btnUpdate.Enabled = dgvStudents.SelectedRows.Count > 0;
            btnDelete.Enabled = dgvStudents.SelectedRows.Count > 0;
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (_studentsTable == null || _studentsTable.Rows.Count == 0)
            {
                return;
            }

            string term = EscapeLikeValue(txtSearch.Text.Trim());
            if (string.IsNullOrEmpty(term))
            {
                _bindingSource.RemoveFilter();
                return;
            }

            string filter =
                $"Convert(studentCode, 'System.String') LIKE '%{term}%' OR " +
                $"firstName LIKE '%{term}%' OR " +
                $"middleName LIKE '%{term}%' OR " +
                $"lastName LIKE '%{term}%'";
            _bindingSource.Filter = filter;
        }

        private static string EscapeLikeValue(string value)
        {
            return value.Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]").Replace("'", "''");
        }

        private void DgvStudents_SelectionChanged(object? sender, EventArgs e)
        {
            bool hasSelection = dgvStudents.SelectedRows.Count > 0;
            btnUpdate.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;

            if (hasSelection)
            {
                var row = dgvStudents.SelectedRows[0];
                txtStudentCode.Text = row.Cells["studentCode"].Value?.ToString() ?? "";
                txtFirstName.Text = row.Cells["firstName"].Value?.ToString() ?? "";
                txtMiddleName.Text = row.Cells["middleName"].Value?.ToString() ?? "";
                txtLastName.Text = row.Cells["lastName"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["phone"].Value?.ToString() ?? "";
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputsForAddOrUpdate(out int studentCode, out string firstName, out string middleName, out string lastName, out string phone))
            {
                return;
            }

            using var conn = Database.OpenConnection();
            using var cmd = new MySqlCommand(
                "INSERT INTO students (studentCode, firstName, middleName, lastName, phone) VALUES (@code, @first, @middle, @last, @phone)",
                conn
            );
            cmd.Parameters.AddWithValue("@code", studentCode);
            cmd.Parameters.AddWithValue("@first", firstName);
            cmd.Parameters.AddWithValue("@middle", string.IsNullOrWhiteSpace(middleName) ? (object)DBNull.Value : middleName);
            cmd.Parameters.AddWithValue("@last", lastName);
            cmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone);

            int affected = cmd.ExecuteNonQuery();
            if (affected > 0)
            {
                ReloadStudents();
                ClearInputs();
                MessageBox.Show("Student added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                return;
            }

            if (!ValidateInputsForAddOrUpdate(out int studentCode, out string firstName, out string middleName, out string lastName, out string phone))
            {
                return;
            }

            int id = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["id"].Value);

            using var conn = Database.OpenConnection();
            using var cmd = new MySqlCommand(
                "UPDATE students SET studentCode = @code, firstName = @first, middleName = @middle, lastName = @last, phone = @phone WHERE id = @id",
                conn
            );
            cmd.Parameters.AddWithValue("@code", studentCode);
            cmd.Parameters.AddWithValue("@first", firstName);
            cmd.Parameters.AddWithValue("@middle", string.IsNullOrWhiteSpace(middleName) ? (object)DBNull.Value : middleName);
            cmd.Parameters.AddWithValue("@last", lastName);
            cmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone);
            cmd.Parameters.AddWithValue("@id", id);

            int affected = cmd.ExecuteNonQuery();
            if (affected > 0)
            {
                ReloadStudents();
                MessageBox.Show("Student updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                return;
            }

            int id = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["id"].Value);

            var confirm = MessageBox.Show("Are you sure you want to delete the selected student?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            using var conn = Database.OpenConnection();
            using var cmd = new MySqlCommand("DELETE FROM students WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            int affected = cmd.ExecuteNonQuery();
            if (affected > 0)
            {
                ReloadStudents();
                ClearInputs();
                MessageBox.Show("Student deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            ClearInputs();
            dgvStudents.ClearSelection();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void ClearInputs()
        {
            txtStudentCode.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtSearch.Text = "";
        }

        private bool ValidateInputsForAddOrUpdate(out int studentCode, out string firstName, out string middleName, out string lastName, out string phone)
        {
            studentCode = 0;
            firstName = txtFirstName.Text.Trim();
            middleName = txtMiddleName.Text.Trim();
            lastName = txtLastName.Text.Trim();
            phone = txtPhone.Text.Trim();

            if (!int.TryParse(txtStudentCode.Text.Trim(), out studentCode))
            {
                MessageBox.Show("Student Code must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("First Name and Last Name are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}

