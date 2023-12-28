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
using MVC.DB;
namespace MVC.Repository
{
    public class MasterRepository : IMasterRepository
    {
        private CommonService commonConnectivity = new CommonService();
        DB.CommonService db = new DB.CommonService();
        public DataTable BankMaster()
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[0];


            dt = commonConnectivity.ExecuteStoredProcedures("[uspGetAllBankList]", sqlParameters);

            return dt;

        }

        public DataTable AddBank(Banks bank)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[14];
            sqlParameters[0] = new SqlParameter("@ID", bank.Id);
            sqlParameters[1] = new SqlParameter("@BankName", bank.BankName);
            sqlParameters[2] = new SqlParameter("@ShortCode", bank.ShortCode);
            sqlParameters[3] = new SqlParameter("@IFSC", bank.IFSCCode);
            sqlParameters[4] = new SqlParameter("@IsCancel", bank.IsCancel);
            sqlParameters[5] = new SqlParameter("@IsIMPS", bank.IsIMPS);
            sqlParameters[6] = new SqlParameter("@IsNEFT", bank.IsNEFT);
            sqlParameters[7] = new SqlParameter("@IsRTGS", bank.IsRTGS);
            sqlParameters[8] = new SqlParameter("@IsActive", bank.IsActive);
            sqlParameters[9] = new SqlParameter("@IsDown", bank.IsDown);
            sqlParameters[10] = new SqlParameter("@AddedBy", bank.AddedBy);
            sqlParameters[11] = new SqlParameter("@ModifiedBy", bank.ModifiedBy);
            sqlParameters[12] = new SqlParameter("@AddedOn", bank.AddedOn);
            sqlParameters[13] = new SqlParameter("@ModifiedOn", bank.ModifiedOn);


