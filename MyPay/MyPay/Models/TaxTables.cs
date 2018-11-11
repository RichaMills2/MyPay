using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPay.Models
{
    public class TaxTables
    {
        public int Id { get; set; }

        public decimal MinimumAmount { get; set; }

        public decimal MaximumAmount { get; set; }

        public decimal Amount { get; set; }
        public decimal TaxAmount { get; set; }

        public decimal Threshhold { get; set; }

        public int TaxYearEnding { get; set; }
    }
}