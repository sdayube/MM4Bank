using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MM4Bank.Application.DTOs;
using MM4Bank.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MM4Bank.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> Get()
        {
            var transactions = await _transactionService.GetTransactionsAsync();

            if (transactions is null)
            {
                return NotFound("Accounts not found");
            }

            return Ok(transactions);
        }

        [HttpGet("{id:guid}", Name = "GetTransactionById")]
        public async Task<ActionResult<TransactionDTO>> GetById(Guid id)
        {
            var transaction = await _transactionService.GetByIdAsync(id);

            if (transaction is null)
            {
                return NotFound("Account not found");
            }

            return Ok(transaction);
        }
    }
}
