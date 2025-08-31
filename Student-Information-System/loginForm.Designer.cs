namespace Student_Information_System
{
    partial class loginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            lblUsername = new Label();
            label1 = new Label();
            txtPassword = new TextBox();
            btnCancel = new Button();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(99, 88);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(207, 23);
            txtUsername.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(99, 70);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 124);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 3;
            label1.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(99, 142);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(207, 23);
            txtPassword.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(99, 183);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(104, 32);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(209, 183);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(97, 32);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 315);
            Controls.Add(btnLogin);
            Controls.Add(btnCancel);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "loginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private Label lblUsername;
        private Label label1;
        private TextBox txtPassword;
        private Button btnCancel;
        private Button btnLogin;
    }
}
