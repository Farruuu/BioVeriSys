using System;
using System.Collections.Generic;
using System.Text;

namespace com.ruda.Domain
{
	public class Users
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Designation { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public bool UserStatus { get; set; }
		public int UserRole { get; set; }
		public string UserRoleName { get; set; }
		public string AccessToken { get; set; }
		public int StationID { get; set; }
	}

	public class UserRoles
	{
		public int ID { get; set; }
		public string RoleName { get; set; }
		public string Description { get; set; }
	}

	public class Stations
	{
		public int StationID { get; set; }
		public string Description { get; set; }
	}
}
