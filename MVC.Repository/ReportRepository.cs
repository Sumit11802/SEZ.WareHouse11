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
    public class ReportRepository : IReportRepository
    {

        private CommonService commonConnectivity = new CommonService();

        public DataTable FetchCustomerList(int category,DateTime? fromdate, DateTime? todate)
        {

            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@category", category);
            sqlParameters[1] = new SqlParameter("@fromdate", fromdate);
            sqlParameters[2] = new SqlParameter("@todate", todate);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspPortalFetchCustomer]", sqlParameters);
            return dt;
        }

        public DataTable FetchRegularCustomerList(int category, DateTime? fromdate, DateTime? todate)
        {

            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@category", category);
            sqlParameters[1] = new SqlParameter("@fromdate", fromdate);
            sqlParameters[2] = new SqlParameter("@todate", todate);

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspPortalFetchRegularCustomer]", sqlParameters);
            return dt;
        }

        public DataTable FetchCampaignList(int category, DateTime? fromdate, DateTime? todate)
        {

            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@category", category);
            sqlParameters[1] = new SqlParameter("@fromdate", fromdate);
            sqlParameters[2] = new SqlParameter("@todate", todate);

            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspFetchCampaignList]", sqlParameters);
            return dt;
        }

        public DataTable FetchUserList(int category, DateTime? fromdate, DateTime? todate)
        {

            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@category", category);
            sqlParameters[1] = new SqlParameter("@fromdate", fromdate);
            sqlParameters[2] = new SqlParameter("@todate", todate);
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspPortalFetchUser]", sqlParameters);
            return dt;
        }

        public int ActionOnUserAccount(int userid, int action)
        {
            string sql = "";

            sql = "Update UserDetails set IsActive=" + action + " where userid="+userid;


           int result = commonConnectivity.ExecuteNonQuery(sql);
           return result;
        }
    }
}
