using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace h2bank.Models
{
    public class Account
    {
        public int ID { get; set; }
        public decimal InterestRate { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreationDate { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}