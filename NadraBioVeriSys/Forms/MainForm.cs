using NadraBioVeriSys.Class;
using NadraBioVeriSys.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NadraBioVeriSys
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			if (Shared.LoggedInUser.UserRole == 1)
			{
				aDMINToolStripMenuItem.Visible = true;
				rEportsToolStripMenuItem.Visible = true;
			}
			else
			{
				aDMINToolStripMenuItem.Visible = false;
				rEportsToolStripMenuItem.Visible = false;
			}
		}

		#region Administration Section

		private void allUsersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Application.OpenForms.OfType<frmUsersList>().FirstOrDefault();
			if (form == null)
			{
				form = new frmUsersList();
				form.MdiParent = this;
			}
			form.Show();
		}

		private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Application.OpenForms.OfType<frmAddUser>().FirstOrDefault();
			if (form == null)
			{
				form = new frmAddUser();
				form.MdiParent = this;
			}
			form.Show();
		}

		#endregion

		#region Customer Verification Section

		private void biometricVerificationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Application.OpenForms.OfType<Verification>().FirstOrDefault();
			if (form == null)
			{
				form = new Verification();
				form.MdiParent = this;
			}
			form.Show();
		}

		#endregion

		#region System Section

		private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Application.OpenForms.OfType<ChangePassword>().FirstOrDefault();
			if (form == null)
			{
				form = new ChangePassword();
				form.MdiParent = this;
			}
			form.Show();
		}

		private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Shared.LoggedInUser = null;
			frmLogin login = new frmLogin();
			this.Close();
			login.Show();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}



		#endregion

		#region Reports Section

		private void dailyActivityUserWiseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = Application.OpenForms.OfType<frmActivityReport>().FirstOrDefault();
			if (form == null)
			{
				form = new frmActivityReport();
				form.MdiParent = this;
			}
			form.Show();
		}

		#endregion


	}
}
