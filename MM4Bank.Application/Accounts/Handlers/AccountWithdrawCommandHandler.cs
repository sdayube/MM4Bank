using MM4Bank.Application.Accounts.Commands;
using MediatR;
using MM4Bank.Domain.Entities;
using MM4Bank.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MM4Bank.Application.Accounts.Handlers
{
    public class AccountWithdrawCommandHandler : IRequestHandler<AccountWithdrawCommand, Transaction>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountWithdrawCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Transaction> Handle(AccountWithdrawCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(request.Id);

            if (account is null)
            {
                throw new ApplicationException("Entity could not be found");
            }
            else
            {
                var transaction = await _accountRepository.WithdrawAsync(request.Id, request.Value);
                return transaction;
            }
        }
    }
}
