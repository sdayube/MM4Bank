using Microsoft.AspNetCore.Mvc;
using MM4Bank.Application.DTOs;
using MM4Bank.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> Get()
        {
            var categories = await _transactionService.GetTransactionsAsync();
            if (categories == null)
            {
                return NotFound("Categories not found");
            }
            return Ok(categories);
        }

        [HttpGet("{id:Guid}", Name = "GetTransaction")]
        public async Task<ActionResult<TransactionDTO>> Get(Guid id)
        {
            var transaction = await _transactionService.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound("Transaction not found");
            }
            return Ok(transaction);
        }

    }
}