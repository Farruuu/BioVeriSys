using NadraBioVeriSys.Class;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NadraBioVeriSys.Forms
{
	public partial class frmActivityReport : Form
	{
		public frmActivityReport()
		{
			InitializeComponent();
		}

		private void frmActivityReport_Load(object sender, EventArgs e)
		{
			try
			{
				string postData = "UserID=" + new Cryptography().Encrypt(Shared.LoggedInUser.ID.ToString()) + "&AccessToken=" + new Cryptography().Encrypt(Shared.LoggedInUser.AccessToken);
				string URL = Shared.API_URL + @"UsersAPI/GetAllUsersList?" + postData;

				var client = new RestClient(URL);
				var request = new RestRequest(URL, Method.Get);
				RestResponse response = client.Execute(request);

				if (!response.IsSuccessStatusCode)
				{
					MessageBox.Show(response.ErrorMessage, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				List<Users> users = JsonConvert.DeserializeObject<List<Users>>(response.Content);

				cmbUsers.Items.Clear();
				cmbUsers.DataSource = users;

				cmbUsers.DisplayMember = "Name";
				cmbUsers.ValueMember = "ID";
				cmbUsers.SelectedIndex = -1;
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (cmbUsers.SelectedIndex <= -1)
				{
					MessageBox.Show("Please select any User to Generate Report!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					cmbUsers.Focus();
					return;
				}

				string URL = Shared.API_URL + @"CustomersAPI/UserWiseActivityReport";

				var client = new RestClient(URL);
				var request = new RestRequest(URL, Method.Post);

				request.AlwaysMultipartFormData = true;
				request.AddParameter("UserID", new Cryptography().Encrypt(Shared.LoggedInUser.ID.ToString()));
				request.AddParameter("AccessToken", new Cryptography().Encrypt(Shared.LoggedInUser.AccessToken));
				request.AddParameter("ReportDate", new Cryptography().Encrypt(new DateTime(dtpReportDate.Value.Year, dtpReportDate.Value.Month, dtpReportDate.Value.Day, 0, 0, 0).ToString()));
				request.AddParameter("ReportUser", new Cryptography().Encrypt(cmbUsers.SelectedValue.ToString()));

				RestResponse response = client.Execute(request);

				if (!response.IsSuccessStatusCode)
				{
					MessageBox.Show(response.ErrorMessage, "Error");
					return;
				}
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
	}
}
