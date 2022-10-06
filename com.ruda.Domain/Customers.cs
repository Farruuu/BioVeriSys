using System;
using System.Collections.Generic;
using System.Text;

namespace com.ruda.Domain
{
    public class Customers
    {
        public int CustID { get; set; }
        public string CustCNIC { get; set; }
        public string CustCell { get; set; }
        public int FingerIndex { get; set; } = 0;
        public byte[] FingerImage { get; set; }
        public bool IsVerified { get; set; }
        public int AppUserID { get; set; }
        public string AppUserAccessToken { get; set; }
    }

    public class VerificationStatus
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string SessionID { get; set; }
        public DateTime RequestedOn { get; set; }
        public string TransactionID { get; set; }
        public string CitizenNumber { get; set; }
        public int[] SuggestedFingers { get; set; }
    }
}
