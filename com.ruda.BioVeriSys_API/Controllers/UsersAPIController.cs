using com.ruda.BusinessLogic;
using com.ruda.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace com.ruda.BioVeriSys_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class UsersAPIController : ControllerBase
	{
		[HttpPost("DoLogin")]
		public IActionResult DoLogin(string username, string password)
		{
			try
			{
				Users objuser = new UsersBLL().DoLogin(new Cryptography().Decrypt(username), new Cryptography().Decrypt(password));
				if (objuser == null)
					return NotFound();

				return Ok(objuser);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetAllUsersList")]
		public IActionResult GetAllUsersList(string UserID, string AccessToken)
		{
			try
			{
				if (!new UsersBLL().VerifyUserAccessToken(new Cryptography().Decrypt(UserID), new Cryptography().Decrypt(AccessToken))) return Unauthorized();

				List<Users> users = new UsersBLL().GetAllUsersList();
				if (users == null)
					return NotFound();

				return Ok(users);
			}
			catch (Exception ex) { return BadRequest(ex.Message); }
		}

		[HttpPost("AddNewUser")]
		public IActionResult AddNewUser([FromForm] string UserID, [FromForm] string AccessToken, [FromForm] string User, [FromForm] string CreatedBy)
		{
			try
			{
				if (!new UsersBLL().VerifyUserAccessToken(new Cryptography().Decrypt(UserID), new Cryptography().Decrypt(AccessToken))) return Unauthorized();

				string decrypted = new Cryptography().Decrypt(User);
				Users RequestedData = JsonConvert.DeserializeObject<Users>(decrypted);

				RequestedData.ID = new UsersBLL().AddNewUser(RequestedData, Convert.ToInt32(new Cryptography().Decrypt(CreatedBy)));

				if (RequestedData.ID <= 0)
					return NotFound();

				return CreatedAtAction("User Added Successfully", RequestedData.ID);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("UpdatePassword")]
		public IActionResult UpdatePassword([FromForm] string UserID, [FromForm] string AccessToken, [FromForm] string CurrentPassword, [FromForm] string NewPassword)
		{
			try
			{
				if (!new UsersBLL().VerifyUserAccessToken(new Cryptography().Decrypt(UserID), new Cryptography().Decrypt(AccessToken))) return Unauthorized();

				bool result = new UsersBLL().UpdatePassword(Convert.ToInt32(new Cryptography().Decrypt(UserID)), new Cryptography().Decrypt(CurrentPassword), new Cryptography().Decrypt(NewPassword));

				if (!result)
					return NotFound();

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
