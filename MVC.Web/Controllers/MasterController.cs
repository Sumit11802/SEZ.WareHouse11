using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using  MVC.Domain.Model;
using MVC.Services;
using MVC.Services.Interface;
using Newtonsoft.Json;

namespace MVC.Web.Controllers
{
    public class MasterController : Controller
    {
        DB.CommonService db = new DB.CommonService();
        public MasterService masterService = new MasterService();


        private string _userId; private string _roleId;
        public string userId
        {
            get { return Request.Cookies["UserID"] != null ? Request.Cookies["UserID"].Value : ""; }
            set { _userId = Request.Cookies["UserID"] != null ? Request.Cookies["UserID"].Value : ""; }
        }

        public string roleId
        {
            get { return Request.Cookies["UserRoleID"] != null ? Request.Cookies["UserRoleID"].Value : ""; }
            set { _roleId = Request.Cookies["UserRoleID"] != null ? Request.Cookies["UserRoleID"].Value : ""; }
        }

        public ActionResult Index()
        {
            return View();
        }

        //---------------------------Master Entries------------------

        public ActionResult Product()
        {
            return View();
        }

        #region WareHouseDetails

        public ActionResult WareHouseMaster()
        {
            return View();

        }
        public JsonResult SaveWarehouseMaster(WareHouse WarehouseMaster)
        {
            string message = "";

            DataTable SvaDT = new DataTable();
           
            //Code For Insert Data Sequence Should Be Same As Created SP.
            SvaDT = db.getData("USP_save_warehouse '" + WarehouseMaster.WHName + "','" + WarehouseMaster.IsActive +
                "','" + Convert.ToInt32(Session["userID"]) + "','" + WarehouseMaster.Warehouse_Code + "','" + WarehouseMaster.Series_Code + "','"
                + WarehouseMaster.Warehouseadd + "','" + WarehouseMaster.ContactNo + "','" + WarehouseMaster.Executive + "'");

            if (SvaDT.Rows.Count > 0)
            {
                message = "Record saved successfully.";
            }
            else
            {
                message = "Record not saved successfully.";
            }

            return new JsonResult() { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }

        public ActionResult AddLocationDetails(LocationM LocationDetails)
        {
            string message = "";
            ///var EntryDate = LocationMaster.EntryDate;
            DataTable dt = new DataTable();
           
            dt = db.getData("Insert_Loctaion_M '" + LocationDetails.Location + "','" + Convert.ToInt32(Session["userid"]) + "'");
            if (dt.Rows.Count > 0)
            {
                message = Convert.ToString(dt.Rows[0][0]);
            }

            return Json(message);
        }


        public JsonResult GetWarehouseList(string search)
        {

            int userId = Convert.ToInt32(Session["userID"]);
            List<WareHouse> WarehouseData = new List<WareHouse>();
            WarehouseData = masterService.GetWarehouseDataForSummary(search);
            Session["SearchAccountDetails"] = search;
            Session["SearchAccountDetailssearch"] = search;
            var jsonResult = Json(WarehouseData, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }

        public JsonResult CheckGodownExist(Godown WarehouseMaster)
        {
            string message = "";
            DataTable SvaDT = new DataTable();
        
            SvaDT = db.getData("[USP_GodownM_Name] '" + WarehouseMaster.GodownCode + "','" + WarehouseMaster.Warehousecode + "'");

            if (SvaDT.Rows.Count > 0)
            {
                message = "Godown code already exists!";
            }

            return Json(message);
        }



        public ActionResult ViewWarehouseMaster(int WHID)
        {
            int userId = Convert.ToInt32(Session["userID"]);
            List<WareHouse> WarehouseData = new List<WareHouse>();
            WarehouseData = masterService.GetWarehouseData(WHID, userId);
            return new JsonResult() { Data = WarehouseData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            // return Json(CustomerData);
        }
        public ActionResult GodownMaster()
        {

            List<WareHouse> master = new List<WareHouse>();
            master = masterService.getwarehusename();
            //int whid = Convert.ToInt32(Session["whid"]);
            ViewBag.Warehouselist = new SelectList(master, "WHID", "WHName");


            //List<BE.Category> categories = new List<BE.Category>();
            ////categories = GS.getBondCategoryList();
            //ViewBag.ddlCategory = new SelectList(categories, "ID", "CategoryName");
            return View();
        }
        public ActionResult SaveGodownMaster(Godown element)
        {
            string message = "";
            int userId = Convert.ToInt32(Session["userID"]);
            DataTable SvaDT = new DataTable();
          
            //Code For Insert Data Sequence Should Be Same As Created SP.
            SvaDT = db.getData("USP_insert_godown '" + element.CategoryID + "','" + element.CentreCode + "','" + element.GodownCode + "','" + Convert.ToDateTime(element.Dateofposs).ToString("yyyy-MM-dd HH:mm") + "','" + element.Warehousecode + "','" + element.Description + "','" + element.conscapacity + "','" +
                element.thumbcapacity + "','" + element.Width + "','" + element.len + "','" + element.Height + "','" + element.isActive + "','" + userId + "','" + element.Areasqm + "','" + element.Areasqft + "'");

            if (SvaDT.Rows.Count > 0)
            {
                message = "Record saved successfully.";
            }
            else
            {
                message = "Records not updated successfully.";
            }

            return new JsonResult() { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public JsonResult GetGodownList(string search)
        {


            int userId = Convert.ToInt32(Session["userID"]);
            List<Godown> GodownData = new List<Godown>();
            GodownData = masterService.GetGodownsummary(search);
            //return PartialView(WarehouseData);
            // return Json(CustomerData);
            Session["SearchAccountDetails"] = search;
            Session["SearchAccountDetailssearch"] = search;
            var jsonResult = Json(GodownData, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }
        public ActionResult ViewGodownMaster(int EntryID)
        {
            int userId = Convert.ToInt32(Session["userID"]);
            List<Godown> WarehouseData = new List<Godown>();
            WarehouseData = masterService.GetGodwonMasterView(EntryID, userId);
            return new JsonResult() { Data = WarehouseData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            // return Json(CustomerData);
        }
        public ActionResult EditGodownMaster(Godown element)
        {
            DataTable tblInvoiceList = new DataTable();
         
            int userId = Convert.ToInt32(Session["userID"]);
            var retVal = 0;
            string Message = "";

            retVal = db.ExecuteNonQuery("USP_Update_GodownM '" + element.EntryID + "','" + element.CentreCode + "','" + element.GodownCode + "','" + Convert.ToDateTime(element.Dateofposs).ToString("yyyy-MM-dd HH:mm") + "','" + element.Warehousecode + "','" + element.Description + "','" + element.conscapacity + "','" + element.thumbcapacity + "','" + element.Width + "','" + element.len + "','" + element.Height + "','" + element.isActive + "','" + userId + "','" + element.Areasqm + "','" + element.Areasqft + "'");

            if (retVal > 0)
            {
                Message = "Record updated successfully.";
            }
            return new JsonResult() { Data = Message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult Packages()
        {
            return View();

        }
        public JsonResult SavePKGSDetails(Packages element)
        {
           ResponseMessage message = new ResponseMessage();
            element.AddedBy = Convert.ToInt32(Session["userID"]);
            message = masterService.SavePKGSDetails(element);
            return Json(message);
        }

        public JsonResult GetUpdatePackageMaster(int CodeID)
        {
            DataTable dt = new DataTable();
            Packages list = new Packages();
            list = masterService.GetUpdatePackageMaster(CodeID);
            var JsonResult = Json(list, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = int.MaxValue;
            return JsonResult;
        }

        public JsonResult PKGSList(string search)
        {
         
            DataTable dt = new DataTable();
            dt = db.getData("SP_PKGList'" + search + "'");
            Session["Session_PKGSList"] = dt;
            var summaryDet = JsonConvert.SerializeObject(dt);
            var jsonResult = Json(summaryDet, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        [HttpPost]
        public ActionResult SaveLocationDetails(LocationMaster LocationDetails)
        {
            string Message = "";
            int userId = Convert.ToInt32(Session["userid"]);
            Message = masterService.AddLocationDetails(LocationDetails, userId);


            return Json(Message, JsonRequestBehavior.AllowGet);

        }

        #endregion


        #region BinMaster

        public ActionResult BinMaster()
        {
            List<Godown> master = new List<Godown>();

            master = masterService.getGodownListForBond();
            ViewBag.Godownlist = new SelectList(master, "EntryID", "GodownCode");
            ViewBag.Date = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd");
            return View();

        }
       
        public JsonResult GetBincList(string search)
        {
            int userId = Convert.ToInt32(Session["userID"]);
            List<Bin> GodownData = new List<Bin>();
            GodownData = masterService.GetBinSummary(search);
            //return PartialView(WarehouseData);
            // return Json(CustomerData);
            Session["SearchAccountDetails"] = search;
            Session["SearchAccountDetailssearch"] = search;
            var jsonResult = Json(GodownData, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult ViewBinMaster(int EntryID)
        {
            int userId = Convert.ToInt32(Session["userID"]);
            List<Bin> WarehouseData = new List<Bin>();
            WarehouseData = masterService.GetBinMasterView(EntryID, userId);
            return new JsonResult() { Data = WarehouseData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            // return Json(CustomerData);
        }



        public ActionResult SaveBinMaster(List<Bin> TableData, string GodownCode, string CenterCode, string WarehouseCode, string WarehouseD, string chkIsActive)
        {
            string message = "";
            int UserID = Convert.ToInt16(Session["userID"]);

            DataTable dt = new DataTable();
            dt.Columns.Add("LotNo", typeof(string));
            dt.Columns.Add("Area", typeof(float));
            dt.Columns.Add("Lenghth", typeof(float));
            dt.Columns.Add("Height", typeof(float));


            if (TableData != null)
            {
                foreach (Bin item in TableData)
                {

                    DataRow row = dt.NewRow();
                    row["LotNo"] = item.LotNo;
                    row["Area"] = item.Area;
                    row["Lenghth"] = item.Lenghth;
                    row["Height"] = item.Height;




                    //row["LocationName"] = item.LocationName;


                    dt.Rows.Add(row);
                }
            }
            if (message == "")
            {
                message = masterService.SaveBinDet(dt, GodownCode, CenterCode, WarehouseCode, WarehouseD, chkIsActive, UserID);
            }

            var jsonResult = Json(message, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult SaveBinMasterA(List<Bin> TableData, string GridSize, string CenterCode, string warehouse, string WD, string tax)
        {
            string message = "";
            int UserID = Convert.ToInt16(Session["userID"]);

            DataTable dt = new DataTable();

            dt.Columns.Add("LotNo", typeof(string));
            dt.Columns.Add("Area", typeof(float));
            dt.Columns.Add("Lenghth", typeof(float));
            dt.Columns.Add("Height", typeof(float));


            if (TableData != null)
            {
                foreach (Bin item in TableData)
                {

                    DataRow row = dt.NewRow();

                    row["LotNo"] = item.LotNo;
                    row["Area"] = item.Area;
                    row["Lenghth"] = item.Lenghth;
                    row["Height"] = item.Height;




                    //row["LocationName"] = item.LocationName;


                    dt.Rows.Add(row);
                }
            }
            if (message == "")
            {
                message = masterService.SaveBinDetA(dt, GridSize, UserID, CenterCode, warehouse, WD, tax);
            }

            var jsonResult = Json(message, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }


        public ActionResult getGodownlistforBin(string godownCode)
        {

         
            DataTable dataTable = new DataTable();
            int userId = Convert.ToInt32(Session["userID"]);
            List<Godown> receiptEntries = new List<Godown>();
          
            dataTable = db.getData("USP_Select_GodownM'" + godownCode + "','" + userId + "'");
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Godown receiptEntry = new Godown();
                    receiptEntry.CentreCode = Convert.ToString(row["centrecode"]);
                    receiptEntry.Warehousecode = Convert.ToString(row["Warehousecode"]);
                    receiptEntry.Description = Convert.ToString(row["warehousedesc"]);


                    receiptEntries.Add(receiptEntry);
                }
            }
            var jsonResult = Json(receiptEntries, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }



        #endregion







        #region LocationMaster
        public ActionResult LocationMaster()
        {

            return View();

        }

        public ActionResult SaveLocationDetails(Location LocationMaster)
        {
            string message = "";
            ///var EntryDate = LocationMaster.EntryDate;
            DataTable dt = new DataTable();
          
            dt = db.getData("Insert_Loctaion_M '" + LocationMaster.LocationName + "','" + Convert.ToInt32(Session["userid"]) + "'");
            if (dt.Rows.Count > 0)
            {
                message = Convert.ToString(dt.Rows[0][0]);
            }

            return Json(message);
        }




        [HttpPost]
        public ActionResult AjaxGetLocationDetails()
        {
            DataTable dt = new DataTable();
            DataTable CompanyMaster = new DataTable();

       
            dt = db.getData("USP_LocationMaster");
            Session["LocationMaster"] = dt;

            CompanyMaster = db.getData("USP_COMPANYDETAILS");
            //var CompanyName = Convert.ToString(CompanyMaster.Rows[0]["con_Name"]);
            //var CompanyAddress = Convert.ToString(CompanyMaster.Rows[0]["AddressI"]);
            string json = JsonConvert.SerializeObject(dt);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }

        public ActionResult ExportToExcel()
        {
            DataTable dt = (DataTable)Session["LocationMaster"];
            DataTable CompanyMaster = new DataTable();
        
            // dt = db.sub_GetDatatable("USP_GetContainerSurveyRemarks '" + containerNo + "'");
            CompanyMaster = db.getData("USP_COMPANYDETAILS");
            var CompanyName = Convert.ToString(CompanyMaster.Rows[0]["con_Name"]);
            var CompanyAddress = Convert.ToString(CompanyMaster.Rows[0]["AddressI"]);
            DataTable FuelStockSummary = (DataTable)Session["FuelStockSummary"];
            string Tittle = "From " + Session["fromdate"] + " To " + Session["todate"] + ".";
            GridView gridview = new GridView();
            gridview.DataSource = dt;
            gridview.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=VoucherDetails.xls");
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 26px'>" + CompanyName + " <strong></td></tr>");
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>" + CompanyAddress + " <strong></td></tr>");
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>Location Summary Report <strong></td></tr>");
                    //   htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>" + Tittle + " <strong></td></tr>");
                    htw.Write("<table><tr><td colspan='7'><h6 style='text-align:left'> * </h6></td></tr>");
                    // render the GridView to the HtmlTextWriter
                    gridview.RenderControl(htw);
                    // Output the GridView content saved into StringWriter
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }

            return View();
        }

     
        #endregion

        #region EquipmentMaster
        public ActionResult EquipmentMaster()
        {



            return View();


        }
        public ActionResult SaveEquipment(Equipment EquipmentMaster)
        {
            string message = "";
            ///var EntryDate = LocationMaster.EntryDate;
            DataTable dt = new DataTable();
         
            dt = db.getData("Insert_Equipment_M '" + EquipmentMaster.EquipmentID + "','" + EquipmentMaster.EquipmentName + "','" + Convert.ToInt32(Session["userid"]) + "'");
            if (dt.Rows.Count > 0)
            {
                message = Convert.ToString(dt.Rows[0][0]);
            }

            return Json(message);
        }




        [HttpPost]
        public ActionResult AjaxGetEquipmentDetails()
        {
            DataTable dt = new DataTable();
            DataTable CompanyMaster = new DataTable();

            dt = db.getData("USP_EquipmentMaster");
            Session["EquipmentMaster"] = dt;

            CompanyMaster = db.getData("USP_COMPANYDETAILS");
            //var CompanyName = Convert.ToString(CompanyMaster.Rows[0]["con_Name"]);
            //var CompanyAddress = Convert.ToString(CompanyMaster.Rows[0]["AddressI"]);
            string json = JsonConvert.SerializeObject(dt);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }

        public ActionResult ExportToExcelEquipment()
        {
            DataTable dt = (DataTable)Session["EquipmentMaster"];
            DataTable CompanyMaster = new DataTable();
        
            CompanyMaster = db.getData("USP_COMPANYDETAILS");
            var CompanyName = Convert.ToString(CompanyMaster.Rows[0]["con_Name"]);
            var CompanyAddress = Convert.ToString(CompanyMaster.Rows[0]["AddressI"]);
            DataTable FuelStockSummary = (DataTable)Session["FuelStockSummary"];
            string Tittle = "From " + Session["fromdate"] + " To " + Session["todate"] + ".";
            GridView gridview = new GridView();
            gridview.DataSource = dt;
            gridview.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=VoucherDetails.xls");
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 26px'>" + CompanyName + " <strong></td></tr>");
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>" + CompanyAddress + " <strong></td></tr>");
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>Equipment Summary  <strong></td></tr>");
                    //   htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>" + Tittle + " <strong></td></tr>");
                    htw.Write("<table><tr><td colspan='7'><h6 style='text-align:left'> * </h6></td></tr>");
                    // render the GridView to the HtmlTextWriter
                    gridview.RenderControl(htw);
                    // Output the GridView content saved into StringWriter
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }

            return View();
        }

        #endregion Equipmentmaster





    }
}