namespace Student_Information_System
{
    partial class enrollmentForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            toggleFormBtn = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            departmentCmb = new ComboBox();
            dataGridView1 = new DataGridView();
            enForm = new GroupBox();
            button1 = new Button();
            searchNameTxt = new TextBox();
            label6 = new Label();
            groupBox4 = new GroupBox();
            label7 = new Label();
            classCmb = new ComboBox();
            label5 = new Label();
            schoolYearCmb = new ComboBox();
            label4 = new Label();
            yearLevelCmb = new ComboBox();
            label3 = new Label();
            semesterCmb = new ComboBox();
            label2 = new Label();
            courseCmb = new ComboBox();
            dataGridView2 = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            enForm.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBox2, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(776, 70);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(toggleFormBtn);
            groupBox2.Location = new Point(391, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(382, 64);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            // 
            // toggleFormBtn
            // 
            toggleFormBtn.Location = new Point(202, 19);
            toggleFormBtn.Name = "toggleFormBtn";
            toggleFormBtn.Size = new Size(174, 35);
            toggleFormBtn.TabIndex = 3;
            toggleFormBtn.Text = "Student Enrollment Form";
            toggleFormBtn.UseVisualStyleBackColor = true;
            toggleFormBtn.Click += toggleFormBtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(departmentCmb);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(382, 57);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 22);
            label1.Name = "label1";
            label1.Size = new Size(94, 19);
            label1.TabIndex = 2;
            label1.Text = "School Year:";
            // 
            // departmentCmb
            // 
            departmentCmb.FormattingEnabled = true;
            departmentCmb.Location = new Point(106, 20);
            departmentCmb.Name = "departmentCmb";
            departmentCmb.Size = new Size(270, 23);
            departmentCmb.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 78);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 360);
            dataGridView1.TabIndex = 2;
            dataGridView1.Visible = false;
            // 
            // enForm
            // 
            enForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            enForm.Controls.Add(button1);
            enForm.Controls.Add(searchNameTxt);
            enForm.Controls.Add(label6);
            enForm.Controls.Add(groupBox4);
            enForm.Controls.Add(dataGridView2);
            enForm.Location = new Point(12, 78);
            enForm.Name = "enForm";
            enForm.Size = new Size(849, 417);
            enForm.TabIndex = 3;
            enForm.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.Location = new Point(756, 20);
            button1.Name = "button1";
            button1.Size = new Size(80, 35);
            button1.TabIndex = 4;
            button1.Text = "Enroll";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // searchNameTxt
            // 
            searchNameTxt.Location = new Point(9, 37);
            searchNameTxt.Name = "searchNameTxt";
            searchNameTxt.Size = new Size(355, 23);
            searchNameTxt.TabIndex = 10;
            // 
            // label6
            // 
            label6.Location = new Point(6, 19);
            label6.Name = "label6";
            label6.Size = new Size(276, 23);
            label6.TabIndex = 9;
            label6.Text = "Search student name";
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(classCmb);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(schoolYearCmb);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(yearLevelCmb);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(semesterCmb);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(courseCmb);
            groupBox4.Location = new Point(541, 61);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(295, 334);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            // 
            // label7
            // 
            label7.Location = new Point(6, 265);
            label7.Name = "label7";
            label7.Size = new Size(276, 23);
            label7.TabIndex = 10;
            label7.Text = "Class";
            // 
            // classCmb
            // 
            classCmb.FormattingEnabled = true;
            classCmb.Location = new Point(6, 288);
            classCmb.Name = "classCmb";
            classCmb.Size = new Size(276, 23);
            classCmb.TabIndex = 9;
            // 
            // label5
            // 
            label5.Location = new Point(6, 203);
            label5.Name = "label5";
            label5.Size = new Size(276, 23);
            label5.TabIndex = 8;
            label5.Text = "School Year";
            // 
            // schoolYearCmb
            // 
            schoolYearCmb.FormattingEnabled = true;
            schoolYearCmb.Location = new Point(6, 226);
            schoolYearCmb.Name = "schoolYearCmb";
            schoolYearCmb.Size = new Size(276, 23);
            schoolYearCmb.TabIndex = 7;
            // 
            // label4
            // 
            label4.Location = new Point(6, 141);
            label4.Name = "label4";
            label4.Size = new Size(276, 23);
            label4.TabIndex = 6;
            label4.Text = "Year Level";
            // 
            // yearLevelCmb
            // 
            yearLevelCmb.FormattingEnabled = true;
            yearLevelCmb.Location = new Point(6, 164);
            yearLevelCmb.Name = "yearLevelCmb";
            yearLevelCmb.Size = new Size(276, 23);
            yearLevelCmb.TabIndex = 5;
            // 
            // label3
            // 
            label3.Location = new Point(6, 79);
            label3.Name = "label3";
            label3.Size = new Size(276, 23);
            label3.TabIndex = 4;
            label3.Text = "Semester";
            // 
            // semesterCmb
            // 
            semesterCmb.FormattingEnabled = true;
            semesterCmb.Location = new Point(6, 102);
            semesterCmb.Name = "semesterCmb";
            semesterCmb.Size = new Size(276, 23);
            semesterCmb.TabIndex = 3;
            // 
            // label2
            // 
            label2.Location = new Point(6, 18);
            label2.Name = "label2";
            label2.Size = new Size(276, 23);
            label2.TabIndex = 2;
            label2.Text = "Course";
            // 
            // courseCmb
            // 
            courseCmb.FormattingEnabled = true;
            courseCmb.Location = new Point(6, 41);
            courseCmb.Name = "courseCmb";
            courseCmb.Size = new Size(276, 23);
            courseCmb.TabIndex = 1;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(9, 69);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(514, 326);
            dataGridView2.TabIndex = 0;
            dataGridView2.SelectionChanged += dataGridView2_SelectionChanged;
            // 
            // enrollmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 507);
            Controls.Add(enForm);
            Controls.Add(dataGridView1);
            Controls.Add(tableLayoutPanel1);
            Name = "enrollmentForm";
            Text = "Enrolled Students";
            tableLayoutPanel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            enForm.ResumeLayout(false);
            enForm.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox departmentCmb;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private Button toggleFormBtn;
        private GroupBox enForm;
        private GroupBox groupBox4;
        private Label label2;
        private ComboBox courseCmb;
        private DataGridView dataGridView2;
        private TextBox searchNameTxt;
        private Label label6;
        private Label label5;
        private ComboBox schoolYearCmb;
        private Label label4;
        private ComboBox yearLevelCmb;
        private Label label3;
        private ComboBox semesterCmb;
        private Label label7;
        private ComboBox classCmb;
        private Button button1;
    }
}