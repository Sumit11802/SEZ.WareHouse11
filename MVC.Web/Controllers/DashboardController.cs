using MVC.Domain.Model;
using MVC.Services;
using MVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Web.Controllers
{
    public class DashboardController : Controller
    {
        private AccountService accountService = new AccountService();

        //public DashboardController(IAccountService accountService)
        //{
        //    this.accountService = accountService;
        //}

        public ActionResult Dashboard()
        {
           
            //return View(MenuList);
            return View();
        }

        public ActionResult Finance()
        {

            //return View(MenuList);
            return View();
        }
        [RBAC]
        public ActionResult Regular()
        {
            //List<Menus> MenuList = new List<Menus>();

            //int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            //MenuList = accountService.GetSideMenu(userid);
            //return View(MenuList);
            //List<Menus> MenuList = new List<Menus>();

            //int userid = Convert.ToInt32(Session["userid"]);
            //MenuList = accountService.GetSideMenu(userid);

            return View();
        }
        [RBAC]
        public ActionResult Database()
        {
            //List<Menus> MenuList = new List<Menus>();

            //int userid = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            //MenuList = accountService.GetSideMenu(userid);
            //return View(MenuList);
            //List<Menus> MenuList = new List<Menus>();

            //int userid = Convert.ToInt32(Session["userid"]);
            //MenuList = accountService.GetSideMenu(userid);

            return View();
        }
    }
}