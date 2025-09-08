using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Information_System
{
    public partial class studentsForm : Form
    {
        private string action = "";
        private DataTable originalData;
        private int selectedStudentId = -1;

        public studentsForm()
        {
            InitializeComponent();
            LoadStudentData();
            SetupDataGridView();
        }

        private void LoadStudentData()
        {
            try
            {
                originalData = Database.GetStudents();
                dataGridView1.DataSource = originalData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading student data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }

        private void SetInputsEnabled(bool enabled)
        {
            studentCodeTxt.Enabled = enabled;
            firstNameTxt.Enabled = enabled;
            middleNameTxt.Enabled = enabled;
            lastNameTxt.Enabled = enabled;
            phoneTxt.Enabled = enabled;
        }

        private void SetActionState(bool inAction)
        {
            clearBtn.Visible = !inAction;
            cancelBtn.Visible = inAction;
            SetInputsEnabled(inAction);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetActionState(false);
        }

        private void addStudentBtn_Click(object sender, EventArgs e)
        {
            if (action == "")
            {
                action = "Add";
                addStudentBtn.Text = "Save";
                editStudentBtn.Enabled = false;
                deleteStudentBtn.Enabled = false;
                editStudentBtn.BackColor = Color.Silver;
                deleteStudentBtn.BackColor = Color.Silver;
                ClearFields();
                SetActionState(true);
            }
            else
            {
                if (ValidateInput())
                {
                    try
                    {
                        int studentCode = int.Parse(studentCodeTxt.Text);
                        string firstName = firstNameTxt.Text.Trim();
                        string middleName = string.IsNullOrWhiteSpace(middleNameTxt.Text) ? null : middleNameTxt.Text.Trim();
                        string lastName = lastNameTxt.Text.Trim();
                        string phone = string.IsNullOrWhiteSpace(phoneTxt.Text) ? null : phoneTxt.Text.Trim();

                        int result = Database.AddStudent(studentCode, firstName, middleName, lastName, phone);
                        if (result > 0)
                        {
                            MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadStudentData();
                            ResetButtons();
                            ClearFields();
                            SetActionState(false);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void editStudentBtn_Click(object sender, EventArgs e)
        {
            if (action == "")
            {
                if (selectedStudentId == -1)
                {
                    MessageBox.Show("Please select a student to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                action = "Edit";
                editStudentBtn.Text = "Save";
                addStudentBtn.Enabled = false;
                deleteStudentBtn.Enabled = false;
                addStudentBtn.BackColor = Color.Silver;
                editStudentBtn.BackColor = Color.LightGreen;
                deleteStudentBtn.BackColor = Color.Silver;
                SetActionState(true);
            }
            else
            {
                if (ValidateInput())
                {
                    try
                    {
                        int studentCode = int.Parse(studentCodeTxt.Text);
                        string firstName = firstNameTxt.Text.Trim();
                        string middleName = string.IsNullOrWhiteSpace(middleNameTxt.Text) ? null : middleNameTxt.Text.Trim();
                        string lastName = lastNameTxt.Text.Trim();
                        string phone = string.IsNullOrWhiteSpace(phoneTxt.Text) ? null : phoneTxt.Text.Trim();

                        int result = Database.UpdateStudent(selectedStudentId, studentCode, firstName, middleName, lastName, phone);
                        if (result > 0)
                        {
                            MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadStudentData();
                            ResetButtons();
                            ClearFields();
                            SetActionState(false);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void deleteStudentBtn_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Please select a student to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this student? This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int deleteResult = Database.DeleteStudent(selectedStudentId);
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudentData();
                        ClearFields();
                        selectedStudentId = -1;
                        SetActionState(false);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ResetButtons();
            ClearFields();
            SetActionState(false);
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                selectedStudentId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                
                studentCodeTxt.Text = selectedRow.Cells["studentCode"].Value.ToString();
                firstNameTxt.Text = selectedRow.Cells["firstName"].Value.ToString();
                middleNameTxt.Text = selectedRow.Cells["middleName"].Value?.ToString() ?? "";
                lastNameTxt.Text = selectedRow.Cells["lastName"].Value.ToString();
                phoneTxt.Text = selectedRow.Cells["phone"].Value?.ToString() ?? "";
            }
        }

        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            if (originalData != null)
            {
                string searchText = searchTxt.Text.ToLower();
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    dataGridView1.DataSource = originalData;
                }
                else
                {
                    DataTable filteredData = originalData.Clone();
                    foreach (DataRow row in originalData.Rows)
                    {
                        string studentCode = row["studentCode"].ToString().ToLower();
                        string firstName = row["firstName"].ToString().ToLower();
                        string middleName = row["middleName"].ToString().ToLower();
                        string lastName = row["lastName"].ToString().ToLower();
                        string fullName = $"{firstName} {middleName} {lastName}".ToLower();

                        if (studentCode.Contains(searchText) || 
                            firstName.Contains(searchText) || 
                            middleName.Contains(searchText) || 
                            lastName.Contains(searchText) ||
                            fullName.Contains(searchText))
                        {
                            filteredData.ImportRow(row);
                        }
                    }
                    dataGridView1.DataSource = filteredData;
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(studentCodeTxt.Text))
            {
                MessageBox.Show("Student Code is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                studentCodeTxt.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(firstNameTxt.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                firstNameTxt.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(lastNameTxt.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lastNameTxt.Focus();
                return false;
            }

            if (!int.TryParse(studentCodeTxt.Text, out _))
            {
                MessageBox.Show("Student Code must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                studentCodeTxt.Focus();
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            studentCodeTxt.Clear();
            firstNameTxt.Clear();
            middleNameTxt.Clear();
            lastNameTxt.Clear();
            phoneTxt.Clear();
        }

        private void ResetButtons()
        {
            action = "";
            addStudentBtn.Text = "Add";
            editStudentBtn.Text = "Edit";
            deleteStudentBtn.Text = "Delete";
            
            addStudentBtn.Enabled = true;
            editStudentBtn.Enabled = true;
            deleteStudentBtn.Enabled = true;

            addStudentBtn.BackColor = Color.LightGreen;
            editStudentBtn.BackColor = Color.Blue;
            deleteStudentBtn.BackColor = Color.LightCoral;
        }
    }
}
