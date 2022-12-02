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
	public partial class frmUsersList : Form
	{
		public frmUsersList()
		{
			InitializeComponent();
		}

		private void frmUsersList_Load(object sender, EventArgs e)
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
					MessageBox.Show("", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				List<Users> users = JsonConvert.DeserializeObject<List<Users>>(response.Content);

				grdUsersList.AutoGenerateColumns = false;
			
				grdUsersList.Columns.Add("UserName", "Name");
				grdUsersList.Columns.Add("Designation", "Designation");
				grdUsersList.Columns.Add("Email", "Email");
				grdUsersList.Columns.Add("UserStatus", "Status");

				grdUsersList.Columns["UserName"].DataPropertyName = "Name";
				grdUsersList.Columns["Designation"].DataPropertyName = "Designation";
				grdUsersList.Columns["Email"].DataPropertyName = "Email";
				grdUsersList.Columns["UserStatus"].DataPropertyName = "UserStatus";
				grdUsersList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

				grdUsersList.DataSource = users;
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, "Error!"); }
		}
	}
}
