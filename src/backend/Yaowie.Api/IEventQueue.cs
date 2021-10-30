using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yaowie.Api.Transactions;

namespace Yaowie.Api
{
    public interface IEventQueue
    {
        public Task Add(string publicKey, Transaction transaction);
        public Task Clear(string publicKey);
    }
}
