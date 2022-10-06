using com.ruda.DataAccess;
using com.ruda.Domain;
using System;
using System.Linq;


namespace com.ruda.BusinessLogic
{
    public class CustomerBLL
    {
        public Customers VerifyCustomer(string CNIC, string Cell, byte[] FingerImage, int UserID)
        {
            Customers objcustomer = new Customers();
            try
            {
                objcustomer = new CustomersDAL().GetCustomerDetails(CNIC);

                if (objcustomer != null)
                {
                    bool matched = FingerImage.SequenceEqual(objcustomer.FingerImage);
                    if (matched && objcustomer.IsVerified)
                        return objcustomer;
                    else
                        return null;
                }
                else
                {
                    return objcustomer;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
