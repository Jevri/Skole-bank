using h2bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace h2bank
{
    public class CustomerDataLayer
    {
        public static bool DeleteCustomer(int id)
        {
            using (var ctx = new BankContext())
            {
                var customer = ctx.Customers.SingleOrDefault(x => x.ID == id);
                if (customer != null) {
                    ctx.Customers.Remove(customer);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static int CreateCustomer(string firstname, string lastname)
        {
            var customer = new Customer()
            {
                FirstName = firstname,
                LastName = lastname,
                CreationDate = DateTime.Now
            };
            using (var ctx = new BankContext())
            {
                ctx.Customers.Add(customer);
                ctx.SaveChanges();

            }
            return customer.ID;
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
                return ctx.Customers.FirstOrDefault(x => x.ID == id);
            }
        }
    }
}