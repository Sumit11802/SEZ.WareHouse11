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
using System;
using DB = MVC.DB.CommonService;
namespace MVC.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private CommonService commonConnectivity = new CommonService();
        DB.CommonService db = new DB.CommonService();


        public DataTable AddCustomerEntry(CUSTOMER customer)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@EMAIL_ID", customer.EMAIL_ID);
            sqlParameters[1] = new SqlParameter("@CONTACT_NO", customer.CONTACT_NO);
            sqlParameters[2] = new SqlParameter("@TYPE_OF_KYC", customer.TYPE_OF_KYC);

            dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_CUSTOMER]", sqlParameters);
            return dt;
        }


        public DataTable AddCompanyDetails(CUSTOMER customer)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[10];
            sqlParameters[0] = new SqlParameter("@CUSTOMER_ID", customer.CUSTOMER_ID);
            sqlParameters[1] = new SqlParameter("@REGESTRATION_TYPE", customer.REGESTRATION_TYPE);
            sqlParameters[2] = new SqlParameter("@GST_No", customer.GST_No);
            sqlParameters[3] = new SqlParameter("@COMPANY_NAME", customer.COMPANY_NAME);
            sqlParameters[4] = new SqlParameter("@ADDRESS", customer.ADDRESS);
            sqlParameters[5] = new SqlParameter("@LOCATION", customer.LOCATION);
            sqlParameters[6] = new SqlParameter("@PIN_CODE", customer.PIN_CODE);
            sqlParameters[7] = new SqlParameter("@STATE", customer.STATE);
            sqlParameters[8] = new SqlParameter("@PAN_NO", customer.PAN_NO);
            sqlParameters[9] = new SqlParameter("@TYPE_OF_ORGANISATION", customer.TYPE_OF_ORGANISATION);

            dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_CUSTOMER_GST_D]", sqlParameters);
            return dt;
        }


        public DataTable AddBankDetails(CUSTOMER customer)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@CUSTOMER_ID", customer.CUSTOMER_ID);
            sqlParameters[1] = new SqlParameter("@ACCOUNT_NAME", customer.ACCOUNT_NAME);
            sqlParameters[2] = new SqlParameter("@ACCOUNT_NUMBER", customer.ACCOUNT_NUMBER);
            sqlParameters[3] = new SqlParameter("@ACCOUNT_TYPE", customer.ACCOUNT_TYPE);
            sqlParameters[4] = new SqlParameter("@IFSC_CODE", customer.IFSC_CODE);

            dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_CUSTOMER_BANK_D]", sqlParameters);
            return dt;
        }


        public DataTable AddCustomerDetails(CUSTOMER customer)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = new SqlParameter("@CUSTOMER_ID", customer.CUSTOMER_ID);
            sqlParameters[1] = new SqlParameter("@NAME", customer.NAME);
            sqlParameters[2] = new SqlParameter("@DESIGNATION", customer.DESIGNATION);
            sqlParameters[3] = new SqlParameter("@MOBILE_NO", customer.MOBILE_NO);
            sqlParameters[4] = new SqlParameter("@EMAIL_ID", customer.EMAIL_ID);
            sqlParameters[5] = new SqlParameter("@PAN_NO", customer.PAN_NO);
            sqlParameters[6] = new SqlParameter("@TAN_NO", customer.TAN_NO);

            dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_CUSTOMER_CONTACT_D]", sqlParameters);
            return dt;
        }
        int ICustomerRepository.AddCustomerDetails(CUSTOMER CUSTOMER)
        {
            throw new NotImplementedException();
        }

        int ICustomerRepository.AddCustomerEntry(CUSTOMER CUSTOMER)
        {
            throw new NotImplementedException();
        }

        int ICustomerRepository.AddCompanyDetails(CUSTOMER CUSTOMER)
        {
            throw new NotImplementedException();
        }

        int ICustomerRepository.AddBankDetails(CUSTOMER CUSTOMER)
        {
            throw new NotImplementedException();
        }

        public List<CUSTOMER> FetchCustomer()

        {
            List<CUSTOMER> allcustomer = new List<CUSTOMER>();
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspFetchCustomer]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CUSTOMER customer = new CUSTOMER();
                    customer.COMPANY_NAME = Convert.ToString(row["COMPANY_NAME"]);
                    customer.GST_No = Convert.ToString(row["GST_No"]);
                    customer.EMAIL_ID = Convert.ToString(row["EMAIL_ID"]);

                    allcustomer.Add(customer);
                }
            }
            return allcustomer;
        }

        public DataTable FetchCustomerDetail(int ID)
        {

            CUSTOMER employee = new CUSTOMER();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspEditEmployee]", sqlParameters);

            
            return dt;
        }
        public DataTable GetGLobalGSTList(String SearchText)
        {
            DataTable GlobalListDT = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@searchText", SearchText);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[USP_GetGlobalSearchDataNew]", sqlParameters);
 
            return dt;
        }
        public DataTable GateInDocDropDownListForUpload(string Concode)
        {
            
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CONCODE", Concode);
          
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[USP_GetDocuemntTypeDETAILSGateIN]", sqlParameters);
            
            return dt;
        }

        public DataTable GetUserData(long id)
        {
            DataTable DT = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", id);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[USP_GetCustomerData]", sqlParameters);

            return dt;
        }
        public DataTable UpdateMaster(Int64 id, string Name,  string address, string contactPer, 
            string email,   string remarks, bool CHA, bool Customer, bool shippline, bool importer, bool isactive, int userId,
       bool Vendor, string NSDLID, string IECNO, 
                DateTime AgreementDate,
                DateTime ExpireDate
        )
        {
            DataTable dt = new DataTable();
            int i = 0;
             
            dt = db.getData("uspAddUpdateCustomerDetails1 '" + id + "','" + Name + "','" + address + "','" + contactPer +  "','" + email + "','" + remarks + "','" + userId + "','" + CHA + "','" + Customer + "','" + shippline + "','" + importer + "','" + isactive + "','"  + Vendor + "','" + NSDLID + "','" + IECNO + "','" + AgreementDate + "','" + ExpireDate + "'" );

            return dt;

        }
        public DataTable GetLocationDetails()
        {
            DataTable LoginDT = new DataTable();
 
            LoginDT = db.getData("get_sp_table 'ext_location_m', 'LocationID,Location','','Location'");
            return LoginDT;
        }

        public DataTable GetGSTRegistrationType()
        {
            DataTable LoginDT = new DataTable();
         
            LoginDT = db.getData("get_sp_table 'GST_Registration_Type', 'RGID,RGType','','RGType'");
            return LoginDT;
        }
        public DataTable GetCustomerLocationList(Int64 id)
        {
            DataTable LoginDT = new DataTable();
          
            LoginDT = db.getData("USP_getCustomerWiseLocationList " + id + "");
            return LoginDT;
        }
        public DataTable GetStateCode(string GstNo)
        {
            DataTable LoginDT = new DataTable();
          
            LoginDT = db.getData("Sp_stateFilter '" + GstNo + "'");
            return LoginDT;
        }
        public DataTable GetGSTLocationWiseData(Int32 LocationID, Int64 Common_ID, Int64 GSTID)
        {
            DataTable LoginDT = new DataTable();
             
            LoginDT = db.getData("USP_getGSTWiseLocationData " + LocationID + "," + Common_ID + "," + GSTID + "");
            return LoginDT;
        }
    }
}
