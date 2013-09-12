using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesNet.Models
{
    public class TransFilter
    {
        public string TransNumber { get; set; }
        public string CustRef { get; set; }
        public string CreatedDateFrom { get; set; }
        public string CreatedDateTo { get; set; }
        public string DueDateFrom { get; set; }
        public string DueDateTo { get; set; }
        public string ProductFilter { get; set; }
        public string TransType { get; set; }
    }
}