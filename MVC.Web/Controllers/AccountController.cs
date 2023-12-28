using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC.Domain.Model;
using MVC.Domain;
using MVC.Services;
using MVC.Services.Interface;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Http;
using MoneyTransfer.Domain.ViewModel;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace MVC.Web.Controllers
{
    public class AccountController : Controller
    {

        // private readonly AccountService accountService;
        DB.CommonService db = new DB.CommonService();
        public AccountService accountService = new AccountService();
        //public AccountController(AccountService accountService)
        //{
        //    this.accountService = accountService;
        //}

        public ActionResult UserRights()
        {
            List<UserRights> model = accountService.GetUserRigths();
            return View(model);
        }

        public ActionResult UserLogin()
        {  
            return View();
        }

        public ActionResult Login()
        {
            
            return View();
        }
        //public JsonResult ValidLogin(string User, string Password , string Role)
        //{
        //    ResponseMessage message = new ResponseMessage();
        //    //  element.AddedBy = Convert.ToInt32(Session["userID"]);
        //    message = accountService.Login(User, Password);


        //    return Json(message);
        //}

        public ActionResult ForgotPassword()
        {
            return View();
        }

        //public JsonResult ResetPassword(string userID)
        //{
        //    Random generator = new Random();
        //    string randomOTP = generator.Next(0, 999999).ToString("D6");

        //    double UserID = Convert.ToDouble(userID);

        //    int result = accountService.ResetPassword(userID, 0, randomOTP, "FGTPWD");

        //    if (result == 1)
        //    {
        //        string message = "Your pocketmoney One Time Password(OTP) is " + randomOTP + ". Do not share this OTP to anyone for security reasons.";
        //        _mailRepository.SendWhattsupMessage(userID, message);
        //        SendEmail(randomOTP, userID);
        //        return Json(new { Success = true, message = "" }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginSubmit(UserLoginDetails loginEntities)
        {
            // BE.LoginEntites loginEntities = new BE.LoginEntites();
            var name = loginEntities.UserName;
            var pass = loginEntities.Password;
            var deptid = loginEntities.DeptID.ToString();
            Boolean rememberme = Convert.ToBoolean(loginEntities.Remember);


           // var password = EncryptionLibrary.EncryptText(loginViewModel.Password);

            var logindata = accountService.UserLogin(name, pass, deptid);

            if (logindata.UserID != 0)
            {
                //Start Validation to Authenticate User For Valid URL Access
         
                //Message = ValidateURLUserLogin(logindata.UserID, Request.Url.Host);
                //if (Message != "" && Message != "Success")
                //{
                //    logindata.LoginErrorMessage = Message;
                //    return View("index", logindata);
                //}

                //End Validation to Authenticate User For Valid URL Access

                Session["userid"] = logindata.UserID;
                Session["username"] = logindata.UserName;
                Session["rolename"] = logindata.UserRole;
                Session["deptid"] = logindata.DeptID;
                Session["roleid"] = logindata.RoleID;


                HttpCookie usercookies = new HttpCookie("usercookies");
                usercookies["userid"] = Convert.ToString(logindata.UserID);
                usercookies["username"] = logindata.UserName; ;
                usercookies["deptid"] = Convert.ToString(logindata.DeptID);
                usercookies["roleid"] = Convert.ToString(logindata.RoleID);

                Response.Cookies.Add(usercookies);

                RememberMe(name, pass, rememberme, Convert.ToString(logindata.UserID));


        
                logindata.status = "1";
                logindata.message = "Successfully Login, Redirecting to Dashboard";
                return Json(logindata);
            }
            else
            {
                logindata.status = "0";
                logindata.message = "Wrong Username or Password.";

                return Json(logindata);
            }
        }

        private void RememberMe(String name, String password, Boolean rememberme, String UserId)
        {

            if (rememberme)
            {
                HttpCookie usercookies = new HttpCookie("usercookies");
                usercookies["userid"] = UserId;
                usercookies["username"] = name;
                usercookies["password"] = password;
                //usercookies["department"] = DepType;
                //usercookies["companycode"] = ConCode;
                Response.Cookies.Add(usercookies);

                //HttpCookie userinfo = new HttpCookie("userinfo");
                //userinfo["username"] = name;
                //userinfo["password"] = password;
                usercookies.Expires = DateTime.Now.AddDays(30);
                //Response.Cookies.Add(userinfo);
            }
            else
            {
                HttpCookie vms_userInfo = new HttpCookie("usercookies");
                vms_userInfo.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(vms_userInfo);

            }
        }

        //[NonAction]
        //public void remove_Anonymous_Cookies()
        //{
        //    if (Request.Cookies["MoneyTransferChannel"] != null)
        //    {
        //        CookieOptions option = new CookieOptions();
        //        option.Expires = DateTime.Now.AddDays(-1);
        //        Response.Cookies.Append("MoneyTransferChannel", "", option);
        //    }
        //}

        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult UserDashboard()
        {
            return View();
        }

        //public ActionResult AdminMenu()
        //{
        //    List<Menus> MenuList = new List<Menus>();

        //    int userid = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
        //    MenuList = accountService.GetSideMenu(userid);
        //    //HttpContext.Session.SetString["MenuList"] = MenuList;
        //    return PartialView("_AdminMenu", MenuList);

        //}

        public ActionResult SideMenu()
        {

            List<Menus> MenuList = new List<Menus>();
      
            int userid = Convert.ToInt32(Session["userid"]);
            MenuList = accountService.GetSideMenu(userid);
            //HttpContext.Session.SetString["MenuList"] = MenuList;
            Session["MenuList"] = MenuList; 
            return PartialView("_SideMenu", MenuList);


            //return PartialView("SideMenu", MenuList);
        }

        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult ChangeLoginPassword(string oldpwd, string newpwd)
        {
            string message = "";
            try
            {
                int UserID = Convert.ToInt16(Session["UserID"]);
                string Message = "";
                try
                {
                  
                    DataTable table = new DataTable();
                  
                    string strSQL = "";
                    strSQL = "uspChangePassword '" + oldpwd + "','" + newpwd + "','" + UserID + "'";

                    table = db.getData(strSQL);


                    if (table != null)
                    {
                        Message = table.Rows[0]["Message"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    //Message = ex.Message;
                }

                return Json(Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Profile()
        {
            User model = new User();
            int UserID = Convert.ToInt16(Session["userid"]);
            string Message = "";

           
            DataTable table = new DataTable();
           

            string strSQL = "uspGetProfileDetails '" + UserID + "'";

            table = db.getData(strSQL);

            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    model.USerName = Convert.ToString(row["Username"]);
                    model.userType = Convert.ToString(row["UserType"]);
                    model.gender = Convert.ToString(row["Gender"]);
                    model.emailid = Convert.ToString(row["email_ID"]);
                    model.Contact = Convert.ToString(row["ContactNo"]);
                    model.DOB = Convert.ToString(row["DOB"]);

                }
            }

            return View(model);
        }

        public JsonResult ChangeProfile(User CreateUser)
        {
            int UserID = Convert.ToInt16(Session["userid"]);
           
            int retVal = 0;

           
            string strSQL = "uspUpdateProfile '" + UserID + "','" + Convert.ToDateTime(CreateUser.DOB).ToString("yyyy-MM-dd HH:mm") + "','" + CreateUser.emailid + "','" + CreateUser.Contact + "'";

            DataTable table = db.getData(strSQL);
            retVal = 1;
            return Json(retVal);
        }

        public ActionResult ManageUser()
        {
           
            ViewBag.Date = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");

            List<User> Location = new List<User>();
            //Location = trainTrackerProvider.GetFrommenuList();
            ViewBag.Location = new SelectList(Location, "GroupID", "Name");


            List<User> icon = new List<User>();
            //icon = trainTrackerProvider.GetIconList();
            ViewBag.icon = new SelectList(icon, "icon", "icon");

            List<User> User = new List<User>();
            User = accountService.UserName();
            ViewBag.User = new SelectList(User, "UserID", "USerName");



            return View();
        }

        public ActionResult AssignRights()
        {
            ViewBag.Date = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");

            List<User> Location = new List<User>();
            //Location = trainTrackerProvider.GetFrommenuList();
            ViewBag.Location = new SelectList(Location, "GroupID", "Name");


            List<User> icon = new List<User>();
            //icon = trainTrackerProvider.GetIconList();
            ViewBag.icon = new SelectList(icon, "icon", "icon");

            List<User> User = new List<User>();
            User = accountService.UserName();
            ViewBag.User = new SelectList(User, "UserID", "USerName");


            return View();
        }
        public JsonResult CreateSearch(string search)
        {
  
            DataTable dt = new DataTable();

            string strSQL = "uspGetUserDetails '" + search + "'";

             dt = db.getData(strSQL);

           // dt = db.sub_GetDatatable("SearchEmp '" + search + "'");
            var summaryDet = JsonConvert.SerializeObject(dt);
            var jsonResult = Json(summaryDet, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult BindMenuDetails(string UserName, string Menusfrom)
        {
          
            DataTable dt = new DataTable();


            string strSQL = "GetMenuUserDetails '" + UserName + "','" + Menusfrom + "'";

            dt = db.getData(strSQL);


            var summaryDet = JsonConvert.SerializeObject(dt);
            var jsonResult = Json(summaryDet, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult AjaxCheckFirstname(string firstname, string lastname)
        {
            string Message = "";

            string strSQL = "USP_CheckCreateUserName '" + firstname + "'";

            DataTable table = db.getData(strSQL);

            if (table.Rows.Count > 0)
            {
                int count = Convert.ToInt16(table.Rows[0]["UserName"]);
                if (count > 0)
                {
                    Message = "1";

                }
            }
            return Json(Message);
        }


        public JsonResult Save(User CreateUser)
        {
            int UserID = Convert.ToInt16(Session["userid"]);
  
            int retVal = 0;
  
            //Master();
            string strSQL = "USP_Create_User_insert '" + CreateUser.firstname + "','" + CreateUser.lastname + "','" + CreateUser.gender + "','" + Convert.ToDateTime(CreateUser.DOB).ToString("yyyy-MM-dd HH:mm") + "','" + CreateUser.employeeid + "','" + CreateUser.password + "','" + CreateUser.department + "','" + CreateUser.userType + "','" + CreateUser.emailid + "','" + CreateUser.passEmail + "','" + CreateUser.Contact + "','" + UserID + "','" + CreateUser.UseriDN + "'";

            DataTable table = db.getData(strSQL);
            retVal = 1;
            return Json(retVal);
        }


        [HttpPost]
        public JsonResult SaveAssingRight(string UserId, List<UserRights> RightsData)
        {
            string message = "";
            try
            {
                DataTable UserRightDT = new DataTable();
                UserRightDT.Columns.Add("MenuId");
                UserRightDT.Columns.Add("IsAccess");
                UserRightDT.Columns.Add("CanAdd");
                UserRightDT.Columns.Add("CanView");
                UserRightDT.Columns.Add("CanUpdate");
                UserRightDT.Columns.Add("CanMail");
                UserRightDT.Columns.Add("CanCancel");

                if (RightsData.Count > 0)
                {
                    foreach (UserRights rights in RightsData)
                    {
                        DataRow row = UserRightDT.NewRow();
                        row["MenuId"] = rights.MenuId;
                        row["IsAccess"] = rights.IsAccess;
                        row["CanAdd"] = rights.CanAdd;
                        row["CanView"] = rights.CanView;
                        row["CanUpdate"] = rights.CanUpdate;
                        row["CanMail"] = rights.CanMail;
                        row["CanCancel"] = rights.CanCancel;

                        UserRightDT.Rows.Add(row);
                    }
                }

                if (UserRightDT != null)
                {
                    message = accountService.SaveUserRight(UserRightDT, Convert.ToInt32(UserId));
                }

            }
            catch (Exception ex) { }

            return Json(message, JsonRequestBehavior.AllowGet);
        }


    }
}