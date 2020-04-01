using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models.Loan
{
    public class LoanSearchRequestModel
    {
        public string usertoken { get; set; }
        public string loannumber { get; set; }
    }

    public class LoanSearchResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
        public List<Loan> loans { get; set; }
    }

    public class Loan
    {
        public string loannumber { get; set; }
        public string loanamount { get; set; }
        public string datecreated { get; set; }
        public string statuscode { get; set; }
        public string statusname { get; set; }
        public string loaninterestrate { get; set; }
        public string loaninterest { get; set; }
        public string loanbalance { get; set; }
        public string loantotal { get; set; }
        public string purposecode { get; set; }
        public string purposename { get; set; }
        public string durationperiod { get; set; }
        public string durationtotal { get; set; }
        public string employeesalarymonthly { get; set; }
        public string employercode { get; set; }
        public string employername { get; set; }
        public string employeenumber { get; set; }
        public string employeestartdate { get; set; }
        public string repaymenttypecode { get; set; }
        public string repaymenttypename { get; set; }
        public string declinereasoncode { get; set; }
        public string declinereasonname { get; set; }
        public string declinereasoncomments { get; set; }
        public List<Schedule> schedules { get; set; }

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

        public string EmployeeLoanDate
        {

            get
            {
                string date = string.Empty;

                try
                {
                    if (employeestartdate!=null)
                    {
                        var Day = employeestartdate.Substring(0, 2);
                        var Month = employeestartdate.Substring(3, 2);
                        var Year = employeestartdate.Substring(6, 4);
                        var monthname = Utilities.Utility.ConvertMonthIntoEnglishLanguage(Month);
                        date = Day + " " + monthname + " " + Year; 
                    }
                }
                catch (Exception ex)
                {
                }
                return date;
            }
            //get
            //{
            //    DateTime date;
            //    string loanDate = string.Empty;
            //    if (!string.IsNullOrEmpty(employeestartdate))
            //    {
            //        date = DateTime.Parse(employeestartdate);
            //        loanDate = date.ToString("d MMM yyyy");
            //    }
            //    return loanDate;
            //}
        }
    }

    public class Schedule
    {
        public string loanschedulenumber { get; set; }
        public string amounttotal { get; set; }
        public string duedate { get; set; }
        public string statuscode { get; set; }
        public string statusname { get; set; }
        public string ScheduleDate
        {
            get
            {
                string date = string.Empty;

                try
                {
                    var Day = duedate.Substring(0, 2);
                    var Month = duedate.Substring(3, 2);
                    var Year = duedate.Substring(6, 4);
                    var monthname = Utilities.Utility.ConvertMonthIntoEnglishLanguage(Month);
                    date = Day + " " + monthname + " " + Year;
                }
                catch (Exception ex)
                {
                }
                return date;
            }
            //get
            //{
            //    DateTime date;
            //    string loanDate = string.Empty;
            //    if (!string.IsNullOrEmpty(duedate))
            //    {
            //        date = DateTime.Parse(duedate);
            //        loanDate = date.ToString("d MMM yyyy");
            //    }
            //    return loanDate;
            //}
        }
    }
}
