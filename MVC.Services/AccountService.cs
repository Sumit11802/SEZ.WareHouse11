using MVC.Domain.Model;
using MVC.Repository;
using MVC.Repository.Interface;
using MVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class AccountService : IAccountService
    {
        public AccountRepository accountRepostory = new AccountRepository();

        //public AccountService(IAccountRepository accountRepostory)
        //{
        //    this.accountRepostory = accountRepostory;
        //}

        public UserLoginDetails UserLogin(string name, string pass , string dept)
        {
            DataTable loginData = new DataTable();
            loginData = accountRepostory.Login(name, pass, dept);
            UserLoginDetails objLoginData = new UserLoginDetails();
            if (loginData.Rows.Count > 0)
            {

                foreach (DataRow row in loginData.Rows)
                {
                    objLoginData.UserID = Convert.ToInt32(row["UserID"]);
                    objLoginData.UserName = Convert.ToString(row["UserName"]);
                    //objLoginData.RoleID = Convert.ToInt32(row["RoleID"]);
                    //objLoginData.UserRole = Convert.ToString(row["RoleName"]);
                    //objLoginData.DeptID = Convert.ToInt32(row["DeptID"]);

                }
            }
            return objLoginData;
        }



        public List<Menus> GetSideMenu(int userid)
        {
            List<Menus> MenuList = new List<Menus>();
            DataTable MenurDL = new DataTable();
            MenurDL = accountRepostory.GetSideMenu(userid);

            if (MenurDL != null)
            {
                foreach (DataRow row in MenurDL.Rows)
                {
                    Menus MenuInfoList = new Menus();

                    MenuInfoList.MenuID = Convert.ToInt32(row["MenuID"]);
                    MenuInfoList.MenuName = Convert.ToString(row["MenuName"]);
                    MenuInfoList.ParentID = Convert.ToInt32(row["ParentID"]);
                    MenuInfoList.ControllerName = Convert.ToString(row["Controller"]);
                    MenuInfoList.Action = Convert.ToString(row["Action"]);
                    MenuInfoList.menuIcon = Convert.ToString(row["MenuIcon"]);
                    MenuList.Add(MenuInfoList);
                }
            }
            return MenuList;
        }

        public List<UserRights> GetUserRigths()
        {
            List<UserRights> rights = new List<UserRights>();
            DataTable rightsData = new DataTable();

            rightsData = accountRepostory.UserRights();
            if (rightsData.Rows.Count > 0)
            {

                foreach (DataRow row in rightsData.Rows)
                {
                    UserRights objRightsData = new UserRights();

                    objRightsData.UserId = Convert.ToInt32(row["UserID"]);
                    objRightsData.MenuId = Convert.ToString(row["MenuID"]);
                    objRightsData.CanAdd = Convert.ToBoolean(row["CanAdd"]);
                    //objLoginData.UserType = Convert.ToString(row["UserType"]);
                    objRightsData.CanUpdate = Convert.ToBoolean(row["CanUpdate"]);
                    //objRightsData.CanDelete = Convert.ToBoolean(row["CanDelete"]);
                    objRightsData.CanView = Convert.ToBoolean(row["CanView"]);
                   // objRightsData.IsAction = Convert.ToBoolean(row["IsAccess"]);
                    // objLoginData.UserRole = Convert.ToString(row["UserRole"]);
                    rights.Add(objRightsData);
                }
            }
            return rights;
        }

        public int ResetPassword(string userid, int loginid, string otp, string action)
        {
            DataTable dt = new DataTable();
            dt = accountRepostory.ResetPassword(userid, loginid, otp, action);

            int result = 0;
            if (dt.Rows.Count > 0)
            {
                result = Convert.ToInt32(dt.Rows[0][0].ToString());
            }

            return result;
        }
        public string SaveUserRight(DataTable UserRightData, int UserID)
        {
            string Message = "";

            Message = accountRepostory.SaveUserRight(UserRightData,UserID);

            return Message;
        }

        public List<User> UserName()
        {

            List<User> fromList = new List<User>();
            DataTable DL = new DataTable();
            DL = accountRepostory.UserNameFill();

            if (DL != null)
            {
                foreach (DataRow row in DL.Rows)
                {
                    User List = new User();

                    List.UserID = Convert.ToString(row["UserID"]);
                    List.USerName = Convert.ToString(row["UserName"]);
                    fromList.Add(List);
                }
            }
            return fromList;
        }
        public string CheckFirstName(string HorseNumber)
        {
            string Message = "";
            DataTable CheckHorseDlL = new DataTable();
            CheckHorseDlL = accountRepostory.CheckFirstName(HorseNumber);

            if (CheckHorseDlL.Rows.Count > 0)
            {
                int HorseCount = Convert.ToInt16(CheckHorseDlL.Rows[0]["UserName"]);
                if (HorseCount > 0)
                {
                    Message = "1";

                }
            }

             
            return Message;
        }

        public List<User> UserDetails(string UserID)
        {
            List<User> passingDL = new List<User>();
            DataTable dt = new DataTable();
            dt = accountRepostory.EditUser(UserID);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    User PassingList = new User();
                    PassingList.firstname = Convert.ToString(row["UserName"]);
                    PassingList.lastname = Convert.ToString(row["UserName"]);
                    PassingList.gender = Convert.ToString(row["Gender"]);
                    PassingList.DOB = Convert.ToString(row["DOB"]);
                    PassingList.employeeid = Convert.ToString(row["EMPID"]);
                    PassingList.password = Convert.ToString(row["UserPass"]);
                    PassingList.department = Convert.ToString(row["DepType"]);
                    PassingList.userType = Convert.ToString(row["UserType"]);
                    PassingList.emailid = Convert.ToString(row["email_ID"]);
                    PassingList.passEmail = Convert.ToString(row["email_Pswrd"]);
                    PassingList.Contact = Convert.ToString(row["ContactNo"]);
                    PassingList.isactive = Convert.ToString(row["IsActive"]);
                    PassingList.UseriDN = Convert.ToInt32(row["UserID"]);

                    passingDL.Add(PassingList);
                }
            }
            return passingDL;
        }

    }
}
