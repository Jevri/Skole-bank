using h2bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace h2bank
{
    public class AccountDataLayer
    {
        public static decimal GetInterestForType(string type)
        {
            //this function could allso lookup in a database
            switch (type)
            {
                case "buisness":
                    return 0.5M;
                case "normal":
                default:
                    return 0;
            }
        }
        public static Account[] GetAllAccounts(int customerId)
        {
            using (var ctx = new BankContext())
            {
                return ctx.Accounts.Where(x => x.Customer.ID == customerId).ToArray();
            }
        }

        public static Account[] GetAccount(int id)
        {
            using (var ctx = new BankContext())
            {
                return ctx.Accounts.Where(x => x.ID == id).ToArray();
            }
        }

        public static int CreateAccount(int CustomerId, decimal interest)
        {
            using (var ctx = new BankContext())
            {
                var account = new Account()
                {
                    InterestRate = interest,
                    CreationDate = DateTime.Now,
                    Balance = 0,
                    Customer = ctx.Customers.FirstOrDefault(x => x.ID == CustomerId)
                };
                ctx.Accounts.Add(account);
                ctx.SaveChanges();
                return account.ID;
            }
        }

        public static bool DeleteAccount(int id)
        {
            using (var ctx = new BankContext())
            {
                var account = ctx.Accounts.SingleOrDefault(x => x.ID == id);
                if (account != null)
                {
                    ctx.Accounts.Remove(account);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}