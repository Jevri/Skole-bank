using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace h2bank.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Account Account { get; set; }
    }
}