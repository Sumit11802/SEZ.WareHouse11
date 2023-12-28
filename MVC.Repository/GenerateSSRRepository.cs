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
    public class GenerateSSRRepository : IGenerateSSRRepository
    {


        private CommonService commonConnectivity = new CommonService();


        public DataTable AddGenerateSSRDetails
            (GENERATESSR generatessr)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@SSRTYPE", generatessr.SSR_TYPE);
            sqlParameters[1] = new SqlParameter("@CHAID", generatessr.CHA);
            sqlParameters[2] = new SqlParameter("@CUSTID", generatessr.CUSTOMER);
        
            sqlParameters[3] = new SqlParameter("@VENDORID", generatessr.VENDOR_NAME);
            sqlParameters[4] = new SqlParameter("@SSR_MODE", generatessr.SSR_MODE);

            dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_WORK_ORDER_M]", sqlParameters);
            return dt;
        }
    }
}
