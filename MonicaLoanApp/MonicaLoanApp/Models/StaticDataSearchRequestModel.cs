using System;
using System.Collections.Generic;
using System.Text;

namespace MonicaLoanApp.Models
{
    public class StaticDataSearchRequestModel
    {
    }
    public class StaticDataSearchResponseModel
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; }
        public List<Staticdata> staticdata { get; set; }
    }
    public class Staticdata
    {
        public string type { get; set; }
        public string key { get; set; }
        public string data { get; set; }
    }
}
