using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models
{
    public class ProfileSaveRequestModel
    {
        public string usertoken { get; set; }
        public string mobileno { get; set; }
        public string gender { get; set; }
        public string maritalstatus { get; set; }
        public string bankcode { get; set; }
        public string bankaccountno { get; set; }
        public string addressline1 { get; set; }
        public string addressline2 { get; set; }
        public string City { get; set; }
        public string Statecode { get; set; }
        public string employercode { get; set; }
        public string employeenumber { get; set; }
        public string Salary { get; set; }
        public string Startdate { get; set; }
        public string Profilepic { get; set; }
    }

    public class ProfileSaveResponseModel
    {
        public int responsecode { get; set; } 
        public string responsemessage { get; set; } 
    }
}
