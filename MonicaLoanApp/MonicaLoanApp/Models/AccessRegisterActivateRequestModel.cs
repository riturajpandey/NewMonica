using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models
{
    public class AccessRegisterActivateRequestModel
    {
        public string usertoken { get; set; }
        public string validatetoken { get; set; }
    }
    public class AccessRegisterActivateResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
    }
}
