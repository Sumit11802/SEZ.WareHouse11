using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC.Domain.Model;
using MVC.Services;
using MVC.Services.Interface;
using Newtonsoft.Json;
using BE = MVC.Domain.Model;
using DB = MVC.DB.CommonService;
namespace MVC.Web.Controllers
{
    public class GenerateSSRController : Controller
    {
        public MasterService masterService = new MasterService();
        public GenerateSSRService generatessrService = new GenerateSSRService();
        DB.CommonService db = new DB.CommonService();


        public ActionResult GenerateSSR()
        {
            List<BE.TariffEnt> AccountHead = new List<BE.TariffEnt>();
            AccountHead = masterService.GetBondAccountList();
            ViewBag.AccountHeadList = new SelectList(AccountHead, "AccountID", "AccountName");

            List<SelectListModel> GetWotype = masterService.GetWo_Type();
            ViewBag.GetWotype = new SelectList(GetWotype, "Name", "Name");

            return View();
        }

        public JsonResult AddGenerateSSRDetails(GENERATESSR generatessr, List<BE.ContainerDetails> SelectedData)
        {
            string strSQL = "";
            DataTable InsertDL = new DataTable();
            DataTable dt = new DataTable();
            //LoginUserDetail loginUserDetail = (LoginUserDetail)Session["LoginUserDetail"];
            var date = DateTime.Now;
            generatessr.ADDED_BY = 1;
            string result;

            //string result = generatessrService.AddGenerateSSRDetails(generatessr);


            strSQL = "";
            strSQL = "";
            strSQL = "USP_INSERT_SSR_WORK_ORDER '" + generatessr.SSR_TYPE + "','" + generatessr.CHA + "','" + generatessr.CUSTOMER + "','"
                + generatessr.VENDOR_NAME + "','" + generatessr.SSR_MODE + "','"
                + generatessr.ADDED_BY + "'";

            dt = db.getData(strSQL);
            result = dt.Rows[0][0].ToString();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ContainerNo");
            dataTable.Columns.Add("ContainerSize");
            dataTable.Columns.Add("ContainerType");
            dataTable.Columns.Add("CargoType");
            dataTable.Columns.Add("SealNo");
            foreach (BE.ContainerDetails item in SelectedData)
            {
                DataRow row = dataTable.NewRow();
                row["ContainerNo"] = item.ContainerNo;
                row["Qty"] = item.Qty;
                row["Weight"] = item.Weight;
                row["Amount"] = item.Amount;
                row["TotalAmount"] = item.TotalAmount;

                dataTable.Rows.Add(row);


            }
            for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
            {
                strSQL = "";
                strSQL = "USP_INSERT_SSR_WORK_ORDER_D '" + result + "','" + dataTable.Rows[i].Field<string>("ContainerNo") + "','" + dataTable.Rows[i].Field<string>("Qty") + "','" + dataTable.Rows[i].Field<string>("Weight") + "','" + dataTable.Rows[i].Field<string>("Amount") + "','" + dataTable.Rows[i].Field<string>("TotalAmount") + "'";

                InsertDL = db.getData(strSQL);


            }

            if (result != "")
            {
                string message = "SUCCESS";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {

                string message = "FAILED";
                return Json(message, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult getInvoiceWorkOrderDet(string data2)
        {
            string Message = "";

            DataTable ds = new DataTable();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            BE.WorkOrderEntities cHA = new BE.WorkOrderEntities();
            List<BE.WorkOrderEntities> ContainerList = new List<BE.WorkOrderEntities>();
            List<BE.WorkOrderEntities> ItemList = new List<BE.WorkOrderEntities>();
            //dt = db.sub_GetDatatable("GetImportSSRValidation '" + SSRType + "','" + IGMNo + "','" + ItemNo + "','" + ContainerNo + "'");




            dt = db.getData("USP_SSRShow '" + data2 + "'");


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    BE.WorkOrderEntities workOrderEntities = new BE.WorkOrderEntities();
                    workOrderEntities.ContainerNo = row["CONTAINER_NO"].ToString();
                    workOrderEntities.Type = row["ContainerType"].ToString();
                    workOrderEntities.CargoType = row["Cargotype"].ToString();

                    workOrderEntities.Weight = row["WEIGHT"].ToString();
                    workOrderEntities.PackageType = row["PACKAGE_TYPE"].ToString();
                    workOrderEntities.Rate_Amt = Convert.ToDouble(row["TotalAmount"]);
                    workOrderEntities.Quantity = Convert.ToDouble(row["QTY"]);
                    workOrderEntities.Amt = Convert.ToDouble(row["Amount"]);
                    workOrderEntities.VendorID = Convert.ToInt32(row["VendorID"]);
                    workOrderEntities.AgencyName = Convert.ToString(row["CustomerName"]);
                    workOrderEntities.CHAName = Convert.ToString(row["CHAName"]);
                    ContainerList.Add(workOrderEntities);
                }

            }



            var returnField = new { ContainerData = ContainerList };

            return new JsonResult() { Data = returnField, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public ActionResult GenerateWorkOrder()
        {
            List<BE.TariffEnt> AccountHead = new List<BE.TariffEnt>();
            AccountHead = masterService.GetBondAccountList();
            ViewBag.AccountHeadList = new SelectList(AccountHead, "AccountID", "AccountName");

            List<BE.SelectListModel> GetWotype = new List<BE.SelectListModel>();

            GetWotype = masterService.GetWo_Type1();
            ViewBag.GetWotype = new SelectList(GetWotype, "Name", "Name");

            List<SelectListModel> Equipment2 = new List<SelectListModel>();
            Equipment2 = masterService.EquipmentNoList();
            ViewBag.EquipmentNoList1 = new SelectList(Equipment2, "ID", "Name");
            ViewBag.EquipmentNoList = JsonConvert.SerializeObject(Equipment2);



            return View();
        }
        public JsonResult GetWorkOrderlist(string data2)
        {
            string Message = "";

            DataTable ds = new DataTable();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            BE.WorkOrderEntities cHA = new BE.WorkOrderEntities();
            List<BE.WorkOrderEntities> ContainerList = new List<BE.WorkOrderEntities>();
            List<BE.WorkOrderEntities> ItemList = new List<BE.WorkOrderEntities>();

            dt = db.getData("USP_WorkOrderShow '" + data2 + "'");


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    BE.WorkOrderEntities workOrderEntities = new BE.WorkOrderEntities();
                    workOrderEntities.ContainerNo = row["CONTAINER_NO"].ToString();

                    workOrderEntities.Size = row["Size"].ToString();

                    workOrderEntities.Weight = row["WEIGHT"].ToString();
                    workOrderEntities.PackageType = row["PACKAGE_TYPE"].ToString();

                    workOrderEntities.Quantity = Convert.ToDouble(row["QTY"]);
                    workOrderEntities.VehicleNo = Convert.ToString(row["VEHICLE_NO"]);
                    workOrderEntities.EquipmentNo = Convert.ToString(row["EquipmentNo"]);
                    workOrderEntities.VendorID = Convert.ToInt32(row["VendorID"]);
                    workOrderEntities.AgencyName = Convert.ToString(row["CustomerName"]);
                    workOrderEntities.CHAName = Convert.ToString(row["CHAName"]);
                    ContainerList.Add(workOrderEntities);
                }

            }



            var returnField = new { ContainerData = ContainerList };

            return new JsonResult() { Data = returnField, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public JsonResult SaveWorkOrder(GENERATESSR generatessr, List<BE.ContainerDetails> SelectedData)
        {
            string strSQL = "";
            string result = "";
            DataTable InsertDL = new DataTable();
            DataTable dt = new DataTable();
            //LoginUserDetail loginUserDetail = (LoginUserDetail)Session["LoginUserDetail"];
            var date = DateTime.Now;
            generatessr.ADDED_BY = 1;

            //string result = generatessrService.SaveWorkOrdarDetails(generatessr);
            strSQL = "";
            strSQL = "";
            strSQL = "USP_INSERT_WORK_ORDER_M '" + generatessr.SSR_TYPE + "','" + generatessr.CHA + "','" + generatessr.CUSTOMER + "','"
                + generatessr.VENDOR_NAME + "','" + generatessr.SSR_MODE + "','"
                + generatessr.ADDED_BY + "'";

            dt = db.getData(strSQL);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    result = Convert.ToString(row["WO_NO"]);
                }
            }

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ContainerNo");
            dataTable.Columns.Add("ContainerSize");
            dataTable.Columns.Add("Qty");
            dataTable.Columns.Add("Weight");
            dataTable.Columns.Add("VehicleNo");
            dataTable.Columns.Add("EquipmentType");
            dataTable.Columns.Add("EquipmentNo");
            foreach (BE.ContainerDetails item in SelectedData)
            {
                DataRow row = dataTable.NewRow();
                row["ContainerNo"] = item.ContainerNo;
                row["ContainerSize"] = item.ContainerSize;
                row["Qty"] = item.Qty;
                row["Weight"] = item.Weight;
                row["VehicleNo"] = item.VehicleNo;
                row["EquipmentType"] = item.EquipmentType;
                row["EquipmentNo"] = item.EquipmentNo;

                dataTable.Rows.Add(row);


            }
            for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
            {
                strSQL = "";
                strSQL = "USP_INSERT_WORK_ORDER_D '" + result + "','" + dataTable.Rows[i].Field<string>("ContainerNo") + "','" + dataTable.Rows[i].Field<string>("ContainerSize") + "','"
                    + dataTable.Rows[i].Field<string>("Qty") + "','" + dataTable.Rows[i].Field<string>("Weight") + "','"
                    + dataTable.Rows[i].Field<string>("VehicleNo") + "','" + dataTable.Rows[i].Field<string>("EquipmentType") + "','" + dataTable.Rows[i].Field<string>("EquipmentNo") + "'";


                InsertDL = db.getData(strSQL);


            }

            if (result != "")
            {
                string message = "SUCCESS";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {

                string message = "FAILED";
                return Json(message, JsonRequestBehavior.AllowGet);
            }

        }
    }
}