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
        public void CreateCustomer(NewCustomer customer)
        {
            CustomerDataLayer.CreateCustomer(customer.Firstname, customer.Lastname);
        }
        [HttpDelete]
        public void DeleteCustomer(int customer)
        {
            CustomerDataLayer.DeleteCustomer(customer);
        }
        [HttpGet]
        public Customer GetCusomer(int customer)
        {
            return CustomerDataLayer.GetCustomer(customer);
        }
    }
}
