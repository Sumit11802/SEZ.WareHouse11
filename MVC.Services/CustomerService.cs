using MVC.Domain.Model;
using MVC.Repository;
using MVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MVC.Domain.Model;
using EN = MVC.Domain.Model;
using DB = MVC.DB.CommonService;
using MVC.DB;

namespace MVC.Services
{
    public class CustomerService : ICustomerService
    {
        CustomerRepository customerRepository = new CustomerRepository();
        DB.CommonService db = new DB.CommonService();
        private CommonService commonConnectivity = new CommonService();

        public int AddCustomerEntry(CUSTOMER CUSTOMER)
        {
            int result = 0;
            try
            {
                DataTable data = new DataTable();
                data = customerRepository.AddCustomerEntry(CUSTOMER);
                if (data != null)
                {
                    result = Convert.ToInt32(data.Rows[0][0].ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddCompanyDetails(CUSTOMER CUSTOMER)
        {
            int result = 0;
            try
            {
                DataTable data = new DataTable();
                data = customerRepository.AddCompanyDetails(CUSTOMER);
                if (data != null)
                {
                    result = Convert.ToInt32(data.Rows[0][0].ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public int AddBankDetails(CUSTOMER CUSTOMER)
        {
            int result = 0;
            try
            {
                DataTable data = new DataTable();
                data = customerRepository.AddBankDetails(CUSTOMER);
                if (data != null)
                {
                    result = Convert.ToInt32(data.Rows[0][0].ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddCustomerDetails(CUSTOMER CUSTOMER)
        {
            int result = 0;
            try
            {
                DataTable data = new DataTable();
                data = customerRepository.AddCustomerDetails(CUSTOMER);
                if (data != null)
                {
                    result = Convert.ToInt32(data.Rows[0][0].ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public CUSTOMER FetchCustomerDetail(int ID)
        {
            CUSTOMER customer = new CUSTOMER();
            try
            {
                DataTable dt = new DataTable();
                dt = customerRepository.FetchCustomerDetail(ID);
            
                  if (dt != null && dt.Rows.Count > 0)
                  {
                        foreach (DataRow row in dt.Rows)
                        {

                            customer.EMAIL_ID = Convert.ToString(row["EMAIL_ID"]);
                            customer.CONTACT_NO = Convert.ToInt32(row["CONTACT_NO"]);
                            customer.TYPE_OF_KYC = Convert.ToString(row["TYPE_OF_KYC"]);
                            customer.REGESTRATION_TYPE = Convert.ToString(row["REGESTRATION_TYPE"]);
                            customer.GST_No = Convert.ToString(row["GST_No"]);
                            customer.COMPANY_NAME = Convert.ToString(row["COMPANY_NAME"]);
                            customer.ADDRESS = Convert.ToString(row["ADDRESS"]);
                            customer.LOCATION = Convert.ToString(row["LOCATION"]);
                            customer.PIN_CODE = Convert.ToInt32(row["PIN_CODE"]);
                            customer.STATE = Convert.ToString(row["STATE"]);
                            customer.PAN_NO = Convert.ToString(row["PAN_NO"]);
                            customer.TYPE_OF_ORGANISATION = Convert.ToString(row["TYPE_OF_ORGANISATION"]);
                            customer.ACCOUNT_NAME = Convert.ToString(row["ACCOUNT_NAME"]);
                            customer.ACCOUNT_NUMBER = Convert.ToString(row["ACCOUNT_NUMBER"]);
                            customer.ACCOUNT_TYPE = Convert.ToString(row["ACCOUNT_TYPE"]);
                            customer.IFSC_CODE = Convert.ToString(row["IFSC_CODE"]);
                            customer.NAME = Convert.ToString(row["NAME"]);
                            customer.DESIGNATION = Convert.ToString(row["DESIGNATION"]);
                            customer.MOBILE_NO = Convert.ToString(row["MOBILE_NO"]);
                            customer.EMAIL_ID = Convert.ToString(row["EMAIL_ID"]);
                            customer.PAN_NO = Convert.ToString(row["PAN_NO"]);
                            customer.TAN_NO = Convert.ToString(row["TAN_NO"]);

                         }
                   
                  }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customer;
        }
        public List<EN.GSTEntities> getGlobalGSTList(String SearchText)
        {
            List<EN.GSTEntities> GSTSummaryList = new List<EN.GSTEntities>();
            DataTable GSTDT = new DataTable();
            GSTDT = customerRepository.GetGLobalGSTList(SearchText);
            if (GSTDT != null)
            {
                foreach (DataRow row in GSTDT.Rows)
                {
                    EN.GSTEntities GSTList = new EN.GSTEntities();
                    GSTList.Id = Convert.ToString(row["ID"]);
                    GSTList.Name = Convert.ToString(row["Name"]);
                    GSTList.Address = Convert.ToString(row["Address"]);
                    GSTList.ContactNo = Convert.ToString(row["contactNo"]);
                    GSTList.ContactNo2 = Convert.ToString(row["contactNo2"]);
                    GSTList.ContactPerson = Convert.ToString(row["ContactPerson"]);
                    GSTList.ContactPerson2 = Convert.ToString(row["ContactPerson2"]);
                    GSTList.CHA = Convert.ToString(row["CHA"]);
                    //GSTList.Shipper = Convert.ToString(row["Shipper"]);
                    //GSTList.ShippingLine = Convert.ToString(row["ShippingLine"]);
                    GSTList.Importer = Convert.ToString(row["Importer"]);
                    GSTList.Customer = Convert.ToString(row["Customer"]);
                    GSTList.Vendor = Convert.ToString(row["Vendor"]);

                    GSTSummaryList.Add(GSTList);
                }
            }
            return (GSTSummaryList);
        }
        public List<EN.DocList> GetDocList(string message)
        {
            List<EN.DocList> objLRentities = new List<EN.DocList>();
            DataTable ds = new DataTable();
            ds = customerRepository.GateInDocDropDownListForUpload(message);

            if (ds.Rows.Count != 0)
            {
                foreach (DataRow row in ds.Rows)
                {
                    EN.DocList LRList = new EN.DocList();

                    LRList.DocID = Convert.ToInt32(row["DocID"]);
                    LRList.DocName = Convert.ToString(row["DocumentType"]);

                    objLRentities.Add(LRList);
                }
            }


            return objLRentities;
        }
        public EN.MasterEntities GetCutomerData(long id)
        {
            EN.MasterEntities UserData = new EN.MasterEntities();
            DataTable DT = new DataTable();
            DataTable MasterDT = new DataTable();

            DT = customerRepository.GetUserData(id);
            //  MasterDT = TrackerManager.GetMasterExistData(Name);

            if (DT != null)
            {
                foreach (DataRow row in DT.Rows)
                {
                    UserData.AGID = Convert.ToInt64(row["ID"]);
                    UserData.AGaID = Convert.ToString(row["CommonCode"]);
                    UserData.AGName = Convert.ToString(row["Name"]);
                    UserData.AGAddress = Convert.ToString(row["Address"]);
                    UserData.AGAuthPerson = Convert.ToString(row["ContactPerson"]);
                    UserData.AGAuthPersonII = Convert.ToString(row["ContactPerson2"]);
                    UserData.AGAuthPersonDesig = Convert.ToString(row["Designation"]);
                    UserData.AGAuthPersonDesigII = Convert.ToString(row["Designation2"]);
                    UserData.AGTelI = Convert.ToString(row["ContactNo1"]);
                    UserData.AGTelII = Convert.ToString(row["ContactNo2"]);
                    //UserData.AGFax = Convert.ToString(row["FaxNumber"]);
                    UserData.AGCellNo = Convert.ToString(row["cellnumber"]);
                    UserData.AGEMail = Convert.ToString(row["eMailIDs"]);
                    UserData.AGEMailII = Convert.ToString(row["eMailIDs2"]);
                    UserData.Business = Convert.ToString(row["Business"]);
                    UserData.AGWebsite = Convert.ToString(row["webSite"]);
                    //UserData.AGGrade = Convert.ToString(row["Grade"]);
                    //UserData.IsContract = Convert.ToBoolean(row["Iscontract"]);
                    UserData.IsActive = Convert.ToBoolean(row["Isactive"]);
                    UserData.CHA = Convert.ToBoolean(row["Ischa"]);
                    UserData.Customer = Convert.ToBoolean(row["ISCustomer"]);
                    //UserData.ShipLines = Convert.ToBoolean(row["ISLINE"]);
                    //UserData.shippers = Convert.ToBoolean(row["ISShipper"]);
                    UserData.Importer = Convert.ToBoolean(row["ISImporter"]);
                    UserData.TallyLedger = Convert.ToString(row["TallyLedger"]);
                    //UserData.JV = Convert.ToBoolean(row["JV"]);
                    UserData.Vendor = Convert.ToBoolean(row["Vendor"]);
                    UserData.LineAgentCode = Convert.ToString(row["CHACode"]); //CHA/ImporterCode

                    UserData.DocFileName = Convert.ToString(row["DOCFILENAME"]);
                    UserData.RunningID = Convert.ToInt32(row["RunningID"]);
                    UserData.srno = Convert.ToInt32(row["srno"]);
                    UserData.AGRemarks = Convert.ToString(row["remark"]);
                    UserData.NSDLID = Convert.ToString(row["NSDL"]);
                    UserData.IECNO = Convert.ToString(row["IEC"]);
                    UserData.AgreementDate = Convert.ToDateTime(row["agreedate"]);
                    UserData.ExpireDate = Convert.ToDateTime(row["agreeexp"]);

                }
            }
            //if (MasterDT != null)
            //{
            //    foreach (DataRow row in MasterDT.Rows)
            //    {
            //        UserData.CHA = Convert.ToBoolean(row["CHA"]);
            //        UserData.Customer = Convert.ToBoolean(row["Customer"]);
            //        UserData.ShipLines = Convert.ToBoolean(row["ShipLines"]);
            //        UserData.shippers = Convert.ToBoolean(row["shippers"]);
            //        UserData.Importer = Convert.ToBoolean(row["Importer"]);

            //    }
            //}

            return UserData;
        }
        public string UpdateMasterData(EN.MasterEntities MasterData, int userId)
        {
            string Message = "";
            DataTable dt = new DataTable();
            int i = 0;
            dt = customerRepository.UpdateMaster(MasterData.AGID,  MasterData.AGName,  MasterData.AGAddress, MasterData.AGAuthPerson,
                MasterData.AGEMail, MasterData.AGRemarks,  MasterData.CHA, MasterData.Customer, MasterData.ShipLines,
                MasterData.Importer,  MasterData.IsActive, userId,
                MasterData.Vendor, MasterData.NSDLID, MasterData.IECNO,
                MasterData.AgreementDate,
                MasterData.ExpireDate

                );
            if (dt == null)
            {
                Message = "Record not saved, Please try again!";

            }
            else
            {
                Message = "Record saved successfully.";
            }
            return Message;
        }
        public List<EN.Ext_location_Master> GetLocationList()
        {
            DataTable codeDL = new DataTable();
            codeDL = customerRepository.GetLocationDetails();


            List<EN.Ext_location_Master> isCHACode = new List<EN.Ext_location_Master>();

            if (codeDL.Rows.Count != 0)
            {
                foreach (DataRow row in codeDL.Rows)
                {
                    EN.Ext_location_Master oper = new EN.Ext_location_Master();
                    oper.LocationID = Convert.ToInt32(row["LocationID"]);
                    oper.Location = Convert.ToString(row["Location"]);
                    isCHACode.Add(oper);
                }

            }
            return isCHACode;
        }

        public List<EN.GST_Registration_Type> GetGSTRegistrationType()
        {
            DataTable codeDL = new DataTable();
            codeDL = customerRepository.GetGSTRegistrationType();


            List<EN.GST_Registration_Type> isCHACode = new List<EN.GST_Registration_Type>();

            if (codeDL.Rows.Count != 0)
            {
                foreach (DataRow row in codeDL.Rows)
                {
                    EN.GST_Registration_Type oper = new EN.GST_Registration_Type();
                    oper.RGID = Convert.ToInt32(row["RGID"]);
                    oper.RGType = Convert.ToString(row["RGType"]);
                    isCHACode.Add(oper);
                }

            }
            return isCHACode;
        }
        public List<EN.Ext_location_Master> GetCustomerLocationList(Int64 id)
        {
            DataTable dt = new DataTable();
            dt = customerRepository.GetCustomerLocationList(id);


            List<EN.Ext_location_Master> DL = new List<EN.Ext_location_Master>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    EN.Ext_location_Master locationList = new EN.Ext_location_Master();
                    locationList.LocationID = Convert.ToInt16(row["LocationID"]);
                    locationList.Location = Convert.ToString(row["Location"]);
                    locationList.GSTID = Convert.ToInt64(row["GSTID"]);
                    DL.Add(locationList);
                }

            }
            return DL;
        }
        public List<EN.StateMaster> getStateCode(string GSTNO)
        {
            DataTable codeDL = new DataTable();
            codeDL = customerRepository.GetStateCode(GSTNO);


            List<EN.StateMaster> isCHACode = new List<EN.StateMaster>();

            if (codeDL.Rows.Count != 0)
            {
                foreach (DataRow row in codeDL.Rows)
                {
                    EN.StateMaster oper = new EN.StateMaster();
                    oper.State_Code = Convert.ToString(row["state_code"]);
                    oper.State = Convert.ToString(row["State"]);
                    isCHACode.Add(oper);
                }

            }
            return isCHACode;
        }
        public string AddLocationDetails(EN.LocationMaster MasterData, int userId)
        {
            string Message = "";
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[16];
            sqlParameters[0] = new SqlParameter("@Common_ID", MasterData.Common_ID);
 
            sqlParameters[1] = new SqlParameter("@Name", MasterData.Name);
            sqlParameters[2] = new SqlParameter("@GSTIn_uniqID", MasterData.GSTIn_uniqID);
            sqlParameters[3] = new SqlParameter("@RegistrationType", MasterData.TyepReg);
            sqlParameters[4] = new SqlParameter("@RegDate", MasterData.RegDate);
            sqlParameters[5] = new SqlParameter("@PANNo", MasterData.PANNo);
            sqlParameters[6] = new SqlParameter("@LocationID", MasterData.LocationID);
            sqlParameters[7] = new SqlParameter("@State", MasterData.State);
            sqlParameters[8] = new SqlParameter("@state_Code", MasterData.state_Code);
            sqlParameters[9] = new SqlParameter("@GSTAddress", MasterData.GSTAddress);
            sqlParameters[10] = new SqlParameter("@Emailid", MasterData.Emailid);
            sqlParameters[11] = new SqlParameter("@MobNo", MasterData.MobNo);
            sqlParameters[12] = new SqlParameter("@userId", userId);
            sqlParameters[13] = new SqlParameter("@IsCopyID", MasterData.IsCopy);
            sqlParameters[14] = new SqlParameter("@GSTID", MasterData.GSTID);
            sqlParameters[15] = new SqlParameter("@PINCODE", MasterData.PINCODE);
            
    



              dt = commonConnectivity.ExecuteStoredProcedures("USP_LocationGSTInsertDetails", sqlParameters);


            if (dt.Rows.Count == 0)
            {
                Message = "Record not save, Please try again!";

            }
            else
            {
                Message = "Recode saved successfully!";
            }
            return Message;
        }
        public EN.LocationMaster getLocationDataCustomerWise(Int32 LocationID, Int64 Common_ID, Int64 GSTID)
        {
            DataTable dt = new DataTable();
            dt = customerRepository.GetGSTLocationWiseData(LocationID, Common_ID, GSTID);


            EN.LocationMaster DL = new EN.LocationMaster();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    DL.LocationID = Convert.ToInt16(row["LocationID"]);
                    DL.TyepReg = Convert.ToString(row["TyepReg"]);
                    DL.Emailid = Convert.ToString(row["Emailid"]);
                    DL.GSTIn_uniqID = Convert.ToString(row["GSTIn_uniqID"]);
                    DL.PANNo = Convert.ToString(row["panno"]);
                    DL.GSTregDate = Convert.ToString(row["RegDate"]);
                    DL.State = Convert.ToString(row["State"]);
                    DL.state_Code = Convert.ToString(row["state_Code"]);
                    DL.GSTAddress = Convert.ToString(row["GSTAddress"]);
                    DL.MobNo = Convert.ToString(row["MobNo"]);
                    DL.RGID = Convert.ToInt32(row["RGID"]);
                    DL.GSTID = Convert.ToInt64(row["GSTID"]);
                    DL.PINCODE = Convert.ToString(row["PINCODE"]);

                    if (Convert.ToString(row["Is_Active"]) == "True")
                    {
                        DL.ISActive = "1";
                    }
                    else
                    {
                        DL.ISActive = "0";
                    }

                }

            }
            return DL;
        }
    }
}
