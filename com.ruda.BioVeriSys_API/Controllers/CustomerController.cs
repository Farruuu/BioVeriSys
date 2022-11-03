using com.ruda.BusinessLogic;
using com.ruda.DataAccess;
using com.ruda.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;
using System.Xml.Linq;

namespace com.ruda.BioVeriSys_API.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<string> CustomerVerificationAsync(string postData) //string userid, string Access_token, string data
        {
            jsonmeta meta = new jsonmeta();
            string response = "";

            try
            {
                string decrypted = new Cryptography().Decrypt(postData);
                Customers RequestedData = JsonConvert.DeserializeObject<Customers>(decrypted);

                if (new UsersBLL().VerifyUserAccessToken(RequestedData.AppUserID.ToString(), RequestedData.AppUserAccessToken))
                {
                    VerificationStatus vs = new VerificationStatus();

                    Customers objcustomer = null;//new CustomerBLL().VerifyCustomer(postdata.CustCell, postdata.CustCell, postdata.FingerImage, postdata.AppUserID);

                    if (objcustomer == null)
                    {
                        //call Nadra APi for verification
                        BioVeriSys.BioVeriSysStandardClient bvs = new BioVeriSys.BioVeriSysStandardClient();
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

                        var ApiResponse = await bvs.VerifyFingerPrintsAsync("3651", xmlSource);
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(ApiResponse);
                        XmlNodeList nodeList = doc.GetElementsByTagName("RESPONSE_DATA");

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
                    }

                    meta.code = vs.ResponseCode;
                    meta.message = vs.ResponseMessage;
                    response = SendResponse("Verification", meta, new
                    {
                        VerificationResponse = vs,
                        CustomerInfo = objcustomer
                    });
                }
            }
            catch (Exception ex)
            {
                meta.code = 404;
                meta.message = "Something went wrong!";
                response = SendResponse("Verification", meta, null, "Error Occured while Processing your Request!" + Environment.NewLine + ex.Message);
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
            response = JsonConvert.SerializeObject(res, Newtonsoft.Json.Formatting.Indented);

            return response;
        }

        #endregion
    }
}
