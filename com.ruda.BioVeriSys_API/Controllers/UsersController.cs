using com.ruda.BusinessLogic;
using com.ruda.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.ruda.BioVeriSys_API.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string DoLogin(string username, string password)
        {
            jsonmeta meta = new jsonmeta();
            string response;

            try
            {
                Users objuser = new UsersBLL().DoLogin(username, password);

                if (objuser != null)
                {
                    meta.code = 200;
                    meta.message = "Signed In Successfully!";
                    response = SendResponse("SignIn", meta, new
                    {
                        userId = objuser.ID,
                        Name = objuser.Name,
                        email = objuser.Email,
                        Access_token = objuser.AccessToken
                    });
                }
                else
                {
                    meta.code = -1000;
                    meta.message = "Invalid Username / Email or password";
                    response = SendResponse("SignIn", meta, null, "Invalid User email or password");
                    //return response;
                }
            }
            catch (Exception ex)
            {
                meta.code = 404;
                meta.message = "Something went wrong!";
                response = SendResponse("Create New User", meta, null, "Error Occured while Processing your Request!" + Environment.NewLine + ex.Message);
            }

            return response;
        }

        [HttpPost]
        public string UpdatePassword(string UserID, string CurrentPassword, string NewPassword)
        {
            jsonmeta meta = new jsonmeta();
            string response;

            try
            {
                bool result = new UsersBLL().UpdatePassword(Convert.ToInt32(UserID), CurrentPassword, NewPassword);

                if (result)
                {
                    meta.code = 200;
                    meta.message = "Password updated Successfully!";
                    response = SendResponse("Update Password", meta, null, "Password Updated Successfully");
                }
                else
                {
                    meta.code = -1000;
                    meta.message = "Invalid Current Password";
                    response = SendResponse("Update Password", meta, null, "Invalid Current Password");
                }
            }
            catch (Exception ex)
            {
                meta.code = 404;
                meta.message = "Something went wrong!";
                response = SendResponse("Update Password", meta, null, "Error Occured while Processing your Request!" + Environment.NewLine + ex.Message);
            }

            return response;
        }

        #region Response 

        private string SendResponse(string action, jsonmeta meta, object data, string error = null)
        {
            string response = "";

            if (!string.IsNullOrEmpty(error))
            {
                data = null;
            }
            if (data != null)
            {
                error = null;
            }
            JsonResponse res = new JsonResponse();
            res.action = action;
            res.meta = meta;
            res.response = data;
            res.error = error;
            response = JsonConvert.SerializeObject(res, Formatting.Indented);

            return response;
        }

        #endregion
    }
}
