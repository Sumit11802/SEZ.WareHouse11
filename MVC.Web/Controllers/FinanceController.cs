using MVC.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE = MVC.Domain.Model;
using MVC.DB;
using System.IO;
using System.Data.OleDb;

namespace MVC.Web.Controllers
{
    public class FinanceController : Controller
    {
        DB.CommonService db = new DB.CommonService();
        public Services.MasterService masterService = new Services.MasterService();
        public Services.FinanceService customerService = new Services.FinanceService();
        public ActionResult BillingHeadMaster()
        {


            return View();
        }
        public ActionResult HSNMaster()
        {
            return View();
        }
        public ActionResult ContractMaster()
        {
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
        public ActionResult RateSettings()
        {
            List<BE.TariffEnt> Tariff = new List<BE.TariffEnt>();
            Tariff = masterService.GetTariff();
            ViewBag.TariffList = new SelectList(Tariff, "entryID", "tariffID");

            List<BE.TariffEnt> Slab = new List<BE.TariffEnt>();
            List<BE.TariffEnt> AccountHead = new List<BE.TariffEnt>();
            List<BE.TariffEnt> Charges = new List<BE.TariffEnt>();
            List<BE.Location> Location = new List<BE.Location>();



            Slab = masterService.GetSlabID();
            Charges = masterService.GetBondCharges();
            AccountHead = masterService.GetBondAccountList();
            Location = masterService.LocationList();



            ViewBag.SlabList = new SelectList(Slab, "entryID", "slabid");
            ViewBag.ChagresBasedOn = new SelectList(Charges, "ChargesID", "ChargesBased");
            ViewBag.AccountHeadList = new SelectList(AccountHead, "AccountID", "AccountName");
            ViewBag.Location = new SelectList(Location, "LocationID", "LocationName");

            List<BE.CargoType> cargoTypes = new List<BE.CargoType>();
            cargoTypes = masterService.getCargoType();
            ViewBag.CargoType = new SelectList(cargoTypes, "Cargotypeid", "Cargotype");


            return View();
        }
        public JsonResult GetTariffDetailsForSearch(string SearchType)
        {

            DataTable dt = new DataTable();
          
            dt = db.getData("USP_TARIFF_SEARCH_LIST '" + SearchType + "'");

            string json = JsonConvert.SerializeObject(dt);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult GateInPendingList(string SearchType)
        {

            DataTable dt = new DataTable();

            dt = db.getData("USP_GateInPendingList");

            string json = JsonConvert.SerializeObject(dt);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult SSRSummary(string SearchType)
        {

            DataTable dt = new DataTable();

            dt = db.getData("USP_SSRSummary");

            string json = JsonConvert.SerializeObject(dt);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult GateInSummary(string SearchType)
        {

            DataTable dt = new DataTable();

            dt = db.getData("USP_GateInSummary");

            string json = JsonConvert.SerializeObject(dt);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult RefreshDeleteTempTariffDetails()
        {
           
            DataTable dt = new DataTable();
            int userId = Convert.ToInt32(Session["userID"]);
            dt = db.getData("Delete_Bond_all_Temp_tariff_Details'" + userId + "'");
            var summaryDet = JsonConvert.SerializeObject(dt);
            var jsonResult = Json(summaryDet, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult ImportTariffSettingDetailsForUserdelete()
        {

            DataTable dt = new DataTable();
            DataTable CompanyMaster = new DataTable();
         
            int Userid = Convert.ToInt32(Session["userID"]);
            dt = db.getData("USP_DeleteTempDetails '" + Userid + "'");

            string json = JsonConvert.SerializeObject(dt);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public ActionResult TempTariffSave(BE.TariffEnt AM)
        {
           
            DataTable dataTable = new DataTable();
            int UserID = Convert.ToInt16(Session["userID"]);
            dataTable = db.getData("use_temp_traiff_setting_web '" + AM.tariffID + "','" + AM.bondtype + "','" + AM.effectivefrom + "','" + AM.effectiveupto + "','" + AM.AccountHead + "','" + AM.size + "','" + AM.ChargesBased + "','" + AM.FixedAmount + "','" + AM.IsTax + "','" + AM.OnDelivered + "','" + Convert.ToInt32(Session["userID"]) + "','" + AM.ConsiderArea + "','" + AM.Location + "','" + AM.slabid + "','" + AM.CargoType + "','" + AM.IsInternal + "','" + AM.AgreedAmount + "'");


            BE.ResponseMessage item = new BE.ResponseMessage();
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {

                    item.Status = Convert.ToInt32(row["Status"]);
                    item.Message = Convert.ToString(row["message"]);

                }
            }
            return Json(item);
        }
        public JsonResult GetTariffTempDetails()
        {
            
            DataTable dt = new DataTable();
            int userId = Convert.ToInt32(Session["userID"]);
            dt = db.getData("USP_FETCH_DATA_FROM_TEMP_CHARGES'" + userId + "'");
            var summaryDet = JsonConvert.SerializeObject(dt);
            var jsonResult = Json(summaryDet, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public ActionResult SaveTarifDetails(BE.TariffEnt Master, decimal AgreedAmount)
        {
            
            DataTable dataTable = new DataTable();
            int UserID = Convert.ToInt16(Session["userID"]);
            dataTable = db.getData("USP_SAVE_BOND_TARIFF_DETAILS '" + Master.tariffID + "','" + UserID + "'," + AgreedAmount + "");


            BE.ResponseMessage item = new BE.ResponseMessage();
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {

                    item.Status = Convert.ToInt32(row["Status"]);
                    item.Message = Convert.ToString(row["message"]);

                }
            }
            return Json(item);
        }
        public JsonResult TariffValidation(List<BE.SlabDetailsEntites> Invoicedata, string tariffID)
        {
            string message = "";
            int UserID = Convert.ToInt16(Session["userID"]);

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("SlabOn");
            dataTable.Columns.Add("RangeFrom");
            dataTable.Columns.Add("RangeTo");
            dataTable.Columns.Add("Value");


            foreach (BE.SlabDetailsEntites item in Invoicedata)
            {
                DataRow row = dataTable.NewRow();

                row["SlabOn"] = item.SlabOn;
                row["RangeFrom"] = item.RangeFrom;
                row["RangeTo"] = item.RangeTo;
                row["Value"] = item.Value;


                dataTable.Rows.Add(row);
            }


            message = masterService.SaveBondSlabBL(dataTable, UserID, tariffID);

            return Json(message);


        }
        public JsonResult AjxImportTariffSettingFileForCustomer(BE.TariffAddDetailsEntites fileData)
        {
            int Userid = Convert.ToInt32(Session["userID"]);
            string message = "";

            string TariffID = fileData.TariffID;
            string AccountingName = fileData.Accounting;

            List<BE.TariffAddDetailsEntites> CustomerTariffDetails = new List<BE.TariffAddDetailsEntites>();
            if (Request.Files.Count > 0)
            {
                try
                {

                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/ImportFile/"), fname);
                        //  fname = Path.Combine(fname);

                        //string MSNO = file.TariffID;
                        //string MSNO1 = file.AccountingName;


                        file.SaveAs(fname);
                        string extension = Path.GetExtension(fname);
                        string conString = string.Empty;
                        switch (extension)
                        {
                            case ".xls": //Excel 97-03.
                                // conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                                conString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'", fname);
                                break;
                            case ".xlsx": //Excel 07 and above.
                                //conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                                conString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'", fname);
                                break;
                        }
                        //BL.AddErrorLog(conString.Replace("'",""));
                        //BL.AddErrorLog(fname.Replace("'", ""));
                        //  conString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'", fname);
                        //  BL.AddErrorLog("Connection close");
                        using (OleDbConnection connExcel = new OleDbConnection(conString))
                        {
                            // BL.AddErrorLog("OleDbConnection");
                            using (OleDbCommand cmdExcel = new OleDbCommand())
                            {
                                // BL.AddErrorLog("cmdExcel");
                                using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                                {
                                    //  BL.AddErrorLog("odaExcel");
                                    DataTable dt = new DataTable();
                                    cmdExcel.Connection = connExcel;

                                    //Get the name of First Sheet.
                                    connExcel.Open();
                                    //  BL.AddErrorLog("Open connection");
                                    DataTable dtExcelSchema;
                                    dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                    string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                                    //  BL.AddErrorLog(sheetName);
                                    connExcel.Close();

                                    //Read Data from First Sheet.
                                    connExcel.Open();
                                    cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                                    odaExcel.SelectCommand = cmdExcel;
                                    odaExcel.Fill(dt);
                                    connExcel.Close();

                                    DataTable DriverPaymentDT = new DataTable();


                                    DriverPaymentDT.Columns.Add("Tariff");
                                    DriverPaymentDT.Columns.Add("Account Name");
                                    DriverPaymentDT.Columns.Add("Activity");
                                    DriverPaymentDT.Columns.Add("From");
                                    DriverPaymentDT.Columns.Add("To");
                                    DriverPaymentDT.Columns.Add("Size");
                                    DriverPaymentDT.Columns.Add("Type");
                                    DriverPaymentDT.Columns.Add("Amount");
                                    DriverPaymentDT.Columns.Add("From Location");
                                    DriverPaymentDT.Columns.Add("To Location");

                                    DriverPaymentDT.Columns.Add("rate");
                                    DriverPaymentDT.Columns.Add("Insurance");
                                    DriverPaymentDT.Columns.Add("Tax");
                                    DriverPaymentDT.Columns.Add("Free Days");

                                    //DriverPaymentDT.TableName = "PT_UpdateDischargeDate";
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (row[0].ToString() != "" && row[1].ToString() != "" && row[2].ToString() != "" && row[3].ToString() != "" && row[4].ToString() != ""
                                            && row[5].ToString() != "" && row[6].ToString() != "" && row[7].ToString() != "" && row[8].ToString() != "" && row[9].ToString() != "" && row[10].ToString() != "")
                                        {
                                            DataRow dar = DriverPaymentDT.NewRow();

                                            dar["Tariff"] = row[0].ToString().ToUpper();
                                            dar["Account Name"] = row[1].ToString().ToUpper();
                                            dar["Activity"] = row[2].ToString().ToUpper();
                                            dar["From"] = row[3].ToString().ToUpper();
                                            dar["To"] = row[4].ToString();
                                            dar["Size"] = row[5].ToString();
                                            dar["Type"] = row[6].ToString();
                                            dar["Amount"] = row[7].ToString();
                                            dar["From Location"] = row[8].ToString();
                                            dar["To Location"] = row[9].ToString();
                                            dar["rate"] = row[10].ToString();
                                            dar["Insurance"] = row[11].ToString();
                                            dar["Tax"] = row[12].ToString();
                                            dar["Free Days"] = row[13].ToString();

                                            DriverPaymentDT.Rows.Add(dar);
                                            int linenum = dt.Rows.IndexOf(row);
                                            if (linenum == 1050)
                                            {
                                                int count1 = 0;
                                            }

                                        }
                                    }

                                    if (fname != null || fname != string.Empty)
                                    {
                                        if ((System.IO.File.Exists(fname)))
                                        {
                                            System.IO.File.Delete(fname);
                                        }

                                    }

                                    if (DriverPaymentDT != null)
                                    {

                                        CustomerTariffDetails = masterService.GetCustomerTariffDetails(DriverPaymentDT, TariffID, AccountingName, Userid);


                                        var jsonResult = Json(CustomerTariffDetails, JsonRequestBehavior.AllowGet);
                                        jsonResult.MaxJsonLength = int.MaxValue;
                                        return jsonResult;


                                    }

                                }
                            }
                        }
                    }
                    return Json("File imported Successfully!");
                }
                catch (Exception ex)
                {

                    return Json("Error occurred. Error details: " + ex.Message);

                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        public ActionResult ExportToFormatCustomertariff()
        {
            string fileName = "~/Format/Tariff_Setting_Details.xlsx";
            if (fileName != "")
            {
                string filePath = fileName;
                Response.ContentType = "doc/docx";
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                Response.TransmitFile(Server.MapPath(filePath));
                Response.End();
            }
 
            return View();
        }
        public JsonResult ApprovedBondTariff(List<BE.SlabDetailsEntites> TariffNo, int type)
        {
            string message = "";
            int UserID = Convert.ToInt16(Session["userID"]);

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Entryid");



            foreach (BE.SlabDetailsEntites item in TariffNo)
            {
                DataRow row = dataTable.NewRow();

                row["Entryid"] = item.Entryid;



                dataTable.Rows.Add(row);
            }


            message = masterService.CancelBondTariffBL(dataTable, UserID, type);

            return Json(message);


        }
        public JsonResult GetInvoiceTyprForSlabDetails(int AccountID)
        {

            DataTable dt = new DataTable();
            DataTable CompanyMaster = new DataTable();
            
            int Userid = Convert.ToInt32(Session["userID"]);
            dt = db.getData("USP_ShowBondAccountDetails '" + AccountID + "'");
            string message = "";
            string message1 = "";

            BE.ImportTariffSetting item = new BE.ImportTariffSetting();
            if (dt.Rows.Count > 0)
            {
                item.InvoiceTypeID = Convert.ToInt32(dt.Rows[0].Field<int>("InvoiceTypeID"));
                item.TaxID = Convert.ToString(dt.Rows[0].Field<Int64>("TaxID"));
                item.SorF = Convert.ToString(dt.Rows[0].Field<string>("Sorf"));
                item.isActive = Convert.ToString(dt.Rows[0].Field<Boolean>("IsFreeDays")) == "True" ? 1 : 0;
            }

            var jsonResult = Json(item, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public ActionResult ContractWorkLoad()
        {
            return View();
        }
        public ActionResult ProformaInvoice()
        {
            return View();
        }
        public ActionResult AwaitingFinalConfirmation()
        {
            return View();
        }
        public ActionResult GenerateReceipt()
        {
            return View();
        }
        public ActionResult tabletest()
        {
            return View();
        }
        public ActionResult SalesRegister()
        {
            return View();
        }
        public ActionResult Shipment()
        {
            return View();
        }
        public ActionResult CollectionSummary()
        {
            return View();
        }
        public ActionResult LedgerStatement()
        {
            return View();
        }
        public ActionResult OutStandingReport()
        {
            return View();
        }

        public JsonResult AddHSNDetails(FINANCE finance)
        {
            int customerid = customerService.AddHSNDetails(finance);
            if (customerid >= 0)
            {
                finance.CUSTOMER_ID = customerid;

                //financeService.AddCompanyDetails(customer);
                //financeService.AddBankDetails(customer);
                //financeService.AddCustomerDetails(customer);
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

//    public JsonResult AddHSNDetails(FINANCE finance)
//    {
//        int customerid = financeService.AddHSNDetails(finance);
//        if (customerid >= 0)
//        {
//            finance.CUSTOMER_ID = customerid;

//            //financeService.AddCompanyDetails(customer);
//            //financeService.AddBankDetails(customer);
//            //financeService.AddCustomerDetails(customer);
//            string message = "SUCCESS";
//            return Json(message, JsonRequestBehavior.AllowGet);
//        }
//        else
//        {

//            string message = "FAILED";
//            return Json(message, JsonRequestBehavior.AllowGet);
//        }
//    }
//}