using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class UserLoginDetails 
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public int  RoleID { get; set; }
        public int DeptID { get; set; }
        public string UserRole { get; set; }
        public string EmailID { get; set; }
        // token to authorize each individual request 
        public string Token { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public bool Remember { get; set; }

       
    }

    public class User
    {
        public string firstname { get; set; }

        public string lastname { get; set; }
        public string gender { get; set; }
        public string DOB { get; set; }
        public string employeeid { get; set; }
        public string password { get; set; }
        public string department { get; set; }
        public string userType { get; set; }
        public string emailid { get; set; }
        public string passEmail { get; set; }
        public string Contact { get; set; }
        public string isactive { get; set; }
        public string GroupID { get; set; }
        public String Name { get; set; }
        public int UseriDN { get; set; }
        public string icon { get; set; }
        public string MenuDesc { get; set; }
        public string MenuDept { get; set; }
        public string fromName { get; set; }
        public string menuName { get; set; }
        public int menudeptid { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Menu { get; set; }
        public string UserID { get; set; }
        public string USerName { get; set; }
        public int FuelVID { get; set; }
        public string FuelVName { get; set; }
        public int FuelTID { get; set; }
        public string FuelType { get; set; }
        public string fuelrate { get; set; }
        public string fuelDate { get; set; }
    }

    public class UserImportantDetail
    {
        public string UserName { get; set; }
        public string Role { get; set; }
        public int PDCount { get; set; }
        public int NPDCount { get; set; }
        public int LoginDays { get; set; }
        public int ConversionRatio { get; set; }
        public int TotalStar { get; set; }
    }

    public class UserBasicData
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Data3 { get; set; }
    }

    public class UserRewardData
    {
        //public int ID { get; set; }
        public string UserName { get; set; }
        public string FormName { get; set; }
        public string Points { get; set; }
        public DateTime AddedOn { get; set; }
    }

    public class TwentyStarUser
    {
        public int UserID { get; set; }
        //public string title { get; set; }
        public string UserName { get; set; }
        public DateTime CurrentDate { get; set; }
        public int User { get; set; }
        public string Branch { get; set; }
        public string City { get; set; }
        public int TotalUser { get; set; }
        public double TotalStar { get; set; }
    }

    public class BasicUserDetail
    {

        public int UserID { get; set; }

        public int RoleID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


    }

    public class ProfileDetail
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public string StayingWith { get; set; }
        public string Hobbies { get; set; }
        public string FamilyBackground { get; set; }
        public string Experience { get; set; }
        public string AboutSelf { get; set; }

    }

    public class UserTraining
    {
        public int TrainingID { get; set; }
        public int DeptID { get; set; }
        public int DayID { get; set; }
        public int ProgrammeID { get; set; }
        public int UserID { get; set; }
        public int Status { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsActive { get; set; }
        public int AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }

    }

    public class UserForgotPasswordDetail
    {

        public int UserID { get; set; }
        public string UserName { get; set; }
        public int RoleID { get; set; }
        public int DeptID { get; set; }
        public string UserRole { get; set; }
        public string UserMobile { get; set; }
        public string SeniorMobile { get; set; }
        public string SeniorName { get; set; }


    }
}
