using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yaowie.Api.Users;

namespace Yaowie.Api.Transactions
{
    public class Transaction
    {
        private Guid id;
        private decimal value;
        private User receiver;
        private User sender;

        private Transaction(Guid id, decimal value, User receiver, User sender)
        {
            this.id = id;
            this.value = value;
            this.receiver = receiver;
            this.sender = sender;
        }

        public static Transaction Create(Guid id, decimal value, User receiver, User sender)
        {
            return new Transaction(id, value, receiver, sender);
        }
    }
}
