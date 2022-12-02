using System;
using System.Data;
using com.ruda.Domain;

namespace com.ruda.DataAccess
{
	public class UsersDAL
	{
		public DataTable GetAllUsersList()
		{
			DataTable dt = new DataTable();
			try
			{
				string @get = @"SP_GetAllUsers";
				dt = new DBHandle().FillDTSP(@get);
			}
			catch (Exception ex) { throw new Exception(ex.Message); }
			return dt;
		}

		public DataTable LoginUser(string username, string password)
		{
			DataTable dt = new DataTable();
			try
			{
				string @get = @"SP_LoginUser, @username, @password";
				dt = new DBHandle().FillDTSP(@get, username, password);
			}
			catch (Exception ex) { throw new Exception(ex.Message); }
			return dt;
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

		public int AddNewUser(Users user, int CreatedBy)
		{
			try
			{
				string @get = @"SP_AddNewUser, @Name, @Designation, @Email, @Password, @StationID, @UserRole, @CreatedBy";
				int result = (Int32)new DBHandle().ExecuteSPWithReturnID(@get, user.Name, user.Designation, user.Email, user.Password, user.StationID, user.UserRole, CreatedBy);

				return result;
			}
			catch (Exception ex) { return -1; }
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

	}
}
