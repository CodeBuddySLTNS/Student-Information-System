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
    public partial class coursesForm : Form
    {
        private string action = "";
        private DataTable originalData;
        private int selectedId = -1;

        public coursesForm()
        {
            InitializeComponent();
            LoadStudentData();
            SetupDataGridView();
        }

        private void LoadStudentData()
        {
            try
            {
                originalData = Database.GetCourses();
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

            // Make columns fill available width
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetInputsEnabled(bool enabled)
        {
            courseCodeTxt.Enabled = enabled;
            courseNameTxt.Enabled = enabled;
            unitsTxt.Enabled = enabled;
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
                        string courseCode = courseCodeTxt.Text.Trim();
                        string courseName = courseNameTxt.Text.Trim();
                        int units = int.Parse(unitsTxt.Text);

                        int result = Database.AddCourse(courseCode, courseName, units);
                        if (result > 0)
                        {
                            MessageBox.Show("Course added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadStudentData();
                            ResetButtons();
                            ClearFields();
                            SetActionState(false);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void editStudentBtn_Click(object sender, EventArgs e)
        {
            if (action == "")
            {
                if (selectedId == -1)
                {
                    MessageBox.Show("Please select a course to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        string courseCode = courseCodeTxt.Text.Trim();
                        string courseName = courseNameTxt.Text.Trim();
                        int units = int.Parse(unitsTxt.Text);

                        int result = Database.UpdateCourse(selectedId, courseCode, courseName, units);
                        if (result > 0)
                        {
                            MessageBox.Show("Course updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadStudentData();
                            ResetButtons();
                            ClearFields();
                            SetActionState(false);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void deleteStudentBtn_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select a course to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this course? This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int deleteResult = Database.DeleteCourse(selectedId);
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudentData();
                        ClearFields();
                        selectedId = -1;
                        SetActionState(false);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                selectedId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                courseCodeTxt.Text = selectedRow.Cells["courseCode"].Value.ToString();
                courseNameTxt.Text = selectedRow.Cells["courseName"].Value.ToString();
                unitsTxt.Text = selectedRow.Cells["units"].Value.ToString();
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
                        string courseCode = row["courseCode"].ToString().ToLower();
                        string courseName = row["courseName"].ToString().ToLower();

                        if (courseCode.Contains(searchText) ||
                            courseName.Contains(searchText))
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
            if (string.IsNullOrWhiteSpace(courseCodeTxt.Text))
            {
                MessageBox.Show("Course Code is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                courseCodeTxt.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(courseNameTxt.Text))
            {
                MessageBox.Show("Course Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                courseNameTxt.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(unitsTxt.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                unitsTxt.Focus();
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            courseCodeTxt.Clear();
            courseNameTxt.Clear();
            unitsTxt.Clear();
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
            editStudentBtn.BackColor = Color.PowderBlue;
            deleteStudentBtn.BackColor = Color.LightCoral;
        }
    }
}
