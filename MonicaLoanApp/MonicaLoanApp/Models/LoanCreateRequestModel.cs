using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models
{
    public class LoanCreateRequestModel
    {
        public string usertoken { get; set; }
        public int loanamount { get; set; }
        public string durationperiod { get; set; }
        public int durationtotal { get; set; }
        public int employeesalarymonthly { get; set; }
        public string employercode { get; set; }
        public string purposecode { get; set; }
        public string employeenumber { get; set; }
        public string employeestartdate { get; set; }
        public string employeeidcard { get; set; }
    }
    public class LoanCreateResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
        public string loannumber { get; set; }
        public string status { get; set; }
        public string statusname { get; set; }
    }
}
