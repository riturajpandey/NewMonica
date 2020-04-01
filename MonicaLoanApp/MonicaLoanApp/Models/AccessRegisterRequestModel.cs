using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models
{
    public class AccessRegisterRequestModel
    {
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string emailaddress { get; set; }
        public string password { get; set; }
        public string mobileno { get; set; }
        public string gender { get; set; }
        public string maritalstatus { get; set; }
        public string dateofbirth { get; set; }
        public string bvn { get; set; }
        public string bankcode { get; set; }
        public string bankaccountno { get; set; }
    }
    public class AccessRegisterResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
        public string usertoken { get; set; }
    }
}
