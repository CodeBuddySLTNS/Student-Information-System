using MySql.Data.MySqlClient;
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
    public partial class enrollmentForm : Form
    {
        private DataTable originalData;
        private int selectedStudentId = -1;
        private int selectedId = -1;
        private bool isEnroll = false;

        public enrollmentForm()
        {
            InitializeComponent();
            LoadStudentData();
            SetupDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadStudentData()
        {
            try
            {
                originalData = Database.GetEnrollments();
                dataGridView1.DataSource = originalData;
                //dataGridView1.Columns["departmentId"].Visible = false;

                originalData = Database.GetStudents();
                dataGridView2.DataSource = originalData;
                dataGridView2.Columns["id"].Visible = false;
                dataGridView2.Columns["studentCode"].Visible = false;
                dataGridView2.Columns["phone"].Visible = false;

                DataTable departmentsData = Database.GetSchoolYears();
                departmentCmb.DataSource = departmentsData;
                departmentCmb.DisplayMember = "name";
                departmentCmb.ValueMember = "id";

                schoolYearCmb.DataSource = departmentsData;
                schoolYearCmb.DisplayMember = "name";
                schoolYearCmb.ValueMember = "id";

                DataTable courses = Database.GetCourses();
                courseCmb.DataSource = courses;
                courseCmb.DisplayMember = "courseName";
                courseCmb.ValueMember = "id";

                DataTable semester = Database.ExecuteQuery("select * from semesters", []);
                semesterCmb.DataSource = courses;
                semesterCmb.DisplayMember = "semester";
                semesterCmb.ValueMember = "id";

                DataTable years = Database.ExecuteQuery("select * from yearLevels", []);
                yearLevelCmb.DataSource = years;
                yearLevelCmb.DisplayMember = "year";
                yearLevelCmb.ValueMember = "id";

                DataTable classes = Database.GetClasses();
                classCmb.DataSource = classes;
                classCmb.DisplayMember = "name";
                classCmb.ValueMember = "id";
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

            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;

            // Make columns fill available width
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void toggleFormBtn_Click(object sender, EventArgs e)
        {
            if (isEnroll)
            {
                dataGridView1.Visible = true;
                enForm.Visible = false;
                toggleFormBtn.Text = "Student Enrollment Form";
            }
            else
            {
                dataGridView1.Visible = false;
                enForm.Visible = true;
                toggleFormBtn.Text = "View Enrolled Students";
            }

            isEnroll = !isEnroll;
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                selectedId = Convert.ToInt32(selectedRow.Cells["id"].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                int courseId = courseCmb.SelectedValue != null && int.TryParse(courseCmb.SelectedValue.ToString(), out int id) ? id : 0;
                int semesterId = semesterCmb.SelectedValue != null && int.TryParse(semesterCmb.SelectedValue.ToString(), out int id2) ? id2 : 0;
                int yearLevelId = yearLevelCmb.SelectedValue != null && int.TryParse(yearLevelCmb.SelectedValue.ToString(), out int id3) ? id3 : 0;
                int schoolYearId = schoolYearCmb.SelectedValue != null && int.TryParse(schoolYearCmb.SelectedValue.ToString(), out int id4) ? id4 : 0;
                int classId = classCmb.SelectedValue != null && int.TryParse(classCmb.SelectedValue.ToString(), out int id5) ? id5 : 0;

                using var conn = Database.OpenConnection();
                using var cmd = new MySqlCommand("INSERT INTO enrollment (studentId, courseId, semesterId, yearLevelId, schoolYearId) " +
                "VALUES (@studentId, @courseId, @semesterId, @yearLevelId, @schoolYearId)", conn);

                cmd.Parameters.AddRange(new MySqlParameter[]
                {
                    new MySqlParameter("@studentId", selectedId),
                    new MySqlParameter("@courseId", courseId),
                    new MySqlParameter("@semesterId", semesterId),
                    new MySqlParameter("@yearLevelId", yearLevelId),
                    new MySqlParameter("@schoolYearId", schoolYearId)
                });

                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT LAST_INSERT_ID();";
                long lastId = Convert.ToInt64(cmd.ExecuteScalar());

                int result = Database.ExecuteNonQuery($"INSERT INTO enrollmentDetails(enrollmentId, classId) VALUES ({lastId}, {classId})", []);

                if (result > 0)
                {
                    MessageBox.Show("Student enrolled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudentData();
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

        private void resetForm()
        {

        }
    }
}
