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
    public class GateRepository : IGateRepository
    {


        private CommonService commonConnectivity = new CommonService();


        public DataTable AddGateEntryDetails(GateInModel gateInModel)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[17];
            sqlParameters[0] = new SqlParameter("@GATE_PASS_NO", gateInModel.GATE_PASS_NO);
            sqlParameters[1] = new SqlParameter("@IN_DATE_TIME", gateInModel.IN_DATE_TIME);
            sqlParameters[2] = new SqlParameter("@CONTAINER_NAME", gateInModel.CONTATINER_NAME);
            sqlParameters[3] = new SqlParameter("@CONTATINER_NO", gateInModel.CONTATINER_NO);
            sqlParameters[4] = new SqlParameter("@SIZE", gateInModel.SIZE);
            sqlParameters[5] = new SqlParameter("@TYPE", gateInModel.TYPE);
            sqlParameters[6] = new SqlParameter("@CARGO_TYPE", gateInModel.CARGO_TYPE);
            sqlParameters[7] = new SqlParameter("@PKGS", gateInModel.PKGS);
            sqlParameters[8] = new SqlParameter("@WEIGHT", gateInModel.WEIGHT);
            sqlParameters[9] = new SqlParameter("@VEHICLE_NO", gateInModel.VEHICLE_NO);
            sqlParameters[10] = new SqlParameter("@TRANSPORTER", gateInModel.TRANSPORTER);
            sqlParameters[11] = new SqlParameter("@DRIVER_NAME", gateInModel.DRIVER_NAME);
            sqlParameters[12] = new SqlParameter("@EIR_DATE_TIME", gateInModel.EIR_DATE_TIME);
            sqlParameters[13] = new SqlParameter("@SCAN_STATUS", gateInModel.SCAN_STATUS);
            sqlParameters[14] = new SqlParameter("@SCAN_TYPE", gateInModel.SCAN_TYPE);
            sqlParameters[15] = new SqlParameter("@REMARKS", gateInModel.REMARKS);
            sqlParameters[16] = new SqlParameter("@ADDED_BY", gateInModel.ADDED_BY);


            dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_INBOUND_IN]", sqlParameters);
            return dt;
        }
    }
}
