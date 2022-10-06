using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                string NewPassword = txtNewPassword.Text.Trim();

                if (!NewPassword.Equals(txtConfirmPassword.Text))
                {
                    lblResult.Text = "Password Doesn't match. Please try again!";
                    lblResult.ForeColor = Color.Red;
                    txtCurrentPassword.Focus();
                    return;
                }
                if (NewPassword.Length < 8 || NewPassword.Length > 15)
                {
                    lblResult.Text = "Password length must be greater than 8 characters and less than 15 characters. Please try again!";
                    lblResult.ForeColor = Color.Red;
                    txtCurrentPassword.Focus();
                    return;
                }
                if (NewPassword.Contains(" "))
                {
                    lblResult.Text = "Spaces not allowed in Password. Please try again!";
                    lblResult.ForeColor = Color.Red;
                    txtCurrentPassword.Focus();
                    return;
                }

                string postData = "UserID=" + Shared.loggedInUserID + "&CurrentPassword=" + txtCurrentPassword.Text + "&NewPassword=" + txtNewPassword.Text;
                string URL = Shared.API_URL + @"Users/UpdatePassword";
                var data = new WebService().webPostMethod(postData, URL);

                var response = JObject.Parse(data);

                if ((int)response["meta"]["code"] == 200)
                {
                    lblResult.Text = response["meta"]["message"].ToString();
                    lblResult.ForeColor = Color.Green;

                    txtCurrentPassword.Clear();
                    txtNewPassword.Clear();
                    txtConfirmPassword.Clear();
                }
                else
                {
                    lblResult.Text = response["meta"]["message"].ToString();
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
