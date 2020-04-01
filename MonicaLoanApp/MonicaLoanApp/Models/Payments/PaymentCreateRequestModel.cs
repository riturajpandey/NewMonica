using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models.Payments
{
    public class PaymentCreateRequestModel
    {
        public string usertoken { get; set; }
        public string loannumber { get; set; }
        public string loanschedulenumber { get; set; }
        public string amount { get; set; }
        public string paymentmethodcode { get; set; }
    }

    public class PaymentCreateResponseModel
    {
        public int responsecode { get; set; } 
        public string responsemessage { get; set; }
        public string paymentnumber { get; set; }
        public string paymentstatuscode { get; set; }
        public string paymentstatusname { get; set; }
    }
}
