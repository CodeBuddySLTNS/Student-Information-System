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
        string action = "";
        public studentsForm()
        {
            InitializeComponent();
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
            }
            else
            {
                action = "";
                addStudentBtn.Text = "Add";
                editStudentBtn.Enabled = true;
                deleteStudentBtn.Enabled = true;
                editStudentBtn.BackColor = Color.Blue;
                deleteStudentBtn.BackColor = Color.LightCoral;
                MessageBox.Show("added", "Success!");
            }
        }

        private void editStudentBtn_Click(object sender, EventArgs e)
        {
            if (action == "")
            {
                action = "Edit";
                editStudentBtn.Text = "Save";
                addStudentBtn.Enabled = false;
                deleteStudentBtn.Enabled = false;
                addStudentBtn.BackColor = Color.Silver;
                editStudentBtn.BackColor = Color.LightGreen;
                deleteStudentBtn.BackColor = Color.Silver;
            }
            else
            {
                action = "";
                editStudentBtn.Text = "Edit";
                addStudentBtn.Enabled = true;
                deleteStudentBtn.Enabled = true;
                addStudentBtn.BackColor = Color.LightGreen;
                editStudentBtn.BackColor = Color.Blue;
                deleteStudentBtn.BackColor = Color.LightCoral;
                MessageBox.Show("edited", "Success!");
            }
        }

        private void deleteStudentBtn_Click(object sender, EventArgs e)
        {
            if (action == "")
            {
                action = "Delete";
                deleteStudentBtn.Text = "Save";
                addStudentBtn.Enabled = false;
                editStudentBtn.Enabled = false;
                addStudentBtn.BackColor = Color.Silver;
                deleteStudentBtn.BackColor = Color.LightGreen;
                editStudentBtn.BackColor = Color.Silver;
            }
            else
            {
                action = "";
                deleteStudentBtn.Text = "Delete";
                addStudentBtn.Enabled = true;
                editStudentBtn.Enabled = true;
                addStudentBtn.BackColor = Color.LightGreen;
                editStudentBtn.BackColor = Color.Blue;
                deleteStudentBtn.BackColor = Color.LightCoral;
                MessageBox.Show("deleted", "Success!");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
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
