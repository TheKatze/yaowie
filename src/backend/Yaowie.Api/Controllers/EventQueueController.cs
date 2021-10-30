using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yaowie.Api.Transactions;

namespace Yaowie.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventQueueController : ControllerBase
    {
        private IEventQueue eventQueue;
        private ITransactionRepository transactionRepository;
        public EventQueueController(IEventQueue eventQueue, ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
            this.eventQueue = eventQueue;
        }

        [HttpGet("{publicKey}")]
        public List<Transaction> GetEventQueueTransactions([FromRoute] string publicKey)
        {
            List<Transaction> transactions = eventQueue.GetAllFromId(publicKey);
            return transactions;
        }
    }
}
