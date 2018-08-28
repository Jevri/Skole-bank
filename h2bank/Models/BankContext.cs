using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace h2bank.Models
{
    public class BankContext: DbContext
    {
        public BankContext(): base()
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasRequired(n => n.Customer)
            .WithMany(n => n.Accounts)
            .WillCascadeOnDelete(true);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}