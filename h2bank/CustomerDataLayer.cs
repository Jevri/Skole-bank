using h2bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace h2bank
{
    public class CustomerDataLayer
    {
        public static void DeleteCustomer(int id)
        {
            using (var ctx = new BankContext())
            {
                var customer = ctx.Customers.SingleOrDefault(x => x.ID == id);
                ctx.Customers.Remove(customer);
                ctx.SaveChanges();
            }
        }

        public static void CreateCustomer(string firstname, string lastname)
        {
            using (var ctx = new BankContext())
            {
                ctx.Customers.Add(new Customer()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    CreationDate = DateTime.Now
                });
                ctx.SaveChanges();
            }
        }

        public static Customer[] GetAllCustomers()
        {
            using (var ctx = new BankContext())
            {
                return ctx.Customers.ToArray();
            }
        }

        public static Customer GetCustomer(int id)
        {
            using (var ctx = new BankContext())
            {
                return ctx.Customers.SingleOrDefault(x => x.ID == id);
            }
        }
    }
}