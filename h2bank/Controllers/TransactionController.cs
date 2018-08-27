using h2bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace h2bank.Controllers
{
    public class NewTransaction
    {
        public int account;
        public decimal amount;
    }
    public class TransactionController : ApiController
    {
        [HttpGet]
        public Transaction[] GetTransactions(int id)
        {
            return TransactionDataLayer.GetTransactions(id);
        }

        [HttpPost]
        public void MakeTransaction(NewTransaction transaction)
        {
            TransactionDataLayer.MakeTransaction(transaction.account, transaction.amount);
        }
    }
}
