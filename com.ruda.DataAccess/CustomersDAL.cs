using com.ruda.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.ruda.DataAccess
{
	public class CustomersDAL
	{
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

		public DataTable GetUserWiseActivityReport(DateTime ReportDate, int ReportUser)
		{
			DataTable dt = new DataTable();
			try
			{
				string @get = @"SP_GetUserWiseActivityReport, @ReportDate, @ReportUser";
				dt = new DBHandle().FillDTSP(@get, ReportDate, ReportUser);
			}
			catch (Exception ex) { throw new Exception(ex.Message); }
			return dt;
		}
	}
}
