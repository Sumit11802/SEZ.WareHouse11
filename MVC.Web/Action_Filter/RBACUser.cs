using MVC.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


public class RBACUser
{
    public int User_Id { get; set; }
    public bool IsSysAdmin { get; set; }
    public string Username { get; set; }
    // private List<UserRole> Roles = new List<UserRole>();

  
    //private readonly Business.BankService _bankService;    
    

    public RBACUser()
    {
        //_loggingHandler = new LoggingHandler();
    }

    public bool Check_UserSession()
    {
       // LoginUserDetail loginUserDetail = (LoginUserDetail)HttpContext.Current.Session["LoginUserDetail"];

        int UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);

        if (UserID == 0)
        {
            return false;
        }
        else 
        {
            return true;
        }
        //    if (HttpContext.Current.Request.Cookies["UserID"] != null)
        //{
        //    string LoggedInUserId = HttpContext.Current.Request.Cookies["UserID"].Value;
        //    if (LoggedInUserId == "") {
        //        return false;
        //    }
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }

    public bool HasPermission(string requiredPermission)
    {      
        bool result = false;
        //double userID = Convert.ToDouble(HttpContext.Current.Request.Cookies["UserID"].Value);
        //int roleID = Convert.ToInt32(HttpContext.Current.Request.Cookies["UserRoleID"].Value);
        return true;
        //var data = (from r in dbContext.PermissionMappings
        //           where r.Permission_Description == requiredPermission
        //           select r).ToList();
        //if (data.Count > 0)
        //{
        //    foreach (var item in data)
        //    {
        //        int id = item.Menu_Id;
        //        bool read1 = item.ReadAction;
        //        bool write1 = item.WriteAction;
        //        bool delete1 = item.DeleteAction;

        //        var record = from r1 in dbContext.UserPermissions
        //                     where r1.MenuID == id && r1.UserID == userID
        //                     select r1;

        //        foreach (var item1 in record)
        //        {
        //            result = item1.ReadAction.Equals(read1);
        //            if (result == false)
        //            {
        //                result = item1.WriteAction.Equals(write1);
        //                if (result == true)
        //                {
        //                    break;
        //                }
        //            }
        //            else
        //            {
        //                break;
        //            }

        //        }
        //    }
        //    return result;
        //}
        //else
        //{
        //    return true;
        //}
    }
}