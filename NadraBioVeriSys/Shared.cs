using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadraBioVeriSys
{
    public class Shared
    {
        public static string API_URL = System.Configuration.ConfigurationManager.AppSettings["API"];
        public static int loggedInUserID = 0;
        public static string loggedInUserName = "";
        public static string loggedInUserEmail = "";
        public static string Access_token = "";

        public static string SessionID = String.Empty;
        public static DateTime RequestedOn = DateTime.MinValue;
        public static string TransactionID = String.Empty;
        public static string CitizenNumber = String.Empty;
        public static int ResponseCode = 0;
        public static string ResponseMessage = String.Empty;
        public static int[] SuggestedFingers = null;

       
    }
}
