using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yaowie.Api.Transactions;

namespace Yaowie.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService transactionService;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService)
        {
            _logger = logger;
            this.transactionService = transactionService;
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] TransactionCreationDto dto)
        {
            await transactionService.CreateTransaction(dto);

            return Created("", "");
        }

    }
}
