using NadraBioVeriSys.Class;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace NadraBioVeriSys
{
	public partial class frmLogin : Form
	{
		public frmLogin()
		{
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(txtUsername.Text))
				{
					lblInvalidLogin.Text = "Please enter UserName!";
					txtUsername.Focus();
					return;
				}
				else if (string.IsNullOrEmpty(txtPassword.Text))
				{
					lblInvalidLogin.Text = "Please enter Password";
					txtPassword.Focus();
					return;
				}

				string postData = "username=" + new Cryptography().Encrypt(txtUsername.Text) + "&password=" + new Cryptography().Encrypt(txtPassword.Text);
				string URL = Shared.API_URL + @"UsersAPI/DoLogin?" + postData;

				var client = new RestClient(URL);
				var request = new RestRequest(URL, Method.Post);
				RestResponse response = client.Execute(request);

				if (!response.IsSuccessStatusCode)
				{
					lblInvalidLogin.Text = response.StatusCode.ToString();
					txtUsername.Focus();
					return;
				}

				Shared.LoggedInUser = JsonConvert.DeserializeObject<Users>(response.Content);

				if (!Shared.LoggedInUser.UserStatus)
				{
					lblInvalidLogin.Text = "This User Account is disabled. Please contact RUDA IT Department.";
					return;
				}

				this.Hide();
				MainForm ObjMainMdi = new MainForm();
				ObjMainMdi.Show();
			}
			catch (Exception exp) { MessageBox.Show(exp.Message); }
		}
	}
}
