using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using MVC.Domain.Model;
using MVC.Services;
using CD = MVC.DB;
using BE = MVC.Domain.Model;
using System;
using DB = MVC.DB.CommonService;
using Newtonsoft.Json;

namespace MVC.Web.Controllers
{
    public class InboundController : Controller
    {

        public MasterService masterService = new MasterService();
        public InboundService inboundService = new InboundService();

        DB.CommonService db = new DB.CommonService();
        public ActionResult InboundEntry()
        {

            List<SelectListModel> GetContainerType = masterService.GetContainer_Type();
            ViewBag.ContainerType = new SelectList(GetContainerType, "ID", "Name");

            List<SelectListModel> GetCargoType = masterService.GetCargo_Type();
            ViewBag.CargoType = new SelectList(GetCargoType, "ID", "Name");


            List<SelectListModel> GetImporter = masterService.GetImpoerterList();
            ViewBag.Importerlist = new SelectList(GetImporter, "ID", "Name");

            List<SelectListModel> GetCHA = masterService.GetCHAList();
            ViewBag.CHAlist = new SelectList(GetCHA, "ID", "Name");

            List<SelectListModel> GetShipper = masterService.GetShipperList();
            ViewBag.Shipperlist = new SelectList(GetShipper, "ID", "Name");

            List<SelectListModel> GetForwarder = masterService.GetForwarderList();
            ViewBag.Forwarderlist = new SelectList(GetShipper, "ID", "Name");

            return View();
        }

        public JsonResult AddInboundEntry(InboundModel inboundModel, List<BE.ContainerDetails> SelectedData)
        {
            string strSQL = "";
            DataTable InsertDL = new DataTable();
            int result = inboundService.AddInboundEntry(inboundModel);

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
                row["ContainerSize"] = item.ContainerSize;
                row["ContainerType"] = item.ContainerType;
                row["CargoType"] = item.CargoType;
                row["SealNo"] = item.SealNo;

                dataTable.Rows.Add(row);


            }
            for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
            {
                strSQL = "";
                strSQL = "USP_INBond_Container '" + result + "','" + dataTable.Rows[i].Field<string>("ContainerNo") + "','" + dataTable.Rows[i].Field<string>("ContainerSize") + "','" + dataTable.Rows[i].Field<string>("ContainerType") + "','" + dataTable.Rows[i].Field<string>("CargoType") + "','" + dataTable.Rows[i].Field<string>("SealNo") + "'";

                InsertDL = db.getData(strSQL);


            }
            if (result >= 0)
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
        public JsonResult getAutoExporterList(string prefixText, string CustomerType)
        {

            DataTable dataTable = new DataTable();
            List<BE.Customer> Customer = new List<BE.Customer>();
            Customer = masterService.getAutoExporter(prefixText, CustomerType);

            return Json(Customer, JsonRequestBehavior.AllowGet);
        }


        public JsonResult BillingHeadSave(string Charges_Head, string Tally_Ledger, string HSN_Code, string Group, string TDS, string Based_ON)
        {
            string strSQL = "";
            DataTable InsertDL = new DataTable();
            int Userid = Convert.ToInt32(Session["UserID"]);
            strSQL = "";
            strSQL = "USP_Insert_Head_Master '" + Charges_Head + "','" + Tally_Ledger + "','" + HSN_Code + "','" + Group + "','" + TDS + "','" + Based_ON + "','" + Userid + "'";

            InsertDL = db.getData(strSQL);

            string message = "SUCCESS";
            return Json(message, JsonRequestBehavior.AllowGet);



        }
        public JsonResult ContractSave(string ContractDescription, string Customer, string CHA, string Exporter, string Line, string EffectiveFrom, string EffectiveUpto)
        {
            string strSQL = "";
            DataTable InsertDL = new DataTable();
            int Userid = Convert.ToInt32(Session["UserID"]);
            strSQL = "";
            strSQL = "USP_INSERT_CONTRACT_MASTER '" + ContractDescription + "','" + Customer + "','" + CHA + "','" + Exporter + "','" + Line + "','" + EffectiveFrom + "','" + EffectiveUpto + "','" + Userid + "'";

            InsertDL = db.getData(strSQL);

            string message = "SUCCESS";
            return Json(message, JsonRequestBehavior.AllowGet);

        }
        public ActionResult EmptyContainerOutPass()
        {

            List<SelectListModel> GetContainerType = masterService.GetContainer_Type();
            ViewBag.ContainerType = new SelectList(GetContainerType, "ID", "Name");

            List<SelectListModel> GetCargoType = masterService.GetCargo_Type();
            ViewBag.CargoType = new SelectList(GetCargoType, "ID", "Name");


            List<SelectListModel> GetImporter = masterService.GetImpoerterList();
            ViewBag.Importerlist = new SelectList(GetImporter, "ID", "Name");

            List<SelectListModel> GetCHA = masterService.GetCHAList();
            ViewBag.CHAlist = new SelectList(GetCHA, "ID", "Name");

            List<SelectListModel> GetShipper = masterService.GetShipperList();
            ViewBag.Shipperlist = new SelectList(GetShipper, "ID", "Name");

            List<SelectListModel> GetForwarder = masterService.GetForwarderList();
            ViewBag.Forwarderlist = new SelectList(GetShipper, "ID", "Name");

            return View();
        }



