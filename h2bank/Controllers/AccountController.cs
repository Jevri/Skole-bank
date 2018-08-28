﻿using h2bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace h2bank.Controllers
{
    public class NewAccount
    {
        public int Customer;
        public string AccountType;
    }
    public class AccountController : ApiController
    {
        [HttpPost]
        public void CreateAccount(NewAccount account)
        {
            if (account != null)
            {
                AccountDataLayer.CreateAccount(account.Customer, AccountDataLayer.GetInterestForType(account.AccountType));
            }
        }
        [HttpDelete]
        public void DeleteAccount(int account)
        {
            AccountDataLayer.DeleteAccount(account);
        }
        [HttpGet]
        public Account[] GetAccount(int id, string getby)
        {
            switch (getby)
            {
                case "customer":
                    return AccountDataLayer.GetAllAccounts(id);
                case "account":
                default:
                    return AccountDataLayer.GetAccount(id);
            }
        }
    }
}
