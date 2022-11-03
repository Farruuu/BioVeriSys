using NadraBioVeriSys.Class;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
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

                string postData = "username=" + txtUsername.Text + "&password=" + txtPassword.Text;
                string URL = Shared.API_URL + @"Users/DoLogin";
                var data = new WebService().webPostMethod(postData, URL);

                var response = JObject.Parse(data);

                if ((int)response["meta"]["code"] == 200)
                {
                    var objUser = JsonConvert.SerializeObject(response["response"]["User"]);
                    Shared.LoggedInUser =  JsonConvert.DeserializeObject<Users>(objUser);
                    if (!Shared.LoggedInUser.UserStatus)
                    {
                        lblInvalidLogin.Text = "This User Account is disabled. Please contact RUDA IT Department.";
                        return;
                    }

                    this.Hide();
                    MainForm ObjMainMdi = new MainForm();
                    ObjMainMdi.Show();
                }
                else
                {
                    lblInvalidLogin.Text = response["meta"]["message"].ToString();
                    txtUsername.Focus();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
