using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models
{
    public class SaveDataRequestModel
    {
        public string mobileno { get; set; }
        public string gender { get; set; }
        public string maritalstatus { get; set; }
        public string addressline1 { get; set; }
        public string addressline2 { get; set; }
        public string city { get; set; }
        public string statecode { get; set; }
        public string employercode { get; set; }
        public string employeenumber { get; set; }
        public double salary { get; set; }
        public string startdate { get; set; }
        public string profilepic { get; set; }
    }
    public class SaveDataResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
    }
}
