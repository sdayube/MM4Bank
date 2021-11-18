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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> Get()
        {
            var categories = await _accountService.GetAccountsAsync();
            if (categories == null)
            {
                return NotFound("Categories not found");
            }
            return Ok(categories);
        }

        [HttpGet("{id:Guid}", Name = "GetAccount")]
        public async Task<ActionResult<AccountDTO>> Get(Guid id)
        {
            var account = await _accountService.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound("Account not found");
            }
            return Ok(account);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AccountDTO accountDto)
        {
            if (accountDto == null)
                return BadRequest("Invalid Data");

            await _accountService.AddAsync(accountDto);

            return new CreatedAtRouteResult("GetAccount", new { id = accountDto.Id }, 
                accountDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Guid id,[FromBody] AccountDTO accountDto)
        {
            if (id != accountDto.Id)
                return BadRequest();

            if (accountDto == null)
                return BadRequest();

            await _accountService.UpdateAsync(accountDto);

            return Ok(accountDto);
        }          
        
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<AccountDTO>> Delete(Guid id)
        {
            var account = await _accountService.GetByIdAsync(id);
            if(account == null)
            {
                return NotFound("Account not found");
            }
            
            await _accountService.RemoveAsync(id);

            return Ok(account);

        }
    }
}