            dt = commonConnectivity.ExecuteStoredProcedures("[uspAddNewBank]", sqlParameters);
            return dt;
        }

        public DataTable EditBank(Banks bank)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[14];
            sqlParameters[0] = new SqlParameter("@ID", bank.Id);
            sqlParameters[1] = new SqlParameter("@BankName", bank.BankName);
            sqlParameters[2] = new SqlParameter("@ShortCode", bank.ShortCode);
            sqlParameters[3] = new SqlParameter("@IFSC", bank.IFSCCode);
            sqlParameters[4] = new SqlParameter("@IsCancel", bank.IsCancel);
            sqlParameters[5] = new SqlParameter("@IsIMPS", bank.IsIMPS);
            sqlParameters[6] = new SqlParameter("@IsNEFT", bank.IsNEFT);
            sqlParameters[7] = new SqlParameter("@IsRTGS", bank.IsRTGS);
            sqlParameters[8] = new SqlParameter("@IsActive", bank.IsActive);
            sqlParameters[9] = new SqlParameter("@IsDown", bank.IsDown);
            sqlParameters[10] = new SqlParameter("@AddedBy", bank.AddedBy);
            sqlParameters[11] = new SqlParameter("@ModifiedBy", bank.ModifiedBy);
            sqlParameters[12] = new SqlParameter("@AddedOn", bank.AddedOn);
            sqlParameters[13] = new SqlParameter("@ModifiedOn", bank.ModifiedOn);


            dt = commonConnectivity.ExecuteStoredProcedures("[uspAddNewBank]", sqlParameters);
            return dt;
        }

        public DataTable DeleteBank(int Id)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", Id);

            dt = commonConnectivity.ExecuteStoredProcedures("[uspDeleteBank]", sqlParameters);
            return dt;
        }

        public DataTable AddServiceComplains(string requestID, string transactionID, string userID, string comment)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@REQUESTID", requestID);
            sqlParameters[1] = new SqlParameter("@REGISTEREDBY", userID);
            sqlParameters[2] = new SqlParameter("@COMPLAINERCOMMENT", comment);
            sqlParameters[3] = new SqlParameter("@TRANSACTIONID", transactionID);

            dt = commonConnectivity.ExecuteStoredProcedures("[uspAddServiceComplains]", sqlParameters);
            return dt;
        }

        public DataTable GetComplainsHistory(double userid, int role, DateTime? from, DateTime? to, string filter, string condition)
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@intUserID", userid);
            sqlParameters[1] = new SqlParameter("@intRoleID", role);
            sqlParameters[2] = new SqlParameter("@strFrom", from);
            sqlParameters[3] = new SqlParameter("@strTo", to);
            sqlParameters[4] = new SqlParameter("@strFilter", filter);
            sqlParameters[5] = new SqlParameter("@strCondition", condition);
            dt = commonConnectivity.ExecuteStoredProcedures("[uspGetComplainsHistory]", sqlParameters);

            return dt;

        }



        public DataTable GetBeneficiaryDetails(string customerid, int typeid)
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[2];

            sqlParameters[0] = new SqlParameter("@userid", customerid);
            sqlParameters[1] = new SqlParameter("@typeid", typeid);

            dt = commonConnectivity.ExecuteStoredProcedures("[uspGetBeneficiary]", sqlParameters);
            return dt;
        }

        public DataTable ValidateBeneficiaryDuplicate(string account, string associateuser)
        {
            DataTable dt = new DataTable();

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@account", account);
            sqlParameters[1] = new SqlParameter("@associateduser", associateuser);

            dt = commonConnectivity.ExecuteStoredProcedures("[uspValidateBeneficiaryDuplicate]", sqlParameters);
            return dt;
        }

        
        //<-----------End PaymentRepository ---------->
        //-----------------------Master
        public DataTable SaveProduct(string ProductName, string Category, string Code, String SKU,
            String Prize, string Desc, int IsActive)
        {

            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = new SqlParameter("@ProductName", ProductName);
            sqlParameters[1] = new SqlParameter("@Category", Category);
            sqlParameters[2] = new SqlParameter("@Code", Code);
            sqlParameters[3] = new SqlParameter("@SKU", SKU);
            sqlParameters[4] = new SqlParameter("@Prize", Prize);
            sqlParameters[5] = new SqlParameter("@Desc", Desc);
            sqlParameters[6] = new SqlParameter("@IsActive", IsActive);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_Product]", sqlParameters);
            return dt;
        }
        public DataTable SaveState(string State, string Code, int IsActive)
        {

            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@State", State);
            sqlParameters[1] = new SqlParameter("@Code", Code);
            sqlParameters[2] = new SqlParameter("@IsActive", IsActive);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_StateMaster]", sqlParameters);
            return dt;
        }
        public DataTable SaveCity(int State, String City, string Code,int IsActive)
        {

            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@State", State);
            sqlParameters[1] = new SqlParameter("@City", City);
            sqlParameters[2] = new SqlParameter("@Code", Code);
            sqlParameters[3] = new SqlParameter("@IsActive", IsActive);

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_CityMaster]", sqlParameters);
            return dt;
        }
        public DataTable SaveBranch(string State, String City, string Branch, string Code, int IsActive)
        {

            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@State", State);
            sqlParameters[1] = new SqlParameter("@City", City);
          
            sqlParameters[2] = new SqlParameter("@Branch", Branch);
            sqlParameters[3] = new SqlParameter("@Code", Code);
            sqlParameters[4] = new SqlParameter("@IsActive", IsActive);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_BranchMaster]", sqlParameters);
            return dt;
        }
        public DataTable SaveThoughtsOfDay(string TOD ,int IsActive)
        {

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@TOD", TOD);
            sqlParameters[1] = new SqlParameter("@IsActive", IsActive);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_Thoughts]", sqlParameters);
            return dt;
        }
        public DataTable GetState()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[usp_state]", sqlParameters);
            return dt;
        }
        public DataTable GetCities()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[usp_City]", sqlParameters);
            return dt;
        }
        public DataTable GetBranch()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[usp_Branch]", sqlParameters);
            return dt;
        }
        public DataTable GetReport(string fromdate, string todate, string Criteria, int Place)
        {
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@fromdate", fromdate);
            sqlParameters[1] = new SqlParameter("@todate", todate);
            sqlParameters[2] = new SqlParameter("@Criteria", Criteria);
            sqlParameters[3] = new SqlParameter("@Place", Place);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[USP_GetReport]", sqlParameters);
            return dt;
        }

        public DataTable GetResultSetByTableName(string tablename)
        {
            
            DataTable dt = commonConnectivity.GetSpecificData(tablename);
            return dt;
        }


        public DataTable GetUserDetailsByRoleID(int roleid)
        {

          
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@RoleID", roleid);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspFetchDatabaseAllUser]", sqlParameters);

            return dt;
        }

        public DataTable GetContainerType()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspSelect_Container_Type]", sqlParameters);

            return dt;
        }

        public DataTable GetWo_Type()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[USP_SSRType_DropDown]", sqlParameters);

            return dt;
        }

        public DataTable GetCargoType()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspSelect_Cargo_Type]", sqlParameters);

            return dt;
        }


        public DataTable GetImpoerterList()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspSelect_ImporterName]", sqlParameters);

            return dt;
        }
        public DataTable GetCHAList()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspSelect_CHAName]", sqlParameters);

            return dt;
        }
        public DataTable GetShipperList()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspSelect_ShipperName]", sqlParameters);

            return dt;
        }
        public DataTable GetForwarderList()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspSelect_ForwarderName]", sqlParameters);

            return dt;
        }

        public DataTable getAutoExporter(string prefixText, string CustomerType)
        {
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@prefixText", prefixText);
            sqlParameters[1] = new SqlParameter("@CustomerType", CustomerType);

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[USP_GetshippernameList]", sqlParameters);

            return dt;
        }
        public DataTable GetDropdownList(string Table, string Column, string Condition, string OrderBy)
        {
            DataTable DT = new DataTable();
           
            DT = db.getData("get_sp_table  '" + Table + "','" + Column + "','" + Condition + "','" + OrderBy + "'");
            return DT;
        }


        public DataTable GetUpdatePackageMaster(int CodeID)
        {


            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@CodeID", CodeID);
    

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[USP_GetUpdatePackageMaster]", sqlParameters);


            return dt;
        }
        public DataTable EquipmentNoList()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[USP_GetEquipment_NO]", sqlParameters);

            return dt;
        }
        public DataTable GetWo_Type1()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[USP_WOType_DropDown]", sqlParameters);

            return dt;
        }

        public DataTable SavePKGSDetails(int EntryID, string PKGCode, string PKGSName, bool IsActive, int AddedBy)
        {

            SqlParameter[] sqlParameters = new SqlParameter[5];

            sqlParameters[0] = new SqlParameter("@CodeID", EntryID);
            sqlParameters[1] = new SqlParameter("@PKGCode", PKGCode);
            sqlParameters[2] = new SqlParameter("@PKGName", PKGSName);
            sqlParameters[3] = new SqlParameter("@IsActive", IsActive);
            sqlParameters[4] = new SqlParameter("@AddedBy", AddedBy);
         

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[sp_InsertPackages]", sqlParameters);

            return dt;
        }
    }
}
