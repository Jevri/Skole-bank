using h2bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace h2bank.Controllers
{
    public class NewCustomer
    {
        public string Firstname;
        public string Lastname;
    }
    public class CustomerController : ApiController
    {
        [HttpPost]
        public int? CreateCustomer(NewCustomer customer)
        {
            if (customer != null)
            {
                return CustomerDataLayer.CreateCustomer(customer.Firstname, customer.Lastname);
            }
            return null;
        }
        [HttpDelete]
        public bool DeleteCustomer(int customer)
        {
            return CustomerDataLayer.DeleteCustomer(customer);
        }
        [HttpGet]
        public Customer GetCusomer(int customer)
        {
            return CustomerDataLayer.GetCustomer(customer);
        }
    }
}
