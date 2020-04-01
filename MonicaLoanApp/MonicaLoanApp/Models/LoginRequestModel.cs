using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models
{
    public class LoginRequestModel
    {
        public string emailaddress { get; set; }
        public string password { get; set; }
    }
    public class LoginResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
        public string usertoken { get; set; }
        public string usersecret { get; set; }
    }
}
