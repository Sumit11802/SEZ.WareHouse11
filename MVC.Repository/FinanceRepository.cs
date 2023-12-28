using MVC.DB;
using MVC.Domain.Model;
using MVC.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository
{
    public class FinanceRepository : IFinanceRepository
    {
        private CommonService commonConnectivity = new CommonService();

        private object _commonService;

        public DataTable AddBillingHeadMaster (FINANCE finance)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[3];

            sqlParameters[1] = new SqlParameter("@HSN_CODE", finance.HSN_CODE);
            sqlParameters[2] = new SqlParameter("@HSN_DESCRIPTION", finance.HSN_DESCRIPTION);
            sqlParameters[3] = new SqlParameter("@HSN_TAX_GROUP_ID", finance.HSN_TAX_GROUP_ID);

            dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_FINANCE_HSN_MASTER]", sqlParameters);
            return dt;
        }

        int IFinanceRepository.AddBillingHeadMaster (FINANCE FINANCE)
        {
            throw new NotImplementedException();
        }


        //public DataTable AddCompanyDetails(CUSTOMER customer)
        //{
        //    DataTable dt = new DataTable();
        //    SqlParameter[] sqlParameters = new SqlParameter[10];
        //    sqlParameters[0] = new SqlParameter("@CUSTOMER_ID", customer.CUSTOMER_ID);
        //    sqlParameters[1] = new SqlParameter("@REGESTRATION_TYPE", customer.REGESTRATION_TYPE);
        //    sqlParameters[2] = new SqlParameter("@GST_No", customer.GST_No);
        //    sqlParameters[3] = new SqlParameter("@COMPANY_NAME", customer.COMPANY_NAME);
        //    sqlParameters[4] = new SqlParameter("@ADDRESS", customer.ADDRESS);
        //    sqlParameters[5] = new SqlParameter("@LOCATION", customer.LOCATION);
        //    sqlParameters[6] = new SqlParameter("@PIN_CODE", customer.PIN_CODE);
        //    sqlParameters[7] = new SqlParameter("@STATE", customer.STATE);
        //    sqlParameters[8] = new SqlParameter("@PAN_NO", customer.PAN_NO);
        //    sqlParameters[9] = new SqlParameter("@TYPE_OF_ORGANISATION", customer.TYPE_OF_ORGANISATION);

        //    dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_CUSTOMER_GST_D]", sqlParameters);
        //    return dt;
        //}


        //public DataTable AddBankDetails(CUSTOMER customer)
        //{
        //    DataTable dt = new DataTable();
        //    SqlParameter[] sqlParameters = new SqlParameter[5];
        //    sqlParameters[0] = new SqlParameter("@CUSTOMER_ID", customer.CUSTOMER_ID);
        //    sqlParameters[1] = new SqlParameter("@ACCOUNT_NAME", customer.ACCOUNT_NAME);
        //    sqlParameters[2] = new SqlParameter("@ACCOUNT_NUMBER", customer.ACCOUNT_NUMBER);
        //    sqlParameters[3] = new SqlParameter("@ACCOUNT_TYPE", customer.ACCOUNT_TYPE);
        //    sqlParameters[4] = new SqlParameter("@IFSC_CODE", customer.IFSC_CODE);

        //    dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_CUSTOMER_BANK_D]", sqlParameters);
        //    return dt;
        //}


        //public DataTable AddCustomerDetails(CUSTOMER customer)
        //{
        //    DataTable dt = new DataTable();
        //    SqlParameter[] sqlParameters = new SqlParameter[7];
        //    sqlParameters[0] = new SqlParameter("@CUSTOMER_ID", customer.CUSTOMER_ID);
        //    sqlParameters[1] = new SqlParameter("@NAME", customer.NAME);
        //    sqlParameters[2] = new SqlParameter("@DESIGNATION", customer.DESIGNATION);
        //    sqlParameters[3] = new SqlParameter("@MOBILE_NO", customer.MOBILE_NO);
        //    sqlParameters[4] = new SqlParameter("@EMAIL_ID", customer.EMAIL_ID);
        //    sqlParameters[5] = new SqlParameter("@PAN_NO", customer.PAN_NO);
        //    sqlParameters[6] = new SqlParameter("@TAN_NO", customer.TAN_NO);

        //    dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_CUSTOMER_CONTACT_D]", sqlParameters);
        //    return dt;
        //}
        //int ICustomerRepository.AddCustomerDetails(CUSTOMER CUSTOMER)
        //{
        //    throw new NotImplementedException();
        //}

        //int ICustomerRepository.AddCustomerEntry(CUSTOMER CUSTOMER)
        //{
        //    throw new NotImplementedException();
        //}

        //int ICustomerRepository.AddCompanyDetails(CUSTOMER CUSTOMER)
        //{
        //    throw new NotImplementedException();
        //}

        //int ICustomerRepository.AddBankDetails(CUSTOMER CUSTOMER)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
