using h2bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace h2bank
{
    public class TransactionDataLayer
    {
        public static void MakeTransaction(int accountId, decimal amount)
        {
            using (var ctx = new BankContext())
            {
                var account = ctx.Accounts.SingleOrDefault(x => x.ID == accountId);
                account.Balance += amount;
                ctx.Transactions.Add(new Transaction()
                {
                    Amount = amount,
                    Date = DateTime.Now,
                    Account = account,
                });
                ctx.SaveChanges();
            }
        }

        public static Transaction[] GetTransactions(int accountId)
        {
            using (var ctx = new BankContext())
            {
                var transactions = ctx.Accounts.SingleOrDefault(x => x.ID == accountId);
                return transactions == null ? null : transactions.Transactions.ToArray();
            }
        }
    }
}