using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC.Domain.Model;
using MVC.Services;
using MVC.Services.Interface;
using Newtonsoft.Json;

namespace MVC.Web.Controllers
{
    public class GateInEntryController : Controller
    {
        DB.CommonService db = new DB.CommonService();
        public MasterService masterService = new MasterService();
        public GateService gateService = new GateService();

        public ActionResult GateInEntry()
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

        public JsonResult AddGateEntryDetails(GateInModel gateInModel)
        {
            //LoginUserDetail loginUserDetail = (LoginUserDetail)Session["LoginUserDetail"];
            var date = DateTime.Now;
            gateInModel.ADDED_BY = 1;

            int result = gateService.AddGateEntryDetails(gateInModel);
            if (result > 0)
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
        public ActionResult MarkScanning()
        {

            return View();
        }

        public JsonResult ImportScanningFile(GateInModel fileData)
        {
            int Userid = Convert.ToInt32(Session["userid"]);


            string message = "";
          
            if (Request.Files.Count > 0)
            {

                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i <= files.Count; i++)
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
                        string contentType;
                        fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                        file.SaveAs(fname);
                        //   byte[] Bytes = ReadAllBytes(fname);

                        Stream fs = Request.Files[i].InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        contentType = MimeMapping.GetMimeMapping(fname);
                        //string filedata = fileContents;
                        DataTable DT = new DataTable();

                        string Strtxtline = "";
                        using (StreamReader file12 = new StreamReader(fname))
                        {
                            int counter = 0;
                            string ln;
                            StringBuilder sb = new StringBuilder();
                            while ((ln = file12.ReadLine()) != null)
                            {
                                counter++;
                                Strtxtline = Strtxtline + ln + " ";

                            }

                            file12.Close();

                            Strtxtline = Strtxtline.Replace("'", "");
                            Strtxtline = "'" + Strtxtline + "'";
                            DataTable dt1 = new DataTable();
                            DataTable dt2 = new DataTable();
                            DataTable dt3 = new DataTable();
                            DataTable dt4 = new DataTable();

                            dt3.Columns.Add("ContainerNo");
                            dt3.Columns.Add("ScanType");
                            dt3.Columns.Add("ScanStatus");
                            dt3.Columns.Add("Size");
                            dt3.Columns.Add("JoNo");
                            int LoginDT = new int();
                            if (DT != null)
                            {
                              
                                string sqlQuery = "GET_CONT_BY_FROM_TEXT_NEW " + Strtxtline + ",'" + fileData.GATE_PASS_NO + "','" + Userid + "'";

                                dt1 = db.getData(sqlQuery);
                                foreach (DataRow row in dt1.Rows)
                                {


                                    DataRow dar = dt3.NewRow();


                                    dar["ContainerNo"] = (dt1.Rows[0]["CONT_NO"]);
                                    dar["ScanType"] = (dt1.Rows[0]["SCAN_CODE"]);
                                    dar["ScanStatus"] = "Y";
                                    dar["Size"] = (dt1.Rows[0]["Size"]);
                                    dar["JoNo"] = (dt1.Rows[0]["JoNo"]);
                                    dt3.Rows.Add(dar);


                                    //int linenum = dt1.Rows.IndexOf(row);
                                    //if (linenum == 1050)
                                    //{
                                    //    int count1 = 0;
                                    //}


                                }
                            }



                            if (dt1 != null)
                            {

                                string json = JsonConvert.SerializeObject(dt1);
                                var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
                                jsonResult.MaxJsonLength = int.MaxValue;
                                return jsonResult;


                            }


                            //}

                        }

                    }
                    return Json("File imported Successfully!");
                }
                catch (Exception ex)
                {
                    return Json(1);
                }



            }


            return Json("No files selected.");

        }

    }
}
