namespace Student_Information_System
{
    partial class dashboardForm
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
            newToolStripMenuItem = new ToolStripMenuItem();
            userToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            label1 = new Label();
            bgLogo = new PictureBox();
            viewStudentsBtn = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bgLogo).BeginInit();
            SuspendLayout();
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { userToolStripMenuItem });
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(43, 20);
            newToolStripMenuItem.Text = "New";
            // 
            // userToolStripMenuItem
            // 
            userToolStripMenuItem.Name = "userToolStripMenuItem";
            userToolStripMenuItem.Size = new Size(115, 22);
            userToolStripMenuItem.Text = "Student";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { newToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(990, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoEllipsis = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("MV Boli", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 246);
            label1.Name = "label1";
            label1.Size = new Size(990, 54);
            label1.TabIndex = 2;
            label1.Text = "Welcome Administrator";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // bgLogo
            // 
            bgLogo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            bgLogo.BackColor = Color.Transparent;
            bgLogo.BackgroundImageLayout = ImageLayout.None;
            bgLogo.Image = Properties.Resources.paclogo;
            bgLogo.Location = new Point(0, 36);
            bgLogo.Name = "bgLogo";
            bgLogo.Size = new Size(990, 216);
            bgLogo.SizeMode = PictureBoxSizeMode.Zoom;
            bgLogo.TabIndex = 3;
            bgLogo.TabStop = false;
            // 
            // viewStudentsBtn
            // 
            viewStudentsBtn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            viewStudentsBtn.BackColor = SystemColors.GradientActiveCaption;
            viewStudentsBtn.Font = new Font("Segoe UI", 11.25F);
            viewStudentsBtn.Location = new Point(329, 321);
            viewStudentsBtn.Name = "viewStudentsBtn";
            viewStudentsBtn.Size = new Size(332, 45);
            viewStudentsBtn.TabIndex = 4;
            viewStudentsBtn.Text = "View Students";
            viewStudentsBtn.UseVisualStyleBackColor = false;
            viewStudentsBtn.Click += viewStudentsBtn_Click;
            // 
            // dashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 468);
            Controls.Add(viewStudentsBtn);
            Controls.Add(bgLogo);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MinimumSize = new Size(1006, 507);
            Name = "dashboardForm";
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bgLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem userToolStripMenuItem;
        private MenuStrip menuStrip1;
        private Label label1;
        private PictureBox bgLogo;
        private Button viewStudentsBtn;
    }
}