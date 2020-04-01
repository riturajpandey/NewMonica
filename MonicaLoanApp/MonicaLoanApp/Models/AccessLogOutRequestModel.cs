using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models
{
    public class AccessLogOutRequestModel
    {
        public string usertoken { get; set; }
    }
    public class AccessLogOutResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
    }
}
