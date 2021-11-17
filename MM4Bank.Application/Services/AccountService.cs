using AutoMapper;
using CleanArchMvc.Application.Accounts.Commands;
using MediatR;
using MM4Bank.Application.Accounts.Commands;
using MM4Bank.Application.Accounts.Queries;
using MM4Bank.Application.DTOs;
using MM4Bank.Application.Interfaces;
using MM4Bank.Domain.Entities;
using MM4Bank.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MM4Bank.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AccountService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<AccountDTO>> GetAccountsAsync()
        {
            var query = new GetAccountsQuery() ?? throw new ApplicationException("Entities could not be loaded");
            var accountEntity = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<AccountDTO>>(accountEntity);
        }

        public async Task<AccountDTO> GetByIdAsync(Guid? id)
        {
            var query = new GetAccountByIdQuery(id.Value) ?? throw new ApplicationException("Entity could not be loaded");
            var accountEntity = await _mediator.Send(query);

            return _mapper.Map<AccountDTO>(accountEntity);
        }

        public async Task AddAsync(AccountDTO accountDTO)
        {
            var command = _mapper.Map<AccountCreateCommand>(accountDTO);
            await _mediator.Send(command);
        }

        public async Task UpdateAsync(AccountDTO accountDTO)
        {
            var command = _mapper.Map<AccountUpdateCommand>(accountDTO);
            await _mediator.Send(command);
        }

        public async Task RemoveAsync(Guid? id)
        {
            var command = new AccountRemoveCommand(id.Value) ?? throw new ApplicationException("Entity could not be loaded");
            await _mediator.Send(command);
        }
    }
}
