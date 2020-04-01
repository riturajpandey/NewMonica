using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// Checking
    /// </summary> 
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants
        private const string AccessToken = "AccessToken";
        private static readonly string AccessTokenDefault = string.Empty;

        private const string LoanNumber = "LoanNumber";
        private static readonly string LoanNumberDefault = string.Empty;

        private const string StaticDataResponse = "StaticDataResponse";
        private static readonly string StaticDataResponseDefault = string.Empty;


        public static string GeneralAccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(AccessToken, AccessTokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AccessToken, value);
            }
        }
        public static string GeneralStaticDataResponse
        {
            get
            {
                return AppSettings.GetValueOrDefault(StaticDataResponse, StaticDataResponseDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(StaticDataResponse, value);
            }
        }
        public static string GeneralLoanNumber
        {
            get
            {
                return AppSettings.GetValueOrDefault(LoanNumber, LoanNumberDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LoanNumber, value);
            }
        }


        #region JSONS

        private const string ProfileData = "ProfileData";
        private static readonly string ProfileDataDefault = string.Empty;

        public static string GeneralProfileDataJSON
        {
            get
            {
                return AppSettings.GetValueOrDefault(ProfileData, ProfileDataDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ProfileData, value);
            }
        }
        #endregion

        //public static string UserLoanBalance
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(LoanBalance, LoanBalanceDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(LoanBalance, value);
        //    }
        //}
        //public static string UserDueBalance
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(DueBalance, DueBalanceDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(DueBalance, value);
        //    }
        //}
        //public static string UserFirstname
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Firstname, FirstnameDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Firstname, value);
        //    }
        //}
        //public static string UserMiddlename
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Middlename, MiddlenameDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Middlename, value);
        //    }
        //}
        //public static string UserLastname
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Lastname, LastnameDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Lastname, value);
        //    }
        //}
        //public static string UserEmailaddress
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Emailaddress, EmailaddressDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Emailaddress, value);
        //    }
        //}
        //public static string UserMobileno
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Mobileno, MobilenoDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Mobileno, value);
        //    }
        //}
        //public static string UserGender
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Gender, GenderDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Gender, value);
        //    }
        //}
        //public static string UserMaritalstatus
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Maritalstatus, MaritalstatusDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Maritalstatus, value);
        //    }
        //}
        //public static string UserBvn
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Bvn, BvnDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Bvn, value);
        //    }

        //}
        //public static string UserDateofbirth
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Dateofbirth, DateofbirthDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Dateofbirth, value);
        //    }
        //}
        //public static string UserBankcode
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Bankcode, BankcodeDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Bankcode, value);
        //    }
        //}
        //public static string UserBankname
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Bankname, BanknameDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Bankname, value);
        //    }
        //}
        //public static string UserBankaccountno
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Bankaccountno, BankaccountnoDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Bankaccountno, value);
        //    }
        //}
        //public static string UserAddressline1
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Addressline1, Addressline1Default);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Addressline1, value);
        //    }
        //}
        //public static string UserAddressline2
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Addressline2, Addressline2Default);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Addressline2, value);
        //    }
        //}
        //public static string UserCity
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(City, CityDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(City, value);
        //    }
        //}
        //public static string UserStatecode
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Statecode, StatecodeDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Statecode, value);
        //    }
        //} 
        //public static string UserStatename
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Statename, StatenameDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Statename, value);
        //    }
        //}
        //public static string UserEmployercode
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Employercode, EmployercodeDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Employercode, value);
        //    }
        //}
        //public static string UserEmployername
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Employername, EmployernameDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Employername, value);
        //    }
        //}
        //public static string UserEmployeenumber
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Employeenumber, EmployeenumberDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Employeenumber, value);
        //    }
        //}
        //public static string UserSalary
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Salary, SalaryDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Salary, value);
        //    }
        //}
        //public static string UserStartdate
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Startdate, StartdateDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Startdate, value);
        //    }
        //}
        //public static string UserProfilepic
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(Profilepic, ProfilepicDefault);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(Profilepic, value);
        //    }
        //}
        #endregion

    }
}
