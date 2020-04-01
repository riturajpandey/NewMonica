using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models.Payments
{
    public class PaymentSearchRequestModel
    {
        public string usertoken { get; set; }
    }

    public class PaymentSearchResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
        public List<Payment> payments { get; set; } 
    }
    public class Payment
    {
        public string paymentnumber { get; set; }
        public string amount { get; set; }
        public string datecreated { get; set; }
        public string paymentdetails { get; set; }
        public string statuscode { get; set; }
        public string statusname { get; set; }
        public string PaymentDate
        {
            get
            {
                DateTime date;
                string paymentDate = string.Empty;
                date = Convert.ToDateTime(datecreated);
                paymentDate = date.ToString("d MMM yyyy");
                return paymentDate;
            }
        }
    }
}
