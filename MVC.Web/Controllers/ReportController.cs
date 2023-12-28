﻿using ClosedXML.Excel;
using MVC.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVC.Web.Controllers
{
    [RBAC]
    public class ReportController : Controller
    {
        ReportService reportServive = new ReportService();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerReport()
        {

            return View();
        }

        public ActionResult GetCustomerReport(int criteria, DateTime? fromdate , DateTime? todate)
        {
            DataTable customerData = new DataTable();

            customerData = reportServive.FetchCustomerList(criteria,fromdate,todate);
            Session["uspFetchCustomerList"] = customerData;
  

            var json = JsonConvert.SerializeObject(customerData);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        public ActionResult GetCustomerReportExcel()
        {
            DataTable dt = (DataTable)Session["uspFetchCustomerList"];
            DataTable CompanyMaster = new DataTable();


            
          
            var CompanyName = "UMBA";
            var CompanyAddress = "";
            string Tittle = "From " + Session["fromdate"] + " To " + Session["todate"] + ".";
            GridView gridview = new GridView();
            gridview.DataSource = dt;
            gridview.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=UMBACustomerReport.xls");
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 26px'>" + CompanyName + " <strong></td></tr>");
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>" + CompanyAddress + " <strong></td></tr>");
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>Customer Report<strong></td></tr>");
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>" + Tittle + " <strong></td></tr>");
                    // htw.Write("<table><tr><td colspan='7'><h6 style='text-align:left'> *output generated by JMM </h6></td></tr>");
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




        public ActionResult UserReport()
        {

            return View();
        }

        public ActionResult GetUserReport(int criteria, DateTime? fromdate, DateTime? todate)
        {
            DataTable customerData = new DataTable();

            customerData = reportServive.FetchUserList(criteria, fromdate, todate);
            Session["uspFetchUserList"] = customerData;


            var json = JsonConvert.SerializeObject(customerData);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        public ActionResult GetUserReportExcel()
        {
            DataTable dt = (DataTable)Session["uspFetchUserList"];
            DataTable CompanyMaster = new DataTable();



            var CompanyName = "UMBA";
            var CompanyAddress = "";
            string Tittle = "From " + Session["fromdate"] + " To " + Session["todate"] + ".";
            GridView gridview = new GridView();
            gridview.DataSource = dt;
            gridview.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=UMBAUserReport.xls");
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 26px'>" + CompanyName + " <strong></td></tr>");
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>" + CompanyAddress + " <strong></td></tr>");
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>User Report<strong></td></tr>");
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>" + Tittle + " <strong></td></tr>");
                    // htw.Write("<table><tr><td colspan='7'><h6 style='text-align:left'> *output generated by JMM </h6></td></tr>");
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

        public ActionResult ActionOnUserAccount(int UserID, int Action)
        {
            string message = "";
            reportServive.ActionOnUserAccount(UserID, Action);
            return Json(message);
        }

        public ActionResult RegularCustomer()
        {

            return View();
        }

        public ActionResult GetRegularCustomerReport(int criteria, DateTime? fromdate, DateTime? todate)
        {
            DataTable customerData = new DataTable();

            customerData = reportServive.FetchRegularCustomerList(criteria, fromdate, todate);
            Session["uspFetchRegularCustomerList"] = customerData;


            var json = JsonConvert.SerializeObject(customerData);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        public ActionResult GetRegularCustomerReportExcel()
        {
            DataTable dt = (DataTable)Session["uspFetchRegularCustomerList"];
            DataTable CompanyMaster = new DataTable();

            //GridView gridview = new GridView();
            //gridview.DataSource = dt;
            //gridview.DataBind();

            //Response.Clear();
            //Response.Buffer = true;
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.AddHeader("content-disposition", "attachment;filename=UMBACustomerUpload.xls");
            //using (StringWriter sw = new StringWriter())
            //{
            //    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            //    {
            //        //htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 26px'>" + CompanyName + " <strong></td></tr>");
            //        //htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>" + CompanyAddress + " <strong></td></tr>");
            //        //htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>Customer Data Upload<strong></td></tr>");
            //        //htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>" + Tittle + " <strong></td></tr>");
            //        // htw.Write("<table><tr><td colspan='7'><h6 style='text-align:left'> *output generated by JMM </h6></td></tr>");
            //        // render the GridView to the HtmlTextWriter
            //        gridview.RenderControl(htw);
            //        // Output the GridView content saved into StringWriter
            //        Response.Output.Write(sw.ToString());
            //        Response.Flush();
            //        Response.End();
            //    }
            //}


            using (XLWorkbook wb = new XLWorkbook())
            {
             
                var ws1 = wb.Worksheets.Add("CustomerData");
                var table1 = ws1.FirstCell().InsertTable(dt, true);
         

           
                //ws3.FirstCell().InsertTable(ds.Tables[3], false);


                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=UMBACustomerUpload_" + DateTime.Now.ToShortDateString()  + "_.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }


            return View();
        }

        public ActionResult Campaign()
        {

            return View();
        }

        public ActionResult GetCampaignReport(int criteria, DateTime? fromdate, DateTime? todate)
        {
            DataTable customerData = new DataTable();

            customerData = reportServive.FetchCampaignReport(criteria, fromdate, todate);
            Session["uspFetchCampaignList"] = customerData;


            var json = JsonConvert.SerializeObject(customerData);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        public ActionResult GetCampaignReportExcel()
        {
            DataTable dt = (DataTable)Session["uspFetchCampaignList"];
            DataTable CompanyMaster = new DataTable();

            GridView gridview = new GridView();
            gridview.DataSource = dt;
            gridview.DataBind();
            var CompanyName = "UMBA";
            var CompanyAddress = "";
            string Tittle = "From " + Session["fromdate"] + " To " + Session["todate"] + ".";
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=UMBACustomerUpload.xls");
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 26px'>" + CompanyName + " <strong></td></tr>");
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>" + CompanyAddress + " <strong></td></tr>");
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>Customer Data Upload<strong></td></tr>");
                    htw.Write("<table><tr><td style='font-weight: bold; text-align: center'; colspan ='7'><strong style='font-size: 15px'>" + Tittle + " <strong></td></tr>");
                    // htw.Write("<table><tr><td colspan='7'><h6 style='text-align:left'> *output generated by JMM </h6></td></tr>");
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
    }
}