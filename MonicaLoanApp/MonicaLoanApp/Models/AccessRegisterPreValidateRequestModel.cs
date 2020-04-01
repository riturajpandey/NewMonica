using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models
{
    public class AccessRegisterPreValidateRequestModel
    {
        public string emailaddress { get; set; }
        public string bvn { get; set; }
    }
    public class AccessRegisterPreValidateResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
    }
}
