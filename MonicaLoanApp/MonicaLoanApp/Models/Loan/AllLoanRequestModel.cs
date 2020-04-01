using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.Models.Loan
{
    public class AllLoanRequestModel
    {
        public string usertoken { get; set; }
    }

    public class AllLoanResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
        public List<AllLoan> loans { get; set; }
    }
    public class AllLoan
    {
        public string loannumber { get; set; }
        public string loanamount { get; set; }
        public string datecreated { get; set; }
        public string statuscode { get; set; }
        public string statusname { get; set; }

        //public DateTime LoanDate
        //{
        //    get
        //    {
        //        DateTime date;
        //        date = DateTime.Parse(datecreated); 
        //        return date;
        //    }
        //}

        public string LoanDate
        {
            get
            {
                string date = string.Empty;

                try
                {
                    var Day = datecreated.Substring(0, 2);
                    var Month = datecreated.Substring(3, 2);
                    var Year = datecreated.Substring(6, 4);
                    var monthname = Utilities.Utility.ConvertMonthIntoEnglishLanguage(Month);
                    date = Day + " " + monthname + " " + Year;
                }
                catch (Exception ex)
                {
                }
                return date;
            }
        }
    }
}
