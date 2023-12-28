using MVC.DB;
using MVC.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Domain.Model;

namespace MVC.Repository
{
    public class AccountRepository : IAccountRepository
    {

        private CommonService commonConnectivity = new CommonService();
        //public AccountRepository(ICommonConnectivity commonConnectivity)
        //{
        //    this.commonConnectivity = commonConnectivity;
        //}
        public DataTable Login(string username, string password, string role)
        {
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@UserName", username);
            sqlParameters[1] = new SqlParameter("@UserPass", password);
          

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspUserLogin]", sqlParameters);

            return dt;
        }



        //public DataTable UserLogin(User user)
        //{
        //    SqlParameter[] sqlParameters = new SqlParameter[8];
        //    sqlParameters[0] = new SqlParameter("@UserName", user.UserName);
        //    sqlParameters[1] = new SqlParameter("@", password);
        //    return 
        //}

        public DataTable UserRights()
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];
            //sqlParameters[0] = new SqlParameter("@UserID", userid);

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspGetUserRights]", sqlParameters);

            return dt;
        }

        public DataTable GetSideMenu(int userid)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@UserID", userid);

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspGetUserMenu]", sqlParameters);

            return dt;
        }

        public DataTable ResetPassword(string userid, int loginid, string otp, string action)
        {
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@intUserID", userid);
            sqlParameters[1] = new SqlParameter("@intLoginID", loginid);
            sqlParameters[2] = new SqlParameter("@strOTP", otp);
            sqlParameters[3] = new SqlParameter("@Action", action);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspForgetPassword]", sqlParameters);
            return dt;
        }

        public string SaveUserRight(DataTable UserRightData, int UserID)
        {
            string Message = "";
         
            Dictionary<object, object> parameterList = new Dictionary<object, object>();

            parameterList.Add("UserId", UserID);

            int i = commonConnectivity.AddTypeTableData("USP_InsUserRights", parameterList, UserRightData, "UserRightsDT", "@UserRightsDT");

            if (i > 0)
            {
                Message = "Rights Assing Successfully";
            }
            else
            {
                Message = "Rights Not Assing Successfully";
            }
            return Message;
        }

        public DataTable UserNameFill()
        {
            DataTable LoginDT = new DataTable();
            string sqlQuery = "Select  UserID, UserName From UserDetails where IsActive = 1 UNION Select UserID, UserName From UserDetails where IsActive = 1 Order By UserID";
            LoginDT = commonConnectivity.getData(sqlQuery);
            // LoginDT = db.sub_GetDatatable("USP_FetchVesselDetal '" + viaNO + "'");

            return LoginDT;
        }

        public DataTable EditUser(string UserID)
        {
            DataTable DT = new DataTable();
          
            string sqlQuery = "USP_Update_Create_User '" + UserID + "'";
            DT = commonConnectivity.getData(sqlQuery);
            return DT;
        }

        public DataTable CheckFirstName(string FirstName)
        {


            DataTable DT = new DataTable();

            string sqlQuery = "USP_CheckUserName '" + FirstName + "'";
            DT = commonConnectivity.getData(sqlQuery);


            return DT;
        }
    }
}
