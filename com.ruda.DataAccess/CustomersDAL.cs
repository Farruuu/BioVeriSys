using com.ruda.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.ruda.DataAccess
{
    public class CustomersDAL
    {
        public Customers GetCustomerDetails(string CNIC)
        {
            Customers obj = null;
            try
            {
                string @get = @"SP_GetCustomerDetails, @CNIC";
                DataTable dt = new DBHandle().FillDTSP(@get, CNIC);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        obj = new Customers()
                        {
                            CustID = Convert.ToInt32(dr["ID"] != DBNull.Value ? dr["ID"].ToString() : "0"),
                            CustCNIC = dr["CNIC"].ToString(),
                            FingerImage = (byte[])dr["FingerImage"],
                            IsVerified = Convert.ToBoolean(dr["IsVerified"])
                        };
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return obj;
        }

        public long AddCustomertoLocal(Customers objCustomer, int UserID)
        {
            try
            {
                string @get = @"SP_Add_UpdateCustomertoLocal, @CNIC, @FingerImage, @IsVerified, @UserID";
                Int64 result = new DBHandle().ExecuteSPWithReturnID(@get, objCustomer.CustCNIC, objCustomer.FingerImage, objCustomer.IsVerified, UserID);

                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public int StoreAPIRequestLogToDB(VerificationStatus vs)
        {
            try
            {
                string @get = @"SP_StoreAPIRequestLog, @BusinessPurpose, @SessionID, @CitizenNumber, @RequestedOn, @RequestedBy, @StationID, @ResponseCode, @ResponseMessage, @TransactionID";
                Int64 result = new DBHandle().ExecuteSPWithReturnID(@get, vs.BusinessPurpose, vs.SessionID, vs.CitizenNumber, vs.RequestedOn, vs.UserID, vs.StationID, vs.ResponseCode, vs.ResponseMessage, vs.TransactionID);

                return (int)result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
