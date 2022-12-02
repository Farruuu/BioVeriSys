namespace NadraBioVeriSys.Forms
{
	partial class frmAddUser
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblResult = new System.Windows.Forms.Label();
			this.cmbStation = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtDesignation = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.txtConfirmPassword = new System.Windows.Forms.TextBox();
			this.txtNewPassword = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbUserRole = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.White;
			this.groupBox1.Controls.Add(this.cmbUserRole);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.lblResult);
			this.groupBox1.Controls.Add(this.cmbStation);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtEmail);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtDesignation);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.btnSave);
			this.groupBox1.Controls.Add(this.txtConfirmPassword);
			this.groupBox1.Controls.Add(this.txtNewPassword);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Size = new System.Drawing.Size(973, 429);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// lblResult
			// 
			this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblResult.ForeColor = System.Drawing.Color.Red;
			this.lblResult.Location = new System.Drawing.Point(39, 350);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(747, 51);
			this.lblResult.TabIndex = 8;
			this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmbStation
			// 
			this.cmbStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.cmbStation.FormattingEnabled = true;
			this.cmbStation.Items.AddRange(new object[] {
            "Transfer & Record Dept",
            "Land Accusition & Enforcement Dept"});
			this.cmbStation.Location = new System.Drawing.Point(197, 164);
			this.cmbStation.Name = "cmbStation";
			this.cmbStation.Size = new System.Drawing.Size(267, 33);
			this.cmbStation.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(110, 169);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(76, 22);
			this.label6.TabIndex = 10;
			this.label6.Text = "Station :";
			// 
			// txtEmail
			// 
			this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEmail.Location = new System.Drawing.Point(197, 219);
			this.txtEmail.MaxLength = 50;
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(729, 30);
			this.txtEmail.TabIndex = 3;
			this.txtEmail.WordWrap = false;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(122, 223);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 22);
			this.label7.TabIndex = 13;
			this.label7.Text = "Email :";
			// 
			// txtDesignation
			// 
			this.txtDesignation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDesignation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDesignation.Location = new System.Drawing.Point(659, 112);
			this.txtDesignation.MaxLength = 50;
			this.txtDesignation.Name = "txtDesignation";
			this.txtDesignation.Size = new System.Drawing.Size(267, 30);
			this.txtDesignation.TabIndex = 2;
			this.txtDesignation.WordWrap = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(538, 116);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(115, 22);
			this.label5.TabIndex = 11;
			this.label5.Text = "Designation :";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Chocolate;
			this.label3.Location = new System.Drawing.Point(39, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(887, 51);
			this.label3.TabIndex = 0;
			this.label3.Text = "Note: Password must contain atleast 1 number, 1 capital Letter, 1 small letter an" +
    "d length must be greater than 8 characters and less than 15 characters";
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(796, 350);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(130, 51);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtConfirmPassword
			// 
			this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtConfirmPassword.Location = new System.Drawing.Point(659, 271);
			this.txtConfirmPassword.MaxLength = 15;
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			this.txtConfirmPassword.PasswordChar = '*';
			this.txtConfirmPassword.Size = new System.Drawing.Size(267, 30);
			this.txtConfirmPassword.TabIndex = 6;
			this.txtConfirmPassword.WordWrap = false;
			// 
			// txtNewPassword
			// 
			this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNewPassword.Location = new System.Drawing.Point(197, 271);
			this.txtNewPassword.MaxLength = 15;
			this.txtNewPassword.Name = "txtNewPassword";
			this.txtNewPassword.PasswordChar = '*';
			this.txtNewPassword.Size = new System.Drawing.Size(267, 30);
			this.txtNewPassword.TabIndex = 5;
			this.txtNewPassword.WordWrap = false;
			// 
			// txtName
			// 
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtName.Location = new System.Drawing.Point(197, 112);
			this.txtName.MaxLength = 50;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(267, 30);
			this.txtName.TabIndex = 1;
			this.txtName.WordWrap = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(487, 275);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(166, 22);
			this.label4.TabIndex = 9;
			this.label4.Text = "Confirm Password :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(39, 275);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(147, 22);
			this.label2.TabIndex = 12;
			this.label2.Text = "Enter Password :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(119, 116);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 22);
			this.label1.TabIndex = 14;
			this.label1.Text = "Name :";
			// 
			// cmbUserRole
			// 
			this.cmbUserRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.cmbUserRole.FormattingEnabled = true;
			this.cmbUserRole.Items.AddRange(new object[] {
            "Admin",
            "Verification Officer"});
			this.cmbUserRole.Location = new System.Drawing.Point(659, 164);
			this.cmbUserRole.Name = "cmbUserRole";
			this.cmbUserRole.Size = new System.Drawing.Size(267, 33);
			this.cmbUserRole.TabIndex = 15;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(553, 169);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 22);
			this.label8.TabIndex = 16;
			this.label8.Text = "User Role :";
			// 
			// frmAddUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(973, 429);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmAddUser";
			this.Text = "Add User";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox txtConfirmPassword;
		private System.Windows.Forms.TextBox txtNewPassword;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbStation;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtDesignation;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.ComboBox cmbUserRole;
		private System.Windows.Forms.Label label8;
	}
}