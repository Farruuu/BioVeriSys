using com.ruda.DataAccess;
using com.ruda.Domain;
using System;
using System.Collections.Generic;
using System.Data;

namespace com.ruda.BusinessLogic
{
	public class UsersBLL
	{
		public Users DoLogin(string username, string password)
		{
			Users obj = null;
			try
			{
				DataTable dt = new UsersDAL().LoginUser(username, password);

				if (dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];

					Guid g = Guid.NewGuid();
					string accessTokenGen = Convert.ToBase64String(g.ToByteArray());

					obj = new Users()
					{
						ID = Convert.ToInt32(dr["ID"] != DBNull.Value ? dr["ID"].ToString() : "0"),
						Name = dr["Name"].ToString(),
						Designation = dr["Designation"].ToString(),
						Email = dr["Email"].ToString(),
						UserStatus = Convert.ToBoolean(dr["UserStatus"].ToString()),
						UserRole = Convert.ToInt32(dr["UserRole"] != DBNull.Value ? dr["UserRole"].ToString() : "0"),
						StationID = Convert.ToInt32(dr["StationID"] != DBNull.Value ? dr["StationID"].ToString() : "0"),
						AccessToken = accessTokenGen.Replace("=", "").Replace("+", "").Replace("/", "").Substring(0, 10)
					};
					var result = new UsersDAL().UpdateUserAccessToken(obj.ID, obj.AccessToken);
				}
			}
			catch (Exception ex) { throw ex; }
			return obj;
		}

		public List<Users> GetAllUsersList()
		{
			List<Users> lstUsers = new List<Users>();

			try
			{
				DataTable dt = new UsersDAL().GetAllUsersList();

				if (dt.Rows.Count > 0)
				{
					foreach (DataRow dr in dt.Rows)
					{
						Users obj = new Users()
						{
							ID = Convert.ToInt32(dr["ID"] != DBNull.Value ? dr["ID"].ToString() : "0"),
							Name = dr["Name"].ToString(),
							Designation = dr["Designation"].ToString(),
							Email = dr["Email"].ToString(),
							UserStatus = Convert.ToBoolean(dr["UserStatus"].ToString()),
						};

						lstUsers.Add(obj);
					}
				}
			}
			catch (Exception ex) { throw ex; }
			return lstUsers;
		}

		public int AddNewUser(Users user, int CreatedBy)
		{
			try
			{
				user.ID = new UsersDAL().AddNewUser(user, CreatedBy);
				return user.ID;
			}
			catch (Exception ex) { throw ex; }
		}

		public bool UpdatePassword(int UserID, string currentPassword, string newPassword)
		{
			try
			{
				bool Result = new UsersDAL().UpdatePassword(UserID, currentPassword, newPassword);
				return Result;

			}
			catch (Exception ex) { throw ex; }
		}

		public bool VerifyUserAccessToken(string userid, string access_token)
		{
			try
			{
				bool result = new UsersDAL().VerifyUserAccessToken(userid, access_token);
				return result;
			}
			catch (Exception ex) { throw ex; }

		}
	}
}
