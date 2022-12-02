using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadraBioVeriSys
{
	public class VerificationResponse
	{
		public Customers objCustomer;
		public VerificationStatus objStatus;

		public VerificationResponse(Customers objCustomer, VerificationStatus objStatus)
		{
			this.objCustomer = objCustomer;
			this.objStatus = objStatus;
		}
	}

	public class Customers
    {
        public int ID { get; set; }
        public string CustCNIC { get; set; }
        public string CustCell { get; set; }
        public int BusinessPurpose { get; set; }
        public int FingerIndex { get; set; } = 0;
        public byte[] FingerImage { get; set; }
        public bool IsVerified { get; set; }
        public int AppUserID { get; set; }
        public int AppUserStationID { get; set; }
        public string AppUserAccessToken { get; set; }
    }

	public class VerificationStatus
	{

		public string SessionID { get; set; }
		public string BusinessPurpose { get; set; }
		public string CitizenNumber { get; set; }

		public int UserID { get; set; }
		public int StationID { get; set; }

		public int ResponseCode { get; set; }
		public string ResponseMessage { get; set; }
		public DateTime RequestedOn { get; set; }
		public string TransactionID { get; set; }
		public int[] SuggestedFingers { get; set; }
	}


	public enum Fingers
    {
        Right_Thumb = 1,
        Right_Index_Finger = 2,
        Right_Middle_Finger = 3,
        Right_Ring_Finger = 4,
        Right_Little_Finger = 5,
        Left_Thumb = 6,
        Left_Index_Finger = 7,
        Left_Middle_Finger = 8,
        Left_Ring_Finger = 9,
        Left_Little_Finger = 10
    };

    public enum BusinessPurpose
    {
        Purchase_Of_Land = 1,
        Sale_Booking_Of_Plot_Appartment = 2
    }

}
