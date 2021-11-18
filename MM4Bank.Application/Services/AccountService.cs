using AutoMapper;
using MM4Bank.Application.Accounts.Commands;
using MediatR;
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

        public async Task<AccountDTO> AddAsync()
        {
            var command = new AccountCreateCommand();
            var accountEntity = await _mediator.Send(command);

            return _mapper.Map<AccountDTO>(accountEntity);
        }

        public async Task<TransactionDTO> WithdrawAsync(Guid? id, decimal value)
        {
            var command = new AccountWithdrawCommand(id.Value, value) ?? throw new ApplicationException("Entity could not be loaded"); ;
            var transactionEntity = await _mediator.Send(command);

            return _mapper.Map<TransactionDTO>(transactionEntity);
        }

        public async Task<TransactionDTO> DepositAsync(Guid? id, decimal value)
        {
            var command = new AccountDepositCommand(id.Value, value) ?? throw new ApplicationException("Entity could not be loaded"); ;
            var transactionEntity = await _mediator.Send(command);

            return _mapper.Map<TransactionDTO>(transactionEntity);
        }

        public async Task<TransactionDTO> SendTransferAsync(Guid? sourceId, Guid? targetId, decimal value)
        {
            if (sourceId is null) throw new ApplicationException("Source entity could not be loaded");
            if (targetId is null) throw new ApplicationException("Target entity could not be loaded");

            var command = new AccountTransferCommand(sourceId.Value, targetId.Value, value);
            var transactionEntity = await _mediator.Send(command);

            return _mapper.Map<TransactionDTO>(transactionEntity);
        }

        public async Task RemoveAsync(Guid? id)
        {
            var command = new AccountRemoveCommand(id.Value) ?? throw new ApplicationException("Entity could not be loaded");
            await _mediator.Send(command);
        }
    }
}
