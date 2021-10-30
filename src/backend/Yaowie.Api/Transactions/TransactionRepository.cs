using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yaowie.Api.Transactions
{
    public interface ITransactionRepository
    {
        Task Add(Transaction transaction);
    }

    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> database = new List<Transaction>();

        public Task Add(Transaction transaction)
        {
            database.Add(transaction);
            return Task.CompletedTask;
        }

    }
}
