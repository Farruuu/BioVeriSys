using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadraBioVeriSys
{
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
