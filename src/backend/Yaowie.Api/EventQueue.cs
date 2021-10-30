using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yaowie.Api.Transactions;
using Yaowie.Api.Users;

namespace Yaowie.Api
{
    public class EventQueue : IEventQueue
    {
        private Dictionary<string, List<Transaction>> userTransactions = new Dictionary<string, List<Transaction>>();

        public Task Add(string publicKey, Transaction transaction)
        {
            if (!userTransactions.TryGetValue(publicKey, out var transactions))
            {
                transactions = new List<Transaction>();
            }

            transactions.Add(transaction);

            return Task.CompletedTask;
        }

        public Task Clear(string publicKey)
        {
            userTransactions.Remove(publicKey);
            return Task.CompletedTask;
        }
    }
}
