namespace NadraBioVeriSys.Forms
{
	partial class frmActivityReport
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
			this.cmbUsers = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbUsers
			// 
			this.cmbUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.cmbUsers.FormattingEnabled = true;
			this.cmbUsers.Items.AddRange(new object[] {
            "Transfer & Record Dept",
            "Land Accusition & Enforcement Dept"});
			this.cmbUsers.Location = new System.Drawing.Point(167, 97);
			this.cmbUsers.Name = "cmbUsers";
			this.cmbUsers.Size = new System.Drawing.Size(364, 33);
			this.cmbUsers.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(102, 102);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(58, 22);
			this.label6.TabIndex = 12;
			this.label6.Text = "User :";
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(463, 191);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(130, 51);
			this.btnSave.TabIndex = 13;
			this.btnSave.Text = "Generate";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// dtpReportDate
			// 
			this.dtpReportDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.dtpReportDate.Location = new System.Drawing.Point(167, 43);
			this.dtpReportDate.Name = "dtpReportDate";
			this.dtpReportDate.Size = new System.Drawing.Size(364, 30);
			this.dtpReportDate.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(43, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 22);
			this.label1.TabIndex = 15;
			this.label1.Text = "Report Date :";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbUsers);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.dtpReportDate);
			this.groupBox1.Location = new System.Drawing.Point(18, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(574, 173);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Report Filters";
			// 
			// frmActivityReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(610, 254);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnSave);
			this.Name = "frmActivityReport";
			this.Text = "User Wise Activity Report";
			this.Load += new System.EventHandler(this.frmActivityReport_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbUsers;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.DateTimePicker dtpReportDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}