        public JsonResult ItemDetails(string Containerno)
        {

            DataTable dt = new DataTable();
            dt = db.getData("EmptyOutatePass'" + Containerno + "'");
            var summaryDet = JsonConvert.SerializeObject(dt);
            var jsonResult = Json(summaryDet, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult SaveEmptyContainer(List<BE.EmptyContainerDetails> SelectedData)
        {
            string strSQL = "";
            string GPNO = "";
            DataTable dt = new DataTable();
            int userId = Convert.ToInt32(Session["userid"]);
            DataTable InsertDL = new DataTable();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Containerno");
            dataTable.Columns.Add("ContainerSize");
            dataTable.Columns.Add("ContainerType");
            dataTable.Columns.Add("LineName");
            dataTable.Columns.Add("Movement");
            dataTable.Columns.Add("Vehicle");
            dataTable.Columns.Add("Transporter");
            dataTable.Columns.Add("DriverName");
            dataTable.Columns.Add("OffloadingLocation");
            dataTable.Columns.Add("Remark");
            dataTable.Columns.Add("EntryID");

            foreach (BE.EmptyContainerDetails item in SelectedData)
            {
                DataRow row = dataTable.NewRow();
                row["Containerno"] = item.Containerno;
                row["ContainerSize"] = item.ContainerSize;
                row["ContainerType"] = item.ContainerType;
                row["LineName"] = item.LineName;
                row["Movement"] = item.Movement;
                row["Vehicle"] = item.Vehicle;
                row["Transporter"] = item.Transporter;
                row["DriverName"] = item.DriverName;
                row["OffloadingLocation"] = item.OffloadingLocation;
                row["Remark"] = item.Remark;
                row["EntryID"] = item.EntryID;
                dataTable.Rows.Add(row);
            }

            dt = db.getData("USP_Max_EmptyEntryID");
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {

                    GPNO = Convert.ToString(row["GPNO"]);

                }
            }
            for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
            {
                strSQL = "";
                strSQL = "USP_INSERT_EMPTY_OUT '" + GPNO + "','" + dataTable.Rows[i].Field<string>("Containerno") + "','"
                        + dataTable.Rows[i].Field<string>("ContainerSize") + "','" + dataTable.Rows[i].Field<string>("ContainerType") + "','"
                        + dataTable.Rows[i].Field<string>("LineName") + "','" + dataTable.Rows[i].Field<string>("Movement") + "','"
                        + dataTable.Rows[i].Field<string>("Vehicle") + "','" + dataTable.Rows[i].Field<string>("Transporter") + "','" + dataTable.Rows[i].Field<string>("DriverName")
                        + "','" + dataTable.Rows[i].Field<string>("OffloadingLocation") + "','" + dataTable.Rows[i].Field<string>("Remark") + "','" + dataTable.Rows[i].Field<string>("EntryID") + "','" + userId + "'";

                InsertDL = db.getData(strSQL);


            }
            if (GPNO != "")
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
        public JsonResult OutSummaryList(string Containerno)
        {

            DataTable dt = new DataTable();
            dt = db.getData("USP_EmptyOut_Summary");
            var summaryDet = JsonConvert.SerializeObject(dt);
            var jsonResult = Json(summaryDet, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult EmptyOUTPrint(string GPNO)
        {
            DataSet MasterTable = new DataSet();
            DataTable tblComDetails = new DataTable();
            DataTable DT = new DataTable();
            DataTable DT1 = new DataTable();
            DataTable DT2 = new DataTable();

            DataTable dt = new DataTable();

            MasterTable = db.getDataSet("USP_Empty_Out_PRINT '" + GPNO + "'");
            if (MasterTable.Tables.Count > 0)
            {
                tblComDetails = MasterTable.Tables[0];
                DT = MasterTable.Tables[1];

                string SignedQRcode = "";
                foreach (DataRow dr in tblComDetails.Rows)
                {
                    ViewBag.CompanyName = dr["con_Name"];
                    ViewBag.CompanyAddress = dr["AddressI"];


                }

                foreach (DataRow dr in DT.Rows)
                {
                    ViewBag.SLIP_NO = dr["GPNO"];
                    ViewBag.OUT_DATE = dr["Out Date"];
                    ViewBag.MovementType = dr["Movement Type"];
                    ViewBag.ContainerNo = dr["Container No"];
                    ViewBag.ContainerType = dr["Container Type"];
                    ViewBag.Size = dr["Size"];
                    ViewBag.LineName = dr["Line Name"];
                    ViewBag.VehicleNo = dr["Vehicle No"];
                    ViewBag.TransportName = dr["Transport Name"];
                    ViewBag.DriverName = dr["Driver Name"];
                    ViewBag.REMARKS = dr["Remark"];

                    ViewBag.PrintDate = Convert.ToDateTime(DateTime.Now).ToString("dd MM yyyy HH:mm");

                }



            }

            ViewBag.ContainerList = DT.AsEnumerable();
            return PartialView();
        }
    }
}