using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models.Loan
{
    public class LoanRespondRequestModel
    {
        public string usertoken { get; set; }
        public string loannumber { get; set; }
        public string action { get; set; }
        public string declinereasoncode { get; set; } 
    }

    public class LoanRespondResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; } 
    }
}
