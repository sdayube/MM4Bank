using MediatR;
using MM4Bank.Application.Accounts.Commands;
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
    public class AccountCreateCommandHandler : IRequestHandler<AccountCreateCommand, Account>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountCreateCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> Handle(AccountCreateCommand request, CancellationToken cancellationToken)
        {
            var account = new Account();

            if (account is null)
            {
                throw new ApplicationException("Error creating entity");
            }

            return await _accountRepository.CreateAsync(account);
        }
    }
}
