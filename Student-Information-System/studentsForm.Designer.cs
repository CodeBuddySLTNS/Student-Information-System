namespace Student_Information_System
{
    partial class studentsForm
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
            lastNameTxt = new TextBox();
            middleNameTxt = new TextBox();
            lastNameLabel = new Label();
            firstNameTxt = new TextBox();
            middleNameLabel = new Label();
            firstNameLabel = new Label();
            groupBox2 = new GroupBox();
            deleteStudentBtn = new Button();
            editStudentBtn = new Button();
            addStudentBtn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            dataGridView1 = new DataGridView();
            cancelBtn = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lastNameTxt);
            groupBox1.Controls.Add(middleNameTxt);
            groupBox1.Controls.Add(lastNameLabel);
            groupBox1.Controls.Add(firstNameTxt);
            groupBox1.Controls.Add(middleNameLabel);
            groupBox1.Controls.Add(firstNameLabel);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(495, 180);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // lastNameTxt
            // 
            lastNameTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lastNameTxt.Location = new Point(6, 146);
            lastNameTxt.Name = "lastNameTxt";
            lastNameTxt.Size = new Size(483, 23);
            lastNameTxt.TabIndex = 5;
            // 
            // middleNameTxt
            // 
            middleNameTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            middleNameTxt.Location = new Point(6, 94);
            middleNameTxt.Name = "middleNameTxt";
            middleNameTxt.Size = new Size(483, 23);
            middleNameTxt.TabIndex = 5;
            // 
            // lastNameLabel
            // 
            lastNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lastNameLabel.Location = new Point(6, 120);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(483, 23);
            lastNameLabel.TabIndex = 0;
            lastNameLabel.Text = "Last Name";
            // 
            // firstNameTxt
            // 
            firstNameTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            firstNameTxt.Location = new Point(6, 40);
            firstNameTxt.Name = "firstNameTxt";
            firstNameTxt.Size = new Size(483, 23);
            firstNameTxt.TabIndex = 5;
            // 
            // middleNameLabel
            // 
            middleNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            middleNameLabel.Location = new Point(6, 68);
            middleNameLabel.Name = "middleNameLabel";
            middleNameLabel.Size = new Size(483, 23);
            middleNameLabel.TabIndex = 0;
            middleNameLabel.Text = "Middle Name";
            // 
            // firstNameLabel
            // 
            firstNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            firstNameLabel.Location = new Point(6, 19);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(483, 29);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "First Name";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(cancelBtn);
            groupBox2.Controls.Add(deleteStudentBtn);
            groupBox2.Controls.Add(editStudentBtn);
            groupBox2.Controls.Add(addStudentBtn);
            groupBox2.Location = new Point(529, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(302, 169);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
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
            editStudentBtn.BackColor = Color.Blue;
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
            tableLayoutPanel1.Location = new Point(40, 38);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(834, 186);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 242);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(834, 227);
            dataGridView1.TabIndex = 4;
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
            // studentsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 498);
            Controls.Add(dataGridView1);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(756, 506);
            Name = "studentsForm";
            Text = "Users Form";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label firstNameLabel;
        private TextBox firstNameTxt;
        private TextBox middleNameTxt;
        private Label middleNameLabel;
        private TextBox lastNameTxt;
        private Label lastNameLabel;
        private Button deleteStudentBtn;
        private Button editStudentBtn;
        private Button addStudentBtn;
        private DataGridView dataGridView1;
        private Button cancelBtn;
    }
}