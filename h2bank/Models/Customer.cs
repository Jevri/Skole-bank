using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace h2bank.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}