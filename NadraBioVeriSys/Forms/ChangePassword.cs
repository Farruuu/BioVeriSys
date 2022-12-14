using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace NadraBioVeriSys.Class
{
	public partial class ChangePassword : Form
	{
		public ChangePassword()
		{
			InitializeComponent();
		}

		private void btnChangePassword_Click(object sender, EventArgs e)
		{
			try
			{
				Regex rgx = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$");

				if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text))
				{
					lblResult.Text = "Password Doesn't match. Please try again!";
					lblResult.ForeColor = Color.Red;
					txtCurrentPassword.Focus();
					return;
				}
				if (!rgx.IsMatch(txtNewPassword.Text))
				{
					lblResult.Text = "New Password does't meet the Password Policy requirements. New Password must contain atleast 1 number, 1 capital Letter, 1 small letter and length must be greater than 8 characters and less than 15 characters. Please try again!";
					lblResult.ForeColor = Color.Red;
					txtCurrentPassword.Focus();
					return;
				}
				if (txtNewPassword.Text.Contains(" "))
				{
					lblResult.Text = "Spaces not allowed in Password. Please try again!";
					lblResult.ForeColor = Color.Red;
					txtCurrentPassword.Focus();
					return;
				}

				string URL = Shared.API_URL + @"UsersAPI/UpdatePassword";

				var client = new RestClient(URL);
				var request = new RestRequest(URL, Method.Post);

				request.AlwaysMultipartFormData = true;
				request.AddParameter("UserID", new Cryptography().Encrypt(Shared.LoggedInUser.ID.ToString()));
				request.AddParameter("AccessToken", new Cryptography().Encrypt(Shared.LoggedInUser.AccessToken));
				request.AddParameter("CurrentPassword", new Cryptography().Encrypt(txtCurrentPassword.Text));
				request.AddParameter("NewPassword", new Cryptography().Encrypt(txtNewPassword.Text));

				RestResponse response = client.Execute(request);


				if (response.IsSuccessStatusCode)
				{
					lblResult.Text = "Password Updated Successfully.";
					lblResult.ForeColor = Color.Green;

					txtCurrentPassword.Clear();
					txtNewPassword.Clear();
					txtConfirmPassword.Clear();
				}
				else
				{
					lblResult.Text = response.ErrorMessage;
					lblResult.ForeColor = Color.Red;

					txtCurrentPassword.Clear();
					txtNewPassword.Clear();
					txtConfirmPassword.Clear();
				}
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message);
			}
		}
	}
}
