using com.ruda.DataAccess;
using com.ruda.Domain;
using System;
using System.Data;
using System.Linq;


namespace com.ruda.BusinessLogic
{
	public class CustomerBLL
	{
		public DataTable GetUserWiseActivityReport(string ReportDate, string ReportUser)
		{
			try
			{
				DataTable dt = new CustomersDAL().GetUserWiseActivityReport(Convert.ToDateTime(ReportDate), Convert.ToInt32(ReportUser));
				return dt;
			}
			catch (Exception ex) { throw ex; }
		}
	}
}
