namespace Student_Information_System
{
    using System;
    using System.Data;
    using System.ComponentModel;
    using System.Windows.Forms;
    

    public partial class StudentManagementForm : Form
    {
        

        private readonly BindingSource _bindingSource = new BindingSource();
        private DataTable _studentsTable = new DataTable();

        public StudentManagementForm()
        {
            InitializeComponent();
            Load += StudentManagementForm_Load;
        }

        

        private void StudentManagementForm_Load(object? sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }
            ReloadStudents();
        }

        private void ReloadStudents()
        {
            _studentsTable = Database.GetStudents();
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

            int affected = Database.AddStudent(studentCode, firstName, string.IsNullOrWhiteSpace(middleName) ? null : middleName, lastName, string.IsNullOrWhiteSpace(phone) ? null : phone);
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

            int affected = Database.UpdateStudent(id, studentCode, firstName, string.IsNullOrWhiteSpace(middleName) ? null : middleName, lastName, string.IsNullOrWhiteSpace(phone) ? null : phone);
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

            int affected = Database.DeleteStudent(id);
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

