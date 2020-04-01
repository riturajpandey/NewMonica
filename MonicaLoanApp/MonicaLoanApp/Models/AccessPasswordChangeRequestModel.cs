using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models
{
    public class AccessPasswordChangeRequestModel
    {
        public string emailaddress { get; set; }
        public string validatetoken { get; set; }
        public string password { get; set; }
    }
    public class AccessPasswordChangeResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
    }
    public class ResendCodeRequestModel
    {
        public string emailaddress { get; set; } 
    }
}
