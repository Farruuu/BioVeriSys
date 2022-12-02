using com.ruda.BusinessLogic;
using com.ruda.DataAccess;
using com.ruda.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace com.ruda.BioVeriSys_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersAPIController : ControllerBase
	{

		[HttpPost("CustomerVerification")]
		public async Task<IActionResult> CustomerVerification([FromForm] string postData)
		{
			try
			{
				string decrypted = new Cryptography().Decrypt(postData);
				Customers RequestedData = JsonConvert.DeserializeObject<Customers>(decrypted);

				if (!new UsersBLL().VerifyUserAccessToken(RequestedData.AppUserID.ToString(), RequestedData.AppUserAccessToken)) return Unauthorized();

				//call Nadra APi for verification

				Random random = new Random();

				string newCode = "3651" + random.Next(1000000, 9999999).ToString("0000000") + random.Next(10000000, 99999999).ToString("00000000");
				string xmlSource = @"<BIOMETRIC_VERIFICATION><USER_VERIFICATION><USERNAME>ruda_std</USERNAME><PASSWORD>y84tm63zu95</PASSWORD></USER_VERIFICATION> " +
									" <REQUEST_DATA> " +
										" <TRANSACTION_ID>" + newCode + "</TRANSACTION_ID> " +
										" <SESSION_ID></SESSION_ID> " +
										" <CITIZEN_NUMBER>" + RequestedData.CustCNIC + "</CITIZEN_NUMBER> " +
										" <CONTACT_NUMBER>" + RequestedData.CustCell + "</CONTACT_NUMBER> " +
										" <FINGER_INDEX>" + RequestedData.FingerIndex + "</FINGER_INDEX> " +
										" <FINGER_TEMPLATE>" + Convert.ToBase64String(RequestedData.FingerImage) + "</FINGER_TEMPLATE> " +
										" <TEMPLATE_TYPE>" + BioVeriSys.TemplateType.RAW_IMAGE + "</TEMPLATE_TYPE> " +
										" <AREA_NAME>punjab</AREA_NAME> " +
									" </REQUEST_DATA> " +
									" </BIOMETRIC_VERIFICATION>";

				var ApiResponse = await new BioVeriSys.BioVeriSysStandardClient().VerifyFingerPrintsAsync("3651", xmlSource);
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(ApiResponse);
				XmlNodeList nodeList = doc.GetElementsByTagName("RESPONSE_DATA");

				VerificationStatus vs = new VerificationStatus();

				foreach (XmlNode node in nodeList)
				{
					Enum.TryParse(RequestedData.BusinessPurpose.ToString(), out BusinessPurpose value);

					vs.BusinessPurpose = value.ToString();
					vs.SessionID = node.ChildNodes.Item(1).InnerText.Trim().ToString() ?? string.Empty;
					vs.CitizenNumber = node.ChildNodes.Item(2).InnerText.Trim().ToString() ?? string.Empty;
					vs.RequestedOn = DateTime.Now;
					vs.UserID = RequestedData.AppUserID;
					vs.StationID = RequestedData.AppUserStationID;

					vs.ResponseCode = Convert.ToInt32(node.ChildNodes.Item(0).FirstChild.InnerText.Trim().ToString());
					vs.ResponseMessage = node.ChildNodes.Item(0).LastChild.InnerText.Trim().ToString() ?? string.Empty;
					vs.TransactionID = newCode;

					if (node.LastChild.Name == "FINGER_INDEX")
					{
						vs.SuggestedFingers = new int[node.LastChild.ChildNodes.Count];

						for (int i = 0; i < node.LastChild.ChildNodes.Count; i++)
							vs.SuggestedFingers[i] = Convert.ToInt32(node.LastChild.ChildNodes.Item(i).InnerText.Trim());
					}
				}

				int RequestID = new CustomersDAL().StoreAPIRequestLogToDB(vs);

				Customers objcustomer = null;//new CustomerBLL().VerifyCustomer(postdata.CustCell, postdata.CustCell, postdata.FingerImage, postdata.AppUserID);

				if (vs.ResponseCode == 100)
				{
					objcustomer = new Customers();

					objcustomer.CustCNIC = RequestedData.CustCNIC;
					objcustomer.CustCell = RequestedData.CustCell;
					objcustomer.FingerIndex = RequestedData.FingerIndex;
					objcustomer.FingerImage = RequestedData.FingerImage;
					objcustomer.IsVerified = true;
					//objcustomer.CustID = (int)new CustomersDAL().AddCustomertoLocal(objcustomer, RequestedData.AppUserID);
				}

				VerificationResponse response = new VerificationResponse(objcustomer, vs);

				return Ok(response);
			}
			catch (Exception ex) { return BadRequest(ex.Message); }
		}

		[HttpPost("UserWiseActivityReport")]
		public IActionResult UserWiseActivityReport([FromForm] string UserID, [FromForm] string AccessToken, [FromForm] string ReportDate, [FromForm] string ReportUser)
		{
			try
			{
				if (!new UsersBLL().VerifyUserAccessToken(new Cryptography().Decrypt(UserID), new Cryptography().Decrypt(AccessToken))) return Unauthorized();

				DataTable dt = new CustomerBLL().GetUserWiseActivityReport(new Cryptography().Decrypt(ReportDate), new Cryptography().Decrypt(ReportUser));
				if (dt.Rows.Count <= 0)
					return NotFound();

				//return Ok(dt.AsEnumerable().ToList());
				return Ok(JsonConvert.SerializeObject(dt.AsEnumerable().ToList()));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
