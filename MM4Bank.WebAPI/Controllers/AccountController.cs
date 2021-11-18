using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MM4Bank.Application.DTOs;
using MM4Bank.Application.Interfaces;
using MM4Bank.Domain.Validation;
using MM4Bank.WebAPI.JsonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MM4Bank.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;

        public AccountController(IAccountService accountService, ITransactionService transactionService)
        {
            _accountService = accountService;
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> Get()
        {
            var accounts = await _accountService.GetAccountsAsync();

            if (accounts is null)
            {
                return NotFound("Accounts not found");
            }

            return Ok(accounts);
        }

        [HttpGet("{id:guid}", Name = "GetAccount")]
        public async Task<ActionResult<AdvancedAccountDTO>> GetById(Guid id)
        {
            var account = await _accountService.GetByIdAsync(id);
            var allTransactions = await _transactionService.GetTransactionsAsync();

            var incomingTransactions = allTransactions.Where(t => t.TargetAccountId == id).Select(t => t.Id).ToList();
            var outgoingTransactions = allTransactions.Where(t => t.SourceAccountId == id).Select(t => t.Id).ToList();

            if (account is null)
            {
                return NotFound("Account not found");
            }

            var accountData = AdvancedAccountDTO.ConvertAccountDTO(account, incomingTransactions, outgoingTransactions);

            return Ok(accountData);
        }

        [HttpPost]
        public async Task<ActionResult> Create()
        {
            var newAccount = await _accountService.AddAsync();

            return new CreatedAtRouteResult("GetAccount", new { id = newAccount.Id }, newAccount);
        }

        [HttpPut("{id}/Deposit")]
        public async Task<ActionResult> Deposit(Guid id, [FromBody] SimpleTransaction deposit)
        {
            if (deposit is null || id != deposit.Id) return BadRequest();

            try
            {
                var transaction = await _accountService.DepositAsync(id, deposit.Value);
                return Ok(transaction);
            }
            catch (DomainExceptionValidation e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}/Withdraw")]
        public async Task<ActionResult> Withdraw(Guid id, [FromBody] SimpleTransaction withdrawal)
        {
            if (withdrawal is null || id != withdrawal.Id) return BadRequest();

            try
            {
                var transaction = await _accountService.WithdrawAsync(id, withdrawal.Value);
                return Ok(transaction);
            }
            catch (DomainExceptionValidation e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}/SendTransfer")]
        public async Task<ActionResult> SendTransfer(Guid id, [FromBody] Transfer transfer)
        {
            if (transfer is null || id != transfer.SourceId) return BadRequest();

            try
            {
                var transaction = await _accountService.SendTransferAsync(id, transfer.TargetId, transfer.Value);
                return Ok(transaction);
            }
            catch (DomainExceptionValidation e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var account = await _accountService.GetByIdAsync(id);

            if (account is null)
            {
                return NotFound("Account not found");
            }


            await _accountService.RemoveAsync(id);

            return Ok(account);
        }
    }
}
