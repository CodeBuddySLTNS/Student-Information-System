namespace Student_Information_System
{
    public partial class loginForm : Form
    {
        string username;
        string password;

        MainForm dashboard = new MainForm();

        public loginForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit the system?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            password = txtPassword.Text;

            if (username == "" || password == "")
            {
                if (username == "" && password == "")
                {
                    MessageBox.Show("Username and Password is required.", "Mandatory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (username == "")
                {
                    MessageBox.Show("Username is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (password == "")
                {
                    MessageBox.Show("Password is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    bool isValid = Database.ValidateUserCredentials(username, password);
                    if (isValid)
                    {
                        MessageBox.Show("You are now logged in.", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        dashboard.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect credentials.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        
    }
}
