namespace Student_Information_System
{
    using System;
    using System.Data;
    using System.Windows.Forms;
    using MySql.Data.MySqlClient;

    public class StudentManagementForm : Form
    {
        private DataGridView dgvStudents;
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
            Width = 1000;
            Height = 650;
            StartPosition = FormStartPosition.CenterParent;

            dgvStudents = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 320,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvStudents.SelectionChanged += DgvStudents_SelectionChanged;

            lblSearch = new Label
            {
                Text = "Search:",
                Top = 330,
                Left = 12,
                Width = 60
            };

            txtSearch = new TextBox
            {
                Top = 326,
                Left = 80,
                Width = 240
            };
            txtSearch.TextChanged += TxtSearch_TextChanged;

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

            btnAdd = new Button { Text = "Add Student", Left = baseLeft, Top = baseTop + rowGap * 3 + 10, Width = 150, Height = 34 };
            btnAdd.Click += BtnAdd_Click;

            btnUpdate = new Button { Text = "Update Student", Left = btnAdd.Right + 12, Top = btnAdd.Top, Width = 150, Height = 34, Enabled = false };
            btnUpdate.Click += BtnUpdate_Click;

            btnDelete = new Button { Text = "Delete Student", Left = btnUpdate.Right + 12, Top = btnAdd.Top, Width = 150, Height = 34, Enabled = false };
            btnDelete.Click += BtnDelete_Click;

            btnClear = new Button { Text = "Clear", Left = btnDelete.Right + 12, Top = btnAdd.Top, Width = 100, Height = 34 };
            btnClear.Click += BtnClear_Click;

            Controls.Add(dgvStudents);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblStudentCode);
            Controls.Add(txtStudentCode);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Controls.Add(lblMiddleName);
            Controls.Add(txtMiddleName);
            Controls.Add(lblLastName);
            Controls.Add(txtLastName);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
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

