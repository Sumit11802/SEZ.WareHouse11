using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Domain.Model;
using MVC.Repository;
using MVC.Services;
using BE = MVC.Domain.Model;

namespace MVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        public MasterService masterService = new MasterService();
        public CustomerService customerService = new CustomerService();

        public CustomerRepository customerRepository = new CustomerRepository();


        public JsonResult AddCustomerEntry(CUSTOMER customer)
        {
            int customerid = customerService.AddCustomerEntry(customer);
            if (customerid >= 0)
            {
                customer.CUSTOMER_ID = customerid;

                customerService.AddCompanyDetails(customer);
                customerService.AddBankDetails(customer);
                customerService.AddCustomerDetails(customer);
                string message = "SUCCESS";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {

                string message = "FAILED";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CustomerEntry()
        {
            List<CUSTOMER> customer = customerRepository.FetchCustomer();
            return View(customer);
        }
        public JsonResult GetCustomerDetails(int ID)
        {
            int id = Convert.ToInt32(ID);
            CUSTOMER employeeDetails = customerService.FetchCustomerDetail(ID);

            var jsonResult = Json(employeeDetails, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        public JsonResult GetGlobalGSTList(String SearchText)
        {

            List<BE.GSTEntities> GSTList = new List<BE.GSTEntities>();
            GSTList = customerService.getGlobalGSTList(SearchText);
            return Json(GSTList);
            // return View();
        }
      
        public ActionResult AddCustomerDetails1()
        {
            string message = "";
            List<BE.DocList> DocList = new List<BE.DocList>();
            DocList = customerService.GetDocList(message);
            //DocLRList = DocList.DocList;
            ViewBag.DocList = new SelectList(DocList, "DocID", "DocName");

            return PartialView("EditCustomerDetails");
        }
   
        public ActionResult EditCustomerDetails(long ID)
        {
            BE.MasterEntities CustomerData = new BE.MasterEntities();
            CustomerData = customerService.GetCutomerData(ID);
            return PartialView(CustomerData);
            // return Json(CustomerData);
        }
        [HttpPost]
        public JsonResult UpdateMasterData(BE.MasterEntities Master)
        {
            BE.ResponseMessage response = new BE.ResponseMessage();
            try
            {
                string Message = "";
                int userId = Convert.ToInt32(Session["userid"]);
                Message = customerService.UpdateMasterData(Master, userId);

                response.Status = 1;
                response.Message = Message;
            }
            catch (Exception ex)
            {
                response.Status = 0;
                response.Message = ex.Message;
            }

            return Json(response);
        }
        [HttpPost]
        public ActionResult LocationDetails(Int64 ID, string Name)
        {
            // BE.MasterEntities CustomerData = new BE.MasterEntities();
            //CustomerData = GS.GetCutomerData(ID);

            List<BE.Ext_location_Master> LocationList = new List<BE.Ext_location_Master>();
            LocationList = customerService.GetLocationList();
            ViewBag.LocationList = new SelectList(LocationList, "LocationID", "Location");

            List<BE.GST_Registration_Type> RegTypeList = new List<BE.GST_Registration_Type>();
            RegTypeList = customerService.GetGSTRegistrationType();
            ViewBag.RegTypeList = new SelectList(RegTypeList, "RGID", "RGType");

            List<BE.Ext_location_Master> CustomerLocationList = new List<BE.Ext_location_Master>();
            CustomerLocationList = customerService.GetCustomerLocationList(ID);
            ViewBag.CustomerLocationList = CustomerLocationList;

            ViewBag.CommonID = ID;
            ViewBag.Name = Name;

            //if (Convert.ToString(TempData["MessageValue"]) != null)
            //{
            //    //string msg = TempData["url"].ToString();
            //    string msg1 = Convert.ToString(TempData["MessageValue"]);
            //    ViewBag.Message = msg1;
            //}
            return PartialView();

        }
        public ActionResult getStateCode(string GSTNO)
        {
            List<BE.StateMaster> stateList = new List<BE.StateMaster>();
            stateList = customerService.getStateCode(GSTNO);



            //ViewBag.Message = Message;
            //TempData["MessageValue"] = Message;
            //return RedirectToAction("GlobalSearchSummary");

            return Json(stateList, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult SaveLocationDetails(BE.LocationMaster LocationDetails)
        {
            string Message = "";
            int userId = Convert.ToInt32(Session["userid"]);
            Message = customerService.AddLocationDetails(LocationDetails, userId);

             
            return Json(Message, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetLocationWiseData(Int32 id, Int64 Common_ID, Int64 GSTID)
        {
            BE.LocationMaster lm = new BE.LocationMaster();
            lm = customerService.getLocationDataCustomerWise(id, Common_ID, GSTID);

            return Json(lm, JsonRequestBehavior.AllowGet);

        }
    }


}