using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models
{
    public class ProfileGetRequestModel
    {
        public string usertoken { get; set; }
    }
    public class ProfileGetResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
        public string profilenumber { get; set; }
        public string loanbalance { get; set; }
        public string duesoon { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string emailaddress { get; set; }
        public string mobileno { get; set; }
        public string gender { get; set; }
        public string maritalstatus { get; set; }
        public string dateofbirth { get; set; }
        public string bvn { get; set; }
        public string bankcode { get; set; }
        public string bankname { get; set; }
        public string bankaccountno { get; set; }
        public string addressline1 { get; set; }
        public string addressline2 { get; set; }
        public string city { get; set; }
        public string statecode { get; set; }
        public string statename { get; set; }
        public string employercode { get; set; }
        public string employername { get; set; }
        public string employeenumber { get; set; }
        public string salary { get; set; }
        public string startdate { get; set; }
        public string profilepic { get; set; }
    }
}
