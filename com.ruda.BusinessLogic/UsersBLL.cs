using com.ruda.DataAccess;
using com.ruda.Domain;
using System;

namespace com.ruda.BusinessLogic
{
    public class UsersBLL
    {
        public Users DoLogin(string username, string password)
        {
            try
            {
                Users objuser = new UsersDAL().LoginUser(username, password);

                if (objuser != null && objuser.UserStatus)
                {
                    Guid g = Guid.NewGuid();
                    string accessTokenGen = Convert.ToBase64String(g.ToByteArray());
                    objuser.AccessToken = accessTokenGen.Replace("=", "").Replace("+", "").Replace("/", "").Substring(0, 10);

                    var result = new UsersDAL().UpdateUserAccessToken(objuser.ID, objuser.AccessToken);
                    return objuser;
                }
                else
                    return null;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool UpdatePassword(int UserID, string currentPassword, string newPassword)
        {
            try
            {
                bool Result = new UsersDAL().UpdatePassword(UserID, currentPassword, newPassword);
                return Result;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool VerifyUserAccessToken(string userid, string access_token)
        {
            bool result = new UsersDAL().VerifyUserAccessToken(userid, access_token);
            return result;
        }


    }
}
