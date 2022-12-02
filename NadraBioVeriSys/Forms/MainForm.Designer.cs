
namespace NadraBioVeriSys
{
    partial class MainForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.biometricVerificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aDMINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.allUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rEportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dailyActivityUserWiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.biometricVerificationToolStripMenuItem,
            this.aDMINToolStripMenuItem,
            this.rEportsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(1924, 36);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(92, 32);
			this.fileToolStripMenuItem.Text = "System";
			// 
			// changePasswordToolStripMenuItem
			// 
			this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
			this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(258, 32);
			this.changePasswordToolStripMenuItem.Text = "Change Password";
			this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
			// 
			// logoutToolStripMenuItem
			// 
			this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
			this.logoutToolStripMenuItem.Size = new System.Drawing.Size(258, 32);
			this.logoutToolStripMenuItem.Text = "Logout";
			this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(258, 32);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// biometricVerificationToolStripMenuItem
			// 
			this.biometricVerificationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.biometricVerificationToolStripMenuItem.Name = "biometricVerificationToolStripMenuItem";
			this.biometricVerificationToolStripMenuItem.Size = new System.Drawing.Size(220, 32);
			this.biometricVerificationToolStripMenuItem.Text = "Biometric Verification";
			this.biometricVerificationToolStripMenuItem.Click += new System.EventHandler(this.biometricVerificationToolStripMenuItem_Click);
			// 
			// aDMINToolStripMenuItem
			// 
			this.aDMINToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allUsersToolStripMenuItem,
            this.addUserToolStripMenuItem});
			this.aDMINToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
			this.aDMINToolStripMenuItem.Name = "aDMINToolStripMenuItem";
			this.aDMINToolStripMenuItem.Size = new System.Drawing.Size(160, 32);
			this.aDMINToolStripMenuItem.Text = "Administration";
			// 
			// allUsersToolStripMenuItem
			// 
			this.allUsersToolStripMenuItem.Name = "allUsersToolStripMenuItem";
			this.allUsersToolStripMenuItem.Size = new System.Drawing.Size(253, 32);
			this.allUsersToolStripMenuItem.Text = "Users List";
			this.allUsersToolStripMenuItem.Click += new System.EventHandler(this.allUsersToolStripMenuItem_Click);
			// 
			// addUserToolStripMenuItem
			// 
			this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
			this.addUserToolStripMenuItem.Size = new System.Drawing.Size(253, 32);
			this.addUserToolStripMenuItem.Text = "Add User";
			this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
			// 
			// rEportsToolStripMenuItem
			// 
			this.rEportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyActivityUserWiseToolStripMenuItem});
			this.rEportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
			this.rEportsToolStripMenuItem.Name = "rEportsToolStripMenuItem";
			this.rEportsToolStripMenuItem.Size = new System.Drawing.Size(96, 32);
			this.rEportsToolStripMenuItem.Text = "Reports";
			// 
			// dailyActivityUserWiseToolStripMenuItem
			// 
			this.dailyActivityUserWiseToolStripMenuItem.Name = "dailyActivityUserWiseToolStripMenuItem";
			this.dailyActivityUserWiseToolStripMenuItem.Size = new System.Drawing.Size(311, 32);
			this.dailyActivityUserWiseToolStripMenuItem.Text = "Daily Activity User Wise";
			this.dailyActivityUserWiseToolStripMenuItem.Click += new System.EventHandler(this.dailyActivityUserWiseToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1924, 908);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.IsMdiContainer = true;
			this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.Name = "MainForm";
			this.Text = "RUDA - Biometric Verficiation System!";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem biometricVerificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aDMINToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rEportsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dailyActivityUserWiseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem allUsersToolStripMenuItem;
	}
}



