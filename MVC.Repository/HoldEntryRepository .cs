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
    public class HoldEntryRepository : IAccountRepository
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
    }
}
