using MonicaLoanApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MonicaLoanApp.Helpers
{
    public class Constants
    {
        //To maintain user toekn..
        public static string UserToken = string.Empty;
        //To maintain user toekn..
        public static string LoginUserToken = string.Empty;
        //To maintain user toekn..
        public static string LoginUserSecret = string.Empty;
        //To maintain multiple times click...
        public static int PageCount = 0; 

        //To maintain variable for image from camera/gallery
        public static string imgFilePath = string.Empty;
        //To maintain variable for Media picker selected items
        public static string PartImageBase64 = string.Empty;
        public static string LoanSubmitSms = string.Empty;


        //To maintain Registration constants
        public static bool IsVerifyToken = false;

        //To maintain variable for user get profile data...
        public static string ProfileNumber = string.Empty;
        public static string UserLoanbalance = string.Empty;
        public static string UserDuebalance = string.Empty;
        public static string UserFirstname = string.Empty;
        public static string UserMiddlename = string.Empty;
        public static string UserLastname = string.Empty;
        public static string UserEmailAddress = string.Empty;
        public static string Usermobileno = string.Empty;
        public static string Usergender = string.Empty;
        public static string UserMaritalstatus = string.Empty;
        public static string UserDateofbirth = string.Empty;
        public static string UserBvn = string.Empty;
        public static string UserBankcode = string.Empty;
        public static string UserBankname = string.Empty;
        public static string UserBankaccountno = string.Empty;
        public static string UserAddressline1 = string.Empty;
        public static string UserAddressline2 = string.Empty;
        public static string UserCity = string.Empty;
        public static string UserStatecode = string.Empty;
        public static string UserStateName = string.Empty;
        public static string UserEmployercode = string.Empty;
        public static string UserEmployername = string.Empty;
        public static string UserEmployeenumber = string.Empty;
        public static string UserSalary = string.Empty;
        public static string UserStartdate = string.Empty;
        public static string Userprofilepic = string.Empty;


        public static ObservableCollection<Staticdata> StaticDataList = new ObservableCollection<Staticdata>();
    }
}
