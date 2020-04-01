using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models
{
    public class AccessPasswordReminderRequestModel
    {
        public string emailaddress { get; set; }
    }
    public class AccessPasswordReminderResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
    }
}
