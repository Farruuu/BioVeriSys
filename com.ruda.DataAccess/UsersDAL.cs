using com.ruda.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.ruda.DataAccess
{
    public class UsersDAL
    {
        public Users LoginUser(string username, string password)
        {
            Users obj = null;
            try
            {
                string @get = @"SP_LoginUser, @username, @password";
                DataTable dt = new DBHandle().FillDTSP(@get, username, password);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        obj = new Users()
                        {
                            ID = Convert.ToInt32(dr["ID"] != DBNull.Value ? dr["ID"].ToString() : "0"),
                            Name = dr["Name"].ToString(),
                            Designation = dr["Designation"].ToString(),
                            Email = dr["Email"].ToString(),
                            UserStatus = Convert.ToBoolean(dr["UserStatus"].ToString()),
                        };
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return obj;
        }

        public bool UpdatePassword(int userID, string currentPassword, string newPassword)
        {
            try
            {
                string @get = @"SP_UpdatePassword, @userID, @currentPassword, @newPassword";
                Int64 result = new DBHandle().ExecuteSPWithReturnID(@get, userID, currentPassword, newPassword);

                return result > 0;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public object UpdateUserAccessToken(int ID, string accessToken)
        {
            try
            {
                string @get = @"SP_UpdateUserAccessToken, @ID, @accessToken";
                Int64 result = new DBHandle().ExecuteSPWithReturnID(@get, ID, accessToken);

                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool VerifyUserAccessToken(string userid, string access_token)
        {
            try
            {
                string @get = @"SP_VerifyUserAccessToken, @UserId, @Access_Token";
                bool result = Convert.ToBoolean(new DBHandle().ExecuteSPWithReturnID(@get, Convert.ToInt32(userid), access_token));

                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
