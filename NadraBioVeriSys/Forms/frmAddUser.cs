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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NadraBioVeriSys.Forms
{
	public partial class frmAddUser : Form
	{
		public frmAddUser()
		{
			InitializeComponent();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				Regex rgx = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$");

				if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text))
				{
					lblResult.Text = "Password & confirm Password Doesn't match. Please try again!";
					lblResult.ForeColor = Color.Red;
					txtNewPassword.Focus();
					return;
				}
				if (!rgx.IsMatch(txtNewPassword.Text))
				{
					lblResult.Text = "New Password does't meet the Password Policy requirements. New Password must contain atleast 1 number, 1 capital Letter, 1 small letter and length must be greater than 8 characters and less than 15 characters. Please try again!";
					lblResult.ForeColor = Color.Red;
					txtNewPassword.Focus();
					return;
				}
				if (txtNewPassword.Text.Contains(" "))
				{
					lblResult.Text = "Spaces not allowed in Password. Please try again!";
					lblResult.ForeColor = Color.Red;
					txtNewPassword.Focus();
					return;
				}

				Users objuser = new Users()
				{
					Name = txtName.Text,
					Designation = txtDesignation.Text,
					Email = txtEmail.Text,
					StationID = cmbStation.SelectedIndex + 1,
					UserRole = cmbUserRole.SelectedIndex + 1,
					Password = txtNewPassword.Text,
				};

				string URL = Shared.API_URL + @"UsersAPI/AddNewUser";

				var client = new RestClient(URL);
				var request = new RestRequest(URL, Method.Post);

				request.AlwaysMultipartFormData = true;
				request.AddParameter("UserID", new Cryptography().Encrypt(Shared.LoggedInUser.ID.ToString()));
				request.AddParameter("AccessToken", new Cryptography().Encrypt(Shared.LoggedInUser.AccessToken));
				request.AddParameter("User", new Cryptography().Encrypt(JsonConvert.SerializeObject(objuser)));
				request.AddParameter("CreatedBy", new Cryptography().Encrypt(Shared.LoggedInUser.ID.ToString()));

				RestResponse response = client.Execute(request);

				if (!response.IsSuccessStatusCode)
				{
					lblResult.Text = response.StatusDescription;
					return;
				}

				lblResult.Text = "user Account Created Successfully!";
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK); }
		}
	}
}
