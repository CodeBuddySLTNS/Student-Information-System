namespace Student_Information_System
{
    partial class coursesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            unitsTxt = new TextBox();
            unitsLabel = new Label();
            courseCodeTxt = new TextBox();
            courseCodeLabel = new Label();
            courseNameTxt = new TextBox();
            courseNameLabel = new Label();
            groupBox2 = new GroupBox();
            clearBtn = new Button();
            cancelBtn = new Button();
            deleteStudentBtn = new Button();
            editStudentBtn = new Button();
            addStudentBtn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            dataGridView1 = new DataGridView();
            searchGroupBox = new GroupBox();
            searchTxt = new TextBox();
            searchLabel = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            searchGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(unitsTxt);
            groupBox1.Controls.Add(unitsLabel);
            groupBox1.Controls.Add(courseCodeTxt);
            groupBox1.Controls.Add(courseCodeLabel);
            groupBox1.Controls.Add(courseNameTxt);
            groupBox1.Controls.Add(courseNameLabel);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(495, 192);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // unitsTxt
            // 
            unitsTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            unitsTxt.Location = new Point(7, 133);
            unitsTxt.Name = "unitsTxt";
            unitsTxt.Size = new Size(483, 23);
            unitsTxt.TabIndex = 5;
            // 
            // unitsLabel
            // 
            unitsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            unitsLabel.Location = new Point(4, 112);
            unitsLabel.Name = "unitsLabel";
            unitsLabel.Size = new Size(483, 23);
            unitsLabel.TabIndex = 4;
            unitsLabel.Text = "Units";
            // 
            // courseCodeTxt
            // 
            courseCodeTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            courseCodeTxt.Location = new Point(6, 32);
            courseCodeTxt.Name = "courseCodeTxt";
            courseCodeTxt.Size = new Size(483, 23);
            courseCodeTxt.TabIndex = 1;
            // 
            // courseCodeLabel
            // 
            courseCodeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            courseCodeLabel.Location = new Point(3, 14);
            courseCodeLabel.Name = "courseCodeLabel";
            courseCodeLabel.Size = new Size(483, 23);
            courseCodeLabel.TabIndex = 0;
            courseCodeLabel.Text = "Course Code";
            // 
            // courseNameTxt
            // 
            courseNameTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            courseNameTxt.Location = new Point(6, 84);
            courseNameTxt.Name = "courseNameTxt";
            courseNameTxt.Size = new Size(483, 23);
            courseNameTxt.TabIndex = 3;
            // 
            // courseNameLabel
            // 
            courseNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            courseNameLabel.Location = new Point(3, 61);
            courseNameLabel.Name = "courseNameLabel";
            courseNameLabel.Size = new Size(483, 23);
            courseNameLabel.TabIndex = 0;
            courseNameLabel.Text = "Course Name";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(clearBtn);
            groupBox2.Controls.Add(cancelBtn);
            groupBox2.Controls.Add(deleteStudentBtn);
            groupBox2.Controls.Add(editStudentBtn);
            groupBox2.Controls.Add(addStudentBtn);
            groupBox2.Location = new Point(529, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(302, 192);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            // 
            // clearBtn
            // 
            clearBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            clearBtn.BackColor = Color.Silver;
            clearBtn.Location = new Point(6, 125);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(290, 34);
            clearBtn.TabIndex = 4;
            clearBtn.Text = "Clear";
            clearBtn.UseVisualStyleBackColor = false;
            clearBtn.Click += clearBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cancelBtn.BackColor = Color.Silver;
            cancelBtn.Location = new Point(6, 125);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(290, 34);
            cancelBtn.TabIndex = 3;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // deleteStudentBtn
            // 
            deleteStudentBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            deleteStudentBtn.BackColor = Color.LightCoral;
            deleteStudentBtn.Location = new Point(6, 88);
            deleteStudentBtn.Name = "deleteStudentBtn";
            deleteStudentBtn.Size = new Size(290, 34);
            deleteStudentBtn.TabIndex = 2;
            deleteStudentBtn.Text = "Delete";
            deleteStudentBtn.UseVisualStyleBackColor = false;
            deleteStudentBtn.Click += deleteStudentBtn_Click;
            // 
            // editStudentBtn
            // 
            editStudentBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            editStudentBtn.BackColor = Color.PowderBlue;
            editStudentBtn.Location = new Point(6, 51);
            editStudentBtn.Name = "editStudentBtn";
            editStudentBtn.Size = new Size(290, 34);
            editStudentBtn.TabIndex = 1;
            editStudentBtn.Text = "Edit";
            editStudentBtn.UseVisualStyleBackColor = false;
            editStudentBtn.Click += editStudentBtn_Click;
            // 
            // addStudentBtn
            // 
            addStudentBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            addStudentBtn.BackColor = Color.LightGreen;
            addStudentBtn.Location = new Point(6, 14);
            addStudentBtn.Name = "addStudentBtn";
            addStudentBtn.Size = new Size(290, 34);
            addStudentBtn.TabIndex = 0;
            addStudentBtn.Text = "Add";
            addStudentBtn.UseVisualStyleBackColor = false;
            addStudentBtn.Click += addStudentBtn_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.1211853F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.8788147F));
            tableLayoutPanel1.Controls.Add(groupBox2, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Location = new Point(40, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(834, 198);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 282);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(834, 287);
            dataGridView1.TabIndex = 5;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // searchGroupBox
            // 
            searchGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchGroupBox.Controls.Add(searchTxt);
            searchGroupBox.Controls.Add(searchLabel);
            searchGroupBox.Location = new Point(40, 216);
            searchGroupBox.Name = "searchGroupBox";
            searchGroupBox.Size = new Size(834, 60);
            searchGroupBox.TabIndex = 4;
            searchGroupBox.TabStop = false;
            // 
            // searchTxt
            // 
            searchTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchTxt.Location = new Point(9, 29);
            searchTxt.Name = "searchTxt";
            searchTxt.Size = new Size(816, 23);
            searchTxt.TabIndex = 1;
            searchTxt.TextChanged += searchTxt_TextChanged;
            // 
            // searchLabel
            // 
            searchLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchLabel.Location = new Point(9, 12);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(816, 23);
            searchLabel.TabIndex = 0;
            searchLabel.Text = "Search by Student Code or Name:";
            // 
            // coursesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 580);
            Controls.Add(dataGridView1);
            Controls.Add(searchGroupBox);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(756, 588);
            Name = "coursesForm";
            Text = "Course Management";
            WindowState = FormWindowState.Maximized;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            searchGroupBox.ResumeLayout(false);
            searchGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label courseNameLabel;
        private TextBox courseNameTxt;
        private TextBox courseCodeTxt;
        private Label courseCodeLabel;
        private Button clearBtn;
        private Button deleteStudentBtn;
        private Button editStudentBtn;
        private Button addStudentBtn;
        private GroupBox searchGroupBox;
        private TextBox searchTxt;
        private Label searchLabel;
        private DataGridView dataGridView1;
        private Button cancelBtn;
        private TextBox unitsTxt;
        private Label unitsLabel;
    }
}