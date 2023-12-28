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
    public class InBoundRepository  : IInboundRepository
    {
        private CommonService commonConnectivity = new CommonService();
        
        private object _commonService;

        public DataTable AddInboundEntry(InboundModel inboundModel )
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[30];

            sqlParameters[0] = new SqlParameter("@RUNNING_NO", inboundModel.RUNNING_NO);
            sqlParameters[1] = new SqlParameter("@WORK_YEAR", inboundModel.WORK_YEAR);
            //sqlParameters[2] = new SqlParameter("@SHIPMENT_NUMBER", inboundModel.SHIPMENT_NUMBER);
            sqlParameters[2] = new SqlParameter("@INBOUND_TYPE_ID", inboundModel.INBOUND_TYPE_ID);
            sqlParameters[3] = new SqlParameter("@MODE_CATEGORY", inboundModel.MODE_CATEGORY);
            sqlParameters[4] = new SqlParameter("@ACTIVITY_TYPE", inboundModel.ACTIVITY_TYPE);
            sqlParameters[5] = new SqlParameter("@REQUEST_NO", inboundModel.REQUEST_NO);
            sqlParameters[6] = new SqlParameter("@BOE_NO", inboundModel.BOE_NO);
            sqlParameters[7] = new SqlParameter("@BOE_DATE", inboundModel.BOE_DATE);
            sqlParameters[8] = new SqlParameter("@INVOICE_NO", inboundModel.INVOICE_NO);
            sqlParameters[9] = new SqlParameter("@INVOICE_DATE", inboundModel.INVOICE_DATE);
            sqlParameters[10] = new SqlParameter("@TP_NO", inboundModel.TP_NO);
            sqlParameters[11] = new SqlParameter("@TP_DATE", inboundModel.TP_DATE);
            sqlParameters[12] = new SqlParameter("@POL", inboundModel.POL);
            sqlParameters[13] = new SqlParameter("@COUNTRY_OF_ORIGIN", inboundModel.COUNTRY_OF_ORIGIN);
            sqlParameters[14] = new SqlParameter("@BL_NO", inboundModel.BL_NO);
            sqlParameters[15] = new SqlParameter("@HBL_NO", inboundModel.HBL_NO);
            sqlParameters[16] = new SqlParameter("@CARGO_DESC", inboundModel.CARGO_DESC);
            sqlParameters[17] = new SqlParameter("@QTY", inboundModel.QTY);
            sqlParameters[18] = new SqlParameter("@PACKAGE_TYPE", inboundModel.PACKAGE_TYPE);
            sqlParameters[19] = new SqlParameter("@WEIGHT", inboundModel.WEIGHT);
            sqlParameters[20] = new SqlParameter("@DUTY", inboundModel.DUTY);
            sqlParameters[21] = new SqlParameter("@VALUE", inboundModel.VALUE);
            sqlParameters[22] = new SqlParameter("@IMPORTER_ID", inboundModel.IMPORTER_ID);
            sqlParameters[23] = new SqlParameter("@CHA_ID", inboundModel.CHA_ID);
            sqlParameters[24] = new SqlParameter("@CUSTOMER_ID", inboundModel.CUSTOMER_ID);
            sqlParameters[25] = new SqlParameter("@EXPORTER_ID", inboundModel.EXPORTER_ID);
            sqlParameters[26] = new SqlParameter("@IGM_NO", inboundModel.IGM_NO);
            sqlParameters[27] = new SqlParameter("@IGM_DATE", inboundModel.IGM_DATE);
            sqlParameters[28] = new SqlParameter("@ITEM_NO", inboundModel.ITEM_NO);
            sqlParameters[29] = new SqlParameter("@REMARKS", inboundModel.REMARKS);

            dt = commonConnectivity.ExecuteStoredProcedures("[USP_INSERT_INBOUND_M]", sqlParameters);

        
            
            return dt;
        }
        int IInboundRepository.AddInboundEntry(InboundModel inboundModel)
        {
            throw new NotImplementedException();
        }


        public List<SelectListModel> GetCargoType()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspSelect_Cargo_Type]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "Select Cargo_Type";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    lstModel.ID = Convert.ToInt32(row["CargoID"].ToString());

                    lstModel.Name = Convert.ToString(row["CargoType"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }


        public List<SelectListModel> GetContainerType()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();

            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = commonConnectivity.ExecuteStoredProcedures("[uspSelect_Container_Type]", sqlParameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "Select Container_Type";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    lstModel.ID = Convert.ToInt32(row["ContainerID"].ToString());

                    lstModel.Name = Convert.ToString(row["ContainerType"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }
    }
}
