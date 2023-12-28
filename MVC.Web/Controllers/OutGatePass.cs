﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using  MVC.Domain.Model;
using MVC.Services;
using MVC.Services.Interface;


namespace MVC.Web.Controllers
{
    public class OutGatePassController : Controller
    {
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

        public ActionResult OutGatePass ()
        {
            return View();
        }

        //---------------------------Master Entries------------------

        public ActionResult Product()
        {
            return View();
        }
    }
}