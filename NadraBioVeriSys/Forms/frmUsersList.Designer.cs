namespace NadraBioVeriSys.Forms
{
	partial class frmUsersList
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
			this.grdUsersList = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.grdUsersList)).BeginInit();
			this.SuspendLayout();
			// 
			// grdUsersList
			// 
			this.grdUsersList.AllowUserToAddRows = false;
			this.grdUsersList.AllowUserToDeleteRows = false;
			this.grdUsersList.AllowUserToOrderColumns = true;
			this.grdUsersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdUsersList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdUsersList.Location = new System.Drawing.Point(0, 0);
			this.grdUsersList.Name = "grdUsersList";
			this.grdUsersList.ReadOnly = true;
			this.grdUsersList.RowHeadersWidth = 51;
			this.grdUsersList.RowTemplate.Height = 24;
			this.grdUsersList.Size = new System.Drawing.Size(931, 400);
			this.grdUsersList.TabIndex = 0;
			// 
			// frmUsersList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(931, 400);
			this.Controls.Add(this.grdUsersList);
			this.Name = "frmUsersList";
			this.Text = "Users List";
			this.Load += new System.EventHandler(this.frmUsersList_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdUsersList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView grdUsersList;
	}
}