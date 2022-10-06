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
                string postData = "username=" + txtUsername.Text + "&password=" + txtPassword.Text;
                string URL = Shared.API_URL + @"Users/DoLogin";
                var data = new WebService().webPostMethod(postData, URL);

                var response = JObject.Parse(data);
                
                if ((int)response["meta"]["code"] == 200)
                {
                    this.Hide();
                    Shared.loggedInUserID = (int)response["response"]["userId"];
                    Shared.loggedInUserName = response["response"]["Name"].ToString();
                    Shared.loggedInUserEmail = response["response"]["email"].ToString();
                    Shared.Access_token = response["response"]["Access_token"].ToString();
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
